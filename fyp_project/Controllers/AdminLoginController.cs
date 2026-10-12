using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fyp_project.Models;
using fyp_project.DTO;
using fyp_project.Services;

namespace fyp_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly WorkforceManagementDbContext _context;
        private readonly TokenService _tokenService;
        private readonly EmailService _emailService;

        public UserLoginController(
            WorkforceManagementDbContext context,
            TokenService tokenService,
            EmailService emailService)
        {
            _context = context;
            _tokenService = tokenService;
            _emailService = emailService;
        }

        [HttpPost("loginUser")]
        public async Task<IActionResult> Login([FromBody] Login obj)
        {
            try
            {
                // 1. Email se user retrieve karo
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Email == obj.Email);

                if (user == null)
                {
                    return Unauthorized(new
                    {
                        message = "Invalid email or password."
                    });
                }

                // 2. Check karo account active hai ya nahi
                if (!user.IsActive)
                {
                    return Unauthorized(new
                    {
                        message = "Account is inactive."
                    });
                }

                // 3. Password verify karo
                bool passwordVerify = BCrypt.Net.BCrypt.Verify(
                    obj.Password,
                    user.PasswordHash
                );

                if (!passwordVerify)
                {
                    return Unauthorized(new
                    {
                        message = "Invalid email or password."
                    });
                }

                // 4. Actual role database se retrieve karo
                var role = await _context.Roles
                    .FirstOrDefaultAsync(r => r.RoleId == user.RoleId);

                if (role == null)
                {
                    return Forbid();
                }

                string actualRole = role.RoleName;

                // 5. Browser se bheje gaye role ko compare karo
                if (!string.Equals(
                    obj.RoleName,
                    actualRole,
                    StringComparison.OrdinalIgnoreCase))
                {
                    return StatusCode(403, new
                    {
                        message = "The supplied role does not match your account."
                    });
                }

                // 6. Sirf Admin ko login karne do
                if (!string.Equals(
                    actualRole,
                    "Admin",
                    StringComparison.OrdinalIgnoreCase))
                {
                    return StatusCode(403, new
                    {
                        message = "Access denied. Only Admin can login."
                    });
                }

                // 7. JWT generate karo
                var token = _tokenService.CreateToken(
                    user.UserId,
                    user.Email,
                    actualRole
                );

                // 8. JWT HttpOnly cookie mein store karo
                Response.Cookies.Append(
                    "accessToken",
                    token,
                    new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict,
                        Expires = DateTimeOffset.UtcNow.AddDays(1),
                        Path = "/"
                    }
                );

                // 9. Last login update karo
                user.LastLogin = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                // 10. User DTO banao
                var userDTO = new UserDTO
                {
                    UserId = user.UserId,
                    FullName = user.FullName,
                    Email = user.Email,
                    RoleName = actualRole
                };

                // 11. Login notification
                await _emailService.SendEmailAsync(
                    user.Email,
                    "Login Notification",
                    $"Hello {user.FullName},\n\n" +
                    $"You have successfully logged in at {DateTime.UtcNow} UTC.\n\n" +
                    "If this wasn't you, please contact support."
                );

                // 12. Response return karo
                return Ok(new
                {
                    message = "Login successful.",
                    user = userDTO
                });
            }
            catch (Exception ex)
            {
                // Production mein exception details client ko return na karo.
                return StatusCode(500, new
                {
                    message = "An error occurred while logging in."
                });
            }
        }
    }
}