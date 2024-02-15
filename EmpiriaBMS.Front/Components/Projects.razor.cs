using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.DefaultComponents;
using EmpiriaMS.Models.Enums;
using EmpiriaMS.Models.Models;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static Microsoft.Fast.Components.FluentUI.Emojis.Objects.Color.Default;

namespace EmpiriaBMS.Front.Components;
public partial class Projects
{
    bool startLoading = true;
    bool filterLoading = false;
    bool deleteLoading = false;

    bool runInTeams = false;
    bool IsAllChecked = false;

    private FluentDialog? _editHoursDialog;
    private bool isEditDialogOdepened = false;
    private double _hoursToChange = 0.0;

    private bool _acceptButtons = true;
    private string _acceptDialogMsg = string.Empty;
    private Func<Task> _acceptDialogOnAccept = null;
    private FluentDialog? _acceptDialog;
    private bool isAcceptDialogOdepened = false;

    private ObservableCollection<ProjectVM> _projects = new ObservableCollection<ProjectVM>();
    List<PlanTypes> projectPlanTypes = Enum.GetValues(typeof(PlanTypes)).OfType<PlanTypes>().ToList();
    private PaginatorVM _paginator = new PaginatorVM(7);

    private UserVM _logedUser;

    private ProjectVM _selectedProject = new ProjectVM();
    private InvoiceVM _selectedInvoice = new InvoiceVM();

    protected override async void OnInitialized()
    {
        startLoading = true;
        await _getLogedUser();
        await _getProjects();
        startLoading = false;
        base.OnInitialized();
        StateHasChanged();
        ToogleEditHoursDialog(false);
        ToogleAcceptDialog(false);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            runInTeams = await MicrosoftTeams.IsInTeams();
            if (runInTeams)
            {

            }

            // Update UI
            //StateHasChanged();
        }

    }

    private async Task _onSaveClicked()
    {
        if (_projects.Any(p => p.IsChecked))
        {
            ToogleAcceptDialog(true, "Are you sure you want to delete the record ?");
        }
    }

    private void _onDeleteBtnClcked()
    {
        if (_projects.Any(p => p.IsChecked))
        {
            ToogleAcceptDialog(
                open:true,
                msg:"Are you sure you want to delete the record ?",
                acceptButtons:true,
                acceptDialogOnAccept: _deleteSelected);
        }
    }

    private async Task _deleteSelected()
    {
        deleteLoading = true;
        var deleted = _projects.Where(p => p.IsChecked).ToList();
        foreach (var item in deleted)
        {
            await DataProvider.Projects.Delete(item.Id);
            _projects.Remove(item);
        }
        deleteLoading = false;
        ToogleAcceptDialog(false);
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

    private void ToogleAcceptDialog(
        bool open,
        string msg = "",
        bool acceptButtons = true,
        Func<Task> acceptDialogOnAccept = null
    ) {
        _acceptButtons = acceptButtons;
        _acceptDialogMsg = msg;
        isAcceptDialogOdepened = open;
        _acceptDialogOnAccept = acceptDialogOnAccept;
        if (open)
            _acceptDialog.Show();
        else
            _acceptDialog.Hide();
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
            data.ForEach(_projects.Add);
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
}