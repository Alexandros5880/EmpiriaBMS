using EmpiriaMS.Models.Models;
using EmpiriaMS.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Models;
public class ProjectEmployee : Entity
{
    [Required]
    [ForeignKey("Project")]
    public string ProjectId { get; set; }
    public Project Project { get; set; }

    [Required]
    [ForeignKey("User")]
    public string EmployeeId { get; set; }
    public User Employee { get; set; }
}
