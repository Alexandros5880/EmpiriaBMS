using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Core.Dtos;

public class DisciplineDto : EntityDto
{
    public long EstimatedMandays { get; set; }

    public long EstimatedHours { get; set; }

    public int TypeId { get; set; }
    public DisciplineType Type { get; set; }

    public int ProjectId { get; set; }
    public Project Project { get; set; }

    public float EstimatedCompleted { get; set; }

    public float DeclaredCompleted { get; set; }
}
