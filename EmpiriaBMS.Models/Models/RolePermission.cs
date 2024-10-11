
namespace EmpiriaBMS.Models.Models;

public class RolePermission : Entity
{
    public long RoleId { get; set; }
    public Role? Role { get; set; }

    public long PermissionId { get; set; }
    public Permission? Permission { get; set; }
}
