using EmpiriaMS.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Models;

public class DailyHour : Entity
{
    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime Date { get; set; }

    public Timespan TimeSpan { get; set; }

    public int? DailyUserId { get; set; }
    public User DailyUser { get; set; }

    public int? PersonalUserId { get; set; }
    public User PersonalUser { get; set; }

    public int? TrainingUserId { get; set; }
    public User TrainingUser { get; set; }

    public int? CorporateUserId { get; set; }
    public User CorporateUser { get; set; }
}
