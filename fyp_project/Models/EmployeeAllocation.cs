using System;
using System.Collections.Generic;

namespace fyp_project.Models;

public partial class EmployeeAllocation
{
    public int AllocationId { get; set; }

    public int EmployeeId { get; set; }

    public int RequestId { get; set; }

    public int FromOrgId { get; set; }

    public int ToOrgId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public decimal HourlyWage { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Organization FromOrg { get; set; } = null!;

    public virtual ResourceRequest Request { get; set; } = null!;

    public virtual Organization ToOrg { get; set; } = null!;
}
