using ChartJs.Blazor.BarChart.Axes;
using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.Common.Axes.Ticks;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Common;
using EmpiriaBMS.Front.ViewModel.Components;
using ChartEnums = ChartJs.Blazor.Common.Enums;
using EmpiriaBMS.Front.Components.General;

namespace EmpiriaBMS.Front.Components.KPIS;

public partial class DelayedProjectsKPI
{

    private List<ProjectVM> _delayedProjects = null;
    private BarConfig _delayedProjectsBarConfig;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _getActiveDelayedProjects();
            _initilizeDelayedProjectsChart();
            StateHasChanged();
        }
    }

    private void _initilizeDelayedProjectsChart()
    {
        _delayedProjectsBarConfig = new BarConfig
        {
            Options = new BarOptions
            {
                Title = new OptionsTitle
                {
                    Display = true,
                    Text = "Delayed Projects Bar Chart",
                    Position = ChartEnums.Position.Top,
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

    #region Hellper Methods
    private string _displayTimeMissedStr(DateTime date)
    {
        TimeSpan diff = DateTime.Now - date;
        return diff.ToString(@"d'd h'h m'm s's");
    }

    private TimeSpan _displayTimeMissed(DateTime? date) => (TimeSpan)(DateTime.Now - date);
    #endregion
}
