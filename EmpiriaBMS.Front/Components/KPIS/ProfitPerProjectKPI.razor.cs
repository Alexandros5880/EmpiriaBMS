using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.BarChart.Axes;
using ChartJs.Blazor.Common.Axes.Ticks;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.PieChart;
using ChartJs.Blazor.Common;
using EmpiriaBMS.Front.Horizontal;
using ChartEnums = ChartJs.Blazor.Common.Enums;
using Microsoft.AspNetCore.Components;

namespace EmpiriaBMS.Front.Components.KPIS;

public partial class ProfitPerProjectKPI
{
    [Parameter]
    public DateTimeOffset? StartDate { get; set; }

    [Parameter]
    public DateTimeOffset? EndDate { get; set; }

    private bool _startLoading = true;

    private Dictionary<string, double> _data = null;
    private PieConfig _chartConfig;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _startLoading = true;
            await _getProfitPerProject();
            _initilizeChart();
            _startLoading = false;
            StateHasChanged();
        }
    }

    private void _initilizeChart()
    {
        if (!_data.Any() || _chartConfig != null)
        {
            _chartConfig = null;
            return;
        }

        _chartConfig = new PieConfig
        {
            Options = new PieOptions()
            {
                CutoutPercentage = 0, // 50 = Doughnut  ||  0 = Pie
                Responsive = true,
                Title = new OptionsTitle()
                {
                    Display = true,
                    Text = "Profit Per Project",
                    Position = ChartEnums.Position.Top,
                    FontSize = 24
                },
                Legend = new Legend()
                {
                    Display = false
                }
            }
        };

        // Check if data is available
        if (_data != null && _data.Count > 0)
        {
            // Add labels to the Y-axis (categories)
            foreach (string key in _data.Keys)
                _chartConfig.Data.Labels.Add(key);

            // Add the values to the dataset
            var values = _data.Values;
            PieDataset<double> dataset = new PieDataset<double>(values, false)
            {
                BackgroundColor = ChartJsHelper.GenerateColors(_data.Values.Count),
                BorderWidth = 0,
                HoverBackgroundColor = ChartJsHelper.GetPreviusRgb(0.7),
                HoverBorderColor = ChartJsHelper.GetPreviusRgb(1),
                HoverBorderWidth = 1,
                BorderColor = ChartJsHelper.GetPreviusRgb(1)
            };

            // Add dataset to the chart
            _chartConfig.Data.Datasets.Add(dataset);
        }
    }

    private async Task _getProfitPerProject()
    {
        var userId = _sharedAuthData.LogedUser.Id;

        _data = await _dataProvider.KPIS.GetProfitPerProject(userId, StartDate?.Date, EndDate?.Date);

        if (_data != null)
        {
            _initilizeChart();
            StateHasChanged();
        }
    }
}
