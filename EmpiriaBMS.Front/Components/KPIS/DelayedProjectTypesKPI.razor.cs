using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.BarChart.Axes;
using ChartJs.Blazor.Common.Axes.Ticks;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Common;
using EmpiriaBMS.Front.Horizontal;
using ChartEnums = ChartJs.Blazor.Common.Enums;

namespace EmpiriaBMS.Front.Components.KPIS;

public partial class DelayedProjectTypesKPI
{
    private Dictionary<string, int> _delayedProjectsTypesCountByType = null;
    private BarConfig _delayedProjectsTypesBarConfig;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _getActiveDelayedProjectsTypesCountByType();
            _initilizeDelayedProjectsTypesChart();
            StateHasChanged();
        }
    }

    private void _initilizeDelayedProjectsTypesChart()
    {
        _delayedProjectsTypesBarConfig = new BarConfig
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
}
