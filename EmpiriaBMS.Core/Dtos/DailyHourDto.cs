using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpiriaBMS.Models.Enum;

namespace EmpiriaBMS.Core.Dtos;

public class DailyHourDto : EntityDto
{
    public DateTime Date { get; set; }

    public DailyTimeType Type { get; set; }

    public bool IsEditByAdmin { get; set; }

    public int? DailyUserId { get; set; }
    public User? DailyUser { get; set; }

    public int? PersonalUserId { get; set; }
    public User? PersonalUser { get; set; }

    public int? TrainingUserId { get; set; }
    public User? TrainingUser { get; set; }

    public int? CorporateUserId { get; set; }
    public User? CorporateUser { get; set; }

    public int? DeliverableId { get; set; }
    public Deliverable? Deliverable { get; set; }

    public int? SupportiveWorkId { get; set; }
    public SupportiveWork? SupportiveWork { get; set; }

    public int? DisciplineId { get; set; }
    public Discipline? Discipline { get; set; }

    public int? ProjectId { get; set; }
    public Project? Project { get; set; }

    public int? ClientId { get; set; }
    public Client? Client { get; set; }

    public int? OfferId { get; set; }
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
            Type = Type,
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
