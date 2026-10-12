using System;
using System.Collections.Generic;

namespace fyp_project.Models;

public partial class Attendance
{
    public int AttendanceId { get; set; }

    public int EmployeeId { get; set; }

    public int OrganizationId { get; set; }

    public DateTime? CheckIn { get; set; }

    public DateTime? CheckOut { get; set; }

    public decimal? WorkingHours { get; set; }

    public string Status { get; set; } = null!;

    public DateOnly Date { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Organization Organization { get; set; } = null!;
}
