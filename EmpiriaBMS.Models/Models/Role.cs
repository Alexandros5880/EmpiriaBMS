﻿using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Models.Models;
public class Role : Entity
{
    [Required]
    public string? Name { get; set; }

    [Required]
    public bool IsEmployee { get; set; }

    [Required]
    public bool IsEditable { get; set; }

    // Parent Roles
    public long? ParentRoleId { get; set; }
    public Role? ParentRole { get; set; }

    // Child Roles
    public ICollection<Role>? ChildRoles { get; set; }

    public ICollection<UserRole>? UserRoles { get; set; }

    public ICollection<RolePermission>? RolesPermissions { get; set; }

    public ICollection<Issue>? Issues { get; set; }
}
