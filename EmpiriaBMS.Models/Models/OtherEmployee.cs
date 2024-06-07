
namespace EmpiriaBMS.Models.Models;

public class OtherEmployee : Entity
{
    public int OtherId { get; set; }
    public Other Other { get; set; }

    public int EmployeeId { get; set; }
    public User Employee { get; set; }
}
