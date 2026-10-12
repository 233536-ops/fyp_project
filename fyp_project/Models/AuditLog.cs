using System;
using System.Collections.Generic;

namespace fyp_project.Models;

public partial class AuditLog
{
    public int LogId { get; set; }

    public int UserId { get; set; }

    public string Action { get; set; } = null!;

    public string EntityType { get; set; } = null!;

    public int? EntityId { get; set; }

    public DateTime Timestamp { get; set; }

    public string? IpAddress { get; set; }

    public virtual User User { get; set; } = null!;
}
