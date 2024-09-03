
using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Models.Models;

public class ProjectCategory : Entity
{
    [Required]
    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool CanAssignePM { get; set; }

    public ICollection<ProjectSubCategory>? SubCategories { get; set; }

    public ICollection<Offer>? Offers { get; set; }
}
