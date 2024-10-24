﻿using BlazorDateRangePicker;
using EmpiriaBMS.Front.Components.General;
using Microsoft.Kiota.Abstractions;

namespace EmpiriaBMS.Front.Components.KPIS.Base;

public partial class KPIDashboard
{
    #region Authorization Properties
    bool SeeHoursPerRoleKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 18);
    bool SeeActiveDelayedProjectsKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 19);
    bool SeeActiveDelayedProjectsTypesCounterKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 23);
    bool SeeAllProjectsMissedDeadLineKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 20);
    bool SeeEmployeeTurnoverKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 21);
    bool SeeMyProjectsMissedDeadLineKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 22);
    bool SeeTenderTableKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 25);
    bool SeeDelayedPaymentsKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 26);
    bool SeePendingsPaymentsKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 27);
    bool SeeNextYearIncome => _sharedAuthData.Permissions.Any(p => p.Ord == 34);
    bool SeeEstimatedInvoicing => _sharedAuthData.Permissions.Any(p => p.Ord == 41);
    bool SeeUnpaidPaidInvoices => _sharedAuthData.Permissions.Any(p => p.Ord == 42);
    bool SeeProfitInEveryProject => _sharedAuthData.Permissions.Any(p => p.Ord == 43);
    bool SeeIssuesPerTimePeriodKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 44);
    bool SeeTurnoverPerProjectsCategoryKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 45);
    bool SeeTurnoverPerProjectsSubCategoryKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 46);
    bool SeeTurnoverPerProjectManagersKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 47);
    #endregion

    private bool _loading = false;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await MicrosoftTeams.InitializeTooltips();
        }
    }

    public async Task Refresh()
    {
        _loading = true;
        StateHasChanged();
        await Task.Delay(500);
        _loading = false;
        StateHasChanged();
    }

    #region Date Range Filter
    DateTimeOffset? StartDate { get; set; } = new DateTimeOffset(DateTime.Now.AddMonths(-2));
    DateTimeOffset? EndDate { get; set; } = new DateTimeOffset(DateTime.Now.AddDays(10));

    public async Task OnDateSelect(DateRange range)
    {
        if (StartDate.HasValue && EndDate.HasValue)
        {
            StartDate = range.Start;
            EndDate = range.End;
            await Refresh();
        }
    }
    #endregion
}
