using EmpiriaBMS.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpiriaBMS.Models.Models;

public class DailyTime : Entity
{
    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime Date { get; set; }

    public DailyTimeState State { get; set; }

    public bool IsEditByAdmin { get; set; }

    // TODO: Think
    #region Think
    public long? DailyUserId { get; set; }
    public User? DailyUser { get; set; }

    public long? PersonalUserId { get; set; }
    public User? PersonalUser { get; set; }

    public long? TrainingUserId { get; set; }
    public User? TrainingUser { get; set; }

    public long? CorporateUserId { get; set; }
    public User? CorporateUser { get; set; }
    #endregion

    public long? DeliverableId { get; set; }
    public Deliverable? Deliverable { get; set; }

    public long? SupportiveWorkId { get; set; }
    public SupportiveWork? SupportiveWork { get; set; }

    public long? DisciplineId { get; set; }
    public Discipline? Discipline { get; set; }

    public long? ProjectId { get; set; }
    public Project? Project { get; set; }

    public long? ClientId { get; set; }
    public Client? Client { get; set; }

    public long? OfferId { get; set; }
    public Offer? Offer { get; set; }

    public string? Description { get; set; }

    #region TimeSpan
    public long Days { get; set; }

    public long Hours { get; set; }

    public long Minutes { get; set; }

    public long Seconds { get; set; }
    #endregion

    public DailyTime GetDailyTime()
    {
        return new DailyTime()
        {
            Date = Date,
            State = State,
            Days = Days,
            Hours = Hours,
            Minutes = Minutes,
            Seconds = Seconds,
            Description = Description,
            IsEditByAdmin = IsEditByAdmin,
            DailyUserId = DailyUserId,
            DailyUser = DailyUser,
            PersonalUserId = PersonalUserId,
            PersonalUser = PersonalUser,
            TrainingUserId = TrainingUserId,
            TrainingUser = TrainingUser,
            CorporateUserId = CorporateUserId,
            CorporateUser = CorporateUser,
            DeliverableId = DeliverableId,
            Deliverable = Deliverable,
            SupportiveWorkId = SupportiveWorkId,
            SupportiveWork = SupportiveWork,
            DisciplineId = DisciplineId,
            Discipline = Discipline,
            ProjectId = ProjectId,
            Project = Project,
            ClientId = ClientId,
            Client = Client,
            OfferId = OfferId,
            Offer = Offer
        };
    }

    public TimeSpan ToTimeSpan()
    {
        return new TimeSpan((int)Days, (int)Hours, (int)Minutes, (int)Seconds);
    }
}
