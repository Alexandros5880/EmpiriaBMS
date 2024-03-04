using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Dtos;

public class PermissionDto : EntityDto
{
    public string Name { get; set; }

    public int Ord { get; set; }

    public ICollection<RolePermission> RolesPermissions { get; set; }
}
