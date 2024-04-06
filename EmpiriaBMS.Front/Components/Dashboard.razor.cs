using AutoMapper;
using EmpiriaBMS.Core;
using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.ReturnModels;
using EmpiriaBMS.Front.Components.Admin.Roles;
using EmpiriaBMS.Front.Horizontal;
using EmpiriaBMS.Front.Services;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.DefaultComponents;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.CodeAnalysis;
using Microsoft.Fast.Components.FluentUI;
using Microsoft.Graph.Models;
using Microsoft.JSInterop;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading;

namespace EmpiriaBMS.Front.Components;
public partial class Dashboard : IDisposable
{
    private UserTimes _editLogedUserTimes;

    #region Authorization Properties
    public bool AssignDesigner => _sharedAuthData.PermissionOrds.Contains(3);
    public bool AssignEngineer => _sharedAuthData.PermissionOrds.Contains(4);
    public bool AssignPm => _sharedAuthData.PermissionOrds.Contains(5);
    public bool EditMyHours => _sharedAuthData.PermissionOrds.Contains(2);
    public bool SeeMyHours => _sharedAuthData.PermissionOrds.Contains(8);
    bool getAllDisciplines => _sharedAuthData.Permissions.Any(p => p.Ord == 9);
    bool getAllDrawings => _sharedAuthData.Permissions.Any(p => p.Ord == 10);
    bool editProject => _sharedAuthData.Permissions.Any(p => p.Ord == 12);
    bool editDiscipline => _sharedAuthData.Permissions.Any(p => p.Ord == 14);
    bool editDeliverable => _sharedAuthData.Permissions.Any(p => p.Ord == 15);
    bool editOther => _sharedAuthData.Permissions.Any(p => p.Ord == 16);
    bool seeKpis => _sharedAuthData.Permissions.Any(p => p.Ord == 17);
    #endregion

    // General Fields
    private bool disposedValue;
    bool _startLoading = true;
    private double _userTotalHoursThisMonth = 0;

    #region Working Timer
    Timer timer;
    bool isWorkingMode = false;
    TimeSpan elapsedTime = TimeSpan.Zero;
    TimeSpan timePaused = TimeSpan.Zero;
    TimeSpan remainingTime = TimeSpan.Zero;
    #endregion

    public string CurentDate => $"{DateTime.Today.Day}/{DateTime.Today.Month}/{DateTime.Today.Year}";

    #region List
    private ObservableCollection<ProjectVM> _projects = new ObservableCollection<ProjectVM>();
    private ObservableCollection<DisciplineVM> _disciplines = new ObservableCollection<DisciplineVM>();
    private ObservableCollection<DrawingVM> _draws = new ObservableCollection<DrawingVM>();
    private ObservableCollection<OtherVM> _others = new ObservableCollection<OtherVM>();
    private List<DrawingVM> _drawsChanged = new List<DrawingVM>();
    private List<OtherVM> _othersChanged = new List<OtherVM>();
    private ObservableCollection<UserVM> _designers = new ObservableCollection<UserVM>();
    private ObservableCollection<UserVM> _engineers = new ObservableCollection<UserVM>();
    private ObservableCollection<UserVM> _projectManagers = new ObservableCollection<UserVM>();
    private ObservableCollection<IssueVM> _issues = new ObservableCollection<IssueVM>();
    #endregion

    #region Selected Models
    private ProjectVM _selectedProject = new ProjectVM();
    private DisciplineVM _selectedDiscipline = new DisciplineVM();
    private DrawingVM _selectedDraw = new DrawingVM();
    private OtherVM _selectedOther = new OtherVM();
    private int _selectedPmId;
    #endregion

    #region Dialogs
    // Work End Dialog
    private FluentDialog _endWorkDialog;
    private bool _isEndWorkDialogOdepened = false;
    private bool _isEndWorkAcceptDialogDisabled => remainingTime.Hours != 0 || remainingTime.Minutes != 0;

    // Add Designer Dialog
    private FluentDialog _addDesignerDialog;
    private bool _isAddDesignerDialogOdepened = false;

    // Add Engineer Dialog
    private FluentDialog _addEngineerDialog;
    private bool _isAddEngineerDialogOdepened = false;

    // Add ProjectManager Dialog
    private FluentDialog _addPMDialog;
    private bool _isAddPMDialogOdepened = false;

    // On Add Issue Dialog
    private FluentDialog _addIssueDialog;
    private bool _isAddIssueDialogOdepened = false;
    private IssueDetailed issueCompoment;

    // On Add/Edit Issues Dialog
    private FluentDialog _displayIssuesDialog;
    private bool _isDisplayIssuesDialogOdepened = false;

    // On Add Project Dialog
    private FluentDialog _addEditProjectDialog;
    private bool _isAddEditProjectDialogOdepened = false;
    private ProjectDetailed projectCompoment;

    // On Add/Edit Discipline Dialog
    private FluentDialog _addEditDisciplineDialog;
    private bool _isAddEditDisciplineDialogOdepened = false;
    private DisciplineDetailed disciplineCompoment;
    private bool _hasDisciplinesSelections = true;

    // On Add/Edit Deliverable Dialog
    private FluentDialog _addEditDeliverableDialog;
    private bool _isAddEditDeliverableDialogOdepened = false;
    private DrawingDetailed drawingCompoment;
    private bool _hasDrawingsSelections = true;

    // On Add/Edit Other Dialog
    private FluentDialog _addEditOtherDialog;
    private bool _isAddEditOtherDialogOdepened = false;
    private OtherDetailed otherCompoment;
    private bool _hasOthersSelections = true;

    // On Delete Dialog
    private FluentDialog _deleteDialog;
    private bool _isDeleteDialogOdepened = false;
    private string _deleteDialogMsg = "";
    private string _deleteObj = null;

    // On Add/Edit Invoice Dialog
    private FluentDialog _addEditInvoiceDialog;
    private bool _isAddEditInvoiceDialogOdepened = false;
    private Invoices _invoicesCompoment;

    // On Add/Edit Payment Dialog
    private FluentDialog _addEditPaymentDialog;
    private bool _isAddEditPaymentDialogOdepened = false;
    private Payments _ppaymentsCompoment;
    #endregion

    protected override void OnInitialized()
    {
        base.OnInitialized();
        // timer = used only to run UpdateElapsedTime() every one second
        timer = new Timer(_ => UpdateElapsedTime(), null, 0, 1000);
        isWorkingMode = TimerService.IsRunning(_sharedAuthData.LogedUser.Id.ToString());
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            var runInTeams = await MicrosoftTeams.IsInTeams();

            await Refresh();
        }
    }

    public async Task Refresh()
    {
        _startLoading = true;
        await _getUserTotalHoursThisMonth();
        await _getIssues();
        await _getProjects();
        _startLoading = false;
        StateHasChanged();
    }

    #region Get Records
    private async Task _getIssues()
    {
        try
        {
            var issuesDtos = await _dataProvider.Users.GetOpenIssues((int)_sharedAuthData.LogedUser.Id);
            var issuesVms = Mapper.Map<List<IssueVM>>(issuesDtos);
            _issues.Clear();
            issuesVms.ForEach(_issues.Add);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
    }

    private async Task _checkIfHasAnySelections()
    {
        if (_selectedProject != null)
            _hasDisciplinesSelections = await _dataProvider.DisciplinesTypes.HasDisciplineTypesSelections(_selectedProject.Id);
        if (_selectedDiscipline != null)
        {
            _hasDrawingsSelections = await _dataProvider.DrawingsTypes.HasDrawingTypesSelections(_selectedDiscipline.Id);
            _hasOthersSelections = await _dataProvider.OthersTypes.HasOtherTypesSelections(_selectedDiscipline.Id);
        }
    }

    private async Task _getUserTotalHoursThisMonth()
    {
        _userTotalHoursThisMonth = await _dataProvider.Users.GetUserTotalHoursThisMonth(_sharedAuthData.LogedUser.Id);
    }

    public async Task _getProjects()
    {
        _selectedProject = null;
        _selectedDiscipline = null;
        _selectedDraw = null;
        _selectedOther = null;
        _disciplines.Clear();
        _draws.Clear();
        _others.Clear();

        try
        {
            // Todo: Find a way to add this in to PaginatorVM
            //_paginator.SetRecordsLength(await _dataProvider.Projects.Count());

            // TODO: Get My Project And Down
            //List<ProjectDto> projectsDto = (await _dataProvider.Projects.GetAll(LogedUser.Id, _paginator.PageSize, _paginator.PageIndex))
            //                                                           .ToList<ProjectDto>();

            // Get Projects of last month.
            Expression<Func<EmpiriaMS.Models.Models.Project, bool>> expression = p => p.CreatedDate >= DateTime.Now.AddMonths(-1);
            List<ProjectDto> projectsDto = (await _dataProvider.Projects.GetAll(expression, _sharedAuthData.LogedUser.Id)).ToList<ProjectDto>();


            var projectsVm = Mapper.Map<List<ProjectDto>, List<ProjectVM>>(projectsDto);

            _projects.Clear();
            foreach(var p in projectsVm)
            {
                var pm = await _dataProvider.Projects.GetProjectManager(p.Id);
                p.PmName = pm != null ? $"{pm.LastName} {pm.FirstName}" : null;
                _projects.Add(p);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
        _startLoading = false;
    }

    private async Task _getDesigners()
    {
        try
        {
            var defaultRoleId = await GetRoleId("Designer");
            if (defaultRoleId == 0)
                throw new Exception("Exception `Designer` role not exists!");

            var disigners = await _dataProvider.Roles.GetUsers(defaultRoleId);

            if (disigners == null)
                throw new NullReferenceException(nameof(disigners));

            var myDesignersIds = (await _dataProvider.Drawings.GetDesigners(_selectedDraw.Id)).Select(d => d.Id);

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
            Console.WriteLine($"Exception: {ex.Message}");
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

            var engineers = await _dataProvider.Roles.GetUsers(defaultRoleId);

            if (engineers == null)
                throw new NullReferenceException(nameof(engineers));

            var myEngineersIds = (await _dataProvider.Disciplines.GetEngineers(_selectedDiscipline.Id)).Select(d => d.Id);

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
            Console.WriteLine($"Exception: {ex.Message}");
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

            var pms = await _dataProvider.Roles.GetUsers(defaultRoleId);

            if (pms == null)
                throw new NullReferenceException(nameof(pms));

            var pmsVM = Mapper.Map<List<UserVM>>(pms);

            if (_selectedProject.ProjectManagerId != null && _selectedProject.ProjectManagerId != 0)
            {
                var myPM = await _dataProvider.Projects.GetProjectManager(_selectedProject.Id);
                _selectedPmId = myPM.Id;
            }

            _projectManagers.Clear();
            pmsVM.ForEach(_projectManagers.Add);

            StateHasChanged();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
    }

    private async Task<int> GetRoleId(string roleName)
    {
        try
        {
            var role = await _dataProvider.Roles.Get(roleName);
            return role?.Id ?? 0;
        }
        catch (Exception ex)
        {
            // TODO: Log Error
            Console.WriteLine($"Exception: {ex.Message}");
            return 0;
        }
    }

    private long GetProjectMenHours(int projecId) =>
        _dataProvider.Projects.GetMenHours(projecId);

    private long GetDisciplineMenHours(int disciplineId) =>
        _dataProvider.Disciplines.GetMenHours(disciplineId);

    private long GetDrawingMenHours(int drawingId) =>
        _dataProvider.Drawings.GetMenHours(drawingId);

    private long GetOtherMenHours(int otherId) =>
        _dataProvider.Others.GetMenHours(otherId);
    #endregion

    #region When Row Selected Update Data
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

        var disciplines = await _dataProvider.Projects.GetDisciplines(project.Id, _sharedAuthData.LogedUser.Id, getAllDisciplines);

        _disciplines.Clear();
        foreach (var di in disciplines)
            _disciplines.Add(Mapper.Map<DisciplineVM>(di));

        await _checkIfHasAnySelections();

        StateHasChanged();
    }

    private async Task OnSelectDiscipline(int disciplineId)
    {
        if (disciplineId == 0 || disciplineId == _selectedDiscipline?.Id) return;

        _selectedDiscipline = _disciplines.FirstOrDefault(d => d.Id == disciplineId);

        var draws = await _dataProvider.Disciplines.GetDraws(_selectedDiscipline.Id, _sharedAuthData.LogedUser.Id, getAllDrawings);
        var others = await _dataProvider.Disciplines.GetOthers(_selectedDiscipline.Id, _sharedAuthData.LogedUser.Id, true);

        _draws.Clear();
        foreach (var di in draws)
            _draws.Add(Mapper.Map<DrawingVM>(di));

        _others.Clear();
        foreach (var di in others)
            _others.Add(Mapper.Map<OtherVM>(di));

        await _checkIfHasAnySelections();

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
    #endregion

    #region Timer
    private void UpdateElapsedTime()
    {
        if (_sharedAuthData.LogedUser == null) return;

        var time = TimerService.GetElapsedTime(_sharedAuthData.LogedUser.Id.ToString());
        timePaused = TimerService.GetPausedTime(_sharedAuthData.LogedUser.Id.ToString());

        var timePlusPaused = time;

        if (timePaused != TimeSpan.Zero)
            timePlusPaused = time + timePaused;

        if (TimerService.IsRunning(_sharedAuthData.LogedUser.Id.ToString()))
        {
            elapsedTime = timePlusPaused;
            InvokeAsync(StateHasChanged);
        }
    }

    private void StartTimer()
    {
        TimerService.StartTimer(_sharedAuthData.LogedUser.Id.ToString());
    }

    private TimeSpan StopTimer()
    {
        return TimerService.StopTimer(_sharedAuthData.LogedUser.Id.ToString());
    }
    #endregion

    #region Start Stop Work Actions
    private void StartWorkClick()
    {
        isWorkingMode = true;
        StartTimer();
        StateHasChanged();
    }

    private async Task StopWorkClick()
    {
        if (!EditMyHours)
        {
            return;
        }

        isWorkingMode = false;
        remainingTime = StopTimer();

        _editLogedUserTimes = new UserTimes()
        {
            DailyTime = TimeSpan.Zero,
            PersonalTime = TimeSpan.Zero,
            TrainingTime = TimeSpan.Zero,
            CorporateEventTime = TimeSpan.Zero,
        };

        _projects.Clear();
        _others.Clear();
        _draws.Clear();
        _disciplines.Clear();
        _selectedOther = null;
        _selectedDraw = null;
        _selectedDiscipline = null;
        _selectedProject = null;
        await _getProjects();

        StateHasChanged();

        _endWorkDialog.Show();
        _isEndWorkDialogOdepened = true;
    }

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

        // TODO: Can save somewhere the extra hours and miutes
        if (remainingTime.Hours < updatedHours)
        {
            updatedHours = remainingTime.Hours;
            newTimeSpan = new TimeSpan(remainingTime.Hours, newTimeSpan.Minutes, newTimeSpan.Seconds);
        }
        if (remainingTime.Minutes < updatedMinutes && remainingTime.Hours == 0)
        {
            updatedMinutes = remainingTime.Minutes;
            newTimeSpan = new TimeSpan(newTimeSpan.Hours, remainingTime.Minutes, newTimeSpan.Seconds);
        }

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

        // TODO: Can save somewhere the extra hours and miutes
        if (remainingTime.Hours < updatedHours)
        {
            updatedHours = remainingTime.Hours;
            newTimeSpan = new TimeSpan(remainingTime.Hours, newTimeSpan.Minutes, newTimeSpan.Seconds);
        }
        if (remainingTime.Minutes < updatedMinutes && remainingTime.Hours == 0)
        {
            updatedMinutes = remainingTime.Minutes;
            newTimeSpan = new TimeSpan(newTimeSpan.Hours, remainingTime.Minutes, newTimeSpan.Seconds);
        }

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

    private void _onPersonalTimeChanged(TimeSpan newTimeSpan)
    {
        var previusTime = _editLogedUserTimes.PersonalTime;
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

        // TODO: Can save somewhere the extra hours and miutes
        if (remainingTime.Hours < updatedHours)
        {
            updatedHours = remainingTime.Hours;
            newTimeSpan = new TimeSpan(remainingTime.Hours, newTimeSpan.Minutes, newTimeSpan.Seconds);
        }
        if (remainingTime.Minutes < updatedMinutes && remainingTime.Hours == 0)
        {
            updatedMinutes = remainingTime.Minutes;
            newTimeSpan = new TimeSpan(newTimeSpan.Hours, remainingTime.Minutes, newTimeSpan.Seconds);
        }

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

        _editLogedUserTimes.PersonalTime = newTimeSpan;

        StateHasChanged();
    }

    private void _onTrainingTimeChanged(TimeSpan newTimeSpan)
    {
        var previusTime = _editLogedUserTimes.TrainingTime;
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

        // TODO: Can save somewhere the extra hours and miutes
        if (remainingTime.Hours < updatedHours)
        {
            updatedHours = remainingTime.Hours;
            newTimeSpan = new TimeSpan(remainingTime.Hours, newTimeSpan.Minutes, newTimeSpan.Seconds);
        }
        if (remainingTime.Minutes < updatedMinutes && remainingTime.Hours == 0)
        {
            updatedMinutes = remainingTime.Minutes;
            newTimeSpan = new TimeSpan(newTimeSpan.Hours, remainingTime.Minutes, newTimeSpan.Seconds);
        }

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

        _editLogedUserTimes.TrainingTime = newTimeSpan;

        StateHasChanged();
    }

    private void _onCorporateTimeChanged(TimeSpan newTimeSpan)
    {
        var previusTime = _editLogedUserTimes.CorporateEventTime;
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

        // TODO: Can save somewhere the extra hours and miutes
        if (remainingTime.Hours < updatedHours)
        {
            updatedHours = remainingTime.Hours;
            newTimeSpan = new TimeSpan(remainingTime.Hours, newTimeSpan.Minutes, newTimeSpan.Seconds);
        }
        if (remainingTime.Minutes < updatedMinutes && remainingTime.Hours == 0)
        {
            updatedMinutes = remainingTime.Minutes;
            newTimeSpan = new TimeSpan(newTimeSpan.Hours, remainingTime.Minutes, newTimeSpan.Seconds);
        }

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

        _editLogedUserTimes.CorporateEventTime = newTimeSpan;

        StateHasChanged();
    }

    public async Task _endWorkDialogAccept()
    {
        try
        {
            _endWorkDialog.Hide();
            _isEndWorkDialogOdepened = false;

            // Validate
            if (remainingTime.Hours > 0)
            {
                // TODO: Display a message to update his hours.
                return;
            }


            // Update Db
            _startLoading = true;

            // Update Draws
            foreach (var draw in _drawsChanged)
            {
                var old = _draws.FirstOrDefault(d => d.Id == draw.Id);
                if (old.CompletionEstimation > draw.CompletionEstimation)
                {
                    //TODO: Display Msg

                    return;
                }
                else
                    await _dataProvider.Drawings.UpdateCompleted(_selectedProject.Id, _selectedDiscipline.Id, draw.Id, draw.CompletionEstimation);
                await _dataProvider.Drawings.AddTime(_sharedAuthData.LogedUser.Id, _selectedProject.Id, _selectedDiscipline.Id, draw.Id, draw.Time);
            }

            // Update Others
            foreach (var other in _othersChanged)
            {
                //await _dataProvider.Others.UpdateCompleted(_selectedProject.Id, _selectedDiscipline.Id, other.Id, other.CompletionEstimation);
                await _dataProvider.Others.AddTime(_sharedAuthData.LogedUser.Id, _selectedProject.Id, _selectedDiscipline.Id, other.Id, other.Time);
            }

            // Update User Hours
            if (_editLogedUserTimes.PersonalTime != TimeSpan.Zero)
                await _dataProvider.Users.AddPersonalTime(_sharedAuthData.LogedUser.Id, DateTime.Now, _editLogedUserTimes.PersonalTime);
            if (_editLogedUserTimes.TrainingTime != TimeSpan.Zero)
                await _dataProvider.Users.AddTraningTime(_sharedAuthData.LogedUser.Id, DateTime.Now, _editLogedUserTimes.TrainingTime);
            if (_editLogedUserTimes.CorporateEventTime != TimeSpan.Zero)
                await _dataProvider.Users.AddCorporateEventTime(_sharedAuthData.LogedUser.Id, DateTime.Now, _editLogedUserTimes.CorporateEventTime);

            _drawsChanged.Clear();
            _othersChanged.Clear();

            await _getProjects();

            // Clear Timer From this User
            TimerService.ClearTimer(_sharedAuthData.LogedUser.Id.ToString());

            await _getUserTotalHoursThisMonth();

            StateHasChanged();
        }
        catch(Exception ex)
        {
            // TODO Exception Log
            Console.WriteLine($"\n\nException: {ex.Message}");
            Console.WriteLine($"\nException Inner: {ex.InnerException.Message}");
        }

        _startLoading = false;
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

    #region Drawings Assign Actions (Deliverable Assign)
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
            Console.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
    }

    public async Task _addDesignerDialogAccept()
    {
        _addDesignerDialog.Hide();
        _isAddDesignerDialogOdepened = false;

        _startLoading = true;

        var forDeleteIds = _designers.Where(d => d.IsSelected == null || d.IsSelected == false)
                                     .Select(d => d.Id)
                                     .ToList();
        await _dataProvider.Drawings.RemoveDesigners(_selectedDraw.Id, forDeleteIds);

        var forAdd = _designers.Where(d => d.IsSelected == true).ToList();
        var forAddDto = Mapper.Map<List<UserDto>>(forAdd);
        await _dataProvider.Drawings.AddDesigners(_selectedDraw.Id, forAddDto);

        _startLoading = false;
    }

    public void _addDesignerDialogCansel()
    {
        _addDesignerDialog.Hide();
        _isAddDesignerDialogOdepened = false;
    }
    #endregion

    #region Engineers Assign Actions (Discipline Assign)
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
            Console.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
    }

    public async Task _addEngineerDialogAccept()
    {
        _addEngineerDialog.Hide();
        _isAddEngineerDialogOdepened = false;

        _startLoading = true;

        var forDeleteIds = _engineers.Where(d => d.IsSelected == null || d.IsSelected == false)
                                     .Select(d => d.Id)
                                     .ToList();
        await _dataProvider.Disciplines.RemoveEngineers(_selectedDiscipline.Id, forDeleteIds);

        var forAdd = _engineers.Where(d => d.IsSelected == true).ToList();
        var forAddDto = Mapper.Map<List<UserDto>>(forAdd);
        await _dataProvider.Disciplines.AddEngineers(_selectedDiscipline.Id, forAddDto);

        _startLoading = false;
    }

    public void _addEngineerDialogCansel()
    {
        _addEngineerDialog.Hide();
        _isAddEngineerDialogOdepened = false;
    }
    #endregion

    #region Projects Managers Assign Actions (Project Assign)
    void ToggleSelection(UserVM pm, string selectedValue)
    {
        pm.IsSelected = !_projectManagers.First(p => p.Id.ToString() == selectedValue).IsSelected;
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
            Console.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
    }

    public async Task _addPMDialogAccept()
    {
        _addPMDialog.Hide();
        _isAddPMDialogOdepened = false;

        _startLoading = true;

        _selectedProject.ProjectManagerId = _selectedPmId;
        await _dataProvider.Projects.Update(Mapper.Map<ProjectDto>(_selectedProject));

        _startLoading = false;

        await Refresh();
    }

    public void _addPMDialogCansel()
    {
        _addPMDialog.Hide();
        _isAddPMDialogOdepened = false;
    }
    #endregion

    #region Add Issue Actions
    private void OnAddIssueClick()
    {
        _startLoading = true;
        issueCompoment.Refresh();
        _startLoading = false;
        _addIssueDialog.Show();
        _isAddIssueDialogOdepened = true;
    }

    private void CloseAddIssueClick()
    {
        if (_isAddIssueDialogOdepened)
        {
            _addIssueDialog.Hide();
            _isAddIssueDialogOdepened = false;
        }
    }

    public async Task _addIssueDialogAccept()
    {
        await issueCompoment.HandleValidSubmit();
        _addIssueDialog.Hide();
        _isAddIssueDialogOdepened = false;
    }

    public void _addIssueDialogCansel()
    {
        _addIssueDialog.Hide();
        _isAddIssueDialogOdepened = false;
    }
    #endregion

    #region Display Issues
    private void OpenIssuesClick()
    {
        _displayIssuesDialog.Show();
        _isDisplayIssuesDialogOdepened = true;
    }

    private async Task CloseIssuesClick()
    {
        if (_isDisplayIssuesDialogOdepened)
        {
            _displayIssuesDialog.Hide();
            _isDisplayIssuesDialogOdepened = false;
            await _getIssues();
        }
    }
    #endregion

    #region Add Invoice Actions
    private async Task AddEditInvoice()
    {
        await _invoicesCompoment.Prepair();
        _addEditInvoiceDialog.Show();
        _isAddEditInvoiceDialogOdepened = true;
    }

    private void CloseAddInvoiceClick()
    {
        if (_isAddEditInvoiceDialogOdepened)
        {
            _addEditInvoiceDialog.Hide();
            _isAddEditInvoiceDialogOdepened = false;
        }
    }

    public async Task _addInvoiceDialogAccept()
    {
        _addEditInvoiceDialog.Hide();
        _isAddEditInvoiceDialogOdepened = false;
        await Refresh();
    }
    #endregion

    #region Add Payment Actions
    private void AddEditPayment()
    {
        _addEditPaymentDialog.Show();
        _isAddEditPaymentDialogOdepened = true;
    }

    private void CloseAddPaymentClick()
    {
        if (_isAddEditPaymentDialogOdepened)
        {
            _addEditPaymentDialog.Hide();
            _isAddEditPaymentDialogOdepened = false;
        }
    }

    public async Task _addPaymentDialogAccept()
    {
        _addEditPaymentDialog.Hide();
        _isAddEditPaymentDialogOdepened = false;
        await Refresh();
    }
    #endregion

    #region Add/Edit/Delete Project Actions
    private void AddProject()
    {
        projectCompoment.PrepairForNew();
        _addEditProjectDialog.Show();
        _isAddEditProjectDialogOdepened = true;
    }

    private void EditProject()
    {
        projectCompoment.PrepairForEdit(_selectedProject);
        _addEditProjectDialog.Show();
        _isAddEditProjectDialogOdepened = true;
    }

    private void CloseAddProjectClick()
    {
        if (_isAddEditProjectDialogOdepened)
        {
            _addEditProjectDialog.Hide();
            _isAddEditProjectDialogOdepened = false;
        }
    }

    private void DeleteProject()
    {
        _deleteDialogMsg = $"Are you sure you want delete {_selectedProject.Name}";
        _deleteObj = nameof(_selectedProject);
        _deleteDialog.Show();
        _isDeleteDialogOdepened = true;
    }

    public async Task _addEditProjectDialogAccept()
    {
        await projectCompoment.HandleValidSubmit();
        _addEditProjectDialog.Hide();
        _isAddEditProjectDialogOdepened = false;
        await Refresh();
    }

    public void _addEditProjectDialogCansel()
    {
        _addEditProjectDialog.Hide();
        _isAddEditProjectDialogOdepened = false;
    }
    #endregion

    #region Add/Edit/Delete Discipline Actions
    private void AddDiscipline()
    {
        disciplineCompoment.PrepairForNew();
        _addEditDisciplineDialog.Show();
        _isAddEditDisciplineDialogOdepened = true;
    }

    private void EditDiscipline()
    {
        disciplineCompoment.PrepairForEdit(_selectedDiscipline);
        _addEditDisciplineDialog.Show();
        _isAddEditDisciplineDialogOdepened = true;
    }

    private void CloseAddDisciplineClick()
    {
        if (_isAddEditDisciplineDialogOdepened)
        {
            _addEditDisciplineDialog.Hide();
            _isAddEditDisciplineDialogOdepened = false;
        }
    }

    public async Task _addEditDisciplineDialogAccept()
    {
        await disciplineCompoment.HandleValidSubmit();
        _addEditDisciplineDialog.Hide();
        _isAddEditDisciplineDialogOdepened = false;
        await Refresh();
    }

    private void DeleteDiscipline()
    {
        _deleteDialogMsg = $"Are you sure you want delete {_selectedDiscipline.Type.Name}";
        _deleteObj = nameof(_selectedDiscipline);
        _deleteDialog.Show();
        _isDeleteDialogOdepened = true;
    }
    #endregion

    #region Add/Edit/Delete Deliverable Actions
    private void AddDeliverable()
    {
        drawingCompoment.PrepairForNew();
        _addEditDeliverableDialog.Show();
        _isAddEditDeliverableDialogOdepened = true;
    }

    private void EditDeliverable()
    {
        drawingCompoment.PrepairForEdit(_selectedDraw);
        _addEditDeliverableDialog.Show();
        _isAddEditDeliverableDialogOdepened = true;
    }

    private void CloseAddDeliverableClick()
    {
        if (_isAddEditDeliverableDialogOdepened)
        {
            _addEditDeliverableDialog.Hide();
            _isAddEditDeliverableDialogOdepened = false;
        }
    }

    public async Task _addEditDeliverableDialogAccept()
    {
        await drawingCompoment.HandleValidSubmit();
        _addEditDeliverableDialog.Hide();
        _isAddEditDeliverableDialogOdepened = false;
        await Refresh();
    }

    private void DeleteDeliverable()
    {
        _deleteDialogMsg = $"Are you sure you want delete {_selectedDraw.Type.Name}";
        _deleteObj = nameof(_selectedDraw);
        _deleteDialog.Show();
        _isDeleteDialogOdepened = true;
    }
    #endregion

    #region Add/Edit/Delete Other Actions
    private void AddOther()
    {
        otherCompoment.PrepairForNew();
        _addEditOtherDialog.Show();
        _isAddEditOtherDialogOdepened = true;
    }

    private void EditOther()
    {
        otherCompoment.PrepairForEdit(_selectedOther);
        _addEditOtherDialog.Show();
        _isAddEditOtherDialogOdepened = true;
    }

    private void CloseAddOtherClick()
    {
        if (_isAddEditOtherDialogOdepened)
        {
            _addEditOtherDialog.Hide();
            _isAddEditOtherDialogOdepened = false;
        }
    }

    public async Task _addEditOtherDialogAccept()
    {
        await otherCompoment.HandleValidSubmit();
        _addEditOtherDialog.Hide();
        _isAddEditOtherDialogOdepened = false;
        await Refresh();
    }

    private void DeleteOther()
    {
        _deleteDialogMsg = $"Are you sure you want delete {_selectedOther.Type.Name}";
        _deleteObj = nameof(_selectedOther);
        _deleteDialog.Show();
        _isDeleteDialogOdepened = true;
    }
    #endregion

    #region Delete Dialog Actions
    private async Task OnDeleteAccept()
    {
        if (_isDeleteDialogOdepened)
        {
            switch (_deleteObj)
            {
                case nameof(_selectedProject):
                    await _dataProvider.Projects.Delete(_selectedProject.Id);
                    break;
                case nameof(_selectedDiscipline):
                    await _dataProvider.Disciplines.Delete(_selectedDiscipline.Id);
                    break;
                case nameof(_selectedDraw):
                    await _dataProvider.Drawings.Delete(_selectedDraw.Id);
                    break;
                case nameof(_selectedOther):
                    await _dataProvider.Others.Delete(_selectedOther.Id);
                    break;
            }

            _deleteDialogMsg = "";
            _deleteObj = null;
            _deleteDialog.Hide();
            _isDeleteDialogOdepened = false;

            await Refresh();
        }
    }

    private void OnDeleteClose()
    {
        if (_isDeleteDialogOdepened)
        {
            _deleteDialogMsg = "";
            _deleteObj = null;
            _deleteDialog.Hide();
            _isDeleteDialogOdepened = false;
        }
    }
    #endregion

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                timer.Dispose();
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
