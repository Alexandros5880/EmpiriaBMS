
using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Models.Models;

public class Email : Entity
{
    [Required]
    public string? Address { get; set; }

    public int? UserId { get; set; }
    public User? User { get; set; }

    public int? ClientId { get; set; }
    public Client? Client { get; set; }

    public int? SubConstructorId { get; set; }
    public SubConstructor? SubConstructor { get; set; }
}
