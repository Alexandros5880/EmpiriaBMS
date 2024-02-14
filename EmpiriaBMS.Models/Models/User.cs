using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpiriaMS.Models.Models;
using EmpiriaMS.Models.Models.Base;

namespace EmpiriaBMS.Models.Models;
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

    public double? Hours { get; set; }

    [ForeignKey("Project")]
    public string? ProjectId { get; set; }
    public Project? Project { get; set; }

    public ICollection<Role> Roles { get; set; }
    public ICollection<User> Employees { get; set; }
    public ICollection<Project> Projects { get; set; }
}