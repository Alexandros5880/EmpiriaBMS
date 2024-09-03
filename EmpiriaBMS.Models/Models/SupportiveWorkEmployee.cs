
namespace EmpiriaBMS.Models.Models;

public class SupportiveWorkEmployee : Entity
{
    public int SupportiveWorkId { get; set; }
    public SupportiveWork? SupportiveWork { get; set; }

    public int EmployeeId { get; set; }
    public User? Employee { get; set; }
}
