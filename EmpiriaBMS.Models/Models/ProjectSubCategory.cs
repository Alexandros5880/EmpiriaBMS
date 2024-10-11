
namespace EmpiriaBMS.Models.Models;

public class ProjectSubCategory : Entity
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public long? CategoryId { get; set; }
    public ProjectCategory? Category { get; set; }

    public ICollection<Offer>? Offers { get; set; }
}
