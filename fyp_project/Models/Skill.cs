using System;
using System.Collections.Generic;

namespace fyp_project.Models;

public partial class Skill
{
    public int SkillId { get; set; }

    public string SkillName { get; set; } = null!;

    public string? Category { get; set; }

    public string? Description { get; set; }
}
