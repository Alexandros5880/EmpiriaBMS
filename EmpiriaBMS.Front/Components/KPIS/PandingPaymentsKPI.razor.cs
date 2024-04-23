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
using Microsoft.Fast.Components.FluentUI;
using EmpiriaBMS.Core.Dtos.KPIS;

namespace EmpiriaBMS.Front.Components.KPIS;

public partial class PandingPaymentsKPI
{
    private Dictionary<string, PendingPayments> _pendingPaymentsPerProject = null;
    private BarConfig _pendingPaymentsCountPerProjectBarConfig;
    private BarConfig _pendingPaymentsFeePerProjectBarConfig;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _getDelayedPaymentsPerProject();

            _initilizePendingPaymentsCountPerProject();
            _initilizePendingPaymentsFeePerProject();

            StateHasChanged();
        }
    }

    private void _initilizePendingPaymentsCountPerProject()
    {
        if (_pendingPaymentsPerProject.Count > 0)
        {
            _pendingPaymentsCountPerProjectBarConfig = new BarConfig
            {
                Options = new BarOptions
                {
                    Title = new OptionsTitle
                    {
                        Display = true,
                        Text = "Pending Payments",
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
                _pendingPaymentsCountPerProjectBarConfig.Data.Labels.Add(key);

            BarDataset<int> dataset = new BarDataset<int>(_pendingPaymentsPerProject.Values.Select(p => p.DelayedPaymentsCount))
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

            _pendingPaymentsCountPerProjectBarConfig.Data.Datasets.Add(dataset);
        }
    }

    private void _initilizePendingPaymentsFeePerProject()
    {
        if (_pendingPaymentsPerProject.Count > 0)
        {
            _pendingPaymentsFeePerProjectBarConfig = new BarConfig
            {
                Options = new BarOptions
                {
                    Title = new OptionsTitle
                    {
                        Display = true,
                        Text = "Pending Payments",
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
                _pendingPaymentsFeePerProjectBarConfig.Data.Labels.Add(key);

            BarDataset<double> dataset = new BarDataset<double>(_pendingPaymentsPerProject.Values.Select(p => p.PendingFee))
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

            _pendingPaymentsFeePerProjectBarConfig.Data.Datasets.Add(dataset);
        }
    }

    private async Task _getDelayedPaymentsPerProject()
    {
        _pendingPaymentsPerProject = await _dataProvider.KPIS.GetPendingPaymentsPerProject();
    }

    #region Table
    private IQueryable<PendingPayments> _data => _pendingPaymentsPerProject?.Values?.AsQueryable();
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private void HandleRowFocus(FluentDataGridRow<PendingPayments> row)
    {
        Console.WriteLine($"Row focused: {row.Item?.Project.Name}");
    }
    #endregion
}
