using System;
using System.Collections.Generic;

namespace fyp_project.Models;

public partial class Shift
{
    public int ShiftId { get; set; }

    public int OrganizationId { get; set; }

    public string ShiftName { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string? RequiredPersonas { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Organization Organization { get; set; } = null!;
}
