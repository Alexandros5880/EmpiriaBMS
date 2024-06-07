using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.ReturnModels;
using EmpiriaBMS.Front.Components.Invoices;
using EmpiriaBMS.Front.Services;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.CodeAnalysis;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;

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
    bool seeAdmin => _sharedAuthData.Permissions.Any(p => p.Ord == 7);
    bool seeOffers => _sharedAuthData.Permissions.Any(p => p.Ord == 24);
    bool seeTeamsRequestedUsers => _sharedAuthData.Permissions.Any(p => p.Ord == 28);
    bool seeInvoices => _sharedAuthData.Permissions.Any(p => p.Ord == 29);
    bool seeExpenses => _sharedAuthData.Permissions.Any(p => p.Ord == 30);
    bool WorkOnProject => _sharedAuthData.Permissions.Any(p => p.Ord == 31);
    bool WorkOnOffers => _sharedAuthData.Permissions.Any(p => p.Ord == 32);
    bool WorkOnLeds => _sharedAuthData.Permissions.Any(p => p.Ord == 33);
    #endregion

    // General Fields
    private bool disposedValue;
    bool _startLoading = true;
    bool _refreshLoading = true;
    private double _userTotalHoursThisMonth = 0;

    #region Working Timer
    Timer timer;
    bool isWorkingMode = false;
    TimeSpan elapsedTime = TimeSpan.Zero;
    TimeSpan timePaused = TimeSpan.Zero;
    TimeSpan remainingTime = TimeSpan.Zero;
    #endregion

    public string CurentDate => $"{DateTime.Today.Day}/{DateTime.Today.Month}/{DateTime.Today.Year}";

    #region Projects Filter
    IQueryable<ProjectVM>? _filteredProjects => _projects?.AsQueryable().Where(x => x.Name.Contains(_projectNameFilter, StringComparison.CurrentCultureIgnoreCase));
    private string _projectNameFilter = string.Empty;

    private void HandleProjectFilter(ChangeEventArgs args)
    {
        if (args.Value is string value)
        {
            _projectNameFilter = value;
        }
        else if (string.IsNullOrWhiteSpace(_projectNameFilter) || string.IsNullOrEmpty(_projectNameFilter))
        {
            _projectNameFilter = string.Empty;
        }
    }
    #endregion

    #region Lists
    private ObservableCollection<LedVM> _leds = new ObservableCollection<LedVM>();
    private ObservableCollection<OfferVM> _offers = new ObservableCollection<OfferVM>();
    private ObservableCollection<ProjectVM> _projects = new ObservableCollection<ProjectVM>();
    private ObservableCollection<DisciplineVM> _disciplines = new ObservableCollection<DisciplineVM>();
    private ObservableCollection<DrawingVM> _draws = new ObservableCollection<DrawingVM>();
    private ObservableCollection<OtherVM> _others = new ObservableCollection<OtherVM>();
    private List<LedVM> _ledsChanged = new List<LedVM>();
    private List<OfferVM> _offersChanged = new List<OfferVM>();
    private List<ProjectVM> _projectsChanged = new List<ProjectVM>();
    private List<DrawingVM> _drawsChanged = new List<DrawingVM>();
    private List<OtherVM> _othersChanged = new List<OtherVM>();
    private ObservableCollection<UserVM> _designers = new ObservableCollection<UserVM>();
    private ObservableCollection<UserVM> _engineers = new ObservableCollection<UserVM>();
    private ObservableCollection<UserVM> _projectManagers = new ObservableCollection<UserVM>();
    private ObservableCollection<IssueVM> _issues = new ObservableCollection<IssueVM>();
    private ObservableCollection<TeamsRequestedUserVM> _teamsRequestedUsers = new ObservableCollection<TeamsRequestedUserVM>();
    #endregion

    #region Selected Models
    private LedVM _selectedLed = new LedVM();
    private OfferVM _selectedOffer = new OfferVM();
    private ProjectVM _selectedProject = new ProjectVM();
    private DisciplineVM _selectedDiscipline = new DisciplineVM();
    private DrawingVM _selectedDraw = new DrawingVM();
    private OtherVM _selectedOther = new OtherVM();
    private int _selectedPmId;
    private InvoiceVM _selectedInvoice = new InvoiceVM();
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

    // On Add/Edit TeamsRequestedUsers Dialog
    private FluentDialog _displayTeamsRequestedUsersDialog;
    private bool _isDisplayTeamsRequestedUsersDialogOdepened = false;

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
    #endregion

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (_sharedAuthData.LogedUser == null)
        {
            MyNavigationManager.NavigateTo("/loginpage");
            return;
        }

        // timer = used only to run UpdateElapsedTime() every one second
        timer = new Timer(_ => UpdateElapsedTime(), null, 0, 1000);
        isWorkingMode = TimerService.IsRunning(_sharedAuthData.LogedUser.Id.ToString());
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _startLoading = true;
            var runInTeams = await MicrosoftTeams.IsInTeams();
            await Refresh();
            _startLoading = false;
        }
    }

    public async Task Refresh()
    {
        _refreshLoading = true;
        await _getTeamsRequestedUsers();
        await _getUserTotalHoursThisMonth();
        await _getIssues();
        await _getProjects();
        _refreshLoading = false;
        StateHasChanged();
    }

    #region Get Records
    private async Task _getTeamsRequestedUsers()
    {
        try
        {
            var requestedUsersDtos = await _dataProvider.TeamsRequestedUsers.GetAll();
            var requestedUsersVms = Mapper.Map<List<TeamsRequestedUserVM>>(requestedUsersDtos);
            _teamsRequestedUsers.Clear();
            requestedUsersVms.ForEach(_teamsRequestedUsers.Add);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
    }

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

    public async Task _getLeds()
    {
        _selectedLed = null;
        _selectedOffer = null;
        _selectedProject = null;
        _selectedDiscipline = null;
        _selectedDraw = null;
        _selectedOther = null;
        _disciplines.Clear();
        _draws.Clear();
        _others.Clear();

        try
        {
            var dtos = await _dataProvider.Leds.GetAll();
            var vms = Mapper.Map<List<LedVM>>(dtos);
            _leds.Clear();
            vms.ForEach(_leds.Add);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
        _startLoading = false;
    }

    public async Task _getOffers()
    {
        _selectedOffer = null;
        _selectedProject = null;
        _selectedDiscipline = null;
        _selectedDraw = null;
        _selectedOther = null;
        _disciplines.Clear();
        _draws.Clear();
        _others.Clear();

        try
        {
            var dtos = await _dataProvider.Offers.GetAllByLed(_selectedLed?.Id ?? 0);
            var vms = Mapper.Map<List<OfferVM>>(dtos);
            _offers.Clear();
            vms.ForEach(_offers.Add);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
        _startLoading = false;
    }

    public async Task _getProjects(bool? active = null)
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
            // Get Projects of last month
            List<ProjectDto> projectsDto = (await _dataProvider.Projects.GetLastMonthProjects(_sharedAuthData.LogedUser.Id, offerId: _selectedOffer?.Id ?? 0, active: active)).ToList<ProjectDto>();


            var projectsVm = Mapper.Map<List<ProjectDto>, List<ProjectVM>>(projectsDto);

            _projects.Clear();
            foreach (var p in projectsVm)
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
    private async Task OnSelectLed(int ledId)
    {
        if (ledId == 0 || ledId == _selectedLed?.Id) return;

        var led = _leds.FirstOrDefault(p => p.Id == ledId);
        _offers.Clear();
        _projects.Clear();
        _draws.Clear();
        _others.Clear();
        _disciplines.Clear();
        _selectedLed = led;
        _selectedOffer = null;
        _selectedProject = null;
        _selectedDiscipline = null;
        _selectedDraw = null;
        _selectedOther = null;

        await _getOffers();

        StateHasChanged();
    }

    private async Task OnSelectOffer(int offerId)
    {
        if (offerId == 0 || offerId == _selectedOffer?.Id) return;

        var offer = _offers.FirstOrDefault(p => p.Id == offerId);
        _projects.Clear();
        _draws.Clear();
        _others.Clear();
        _disciplines.Clear();
        _selectedOffer = offer;
        _selectedProject = null;
        _selectedDiscipline = null;
        _selectedDraw = null;
        _selectedOther = null;

        await _getProjects(active: true);

        StateHasChanged();
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

        _leds.Clear();
        _offers.Clear();
        _projects.Clear();
        _others.Clear();
        _draws.Clear();
        _disciplines.Clear();
        _selectedLed = null;
        _selectedOffer = null;
        _selectedProject = null;
        _selectedOther = null;
        _selectedDraw = null;
        _selectedDiscipline = null;
        _selectedProject = null;

        if (WorkOnLeds)
            await _getLeds();

        if (WorkOnOffers)
            await _getOffers();

        if (!WorkOnLeds && !WorkOnOffers)
            await _getProjects();

        StateHasChanged();

        _endWorkDialog.Show();
        _isEndWorkDialogOdepened = true;
    }

    private void _onLedTimeChanged(LedVM led, TimeSpan newTimeSpan)
    {
        // previusTime, updatedTime, remainingTime

        var previusTime = led.Time;
        var updatedTime = newTimeSpan - previusTime;
        remainingTime += (-updatedTime);

        led.Time = newTimeSpan;

        if (_ledsChanged.Any(d => d.Id == led.Id))
        {
            var d = _ledsChanged.FirstOrDefault(d => d.Id == led.Id);
            d.Time = led.Time;
        }
        else
            _ledsChanged.Add(led);

        StateHasChanged();
    }

    private void _onOfferTimeChanged(OfferVM offer, TimeSpan newTimeSpan)
    {
        // previusTime, updatedTime, remainingTime

        var previusTime = offer.Time;
        var updatedTime = newTimeSpan - previusTime;
        remainingTime += (-updatedTime);

        offer.Time = newTimeSpan;

        if (_offersChanged.Any(d => d.Id == offer.Id))
        {
            var d = _offersChanged.FirstOrDefault(d => d.Id == offer.Id);
            d.Time = offer.Time;
        }
        else
            _offersChanged.Add(offer);

        StateHasChanged();
    }

    private void _onProjectTimeChanged(ProjectVM project, TimeSpan newTimeSpan)
    {
        // previusTime, updatedTime, remainingTime

        var previusTime = project.Time;
        var updatedTime = newTimeSpan - previusTime;
        remainingTime += (-updatedTime);

        project.Time = newTimeSpan;

        if (_projectsChanged.Any(d => d.Id == project.Id))
        {
            var d = _projectsChanged.FirstOrDefault(d => d.Id == project.Id);
            d.Time = project.Time;
        }
        else
            _projectsChanged.Add(project);

        StateHasChanged();
    }

    private void _onDrawTimeChanged(DrawingVM draw, TimeSpan newTimeSpan)
    {
        // previusTime, updatedTime, remainingTime

        var previusTime = draw.Time;
        var updatedTime = newTimeSpan - previusTime;
        remainingTime += (-updatedTime);

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
        var updatedTime = newTimeSpan - previusTime;
        remainingTime += (-updatedTime);

        other.Time = newTimeSpan;

        if (_othersChanged.Any(d => d.Id == other.Id))
        {
            var d = _othersChanged.FirstOrDefault(d => d.Id == other.Id);
            d.Time = other.Time;
        }
        else
            _othersChanged.Add(other);

        StateHasChanged();
    }

    private void _onPersonalTimeChanged(TimeSpan newTimeSpan)
    {
        // previusTime, updatedTime, remainingTime

        var previusTime = _editLogedUserTimes.PersonalTime;
        var updatedTime = newTimeSpan - previusTime;
        remainingTime += (-updatedTime);

        _editLogedUserTimes.PersonalTime = newTimeSpan;

        StateHasChanged();
    }

    private void _onTrainingTimeChanged(TimeSpan newTimeSpan)
    {
        // previusTime, updatedTime, remainingTime

        var previusTime = _editLogedUserTimes.TrainingTime;
        var updatedTime = newTimeSpan - previusTime;
        remainingTime += (-updatedTime);

        _editLogedUserTimes.TrainingTime = newTimeSpan;

        StateHasChanged();
    }

    private void _onCorporateTimeChanged(TimeSpan newTimeSpan)
    {
        // previusTime, updatedTime, remainingTime

        var previusTime = _editLogedUserTimes.CorporateEventTime;
        var updatedTime = newTimeSpan - previusTime;
        remainingTime += (-updatedTime);

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


            // Update Leds
            foreach (var led in _ledsChanged)
            {
                await _dataProvider.Leds.AddTime(_sharedAuthData.LogedUser.Id, led.Id, led.Time);
            }
            _ledsChanged.Clear();
            _selectedLed = null;

            // Update Offers
            foreach (var offer in _offersChanged)
            {
                await _dataProvider.Offers.AddTime(_sharedAuthData.LogedUser.Id, offer.Id, offer.Time);
            }
            _offersChanged.Clear();
            _selectedOffer = null;

            // Update Projects
            foreach (var project in _projectsChanged)
            {
                await _dataProvider.Projects.AddTime(_sharedAuthData.LogedUser.Id, project.Id, project.Time);
            }
            _projectsChanged.Clear();
            //_selectedProject = null;

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
        catch (Exception ex)
        {
            // TODO Exception Log
            Console.WriteLine($"\n\nException: {ex.Message}");
            Console.WriteLine($"\nException Inner: {ex.InnerException.Message}");
        }

        _startLoading = false;
    }

    public void _endWorkDialogCansel()
    {
        _ledsChanged.Clear();
        _offersChanged.Clear();
        _projectsChanged.Clear();
        _drawsChanged.Clear();
        _othersChanged.Clear();

        _selectedLed = null;
        _selectedOffer = null;
        //_selectedProject = null;
        //_selectedDiscipline = null;
        //_selectedDraw = null;
        //_selectedOther = null;

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
    private async Task OpenIssuesClick(MouseEventArgs e)
    {
        if (!isWorkingMode)
        {
            await ShowInformationAsync("You need to have started your work to see the issues!");
        }
        else
        {
            _displayIssuesDialog.Show();
            _isDisplayIssuesDialogOdepened = true;
        }
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

    #region Display TeamsRequestedUsers
    private async Task OpenTeamsRequestedUsersClick(MouseEventArgs e)
    {
        _displayTeamsRequestedUsersDialog.Show();
        _isDisplayTeamsRequestedUsersDialogOdepened = true;
    }

    private async Task CloseTeamsRequestedUsersClick()
    {
        if (_isDisplayTeamsRequestedUsersDialogOdepened)
        {
            _displayTeamsRequestedUsersDialog.Hide();
            _isDisplayTeamsRequestedUsersDialogOdepened = false;
            await _getTeamsRequestedUsers();
        }
    }
    #endregion

    #region Add/Edit/Delete Project Actions
    private async Task NavigateOnMap(Address address)
    {
        if (address == null) return;
        var directionsUrl = $"https://www.google.com/maps/dir/?api=1&destination={address.Latitude},{address.Longitude}&travelmode=driving&dir_action=navigate";
        await MicrosoftTeams.OpenDirectionsInNewWindow(directionsUrl);
    }

    private void AddProject()
    {
        _addEditProjectDialog.Show();
        _isAddEditProjectDialogOdepened = true;
    }

    private void EditProject()
    {
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
        var valid = projectCompoment.Validate();
        if (valid)
        {
            await projectCompoment.SaveAsync();
            _addEditProjectDialog.Hide();
            _isAddEditProjectDialogOdepened = false;
            await Refresh();
        }
    }

    public void _addEditProjectDialogCansel()
    {
        _addEditProjectDialog.Hide();
        _isAddEditProjectDialogOdepened = false;
    }
    #endregion

    #region Add/Edit/Delete Discipline Actions
    private async Task AddDiscipline()
    {
        await disciplineCompoment.PrepairForNew();
        _addEditDisciplineDialog.Show();
        _isAddEditDisciplineDialogOdepened = true;
    }

    private async Task EditDiscipline()
    {
        await disciplineCompoment.PrepairForEdit(_selectedDiscipline);
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

    #region Tab Actions
    string? activeid = "tab-home";
    FluentTab? changedto;

    private void HandleOnTabChange(FluentTab tab)
    {
        changedto = tab;
    }
    #endregion

    #region Invoice
    private EmpiriaBMS.Front.Components.Invoices.Invoices _invoiceListRef;
    private InvoiceDetailed _invoiceDetailedRef;
    private Payments _invoicePaymentsRef;

    private async Task _onSelectedInvoice(InvoiceVM invoice)
    {
        _selectedInvoice = invoice;
        if (_invoiceDetailedRef != null)
        {
            await _invoiceDetailedRef.Prepair(_selectedInvoice, true);
            await _invoicePaymentsRef.Prepair(_selectedInvoice.Id);
        }
    }

    private async Task _onSaveInvoice(InvoiceVM invoice)
    {
        if (_invoiceListRef != null)
        {
            await _invoiceListRef.Refresh();
            await _invoiceDetailedRef.Prepair();
            await _invoicePaymentsRef.Prepair(_selectedInvoice.Id);
        }

    }
    #endregion

    private async Task ShowInformationAsync(string msg)
    {
        var dialog = await DialogService.ShowInfoAsync(msg);
        var result = await dialog.Result;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                timer?.Dispose();
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
