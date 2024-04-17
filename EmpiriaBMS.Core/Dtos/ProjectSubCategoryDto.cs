using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Dtos;

public class ProjectSubCategoryDto : EntityDto
{
    public string? Name { get; set; }

    public bool CanAssignePM { get; set; }
    public int? CategoryId { get; set; }
    public ProjectCategory Category { get; set; }

    public ICollection<Project> Projects { get; set; }
}
