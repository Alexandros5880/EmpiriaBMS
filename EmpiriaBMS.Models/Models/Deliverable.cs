using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpiriaBMS.Models.Models;

public class Deliverable : Entity
{
    [Required]
    public int TypeId { get; set; }
    public DeliverableType Type { get; set; }

    [Required]
    public int DisciplineId { get; set; }
    public Discipline Discipline { get; set; }

    public float CompletionEstimation { get; set; }

    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime? CompletionDate { get; set; }

    public ICollection<DailyTime> DailyTime { get; set; }

    public ICollection<DeliverableEmployee> DeliverablesEmployees { get; set; }
}