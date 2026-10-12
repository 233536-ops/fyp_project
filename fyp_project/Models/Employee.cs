using System;
using System.Collections.Generic;

namespace fyp_project.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public int UserId { get; set; }

    public int CurrentOrganizationId { get; set; }

    public string EmployeeType { get; set; } = null!;

    public string PersonaType { get; set; } = null!;

    public string AvailabilityStatus { get; set; } = null!;

    public decimal HourlyRate { get; set; }

    public bool IsInSharedPool { get; set; }

    public decimal? Rating { get; set; }

    public byte? ProficiencyLevel { get; set; }

    public byte[]? Picture { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual Organization CurrentOrganization { get; set; } = null!;

    public virtual ICollection<EmployeeAllocation> EmployeeAllocations { get; set; } = new List<EmployeeAllocation>();

    public virtual ICollection<OrganizationServiceUsage> OrganizationServiceUsages { get; set; } = new List<OrganizationServiceUsage>();

    public virtual ICollection<PerformanceMetric> PerformanceMetrics { get; set; } = new List<PerformanceMetric>();

    public virtual ICollection<ServiceSession> ServiceSessions { get; set; } = new List<ServiceSession>();

    public virtual User User { get; set; } = null!;
}
