
namespace EmpiriaBMS.Models.Models;

public class ProjectStage : Entity
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public List<Project> Projects { get; set; }
}
