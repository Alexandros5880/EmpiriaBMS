using EmpiriaMS.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Models;

public class Timespan : Entity
{
    public long Days { get; set; }

    public long Hours { get; set; }

    public long Minutes { get; set; }

    public long Seconds { get; set; }

    public Timespan()
    {
          
    }

    public Timespan(long days, long hours, long minutes, long seconds)
    {
        Days = days;
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
    }
}
