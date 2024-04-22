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

    private decimal _missedDeadLineProject = 0;
    private Dictionary<string, long> _employeesTurnover = null;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _initilizeDelayedProjectsChart();
            await _initilizeDelayedProjectsTypesChart();

            await _getMissedDeadLineProjects();
            await _getEmployeesTurnover();

            _loading = false;
            StateHasChanged();
        }
    }

    private async Task _getMissedDeadLineProjects()
    {
        _missedDeadLineProject = await _dataProvider.KPIS.GetMissedDeadLineProjects();
    }

    private async Task _getEmployeesTurnover()
    {
        await Task.Delay(1000);

        // TODO: _getEmployeesTurnover()
        // _employeesTurnover = await _dataProvider.KPIS.GetEmployeesTurnover();
    }

    private string _displayTimeMissedStr(DateTime date)
    {
        TimeSpan diff = DateTime.Now - date;
        return diff.ToString(@"d'd h'h m'm s's");
    }

    private TimeSpan _displayTimeMissed(DateTime? date) => (TimeSpan)(DateTime.Now - date);

    #region Initialize DelayedProjects Bar Chart
    private List<ProjectVM> _delayedProjects = null;
    private BarConfig _delayedProjectsBarConfig;

    private async Task _initilizeDelayedProjectsChart()
    {
        await _getActiveDelayedProjects();

        _delayedProjectsBarConfig = new BarConfig
        {
            Options = new BarOptions
            {
                Title = new OptionsTitle
                {
                    Display = true,
                    Text = "Delayed Projects Bar Chart",
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
                                StepSize = 5.0,
                                //SuggestedMax = 100
                            }
                        }
                    }
                },
                Responsive = true,

            }
        };

        var names = _delayedProjects.Select(p => p.Name).ToList();

        foreach (string key in names)
            _delayedProjectsBarConfig.Data.Labels.Add(key);

        // Dayes Dataset
        var days = _delayedProjects.Select(p => _displayTimeMissed((DateTime)p.DeadLine).Days).ToList();
        BarDataset<int> dayesDataSet = new BarDataset<int>(days, false)
        {
            Label = "Days Dealied",
            BackgroundColor = "rgba(0,94,160, 1)",
            BorderWidth = 0,
            HoverBackgroundColor = "rgba(0,94,160, 0.5)",
            HoverBorderColor = "rgba(0,94,160, 1)",
            HoverBorderWidth = 1,
            BorderColor = "rgba(0,94,160, 1)",
            BarPercentage = 0.5,

        };
        _delayedProjectsBarConfig.Data.Datasets.Add(dayesDataSet);

        // Hours Dataset
        var hours = _delayedProjects.Select(p => _displayTimeMissed((DateTime)p.DeadLine).Hours).ToList();
        BarDataset<int> hoursDataSet = new BarDataset<int>(hours, false)
        {
            Label = "Hours Dealied",
            BackgroundColor = "rgba(49,83,0, 1)",
            BorderWidth = 0,
            HoverBackgroundColor = "rgba(49,83,0, 0.5)",
            HoverBorderColor = "rgba(49,83,0, 1)",
            HoverBorderWidth = 1,
            BorderColor = "rgba(49,83,0, 1)",
            BarPercentage = 0.5,

        };
        _delayedProjectsBarConfig.Data.Datasets.Add(hoursDataSet);

        // Minutes Dataset
        var minutes = _delayedProjects.Select(p => _displayTimeMissed((DateTime)p.DeadLine).Minutes).ToList();
        BarDataset<int> minutesDataSet = new BarDataset<int>(minutes, false)
        {
            Label = "Minutes Dealied",
            BackgroundColor = "rgba(0,83,75, 1)",
            BorderWidth = 0,
            HoverBackgroundColor = "rgba(0,83,75, 0.5)",
            HoverBorderColor = "rgba(0,83,75, 1)",
            HoverBorderWidth = 1,
            BorderColor = "rgba(0,83,75, 1)",
            BarPercentage = 0.5,

        };
        _delayedProjectsBarConfig.Data.Datasets.Add(minutesDataSet);
    }

    private async Task _getActiveDelayedProjects()
    {
        var userId = _sharedAuthData.LogedUser.Id;
        var dtos = await _dataProvider.KPIS.GetActiveDelayedProjects(userId);
        _delayedProjects = _mapper.Map<List<ProjectVM>>(dtos);
    }
    #endregion

    #region Initialize ProjectTypes Missed DeadLine Chart
    private Dictionary<string, int> _delayedProjectsTypesCountByType = null;
    private BarConfig _delayedProjectsTypesBarConfig;

    private async Task _initilizeDelayedProjectsTypesChart()
    {
        await _getActiveDelayedProjectsTypesCountByType();

        _delayedProjectsTypesBarConfig = new BarConfig
        {
            Options = new BarOptions
            {
                Title = new OptionsTitle
                {
                    Display = true,
                    Text = "Count Delayed Projects By Type",
                    Position = ChartEnums.Position.Right,
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
                                StepSize = 0.5,
                                //SuggestedMax = 100
                            }
                        }
                    }
                },
                Responsive = true,

            }
        };

        foreach (string key in _delayedProjectsTypesCountByType.Keys)
            _delayedProjectsTypesBarConfig.Data.Labels.Add(key);

        // Values Dataset
        var values = _delayedProjectsTypesCountByType.Values;
        BarDataset<int> dataset = new BarDataset<int>(values, false)
        {
            //Label = "Project Type",
            //BackgroundColor = ChartJsHelper.GenerateColors(_delayedProjectsTypesCountByType.Values.Count, 1),
            BackgroundColor = ChartJsHelper.GenerateColors(_delayedProjectsTypesCountByType.Values.Count, 685, 700, 1),
            BorderWidth = 0,
            HoverBackgroundColor = ChartJsHelper.GetPreviusRgb(0.7),
            HoverBorderColor = ChartJsHelper.GetPreviusRgb(1),
            HoverBorderWidth = 1,
            BorderColor = ChartJsHelper.GetPreviusRgb(1),
            BarPercentage = 0.5,

        };
        _delayedProjectsTypesBarConfig.Data.Datasets.Add(dataset);

    }

    private async Task _getActiveDelayedProjectsTypesCountByType()
    {
        var userId = _sharedAuthData.LogedUser.Id;
        _delayedProjectsTypesCountByType = await _dataProvider.KPIS.GetActiveDelayedProjectTypesCountByType(userId);
    }
    #endregion

    #region Tab Actions
    string? activeid = "tab-1";
    FluentTab? changedto;

    private void HandleOnTabChange(FluentTab tab)
    {
        changedto = tab;
    }
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
