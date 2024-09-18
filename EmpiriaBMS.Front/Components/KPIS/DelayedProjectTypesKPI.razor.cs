using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.BarChart.Axes;
using ChartJs.Blazor.Common.Axes.Ticks;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Common;
using EmpiriaBMS.Front.Horizontal;
using ChartEnums = ChartJs.Blazor.Common.Enums;
using Microsoft.AspNetCore.Components;

namespace EmpiriaBMS.Front.Components.KPIS;

public partial class DelayedProjectTypesKPI
{
    [Parameter]
    public DateTimeOffset? StartDate { get; set; }

    [Parameter]
    public DateTimeOffset? EndDate { get; set; }

    private bool _startLoading = true;

    private Dictionary<string, int> _data = null;
    private BarConfig _chartConfig;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _startLoading = true;
            await _getActiveDelayedProjectsTypesCountByType();
            _initilizeDelayedProjectsTypesChart();
            _startLoading = false;
            StateHasChanged();
        }
    }

    private void _initilizeDelayedProjectsTypesChart()
    {
        if (!_data.Any() || _chartConfig != null)
        {
            _chartConfig = null;
            return;
        }

        _chartConfig = new BarConfig
        {
            Options = new BarOptions
            {
                Title = new OptionsTitle
                {
                    Display = true,
                    Text = "Count Delayed Projects By Type",
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
                                StepSize = 0.5,
                                //SuggestedMax = 100
                            }
                        }
                    }
                },
                Legend = new Legend()
                {
                    Display = false
                },
                Responsive = true,

            }
        };

        foreach (string key in _data.Keys)
            _chartConfig.Data.Labels.Add(key);

        // Values Dataset
        var values = _data.Values;
        BarDataset<int> dataset = new BarDataset<int>(values, false)
        {
            //Label = "Project Type",
            //BackgroundColor = ChartJsHelper.GenerateColors(_data.Values.Count, 1),
            BackgroundColor = ChartJsHelper.GenerateColors(_data.Values.Count, 685, 700, 1),
            BorderWidth = 0,
            HoverBackgroundColor = ChartJsHelper.GetPreviusRgb(0.7),
            HoverBorderColor = ChartJsHelper.GetPreviusRgb(1),
            HoverBorderWidth = 1,
            BorderColor = ChartJsHelper.GetPreviusRgb(1),
            BarPercentage = 0.5,

        };
        _chartConfig.Data.Datasets.Add(dataset);

    }

    private async Task _getActiveDelayedProjectsTypesCountByType()
    {
        var userId = _sharedAuthData.LogedUser.Id;
        _data = await _dataProvider.KPIS.GetActiveDelayedProjectTypesCountByType(userId, StartDate?.Date, EndDate?.Date);
    }
}
