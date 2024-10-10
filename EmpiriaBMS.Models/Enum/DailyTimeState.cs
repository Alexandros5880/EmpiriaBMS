using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Enum;

public enum DailyTimeState
{
    [Display(Name = "APPROVED")]
    APPROVED = 0,
    [Display(Name = "AWAITING")]
    AWAITING = 1,
    [Display(Name = "NOREQUEST")]
    NOREQUEST = 2
}
