﻿using EmpiriaBMS.Models.Enum;
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

    [Parameter]
    public Dictionary<DailyTimeTypes, List<DailyTime>> DailyRequests { get; set; }

    private string GetDisplayName(DailyTimeTypes dailyTimeType)
    {
        var field = dailyTimeType.GetType().GetField(dailyTimeType.ToString());
        var attribute = (DisplayAttribute)field.GetCustomAttribute(typeof(DisplayAttribute));
        return attribute?.Name ?? dailyTimeType.ToString();
    }

    private async Task _onEnd(DailyTime request) =>
        await OnChange.InvokeAsync(request);
}