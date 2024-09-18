using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.BarChart.Axes;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Common.Axes.Ticks;
using EmpiriaBMS.Core.ReturnModels;
using EmpiriaBMS.Front.Horizontal;
using Microsoft.AspNetCore.Components;
using ChartEnums = ChartJs.Blazor.Common.Enums;

namespace EmpiriaBMS.Front.Components.KPIS;

public partial class IssuesPerProjectCountKPI
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
            await _initilizeChart();
            _startLoading = false;

            StateHasChanged();
        }
    }

    private async Task _initilizeChart()
    {
        await _getRecords();

        if (!_data.Any() || _chartConfig != null)
        {
            _chartConfig = null;
            return;
        }

        if (_data.Count > 0)
        {
            _chartConfig = new BarConfig
            {
                Options = new BarOptions
                {
                    Title = new OptionsTitle
                    {
                        Display = true,
                        Text = "Count Issues per Project",
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
                                    StepSize = 2,
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

            foreach (string key in _data.Select(p => p.Key))
                _chartConfig.Data.Labels.Add(key);

            BarDataset<int> dataset = new BarDataset<int>(_data.Values)
            {
                //Label = "Roles",
                //BackgroundColor = ChartJsHelper.GenerateColors(_hoursPerRole.Values.Count, 1),
                BackgroundColor = ChartJsHelper.GenerateColors(_data.Count, 650, 699, 1),
                BorderWidth = 0,
                HoverBackgroundColor = ChartJsHelper.GetPreviusRgb(0.7),
                HoverBorderColor = ChartJsHelper.GetPreviusRgb(1),
                HoverBorderWidth = 1,
                BorderColor = ChartJsHelper.GetPreviusRgb(1),
                BarPercentage = 0.5,

            };

            _chartConfig.Data.Datasets.Add(dataset);
        }
    }

    private async Task _getRecords()
    {
        _data = await _dataProvider.KPIS.GetIssuesPerProjectCount(StartDate?.Date, EndDate?.Date);
    }
}
