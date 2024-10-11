
namespace EmpiriaBMS.Models.Models;
public class UserRole : Entity
{
    public long UserId { get; set; }
    public User? User { get; set; }

    public long RoleId { get; set; }
    public Role? Role { get; set; }
}