using System;
using System.Collections.Generic;

namespace fyp_project.Models;

public partial class OrganizationServiceUsage
{
    public int UsageId { get; set; }

    public int OrganizationId { get; set; }

    public int EmployeeId { get; set; }

    public decimal HoursWorked { get; set; }

    public decimal RatePerHour { get; set; }

    public decimal TotalAmount { get; set; }

    public DateOnly PeriodStart { get; set; }

    public DateOnly PeriodEnd { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Organization Organization { get; set; } = null!;
}
