using EmpiriaBMS.Models.Enum;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EmpiriaBMS.Front.Components.WorkingHours;

public partial class DailyTimeRequestsCorrection
{
    [Parameter]
    public int RequestCount { get; set; }

    [Parameter]
    public EventCallback<DailyTimeRequest> OnChange { get; set; }

    [Parameter]
    public Dictionary<DailyTimeTypes, List<DailyTimeRequest>> DailyRequests { get; set; }

    private string GetDisplayName(DailyTimeTypes dailyTimeType)
    {
        var field = dailyTimeType.GetType().GetField(dailyTimeType.ToString());
        var attribute = (DisplayAttribute)field.GetCustomAttribute(typeof(DisplayAttribute));
        return attribute?.Name ?? dailyTimeType.ToString();
    }

    private async Task _onEnd(DailyTimeRequest request) =>
        await OnChange.InvokeAsync(request);
}
