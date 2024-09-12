using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.BarChart.Axes;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Common.Axes.Ticks;
using EmpiriaBMS.Core.ReturnModels;
using EmpiriaBMS.Front.Horizontal;
using ChartEnums = ChartJs.Blazor.Common.Enums;

namespace EmpiriaBMS.Front.Components.KPIS;

public partial class PandingPaymentsKPI
{
    private bool _startLoading = true;

    private Dictionary<string, PendingPayments> _pendingPaymentsPerProject = null;
    private BarConfig _pendingPaymentsPerProjectBarConfig;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _startLoading = true;
            await _getPendingPaymentsPerProject();
            await _initilizePendingPaymentsPerProject();
            _startLoading = false;
            StateHasChanged();
        }
    }

    private async Task _initilizePendingPaymentsPerProject()
    {
        if (_pendingPaymentsPerProject.Count > 0)
        {
            _pendingPaymentsPerProjectBarConfig = new BarConfig
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

            foreach (string key in _pendingPaymentsPerProject.Select(p => p.Key))
                _pendingPaymentsPerProjectBarConfig.Data.Labels.Add(key);

            BarDataset<int> dataset = new BarDataset<int>(_pendingPaymentsPerProject.Values.Select(p => p.PendingPaymentsCount))
            {
                //Label = "Roles",
                //BackgroundColor = ChartJsHelper.GenerateColors(_hoursPerRole.Values.Count, 1),
                BackgroundColor = ChartJsHelper.GenerateColors(_pendingPaymentsPerProject.Count, 650, 699, 1),
                BorderWidth = 0,
                HoverBackgroundColor = ChartJsHelper.GetPreviusRgb(0.7),
                HoverBorderColor = ChartJsHelper.GetPreviusRgb(1),
                HoverBorderWidth = 1,
                BorderColor = ChartJsHelper.GetPreviusRgb(1),
                BarPercentage = 0.5,

            };

            _pendingPaymentsPerProjectBarConfig.Data.Datasets.Add(dataset);
        }
    }

    private async Task _getPendingPaymentsPerProject()
    {
        _pendingPaymentsPerProject = await _dataProvider.KPIS.GetPendingPayments();
    }

}
