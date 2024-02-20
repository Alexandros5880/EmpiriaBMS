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

    public int? Completed { get; set; }

    public int? ProjectManagerId { get; set; }
    public User? ProjectManager { get; set; }

    public ICollection<Draw> Draws { get; set; }

    public ICollection<Doc> Docs { get; set; }

    public ICollection<DisciplineEmployee> DisciplineEmployees { get; set; }
}
