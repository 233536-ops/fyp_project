using System;
using System.Collections.Generic;

namespace fyp_project.Models;

public partial class OrganizationInvoice
{
    public int InvoiceId { get; set; }

    public int OrganizationId { get; set; }

    public decimal TotalHours { get; set; }

    public decimal TotalAmount { get; set; }

    public DateOnly BillingMonth { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual Organization Organization { get; set; } = null!;
}
