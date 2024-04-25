using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Core.Dtos;

public class ProjectStageDto : EntityDto
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public List<Project> Projects { get; set; }
}
