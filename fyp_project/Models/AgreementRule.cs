using System;
using System.Collections.Generic;

namespace fyp_project.Models;

public partial class AgreementRule
{
    public int RuleId { get; set; }

    public int OrganizationId { get; set; }

    public string RuleType { get; set; } = null!;

    public string? RuleValue { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Organization Organization { get; set; } = null!;
}
