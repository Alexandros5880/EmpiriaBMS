using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using EmpiriaMS.Models.Models;
using EmpiriaMS.Models.Models.Base;

namespace EmpiriaBMS.Models.Models;
public class User : Entity
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string FirstName { get; set; }

    public string? MidName { get; set; }

    [Required]
    public string Phone1 { get; set; }

    public string? Phone2 { get; set; }

    public string? Phone3 { get; set; }

    public string? Description { get; set; }

    public double? Hours { get; set; }

    public int? ProjectId { get; set; }
    public Project? Project { get; set; }

    public ICollection<Discipline> Disciplines { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }
    
    public ICollection<DisciplineEmployee> DisciplineEmployees { get; set; }
}