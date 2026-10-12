using System;
using System.Collections.Generic;

namespace fyp_project.Models;

public partial class CustomerPayment
{
    public int PaymentId { get; set; }

    public int CustomerId { get; set; }

    public int OrganizationId { get; set; }

    public decimal Amount { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string? TransactionReference { get; set; }

    public string Status { get; set; } = null!;

    public int ServiceSessionId { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual OrganizationCustomer Customer { get; set; } = null!;

    public virtual Organization Organization { get; set; } = null!;

    public virtual ServiceSession ServiceSession { get; set; } = null!;
}
