
namespace EmpiriaBMS.Models.Models;

public class SubConstructor : Entity
{
    public string Name { get; set; }

    public int? UserId { get; set; }
    public User? User { get; set; }

    public ICollection<ProjectSubConstractor>? ProjectsSubConstructors { get; set; }
}
