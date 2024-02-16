using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Enums;
using EmpiriaMS.Models.Models.Base;

namespace EmpiriaMS.Models.Models;
public class Role : Entity
{
    [Required]
    public string? Name { get; set; }

    public Role()
    {
        Name = string.Empty;
    }

    public void SetValues(Role entity)
    {
        Name = entity.Name;
    }
}
