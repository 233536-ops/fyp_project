using System;
using System.Collections.Generic;

namespace fyp_project.Models;

public partial class OrganizationCustomer
{
    public int CustomerId { get; set; }

    public int OrganizationId { get; set; }

    public string FullName { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string CustomerType { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<CustomerPayment> CustomerPayments { get; set; } = new List<CustomerPayment>();

    public virtual Organization Organization { get; set; } = null!;
}
