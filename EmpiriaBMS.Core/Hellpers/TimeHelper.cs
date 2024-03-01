using EmpiriaBMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Hellpers;

public static class TimeHelper
{
    public static TimeSpan CalculateTotalTime(ICollection<DailyTime> dailyTimes)
    {
        TimeSpan totalTime = TimeSpan.Zero;

        foreach (var dailyTime in dailyTimes)
        {
            totalTime = totalTime.Add(
                new TimeSpan(
                    (int)dailyTime.TimeSpan.Days,
                    (int)dailyTime.TimeSpan.Hours,
                    (int)dailyTime.TimeSpan.Minutes,
                    (int)dailyTime.TimeSpan.Seconds)
            );
        }

        return totalTime;
    }
}
