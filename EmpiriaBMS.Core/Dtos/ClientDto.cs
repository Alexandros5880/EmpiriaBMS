using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Dtos;

public class ClientDto : UserDto
{
    public string CompanyName { get; set; }

    public int? AddressId { get; set; }
    public Address? Address { get; set; }

    public ICollection<Project> Projects { get; set; }
}
