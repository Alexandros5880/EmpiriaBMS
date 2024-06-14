using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Models.Models;

public class SupportiveWorkType : Entity
{
    [Required]
    public string Name { get; set; }

    public string? Description { get; set; }

    public ICollection<SupportiveWork> SupportiveWorks { get; set; }
}
