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
using ChartJs.Blazor.PolarAreaChart;
using Microsoft.Fast.Components.FluentUI;

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
            _initilizeChart(out _chartConfig);
            _startLoading = false;
            StateHasChanged();
        }
    }

    private async Task _getData() =>
        _data = await _dataProvider.KPIS.GetTurnoverPerProjectManager(StartDate?.Date, EndDate?.Date);

    private PolarAreaConfig _chartConfig;

    private void _initilizeChart(out PolarAreaConfig chart, bool displayLegend = false)
    {
        if (_data == null || !_data.Any())
        {
            chart = null;
            return;
        }

        chart = new PolarAreaConfig()
        {
            Options = new PolarAreaOptions()
            {
                Responsive = true,
                Title = new OptionsTitle()
                {
                    Display = true,
                    Text = "Turnover per Project Manager",
                    Position = ChartEnums.Position.Top,
                    FontSize = 24
                },
                Legend = new Legend()
                {
                    Display = displayLegend
                }
            }
        };

        foreach (string key in _data.Keys)
            chart.Data.Labels.Add(key);

        var dataset = new PolarAreaDataset<double>(_data.Values)
        {
            BackgroundColor = ChartJsHelper.GenerateColors(_data.Values.Count, 1),
            BorderWidth = 0,
            HoverBackgroundColor = ChartJsHelper.GetPreviusRgb(0.7),
            HoverBorderColor = ChartJsHelper.GetPreviusRgb(1),
            HoverBorderWidth = 1,
            BorderColor = ChartJsHelper.GetPreviusRgb(1),
        };

        chart.Data.Datasets.Add(dataset);
    }

    #region Dialog FullScreen
    private bool _isDialogVisible = false;
    FluentDialog _dialog;
    // Dialog Chart
    private PolarAreaConfig _chartDialogConfig;

    private void ShowFullscreenDialog()
    {
        _dialog.Show();
        _isDialogVisible = true;
        if (_chartDialogConfig == null)
        {
            _chartConfig = null;
            _initilizeChart(out _chartDialogConfig, true);
            StateHasChanged();
        }
    }

    private void HideFullscreenDialog()
    {
        if (_isDialogVisible == true)
        {
            _dialog.Hide();
            _isDialogVisible = false;
            _chartDialogConfig = null;
            _initilizeChart(out _chartConfig, false);
            StateHasChanged();
        }
    }
    #endregion

}
