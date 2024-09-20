using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.BarChart.Axes;
using ChartJs.Blazor.Common.Axes.Ticks;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Common;
using EmpiriaBMS.Front.Horizontal;
using ChartEnums = ChartJs.Blazor.Common.Enums;
using Microsoft.AspNetCore.Components;
using ChartJs.Blazor.PieChart;
using Microsoft.Fast.Components.FluentUI;
using EmpiriaBMS.Front.ViewModel.Helper;

namespace EmpiriaBMS.Front.Components.KPIS;

public partial class DelayedProjectTypesKPI
{
    [Parameter]
    public DateTimeOffset? StartDate { get; set; }

    [Parameter]
    public DateTimeOffset? EndDate { get; set; }

    private bool _startLoading = true;

    private IQueryable<DictRow<int>> _data;
    private BarConfig _chartConfig;
    private string _title = "Count Delayed Projects By Type";

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

    private void _initilizeChart(out BarConfig chart, bool displayLegend = false)
    {
        if (_data == null || !_data.Any())
        {
            chart = null;
            return;
        }

        chart = new BarConfig
        {
            Options = new BarOptions
            {
                Title = new OptionsTitle
                {
                    Display = true,
                    Text = _title,
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
                                StepSize = 0.5,
                                //SuggestedMax = 100
                            }
                        }
                    }
                },
                Legend = new Legend()
                {
                    Display = displayLegend
                },
                Responsive = true,

            }
        };

        foreach (var d in _data)
            chart.Data.Labels.Add(d.Key);

        // Values Dataset
        var values = _data.Select(d => d.Value);
        BarDataset<int> dataset = new BarDataset<int>(values, false)
        {
            //Label = "Project Type",
            //BackgroundColor = ChartJsHelper.GenerateColors(_data.Values.Count, 1),
            BackgroundColor = ChartJsHelper.GenerateColors(values.Count(), 0.5),
            BorderWidth = 0,
            HoverBackgroundColor = ChartJsHelper.GetPreviusRgb(0.7),
            HoverBorderColor = ChartJsHelper.GetPreviusRgb(1),
            HoverBorderWidth = 1,
            BorderColor = ChartJsHelper.GetPreviusRgb(1),
            BarPercentage = 0.5,

        };
        chart.Data.Datasets.Add(dataset);

    }

    private async Task _getData()
    {
        var userId = _sharedAuthData.LogedUser.Id;
        var dict = await _dataProvider.KPIS.GetActiveDelayedProjectTypesCountByType(userId, StartDate?.Date, EndDate?.Date);
        _data = dict.Select(d => new DictRow<int>() { Key = d.Key, Value = d.Value }).AsQueryable();
    }

    #region Dialog FullScreen
    private bool _isDialogVisible = false;
    FluentDialog _dialog;
    // Dialog Chart
    private BarConfig _chartDialogConfig;

    private void ShowFullscreenDialog()
    {
        _dialog.Show();
        _isDialogVisible = true;
        if (_chartDialogConfig == null)
        {
            _chartConfig = null;
            _initilizeChart(out _chartDialogConfig, false);
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
    private DictRow<int> _selectedRecord = new DictRow<int>();

    private void HandleRowFocus(FluentDataGridRow<DictRow<int>> row)
    {
        _selectedRecord = row.Item as DictRow<int>;
    }
    #endregion

    #region Export As Pdf
    private bool exporting = false;

    private async Task _exportToPdf()
    {
        exporting = true;
        StateHasChanged();

        await Task.Delay(1000);

        string[] divsIds = new string[] { "export-to-pdf" };
        string fileName = $"EmbiriaBMS-{_title}-{DateTime.Now.ToEuropeFormat()}.pdf";

        await _microsoftTeams.ExportPdfContent(divsIds, fileName);

        await Task.Delay(1000);

        exporting = false;
        StateHasChanged();
    }
    #endregion
}
