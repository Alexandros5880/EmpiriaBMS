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
    public string FullName => $"{LastName} {MidName} {FirstName}";
    
    public ICollection<Led> Leds { get; set; }
}
