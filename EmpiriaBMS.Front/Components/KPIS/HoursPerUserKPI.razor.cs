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

public partial class HoursPerUserKPI
{
    private bool _startLoading = false;

    private Dictionary<string, long> _hoursPerUser = null;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _startLoading = true;
            await _getHoursPerUser();
            _initilizeHoursPerUserPieChart();
            _startLoading = false;
            StateHasChanged();
        }
    }

    private async Task _getHoursPerUser() =>
        _hoursPerUser = await _dataProvider.KPIS.GetHoursPerUser();

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
                },
                Legend = new Legend()
                {
                    Display = false
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
