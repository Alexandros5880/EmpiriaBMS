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
using EmpiriaBMS.Front.Components.Home.Projects;
using EmpiriaBMS.Front.Components.Home.Issues;
using DevComp = EmpiriaBMS.Front.Components.Home.Deliverables;
using DiscComp = EmpiriaBMS.Front.Components.Home.Disciplines;
using SWComp = EmpiriaBMS.Front.Components.Home.SupportiveWorks;
using projComp = EmpiriaBMS.Front.Components.Home.Projects;
using Microsoft.CodeAnalysis.CSharp;

namespace EmpiriaBMS.Front.Components;
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

    

    #region Lists    
    private ObservableCollection<IssueVM> _issues = new ObservableCollection<IssueVM>();
    private ObservableCollection<TeamsRequestedUserVM> _teamsRequestedUsers = new ObservableCollection<TeamsRequestedUserVM>();
    private Dictionary<DailyTimeTypes, List<DailyTimeRequest>> _dailyTimeRequest = new Dictionary<DailyTimeTypes, List<DailyTimeRequest>>();
    #endregion

    #region Selected Models
    private ClientVM _selectedClient = new ClientVM();
    private OfferVM _selectedOffer = new OfferVM();
    private InvoiceVM _selectedIncomeInvoice = new InvoiceVM();
    private InvoiceVM _selectedExpenseInvoice = new InvoiceVM();
    #endregion

    #region Dialogs
    // Work End Dialog
    private FluentDialog _endWorkDialog;
    private bool _isEndWorkDialogOdepened = false;
    private bool _isEndWorkAcceptDialogDisabled => remainingTime.Hours != 0 || remainingTime.Minutes != 0;

    // On Add/Edit Issues Dialog
    private FluentDialog _displayIssuesDialog;
    private bool _isDisplayIssuesDialogOdepened = false;

    // On Add/Edit TeamsRequestedUsers Dialog
    private FluentDialog _displayTeamsRequestedUsersDialog;
    private bool _isDisplayTeamsRequestedUsersDialogOdepened = false;

    // On Add/Edit Hours Correction rEQUESTS Dialog
    private FluentDialog _displayHoursCorrectionRequestsDialog;
    private bool _isDisplayHoursCorrectionRequestsDialogOdepened = false;

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
            StateHasChanged();
        }
    }

    public async Task Refresh()
    {
        _refreshLoading = true;
        await _getTeamsRequestedUsers();
        await _getUserTotalHoursThisMonth();
        await _getIssues();
        await _getRecordsProjects(_selectedOffer?.Id ?? 0, true);
        if (canApproveTimeRequests)
        {
            await _getHoursCorrectionsRequests();
            await _getHoursCorrectionRequestsCount();
        }
        _refreshLoading = false;
        StateHasChanged();
    }

    #region Offers Table Compoment
    private OffersComp _offersComp;
    #endregion

    #region Clients Table Compoment
    private async Task _onClientResultChanged(ClientVM client)
    {
        if (client.Result == ClientResult.SUCCESSFUL)
        {
            await MicrosoftTeams.ScrollToElement("offers-table-dash");
        }
    }
    #endregion

    #region Projects Table Compoment
    private projComp.Projects _projectsComp;

    private async Task OnSelectProject(int projectId)
    {
        if (projectId == 0)
            return;

        _clearRecordsDisciplines();
        _clearRecordsDeliverables();
        _clearRecordsSupportiveWoprk();

        _resetSelectedDisciplines(); ;
        _resetSelectedDeliverable();
        _resetSelectedSupportiveWoprk();

        await _getRecordsDisciplines(projectId);

        await _checkIfHasAnySelections();

        StateHasChanged();
    }

    private void OnEditProject()
    {
        _resetSelectedDisciplines(); ;
        _resetSelectedDeliverable();
        _resetSelectedSupportiveWoprk();
    }

    private async Task _getRecordsProjects(int offerId, bool active = false)
    {
        if (_projectsComp != null)
            await _projectsComp.GetRecords(offerId, active);
    } 

    private void _resetSelectedProjects()
    {
        if (_projectsComp != null)
            _projectsComp.ResetSelection();
    }

    private void _clearRecordsProjects()
    {
        if (_projectsComp != null)
            _projectsComp.ClearRecords();
    }

    private void _resetChangesProjects()
    {
        if (_projectsComp != null)
            _projectsComp.ResetChanges();
    }
    #endregion

    #region Disciplines Table Compoment
    private DiscComp.Disciplines _disciplinesComp;

    private async void OnSelectDiscipline(int disciplineId)
    {
        if (disciplineId == 0)
            return;

        await _getRecordsDeliverables(disciplineId);
        await _getRecordsSupportiveWorks(disciplineId);
    }

    private async Task _getRecordsDisciplines(int projectId)
    {
        if (_disciplinesComp != null)
            await _disciplinesComp.GetRecords(projectId);
    }

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

    private async Task _getRecordsDeliverables(int disciplineId)
    {
        if (_deliverablesComp != null)
            await _deliverablesComp.GetRecords(disciplineId);
    }

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

    private async Task _getRecordsSupportiveWorks(int disciplineId)
    {
        if (_supportiveWorksComp != null)
            await _supportiveWorksComp.GetRecords(disciplineId);
    }

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

            await _getRecordsProjects(_selectedOffer?.Id ?? 0);

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
        _resetChangesProjects();
        _resetChangesDeliverables();
        _resetChangesSupportiveWoprk();

        _selectedClient = null;
        _selectedOffer = null;

        StartWorkClick();
        _endWorkDialog.Hide();
        _isEndWorkDialogOdepened = false;
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
            //        _resetSelectedProjects();
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
