using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Models.Models;

public class OfferType : Entity
{
    [Required]
    public string Name { get; set; }

    public string? Description { get; set; }

    public ICollection<Offer> Offers { get; set; }
}
