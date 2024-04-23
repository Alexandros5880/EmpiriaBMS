using AutoMapper;
using EmpiriaBMS.Core;
using EmpiriaBMS.Front.Interop.TeamsSDK;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;

using ChartJs.Blazor.PieChart;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.Util;
using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.BarChart.Axes;
using ChartJs.Blazor.Common.Axes.Ticks;
using ChartEnums = ChartJs.Blazor.Common.Enums;
using Azure;
using Microsoft.Recognizers.Definitions;
using static Microsoft.Fast.Components.FluentUI.Emojis.FoodDrink.Color.Default;
using ChartJs.Blazor;
using EmpiriaBMS.Front.Horizontal;
using Microsoft.Fast.Components.FluentUI;
using Microsoft.Graph.Models;
using EmpiriaBMS.Core.Dtos;
using Microsoft.AspNetCore.Components.Web;

namespace EmpiriaBMS.Front.Components.KPIS;

public partial class KpisLand : ComponentBase, IDisposable
{
    private bool disposedValue;
    bool _loading = true;

    #region Authorization Properties
    bool SeeHoursPerRoleKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 18);
    bool SeeActiveDelayedProjectsKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 19);
    bool SeeActiveDelayedProjectsTypesCounterKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 23);
    bool SeeAllProjectsMissedDeadLineKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 20);
    bool SeeEmployeeTurnoverKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 21);
    bool SeeMyProjectsMissedDeadLineKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 22);
    bool SeeTenderTableKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 25);
    bool SeeDelayedPaymentsKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 26);
    #endregion

    
    

    #region Tab Actions
    bool[] tabs =
    {
        true,
        false,
        false,
        false,
        false,
        false,
        false,
    };

    private void TabMenuClick(MouseEventArgs e, int tabIndex)
    {
        for (int i = 0; i < tabs.Length; i++) { tabs[i] = false; }
        tabs[tabIndex] = true;
    }
    #endregion



    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _getMissedDeadLineProjects();
            await _getEmployeesTurnover();

            _loading = false;
            StateHasChanged();
        }
    }



    private decimal _missedDeadLineProject = 0;
    private async Task _getMissedDeadLineProjects()
    {
        _missedDeadLineProject = await _dataProvider.KPIS.GetMissedDeadLineProjects();
    }



    private Dictionary<string, long> _employeesTurnover = null;
    private async Task _getEmployeesTurnover()
    {
        await Task.Delay(1000);

        // TODO: _getEmployeesTurnover()
        // _employeesTurnover = await _dataProvider.KPIS.GetEmployeesTurnover();
    }

    

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {

            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
