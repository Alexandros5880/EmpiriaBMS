using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Models;

public class OfferResult : Entity
{
    [Required]
    public string Name { get; set; }

    public string? Description { get; set; }

    public ICollection<Offer> Offers { get; set; }
}
