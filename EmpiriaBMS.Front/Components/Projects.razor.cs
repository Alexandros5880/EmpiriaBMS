using EmpiriaBMS.Core;
using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.ReturnModels;
using EmpiriaBMS.Front.DefaultComponents;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.DefaultComponents;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using Microsoft.Graph.Models;
using Microsoft.JSInterop;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;

namespace EmpiriaBMS.Front.Components;
public partial class Projects : IDisposable
{

    // Auth Models
    [Parameter]
    public UserVM LogedUser { get; set; }
    [Parameter]
    public double LogesUserHours { get; set; } = 0;
    [Parameter]
    public ICollection<RoleVM> LoggedUserRoles { get; set; }

    // General Fields
    private bool disposedValue;
    bool _runInTeams = false;
    bool _authenticated = false;
    bool _startLoading = true;
    bool _filterLoading = false;

    // Visibility Properties
    public bool EditDrawing {
        get
        {
            return isWorkingMode && LoggedUserRoles.Select(r => r.Name).ToList().Contains("Engineer");
        }
    }
    public bool EditDiscipline
    {
        get
        {
            return isWorkingMode && LoggedUserRoles.Select(r => r.Name).ToList().Contains("Project Manager");
        }
    }
    public bool EditProject
    {
        get
        {
            return isWorkingMode && (LoggedUserRoles.Select(r => r.Name).ToList().Contains("CTO")
                                 || LoggedUserRoles.Select(r => r.Name).ToList().Contains("COO")
                                 || LoggedUserRoles.Select(r => r.Name).ToList().Contains("CEO"));
        }
    }

    // Working Timer
    Timer timer;
    DateTime StartWorkTime = DateTime.Now;
    bool isWorkingMode = false;
    TimeSpan timePassed = TimeSpan.Zero;
    TimeSpan timePaused = TimeSpan.Zero;
    TimeSpan remainingTime = TimeSpan.Zero;

    public string CurentDate => $"{DateTime.Today.Day}/{DateTime.Today.Month}/{DateTime.Today.Year}";

    // List
    private ObservableCollection<ProjectVM> _projects = new ObservableCollection<ProjectVM>();
    private ObservableCollection<DisciplineVM> _disciplines = new ObservableCollection<DisciplineVM>();
    private ObservableCollection<DrawingVM> _draws = new ObservableCollection<DrawingVM>();
    private ObservableCollection<OtherVM> _others = new ObservableCollection<OtherVM>();
    private List<DisciplineVM> _disciplinesChanged = new List<DisciplineVM>();
    private List<DrawingVM> _drawsChanged = new List<DrawingVM>();
    private List<OtherVM> _othersChanged = new List<OtherVM>();
    private ObservableCollection<UserVM> _designers = new ObservableCollection<UserVM>();
    private ObservableCollection<UserVM> _engineers = new ObservableCollection<UserVM>();
    private ObservableCollection<UserVM> _projectManagers = new ObservableCollection<UserVM>();

    // Selected Models
    private ProjectVM _selectedProject = new ProjectVM();
    private DisciplineVM _selectedDiscipline = new DisciplineVM();
    private DrawingVM _selectedDraw = new DrawingVM();
    private OtherVM _selectedOther = new OtherVM();

    // Paginator
    private PaginatorVM _paginator = new PaginatorVM(7);

    // Work End Dialog
    private FluentDialog? _endWorkDialog;
    private bool _isEndWorkDialogOdepened = false;

    // Add Designer Dialog
    private FluentDialog? _addDesignerDialog;
    private bool _isAddDesignerDialogOdepened = false;

    // Add Engineer Dialog
    private FluentDialog? _addEngineerDialog;
    private bool _isAddEngineerDialogOdepened = false;

    // Add ProjectManager Dialog
    private FluentDialog? _addPMDialog;
    private bool _isAddPMDialogOdepened = false;

    protected override async void OnInitialized()
    {
        base.OnInitialized();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _runInTeams = await MicrosoftTeams.IsInTeams();

            await _getProjects();
            _startLoading = false;
            StateHasChanged();
        }
    }

    public async Task Refresh()
    {
        _startLoading = true;
        await _getProjects();
        _startLoading = false;
        StateHasChanged();
    }

    #region Get Records
    public async Task _getProjects()
    {
        _selectedProject = null;
        _selectedDiscipline = null;
        _selectedDraw = null;
        _selectedOther = null;
        _disciplines.Clear();
        _draws.Clear();
        _others.Clear();

        _filterLoading = !_startLoading ? true : _filterLoading;
        try
        {
            // Todo: Find a way to add this in to PaginatorVM
            //_paginator.SetRecordsLength(await DataProvider.Projects.Count());

            // TODO: Get My Project And Down
            //List<ProjectDto> projectsDto = (await DataProvider.Projects.GetAll(LogedUser.Id, _paginator.PageSize, _paginator.PageIndex))
            //                                                           .ToList<ProjectDto>();
            List<ProjectDto> projectsDto = (await DataProvider.Projects.GetAll(LogedUser.Id)).ToList<ProjectDto>();


            var projectsVm = Mapper.Map<List<ProjectDto>, List<ProjectVM>>(projectsDto);

            _projects.Clear();
            projectsVm.ForEach(_projects.Add);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
        _startLoading = false;
        _filterLoading = !_startLoading ? false : _filterLoading;
    }

    private async Task _getDesigners()
    {
        try
        {
            var defaultRoleId = await GetRoleId("Designer");
            if (defaultRoleId == 0)
                throw new Exception("Exception `Designer` role not exists!");

            var disigners = await DataProvider.Roles.GetUsers(defaultRoleId);

            if (disigners == null)
                throw new NullReferenceException(nameof(disigners));

            var myDesignersIds = (await DataProvider.Drawings.GetDesigners(_selectedDraw.Id)).Select(d => d.Id);

            var disignersVM = Mapper.Map<List<UserVM>>(disigners);
            _designers.Clear();
            disignersVM.ForEach(d =>
            {
                d.IsSelected = myDesignersIds.Contains(d.Id);
                _designers.Add(d);
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
    }

    private async Task _getEngineers()
    {
        try
        {
            var defaultRoleId = await GetRoleId("Engineer");
            if (defaultRoleId == 0)
                throw new Exception("Exception `Engineer` role not exists!");

            var engineers = await DataProvider.Roles.GetUsers(defaultRoleId);

            if (engineers == null)
                throw new NullReferenceException(nameof(engineers));

            var myEngineersIds = (await DataProvider.Disciplines.GetEngineers(_selectedDiscipline.Id)).Select(d => d.Id);

            var engineersVM = Mapper.Map<List<UserVM>>(engineers);
            _engineers.Clear();
            engineersVM.ForEach(d =>
            {
                d.IsSelected = myEngineersIds.Contains(d.Id);
                _engineers.Add(d);
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
    }

    private async Task _getProjectManagers()
    {
        try
        {
            var defaultRoleId = await GetRoleId("Project Manager");
            if (defaultRoleId == 0)
                throw new Exception("Exception `Project Manager` role not exists!");

            var pms = await DataProvider.Roles.GetUsers(defaultRoleId);

            if (pms == null)
                throw new NullReferenceException(nameof(pms));

            var myPmsIds = (await DataProvider.Projects.GetProjectManagers(_selectedProject.Id)).Select(d => d.Id);

            var pmsVM = Mapper.Map<List<UserVM>>(pms);
            _projectManagers.Clear();
            pmsVM.ForEach(d =>
            {
                d.IsSelected = myPmsIds.Contains(d.Id);
                _projectManagers.Add(d);
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
    }

    private async Task<int> GetRoleId(string roleName)
    {
        try
        {
            var role = await DataProvider.Roles.Get(roleName);
            return role?.Id ?? 0;
        }
        catch (Exception ex)
        {
            // TODO: Log Error
            Debug.WriteLine($"Exception: {ex.Message}");
            return 0;
        }
    }

    private long GetProjectMenHours(int projecId) =>
        DataProvider.Projects.GetMenHours(projecId);

    private long GetDisciplineMenHours(int disciplineId) =>
        DataProvider.Disciplines.GetMenHours(disciplineId);

    private long GetDrawingMenHours(int drawingId) =>
        DataProvider.Drawings.GetMenHours(drawingId);

    private long GetOtherMenHours(int otherId) =>
        DataProvider.Others.GetMenHours(otherId);
    #endregion

    #region Actions Functions
    private void StartWorkClick()
    {
        isWorkingMode = true;
        StartTimer();
        StateHasChanged();
    }

    private void StopWorkClick()
    {
        isWorkingMode = false;
        StopTimer();

        remainingTime = timePaused;

        _others.Clear();
        _draws.Clear();
        _disciplines.Clear();
        _selectedOther = null;
        _selectedDraw = null;
        _selectedDiscipline = null;
        _selectedProject = null;
        StateHasChanged();

        _endWorkDialog.Show();
        _isEndWorkDialogOdepened = true;
    }

    private async Task OnSelectProject(int projectId)
    {
        if (projectId == 0 || projectId == _selectedProject?.Id) return;

        var project = _projects.FirstOrDefault(p => p.Id == projectId);
        _draws.Clear();
        _others.Clear();
        _disciplines.Clear();
        _selectedProject = project;
        _selectedDiscipline = null;
        _selectedDraw = null;
        _selectedOther = null;

        var getAll = LoggedUserRoles.Select(r => r.Name).ToList().Contains("Engineer")
                     || LoggedUserRoles.Select(r => r.Name).ToList().Contains("COO")
                     || LoggedUserRoles.Select(r => r.Name).ToList().Contains("Project Manager")
                     || LoggedUserRoles.Select(r => r.Name).ToList().Contains("CEO")
                     || LoggedUserRoles.Select(r => r.Name).ToList().Contains("CTO");

        var disciplines = await DataProvider.Projects.GetDisciplines(project.Id, LogedUser.Id, getAll);

        _disciplines.Clear();
        foreach (var di in disciplines)
            _disciplines.Add(Mapper.Map<DisciplineVM>(di));

        StateHasChanged();
    }

    private async Task OnSelectDiscipline(int disciplineId)
    {
        if (disciplineId == 0 || disciplineId == _selectedDiscipline?.Id) return;

        _selectedDiscipline = _disciplines.FirstOrDefault(d => d.Id == disciplineId);

        var draws = await DataProvider.Disciplines.GetDraws(_selectedDiscipline.Id);
        var others = await DataProvider.Disciplines.GetOthers(_selectedDiscipline.Id);

        _draws.Clear();
        foreach (var di in draws)
            _draws.Add(Mapper.Map<DrawingVM>(di));

        _others.Clear();
        foreach (var di in others)
            _others.Add(Mapper.Map<OtherVM>(di));

        StateHasChanged();
    }

    private void OnSelectDraw(DrawingVM draw)
    {
        if (draw == null || draw.Id == _selectedDraw?.Id) return;
        _selectedDraw = draw;
        StateHasChanged();
    }

    private void OnSelectDoc(OtherVM doc)
    {
        if (doc == null || doc.Id == _selectedOther?.Id) return;
        _selectedOther = doc;
        StateHasChanged();
    }

    private async Task OnDrawingAssignClick(DrawingVM draw)
    {
        if (!isWorkingMode) return;
        try
        {
            _selectedDraw = draw;
            await _getDesigners();
            StateHasChanged();
            _addDesignerDialog.Show();
            _isAddDesignerDialogOdepened = true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
    }

    private async Task OnDesciplineAssignClick(DisciplineVM discipline)
    {
        if (!isWorkingMode) return;
        try
        {
            _selectedDiscipline = discipline;
            await _getEngineers();
            StateHasChanged();
            _addEngineerDialog.Show();
            _isAddEngineerDialogOdepened = true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
    }

    private async Task OnProjectAssignClick(ProjectVM project)
    {
        if (!isWorkingMode) return;
        try
        {
            _selectedProject = project;
            await _getProjectManagers();
            StateHasChanged();
            _addPMDialog.Show();
            _isAddPMDialogOdepened = true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
    }
    #endregion

    #region Timer
    private async Task StartTimer()
    {
        // TODO: Projects Timer -> Change """ timePaused != TimeSpan.Zero ? DateTime.Now : DateTime.Now.AddHours(-7); """ TO """ DateTime.Now """
        StartWorkTime = timePaused != TimeSpan.Zero ? DateTime.Now : DateTime.Now.AddHours(-7).AddMinutes(-10);
        timer = new System.Threading.Timer((_) =>
        {
            timePassed = DateTime.Now - StartWorkTime;
            if (timePaused != TimeSpan.Zero)
                timePassed += timePaused;

            InvokeAsync(() =>
                {
                    StateHasChanged();
                });
        }, null, 0, 1000);
    }

    private void StopTimer()
    {
        timePaused = timePassed;
        timer.Dispose();
    }
    #endregion

    #region On Press Work End Dialog Actions
    private void _onDrawTimeChanged(DrawingVM draw, TimeSpan newTimeSpan)
    {
        // previusTime, updatedTime, remainingTime

        var previusTime = draw.Time;
        var hoursChanged = previusTime.Hours != newTimeSpan.Hours;
        var minutesChanged = previusTime.Minutes != newTimeSpan.Minutes;

        var updatedHours = hoursChanged ? 
                                          newTimeSpan.Hours < previusTime.Hours ? 
                                                          -(previusTime.Hours - newTimeSpan.Hours) 
                                                        : newTimeSpan.Hours 
                                        : 0;
        var updatedMinutes = minutesChanged ? 
                                          newTimeSpan.Minutes < previusTime.Minutes ?
                                                          -(previusTime.Minutes - newTimeSpan.Minutes)
                                                        : newTimeSpan.Minutes
                                        : 0;

        var updatedTime = new TimeSpan(updatedHours, updatedMinutes, 0);

        TimeSpan difference = remainingTime - updatedTime;
        if (difference < TimeSpan.Zero)
        {
            remainingTime += updatedTime;
        }
        else
        {
            remainingTime -= updatedTime;
        }

        draw.Time = newTimeSpan;

        if (_drawsChanged.Any(d => d.Id == draw.Id))
        {
            var d = _drawsChanged.FirstOrDefault(d => d.Id == draw.Id);
            d.Time = draw.Time;
        }
        else
            _drawsChanged.Add(draw);

        StateHasChanged();
    }

    private void _onDrawCompletedChanged(DrawingVM draw, object val)
    {
        draw.CompletionEstimation += Convert.ToInt32(val);

        if (_drawsChanged.Any(d => d.Id == draw.Id))
        {
            var d = _drawsChanged.FirstOrDefault(d => d.Id == draw.Id);
            d.CompletionEstimation = draw.CompletionEstimation;
        }
        else
            _drawsChanged.Add(draw);

        StateHasChanged();
    }

    private void _onOtherTimeChanged(OtherVM other, TimeSpan newTimeSpan)
    {
        // previusTime, updatedTime, remainingTime

        var previusTime = other.Time;
        var hoursChanged = previusTime.Hours != newTimeSpan.Hours;
        var minutesChanged = previusTime.Minutes != newTimeSpan.Minutes;

        var updatedHours = hoursChanged ?
                                          newTimeSpan.Hours < previusTime.Hours ?
                                                          -(previusTime.Hours - newTimeSpan.Hours)
                                                        : newTimeSpan.Hours
                                        : 0;
        var updatedMinutes = minutesChanged ?
                                          newTimeSpan.Minutes < previusTime.Minutes ?
                                                          -(previusTime.Minutes - newTimeSpan.Minutes)
                                                        : newTimeSpan.Minutes
                                        : 0;

        var updatedTime = new TimeSpan(updatedHours, updatedMinutes, 0);

        TimeSpan difference = remainingTime - updatedTime;
        if (difference < TimeSpan.Zero)
        {
            remainingTime += updatedTime;
        }
        else
        {
            remainingTime -= updatedTime;
        }

        other.Time = newTimeSpan;

        if (_othersChanged.Any(o => o.Id == other.Id))
        {
            var o = _othersChanged.FirstOrDefault(o => o.Id == other.Id);
            o.Time = other.Time;
        }
        else
            _othersChanged.Add(other);

        StateHasChanged();
    }

    public async Task _endWorkDialogAccept()
    {
        _endWorkDialog.Hide();
        _isEndWorkDialogOdepened = false;

        //if (remainingTime.Hours > 0)
        //{
        //    // TODO: Display a message to update his hours.
        //    return;
        //}

        //_startLoading = true;

        //// Update Draws
        //foreach (var draw in _drawsChanged)
        //{
        //    var old = _draws.FirstOrDefault(d => d.Id == draw.Id);
        //    if (old.CompletionEstimation > draw.CompletionEstimation)
        //    {
        //        //TODO: Display Msg

        //        return;
        //    }
        //    else
        //        await DataProvider.Drawings.UpdateCompleted(_selectedProject.Id, _selectedDiscipline.Id, draw.Id, draw.CompletionEstimation);
        //    await DataProvider.Drawings.UpdateHours(LogedUser.Id, _selectedProject.Id, _selectedDiscipline.Id, draw.Id, draw.MenHours);
        //}

        //// Update Others
        //foreach (var other in _othersChanged)
        //{
        //    //await DataProvider.Others.UpdateCompleted(_selectedProject.Id, _selectedDiscipline.Id, other.Id, other.CompletionEstimation);
        //    await DataProvider.Others.UpdateHours(LogedUser.Id, _selectedProject.Id, _selectedDiscipline.Id, other.Id, other.MenHours);
        //}

        //// Update User Hours
        //await DataProvider.Users.AddHours(LogedUser.Id, DateTime.Now, Convert.ToInt64(remainingTime.Hours));

        //_drawsChanged.Clear();
        //_othersChanged.Clear();

        //await _getProjects();

        //_startLoading = false;
    }

    public void _endWorkDialogCansel()
    {
        _drawsChanged.Clear();
        _othersChanged.Clear();
        StartWorkClick();
        _endWorkDialog.Hide();
        _isEndWorkDialogOdepened = false;
    }
    #endregion

    #region On Press Add Designer Dialog Actions
    public async Task _addDesignerDialogAccept()
    {
        _addDesignerDialog.Hide();
        _isAddDesignerDialogOdepened = false;

        _startLoading = true;

        var forDeleteIds = _designers.Where(d => d.IsSelected == null || d.IsSelected == false)
                                     .Select(d => d.Id)
                                     .ToList();
        await DataProvider.Drawings.RemoveDesigners(_selectedDraw.Id, forDeleteIds);

        var forAdd = _designers.Where(d => d.IsSelected == true).ToList();
        var forAddDto = Mapper.Map<List<UserDto>>(forAdd);
        await DataProvider.Drawings.AddDesigners(_selectedDraw.Id, forAddDto);

        _startLoading = false;
    }

    public void _addDesignerDialogCansel()
    {
        _addDesignerDialog.Hide();
        _isAddDesignerDialogOdepened = false;
    }
    #endregion

    #region On Press Add Engineer Dialog Actions
    public async Task _addEngineerDialogAccept()
    {
        _addEngineerDialog.Hide();
        _isAddEngineerDialogOdepened = false;

        _startLoading = true;

        var forDeleteIds = _engineers.Where(d => d.IsSelected == null || d.IsSelected == false)
                                     .Select(d => d.Id)
                                     .ToList();
        await DataProvider.Disciplines.RemoveEngineers(_selectedDiscipline.Id, forDeleteIds);

        var forAdd = _engineers.Where(d => d.IsSelected == true).ToList();
        var forAddDto = Mapper.Map<List<UserDto>>(forAdd);
        await DataProvider.Disciplines.AddEngineers(_selectedDiscipline.Id, forAddDto);

        _startLoading = false;
    }

    public void _addEngineerDialogCansel()
    {
        _addEngineerDialog.Hide();
        _isAddEngineerDialogOdepened = false;
    }
    #endregion

    #region On Press Add Project Manager Dialog Actions
    public async Task _addPMDialogAccept()
    {
        _addPMDialog.Hide();
        _isAddPMDialogOdepened = false;

        _startLoading = true;

        var forDeleteIds = _projectManagers.Where(d => d.IsSelected == null || d.IsSelected == false)
                                           .Select(d => d.Id)
                                     .ToList();
        await DataProvider.Projects.RemoveProjectManager(_selectedProject.Id, forDeleteIds);

        var forAdd = _projectManagers.Where(d => d.IsSelected == true).ToList();
        var forAddDto = Mapper.Map<List<UserDto>>(forAdd);
        await DataProvider.Projects.AddProjectManager(_selectedProject.Id, forAddDto);

        _startLoading = false;
    }

    public void _addPMDialogCansel()
    {
        _addPMDialog.Hide();
        _isAddPMDialogOdepened = false;
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
