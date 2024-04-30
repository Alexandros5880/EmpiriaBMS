
namespace EmpiriaBMS.Models.Models;

public class DrawingEmployee : Entity
{
    public int DrawingId { get; set; }
    public Drawing Drawing { get; set; }

    public int EmployeeId { get; set; }
    public User Employee { get; set; }
}
