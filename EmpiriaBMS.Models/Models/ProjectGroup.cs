using EmpiriaMS.Models.Models;
using EmpiriaMS.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Models;

public class ProjectGroup : Entity
{
    public string? Name { get; set; }

    public ICollection<Project> Projects { get; set; }
}
