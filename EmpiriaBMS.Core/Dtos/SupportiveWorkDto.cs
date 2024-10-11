using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Core.Dtos;

public class SupportiveWorkDto : EntityDto
{
    public long TypeId { get; set; }
    public SupportiveWorkType Type { get; set; }

    public long MenHours { get; set; }

    public float CompletionEstimation { get; set; }

    public long DisciplineId { get; set; }
    public Discipline Discipline { get; set; }
}
