using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Models.Models;

public class Other : Entity
{
    [Required]
    public int TypeId { get; set; }
    public OtherType Type { get; set; }

    [Required]
    public int DisciplineId { get; set; }
    public Discipline Discipline { get; set; }

    public float CompletionEstimation { get; set; }

    public ICollection<DailyTime> DailyTime { get; set; }

    public ICollection<OtherEmployee> OthersEmployees { get; set; }
}
