using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.BarChart.Axes;
using ChartJs.Blazor.Common.Axes.Ticks;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Common;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Components.General;
using EmpiriaBMS.Front.Horizontal;
using ChartEnums = ChartJs.Blazor.Common.Enums;
using EmpiriaBMS.Core.ReturnModels;

namespace EmpiriaBMS.Front.Components.KPIS;

public partial class DelayedPaymentsKpi
{
    private Dictionary<string, DelayedPayments> _delayedPaymentsPerProject = null;
    private BarConfig _delayedPaymentsPerProjectBarConfig;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _initilizeDelayedPaymentsPerProject();

            StateHasChanged();
        }
    }

    private async Task _initilizeDelayedPaymentsPerProject()
    {
        await _getDelayedPaymentsPerProject();

        if (_delayedPaymentsPerProject.Count > 0)
        {
            _delayedPaymentsPerProjectBarConfig = new BarConfig
            {
                Options = new BarOptions
                {
                    Title = new OptionsTitle
                    {
                        Display = true,
                        Text = "Delayed Payments",
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
                    Responsive = true,

                }
            };

            foreach (string key in _delayedPaymentsPerProject.Select(p => p.Key))
                _delayedPaymentsPerProjectBarConfig.Data.Labels.Add(key);

            BarDataset<int> dataset = new BarDataset<int>(_delayedPaymentsPerProject.Values.Select(p => p.DelayedPaymentsCount))
            {
                //Label = "Roles",
                //BackgroundColor = ChartJsHelper.GenerateColors(_hoursPerRole.Values.Count, 1),
                BackgroundColor = ChartJsHelper.GenerateColors(_delayedPaymentsPerProject.Count, 650, 699, 1),
                BorderWidth = 0,
                HoverBackgroundColor = ChartJsHelper.GetPreviusRgb(0.7),
                HoverBorderColor = ChartJsHelper.GetPreviusRgb(1),
                HoverBorderWidth = 1,
                BorderColor = ChartJsHelper.GetPreviusRgb(1),
                BarPercentage = 0.5,

            };

            _delayedPaymentsPerProjectBarConfig.Data.Datasets.Add(dataset);
        }
    }

    private async Task _getDelayedPaymentsPerProject()
    {
        _delayedPaymentsPerProject = await _dataProvider.KPIS.GetDelayedPayments();
    }

}
