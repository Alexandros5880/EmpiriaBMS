using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models.Base;

namespace EmpiriaMS.Models.Models;
public class Role : Entity
{
    [Required]
    public string? Name { get; set; }

    [Required]
    public bool IsEmployee { get; set; }

    [Required]
    public bool IsEditable { get; set; }

    // Parent Roles
    public int? ParentRoleId { get; set; }
    public Role? ParentRole { get; set; }

    // Child Roles
    public ICollection<Role> ChildRoles { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }

    public ICollection<RolePermission> RolesPermissions { get; set; }

    public ICollection<Issue> Issues { get; set; }
}
