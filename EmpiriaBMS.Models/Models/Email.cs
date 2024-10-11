
using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Models.Models;

public class Email : Entity
{
    [Required]
    public string? Address { get; set; }

    public long? UserId { get; set; }
    public User? User { get; set; }

    public long? ClientId { get; set; }
    public Client? Client { get; set; }

    public long? SubConstructorId { get; set; }
    public SubConstructor? SubConstructor { get; set; }
}
