using AutoMapper;
using EmpiriaBMS.Core;
using EmpiriaBMS.Front.Interop.TeamsSDK;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;

using BlazorBootstrap;
using ChartJs.Blazor.PieChart;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.Util;
using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.BarChart.Axes;
using ChartJs.Blazor.Common.Axes.Ticks;
using ChartEnums = ChartJs.Blazor.Common.Enums;
using Azure;

namespace EmpiriaBMS.Front.Components;

public partial class KpisLand : ComponentBase, IDisposable
{
    private bool disposedValue;
    bool _loading = true;

    #region Authorization Properties
    bool SeeHoursPerRoleKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 18);
    bool SeeActiveDelayedProjectsKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 19);
    bool SeeAllProjectsMissedDeadLineKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 20);
    bool SeeEmployeeTurnoverKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 21);
    bool SeeMyProjectsMissedDeadLineKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 22);
    #endregion

    private int _missedDeadLineProject = 0;
    private List<ProjectVM> _delayedProjects = null;
    private Dictionary<string, long> _employeesTurnover = null;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _initilizeHoursPerRoleChart();

            await _getMissedDeadLineProjects();
            await _getActiveDelayedProjects();
            await _getEmployeesTurnover();

            _loading = false;
            StateHasChanged();
        }
    }

    private async Task _getMissedDeadLineProjects()
    {
        _missedDeadLineProject = await _dataProvider.KPIS.GetMissedDeadLineProjects();
    }

    private async Task _getActiveDelayedProjects()
    {
        var userId = _sharedAuthData.LogedUser.Id;
        var dtos = await _dataProvider.KPIS.GetActiveDelayedProjects(userId);
        _delayedProjects = _mapper.Map<List<ProjectVM>>(dtos);
    }

    private async Task _getEmployeesTurnover()
    {
        await Task.Delay(1000);

        // TODO: _getEmployeesTurnover()
        // _employeesTurnover = await _dataProvider.KPIS.GetEmployeesTurnover();
    }

    private string _displayTimeMissed(DateTime? date) => 
            (DateTime.Now - date)?.ToString(@"dd Days, hh\:mm\:ss");

    #region Initialize HoursPerRole Chart
    private Dictionary<string, long> _hoursPerRole = null;
    private BarConfig _hoursPerRoleBarConfig;

    private async Task _initilizeHoursPerRoleChart()
    {
        await _getHoursPerRole();
        _hoursPerRoleBarConfig = new BarConfig
        {
            Options = new BarOptions
            {
                Title = new OptionsTitle
                {
                    Display = true,
                    Text = "Hours per Role",
                    Position = ChartEnums.Position.Left,
                    FontSize = 24
                },
                Scales = new BarScales
                {
                    XAxes = new List<CartesianAxis>
                    {
                        new BarCategoryAxis
                        {
                            BarPercentage = 0.5,
                            BarThickness = BarThickness.Flex
                        }
                    },
                    YAxes = new List<CartesianAxis>
                    {
                        new BarLinearCartesianAxis
                        {
                            Ticks = new LinearCartesianTicks
                            {
                                BeginAtZero = true,
                                StepSize = 2,
                                //SuggestedMax = 100
                            }
                        }
                    }
                },
                Responsive = true,

            }
        };

        foreach (string key in _hoursPerRole.Keys)
            _hoursPerRoleBarConfig.Data.Labels.Add(key);

        BarDataset<long> dataset = new BarDataset<long>(_hoursPerRole.Values)
        {
            Label = "Roles",
            BackgroundColor = "rgba(0,128,128, 1)",
            BorderWidth = 0,
            HoverBackgroundColor = "rgba(0,128,128, 0.5)",
            HoverBorderColor = "rgba(0,128,128, 1)",
            HoverBorderWidth = 1,
            BorderColor = "rgba(0,128,128, 1)",
            BarPercentage = 0.5,

        };

        _hoursPerRoleBarConfig.Data.Datasets.Add(dataset);
    }

    private async Task _getHoursPerRole() =>
        _hoursPerRole = await _dataProvider.KPIS.GetHoursPerRole();
    #endregion

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
