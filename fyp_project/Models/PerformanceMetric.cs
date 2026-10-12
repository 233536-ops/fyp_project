using System;
using System.Collections.Generic;

namespace fyp_project.Models;

public partial class PerformanceMetric
{
    public int MetricId { get; set; }

    public int EmployeeId { get; set; }

    public int OrganizationId { get; set; }

    public int TasksCompleted { get; set; }

    public decimal? AvgRating { get; set; }

    public decimal? AttendanceRate { get; set; }

    public decimal? EfficiencyScore { get; set; }

    public DateTime CalculatedAt { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Organization Organization { get; set; } = null!;
}
