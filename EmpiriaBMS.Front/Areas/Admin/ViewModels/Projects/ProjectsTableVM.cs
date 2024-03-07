using EmpiriaBMS.Core.Dtos;

namespace EmpiriaBMS.Front.Areas.Admin.ViewModels.Projects;

public class ProjectsTableVM
{
    public ICollection<ProjectDto> Projects { get; set; }
}
