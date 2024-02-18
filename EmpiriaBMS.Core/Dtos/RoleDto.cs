using EmpiriaBMS.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Dtos;

public class RoleDto : EntityDto
{
    public string? Name { get; set; }

    public bool IsEmployee { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }
}
