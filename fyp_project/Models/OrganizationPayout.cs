using System;
using System.Collections.Generic;

namespace fyp_project.Models;

public partial class OrganizationPayout
{
    public int PayoutId { get; set; }

    public int OrganizationId { get; set; }

    public decimal TotalCollectedAmount { get; set; }

    public decimal PlatformCommission { get; set; }

    public decimal PayoutAmount { get; set; }

    public string Status { get; set; } = null!;

    public DateOnly? PayoutDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Organization Organization { get; set; } = null!;
}
