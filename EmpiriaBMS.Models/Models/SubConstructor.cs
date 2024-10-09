using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Models.Models;

public class SubConstructor : Entity
{
    [Required]
    public string Name { get; set; }

    public string? Description { get; set; }

    public string? Phone { get; set; }

    public ICollection<Email>? Emails { get; set; }

    public ICollection<User>? Users { get; set; }

    public ICollection<ProjectSubConstractor>? ProjectsSubConstructors { get; set; }
}
