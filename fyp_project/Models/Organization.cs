using System;
using System.Collections.Generic;

namespace fyp_project.Models;

public partial class Organization
{
    public int OrganizationId { get; set; }

    public string OrgName { get; set; } = null!;

    public string OrgType { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string Status { get; set; } = null!;

    public DateOnly? ContractStartDate { get; set; }

    public DateOnly? ContractEndDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<AgreementRule> AgreementRules { get; set; } = new List<AgreementRule>();

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual ICollection<CustomerPayment> CustomerPayments { get; set; } = new List<CustomerPayment>();

    public virtual ICollection<EmployeeAllocation> EmployeeAllocationFromOrgs { get; set; } = new List<EmployeeAllocation>();

    public virtual ICollection<EmployeeAllocation> EmployeeAllocationToOrgs { get; set; } = new List<EmployeeAllocation>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<ForecastingDatum> ForecastingData { get; set; } = new List<ForecastingDatum>();

    public virtual ICollection<OrganizationContract> OrganizationContracts { get; set; } = new List<OrganizationContract>();

    public virtual ICollection<OrganizationCustomer> OrganizationCustomers { get; set; } = new List<OrganizationCustomer>();

    public virtual ICollection<OrganizationInvoice> OrganizationInvoices { get; set; } = new List<OrganizationInvoice>();

    public virtual ICollection<OrganizationManager> OrganizationManagers { get; set; } = new List<OrganizationManager>();

    public virtual ICollection<OrganizationPayout> OrganizationPayouts { get; set; } = new List<OrganizationPayout>();

    public virtual ICollection<OrganizationServiceUsage> OrganizationServiceUsages { get; set; } = new List<OrganizationServiceUsage>();

    public virtual ICollection<PerformanceMetric> PerformanceMetrics { get; set; } = new List<PerformanceMetric>();

    public virtual ICollection<ResourceRequest> ResourceRequests { get; set; } = new List<ResourceRequest>();

    public virtual ICollection<ServiceSession> ServiceSessions { get; set; } = new List<ServiceSession>();

    public virtual ICollection<Shift> Shifts { get; set; } = new List<Shift>();
}
