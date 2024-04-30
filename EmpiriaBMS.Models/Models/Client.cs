using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Models.Models;

public class Client : User
{
    [Required]
    public string CompanyName { get; set; }

    public int? AddressId { get; set; }
    public Address? Address { get; set; }

    public ICollection<Project> Projects { get; set; }
}
