using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.Components.Admin.Projects;
using EmpiriaBMS.Front.Components.Home.Issues;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.CodeAnalysis;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.Home.Projects;

public partial class Projects
{
    private string _dialogWidth = "min(82%, 740px);";
    private string _dialogHeight = "min(85%, 880px);";

    private bool _loading = false;

    #region Authorization Properties
    bool editDiscipline => _sharedAuthData.Permissions.Any(p => p.Ord == 14);
    bool getAllDisciplines => _sharedAuthData.Permissions.Any(p => p.Ord == 9);
    bool assignEngineer => _sharedAuthData.PermissionOrds.Contains(4);
    bool editProject => _sharedAuthData.Permissions.Any(p => p.Ord == 12);
    bool assignPm => _sharedAuthData.PermissionOrds.Contains(5);
    #endregion

    [Parameter]
    public bool IsWorkingMode { get; set; }

    [Parameter]
    public EventCallback<int> OnSelect { get; set; }

    [Parameter]
    public EventCallback OnEdit { get; set; }

    private ObservableCollection<ProjectVM> _data = new ObservableCollection<ProjectVM>();

    private List<ProjectVM> _dataChanged = new List<ProjectVM>();

    private ProjectVM _selectedProject = new ProjectVM();

    private ObservableCollection<UserVM> _projectManagers = new ObservableCollection<UserVM>();

    private ObservableCollection<OfferVM> _offers = new ObservableCollection<OfferVM>();

    private int _selectedPmId;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _loading = true;
            StateHasChanged();

            await GetRecords();

            _loading = false;
            StateHasChanged();
        }
    }

    public async Task Refresh()
    {
        if (_loading == false)
        {
            _loading = true;
            StateHasChanged();
        }
        _selectedProject = null;

        await GetRecords();

        _loading = false;
        StateHasChanged();
    }

    public void ResetSelection() =>
        _selectedProject = null;

    public void SetSelected(ProjectVM selected)
    {
        if (selected == null || selected.Id == _selectedProject?.Id)
            return;
        _selectedProject = selected;
    }

    public async Task GetRecords(int offerId = 0, bool? active = null)
    {
        await _getOffers();

        // Get Projects of last month
        List<ProjectDto> projectsDto =
            (await _dataProvider.Projects
                .GetProjectsWithFallback(
                    _sharedAuthData.LogedUser.Id,
                    offerId: offerId,
                    active: active
            )).ToList<ProjectDto>();

        var projectsVm = Mapper.Map<List<ProjectDto>, List<ProjectVM>>(projectsDto);

        _data.Clear();
        foreach (var p in projectsVm)
        {
            var pm = await _dataProvider.Projects.GetProjectManager(p.Id);
            p.PmName = pm != null ? $"{pm.LastName} {pm.FirstName}" : null;
            _data.Add(p);
        }

        StateHasChanged();
    }

    public void ClearRecords() => _data.Clear();

    public void ResetChanges() => _dataChanged.Clear();

    private async Task OnRowSelect(int projectId)
    {
        if (projectId == 0)
            return;

        _selectedProject = _data.FirstOrDefault(p => p.Id == projectId);

        await OnSelect.InvokeAsync(projectId);

        StateHasChanged();
    }

    private long GetProjectMenHours(int projecId) =>
        _dataProvider.Projects.GetMenHours(projecId);

    public async Task _getOffers()
    {
        try
        {
            var dtos = await _dataProvider.Offers.GetAllByLead();
            var vms = Mapper.Map<List<OfferVM>>(dtos);
            _offers.Clear();
            vms.ForEach(_offers.Add);
        }
        catch (Exception ex)
        {
            Logger.LogError($"Exception Projects._getOffers(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }
    }

    #region Dialogs
    // On Delete Dialog
    private FluentDialog _deleteDialog;
    private bool _isDeleteDialogOdepened = false;
    private string _deleteDialogMsg = "";

    // On Add Issue Dialog
    private FluentDialog _addIssueDialog;
    private bool _isAddIssueDialogOdepened = false;
    private IssueDetailed issueCompoment;

    // Add ProjectManager Dialog
    private FluentDialog _addPMDialog;
    private bool _isAddPMDialogOdepened = false;
    #endregion 

    #region Projects Filter
    IQueryable<ProjectVM> _filteredProjects => _data?.AsQueryable()
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

        DialogParameters parameters = new()
        {
            Title = $"New Record",
            PrimaryActionEnabled = true,
            SecondaryActionEnabled = true,
            PrimaryAction = "Save",
            SecondaryAction = "Cancel",
            TrapFocus = true,
            Modal = true,
            PreventScroll = false,
            Width = _dialogWidth,
            Height = _dialogHeight
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<ProjectDetailedDialog>(new ProjectVM(), parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            ProjectVM vm = result.Data as ProjectVM;
            var dto = Mapper.Map<ProjectDto>(vm);

            // Save Project
            var updatedDto = await _dataProvider.Projects.Add(dto);
            var updateVm = Mapper.Map<ProjectVM>(updatedDto);

            if (_data.Any(p => p.Id == updateVm.Id))
                _data.Remove(updateVm);

            var pm = await _dataProvider.Projects.GetProjectManager(updateVm.Id);
            updateVm.PmName = pm != null ? $"{pm.LastName} {pm.FirstName}" : null;

            // Order by DeaLine and add new one on top
            var sortedProjects = _data.OrderByDescending(p => p.DeadLine).ToList();
            sortedProjects.Insert(0, updateVm);
            _data = new ObservableCollection<ProjectVM>(sortedProjects);

            _selectedProject = updateVm;
            StateHasChanged();
        }
    }

    private async Task EditProject()
    {
        DialogParameters parameters = new()
        {
            Title = $"Edit {_selectedProject.Name}",
            PrimaryActionEnabled = true,
            SecondaryActionEnabled = true,
            PrimaryAction = "Save",
            SecondaryAction = "Cancel",
            TrapFocus = true,
            Modal = true,
            PreventScroll = false,
            Width = _dialogWidth,
            Height = _dialogHeight
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<ProjectDetailedDialog>(_selectedProject, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            ProjectVM vm = result.Data as ProjectVM;
            var dto = Mapper.Map<ProjectDto>(vm);

            // Save Project
            var updatedDto = await _dataProvider.Projects.Update(dto);
            var updateVm = Mapper.Map<ProjectVM>(updatedDto);

            if (_data.Any(p => p.Id == updateVm.Id))
                _data.Remove(updateVm);

            var pm = await _dataProvider.Projects.GetProjectManager(updateVm.Id);
            updateVm.PmName = pm != null ? $"{pm.LastName} {pm.FirstName}" : null;

            // Order by DeaLine and add new one on top
            var sortedProjects = _data.OrderByDescending(p => p.DeadLine).ToList();
            sortedProjects.Insert(0, updateVm);
            _data = new ObservableCollection<ProjectVM>(sortedProjects);

            _selectedProject = updateVm;
            StateHasChanged();
        }
    }

    private void DeleteProject()
    {
        _deleteDialogMsg = $"Are you sure you want delete {_selectedProject.Name}";
        _deleteDialog.Show();
        _isDeleteDialogOdepened = true;
    }
    #endregion

    #region Delete Dialog Actions
    private async Task OnDeleteAccept()
    {
        if (_isDeleteDialogOdepened)
        {
            await _dataProvider.Projects.Delete(_selectedProject.Id);
            _data.Remove(_selectedProject);
            _selectedProject = null;

            _deleteDialogMsg = "";
            _deleteDialog.Hide();
            _isDeleteDialogOdepened = false;

            StateHasChanged();
        }
    }

    private void OnDeleteClose()
    {
        if (_isDeleteDialogOdepened)
        {
            _deleteDialogMsg = "";
            _deleteDialog.Hide();
            _isDeleteDialogOdepened = false;
        }
    }
    #endregion

    #region Add Issue Actions
    private void OnAddIssueClick()
    {
        issueCompoment.Refresh();
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

    #region Projects Managers Assign Actions (Project Assign)
    private async Task<int> GetRoleId(string roleName)
    {
        try
        {
            var role = await _dataProvider.Roles.Get(roleName);
            return role?.Id ?? 0;
        }
        catch (Exception ex)
        {
            Logger.LogError($"Exception Projects.GetRoleId(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
            return 0;
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
            Logger.LogError($"Exception Dashboard._getProjectManagers(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }
    }

    void ToggleSelection(UserVM pm, string selectedValue)
    {
        pm.IsSelected = !_projectManagers.First(p => p.Id.ToString() == selectedValue).IsSelected;
    }

    private async Task OnProjectAssignClick(ProjectVM project)
    {
        if (!IsWorkingMode) return;
        try
        {
            bool neaSelected = _selectedProject.Id != project.Id;

            if (neaSelected)
                _selectedProject = project;

            await _getProjectManagers();
            if (neaSelected)
            {
                await OnRowSelect(_selectedProject.Id);
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

            var projectIndex = _data.IndexOf(_selectedProject);

            var pmDto = await _dataProvider.Users.Get(_selectedPmId);

            if (pmDto == null)
                return;

            var pm = Mapping.Mapper.Map<User>(pmDto);
            updated.PmName = pm != null ? $"{pm.LastName} {pm.FirstName}" : null;
            updated.ProjectManagerId = _selectedPmId;
            await _dataProvider.Projects.Update(Mapper.Map<ProjectDto>(updated));
            updated.ProjectManager = pm;

            var forDelete = _data.FirstOrDefault(p => p.Id == updated.Id);
            if (forDelete != null)
                _data.Remove(forDelete);

            _data.Insert(projectIndex, updated);

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

    private async Task ExportProjectsToCSV()
    {
        var date = DateTime.Today;
        var fileName = $"Projects-{date.ToEuropeFormat()}.csv";
        var data = _data.ToList();
        if (_data.Count > 0)
        {
            string csvContent = Data.GetCsvContent(_data);
            await MicrosoftTeams.DownloadCsvFile(fileName, csvContent);
        }
    }
}
