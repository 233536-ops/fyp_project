using System;
using System.Collections.Generic;

namespace fyp_project.Models;

public partial class OrganizationManager
{
    public int OrgManagerId { get; set; }

    public int UserId { get; set; }

    public int OrganizationId { get; set; }

    public string? Designation { get; set; }

    public string? ContactNo { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Organization Organization { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
