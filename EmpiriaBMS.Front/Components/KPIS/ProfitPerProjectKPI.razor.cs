using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.BarChart.Axes;
using ChartJs.Blazor.Common.Axes.Ticks;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.PieChart;
using ChartJs.Blazor.Common;
using EmpiriaBMS.Front.Horizontal;
using ChartEnums = ChartJs.Blazor.Common.Enums;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using EmpiriaBMS.Front.ViewModel.Helper;
using EmpiriaBMS.Front.Components.KPIS.Contract;

namespace EmpiriaBMS.Front.Components.KPIS;

public partial class ProfitPerProjectKPI : IKpiCompoment
{
    [Parameter]
    public DateTimeOffset? StartDate { get; set; }

    [Parameter]
    public DateTimeOffset? EndDate { get; set; }

    private bool _startLoading = true;

    private IQueryable<DictRow<double>> _data;

    public string Title => "Profit Per Project";
    private PieConfig _chartConfig;

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

    private void _initilizeChart(out PieConfig chart, bool displayLegend = false)
    {
        if (_data == null || !_data.Any())
        {
            chart = null;
            return;
        }

        chart = new PieConfig
        {
            Options = new PieOptions()
            {
                CutoutPercentage = 0, // 50 = Doughnut  ||  0 = Pie
                Responsive = true,
                Title = new OptionsTitle()
                {
                    Display = true,
                    Text = Title,
                    Position = ChartEnums.Position.Top,
                    FontSize = 24
                },
                Legend = new Legend()
                {
                    Display = displayLegend,
                    FullWidth = false,
                    Position = ChartEnums.Position.Left, // Place legend on the right
                    Labels = new LegendLabels()
                    {
                        BoxWidth = 10,  // Size of the box in the legend
                        UsePointStyle = true,  // Use a custom style for the legend
                    }
                }
            }
        };

        // Add labels to the Y-axis (categories)
        foreach (var d in _data)
            chart.Data.Labels.Add(d.Key);

        var values = _data.Select(d => d.Value);

        // Add the values to the dataset
        PieDataset<double> dataset = new PieDataset<double>(values, false)
        {
            BackgroundColor = ChartJsHelper.GenerateColors(values.Count(), 0.5),
            BorderWidth = 0,
            HoverBackgroundColor = ChartJsHelper.GetPreviusRgb(0.7),
            HoverBorderColor = ChartJsHelper.GetPreviusRgb(1),
            HoverBorderWidth = 1,
            BorderColor = ChartJsHelper.GetPreviusRgb(1)
        };

        // Add dataset to the chart
        chart.Data.Datasets.Add(dataset);
    }

    private async Task _getData()
    {
        var userId = _sharedAuthData.LogedUser.Id;
        var dict = await _dataProvider.KPIS.GetProfitPerProject(userId, StartDate?.Date, EndDate?.Date);
        _data = dict.Select(d => new DictRow<double>() { Key = d.Key, Value = d.Value }).AsQueryable();
    }

    #region Dialog FullScreen
    private bool _isDialogVisible = false;
    FluentDialog _dialog;
    // Dialog Chart
    private PieConfig _chartDialogConfig;

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

    #region Data Table
    private DictRow<double> _selectedRecord = new DictRow<double>();

    private void HandleRowFocus(FluentDataGridRow<DictRow<double>> row)
    {
        _selectedRecord = row.Item as DictRow<double>;
    }
    #endregion

    #region Export As Pdf
    private bool exporting = false;

    private async Task _exportToPdf()
    {
        exporting = true;
        StateHasChanged();

        await Task.Delay(2000);

        var filtersId = "filters-to-pdf";
        var chartId = "chart-to-pdf";
        var tableId = "table-to-pdf";

        string fileName = $"EmbiriaBMS {Title} {DateTime.Now.ToEuropeFormat()}.pdf";
        await _microsoftTeams.ExportChartTableToPdf(filtersId, chartId, tableId, fileName);

        await Task.Delay(1000);

        exporting = false;
        StateHasChanged();
    }
    #endregion
}