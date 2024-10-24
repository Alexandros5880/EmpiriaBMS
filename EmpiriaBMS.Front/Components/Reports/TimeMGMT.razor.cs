﻿using BlazorBootstrap;
using BlazorDateRangePicker;
using Chart = ChartJs.Blazor.Chart;
using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.BarChart.Axes;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Common.Axes.Ticks;
using ChartJs.Blazor.Common.Enums;
using ChartJs.Blazor.Util;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.ReturnModels;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions;
using ChartEnums = ChartJs.Blazor.Common.Enums;
using Color = System.Drawing.Color;
using Fluent = Microsoft.Fast.Components.FluentUI;
using EmpiriaBMS.Front.Components.General;
using System;
using System.Drawing;
using EmpiriaBMS.Front.Horizontal;
using Newtonsoft.Json.Linq;

namespace EmpiriaBMS.Front.Components.Reports;

public partial class TimeMGMT
{
    #region Authorization Properties
    bool canChangeEverybodyHours => _sharedAuthData.Permissions.Any(p => p.Ord == 37);
    #endregion

    private bool _loading = true;

    private static Random _random = new Random();

    private List<ReportProjectReturnModel> reportEntries = new();
    private BarConfig _barChartConfig;
    private Chart _chartInstance;
    private double? _chartAspectRatio = null;
    private double _maxYValue = 100;
    private List<string> _labels = new List<string>();
    private List<BarDataset<double>> _datasets = new List<BarDataset<double>>();

    protected override async Task OnInitializedAsync()
    {
        await _getAspectRatio();
        _initializeChart();
        await base.OnInitializedAsync();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _refreshData();
            await _getReportData();
            await RefreshChart();
            _loading = false;
            StateHasChanged();
        }
    }

    public async Task Refresh()
    {
        _loading = true;
        StateHasChanged();
        await _getReportData();
        await RefreshChart();
        _loading = false;
        StateHasChanged();
    }

    #region Change Hours Dialog
    private FluentDialog _changeHoursDialog;
    private bool _isChangeHoursDialogOdepened = false;

    private void _openChangeHoursDialog()
    {
        if (_changeHoursDialog.Hidden)
        {
            _changeHoursDialog.Show();
            _isChangeHoursDialogOdepened = true;
        }
    }

    private void _closeChangeHoursDialog()
    {
        if (!_changeHoursDialog.Hidden)
        {
            _changeHoursDialog.Hide();
            _isChangeHoursDialogOdepened = false;
        } 
    }
    #endregion

    #region Initialize Chart
    private void _initializeChart(double maxHours = 100)
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
                                Max = "100000"
                            }
                        }
                    },
                    YAxes = new List<CartesianAxis>
                    {
                        new BarLinearCartesianAxis
                        {
                            Stacked = true,
                            Ticks = new LinearCartesianTicks
                            {
                                BeginAtZero = true,
                                Max = maxHours
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
                AspectRatio = _chartAspectRatio ?? 3.5,
            },
        };
    }

    private void _updateYAxisMax()
    {
        if (_chartInstance != null)
        {
            // Update the Y-axis max value
            var yAxis = _barChartConfig.Options.Scales.YAxes.OfType<BarLinearCartesianAxis>().FirstOrDefault();
            if (yAxis != null)
            {
                yAxis.Ticks.Max = _maxYValue;
                // Reassign the updated config to the chart
                _chartInstance.Config = _barChartConfig;
                _chartInstance.Update();  // Refresh the chart
            }
        }
    }

    private void _updateAspectRatio()
    {
        if (_chartInstance != null)
        {
            // Update the Aspect Ratio
            var options = _barChartConfig.Options;
            if (options != null)
            {
                options.AspectRatio = _chartAspectRatio;
                // Reassign the updated config to the chart
                _chartInstance.Config = _barChartConfig;
                _chartInstance.Update();  // Refresh the chart
            }
        }
    }

    private void _prepaireDataForChart()
    {
        _labels.Clear();
        _datasets.Clear();

        // Labels (Dates for start date to end date per 1 week)
        var weeklyDates = _getWeeklyDates(StartDate, EndDate).ToList();

        if (weeklyDates == null || !weeklyDates.Any())
            return;

        // Set X-axis Labels
        foreach(var week in weeklyDates)
        {
            var startDate = week.Start.DateTime;
            var endDate = week.End.DateTime;
            _labels.Add($"{startDate.ToEuropeFormat()}-{endDate.ToEuropeFormat()}");
        }

        var totalHoursPerWeek = new double[weeklyDates.Count];

        // Initialize datasets for each project
        foreach (var report in reportEntries)
        {
            var dataset = new BarDataset<double>(new double[weeklyDates.Count])
            {
                Label = $"Name: {report.Project.Name}   Date: {report.Project.CreatedDate.ToEuropeFormat()}   Hours",
                BackgroundColor = ChartJsHelper.GenerateColors(reportEntries.Count(), 0.5),
                BorderWidth = 0,
                HoverBackgroundColor = ChartJsHelper.GetPreviusRgb(0.7),
                HoverBorderColor = ChartJsHelper.GetPreviusRgb(1),
                HoverBorderWidth = 1,
                BorderColor = ChartJsHelper.GetPreviusRgb(1),
                BarPercentage = 0.5,
            };

            var createdDate = report.Project.CreatedDate;
            var weekCounter = 0;
            foreach (var week in weeklyDates)
            {
                var startDate = week.Start.DateTime;
                var endDate = week.End.DateTime;

                int startDateResult = DateTime.Compare(createdDate, startDate);
                int endDateResult = DateTime.Compare(createdDate, endDate);

                if (startDateResult >= 0 && endDateResult <= 0)
                {
                    var hours = report.TotalWorkedTime.TotalHours;
                    totalHoursPerWeek[weekCounter] += hours;
                    dataset.AddValue(weekCounter, hours);
                    break;
                }

                weekCounter++;
            }

            _datasets.Add(dataset);
        }

        // Add the total hours dataset to the chart
        var totalDataset = new BarDataset<double>(totalHoursPerWeek)
        {
            Label = "Total Hours",
            BackgroundColor = new IndexableOption<string>(Color.LightGray.ToHexString()),
            BorderColor = new IndexableOption<string>(Color.Gray.ToHexString()),
            BorderWidth = 2,
            Stack = "Total",
            BarThickness = 12
        };

        _datasets.Add(totalDataset);

        // Find the week with the largest sum
        var max = totalHoursPerWeek.Max();
        _maxYValue = max + (max)/4;
    }

    private void _loadDataOnChart()
    {
        // Update Bar Labers And Datasets
        _barChartConfig.Data.Labels.Clear();
        _barChartConfig.Data.Datasets.Clear();
        _labels.ForEach(_barChartConfig.Data.Labels.Add);
        _datasets.ForEach(_barChartConfig.Data.Datasets.Add);

        // Ensure datasets are added properly
        _barChartConfig.Data.Datasets.Reverse();

        // Refresh chart
        _chartInstance.Update();
    }

    public async Task RefreshChart() {
        await _getAspectRatio();
        _updateAspectRatio();
        _prepaireDataForChart();
        _updateYAxisMax();
        _loadDataOnChart();
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
    }
    #endregion

    #region Client Filter
    private List<ClientVM> _clients = new List<ClientVM>();

    private ClientVM _client = null;
    public ClientVM Client
    {
        get => _client;
        set
        {
            if (_client == value) return;
            _client = value;
        }
    }

    private async Task _onClientSelected(ClientVM obj)
    {
        Client = obj;
        await Refresh();
    }
    #endregion

    #region Project Category Filter
    private List<ProjectCategoryVM> _projectCategories = new List<ProjectCategoryVM>();

    private ProjectCategoryVM _projectCategoryVM = null;
    public ProjectCategoryVM ProjectCategory
    {
        get => _projectCategoryVM;
        set
        {
            if (_projectCategoryVM == value) return;
            _projectCategoryVM = value;
        }
    }

    private async Task _onCategorySelected(ProjectCategoryVM obj)
    {
        ProjectCategory = obj;
        if (obj != null)
            await _getProjectSubCategories();

        subCategoryCombo.SelectedOption = null;
        subCategoryCombo.Value = string.Empty;
        ProjectSubCategory = null;

        await Refresh();
    }
    #endregion

    #region Project SubCategory Filter
    private Fluent.FluentCombobox<ProjectSubCategoryVM> subCategoryCombo;
    private List<ProjectSubCategoryVM> _projectSubCategories = new List<ProjectSubCategoryVM>();

    private ProjectSubCategoryVM _projectSubCategory = null;
    public ProjectSubCategoryVM ProjectSubCategory
    {
        get => _projectSubCategory;
        set
        {
            if (_projectSubCategory == value) return;
            _projectSubCategory = value;
        }
    }

    private async Task _onSubCategorySelected(ProjectSubCategoryVM obj)
    {
        ProjectSubCategory = obj;
        await Refresh();
    }
    #endregion

    #region Date Range Filter
    DateTimeOffset? StartDate { get; set; } = new DateTimeOffset(DateTime.Parse("7-1-2024"));
    DateTimeOffset? EndDate { get; set; } = new DateTimeOffset(DateTime.Parse("10-1-2024"));

    public async Task OnDateSelect(DateRange range)
    {
        if (StartDate.HasValue && EndDate.HasValue)
        {
            StartDate = range.Start;
            EndDate = range.End;
            await Refresh();
        }
    }
    #endregion

    #region Data Table
    private string _filterString = string.Empty;
    IQueryable<ReportProjectReturnModel>? FilteredItems => reportEntries?.AsQueryable()
        .Where(x => 
        x.Project.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase)
        && x.TotalWorkedTime.TotalHours > 0);
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
    public static IEnumerable<DateRange> _getWeeklyDates(DateTimeOffset? start, DateTimeOffset? end)
    {
        if (start != null && end == null)
        {
            end = DateTime.Now;
        }
        else if (start == null && end != null)
        {
            start = DateTime.Now.AddMonths(-1);
        }
        else if (start == null && end == null)
        {
            end = DateTime.Now;
            start = DateTime.Now.AddMonths(-1);
        }

        DateTime current = ((DateTimeOffset)start).Date;
        DateTime finished = ((DateTimeOffset)end).Date;
        int dayesToAppend = 7;

        while (current <= finished && dayesToAppend != 0)
        {
            int remaining = (finished - current).Days;
            dayesToAppend = remaining >= 7 ? 7 : remaining;
            DateRange range = new DateRange()
            {
                Start = current == ((DateTimeOffset)start).Date ? current : current.AddDays(1),
                End = current.AddDays(dayesToAppend),
            };
            yield return range;
            current = current.AddDays(dayesToAppend);
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

    private async Task _getAspectRatio()
    {
        var screeenAspectRatio = await MicrosoftTeams.GetAspectRatio();
        _chartAspectRatio = screeenAspectRatio * 2;
    }
}
