using EmpiriaMS.Models.Models;
using EmpiriaMS.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Models;

public class ProjectType : Entity
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool CanAssignePM { get; set; }

    public List<Project> Projects { get; set; }
}
