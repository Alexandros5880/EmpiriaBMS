using EmpiriaBMS.Models.Enum;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;

namespace EmpiriaBMS.Front.Components.WorkingHours;

public partial class DailyTimeRequestCard
{
    [Parameter]
    public DailyTimeRequest Request { get; set; }

    [Parameter]
    public DailyTimeTypes Type { get; set; }

    [Parameter]
    public EventCallback<DailyTimeRequest> OnEnd { get; set; }

    private string FormatTimeSpan(Timespan timeSpan)
    {
        return $"{timeSpan.Days} days, {timeSpan.Hours} hours, {timeSpan.Minutes} minutes, {timeSpan.Seconds} seconds";
    }

    private async Task _approve()
    {
        await _dataProvider.WorkingTime.ApproveDailyTimeRequest(Request, Type);

        await OnEnd.InvokeAsync(Request);
    }

    private async Task _reject()
    {
        await _dataProvider.WorkingTime.RejectDailyTimeRequest(Request);

        await OnEnd.InvokeAsync(Request);
    }
}
