using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpiriaMS.Models.Models.Base;

namespace EmpiriaMS.Models.Models;
public class Employee : User
{
    public IEnumerable<float>? Hours { get; set; }

    public IEnumerable<Project>? Projects { get; set; }

    public required IEnumerable<Role> Roles { get; set; }
}
