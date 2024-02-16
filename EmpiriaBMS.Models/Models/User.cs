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

    public User()
    {
        Email = string.Empty;
        LastName = string.Empty;
        FirstName = string.Empty;
        MidName = string.Empty;
        Phone1 = string.Empty;
        Phone2 = string.Empty;
        Phone3 = string.Empty;
        Description = string.Empty;
        Hours = 0;
    }

    public void SetValues(User entity)
    {
        Email = entity.Email;
        LastName = entity.LastName;
        FirstName = entity.FirstName;
        MidName = entity.MidName;
        Phone1 = entity.Phone1;
        Phone2 = entity.Phone2;
        Phone3 = entity.Phone3;
        Description = entity.Description;
        Hours = entity.Hours;
        ProjectId = entity.ProjectId;
        Project = entity.Project;
    }
}