using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpiriaMS.Models.Models.Base;

namespace EmpiriaMS.Models.Models;
public class Role : Entity
{
    [Required]
    public string? Name { get; set; }

    public IEnumerable<Employee>? Employees { get; set; }

}
