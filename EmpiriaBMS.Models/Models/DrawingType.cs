using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Models.Models;

public class DrawingType : Entity
{
    [Required]
    public string Name { get; set; }

    public ICollection<Drawing> Drawings { get; set; }
}

