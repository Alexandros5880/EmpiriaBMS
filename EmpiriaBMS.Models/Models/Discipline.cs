﻿using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Models.Models;

public class Discipline : Entity
{
    public long EstimatedMandays { get; set; }

    public long EstimatedHours { get; set; }

    [Required]
    public long ProjectId { get; set; }
    public Project? Project { get; set; }

    [Required]
    public long TypeId { get; set; }
    public DisciplineType? Type { get; set; }

    public ICollection<Deliverable>? Deliverables { get; set; }

    public ICollection<SupportiveWork>? SupportiveWorks { get; set; }

    public ICollection<DailyTime>? DailyTime { get; set; }

    public ICollection<DisciplineEngineer>? DisciplinesEngineers { get; set; }
}
