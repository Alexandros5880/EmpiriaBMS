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

    public DailyTimeTypes Type { get; set; }

    public DailyTimeState State { get; set; }

    public bool IsEditByAdmin { get; set; }

    public long? UserId { get; set; }
    public User? User { get; set; }

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
            Type = Type,
            State = State,
            Days = Days,
            Hours = Hours,
            Minutes = Minutes,
            Seconds = Seconds,
            Description = Description,
            IsEditByAdmin = IsEditByAdmin,
            UserId = UserId,
            User = User,
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
