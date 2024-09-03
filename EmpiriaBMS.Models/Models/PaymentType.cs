using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Models.Models;

public class PaymentType : Entity
{
    [Required]
    public string? Name { get; set; }

    public string? Description { get; set; }

    public ICollection<Payment>? Payments { get; set; }
}
