using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Enum;
using EmpiriaBMS.Front.Components.Invoices;
using EmpiriaBMS.Front.Components.KPIS.Base;
using ComReports = EmpiriaBMS.Front.Components.Reports;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Enum;
using Microsoft.CodeAnalysis;
using OffersComp = EmpiriaBMS.Front.Components.Home.Offers.Offers;
using DevComp = EmpiriaBMS.Front.Components.Home.Deliverables;
using DiscComp = EmpiriaBMS.Front.Components.Home.Disciplines;
using SWComp = EmpiriaBMS.Front.Components.Home.SupportiveWorks;
using projComp = EmpiriaBMS.Front.Components.Home.Projects;
using Microsoft.CodeAnalysis.CSharp;
using EmpiriaBMS.Front.Components.Home.Header;
using ClientsComp = EmpiriaBMS.Front.Components.Home.Clients;
using Microsoft.AspNetCore.Components;

namespace EmpiriaBMS.Front.Components.Home;

public partial class Home
{
    #region Authorization Properties
    bool seeClientsOnDashboard => _sharedAuthData.Permissions.Any(p => p.Ord == 38);
    bool seeOffers => _sharedAuthData.Permissions.Any(p => p.Ord == 24);

    #endregion

    [Parameter]
    public EventCallback<bool> IsWorkingModeChanged { get; set; }

    // General Fields
    bool _runInTeams = true;
    bool _isWorkingMode = false;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _runInTeams = await MicrosoftTeams.IsInTeams();
        }
    }

    private void _onWorkingModeChanged(bool workMode)
    {
        _isWorkingMode = workMode;
        IsWorkingModeChanged.InvokeAsync(_isWorkingMode);
        StateHasChanged();
    }

    private async Task _onRefresh()
    {
        var refreshTasks = new List<Task>();

        if (_clientsComp != null)
            refreshTasks.Add(_clientsComp.Refresh());

        if (_offersComp != null)
            refreshTasks.Add(_offersComp.Refresh());

        if (_projectsComp != null)
            refreshTasks.Add(_projectsComp.Refresh());

        if (_disciplinesComp != null)
            refreshTasks.Add(_disciplinesComp.Refresh());

        if (_deliverablesComp != null)
            refreshTasks.Add(_deliverablesComp.Refresh());

        if (_supportiveWorksComp != null)
            refreshTasks.Add(_supportiveWorksComp.Refresh());

        await Task.WhenAll(refreshTasks);
    }

    #region Header Compoment
    private HomeHeadComp _headerComp;
    #endregion

    #region Offers Table Compoment
    private OffersComp _offersComp;
    #endregion

    #region Clients Table Compoment
    private ClientsComp.Clients _clientsComp;
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

    private async Task _checkIfHasAnySelections()
    {
        await _disciplinesComp.CheckIfHasSelections();
        await _deliverablesComp.CheckIfHasSelections();
        await _supportiveWorksComp.CheckIfHasSelections();
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

}
