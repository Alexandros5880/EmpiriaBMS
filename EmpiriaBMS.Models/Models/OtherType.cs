using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Models.Models;

public class OtherType : Entity
{
    [Required]
    public string Name { get; set; }

    public ICollection<Other> Others { get; set; }
}
