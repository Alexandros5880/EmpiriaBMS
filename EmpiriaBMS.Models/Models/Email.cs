using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models.Base;

namespace EmpiriaBMS.Models.Models;

public class Email : Entity
{
    public string Address { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
}
