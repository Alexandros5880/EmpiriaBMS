using BlazorDateRangePicker;
using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.BarChart.Axes;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Common.Axes.Ticks;
using ChartJs.Blazor.Util;
using EmpiriaBMS.Front.ViewModel.Components;
using System.Drawing;
using ChartEnums = ChartJs.Blazor.Common.Enums;
using Fluent = Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Reports;

public partial class Reports
{

    #region For Development
    private List<ReportEntry> reportEntries = new()
    {
        new ReportEntry { ProjectName = "General Services", Date = new DateTime(2024, 7, 24), Hours = 8 },
        new ReportEntry { ProjectName = "General Services", Date = new DateTime(2024, 7, 25), Hours = 9 },
        new ReportEntry { ProjectName = "General Services", Date = new DateTime(2024, 7, 26), Hours = 7 },
        new ReportEntry { ProjectName = "General Services", Date = new DateTime(2024, 7, 27), Hours = 6 }
    };

    public class ReportEntry
    {
        public string ProjectName { get; set; }
        public DateTime Date { get; set; }
        public double Hours { get; set; }
    }
    #endregion



    private BarConfig _barChartConfig;

    protected override void OnInitialized()
    {
        base.OnInitializedAsync();
        InitializeChart();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _refreshData();
            LoadDataOnChart();
            StateHasChanged();
        }
    }

    #region Initialize Chart
    private void InitializeChart()
    {
        _barChartConfig = new BarConfig
        {
            Options = new BarOptions
            {
                Title = new OptionsTitle
                {
                    Display = true,
                    Text = "Projects Profit",
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
                            Stacked = true,
                            Ticks = new LinearCartesianTicks
                            {
                                BeginAtZero = true
                            }
                        }
                    }
                },
                Responsive = true,
                AspectRatio = 3.5,
            }
        };
    }

    private void LoadDataOnChart()
    {
        // Labels (Dates for start date to end date per 1 week)
        List<string> dates = new List<string> { "Jul 24", "Jul 25", "Jul 26", "Jul 27" };
        foreach (var date in dates)
        {
            _barChartConfig.Data.Labels.Add(date);
        }

        // Dataset Labes are Projects.Client.CompanyName
        // Dataset Values are Client.Projects.Invoices.Payments.Sum
        var dataset1 = new BarDataset<int>(new List<int> { 10, 20, 30 })
        {
            Label = "dataset1",
            BackgroundColor = new IndexableOption<string>(ColorUtil.FromDrawingColor(Color.LightSkyBlue)),
            BorderColor = new IndexableOption<string>(ColorUtil.FromDrawingColor(Color.SkyBlue)),
            BorderWidth = 1
        };
        _barChartConfig.Data.Datasets.Add(dataset1);

        var dataset2 = new BarDataset<int>(new List<int> { 8, 9, 7, 6 })
        {
            Label = "dataset2",
            BackgroundColor = new IndexableOption<string>(ColorUtil.FromDrawingColor(Color.LightSeaGreen)),
            BorderColor = new IndexableOption<string>(ColorUtil.FromDrawingColor(Color.SeaGreen)),
            BorderWidth = 1
        };
        _barChartConfig.Data.Datasets.Add(dataset2);
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

    private async Task _getProjects()
    {
        var dtos = await _dataProvider.Projects.GetAll();
        var vms = _mapper.Map<List<ProjectVM>>(dtos);
        _projects.Clear();
        vms.ForEach(_projects.Add);
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
        await _refreshData();
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
        await _refreshData();
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
        await _getProjects();
        var firatProject = _projects.FirstOrDefault();
        projectCombo.SelectedOption = firatProject;
        projectCombo.Value = firatProject.Name;
        await _refreshData();
    }
    #endregion

    #region Project Filter
    private Fluent.FluentCombobox<ProjectVM> projectCombo;
    private List<ProjectVM> _projects = new List<ProjectVM>();

    private ProjectVM _project = new ProjectVM();
    public ProjectVM Project
    {
        get => _project;
        set
        {
            if (_project == value || value == null) return;
            _project = value;
        }
    }

    private async Task _onProjectSelected(ProjectVM obj)
    {
        Project = obj;
        await _refreshData();
    }
    #endregion

    #region Date Range Filter
    DateTimeOffset? StartDate { get; set; } = null;
    DateTimeOffset? EndDate { get; set; } = null;

    public async Task OnDateSelect(DateRange range)
    {
        await _refreshData();
    }
    #endregion
}
