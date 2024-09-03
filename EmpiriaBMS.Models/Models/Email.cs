
using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Models.Models;

public class Email : Entity
{
    [Required]
    public string? Address { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }
}
