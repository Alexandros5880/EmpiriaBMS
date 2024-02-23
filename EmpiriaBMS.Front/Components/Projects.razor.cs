using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.ReturnModels;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.DefaultComponents;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;
using Microsoft.Fast.Components.FluentUI;
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
    TimeSpan timePassed = TimeSpan.Zero;
    TimeSpan timePaused = TimeSpan.Zero;

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

    // Auth Models
    private UserVM _logedUser;
    private double _logesUserHours = 0;
    private ICollection<RoleVM> _loggedUserRoles = new List<RoleVM>();
    private bool _logesUserChanged = false;

    // Work End Dialog
    private FluentDialog? _endWorkDialog;
    private bool _isEndWorkDialogOdepened = false;

    protected override async void OnInitialized()
    {
        base.OnInitialized();
        await _getLogedUser();
        await _getProjects();
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

            _logesUserHours = await DataProvider.Users.GetUserHoursFromLastMonday(_logedUser.Id, DateTime.Now);

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

    #region Properties Changed Events
    private void ToogleWorkStatus(bool? start = null)
    {
        if (start != null)
            workStarted = (bool)start;
        else
            workStarted = !workStarted;

        if (workStarted)
        {
            StartTimer();
        } else
        {
            StopTimer();

            // TODO: Enable This
            //if (hoursPassed < 1) return;

            _endWorkDialog.Show();
            _isEndWorkDialogOdepened = true;
        }
    }

    private async Task OnSelectProject(int projectId)
    {
        if (projectId == 0) return;

        var project = _projects.FirstOrDefault(p => p.Id == projectId);
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

    private async Task OnSelectDiscipline(int disciplineId)
    {
        if (disciplineId == 0) return;

        var discipline = _disciplines.FirstOrDefault(d => d.Id == disciplineId);
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
    #endregion

    #region Async Jobs
    private async Task StartTimer()
    {
        // TODO: Remove "AddHours(-7)"
        StartWorkTime = DateTime.Now.AddHours(-7); //DateTime.Now;
        timer = new System.Threading.Timer((_) =>
        {
            timePassed = DateTime.Now - StartWorkTime;

        InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }, null, 0, 1000);
    }

    private void StopTimer()
    {
        timePassed = timePaused;
        timer.Dispose();
    }
    #endregion

    #region On Press Work End Dialog Actions
    private void _onDrawHoursChanged(DrawVM draw, object val)
    {
        var previusValue = draw.MenHours;
        var value = Convert.ToInt32(val) > previusValue ? Convert.ToInt32(val) - previusValue : -(previusValue - Convert.ToInt32(val));
        if (timePassed.Hours < value)
        {
            // TODO: Display a Msg
            return;
        }

        var updatedTimeSpan = new TimeSpan(timePassed.Days, timePassed.Hours - Convert.ToInt32(value), timePassed.Minutes, timePassed.Seconds);
        timePassed = updatedTimeSpan;
    }

    private void _onOtherHoursChanged(OtherVM other, object val)
    {
        var previusValue = other.MenHours;
        var value = Convert.ToInt32(val) > previusValue ? Convert.ToInt32(val) - previusValue : -(previusValue - Convert.ToInt32(val));
        if (timePassed.Hours < value)
        {
            // TODO: Display a Msg
            return;
        }

        var updatedTimeSpan = new TimeSpan(timePassed.Days, timePassed.Hours - Convert.ToInt32(value), timePassed.Minutes, timePassed.Seconds);
        timePassed = updatedTimeSpan;
    }

    public async Task _endWorkDialogAccept()
    {
        _endWorkDialog.Hide();
        _isEndWorkDialogOdepened = false;

        if (timePassed.Hours > 0)
        {
            // TODO: Display a message to update his hours.
            return;
        }

        await DataProvider.Users.AddHours(_logedUser.Id, DateTime.Now, Convert.ToInt64(timePassed.Hours));

        // TODO: Update all Records With User Hours

        await Task.Delay(2000);
    }

    public void _endWorkDialogCansel()
    {
        ToogleWorkStatus(true);
        _endWorkDialog.Hide();
        _isEndWorkDialogOdepened = false;
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
