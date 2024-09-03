
namespace EmpiriaBMS.Models.Models;

public class DisciplineEngineer : Entity
{
    public int DisciplineId { get; set; }
    public Discipline? Discipline { get; set; }

    public int EngineerId { get; set; }
    public User? Engineer { get; set; }
}
