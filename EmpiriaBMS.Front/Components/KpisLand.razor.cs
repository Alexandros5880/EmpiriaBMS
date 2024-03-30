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
using Microsoft.Recognizers.Definitions;

namespace EmpiriaBMS.Front.Components;

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
    #endregion

    private int _missedDeadLineProject = 0;
    private Dictionary<string, long> _employeesTurnover = null;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _initilizeHoursPerRoleChart();
            await _initilizeDelayedProjectsChart();
            await _initilizeDelayedProjectsTypesChart();


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
                    Text = "Hours Per Role",
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

    #region Initialize DelayedProjects Chart
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
                    Text = "Delayed Projects",
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
                                StepSize = 0.5,
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
            Label = "Project Type",
            BackgroundColor = "rgba(187,216,172, 1)",
            BorderWidth = 0,
            HoverBackgroundColor = "rgba(187,216,172, 0.5)",
            HoverBorderColor = "rgba(187,216,172, 1)",
            HoverBorderWidth = 1,
            BorderColor = "rgba(187,216,172, 1)",
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
