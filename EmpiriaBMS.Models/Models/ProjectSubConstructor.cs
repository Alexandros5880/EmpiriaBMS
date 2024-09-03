
namespace EmpiriaBMS.Models.Models;

public class ProjectSubConstructor : Entity
{
    public int ProjectId { get; set; }
    public Project? Project { get; set; }

    public int SubContractorId { get; set; }
    public User? SubContractor { get; set; }
}
