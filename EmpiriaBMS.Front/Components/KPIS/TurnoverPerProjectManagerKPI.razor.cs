using ChartJs.Blazor.BarChart.Axes;
using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.Common.Axes.Ticks;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.PieChart;
using EmpiriaBMS.Front.Horizontal;
using ChartEnums = ChartJs.Blazor.Common.Enums;
using EmpiriaBMS.Front.Components.General;
using Microsoft.AspNetCore.Components;

namespace EmpiriaBMS.Front.Components.KPIS;

public partial class TurnoverPerProjectManagerKPI
{
    [Parameter]
    public DateTimeOffset? StartDate { get; set; }

    [Parameter]
    public DateTimeOffset? EndDate { get; set; }

    private bool _startLoading = true;

    private Dictionary<string, double> _data = null;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _startLoading = true;
            await _getData();
            _initilizeChart();
            _startLoading = false;
            StateHasChanged();
        }
    }

    private async Task _getData() =>
        _data = await _dataProvider.KPIS.GetTurnoverPerProjectManager(StartDate?.Date, EndDate?.Date);

    // Pie Chart
    private PieConfig _chartConfig;

    private void _initilizeChart()
    {
        if (!_data.Any() || _chartConfig != null)
        {
            _chartConfig = null;
            return;
        }

        _chartConfig = new PieConfig()
        {
            Options = new PieOptions()
            {
                CutoutPercentage = 0, // 50 = Doughnut  ||  0 = Pie
                Responsive = true,
                Title = new OptionsTitle()
                {
                    Display = true,
                    Text = "Turnover per Project Sub Category",
                    Position = ChartEnums.Position.Top,
                    FontSize = 24
                },
                Legend = new Legend()
                {
                    Display = false
                }
            }
        };

        foreach (string key in _data.Keys)
            _chartConfig.Data.Labels.Add(key);


        PieDataset<double> dataset = new PieDataset<double>(_data.Values)
        {
            BackgroundColor = ChartJsHelper.GenerateColors(_data.Values.Count, 1),
            //BackgroundColor = ChartJsHelper.GenerateColors(_data.Values.Count, 550, 599, 1),
            BorderWidth = 0,
            HoverBackgroundColor = ChartJsHelper.GetPreviusRgb(0.7),
            HoverBorderColor = ChartJsHelper.GetPreviusRgb(1),
            HoverBorderWidth = 1,
            BorderColor = ChartJsHelper.GetPreviusRgb(1),
        };

        _chartConfig.Data.Datasets.Add(dataset);
    }
}
