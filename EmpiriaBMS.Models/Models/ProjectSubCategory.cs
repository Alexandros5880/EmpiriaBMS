
namespace EmpiriaBMS.Models.Models;

public class ProjectSubCategory : Entity
{
    public string? Name { get; set; }

    public bool CanAssignePM { get; set; }

    public string? Description { get; set; }

    public int? CategoryId { get; set; }
    public ProjectCategory Category { get; set; }

    public ICollection<Offer> Offers { get; set; }
}
