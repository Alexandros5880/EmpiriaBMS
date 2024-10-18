using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.ReturnModels;
using EmpiriaBMS.Front.Services;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.Home.Header.Hours;

public partial class PassWorkedHours
{
    [Parameter]
    public bool DisplayTitle { get; set; } = true;

    [Parameter]
    public TimeSpan RemainingTime { get; set; }

    [Parameter]
    public EventCallback<TimeSpan> OnTimeChanged { get; set; }

    private DateTime _defaultDate = DateTime.UtcNow;
    private UserVM _loggedUser;

    #region Authorization Properties
    bool seeAdmin => _sharedAuthData.Permissions.Any(p => p.Ord == 7);
    bool getAllDisciplines => _sharedAuthData.Permissions.Any(p => p.Ord == 9);
    bool getAllDeliverables => _sharedAuthData.Permissions.Any(p => p.Ord == 10);
    bool workOnProject => _sharedAuthData.Permissions.Any(p => p.Ord == 31);
    bool workOnOffers => _sharedAuthData.Permissions.Any(p => p.Ord == 32);
    bool workOnClients => _sharedAuthData.Permissions.Any(p => p.Ord == 33);
    #endregion

    bool _startLoading = true;

    private UserTimes _editLogedUserTimes = new UserTimes()
    {
        DailyTime = TimeSpan.Zero,
        PersonalTime = TimeSpan.Zero,
        TrainingTime = TimeSpan.Zero,
        CorporateEventTime = TimeSpan.Zero,
    };

    // With General Time
    private bool _hasChanged = false;

    // Without General Time
    private bool _hasChanges => _clientsChanged.Any() ||
            _offersChanged.Any() ||
            _projectsChanged.Any() ||
            _disciplinesChanged.Any() ||
            _deliverablesChanged.Any() ||
            _supportiveWorkChanged.Any();

    #region Selections Lists
    private ObservableCollection<ClientVM> _clients = new ObservableCollection<ClientVM>();
    private ObservableCollection<OfferVM> _offers = new ObservableCollection<OfferVM>();
    private ObservableCollection<ProjectVM> _projects = new ObservableCollection<ProjectVM>();
    private ObservableCollection<DisciplineVM> _disciplines = new ObservableCollection<DisciplineVM>();
    private ObservableCollection<DeliverableVM> _deliverables = new ObservableCollection<DeliverableVM>();
    private ObservableCollection<SupportiveWorkVM> _supportiveWork = new ObservableCollection<SupportiveWorkVM>();
    #endregion

    #region Selected Models
    private ClientVM _selectedClient = new ClientVM();
    private OfferVM _selectedOffer = new OfferVM();
    private ProjectVM _selectedProject = new ProjectVM();
    private DisciplineVM _selectedDiscipline = new DisciplineVM();
    private DeliverableVM _selectedDeliverable = new DeliverableVM();
    private SupportiveWorkVM _selectedSupportiveWork = new SupportiveWorkVM();
    private DateTime _personalTimeDate;
    private DateTime _trainingTimeDate;
    private DateTime _corporateTimeDate;
    #endregion

    #region Changed Records Lists
    private List<ClientVM> _clientsChanged = new List<ClientVM>();
    private List<OfferVM> _offersChanged = new List<OfferVM>();
    private List<ProjectVM> _projectsChanged = new List<ProjectVM>();
    private List<DisciplineVM> _disciplinesChanged = new List<DisciplineVM>();
    private List<DeliverableVM> _deliverablesChanged = new List<DeliverableVM>();
    private List<SupportiveWorkVM> _supportiveWorkChanged = new List<SupportiveWorkVM>();
    #endregion

    #region Helped Selection Variables
    private bool _hasDisciplinesSelections = true;
    private bool _hasDeliverablessSelections = true;
    private bool _hasSapportiveWorksSelections = true;
    #endregion

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            RemainingTime = TimeSpan.Zero;
            _loggedUser = _sharedAuthData.LogedUser;
            _personalTimeDate = _defaultDate;
            _trainingTimeDate = _defaultDate;
            _corporateTimeDate = _defaultDate;
            await Refresh();
        }
    }

    public async Task Refresh(TimeSpan? timespan = null)
    {
        if (timespan != null)
            RemainingTime = (TimeSpan)timespan;

        _clients.Clear();
        _offers.Clear();
        _projects.Clear();
        _supportiveWork.Clear();
        _deliverables.Clear();
        _disciplines.Clear();

        if (workOnClients || seeAdmin)
            await _getClients();

        if (workOnOffers || seeAdmin)
            await _getOffers();

        if (!workOnClients && !workOnOffers)
            await _getProjects(active: true);

        _selectedClient = new ClientVM() { Id = 0 };
        _selectedOffer = new OfferVM() { Id = 0 };
        _selectedProject = new ProjectVM() { Id = 0 };
        _selectedDiscipline = new DisciplineVM() { Id = 0 };
        _selectedDeliverable = new DeliverableVM() { Id = 0 };
        _selectedSupportiveWork = new SupportiveWorkVM() { Id = 0 };

        StateHasChanged();
    }

    #region Get Records
    public async Task _getClients()
    {
        _selectedClient = null;
        _selectedOffer = null;
        _selectedProject = null;
        _selectedDiscipline = null;
        _selectedDeliverable = null;
        _selectedSupportiveWork = null;
        _disciplines.Clear();
        _deliverables.Clear();
        _supportiveWork.Clear();

        try
        {
            var dtos = await _dataProvider.Clients.GetAll();
            var vms = Mapper.Map<List<ClientVM>>(dtos);
            _clients.Clear();
            vms.ForEach(_clients.Add);
        }
        catch (Exception ex)
        {
            Logger.LogError($"Exception EditUsersHours._getClients(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }
    }

    public async Task _getOffers()
    {
        _selectedOffer = null;
        _selectedProject = null;
        _selectedDiscipline = null;
        _selectedDeliverable = null;
        _selectedSupportiveWork = null;
        _disciplines.Clear();
        _deliverables.Clear();
        _supportiveWork.Clear();

        try
        {
            var dtos = await _dataProvider.Offers.GetAllByLead(_selectedClient?.Id ?? 0);
            var vms = Mapper.Map<List<OfferVM>>(dtos);
            _offers.Clear();
            vms.ForEach(_offers.Add);
        }
        catch (Exception ex)
        {
            Logger.LogError($"Exception EditUsersHours._getOffers(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }
    }

    public async Task _getProjects(bool? active = null)
    {
        _selectedProject = null;
        _selectedDiscipline = null;
        _selectedDeliverable = null;
        _selectedSupportiveWork = null;
        _disciplines.Clear();
        _deliverables.Clear();
        _supportiveWork.Clear();

        var userId = _sharedAuthData.LogedUser.Id;

        try
        {
            // Get Projects of last month
            List<ProjectDto> projectsDto = (await _dataProvider.Projects
                .GetProjectsWithFallback(
                    userId,
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
            Logger.LogError($"Exception EditUsersHours._getProjects(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }
    }

    private async Task _checkIfHasAnySelections()
    {
        if (_selectedProject != null)
            _hasDisciplinesSelections = await _dataProvider.DisciplinesTypes.HasDisciplineTypesSelections(_selectedProject.Id);
        if (_selectedDiscipline != null)
        {
            _hasDeliverablessSelections = await _dataProvider.DeliverablesTypes.HasDeliverableTypesSelections(_selectedDiscipline.Id);
            _hasSapportiveWorksSelections = await _dataProvider.SupportiveWorksTypes.HasOtherTypesSelections(_selectedDiscipline.Id);
        }
    }
    #endregion

    #region On Time/DateTime Changed
    private async Task _onClientTimeChanged(ClientVM client, TimeSpan newTimeSpan)
    {
        // previusTime, updatedTime, RemainingTime

        var previusTime = client.Time;
        var updatedTime = newTimeSpan - previusTime;
        RemainingTime += (-updatedTime);

        client.Time = newTimeSpan;

        if (_clientsChanged.Any(d => d.Id == client.Id))
        {
            var d = _clientsChanged.FirstOrDefault(d => d.Id == client.Id);
            d.Time = client.Time;
        }
        else
            _clientsChanged.Add(client);

        _hasChanged = true;

        await OnTimeChanged.InvokeAsync(RemainingTime);

        StateHasChanged();
    }

    private async Task _onOfferTimeChanged(OfferVM offer, TimeSpan newTimeSpan)
    {
        // previusTime, updatedTime, RemainingTime

        var previusTime = offer.Time;
        var updatedTime = newTimeSpan - previusTime;
        RemainingTime += (-updatedTime);

        offer.Time = newTimeSpan;

        if (_offersChanged.Any(d => d.Id == offer.Id))
        {
            var d = _offersChanged.FirstOrDefault(d => d.Id == offer.Id);
            d.Time = offer.Time;
        }
        else
            _offersChanged.Add(offer);

        _hasChanged = true;

        await OnTimeChanged.InvokeAsync(RemainingTime);

        StateHasChanged();
    }

    private async Task _onProjectTimeChanged(ProjectVM project, TimeSpan newTimeSpan)
    {
        // previusTime, updatedTime, RemainingTime

        var previusTime = project.Time;
        var updatedTime = newTimeSpan - previusTime;
        RemainingTime += (-updatedTime);

        project.Time = newTimeSpan;

        if (_projectsChanged.Any(d => d.Id == project.Id))
        {
            var d = _projectsChanged.FirstOrDefault(d => d.Id == project.Id);
            d.Time = project.Time;
        }
        else
            _projectsChanged.Add(project);

        _hasChanged = true;

        await OnTimeChanged.InvokeAsync(RemainingTime);

        StateHasChanged();
    }

    private async Task _onDisciplineTimeChanged(DisciplineVM discipline, TimeSpan newTimeSpan)
    {
        // previusTime, updatedTime, RemainingTime

        var previusTime = discipline.Time;
        var updatedTime = newTimeSpan - previusTime;
        RemainingTime += (-updatedTime);

        discipline.Time = newTimeSpan;

        if (_disciplinesChanged.Any(d => d.Id == discipline.Id))
        {
            var d = _disciplinesChanged.FirstOrDefault(d => d.Id == discipline.Id);
            d.Time = discipline.Time;
        }
        else
            _disciplinesChanged.Add(discipline);

        _hasChanged = true;

        await OnTimeChanged.InvokeAsync(RemainingTime);

        StateHasChanged();
    }

    private async Task _onDeliverableTimeChanged(DeliverableVM draw, TimeSpan newTimeSpan)
    {
        // previusTime, updatedTime, RemainingTime

        var previusTime = draw.Time;
        var updatedTime = newTimeSpan - previusTime;
        RemainingTime += (-updatedTime);

        draw.Time = newTimeSpan;

        if (_deliverablesChanged.Any(d => d.Id == draw.Id))
        {
            var d = _deliverablesChanged.FirstOrDefault(d => d.Id == draw.Id);
            d.Time = draw.Time;
        }
        else
            _deliverablesChanged.Add(draw);

        _hasChanged = true;

        await OnTimeChanged.InvokeAsync(RemainingTime);

        StateHasChanged();
    }

    private async Task _onDeliverableCompletedChanged(DeliverableVM draw, object val)
    {
        draw.CompletionEstimation = Convert.ToInt32(val);

        if (_deliverablesChanged.Any(d => d.Id == draw.Id))
        {
            var d = _deliverablesChanged.FirstOrDefault(d => d.Id == draw.Id);
            d.CompletionEstimation = draw.CompletionEstimation;
        }
        else
            _deliverablesChanged.Add(draw);

        _hasChanged = true;

        await OnTimeChanged.InvokeAsync(RemainingTime);

        StateHasChanged();
    }

    private async Task _onOtherTimeChanged(SupportiveWorkVM other, TimeSpan newTimeSpan)
    {
        // previusTime, updatedTime, RemainingTime

        var previusTime = other.Time;
        var updatedTime = newTimeSpan - previusTime;
        RemainingTime += (-updatedTime);

        other.Time = newTimeSpan;

        if (_supportiveWorkChanged.Any(d => d.Id == other.Id))
        {
            var d = _supportiveWorkChanged.FirstOrDefault(d => d.Id == other.Id);
            d.Time = other.Time;
        }
        else
            _supportiveWorkChanged.Add(other);

        _hasChanged = true;

        await OnTimeChanged.InvokeAsync(RemainingTime);

        StateHasChanged();
    }

    private async Task _onPersonalTimeChanged(TimeSpan newTimeSpan)
    {
        // previusTime, updatedTime, RemainingTime

        var previusTime = _editLogedUserTimes.PersonalTime;
        var updatedTime = newTimeSpan - previusTime;
        RemainingTime += (-updatedTime);

        _editLogedUserTimes.PersonalTime = newTimeSpan;

        _hasChanged = true;

        await OnTimeChanged.InvokeAsync(RemainingTime);

        StateHasChanged();
    }

    private async Task _onTrainingTimeChanged(TimeSpan newTimeSpan)
    {
        // previusTime, updatedTime, RemainingTime

        var previusTime = _editLogedUserTimes.TrainingTime;
        var updatedTime = newTimeSpan - previusTime;
        RemainingTime += (-updatedTime);

        _editLogedUserTimes.TrainingTime = newTimeSpan;

        _hasChanged = true;

        await OnTimeChanged.InvokeAsync(RemainingTime);

        StateHasChanged();
    }

    private async Task _onCorporateTimeChanged(TimeSpan newTimeSpan)
    {
        // previusTime, updatedTime, RemainingTime

        var previusTime = _editLogedUserTimes.CorporateEventTime;
        var updatedTime = newTimeSpan - previusTime;
        RemainingTime += (-updatedTime);

        _editLogedUserTimes.CorporateEventTime = newTimeSpan;

        _hasChanged = true;

        await OnTimeChanged.InvokeAsync(RemainingTime);

        StateHasChanged();
    }

    private void _onPersonalTimeDateChanged(DateTime date)
    {
        _personalTimeDate = date;
    }

    private void _onTrainingTimeDateChanged(DateTime date)
    {
        _trainingTimeDate = date;
    }

    private void _onCorporateTimeDateChanged(DateTime date)
    {
        _corporateTimeDate = date;
    }
    #endregion

    #region When Records Selected
    private async Task OnSelectClient(long ledId)
    {
        if (ledId == 0 || ledId == _selectedClient?.Id) return;

        var led = _clients.FirstOrDefault(p => p.Id == ledId);
        _offers.Clear();
        _projects.Clear();
        _deliverables.Clear();
        _supportiveWork.Clear();
        _disciplines.Clear();

        _selectedClient = led ?? new ClientVM { Id = 0 };

        await _getOffers();

        _selectedOffer = new OfferVM() { Id = 0 };
        _selectedProject = null;
        _selectedDiscipline = null;
        _selectedDeliverable = null;
        _selectedSupportiveWork = null;

        StateHasChanged();
    }

    private async Task OnSelectOffer(long offerId)
    {
        if (offerId == 0 || offerId == _selectedOffer?.Id) return;

        var offer = _offers.FirstOrDefault(p => p.Id == offerId);
        _projects.Clear();
        _deliverables.Clear();
        _supportiveWork.Clear();
        _disciplines.Clear();
        _selectedOffer = offer;

        await _getProjects(active: true);

        _selectedProject = null;
        _selectedDiscipline = null;
        _selectedDeliverable = null;
        _selectedSupportiveWork = null;

        StateHasChanged();
    }

    private async Task OnSelectProject(long projectId)
    {
        if (projectId == 0 || projectId == _selectedProject?.Id) return;

        var project = _projects.FirstOrDefault(p => p.Id == projectId);
        _deliverables.Clear();
        _supportiveWork.Clear();
        _disciplines.Clear();
        _selectedProject = project;
        _selectedDiscipline = null;
        _selectedDeliverable = null;
        _selectedSupportiveWork = null;

        var userId = _sharedAuthData.LogedUser.Id;

        var disciplines = await _dataProvider.Projects.GetDisciplines(project.Id, userId, getAllDisciplines);

        _disciplines.Clear();
        foreach (var di in disciplines)
            _disciplines.Add(Mapper.Map<DisciplineVM>(di));

        await _checkIfHasAnySelections();

        StateHasChanged();
    }

    private async Task OnSelectDiscipline(long disciplineId)
    {
        if (disciplineId == 0 || disciplineId == _selectedDiscipline?.Id) return;

        _selectedDiscipline = _disciplines.FirstOrDefault(d => d.Id == disciplineId);

        var userId = _sharedAuthData.LogedUser.Id;

        var draws = await _dataProvider.Disciplines.GetDraws(_selectedDiscipline.Id, userId, getAllDeliverables);
        var others = await _dataProvider.Disciplines.GetOthers(_selectedDiscipline.Id, userId, true);

        _deliverables.Clear();
        foreach (var di in draws)
            _deliverables.Add(Mapper.Map<DeliverableVM>(di));

        _supportiveWork.Clear();
        foreach (var di in others)
            _supportiveWork.Add(Mapper.Map<SupportiveWorkVM>(di));

        await _checkIfHasAnySelections();

        StateHasChanged();
    }

    private void OnSelectDeliverable(DeliverableVM draw)
    {
        if (draw == null || draw.Id == _selectedDeliverable?.Id) return;
        _selectedDeliverable = draw;
        StateHasChanged();
    }

    private void OnSelectDoc(SupportiveWorkVM doc)
    {
        if (doc == null || doc.Id == _selectedSupportiveWork?.Id) return;
        _selectedSupportiveWork = doc;
        StateHasChanged();
    }
    #endregion

    public async Task UpdateHours()
    {
        if (!_hasChanged)
            return;

        try
        {
            // Update Db
            _startLoading = true;

            var userId = _sharedAuthData.LogedUser.Id;

            // Update Clients
            foreach (var client in _clientsChanged)
            {
                await _dataProvider.WorkingTime.ClientAddTime(userId, client.Id, client.Time, client.TimeDatePassed);
            }
            _clientsChanged.Clear();
            //_selectedClient = null;

            // Update Offers
            foreach (var offer in _offersChanged)
            {
                await _dataProvider.WorkingTime.OfferAddTime(userId, offer.Id, offer.Time, offer.TimeDatePassed);
            }
            _offersChanged.Clear();
            //_selectedOffer = null;

            // Update Projects
            foreach (var project in _projectsChanged)
            {
                await _dataProvider.WorkingTime.ProjectAddTime(userId, project.Id, project.Time, project.TimeDatePassed);
            }
            _projectsChanged.Clear();
            //_selectedProject = null;

            // Update Discipline
            foreach (var discipline in _disciplinesChanged)
            {
                await _dataProvider.WorkingTime.DisciplineAddTime(userId, _selectedProject.Id, discipline.Id, discipline.Time, discipline.TimeDatePassed);
            }
            _disciplinesChanged.Clear();
            //_selectedDiscipline = null;

            // Update Draws
            foreach (var draw in _deliverablesChanged)
            {
                var old = _deliverables.FirstOrDefault(d => d.Id == draw.Id);
                if (old.CompletionEstimation > draw.CompletionEstimation)
                {
                    //TODO: Display Msg

                    return;
                }
                else
                    await _dataProvider.Deliverables.UpdateCompleted(_selectedProject.Id, _selectedDiscipline.Id, draw.Id, draw.CompletionEstimation);
                await _dataProvider.WorkingTime.DeliverableAddTime(userId, _selectedProject.Id, _selectedDiscipline.Id, draw.Id, draw.Time, draw.TimeDatePassed);
            }
            _deliverablesChanged.Clear();

            // Update Others
            foreach (var other in _supportiveWorkChanged)
            {
                //await _dataProvider.Others.UpdateCompleted(_selectedProject.Id, _selectedDiscipline.Id, other.Id, other.CompletionEstimation);
                await _dataProvider.WorkingTime.SupportiveWorkAddTime(userId, _selectedProject.Id, _selectedDiscipline.Id, other.Id, other.Time, other.TimeDatePassed);
            }
            _supportiveWorkChanged.Clear();

            // Update User Hours
            if (_editLogedUserTimes.PersonalTime != TimeSpan.Zero)
            {
                await _dataProvider.WorkingTime.AddPersonalTime(userId, _personalTimeDate, _editLogedUserTimes.PersonalTime);
                _editLogedUserTimes.PersonalTime = TimeSpan.Zero;
            }
                
            if (_editLogedUserTimes.TrainingTime != TimeSpan.Zero)
            {
                await _dataProvider.WorkingTime.AddTraningTime(userId, _trainingTimeDate, _editLogedUserTimes.TrainingTime);
                _editLogedUserTimes.TrainingTime = TimeSpan.Zero;
            }
                
            if (_editLogedUserTimes.CorporateEventTime != TimeSpan.Zero)
            {
                await _dataProvider.WorkingTime.AddCorporateEventTime(userId, _corporateTimeDate, _editLogedUserTimes.CorporateEventTime);
                _editLogedUserTimes.CorporateEventTime = TimeSpan.Zero;
            }

            // Refresh
            //RemainingTime = TimeSpan.Zero;
            await Refresh(RemainingTime);
        }
        catch (Exception ex)
        {
            Logger.LogError($"Exception EditUsersHours._addHours(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }

        _startLoading = false;
    }
}
