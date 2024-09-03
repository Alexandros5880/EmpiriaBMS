using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpiriaBMS.Models.Models;

public class Client : User
{
    [Required]
    public string CompanyName { get; set; }

    public int? AddressId { get; set; }
    public Address? Address { get; set; }

    public ICollection<Project> Projects { get; set; }

    [NotMapped]
    public new string FullName => $"{LastName} {MidName} {FirstName}";
    
    public ICollection<Lead>? Leds { get; set; }
}
