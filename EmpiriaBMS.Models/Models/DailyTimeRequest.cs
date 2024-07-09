using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpiriaBMS.Models.Models;

public class DailyTimeRequest : Entity
{
    public bool IsClosed { get; set; }

    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime Date { get; set; }

    public Timespan TimeSpan { get; set; }

    public bool IsEditByAdmin { get; set; }

    public int? DailyUserId { get; set; }
    public User? DailyUser { get; set; }

    public int? PersonalUserId { get; set; }
    public User? PersonalUser { get; set; }

    public int? TrainingUserId { get; set; }
    public User? TrainingUser { get; set; }

    public int? CorporateUserId { get; set; }
    public User? CorporateUser { get; set; }

    public int? DrawingId { get; set; }
    public Deliverable? Drawing { get; set; }

    public int? OtherId { get; set; }
    public SupportiveWork? Other { get; set; }

    public int? DisciplineId { get; set; }
    public Discipline? Discipline { get; set; }

    public int? ProjectId { get; set; }
    public Project? Project { get; set; }

    public int? LeadId { get; set; }
    public Lead? Lead { get; set; }

    public int? OfferId { get; set; }
    public Offer? Offer { get; set; }
}