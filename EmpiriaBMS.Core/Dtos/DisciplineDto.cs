using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Dtos;

public class DisciplineDto : EntityDto
{
    public string Name { get; set; }

    public int ProjectId { get; set; }
    public Project Project { get; set; }

    public int? ProjectManagerId { get; set; }
    public User? ProjectManager { get; set; }

    public ICollection<Draw> Draws { get; set; }

    public ICollection<Doc> Docs { get; set; }

    public ICollection<User> Engineers { get; set; }

    public ICollection<DisciplineEngineer> DisciplineEngineers { get; set; }
}
