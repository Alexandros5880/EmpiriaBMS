using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.DefaultComponents;
using EmpiriaMS.Models.Enums;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace EmpiriaBMS.Front.Components;
public partial class Projects
{
    bool startLoading = true;
    bool filterLoading = false;

    bool runInTeams = false;
    bool IsAllChecked = false;

    private FluentDialog? EditHoursDialog;
    private bool isEditDialogOdepened = false;
    private double _hoursToChange = 0.0;

    private ObservableCollection<ProjectVM> _data = new ObservableCollection<ProjectVM>();
    List<PlanType> projectPlanTypes = Enum.GetValues(typeof(PlanType)).OfType<PlanType>().ToList();
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

    private void ToogleEditHoursDialog(bool open)
    {
        isEditDialogOdepened = open;
        if (open)
            EditHoursDialog.Show();
        else
            EditHoursDialog.Hide();
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
        foreach (var p in _data)
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
            _data.Clear();
            data.ForEach(_data.Add);
            _selectedProject = _data.FirstOrDefault();
            _selectedInvoice = _selectedProject.Invoice;
        }
        catch (Exception ex)
        {
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
            return null;
        }
    }
}