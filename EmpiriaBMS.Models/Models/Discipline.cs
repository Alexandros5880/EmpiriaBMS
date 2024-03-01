using EmpiriaMS.Models.Models;
using EmpiriaMS.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Models;

public class Discipline : Entity
{
    public long EstimatedHours { get; set; }

    public float EstimatedCompleted { get; set; }

    public float Completed { get; set; }

    public int ProjectId { get; set; }
    public Project Project { get; set; }

    [Required]
    public int TypeId { get; set; }
    public DisciplineType Type { get; set; }

    public ICollection<Drawing> Drawings { get; set; }

    public ICollection<Other> Others { get; set; }

    public ICollection<DailyHour> DailyTime { get; set; }

    public ICollection<DisciplineEngineer> DisciplinesEngineers { get; set; }
}
