
namespace EmpiriaBMS.Models.Models;

public class DeliverableEmployee : Entity
{
    public int DeliverableId { get; set; }
    public Deliverable Deliverable { get; set; }

    public int EmployeeId { get; set; }
    public User Employee { get; set; }
}
