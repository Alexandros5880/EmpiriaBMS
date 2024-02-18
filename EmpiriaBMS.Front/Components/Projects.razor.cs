using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.DefaultComponents;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace EmpiriaBMS.Front.Components;
public partial class Projects: IDisposable
{
    private bool disposedValue;

    bool startLoading = true;
    bool filterLoading = false;

    bool runInTeams = false;
    bool IsAllChecked = false;

    private ObservableCollection<ProjectVM> _projects = new ObservableCollection<ProjectVM>();
    
    // Paginator
    private PaginatorVM _paginator = new PaginatorVM(7);

    // Basic Models
    private ProjectVM _selectedProject = new ProjectVM();
    private UserVM _logedUser;
    private ICollection<RoleVM> _loggedUserRoles = new List<RoleVM>();
    private bool _logesUserChanged = false;

    protected override async void OnInitialized()
    {
        await _getLogedUser();
        await _getProjects();
        startLoading = false;
        base.OnInitialized();
        //StateHasChanged();
    }

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
            data.ForEach(_projects.Add);
            _selectedProject = _projects.FirstOrDefault();
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
            if (defaultRoleId == 0)
                throw new Exception("Exception `Project Managers` role not exists!");

            var users = await DataProvider.Roles.GetUsers(defaultRoleId);
            var dbUser = users.FirstOrDefault();

            if (dbUser == null)
                throw new Exception("Exception user with `Project Managers` role not exists!");

            _logedUser = Mapper.Map<UserVM>(dbUser);

            _loggedUserRoles = (await DataProvider.Roles.GetEmplyeeRoles(dbUser.Id))
                                                        .Select(r => Mapper.Map<RoleVM>(r))
                                                        .ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
    }

    private async Task<int> GetProjectManagersRoleId(string roleName)
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
            return 0;
        }
    }
    #endregion

    #region Properties Changed Evenets
    private void OnSelectProject(ProjectVM project)
    {
        _selectedProject = project;
        StateHasChanged();
    }
    #endregion

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {

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
