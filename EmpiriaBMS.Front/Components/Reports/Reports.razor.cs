using BlazorBootstrap;
using BlazorDateRangePicker;
using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.BarChart.Axes;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Common.Axes.Ticks;
using ChartJs.Blazor.Util;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.ReturnModels;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using ChartEnums = ChartJs.Blazor.Common.Enums;
using Color = System.Drawing.Color;
using Fluent = Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Reports;

public partial class Reports
{
    private static Random _random = new Random();

    private List<ReportProjectReturnModel> reportEntries = new();
    private BarConfig _barChartConfig;

    protected override void OnInitialized()
    {
        base.OnInitializedAsync();
        _initializeChart();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _refreshData();
            await _getReportData();
            StateHasChanged();
        }
    }

    #region Initialize Chart
    private void _initializeChart()
    {
        _barChartConfig = new BarConfig
        {
            Options = new BarOptions
            {
                Title = new OptionsTitle
                {
                    Display = true,
                    Text = "Projects Hours",
                    Position = ChartEnums.Position.Left,
                    FontSize = 24
                },
                Scales = new BarScales
                {
                    XAxes = new List<CartesianAxis>
                    {
                        new BarCategoryAxis
                        {
                            Stacked = true,
                            Ticks = new CategoryTicks
                            {
                                FontColor = ColorUtil.FromDrawingColor(Color.FromArgb(255, 99, 132, 1)),
                            }
                        }
                    },
                    YAxes = new List<CartesianAxis>
                    {
                        new BarLinearCartesianAxis
                        {
                            Ticks = new LinearCartesianTicks
                            {
                                BeginAtZero = true
                            }
                        }
                    }
                },
                Legend = new Legend
                {
                    Display = false,
                    Position = ChartEnums.Position.Top,
                    Labels = new LegendLabels
                    {
                        FontColor = ColorUtil.FromDrawingColor(Color.Black),
                        FontSize = 14
                    }
                },
                Responsive = true,
                AspectRatio = 3.5,
            },
        };
    }

    private void _loadDataOnChart()
    {
        _barChartConfig.Data.Labels.Clear();
        _barChartConfig.Data.Datasets.Clear();

        // Labels (Dates for start date to end date per 1 week)
        var weeklyDates = _getWeeklyDates(StartDate?.DateTime, EndDate).ToList();

        if (weeklyDates == null || !weeklyDates.Any())
        {
            return;
        }

        // Set X-axis Labels
        for (int i = 0; i < weeklyDates.Count - 1; i++)
        {
            var date = weeklyDates[i];
            var nextWeek = weeklyDates[i + 1];
            _barChartConfig.Data.Labels.Add(date.ToEuropeFormat());
        }

        // Create a list of datasets, one for each project
        var datasets = new List<BarDataset<double>>();

        // Initialize datasets for each project
        foreach (var report in reportEntries)
        {
            var color = _getRandomColor();
            var dataset = new BarDataset<double>(new double[weeklyDates.Count - 1])
            {
                Label = $"{report.Project.Name}",
                BackgroundColor = new IndexableOption<string>(color.Item1.ToHexaString()),
                BorderColor = new IndexableOption<string>(color.Item2.ToHexaString()),
                BorderWidth = 1,
            };
            datasets.Add(dataset);
        }

        // Assign the project data to the appropriate weekly bucket
        foreach (var report in reportEntries)
        {
            var createdDate = report.Project.CreatedDate;
            for (int i = 0; i < weeklyDates.Count - 1; i++)
            {
                var startDate = weeklyDates[i];
                var endDate = weeklyDates[i + 1];
                if (createdDate >= startDate && createdDate < endDate)
                {
                    // Add the worked time in ticks to the appropriate week for the current project
                    var index = datasets.FindIndex(ds => ds.Label == $"{report.Project.Name}");
                    if (index >= 0)
                    {
                        datasets[index].AddValue(i, report.TotalWorkedTime.TotalHours);
                    }
                    break;
                }
            }
        }

        // Add all datasets to the chart configuration
        foreach (var dataset in datasets)
        {
            _barChartConfig.Data.Datasets.Add(dataset);
        }

        // Ensure datasets are added properly
        _barChartConfig.Data.Datasets.Reverse();
    }
    #endregion

    #region Get Records
    private async Task _refreshData()
    {
        await _getClients();
        await _getProjectCategories();
        //await _getProjectSubCategories();
        //await _getProjects();
    }

    private async Task _getClients()
    {
        var dtos = await _dataProvider.Clients.GetAll();
        var vms = _mapper.Map<List<ClientVM>>(dtos);
        _clients.Clear();
        vms.ForEach(_clients.Add);
    }

    private async Task _getProjectCategories()
    {
        var dtos = await _dataProvider.ProjectsCategories.GetAll();
        var vms = _mapper.Map<List<ProjectCategoryVM>>(dtos);
        _projectCategories.Clear();
        vms.ForEach(_projectCategories.Add);
    }

    private async Task _getProjectSubCategories()
    {
        if (ProjectCategory == null) return;
        var dtos = await _dataProvider.ProjectsSubCategories.GetAll(ProjectCategory.Id);
        var vms = _mapper.Map<List<ProjectSubCategoryVM>>(dtos);
        _projectSubCategories.Clear();
        vms.ForEach(_projectSubCategories.Add);
    }

    private async Task _getReportData()
    {
        var clientDto = _mapper.Map<ClientDto>(Client);
        var categoryDto = _mapper.Map<ProjectCategoryDto>(ProjectCategory);
        var subCategoryDto = _mapper.Map<ProjectSubCategoryDto>(ProjectSubCategory);
        var data = await _dataProvider.Reports.GetProjectPerEmployeeReport(StartDate?.Date, EndDate?.Date, clientDto, categoryDto, subCategoryDto);
        reportEntries = data;
        _loadDataOnChart();
    }
    #endregion

    #region Client Filter
    private List<ClientVM> _clients = new List<ClientVM>();

    private ClientVM _client = new ClientVM();
    public ClientVM Client
    {
        get => _client;
        set
        {
            if (_client == value || value == null) return;
            _client = value;
        }
    }

    private async Task _onClientSelected(ClientVM obj)
    {
        Client = obj;

        await _getReportData();
    }
    #endregion

    #region Project Category Filter
    private List<ProjectCategoryVM> _projectCategories = new List<ProjectCategoryVM>();

    private ProjectCategoryVM _projectCategoryVM = new ProjectCategoryVM();
    public ProjectCategoryVM ProjectCategory
    {
        get => _projectCategoryVM;
        set
        {
            if (_projectCategoryVM == value || value == null) return;
            _projectCategoryVM = value;
        }
    }

    private async Task _onCategorySelected(ProjectCategoryVM obj)
    {
        ProjectCategory = obj;
        await _getProjectSubCategories();
        var firstSubCategory = _projectSubCategories.FirstOrDefault();
        subCategoryCombo.SelectedOption = firstSubCategory;
        subCategoryCombo.Value = firstSubCategory.Name;

        await _getReportData();
    }
    #endregion

    #region Project SubCategory Filter
    private Fluent.FluentCombobox<ProjectSubCategoryVM> subCategoryCombo;
    private List<ProjectSubCategoryVM> _projectSubCategories = new List<ProjectSubCategoryVM>();

    private ProjectSubCategoryVM _projectSubCategory = new ProjectSubCategoryVM();
    public ProjectSubCategoryVM ProjectSubCategory
    {
        get => _projectSubCategory;
        set
        {
            if (_projectSubCategory == value || value == null) return;
            _projectSubCategory = value;
        }
    }

    private async Task _onSubCategorySelected(ProjectSubCategoryVM obj)
    {
        ProjectSubCategory = obj;
        await _getReportData();
    }
    #endregion

    #region Date Range Filter
    DateTimeOffset? StartDate { get; set; } = null;
    DateTimeOffset? EndDate { get; set; } = null;

    public async Task OnDateSelect(DateRange range)
    {
        //var startDate = range.Start.DateTime;
        //var endDate = range.End.DateTime;
        await _getReportData();
    }
    #endregion

    #region Data Table
    private string _filterString = string.Empty;
    IQueryable<ReportProjectReturnModel>? FilteredItems => reportEntries?.AsQueryable().Where(x => x.Project.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 5 };

    private void HandleFilter(ChangeEventArgs args)
    {
        if (args.Value is string value)
        {
            _filterString = value;
        }
        else if (string.IsNullOrWhiteSpace(_filterString) || string.IsNullOrEmpty(_filterString))
        {
            _filterString = string.Empty;
        }
    }

    private ReportProjectReturnModel _selectedRecord = new ReportProjectReturnModel();
    private void HandleRowFocus(FluentDataGridRow<ReportProjectReturnModel> row)
    {
        _selectedRecord = row.Item as ReportProjectReturnModel;
    }
    #endregion

    #region Export As Pdf
    private bool exporting = false;

    private async Task _exportToPdf()
    {
        exporting = true;
        StateHasChanged();
        await Task.Delay(1000);

        try
        {
            string[] divsIds = new string[] { "export-to-pdf-projects-report-chart", "export-to-pdf-projects-report-table" };
            string fileName = $"Projects-Reports-{DateTime.Now.ToEuropeFormat()}.pdf";

            await MicrosoftTeams.ExportPdfContent(divsIds, fileName);
        }
        catch (Exception ex)
        {
            _logger.LogError($"\n\nException in Reports.razor.cs: {ex.Message}.\nInner: {ex.InnerException?.Message}.\n\n");
        }
        finally
        {
            await Task.Delay(1000);
            exporting = false;
            StateHasChanged();
        }
    }
    #endregion

    // Divide Timespan to weeks and return list of weeks
    public static IEnumerable<DateTime> _getWeeklyDates(DateTimeOffset? start, DateTimeOffset? end)
    {
        if (start != null || end == null)
        {
            end = DateTime.Now;
        }
        else if (start == null || end != null)
        {
            start = DateTime.Now.AddMonths(-1);
        }
        else
        {
            end = DateTime.Now;
            start = DateTime.Now.AddMonths(-1);
        }

        DateTime current = start?.DateTime ?? DateTime.Now.AddMonths(-1);

        while (current <= end)
        {
            yield return current;
            current = current.AddDays(7); // Move to the next week
        }
    }

    // Find the index (possition) of a date in date array span
    private int _getWeekIndex(DateTime date, List<DateTime> weeklyDates)
    {
        for (int i = 0; i < weeklyDates.Count - 1; i++)
        {
            if (date >= weeklyDates[i] && date < weeklyDates[i + 1])
            {
                return i;
            }
        }
        return -1;
    }

    private (Color, Color) _getRandomColor()
    {
        var r = _random.Next(256);
        var g = _random.Next(256);
        var b = _random.Next(256);

        var bodyColor = Color.FromArgb(255, r, g, b);
        var borderColor = Color.FromArgb(r, g, b);

        return (bodyColor, borderColor);
    }
}
