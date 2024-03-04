using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Dtos;

public class ProjectTypeDto : EntityDto
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public List<Project> Projects { get; set; }
}
