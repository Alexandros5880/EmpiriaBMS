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
    [Required]
    public string Name { get; set; }

    public long EstimatedHours { get; set; }

    public float EstimatedCompleted { get; set; }

    public float Completed { get; set; }

    public ICollection<ManHour> MenHours { get; set; }

    public ICollection<DisciplineOther> DisciplinesOthers { get; set; }

    public ICollection<DisciplineDraw> DisciplinesDraws { get; set; }

    public ICollection<DisciplinePoject> DisciplinesProjects { get; set; }

    public ICollection<DisciplineEngineer> DisciplinesEngineers { get; set; }
}
