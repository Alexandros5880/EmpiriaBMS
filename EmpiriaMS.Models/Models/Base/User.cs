using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaMS.Models.Models.Base;
public class User : Entity
{
    public string? Email { get; set; }

    public required string LastName { get; set; }

    public required string FirstName { get; set; }

    public string? MidName { get; set; }

    public required string Phone1 { get; set; }

    public string? Phone2 { get; set; }
    
    public string? Phone3 { get; set; }

    public string? Description { get; set; }
}