using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Core.Dtos;

public class SupportiveWorkTypeDto : EntityDto
{
    public string Name { get; set; }

    public string? Description { get; set; }
    public ICollection<SupportiveWork> SupportiveWorks { get; set; }
}
