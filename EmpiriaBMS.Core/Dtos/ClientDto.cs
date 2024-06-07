using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Core.Dtos;

public class ClientDto : UserDto
{
    public string CompanyName { get; set; }

    public int? AddressId { get; set; }
    public Address? Address { get; set; }

    public ICollection<Project> Projects { get; set; }
}
