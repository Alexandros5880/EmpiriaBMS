using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Models.Models;

public class DeliverableType : Entity
{
    [Required]
    public string Name { get; set; }

    public string? Description { get; set; }

    public ICollection<Deliverable> Deliverables { get; set; }
}

