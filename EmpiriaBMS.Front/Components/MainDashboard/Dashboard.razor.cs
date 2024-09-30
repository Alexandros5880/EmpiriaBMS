using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.Components.Invoices;
using EmpiriaBMS.Front.Components.KPIS.Base;
using ComReports = EmpiriaBMS.Front.Components.Reports;
using EmpiriaBMS.Front.Components.WorkingHours;
using EmpiriaBMS.Front.Services;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Enum;
using EmpiriaBMS.Models.Models;
using Humanizer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.RulesetToEditorconfig;
using Microsoft.Fast.Components.FluentUI;
using System;
using System.Collections.ObjectModel;
using OffersComp = EmpiriaBMS.Front.Components.Offers.Offers;
using EmpiriaBMS.Front.Components.Admin.Projects;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using EmpiriaBMS.Front.Components.MainDashboard.Projects;
using EmpiriaBMS.Front.Components.MainDashboard.Issues;
using DevComp = EmpiriaBMS.Front.Components.MainDashboard.Deliverables;
using DiscComp = EmpiriaBMS.Front.Components.MainDashboard.Disciplines;
using SWComp = EmpiriaBMS.Front.Components.MainDashboard.SupportiveWorks;

namespace EmpiriaBMS.Front.Components.MainDashboard;
public partial class Dashboard : IDisposable
{
    #region Authorization Properties
    bool isEmployee => _sharedAuthData.IsLogedUserEmployee;
    public bool assignDesigner => _sharedAuthData.PermissionOrds.Contains(3);
    public bool assignEngineer => _sharedAuthData.PermissionOrds.Contains(4);
    public bool assignPm => _sharedAuthData.PermissionOrds.Contains(5);
    public bool editMyHours => _sharedAuthData.PermissionOrds.Contains(2);
    public bool seeMyHours => _sharedAuthData.PermissionOrds.Contains(8);
    bool getAllDisciplines => _sharedAuthData.Permissions.Any(p => p.Ord == 9);
    bool editProject => _sharedAuthData.Permissions.Any(p => p.Ord == 12);
    bool editDiscipline => _sharedAuthData.Permissions.Any(p => p.Ord == 14);
    bool editDeliverable => _sharedAuthData.Permissions.Any(p => p.Ord == 15);
    bool editSupportiveWork => _sharedAuthData.Permissions.Any(p => p.Ord == 16);
    bool seeKpis => _sharedAuthData.Permissions.Any(p => p.Ord == 17);
    bool seeAdmin => _sharedAuthData.Permissions.Any(p => p.Ord == 7);
    bool seeOffers => _sharedAuthData.Permissions.Any(p => p.Ord == 24);
    bool seeTeamsRequestedUsers => _sharedAuthData.Permissions.Any(p => p.Ord == 28);
    bool seeInvoices => _sharedAuthData.Permissions.Any(p => p.Ord == 29);
    bool seeExpenses => _sharedAuthData.Permissions.Any(p => p.Ord == 30);
    bool workOnProject => _sharedAuthData.Permissions.Any(p => p.Ord == 31);
    bool workOnOffers => _sharedAuthData.Permissions.Any(p => p.Ord == 32);
    bool workOnLeds => _sharedAuthData.Permissions.Any(p => p.Ord == 33);
    bool seeNextYearIncome => _sharedAuthData.Permissions.Any(p => p.Ord == 34);
    bool seeBackupDatabase => _sharedAuthData.Permissions.Any(p => p.Ord == 35);
    bool seeRestoreDatabase => _sharedAuthData.Permissions.Any(p => p.Ord == 36);
    bool canChangeEverybodyHours => _sharedAuthData.Permissions.Any(p => p.Ord == 37);
    bool seeClientsOnDashboard => _sharedAuthData.Permissions.Any(p => p.Ord == 38);
    bool canApproveTimeRequests => _sharedAuthData.Permissions.Any(p => p.Ord == 39);
    bool seeTimeMGMT => _sharedAuthData.Permissions.Any(p => p.Ord == 40);
    #endregion

    // General Fields
    private bool disposedValue;
    bool _runInTeams = true;
    bool _startLoading = true;
    bool _refreshLoading = true;
    private double _userTotalHoursThisMonth = 0;

    #region Compoment Refrense
    private Invoices.Invoices _invoiceIncomesListRef;
    private Invoices.Invoices _invoiceExpensesListRef;
    private KPIDashboard _kpiDashRef;
    private ComReports.TimeMGMT _timeMGMTRef;
    #endregion

    #region Working Timer
    Timer timer;
    bool isWorkingMode = false;
    TimeSpan elapsedTime = TimeSpan.Zero;
    TimeSpan timePaused = TimeSpan.Zero;
    TimeSpan remainingTime = TimeSpan.Zero;
    private EditUsersHours _editHoursCompoment;
    #endregion

    public string CurentDate => $"{DateTime.Today.Day}/{DateTime.Today.Month}/{DateTime.Today.Year}";

    #region Projects Filter
    IQueryable<ProjectVM> _filteredProjects => _projects?.AsQueryable()
        .Where(p => _filterProjects(p));

    private string _projectNameFilter = string.Empty;
    private string selectedOfferFilterId = string.Empty;

    private void HandleProjectNameFilter(ChangeEventArgs args)
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

    private void _onOfferFilterChanged(OfferVM offer)
    {
        if (offer != null && offer.Id != 0)
            selectedOfferFilterId = offer.Id.ToString();
        else
            selectedOfferFilterId = string.Empty;
    }

    private bool _filterProjects(ProjectVM project)
    {
        return project.Name.Contains(_projectNameFilter, StringComparison.CurrentCultureIgnoreCase)
                &&
               (string.IsNullOrEmpty(selectedOfferFilterId) || Convert.ToString(project.OfferId) == selectedOfferFilterId);
    }
    #endregion

    #region Lists
    private ObservableCollection<ClientVM> _clients = new ObservableCollection<ClientVM>();
    private ObservableCollection<OfferVM> _offers = new ObservableCollection<OfferVM>();
    private ObservableCollection<ProjectVM> _projects = new ObservableCollection<ProjectVM>();
    private List<ClientVM> _clientsChanged = new List<ClientVM>();
    private List<OfferVM> _offersChanged = new List<OfferVM>();
    private List<ProjectVM> _projectsChanged = new List<ProjectVM>();
    private ObservableCollection<UserVM> _projectManagers = new ObservableCollection<UserVM>();
    private ObservableCollection<IssueVM> _issues = new ObservableCollection<IssueVM>();
    private ObservableCollection<TeamsRequestedUserVM> _teamsRequestedUsers = new ObservableCollection<TeamsRequestedUserVM>();
    private Dictionary<DailyTimeTypes, List<DailyTimeRequest>> _dailyTimeRequest = new Dictionary<DailyTimeTypes, List<DailyTimeRequest>>();
    #endregion

    #region Selected Models
    private ClientVM _selectedClient = new ClientVM();
    private OfferVM _selectedOffer = new OfferVM();
    private ProjectVM _selectedProject = new ProjectVM();
    private int _selectedPmId;
    private InvoiceVM _selectedIncomeInvoice = new InvoiceVM();
    private InvoiceVM _selectedExpenseInvoice = new InvoiceVM();
    #endregion

    #region Dialogs
    // Work End Dialog
    private FluentDialog _endWorkDialog;
    private bool _isEndWorkDialogOdepened = false;
    private bool _isEndWorkAcceptDialogDisabled => remainingTime.Hours != 0 || remainingTime.Minutes != 0;

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

    // On Add/Edit Hours Correction rEQUESTS Dialog
    private FluentDialog _displayHoursCorrectionRequestsDialog;
    private bool _isDisplayHoursCorrectionRequestsDialogOdepened = false;

    // On Add Project Dialog
    private FluentDialog _addEditProjectDialog;
    private bool _isAddEditProjectDialogOdepened = false;
    private ProjectDetailed projectCompoment;

    // On Delete Dialog
    private FluentDialog _deleteDialog;
    private bool _isDeleteDialogOdepened = false;
    private string _deleteDialogMsg = "";
    private string _deleteObj = null;

    // On Corrext Hours
    private FluentDialog _correctHoursDialog;
    private bool _isCorrectHoursDialogOdepened = false;
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
            _runInTeams = await MicrosoftTeams.IsInTeams();
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
        if (canApproveTimeRequests)
        {
            await _getHoursCorrectionsRequests();
            await _getHoursCorrectionRequestsCount();
        }
        await _getOffers(false);
        _refreshLoading = false;
        StateHasChanged();
    }

    #region Disciplines Table Compoment
    private DiscComp.Disciplines _disciplinesComp;

    private void _resetSelectedDisciplines()
    {
        if (_disciplinesComp != null)
            _disciplinesComp.ResetSelection();
    }

    private void _clearRecordsDisciplines()
    {
        if (_disciplinesComp != null)
            _disciplinesComp.ClearRecords();
    }

    private void _resetChangesDisciplines()
    {
        if (_disciplinesComp != null)
            _disciplinesComp.ResetChanges();
    }
    #endregion

    #region Deliverables Table Compoment
    private DevComp.Deliverables _deliverablesComp;

    private void _resetSelectedDeliverable()
    {
        if (_deliverablesComp != null)
            _deliverablesComp.ResetSelection();
    }

    private void _clearRecordsDeliverables()
    {
        if (_deliverablesComp != null)
            _deliverablesComp.ClearRecords();
    }

    private void _resetChangesDeliverables()
    {
        if (_deliverablesComp != null)
            _deliverablesComp.ResetChanges();
    }
    #endregion

    #region Supportive Works Table Compoment
    private SWComp.SupportiveWorks _supportiveWorksComp;

    private void _resetSelectedSupportiveWoprk()
    {
        if (_supportiveWorksComp != null)
            _supportiveWorksComp.ResetSelection();
    }

    private void _clearRecordsSupportiveWoprk()
    {
        if (_supportiveWorksComp != null)
            _supportiveWorksComp.ClearRecords();
    }

    private void _resetChangesSupportiveWoprk()
    {
        if (_supportiveWorksComp != null)
            _supportiveWorksComp.ResetChanges();
    }
    #endregion



    #region On Create Offer WorkFlow
    private OffersComp _offersComp;
    private async Task _onClientResultChanged(ClientVM client)
    {
        if (client.Result == ClientResult.SUCCESSFUL)
        {
            await MicrosoftTeams.ScrollToElement("offers-table-dash");
        }
    }
    #endregion

    #region Get Records
    private async Task _getHoursCorrectionsRequests()
    {
        _dailyTimeRequest.Clear();
        _dailyTimeRequest = await _dataProvider.WorkingTime.GetDailyTimeRequests();
    }

    private int _hoursCorrectionCount = 0;
    private async Task _getHoursCorrectionRequestsCount()
    {
        _hoursCorrectionCount = await _dataProvider.WorkingTime.GetDailyTimeRequestsCount();
    }

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
            Logger.LogError($"Exception Dashboard._getTeamsRequestedUsers(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
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
            Logger.LogError($"Exception Dashboard._getIssues(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }
    }

    private async Task _checkIfHasAnySelections()
    {
        await _disciplinesComp.CheckIfHasSelections();
        await _deliverablesComp.CheckIfHasSelections();
        await _supportiveWorksComp.CheckIfHasSelections();
    }

    private async Task _getUserTotalHoursThisMonth()
    {
        _userTotalHoursThisMonth = await _dataProvider.Users.GetUserTotalHoursThisMonth(_sharedAuthData.LogedUser.Id);
    }

    public async Task _getClients()
    {
        _selectedClient = null;
        _selectedOffer = null;
        _selectedProject = null;
        _resetSelectedDisciplines();;
        _resetSelectedDeliverable();
        _resetSelectedSupportiveWoprk();
        _clearRecordsDisciplines();
        _clearRecordsDeliverables();
        _clearRecordsSupportiveWoprk();

        try
        {
            var dtos = await _dataProvider.Clients.GetAll();
            var vms = Mapper.Map<List<ClientVM>>(dtos);
            _clients.Clear();
            vms.ForEach(_clients.Add);
        }
        catch (Exception ex)
        {
            Logger.LogError($"Exception Dashboard._getClients(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }
        _startLoading = false;
    }

    public async Task _getOffers(bool reset = true)
    {
        if (reset)
        {
            _selectedOffer = null;
            _selectedProject = null;
            _resetSelectedDisciplines();;
            _resetSelectedDeliverable();
            _resetSelectedSupportiveWoprk();
            _clearRecordsDisciplines();
            _clearRecordsDeliverables();
            _clearRecordsSupportiveWoprk();
        }

        try
        {
            var dtos = await _dataProvider.Offers.GetAllByLead(_selectedClient?.Id ?? 0);
            var vms = Mapper.Map<List<OfferVM>>(dtos);
            _offers.Clear();
            vms.ForEach(_offers.Add);
        }
        catch (Exception ex)
        {
            Logger.LogError($"Exception Dashboard._getOffers(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }
        _startLoading = false;
    }

    public async Task _getProjects(bool? active = null)
    {
        _selectedProject = null;
        _resetSelectedDisciplines();;
        _resetSelectedDeliverable();
        _resetSelectedSupportiveWoprk();
        _clearRecordsDisciplines();
        _clearRecordsDeliverables();
        _clearRecordsSupportiveWoprk();

        try
        {
            // Get Projects of last month
            List<ProjectDto> projectsDto =
                (await _dataProvider.Projects
                    .GetProjectsWithFallback(
                        _sharedAuthData.LogedUser.Id,
                        offerId: _selectedOffer?.Id ?? 0,
                        active: active
                )).ToList<ProjectDto>();

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
            Logger.LogError($"Exception Dashboard._getProjects(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }
        _startLoading = false;
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
            Logger.LogError($"Exception Dashboard._getProjectManagers(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
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
            Logger.LogError($"Exception Dashboard.GetRoleId(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
            return 0;
        }
    }

    private long GetProjectMenHours(int projecId) =>
        _dataProvider.Projects.GetMenHours(projecId);
    #endregion

    #region When Row Selected Update Data
    private async Task OnSelectClient(int clientId)
    {
        if (clientId == 0 || clientId == _selectedClient?.Id) return;

        var client = _clients.FirstOrDefault(p => p.Id == clientId);
        _offers.Clear();
        _projects.Clear();
        _clearRecordsDeliverables();
        _clearRecordsSupportiveWoprk();
        _clearRecordsDisciplines();
        _selectedClient = client;
        _selectedOffer = null;
        _selectedProject = null;
        _resetSelectedDisciplines();;
        _resetSelectedDeliverable();
        _resetSelectedSupportiveWoprk();

        await _getOffers();

        StateHasChanged();
    }

    private async Task OnSelectOffer(int offerId)
    {
        if (offerId == 0 || offerId == _selectedOffer?.Id) return;

        var offer = _offers.FirstOrDefault(p => p.Id == offerId);
        _projects.Clear();
        _clearRecordsDeliverables();
        _clearRecordsSupportiveWoprk();
        _clearRecordsDisciplines();
        _selectedOffer = offer;
        _selectedProject = null;
        _resetSelectedDisciplines();;
        _resetSelectedDeliverable();
        _resetSelectedSupportiveWoprk();

        await _getProjects(active: true);

        StateHasChanged();
    }

    private async Task OnSelectProject(int projectId, bool force = false)
    {
        if (projectId == 0 || projectId == _selectedProject?.Id && !force) return;

        var project = _projects.FirstOrDefault(p => p.Id == projectId);
        _clearRecordsDeliverables();
        _clearRecordsSupportiveWoprk();
        _clearRecordsDisciplines();
        _selectedProject = project;
        _resetSelectedDisciplines();;
        _resetSelectedDeliverable();
        _resetSelectedSupportiveWoprk();


        await _disciplinesComp.GetRecords(_selectedProject.Id);
        

        await _checkIfHasAnySelections();

        StateHasChanged();
    }

    private async void OnSelectDiscipline(int disciplineId)
    {
        if (disciplineId == 0)
            return;

        await _deliverablesComp.GetRecords(disciplineId);
        await _supportiveWorksComp.GetRecords(disciplineId);
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
        if (!editMyHours)
        {
            return;
        }

        isWorkingMode = false;
        remainingTime = StopTimer();

        await _editHoursCompoment.Refresh(remainingTime);

        _endWorkDialog.Show();
        _isEndWorkDialogOdepened = true;
    }

    private void _onTimeTimeChanged(TimeSpan timeSpan)
    {
        remainingTime = timeSpan;
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
                await ShowInformationAsync("You need to update your working today's hours!");
                return;
            }

            _startLoading = true;

            await _editHoursCompoment.Save();

            _resetChangesDeliverables();
            _resetChangesSupportiveWoprk();

            await _getProjects();

            // Clear Timer From this User
            TimerService.ClearTimer(_sharedAuthData.LogedUser.Id.ToString());

            await _getUserTotalHoursThisMonth();

            StateHasChanged();
        }
        catch (Exception ex)
        {
            Logger.LogError($"Exception Dashboard._endWorkDialogAccept(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }

        _startLoading = false;
    }

    public void _endWorkDialogCansel()
    {
        _clientsChanged.Clear();
        _offersChanged.Clear();
        _projectsChanged.Clear();
        _resetChangesDeliverables();
        _resetChangesSupportiveWoprk();

        _selectedClient = null;
        _selectedOffer = null;
        //_selectedProject = null;
        //_resetSelectedDisciplines();;
        //_resetSelectedDeliverable();
        //_resetSelectedSupportiveWoprk();

        StartWorkClick();
        _endWorkDialog.Hide();
        _isEndWorkDialogOdepened = false;
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
            bool neaSelected = _selectedProject.Id != project.Id;

            if (neaSelected)
                _selectedProject = project;

            await _getProjectManagers();
            if (neaSelected)
            {
                await OnSelectProject(_selectedProject.Id, true);
                StateHasChanged();
            }

            _addPMDialog.Show();
            _isAddPMDialogOdepened = true;
        }
        catch (Exception ex)
        {
            Logger.LogError($"Exception Dashboard.OnProjectAssignClick(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }
    }

    public async Task _addPMDialogAccept()
    {
        try
        {
            var updated = _selectedProject.Clone() as ProjectVM;

            var projectIndex = _projects.IndexOf(_selectedProject);

            var pmDto = await _dataProvider.Users.Get(_selectedPmId);

            if (pmDto == null)
                return;

            var pm = Mapping.Mapper.Map<User>(pmDto);
            updated.PmName = pm != null ? $"{pm.LastName} {pm.FirstName}" : null;
            updated.ProjectManagerId = _selectedPmId;
            await _dataProvider.Projects.Update(Mapper.Map<ProjectDto>(updated));
            updated.ProjectManager = pm;

            var forDelete = _projects.FirstOrDefault(p => p.Id == updated.Id);
            if (forDelete != null)
                _projects.Remove(forDelete);

            _projects.Insert(projectIndex, updated);

            _addPMDialog.Hide();
            _isAddPMDialogOdepened = false;
        }
        catch (Exception ex)
        {
            Logger.LogError($"Exception Dashboard._addPMDialogAccept(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }
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
        if (!isWorkingMode)
        {
            await ShowInformationAsync("You need to have started your work to see the users requests!");
            return;
        }
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

    #region Display Hours Correction Request
    private async Task OpenHoursCorrectionRequestsClick(MouseEventArgs e)
    {
        if (!isWorkingMode)
        {
            await ShowInformationAsync("You need to have started your work to see and accept users hours corrections requests!");
            return;
        }
        _displayHoursCorrectionRequestsDialog.Show();
        _isDisplayHoursCorrectionRequestsDialogOdepened = true;
    }

    private async Task CloseHoursCorrectionRequestsClick()
    {
        if (_isDisplayHoursCorrectionRequestsDialogOdepened)
        {
            _displayHoursCorrectionRequestsDialog.Hide();
            _isDisplayHoursCorrectionRequestsDialogOdepened = false;
            await _getHoursCorrectionRequestsCount();
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

    private async Task AddProject()
    {
        _selectedProject = null;
        _resetSelectedDisciplines();;
        _resetSelectedDeliverable();
        _resetSelectedSupportiveWoprk();
        _addEditProjectDialog.Show();
        _isAddEditProjectDialogOdepened = true;

        Offer offer = null;
        if (!string.IsNullOrEmpty(selectedOfferFilterId))
        {
            var offerId = Convert.ToInt32(selectedOfferFilterId);
            var dto = await _dataProvider.Offers.Get(offerId);
            offer = Mapping.Mapper.Map<Offer>(dto);
        }

        await projectCompoment.Prepair(new ProjectVM()
        {
            Stage = null,
            StageId = 0,
            Offer = offer,
            OfferId = offer != null ? offer.Id : 0,
        });
    }

    private async Task EditProject()
    {
        _resetSelectedDisciplines();;
        _resetSelectedDeliverable();
        _resetSelectedSupportiveWoprk();
        _addEditProjectDialog.Show();
        _isAddEditProjectDialogOdepened = true;
        await projectCompoment.Prepair();
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

            var newProject = projectCompoment.GetProject();

            if (_projects.Any(p => p.Id == newProject.Id))
                _projects.Remove(newProject);

            // Order by DeaLine and add new one on top
            var sortedProjects = _projects.OrderByDescending(p => p.DeadLine).ToList();
            sortedProjects.Insert(0, newProject);
            _projects = new ObservableCollection<ProjectVM>(sortedProjects);

            _addEditProjectDialog.Hide();
            _isAddEditProjectDialogOdepened = false;

            StateHasChanged();
        }
    }

    public void _addEditProjectDialogCansel()
    {
        _addEditProjectDialog.Hide();
        _isAddEditProjectDialogOdepened = false;
    }
    #endregion

    #region Correct Hours Dialog
    private async Task _correctHours()
    {
        if (!isWorkingMode)
        {
            await ShowInformationAsync("You need to have started your work to correct hours!");
            return;
        }
        _correctHoursDialog.Show();
        _isCorrectHoursDialogOdepened = true;
    }

    private async Task _onCorrectHoursClose()
    {
        if (_isCorrectHoursDialogOdepened)
        {
            _correctHoursDialog.Hide();
            _isCorrectHoursDialogOdepened = false;
        }
    }

    private async Task _onHoursRequestChange()
    {
        await _getHoursCorrectionsRequests();
        await _getHoursCorrectionRequestsCount();
        await _getUserTotalHoursThisMonth();
    }
    #endregion

    #region Delete Dialog Actions
    private async Task OnDeleteAccept()
    {
        if (_isDeleteDialogOdepened)
        {
            //switch (_deleteObj)
            //{
            //    case nameof(_selectedProject):
            //        await _dataProvider.Projects.Delete(_selectedProject.Id);
            //        _projects.Remove(_selectedProject);
            //        _selectedProject = null;
            //        break;
            //    case nameof(_selectedDiscipline):
            //        await _dataProvider.Disciplines.Delete(_selectedDiscipline.Id);
            //        _disciplines.Remove(_selectedDiscipline);
            //        _resetSelectedDisciplines();;
            //        break;
            //    case nameof(_selectedDeliverable):
            //        await _dataProvider.Deliverables.Delete(_selectedDeliverable.Id);
            //        _deliverables.Remove(_selectedDeliverable);
            //        _selectedDeliverable = null;
            //        break;
            //    case nameof(_selectedSupportiveWork):
            //        await _dataProvider.SupportiveWorks.Delete(_selectedSupportiveWork.Id);
            //        _supportiveWorks.Remove(_selectedSupportiveWork);
            //        _selectedSupportiveWork = null;
            //        break;
            //}

            //_deleteDialogMsg = "";
            //_deleteObj = null;
            //_deleteDialog.Hide();
            //_isDeleteDialogOdepened = false;

            //StateHasChanged();
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
    private string _activeid = "tab-home";
    #endregion

    #region Invoice
    private InvoiceDetailed _invoiceIncomeDetailedRef;
    private InvoiceDetailed _invoiceExpenseDetailedRef;
    private Payments _invoiceIncomePaymentsRef;
    private Payments _invoiceExpensePaymentsRef;

    private async Task _onSelectedIncomeInvoice(InvoiceVM invoice)
    {
        if (invoice == null)
            return;

        _selectedIncomeInvoice = invoice;
        if (_invoiceIncomeDetailedRef != null)
        {
            await _invoiceIncomeDetailedRef.Prepair(_selectedIncomeInvoice, true);
            await _invoiceIncomePaymentsRef.Prepair(_selectedIncomeInvoice.Id);
        }
    }

    private async Task _onSaveIncomeInvoice(InvoiceVM invoice)
    {
        if (_invoiceIncomesListRef != null)
        {
            await _invoiceIncomesListRef.Refresh();
            await _invoiceIncomeDetailedRef.Prepair();
            await _invoiceIncomePaymentsRef.Prepair(_selectedIncomeInvoice.Id);
        }

    }

    private async Task _onSelectedExpenseInvoice(InvoiceVM invoice)
    {
        if (invoice == null)
            return;

        _selectedExpenseInvoice = invoice;
        if (_invoiceExpenseDetailedRef != null)
        {
            await _invoiceExpenseDetailedRef.Prepair(_selectedExpenseInvoice, true);
            await _invoiceExpensePaymentsRef.Prepair(_selectedExpenseInvoice.Id);
        }
    }

    private async Task _onSaveExpenseInvoice(InvoiceVM invoice)
    {
        if (_invoiceExpensesListRef != null)
        {
            await _invoiceExpensesListRef.Refresh();
            await _invoiceExpenseDetailedRef.Prepair();
            await _invoiceExpensePaymentsRef.Prepair(_selectedExpenseInvoice.Id);
        }

    }
    #endregion

    private async Task ExportProjectsToCSV()
    {
        var date = DateTime.Today;
        var fileName = $"Projects-{date.ToEuropeFormat()}.csv";
        var data = _projects.ToList();
        if (_projects.Count > 0)
        {
            string csvContent = Data.GetCsvContent(_projects);
            await MicrosoftTeams.DownloadCsvFile(fileName, csvContent);
        }
    } 

    #region Database Manipulation
    bool _backUpLoading = false;
    private async Task BackUpDb()
    {
        _backUpLoading = true;
        StateHasChanged();

        try
        {
            Dictionary<string, string> csvs = await DatabaseBackupService.DatabaseToCSV();


            if (csvs != null && csvs.Count > 0)
            {
                var zipBytes = await DatabaseBackupService.CsvToZipBytes(csvs);
                var base64Zip = Convert.ToBase64String(zipBytes);

                var dateTime = DateTime.Now;
                var fileName = $"{DatabaseBackupService.DatabaseName}_{dateTime.ToEuropeFormat()}.zip";
                await MicrosoftTeams.DownloadZipFile(fileName, base64Zip);
            }
            else
            {
                await ShowInformationAsync($"\n\ncsvs == null || csvs.Count == 0\n\n");
            }
        }
        catch (Exception ex)
        {
            Logger.LogError($"Exception Dashboard.BackUpDb(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }

        _backUpLoading = false;
        StateHasChanged();
    }

    private InputFile fileRestoreDB;
    bool _restoreLoading = false;
    private async Task RestoreDb(InputFileChangeEventArgs e)
    {
        _restoreLoading = true;
        StateHasChanged();

        var file = e.File;
        var filePath = file.Name;
        var fileType = file.ContentType;

        if (!(fileType?.Contains("zip") ?? false))
        {
            await ShowInformationAsync("Uploaded file is not a ZIP archive.");

            _restoreLoading = false;
            StateHasChanged();

            return;
        }

        try
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.OpenReadStream().CopyToAsync(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                var data = await DatabaseBackupService.ZipStreamToCsv(memoryStream);
                await DatabaseBackupService.SaveToDB(data);
            }
        }
        catch (Exception ex)
        {
            Logger.LogError($"Exception Dashboard.RestoreDb(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }

        _restoreLoading = false;
        StateHasChanged();

        await Refresh();
    }
    private async Task TriggerRestoreDbInport()
    {
        var element = fileRestoreDB.Element;
        await MicrosoftTeams.TriggerFileInputClick(element);
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
