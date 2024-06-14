using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Core.Dtos;

public class DeliverableTypeDto : EntityDto
{
    public string Name { get; set; }

    public string? Description { get; set; }

    public ICollection<Deliverable> Deliverables { get; set; }
}
