using System;
using System.Collections.Generic;

namespace fyp_project.Models;

public partial class ServiceSession
{
    public int SessionId { get; set; }

    public int EmployeeId { get; set; }

    public int OrganizationId { get; set; }

    public string PersonaType { get; set; } = null!;

    public string CustomerType { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public decimal? PerformanceRating { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<CustomerPayment> CustomerPayments { get; set; } = new List<CustomerPayment>();

    public virtual Employee Employee { get; set; } = null!;

    public virtual Organization Organization { get; set; } = null!;
}
