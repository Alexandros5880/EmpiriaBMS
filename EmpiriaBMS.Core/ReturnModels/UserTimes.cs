using EmpiriaBMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.ReturnModels;

public class UserTimes
{
    public TimeSpan DailyTime { get; set; }
    public TimeSpan PersonalTime { get; set; }
    public TimeSpan TrainingTime { get; set; }
    public TimeSpan CorporateEventTime { get; set; }
}
