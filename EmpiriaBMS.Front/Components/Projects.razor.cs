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

namespace EmpiriaBMS.Front.Components;
public partial class Projects: IDisposable
{
    private bool disposedValue;

    bool startLoading = true;
    bool filterLoading = false;

    bool runInTeams = false;
    bool IsAllChecked = false;

    private FluentDialog _editHoursDialog;
    private bool isEditDialogOdepened = false;
    private double _hoursToChange = 0.0;

    private List<string> _changedProjectIds = new List<string>();
    private ObservableCollection<ProjectVM> _projects = new ObservableCollection<ProjectVM>();
    List<PlanTypes> projectPlanTypes = Enum.GetValues(typeof(PlanTypes)).OfType<PlanTypes>().ToList();
    private PaginatorVM _paginator = new PaginatorVM(7);

    private UserVM _logedUser;

    private ProjectVM _selectedProject = new ProjectVM();
    private InvoiceVM _selectedInvoice = new InvoiceVM();

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
        ToogleEditHoursDialog(false);
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
                await DataProvider.Projects.Update(Mapper.Map<Project>(item));
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

    private void ToogleEditHoursDialog(bool open)
    {
        isEditDialogOdepened = open;
        if (open)
            _editHoursDialog.Show();
        else
            _editHoursDialog.Hide();
    }

    private void UpdateHours()
    {
        _logedUser.Hours += _hoursToChange;
        _hoursToChange = 0.0;
        ToogleEditHoursDialog(false);
    }

    private void OnSelectProject(ProjectVM project)
    {
        _selectedProject = project;
        _selectedInvoice = Mapper.Map<InvoiceVM>(project.Invoice);
    }

    private void SelectionChanged()
    {
        foreach (var p in _projects)
            p.IsChecked = !IsAllChecked;
    }

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
                p.PropertyChanged += P_PropertyChanged;
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

            var dbUser = (await DataProvider.Roles.GetUsers(defaultRoleId)).FirstOrDefault();
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

    #region Properties Changed Venets
    private void P_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        var id = sender.GetType().GetProperty(nameof(ProjectVM.Id)).GetValue(sender);
        if (!_changedProjectIds.Contains(_selectedProject.Id) && !_selectedProject.Id.Equals(string.Empty))
            _changedProjectIds.Add(_selectedProject.Id);
    }

    private void _invoice_PropertyChanged(string id)
    {
        if (!_changedProjectIds.Contains(_selectedProject.Id) && !_selectedProject.Id.Equals(string.Empty))
            _changedProjectIds.Add(_selectedProject.Id);
    }
    #endregion

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _projects.ToList().ForEach(p => {
                    p.PropertyChanged -= P_PropertyChanged;
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