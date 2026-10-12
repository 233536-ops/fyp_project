using System;
using System.Collections.Generic;

namespace fyp_project.Models;

public partial class ForecastingDatum
{
    public int DataId { get; set; }

    public int OrganizationId { get; set; }

    public DateOnly Date { get; set; }

    public byte Hour { get; set; }

    public int IncomingDemand { get; set; }

    public int RequiredStaff { get; set; }

    public int ActualStaff { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Organization Organization { get; set; } = null!;
}
