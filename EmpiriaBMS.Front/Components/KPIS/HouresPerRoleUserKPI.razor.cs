using ChartJs.Blazor.BarChart.Axes;
using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.Common.Axes.Ticks;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.PieChart;
using EmpiriaBMS.Front.Horizontal;
using ChartEnums = ChartJs.Blazor.Common.Enums;
using EmpiriaBMS.Front.Components.General;

namespace EmpiriaBMS.Front.Components.KPIS;

public partial class HouresPerRoleUserKPI
{
    private Dictionary<string, long> _hoursPerRole = null;
    private Dictionary<string, long> _hoursPerUser = null;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _getHoursPerRole();
            await _getHoursPerUser();
            _initilizeHoursPerRoleChart();
            _initilizeHoursPerUserPieChart();
            StateHasChanged();
        }
    }

    private async Task _getHoursPerRole() =>
        _hoursPerRole = await _dataProvider.KPIS.GetHoursPerRole();

    private async Task _getHoursPerUser() =>
        _hoursPerUser = await _dataProvider.KPIS.GetHoursPerUser();

    // Bar Chart
    private BarConfig _hoursPerRoleBarConfig;
    private void _initilizeHoursPerRoleChart()
    {
        _hoursPerRoleBarConfig = new BarConfig
        {
            Options = new BarOptions
            {
                Title = new OptionsTitle
                {
                    Display = true,
                    Text = "Hours Per Role Bar Chart",
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

        foreach (string key in _hoursPerRole.Keys)
            _hoursPerRoleBarConfig.Data.Labels.Add(key);

        BarDataset<long> dataset = new BarDataset<long>(_hoursPerRole.Values)
        {
            //Label = "Roles",
            //BackgroundColor = ChartJsHelper.GenerateColors(_hoursPerRole.Values.Count, 1),
            BackgroundColor = ChartJsHelper.GenerateColors(_hoursPerRole.Values.Count, 650, 699, 1),
            BorderWidth = 0,
            HoverBackgroundColor = ChartJsHelper.GetPreviusRgb(0.7),
            HoverBorderColor = ChartJsHelper.GetPreviusRgb(1),
            HoverBorderWidth = 1,
            BorderColor = ChartJsHelper.GetPreviusRgb(1),
            BarPercentage = 0.5,
        };

        _hoursPerRoleBarConfig.Data.Datasets.Add(dataset);
    }

    // Pie Chart
    private PieConfig _hoursPerUserPieConfig;

    private void _initilizeHoursPerUserPieChart()
    {
        _hoursPerUserPieConfig = new PieConfig()
        {
            Options = new PieOptions()
            {
                CutoutPercentage = 50, // 50 = Doughnut  ||  0 = Pie
                Responsive = true,
                Title = new OptionsTitle()
                {
                    Display = true,
                    Text = "Hours Per User Pie Chart",
                    Position = ChartEnums.Position.Top,
                    FontSize = 24
                }
            }
        };

        foreach (string key in _hoursPerUser.Keys)
            _hoursPerUserPieConfig.Data.Labels.Add(key);


        PieDataset<long> dataset = new PieDataset<long>(_hoursPerUser.Values)
        {
            BackgroundColor = ChartJsHelper.GenerateColors(_hoursPerUser.Values.Count, 1),
            //BackgroundColor = ChartJsHelper.GenerateColors(_hoursPerUser.Values.Count, 550, 599, 1),
            BorderWidth = 0,
            HoverBackgroundColor = ChartJsHelper.GetPreviusRgb(0.7),
            HoverBorderColor = ChartJsHelper.GetPreviusRgb(1),
            HoverBorderWidth = 1,
            BorderColor = ChartJsHelper.GetPreviusRgb(1),
        };

        _hoursPerUserPieConfig.Data.Datasets.Add(dataset);
    }
}
