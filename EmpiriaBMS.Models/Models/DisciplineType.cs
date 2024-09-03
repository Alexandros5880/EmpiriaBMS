using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Models.Models;

public class DisciplineType : Entity
{
    [Required]
    public string? Name { get; set; }

    public string? Description { get; set; }

    public ICollection<Discipline>? Disciplines { get; set; }
}
