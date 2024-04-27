using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Core.Dtos;

public class ProjectCategoryDto : EntityDto
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool CanAssignePM { get; set; }

    public List<ProjectSubCategory> SubCategories { get; set; }
}
