using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Models.Models;

public class Permission : Entity
{
    [Required]
    public string Name { get; set; }

    public int Ord { get; set; }

    public ICollection<RolePermission> RolesPermissions { get; set; }
}
