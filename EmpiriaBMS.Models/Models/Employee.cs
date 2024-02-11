using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpiriaMS.Models.Models.Base;

namespace EmpiriaMS.Models.Models;
public class Employee : User
{
    public double? Hours { get; set; }

    public IEnumerable<Project>? Projects { get; set; }

    [Required]
    public IEnumerable<Role>? Roles { get; set; }
}
