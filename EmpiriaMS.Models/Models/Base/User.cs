using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaMS.Models.Models.Base;
public class User : Entity
{
    [Required]
    public string? Email { get; set; }

    [Required]
    public string? LastName { get; set; }

    [Required]
    public string? FirstName { get; set; }

    public string? MidName { get; set; }

    [Required]
    public string? Phone1 { get; set; }

    public string? Phone2 { get; set; }
    
    public string? Phone3 { get; set; }

    public string? Description { get; set; }
}