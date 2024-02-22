using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.ReturnModels;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.DefaultComponents;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;

namespace EmpiriaBMS.Front.Components;
public partial class Projects: IDisposable
{
    private bool disposedValue;

    bool runInTeams = false;
    bool startLoading = true;
    bool filterLoading = false;

    // Working Timer
    Timer timer;
    DateTime StartWorkTime = DateTime.Now;
    bool workStarted = false;
    double hoursPaused = 0;
    double? hoursPassed = null;
    double? minutsPassed = 0;
    double? minutsPaused = 0;
    double hoursUsed = 0;

    public string CurentDate => $"{DateTime.Today.Day}/{DateTime.Today.Month}/{DateTime.Today.Year}";

    // List
    private ObservableCollection<ProjectVM> _projects = new ObservableCollection<ProjectVM>();
    private ObservableCollection<DisciplineVM> _disciplines = new ObservableCollection<DisciplineVM>();
    private ObservableCollection<DrawVM> _draws = new ObservableCollection<DrawVM>();
    private ObservableCollection<OtherVM> _others = new ObservableCollection<OtherVM>();

    // Selected Models
    private ProjectVM _selectedProject = new ProjectVM();
    private DisciplineVM _selectedDiscipline = new DisciplineVM();
    private DrawVM _selectedDraw = new DrawVM();
    private OtherVM _selectedOther = new OtherVM();

    // Paginator
    private PaginatorVM _paginator = new PaginatorVM(7);

    // Basic Models
    private UserVM _logedUser;
    private ICollection<RoleVM> _loggedUserRoles = new List<RoleVM>();
    private bool _logesUserChanged = false;

    protected override async void OnInitialized()
    {
        base.OnInitialized();
        await _getLogedUser();
        await _getProjects();
        hoursPassed = null;
        startLoading = false;
        StateHasChanged();
    }

    #region Get Records
    private async Task _getProjects()
    {
        _selectedProject = null;
        _selectedDiscipline = null;
        _selectedDraw = null;
        _selectedOther = null;
        _disciplines.Clear();
        _draws.Clear();
        _others.Clear();

        filterLoading = !startLoading ? true : filterLoading;
        try
        {
            // Todo: Find a way to add this in to PaginatorVM
            //_paginator.SetRecordsLength(await DataProvider.Projects.Count());

            // TODO: Get My Project And Down
            //List<ProjectDto> projectsDto = (await DataProvider.Projects.GetAll(_logedUser.Id, _paginator.PageSize, _paginator.PageIndex))
            //                                                           .ToList<ProjectDto>();
            List<ProjectDto> projectsDto = (await DataProvider.Projects.GetAll(_logedUser.Id)).ToList<ProjectDto>();


            var projectsVm = Mapper.Map<List<ProjectDto>, List<ProjectVM>>(projectsDto);

            _projects.Clear();
            projectsVm.ForEach(_projects.Add);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
        startLoading = false;
        filterLoading = !startLoading ? false : filterLoading;
    }

    private async Task _getLogedUser()
    {
        try
        {
            // TODO: Get Teams Loged User And Mach him With Oure Users

            var defaultRoleId = await GetProjectManagersRoleId("Draftsmen");
            if (defaultRoleId == 0)
                throw new Exception("Exception `Project Managers` role not exists!");

            var users = await DataProvider.Roles.GetUsers(defaultRoleId);
            var dbUser = users.FirstOrDefault();

            if (dbUser == null)
                throw new Exception("Exception user with `Draftsmen` role not exists!");

            _logedUser = Mapper.Map<UserVM>(dbUser);

            _loggedUserRoles = (await DataProvider.Roles.GetEmplyeeRoles(dbUser.Id))
                                                        .Select(r => Mapper.Map<RoleVM>(r))
                                                        .ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
    }

    private async Task<int> GetProjectManagersRoleId(string roleName)
    {
        try
        {
            return (await DataProvider.Roles.Get(roleName)).Id;
        }
        catch (Exception ex)
        {
            // TODO: Log Error
            Debug.WriteLine($"Exception: {ex.Message}");
            return 0;
        }
    }
    #endregion

    #region Properties Changed Evenets
    private void ToogleWorkStatus()
    {
        workStarted = !workStarted;

        if (workStarted)
        {
            StartTimer();
        } else
        {
            StopTimer();
        }
    }

    private async Task OnSelectProject(ProjectVM project)
    {
        _draws.Clear();
        _others.Clear();
        _disciplines.Clear();
        _selectedProject = project;
        _selectedDiscipline = null;
        _selectedDraw = null;
        _selectedOther = null;
        var disciplines = await DataProvider.Projects.GetDisciplines(project.Id);

        _disciplines.Clear();
        foreach (var di in disciplines)
            _disciplines.Add(Mapper.Map<DisciplineVM>(di));
        
        StateHasChanged();
    }

    private async Task OnSelectDiscipline(DisciplineVM discipline)
    {
        _selectedDiscipline = discipline;

        var draws = await DataProvider.Disciplines.GetDraws(discipline.Id);
        var others = await DataProvider.Disciplines.GetOthers(discipline.Id);
        await _getLogedUser();

        _draws.Clear();
        foreach (var di in draws)
            _draws.Add(Mapper.Map<DrawVM>(di));

        _others.Clear();
        foreach (var di in others)
            _others.Add(Mapper.Map<OtherVM>(di));

        StateHasChanged();
    }

    private void OnSelectDraw(DrawVM draw)
    {
        _selectedDraw = draw;
        StateHasChanged();
    }

    private void OnSelectDoc(OtherVM doc)
    {
        _selectedOther = doc;
        StateHasChanged();
    }
    
    private async Task _onDrawHoursChanged(DrawVM draw, object val)
    {
        var previusValue = draw.MenHours;
        var value = Convert.ToInt32(val) > previusValue ? Convert.ToInt32(val) - previusValue : -(previusValue - Convert.ToInt32(val));
        if ((hoursPassed - hoursUsed) < value)
        {
            // TODO: Display a Msg
            return;
        }

        _logedUser.Hours += value;
        //await DataProvider.Draws.UpdateHours(_selectedProject.Id, draw.Id, value);
    }

    private async Task _onOtherHoursChanged(OtherVM other, object val)
    {
        var previusValue = other.MenHours;
        var value = Convert.ToInt32(val) > previusValue ? Convert.ToInt32(val) - previusValue : -(previusValue - Convert.ToInt32(val));
        if ((hoursPassed - hoursUsed) < value)
        {
            // TODO: Display a Msg
            return;
        }

        _logedUser.Hours += value;
        //await DataProvider.Others.UpdateHours(_selectedProject.Id, other.Id, value);
    }
    #endregion

    #region Async Jobs
    private async Task StartTimer()
    {
        StartWorkTime = DateTime.Now;
        timer = new System.Threading.Timer((_) =>
        {
            var chrono = DateTime.Now - StartWorkTime;
            hoursPassed = chrono.Hours + hoursPaused;
            minutsPassed = chrono.Seconds + minutsPaused;

        InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }, null, 0, 1000);
    }

    private void StopTimer()
    {
        hoursPaused = (double)hoursPassed;
        minutsPaused = (double)minutsPassed;
        timer.Dispose();
    }
    #endregion

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {

            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
