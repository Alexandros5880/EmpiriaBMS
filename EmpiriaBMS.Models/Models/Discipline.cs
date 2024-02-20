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

    public int ProjectId { get; set; }
    public Project Project { get; set; }

    public long? EstimatedHours { get; set; }

    public long? EstimatedMenHours { get; set; }

    public int? Completed { get; set; }

    public int? EngineerId { get; set; }
    public User? Engineer { get; set; }

    public ICollection<DisciplineEmployee> DisciplineEmployees { get; set; }

    public ICollection<DisciplineOther> DisciplinesOthers { get; set; }

    public ICollection<DisciplineDraw> DisciplinesDraws { get; set; }
}
