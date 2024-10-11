
namespace EmpiriaBMS.Models.Models;

public class DeliverableEmployee : Entity
{
    public long DeliverableId { get; set; }
    public Deliverable? Deliverable { get; set; }

    public long EmployeeId { get; set; }
    public User? Employee { get; set; }
}
