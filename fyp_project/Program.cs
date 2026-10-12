using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System.Text;
using fyp_project.Models;
using fyp_project.Services;

var builder = WebApplication.CreateBuilder(args);

// =====================================================
// EMAIL SETTINGS
// =====================================================

builder.Services.Configure<EmailSettings>(
    builder.Configuration.GetSection("EmailSettings")
);


// =====================================================
// REDIS
// =====================================================

var redisOptions = new ConfigurationOptions
{
    User = builder.Configuration["Redis:User"],
    Password = builder.Configuration["Redis:Password"],

    // Debug ke liye true rakho
    // Agar connection fail hua to app startup par actual error milega
    AbortOnConnectFail = true,

    ConnectTimeout = 10000,
    SyncTimeout = 10000
};

redisOptions.EndPoints.Add(
    "soda-recess-diaphanous-40743.db.redis.io",
    16619
);

var redis = ConnectionMultiplexer.Connect(redisOptions);

builder.Services.AddSingleton<IConnectionMultiplexer>(redis);

builder.Services.AddSingleton<RedisService>();
// =====================================================
// APPLICATION SERVICES
// =====================================================

builder.Services.AddScoped<EmailService>();

builder.Services.AddScoped<TokenService>();


// =====================================================
// CONTROLLERS
// =====================================================

builder.Services.AddControllers();


// =====================================================
// OPEN API
// =====================================================

builder.Services.AddOpenApi();


// =====================================================
// DATABASE
// =====================================================

builder.Services.AddDbContext<WorkforceManagementDbContext>(
    options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString(
                "DefaultConnection"
            )
        )
);


// =====================================================
// JWT AUTHENTICATION
// =====================================================

builder.Services
    .AddAuthentication(
        JwtBearerDefaults.AuthenticationScheme
    )
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                // -----------------------------------------
                // ISSUER
                // -----------------------------------------

                ValidateIssuer = true,

                ValidIssuer =
                    builder.Configuration["Jwt:Issuer"],


                // -----------------------------------------
                // AUDIENCE
                // -----------------------------------------

                ValidateAudience = true,

                ValidAudience =
                    builder.Configuration["Jwt:Audience"],


                // -----------------------------------------
                // TOKEN EXPIRATION
                // -----------------------------------------

                ValidateLifetime = true,


                // -----------------------------------------
                // SIGNING KEY
                // -----------------------------------------

                ValidateIssuerSigningKey = true,

                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            builder.Configuration["Jwt:Key"]!
                        )
                    )
            };


        // =================================================
        // GET JWT FROM HTTPONLY COOKIE
        // =================================================

        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var token =
                    context.Request.Cookies["accessToken"];

                if (!string.IsNullOrEmpty(token))
                {
                    context.Token = token;
                }

                return Task.CompletedTask;
            }
        };
    });


// =====================================================
// AUTHORIZATION
// =====================================================

builder.Services.AddAuthorization();


// =====================================================
// BUILD APPLICATION
// =====================================================

var app = builder.Build();


// =====================================================
// DEVELOPMENT
// =====================================================

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


// =====================================================
// HTTPS REDIRECTION
// =====================================================

app.UseHttpsRedirection();


// =====================================================
// AUTHENTICATION
// =====================================================

app.UseAuthentication();


// =====================================================
// AUTHORIZATION
// =====================================================

app.UseAuthorization();


// =====================================================
// CONTROLLERS
// =====================================================

app.MapControllers();


// =====================================================
// RUN
// =====================================================

app.Run();