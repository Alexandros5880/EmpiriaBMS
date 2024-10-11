using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Models.Models;

public class SupportiveWork : Entity
{
    [Required]
    public long TypeId { get; set; }
    public SupportiveWorkType? Type { get; set; }

    [Required]
    public long DisciplineId { get; set; }
    public Discipline? Discipline { get; set; }

    public ICollection<DailyTime>? DailyTime { get; set; }

    public ICollection<SupportiveWorkEmployee>? SupportiveWorksEmployees { get; set; }
}
