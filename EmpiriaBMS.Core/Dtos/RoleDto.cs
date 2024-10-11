using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Core.Dtos;

public class RoleDto : EntityDto
{
    public string? Name { get; set; }

    public bool IsEmployee { get; set; }

    public bool IsEditable { get; set; }

    // Parent Roles
    public long? ParentRoleId { get; set; }
    public Role? ParentRole { get; set; }

    // Child Roles
    public ICollection<Role> ChildRoles { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }

    public ICollection<RolePermission> RolesPermissions { get; set; }

    public ICollection<Issue> Issues { get; set; }
}
