using EmpiriaBMS.Front.Components.General;
using EmpiriaBMS.Models.Enum;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EmpiriaBMS.Front.Components.Home.Header.Hours;

public partial class DailyTimeRequestsCorrection
{
    [Parameter]
    public int RequestCount { get; set; }

    [Parameter]
    public EventCallback<DailyTime> OnChange { get; set; }

    private bool _loading = false;
    private Dictionary<DailyTimeTypes, List<DailyTime>> _dailyTimeRequest = new Dictionary<DailyTimeTypes, List<DailyTime>>();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _loading = true;
            await _getHoursCorrectionsAwaitingRequests();
            _loading = false;
            StateHasChanged();
        }
    }

    private string GetDisplayName(DailyTimeTypes dailyTimeType)
    {
        var field = dailyTimeType.GetType().GetField(dailyTimeType.ToString());
        var attribute = (DisplayAttribute)field.GetCustomAttribute(typeof(DisplayAttribute));
        return attribute?.Name ?? dailyTimeType.ToString();
    }

    private async Task _onEnd(DailyTime request) =>
        await OnChange.InvokeAsync(request);

    private async Task _getHoursCorrectionsAwaitingRequests()
    {
        _dailyTimeRequest.Clear();
        _dailyTimeRequest = await _dataProvider.WorkingTime.GetDailyTimeRequests(DailyTimeState.AWAITING);
    }
}
