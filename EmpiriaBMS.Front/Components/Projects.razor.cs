using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.DefaultComponents;
using EmpiriaMS.Models.Models;
using System.Collections.Generic;
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
            List<ProjectDto> projectsDto = (await DataProvider.Projects.GetAll(_paginator.PageSize, _paginator.PageIndex))
                                                                       .ToList<ProjectDto>();


            var projectsVm = Mapping.Mapper.Map<List<ProjectDto>, List<ProjectVM>>(projectsDto);
            // Exception: Error mapping types.
            //System.Collections.Generic.List`1 [EmpiriaBMS.Core.Dtos.ProjectDto] ->
            //      System.Collections.Generic.List`1 [EmpiriaBMS.Front.ViewModel.Components.ProjectVM]



            _projects.Clear();
            projectsVm.ForEach(_projects.Add);
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

            var defaultRoleId = await GetProjectManagersRoleId("Project Manager");
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
            return (await DataProvider.Roles.Get(roleName)).Id;
        }
        catch (Exception ex)
        {
            // TODO: Log Error
            Debug.WriteLine($"Exception: {ex.Message}");
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
