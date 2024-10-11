
namespace EmpiriaBMS.Models.Models;

public class SupportiveWorkEmployee : Entity
{
    public long SupportiveWorkId { get; set; }
    public SupportiveWork? SupportiveWork { get; set; }

    public long EmployeeId { get; set; }
    public User? Employee { get; set; }
}
