using System;
using System.Collections.Generic;

namespace fyp_project.Models;

public partial class BusinessOwner
{
    public int OwnerId { get; set; }

    public int UserId { get; set; }

    public decimal? OwnershipPercentage { get; set; }

    public string? Designation { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
