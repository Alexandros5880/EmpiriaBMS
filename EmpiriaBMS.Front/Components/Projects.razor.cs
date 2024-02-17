using EmpiriaBMS.Front.Components.General;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.DefaultComponents;
using EmpiriaMS.Models.Enums;
using EmpiriaMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using Microsoft.Kiota.Abstractions;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using static Microsoft.Fast.Components.FluentUI.Emojis.Objects.Color.Default;
using EmpiriaBMS.Front.Components;
using EmpiriaBMS.Front.ViewModel.Components.Projects;
using System.Diagnostics.Eventing.Reader;

namespace EmpiriaBMS.Front.Components;
public partial class Projects: IDisposable
{
    private bool disposedValue;

    bool startLoading = true;
    bool filterLoading = false;

    bool runInTeams = false;
    bool IsAllChecked = false;

    private List<string> _changedProjectIds = new List<string>();
    private ObservableCollection<ProjectVM> _projects = new ObservableCollection<ProjectVM>();
    List<PlanTypes> projectPlanTypes = Enum.GetValues(typeof(PlanTypes)).OfType<PlanTypes>().ToList();
    private PaginatorVM _paginator = new PaginatorVM(7);

    private ProjectValidModel _validationModel = new ProjectValidModel();
    private ProjectVM _selectedProjectBackUp = null;
    private ProjectVM _selectedProject = new ProjectVM();
    private InvoiceVM _selectedInvoice = new InvoiceVM();

    private UserVM _logedUser;

    // Hours Dialog
    private FluentDialog _editHoursDialog;
    private bool isEditDialogOdepened = false;
    private double _hoursToChange = 0.0;

    // Project Deyailes Dialog
    private FluentDialog _projectDetailesDialog;
    private bool isProjectDetailesDialogOdepened = false;

    // Accept Dialog
    private AcceptDialog _acceptDialog;
    private bool _isAcceptDialogOppend = false;

    protected override async void OnInitialized()
    {
        startLoading = true;
        await _getLogedUser();
        await _getProjects();
        startLoading = false;
        base.OnInitialized();
        StateHasChanged();
        _toogleEditHoursDialog(false);
        _toogleProjectDetailesDialog(false);
        _acceptDialog?.Close();
    }

    private async Task _onSaveClicked()
    {
        var hasNewRecords = _projects.Any(p => string.IsNullOrEmpty(p.Id));
        var hasAnyChange = _changedProjectIds.Count > 0;
        if (hasNewRecords || hasAnyChange)
        {
            await _acceptDialog?.ToogleAcceptDialog(
                                open: true,
                                acceptDialogOnAccept: _updateRecords,
                                msg: "Are you sure you want to save the changes?",
                                acceptButtons: true);
        }
        else
        {
            await _acceptDialog?.ToogleAcceptDialog(
                                open: true,
                                msg: "There is no changed records to Update!",
                                acceptButtons: false);
        }
    }

    private async Task _updateRecords()
    {
        _acceptDialog.IsLoading = true;
        var newRecords = _projects.Where(p => string.IsNullOrEmpty(p.Id)).ToList();
        foreach (var item in newRecords)
        {
            if (!await DataProvider.Projects.Any(p => p.Id.Equals(item.Id)))
                await DataProvider.Projects.Add(Mapper.Map<Project>(item));
        }

        var updated = _projects.Where(p => _changedProjectIds.Contains(p.Id)).ToList();
        foreach (var item in updated)
        {
            if (await DataProvider.Projects.Any(p => p.Id.Equals(item.Id)))
                DataProvider.Projects.Update(Mapper.Map<Project>(item));
        }

        _changedProjectIds.Clear();
        _acceptDialog.IsLoading = false;

        _acceptDialog?.Close();

        await _acceptDialog?.ToogleAcceptDialog(
                                open: true,
                                msg: "Updated successfully!",
                                acceptButtons: false);

        StateHasChanged();
    }

    private async Task _onDeleteBtnClcked()
    {
        if (_projects.Any(p => p.IsChecked))
        {
            await _acceptDialog?.ToogleAcceptDialog(
                                open:true,
                                acceptDialogOnAccept: _deleteSelected,
                                msg:"Are you sure you want to delete the record ?",
                                acceptButtons:true);
        }
        else
        {
            await _acceptDialog?.ToogleAcceptDialog(
                                open: true,
                                msg: "Please select some records to delete!",
                                acceptButtons: false);
        }
    }

    private async Task _deleteSelected()
    {
        _acceptDialog.IsLoading = true;
        var deleted = _projects.Where(p => p.IsChecked).ToList();
        foreach (var item in deleted)
        {
            if (await DataProvider.Projects.Any(p => p.Id.Equals(item.Id)))
                await DataProvider.Projects.Delete(item.Id);
            _projects.Remove(item);
        }
        _acceptDialog.IsLoading = false;
        _acceptDialog?.Close();
        StateHasChanged();
    }

    private void _addRecord()
    {
        try {
            var newProject = new ProjectVM();
            newProject.Invoice = new InvoiceVM();
            newProject.Invoice.Project = newProject;
            _projects.Insert(0, newProject);
            _selectedProject = newProject;
            _selectedInvoice = _selectedProject.Invoice;
            //StateHasChanged();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
    }
    
    #region HoursDialog
    private void _toogleEditHoursDialog(bool open)
    {
        isEditDialogOdepened = open;
        if (open)
            _editHoursDialog?.Show();
        else
            _editHoursDialog?.Hide();
    }

    private void UpdateHours()
    {
        _logedUser.Hours += _hoursToChange;
        _hoursToChange = 0.0;
        _toogleEditHoursDialog(false);
    }
    #endregion

    #region Project Detailes Dialog
    private void _toogleProjectDetailesDialog(bool open)
    {
        isProjectDetailesDialogOdepened = open;
        if (open)
            _projectDetailesDialog?.Show();
        else
            _projectDetailesDialog?.Hide();
    }
    
    private void _openPorjectDetailsClick()
    {
        _selectedProjectBackUp = _selectedProject;
        _toogleProjectDetailesDialog(true);
    }

    private void _updateProject(bool cancel = true)
    {
        if (cancel)
        {
            _selectedProject = _selectedProjectBackUp;
        }
        _selectedProjectBackUp = null;
        _toogleProjectDetailesDialog(false);
    }
    #endregion

    #region Get Records
    private async Task _getProjects()
    {
        filterLoading = !startLoading ? true : filterLoading;
        try
        {
            // Todo: Find a way to add this in to PaginatorVM
            _paginator.RecordsCount = await DataProvider.Projects.Count();
            var divide = _paginator.RecordsCount / _paginator.PageSize;
            var quotient = _paginator.RecordsCount % _paginator.PageSize;
            _paginator.PagesCounter = quotient == 0 ? divide : divide + 1;

            // TODO: Get My Project And Down
            var data = (await DataProvider.Projects.GetAll(_paginator.PageSize, _paginator.PageIndex))
                        .Select(p => Mapper.Map<ProjectVM>(p))
                        .ToList();
            _projects.Clear();
            data.ForEach(p => {
                p.PropertyChanged += _projectsPropertyChanged;
                _projects.Add(p);
            });
            _selectedProject = _projects.FirstOrDefault();
            _selectedInvoice = _selectedProject.Invoice;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
        filterLoading = !startLoading ? false : filterLoading;
    }

    private async Task _getLogedUser()
    {
        try
        {
            // TODO: Get Teams Loged User And Mach him With Oure Users

            var defaultRoleId = await GetProjectManagersRoleId("Project Managers");
            if (defaultRoleId == null)
                throw new Exception("Exception `Project Managers` role not exists!");

            var users = await DataProvider.Roles.GetUsers(defaultRoleId);
            var dbUser = users.FirstOrDefault();
            //string defaultUserId = "cc71da774225492093e3cc418569f1a524";
            // var dbUser = await DataProvider.Employees.Get(defaultUserId);
            _logedUser = Mapper.Map<UserVM>(dbUser);
            _logedUser.Roles = (await DataProvider.Employees.GetRoles(dbUser.Id))
                                        .Select(r => Mapper.Map<RoleVM>(r))
                                        .ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
    }

    private async Task<String> GetProjectManagersRoleId(string roleName)
    {
        try
        {
            return (await DataProvider.Roles
                                .GetAll(r => r.Name.Equals(roleName)))
                                .FirstOrDefault().Id;
        }
        catch (Exception ex)
        {
            // TODO: Log Error
            return null;
        }
    }
    #endregion

    #region Properties Changed Venets
    private void OnSelectProject(ProjectVM project)
    {
        _selectedProject = project;
        _selectedInvoice = Mapper.Map<InvoiceVM>(project.Invoice);
    }

    private void _isCheckedChanged()
    {
        foreach (var p in _projects)
            p.IsChecked = !IsAllChecked;
    }

    private void _projectsPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        var project = sender as ProjectVM;

        _projectValidate(project, nameof(ProjectVM.Completed));

        // Pass Changed Project Id To Update List
        var id = project.Id;
        if (!_changedProjectIds.Contains(_selectedProject.Id) && !_selectedProject.Id.Equals(string.Empty))
            _changedProjectIds.Add(_selectedProject.Id);
    }

    private void _invoice_PropertyChanged(string id)
    {
        if (!_changedProjectIds.Contains(_selectedProject.Id) && !_selectedProject.Id.Equals(string.Empty))
            _changedProjectIds.Add(_selectedProject.Id);
    }

    private void _project_PropertyChanged(string id)
    {
        if (!_changedProjectIds.Contains(_selectedProject.Id) && !_selectedProject.Id.Equals(string.Empty))
            _changedProjectIds.Add(_selectedProject.Id);
    }
    #endregion

    #region Validation
    private void _projectValidate(ProjectVM project, string propertyName) {
        // Validate
        switch (propertyName)
        {
            case nameof(ProjectVM.Completed):
                var valid = _validationModel.Validate(project, nameof(ProjectVM.Completed));
                project.Completed = valid
                    ? project.Completed
                    : project.Completed < 0 ? 0 : 100;
                break;

            default:
                break;
        }
    }
    #endregion

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _projects.ToList().ForEach(p => {
                    p.PropertyChanged -= _projectsPropertyChanged;
                });
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
