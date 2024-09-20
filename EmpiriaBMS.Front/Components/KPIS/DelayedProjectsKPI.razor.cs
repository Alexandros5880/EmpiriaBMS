using ChartJs.Blazor.BarChart.Axes;
using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.Common.Axes.Ticks;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Common;
using EmpiriaBMS.Front.ViewModel.Components;
using ChartEnums = ChartJs.Blazor.Common.Enums;
using EmpiriaBMS.Front.Components.General;
using Microsoft.AspNetCore.Components;
using ChartJs.Blazor.PieChart;
using Microsoft.Fast.Components.FluentUI;
using EmpiriaBMS.Front.ViewModel.Helper;

namespace EmpiriaBMS.Front.Components.KPIS;

public partial class DelayedProjectsKPI
{
    [Parameter]
    public DateTimeOffset? StartDate { get; set; }

    [Parameter]
    public DateTimeOffset? EndDate { get; set; }

    private bool _startLoading = true;

    private IQueryable<DictRowDelayProject> _data = null;
    private BarConfig _chartConfig;
    private string _title = "Delayed Projects";

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

    private async Task _getData()
    {
        var userId = _sharedAuthData.LogedUser.Id;
        var dtos = await _dataProvider.KPIS.GetActiveDelayedProjects(userId, StartDate?.Date, EndDate?.Date);

        _data = dtos.Select(p => new DictRowDelayProject()
        {
            Name = p.Name,
            Days = _displayTimeMissed((DateTime)p.DeadLine).Days,
            Hours = _displayTimeMissed((DateTime)p.DeadLine).Hours,
            Minutes = _displayTimeMissed((DateTime)p.DeadLine).Hours
        }).AsQueryable();
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
                    Text = "Delayed Projects",
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
                                StepSize = 5.0,
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

        foreach (string key in _data.Select(d => d.Name))
            chart.Data.Labels.Add(key);

        // Dayes Dataset
        BarDataset<int> dayesDataSet = new BarDataset<int>(_data.Select(d => d.Days), false)
        {
            Label = "Days Dealied",
            BackgroundColor = "rgba(0,94,160, 0.8)",
            BorderWidth = 0,
            HoverBackgroundColor = "rgba(0,94,160, 0.5)",
            HoverBorderColor = "rgba(0,94,160, 0.8)",
            HoverBorderWidth = 1,
            BorderColor = "rgba(0,94,160, 0.8)",
            BarPercentage = 0.5,

        };
        chart.Data.Datasets.Add(dayesDataSet);

        // Hours Dataset
        BarDataset<int> hoursDataSet = new BarDataset<int>(_data.Select(d => d.Hours), false)
        {
            Label = "Hours Dealied",
            BackgroundColor = "rgba(49,83,0, 0.8)",
            BorderWidth = 0,
            HoverBackgroundColor = "rgba(49,83,0, 0.5)",
            HoverBorderColor = "rgba(49,83,0, 0.8)",
            HoverBorderWidth = 1,
            BorderColor = "rgba(49,83,0, 0.8)",
            BarPercentage = 0.5,

        };
        chart.Data.Datasets.Add(hoursDataSet);

        // Minutes Dataset
        BarDataset<int> minutesDataSet = new BarDataset<int>(_data.Select(d => d.Minutes), false)
        {
            Label = "Minutes Dealied",
            BackgroundColor = "rgba(0,83,75, 0.8)",
            BorderWidth = 0,
            HoverBackgroundColor = "rgba(0,83,75, 0.5)",
            HoverBorderColor = "rgba(0,83,75, 0.8)",
            HoverBorderWidth = 1,
            BorderColor = "rgba(0,83,75, 0.8)",
            BarPercentage = 0.5,

        };
        chart.Data.Datasets.Add(minutesDataSet);
    }  

    #region Hellper Methods
    private string _displayTimeMissedStr(DateTime date)
    {
        TimeSpan diff = DateTime.Now - date;
        return diff.ToString(@"d'd h'h m'm s's");
    }

    private TimeSpan _displayTimeMissed(DateTime? date) => (TimeSpan)(DateTime.Now - date);
    #endregion

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
    private DictRowDelayProject _selectedRecord = new DictRowDelayProject();

    private void HandleRowFocus(FluentDataGridRow<DictRowDelayProject> row)
    {
        _selectedRecord = row.Item as DictRowDelayProject;
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

    private sealed class DictRowDelayProject
    {
        public string Name { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
    }
}
