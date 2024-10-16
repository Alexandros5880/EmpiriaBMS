using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Components.Home.Header.Hours;
using EmpiriaBMS.Front.Services;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Enum;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.CodeAnalysis;
using Microsoft.Fast.Components.FluentUI;
using Microsoft.JSInterop;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.Home.Header;

public partial class HomeHeadComp : IDisposable
{
    [Parameter]
    public EventCallback<bool> IsWorkingModeChanged { get; set; }

    [Parameter]
    public EventCallback OnRefresh { get; set; }

    #region Authorization Properties
    bool isEmployee => _sharedAuthData.IsLogedUserEmployee;
    bool editMyHours => _sharedAuthData.PermissionOrds.Contains(2);
    public bool seeMyHours => _sharedAuthData.PermissionOrds.Contains(8);
    bool seeTeamsRequestedUsers => _sharedAuthData.Permissions.Any(p => p.Ord == 28);
    bool seeBackupDatabase => _sharedAuthData.Permissions.Any(p => p.Ord == 35);
    bool seeRestoreDatabase => _sharedAuthData.Permissions.Any(p => p.Ord == 36);
    bool canApproveTimeRequests => _sharedAuthData.Permissions.Any(p => p.Ord == 39);
    #endregion

    private bool disposedValue;
    public string CurentDate => $"{DateTime.Today.Day}/{DateTime.Today.Month}/{DateTime.Today.Year}";
    private double _userTotalHoursThisMonth = 0;
    bool _refreshLoading = true;
    private bool _loading = false;

    #region Dialogs
    // Work End Dialog
    private FluentDialog _endWorkDialog;
    private bool _isEndWorkDialogOdepened = false;
    private bool _isEndWorkAcceptDialogDisabled => remainingTime.Hours != 0 || remainingTime.Minutes != 0;

    // On Add/Edit Issues Dialog
    private FluentDialog _displayIssuesDialog;
    private bool _isDisplayIssuesDialogOdepened = false;

    // On Corrext Hours
    private FluentDialog _correctHoursDialog;
    private bool _isCorrectHoursDialogOdepened = false;

    // On Add/Edit Hours Correction rEQUESTS Dialog
    private FluentDialog _displayHoursCorrectionRequestsDialog;
    private bool _isDisplayHoursCorrectionRequestsDialogOdepened = false;

    // On Add/Edit TeamsRequestedUsers Dialog
    private FluentDialog _displayTeamsRequestedUsersDialog;
    private bool _isDisplayTeamsRequestedUsersDialogOdepened = false;
    #endregion

    protected override void OnInitialized()
    {
        // timer = used only to run UpdateElapsedTime() every one second
        timer = new Timer(_ => UpdateElapsedTime(), null, 0, 1000);
        IsWorkingMode = TimerService.IsRunning(_sharedAuthData.LogedUser.Id.ToString());
        IsWorkingModeChanged.InvokeAsync(IsWorkingMode);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _loading = true;
            await _getTeamsRequestedUsersCount();
            await _getUserTotalHoursThisMonth();
            if (canApproveTimeRequests)
                await _getHoursCorrectionRequestsAwaitingCount();
            await _countIssues();
            _loading = false;
            StateHasChanged();
        }
    }

    public async Task Refresh()
    {
        _refreshLoading = true;
        await _getTeamsRequestedUsersCount();
        await _getUserTotalHoursThisMonth();

        if (canApproveTimeRequests)
        {
            await _getHoursCorrectionRequestsAwaitingCount();
        }
        _refreshLoading = false;
        StateHasChanged();

        await OnRefresh.InvokeAsync();
    }

    #region Timer
    Timer timer;
    bool IsWorkingMode = false;
    TimeSpan elapsedTime = TimeSpan.Zero;
    TimeSpan timePaused = TimeSpan.Zero;
    TimeSpan remainingTime = TimeSpan.Zero;
    private EditUsersHours _editHoursCompoment;
    
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

    #region Correct Hours Dialog
    private async Task _correctHours()
    {
        if (!IsWorkingMode)
        {
            await ShowInformationAsync("You need to have started your work to correct hours!");
            return;
        }
        _correctHoursDialog.Show();
        _isCorrectHoursDialogOdepened = true;
    }

    private void _onCorrectHoursClose()
    {
        if (_isCorrectHoursDialogOdepened)
        {
            _correctHoursDialog.Hide();
            _isCorrectHoursDialogOdepened = false;
        }
    }

    private async Task _onHoursRequestChange()
    {
        await _getHoursCorrectionRequestsAwaitingCount();
        await _getUserTotalHoursThisMonth();
    }
    #endregion

    #region Display Hours Correction Request
    private async Task OpenHoursCorrectionRequestsClick(MouseEventArgs e)
    {
        if (!IsWorkingMode)
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
            await _getHoursCorrectionRequestsAwaitingCount();
        }
    }
    #endregion

    #region Start Stop Work Actions
    private void StartWorkClick()
    {
        IsWorkingMode = true;
        StartTimer();
        IsWorkingModeChanged.InvokeAsync(IsWorkingMode);
        StateHasChanged();
    }

    private async Task StopWorkClick()
    {
        if (!editMyHours)
        {
            return;
        }

        IsWorkingMode = false;
        remainingTime = StopTimer();

        await _editHoursCompoment.Refresh(remainingTime);

        _endWorkDialog.Show();
        _isEndWorkDialogOdepened = true;

        IsWorkingModeChanged.InvokeAsync(IsWorkingMode);
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

            _loading = true;

            await _editHoursCompoment.Save();

            //_resetChangesDeliverables();
            //_resetChangesSupportiveWoprk();

            //await _getRecordsProjects(_selectedOffer?.Id ?? 0);

            // Clear Timer From this User
            TimerService.ClearTimer(_sharedAuthData.LogedUser.Id.ToString());

            await _getUserTotalHoursThisMonth();

            await Refresh();

            StateHasChanged();
        }
        catch (Exception ex)
        {
            Logger.LogError($"Exception HomeHeadComp._endWorkDialogAccept(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }

        _loading = false;
    }

    public void _endWorkDialogCansel()
    {
        //_resetChangesProjects();
        //_resetChangesDeliverables();
        //_resetChangesSupportiveWoprk();

        //_selectedClient = null;
        //_selectedOffer = null;

        StartWorkClick();
        _endWorkDialog.Hide();
        _isEndWorkDialogOdepened = false;
    }
    #endregion

    #region Display Issues
    private async Task OpenIssuesClick(MouseEventArgs e)
    {
        if (!IsWorkingMode)
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
            await _countIssues();
        }
    }
    #endregion

    #region Display TeamsRequestedUsers
    private async Task OpenTeamsRequestedUsersClick(MouseEventArgs e)
    {
        if (!IsWorkingMode)
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
            await _getTeamsRequestedUsersCount();
        }
    }
    #endregion

    #region Database Manipulation
    bool _backUp_loading = false;
    private async Task BackUpDb()
    {
        //var fileUrl = _dataProvider.Database.DownloadLink;
        //await JS.InvokeVoidAsync("window.open", fileUrl, "_blank");

        _backUp_loading = true;
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
            Logger.LogError($"Exception HomeHeadComp.BackUpDb(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }

        _backUp_loading = false;
        StateHasChanged();
    }

    private InputFile fileRestoreDB;
    bool _restore_loading = false;
    private async Task RestoreDb(InputFileChangeEventArgs e)
    {
        _restore_loading = true;
        StateHasChanged();

        var file = e.File;
        var filePath = file.Name;
        var fileType = file.ContentType;

        if (!(fileType?.Contains("zip") ?? false))
        {
            await ShowInformationAsync("Uploaded file is not a ZIP archive.");

            _restore_loading = false;
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
            Logger.LogError($"Exception HomeHeadComp.RestoreDb(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }

        _restore_loading = false;
        StateHasChanged();

        await Refresh();
    }
    private async Task TriggerRestoreDbInport()
    {
        var element = fileRestoreDB.Element;
        await MicrosoftTeams.TriggerFileInputClick(element);
    }
    #endregion

    #region Get Records
    private int _issuesCounter = 0;
    private async Task _countIssues()
    {
        try
        {
            _issuesCounter = await _dataProvider.Users.CountOpenIssues((int)_sharedAuthData.LogedUser.Id);
        }
        catch (Exception ex)
        {
            Logger.LogError($"Exception HomeHeadComp._countIssues(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }
    }

    private int _hoursCorrectionCount = 0;
    private async Task _getHoursCorrectionRequestsAwaitingCount()
    {
        _hoursCorrectionCount = await _dataProvider.WorkingTime.GetDailyTimeRequestsCount(DailyTimeState.AWAITING);
    }

    private async Task _getUserTotalHoursThisMonth()
    {
        _userTotalHoursThisMonth = await _dataProvider.Users.GetUserTotalHoursThisMonth(_sharedAuthData.LogedUser.Id);
    }

    private int _usersRequestCount = 0;
    private async Task _getTeamsRequestedUsersCount()
    {
        try
        {
            _usersRequestCount = await _dataProvider.TeamsRequestedUsers.Count();
        }
        catch (Exception ex)
        {
            Logger.LogError($"Exception HomeHeadComp._getTeamsRequestedUsersCount(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
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
