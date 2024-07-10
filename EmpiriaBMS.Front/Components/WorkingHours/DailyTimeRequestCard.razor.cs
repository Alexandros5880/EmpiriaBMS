using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;

namespace EmpiriaBMS.Front.Components.WorkingHours;

public partial class DailyTimeRequestCard
{
    [Parameter]
    public DailyTimeRequest Request { get; set; }

    private string FormatTimeSpan(Timespan timeSpan)
    {
        return $"{timeSpan.Days} days, {timeSpan.Hours} hours, {timeSpan.Minutes} minutes, {timeSpan.Seconds} seconds";
    }
}
