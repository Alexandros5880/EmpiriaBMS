namespace EmpiriaBMS.Front.Components.WorkingHours;

using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.ReturnModels;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;

public partial class EditUsersHours
{
    [Parameter]
    public bool IsFromDashboard { get; set; } = false;

    [Parameter]
    public bool SendRequest { get; set; } = false;

    [Parameter]
    public bool DisplayTitle { get; set; } = true;

    [Parameter]
    public TimeSpan RemainingTime { get; set; }

    [Parameter]
    public UserVM User { get; set; } = null;

    [Parameter]
    public EventCallback OnEnd { get; set; }

    [Parameter]
    public EventCallback<TimeSpan> OnTimeChanged { get; set; }

    #region Authorization Properties
    bool seeAdmin => _sharedAuthData.Permissions.Any(p => p.Ord == 7);
    bool getAllDisciplines => _sharedAuthData.Permissions.Any(p => p.Ord == 9);
    bool getAllDeliverables => _sharedAuthData.Permissions.Any(p => p.Ord == 10);
    bool workOnProject => _sharedAuthData.Permissions.Any(p => p.Ord == 31);
    bool workOnOffers => _sharedAuthData.Permissions.Any(p => p.Ord == 32);
    bool workOnLeds => _sharedAuthData.Permissions.Any(p => p.Ord == 33);
    #endregion

    bool _startLoading = true;

    private UserTimes _editLogedUserTimes = new UserTimes()
    {
        DailyTime = TimeSpan.Zero,
        PersonalTime = TimeSpan.Zero,
        TrainingTime = TimeSpan.Zero,
        CorporateEventTime = TimeSpan.Zero,
    };

    private bool _hasChanged = false;

    private string _description { get; set; }

    #region Selections Lists
    private ObservableCollection<UserVM> _users = new ObservableCollection<UserVM>();
    private ObservableCollection<ClientVM> _clients = new ObservableCollection<ClientVM>();
    private ObservableCollection<OfferVM> _offers = new ObservableCollection<OfferVM>();
    private ObservableCollection<ProjectVM> _projects = new ObservableCollection<ProjectVM>();
    private ObservableCollection<DisciplineVM> _disciplines = new ObservableCollection<DisciplineVM>();
    private ObservableCollection<DeliverableVM> _deliverables = new ObservableCollection<DeliverableVM>();
    private ObservableCollection<SupportiveWorkVM> _supportiveWork = new ObservableCollection<SupportiveWorkVM>();
    #endregion

    #region Selected Models
    private UserVM _selectedUser = new UserVM();
    private ClientVM _selectedClient = new ClientVM();
    private OfferVM _selectedOffer = new OfferVM();
    private ProjectVM _selectedProject = new ProjectVM();
    private DisciplineVM _selectedDiscipline = new DisciplineVM();
    private DeliverableVM _selectedDeliverable = new DeliverableVM();
    private SupportiveWorkVM _selectedSupportiveWork = new SupportiveWorkVM();
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
            RemainingTime = IsFromDashboard ? TimeSpan.Zero : new TimeSpan(300, 0, 0);
            await Refresh();

            if (User != null)
            {
                await OnSelectUser(User.Id);
            }
        }
    }

    public async Task Refresh(TimeSpan? timespan = null)
    {
        if (timespan != null)
            RemainingTime = (TimeSpan)timespan;

        _description = string.Empty;

        _users.Clear();
        _clients.Clear();
        _offers.Clear();
        _projects.Clear();
        _supportiveWork.Clear();
        _deliverables.Clear();
        _disciplines.Clear();

        if (!IsFromDashboard)
            await _getUsers();

        if (workOnLeds || seeAdmin)
            await _getClients();

        if (workOnOffers || seeAdmin)
            await _getOffers();

        if (!workOnLeds && !workOnOffers)
            await _getProjects(active: true);

        _selectedUser = new UserVM() { Id = 0 };
        _selectedClient = new ClientVM() { Id = 0 };
        _selectedOffer = new OfferVM() { Id = 0 };
        _selectedProject = new ProjectVM() { Id = 0 };
        _selectedDiscipline = new DisciplineVM() { Id = 0 };
        _selectedDeliverable = new DeliverableVM() { Id = 0 };
        _selectedSupportiveWork = new SupportiveWorkVM() { Id = 0 };

        StateHasChanged();
    }

    #region Get Records
    public async Task _getUsers()
    {
        _selectedUser = null;
        _selectedClient = null;
        _selectedOffer = null;
        _selectedProject = null;
        _selectedDiscipline = null;
        _selectedDeliverable = null;
        _selectedSupportiveWork = null;
        _clients.Clear();
        _disciplines.Clear();
        _deliverables.Clear();
        _supportiveWork.Clear();

        try
        {
            var dtos = await _dataProvider.Users.GetEmployees();
            var vms = Mapper.Map<List<UserVM>>(dtos);
            _users.Clear();
            vms.ForEach(_users.Add);
        }
        catch (Exception ex)
        {
            Logger.LogError($"Exception EditUsersHours._getUsers(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }
    }

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

        var userId = IsFromDashboard ? _sharedAuthData.LogedUser.Id : _selectedUser?.Id ?? 0;

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

    #region On Time Changed
    private async Task _onLedTimeChanged(ClientVM client, TimeSpan newTimeSpan)
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
    #endregion

    #region When Records Selected
    private async Task OnSelectUser(int userId)
    {
        if (userId == 0 || userId == _selectedUser?.Id) return;

        var user = _users.FirstOrDefault(p => p.Id == userId);

        _clients.Clear();
        _offers.Clear();
        _projects.Clear();
        _supportiveWork.Clear();
        _deliverables.Clear();
        _disciplines.Clear();
        _selectedUser = user;

        await _getClients();

        _selectedClient = new ClientVM() { Id = 0 };
        _selectedOffer = new OfferVM() { Id = 0 };
        _selectedProject = new ProjectVM() { Id = 0 };
        _selectedDiscipline = new DisciplineVM() { Id = 0 };
        _selectedDeliverable = new DeliverableVM() { Id = 0 };
        _selectedSupportiveWork = new SupportiveWorkVM() { Id = 0 };

        StateHasChanged();
    }

    private async Task OnSelectLed(int ledId)
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

    private async Task OnSelectOffer(int offerId)
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

    private async Task OnSelectProject(int projectId)
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

        var userId = IsFromDashboard ? _sharedAuthData.LogedUser.Id : _selectedUser?.Id ?? 0;

        var disciplines = await _dataProvider.Projects.GetDisciplines(project.Id, userId, getAllDisciplines);

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

        var userId = IsFromDashboard ? _sharedAuthData.LogedUser.Id : _selectedUser?.Id ?? 0;

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

    public async Task Save()
    {
        if (!_hasChanged)
            return;

        if (SendRequest)
        {
            var valid = Validate();
            if (valid)
                await _sendRequest();
            else
                return;
        }
        else
            await _addHours();

        // Refresh
        RemainingTime = IsFromDashboard ? TimeSpan.Zero : new TimeSpan(300, 0, 0);
        await Refresh(RemainingTime);

        if (User != null)
        {
            await OnSelectUser(User.Id);
        }

        _startLoading = false;
    }

    private async Task _sendRequest()
    {
        try
        {
            var userId = IsFromDashboard ? _sharedAuthData.LogedUser.Id : _selectedUser?.Id ?? 0;

            // Update Leds
            foreach (var led in _clientsChanged)
            {
                await _dataProvider.WorkingTime.ClientAddTimeRequest(userId, led.Id, led.Time, _description);
            }
            _clientsChanged.Clear();
            _selectedClient = null;

            // Update Offers
            foreach (var offer in _offersChanged)
            {
                await _dataProvider.WorkingTime.OfferAddTimeRequest(userId, offer.Id, offer.Time, _description);
            }
            _offersChanged.Clear();
            _selectedOffer = null;

            // Update Projects
            foreach (var project in _projectsChanged)
            {
                await _dataProvider.WorkingTime.ProjectAddTimeRequest(userId, project.Id, project.Time, _description);
            }
            _projectsChanged.Clear();
            //_selectedProject = null;

            // Update Discipline
            foreach (var discipline in _disciplinesChanged)
            {
                await _dataProvider.WorkingTime.DisciplineAddTimeRequest(userId, _selectedProject.Id, discipline.Id, discipline.Time, _description);
            }
            _disciplinesChanged.Clear();
            //_selectedDiscipline = null;

            // Update Draws
            foreach (var draw in _deliverablesChanged)
                await _dataProvider.WorkingTime.DeliverableAddTimeRequest(userId, _selectedProject.Id, _selectedDiscipline.Id, draw.Id, draw.Time, _description);

            // Update Others
            foreach (var other in _supportiveWorkChanged)
                await _dataProvider.WorkingTime.SupportiveWorkAddTimeRequest(userId, _selectedProject.Id, _selectedDiscipline.Id, other.Id, other.Time, _description);

            // Update User Hours
            if (_editLogedUserTimes.PersonalTime != TimeSpan.Zero)
                await _dataProvider.WorkingTime.AddPersonaTimeRequest(userId, _editLogedUserTimes.PersonalTime, _description);
            if (_editLogedUserTimes.TrainingTime != TimeSpan.Zero)
                await _dataProvider.WorkingTime.AddTraningTimeRequest(userId, _editLogedUserTimes.TrainingTime, _description);
            if (_editLogedUserTimes.CorporateEventTime != TimeSpan.Zero)
                await _dataProvider.WorkingTime.AddCorporateEventTimeRequest(userId, _editLogedUserTimes.CorporateEventTime, _description);

            await OnEnd.InvokeAsync();
        }
        catch (Exception ex)
        {
            Logger.LogError($"Exception EditUsersHours._sendRequest(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }
    }

    private async Task _addHours()
    {
        try
        {
            // Validate
            if (IsFromDashboard)
            {
                if (RemainingTime.Hours > 0)
                    // TODO: Display a message to update his hours.
                    return;
            }

            // Update Db
            _startLoading = true;

            var userId = IsFromDashboard ? _sharedAuthData.LogedUser.Id : _selectedUser?.Id ?? 0;


            // Update Leds
            foreach (var led in _clientsChanged)
            {
                await _dataProvider.WorkingTime.ClientAddTime(userId, led.Id, led.Time);
            }
            _clientsChanged.Clear();
            _selectedClient = null;

            // Update Offers
            foreach (var offer in _offersChanged)
            {
                await _dataProvider.WorkingTime.OfferAddTime(userId, offer.Id, offer.Time);
            }
            _offersChanged.Clear();
            _selectedOffer = null;

            // Update Projects
            foreach (var project in _projectsChanged)
            {
                await _dataProvider.WorkingTime.ProjectAddTime(userId, project.Id, project.Time);
            }
            _projectsChanged.Clear();
            //_selectedProject = null;

            // Update Discipline
            foreach (var discipline in _disciplinesChanged)
            {
                await _dataProvider.WorkingTime.DisciplineAddTime(userId, _selectedProject.Id, discipline.Id, discipline.Time);
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
                await _dataProvider.WorkingTime.DeliverableAddTime(userId, _selectedProject.Id, _selectedDiscipline.Id, draw.Id, draw.Time);
            }

            // Update Others
            foreach (var other in _supportiveWorkChanged)
            {
                //await _dataProvider.Others.UpdateCompleted(_selectedProject.Id, _selectedDiscipline.Id, other.Id, other.CompletionEstimation);
                await _dataProvider.WorkingTime.SupportiveWorkAddTime(userId, _selectedProject.Id, _selectedDiscipline.Id, other.Id, other.Time);
            }

            // Update User Hours
            if (_editLogedUserTimes.PersonalTime != TimeSpan.Zero)
                await _dataProvider.WorkingTime.AddPersonalTime(userId, DateTime.Now, _editLogedUserTimes.PersonalTime);
            if (_editLogedUserTimes.TrainingTime != TimeSpan.Zero)
                await _dataProvider.WorkingTime.AddTraningTime(userId, DateTime.Now, _editLogedUserTimes.TrainingTime);
            if (_editLogedUserTimes.CorporateEventTime != TimeSpan.Zero)
                await _dataProvider.WorkingTime.AddCorporateEventTime(userId, DateTime.Now, _editLogedUserTimes.CorporateEventTime);

            await OnEnd.InvokeAsync();
        }
        catch (Exception ex)
        {
            Logger.LogError($"Exception EditUsersHours._addHours(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }
    }

    #region Validation
    private bool validDescription = true;

    public bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validDescription = !string.IsNullOrEmpty(_description) && !string.IsNullOrWhiteSpace(_description);

            return validDescription;
        }
        else
        {
            validDescription = true;

            switch (fieldname)
            {
                case "Description":
                    validDescription = !string.IsNullOrEmpty(_description) && !string.IsNullOrWhiteSpace(_description);
                    return validDescription;

                default:
                    return true;
            }

        }
    }
    #endregion
}
