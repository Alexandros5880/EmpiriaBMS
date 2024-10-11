
namespace EmpiriaBMS.Models.Models;

public class DisciplineEngineer : Entity
{
    public long DisciplineId { get; set; }
    public Discipline? Discipline { get; set; }

    public long EngineerId { get; set; }
    public User? Engineer { get; set; }
}
