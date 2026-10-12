using System;
using System.Collections.Generic;

namespace fyp_project.Models;

public partial class OrganizationContract
{
    public int ContractId { get; set; }

    public int OrganizationId { get; set; }

    public decimal BillingRatePerHour { get; set; }

    public string? AgreedPersonaTypes { get; set; }

    public int? MaxSharedEmployees { get; set; }

    public int? MinFixedEmployees { get; set; }

    public string? ServiceClauses { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual Organization Organization { get; set; } = null!;
}
