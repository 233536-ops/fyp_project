using System;
using System.Collections.Generic;

namespace fyp_project.Models;

public partial class ResourceRequest
{
    public int RequestId { get; set; }

    public int OrganizationId { get; set; }

    public string PersonaType { get; set; } = null!;

    public int RequiredCount { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<EmployeeAllocation> EmployeeAllocations { get; set; } = new List<EmployeeAllocation>();

    public virtual Organization Organization { get; set; } = null!;
}
