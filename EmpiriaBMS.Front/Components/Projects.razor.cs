using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.ReturnModels;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.DefaultComponents;
using EmpiriaBMS.Models.Models;
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

    // List
    private ObservableCollection<ProjectVM> _projects = new ObservableCollection<ProjectVM>();
    private ObservableCollection<DisciplineVM> _disciplines = new ObservableCollection<DisciplineVM>();
    private ObservableCollection<DrawVM> _draws = new ObservableCollection<DrawVM>();
    private ObservableCollection<DocVM> _docs = new ObservableCollection<DocVM>();

    // Selected Models
    private ProjectVM _selectedProject = new ProjectVM();
    private DisciplineVM _selectedDiscipline = new DisciplineVM();
    private DrawVM _selectedDraw = new DrawVM();
    private DocVM _selectedDoc = new DocVM();

    // Paginator
    private PaginatorVM _paginator = new PaginatorVM(7);

    // Basic Models
    private UserVM _logedUser;
    private ICollection<RoleVM> _loggedUserRoles = new List<RoleVM>();
    private bool _logesUserChanged = false;

    protected override async void OnInitialized()
    {
        base.OnInitialized();
        await _getLogedUser();
        await _getProjects();
        startLoading = false;
        StateHasChanged();
    }

    #region Get Records
    private async Task _getProjects()
    {
        _selectedProject = null;
        _selectedDiscipline = null;
        _selectedDraw = null;
        _selectedDoc = null;
        _disciplines.Clear();
        _draws.Clear();
        _docs.Clear();

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


            var projectsVm = Mapper.Map<List<ProjectDto>, List<ProjectVM>>(projectsDto);

            _projects.Clear();
            projectsVm.ForEach(_projects.Add);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
        startLoading = false;
        filterLoading = !startLoading ? false : filterLoading;
    }

    private async Task _getLogedUser()
    {
        try
        {
            // TODO: Get Teams Loged User And Mach him With Oure Users

            var defaultRoleId = await GetProjectManagersRoleId("Draftsmen");
            if (defaultRoleId == 0)
                throw new Exception("Exception `Project Managers` role not exists!");

            var users = await DataProvider.Roles.GetUsers(defaultRoleId);
            var dbUser = users.FirstOrDefault();

            if (dbUser == null)
                throw new Exception("Exception user with `Draftsmen` role not exists!");

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
    private async Task OnSelectProject(ProjectVM project)
    {
        _draws.Clear();
        _docs.Clear();
        _selectedProject = project;
        var disciplines = await DataProvider.Projects.GetDisciplines(project.Id);

        _disciplines.Clear();
        foreach (var di in disciplines)
            _disciplines.Add(Mapper.Map<DisciplineVM>(di));
        
        StateHasChanged();
    }

    private async Task OnSelectDiscipline(DisciplineVM discipline)
    {
        _selectedDiscipline = discipline;

        var draws = await DataProvider.Disciplines.GetDraws(discipline.Id);
        var docs = await DataProvider.Disciplines.GetDocs(discipline.Id);
        await _getLogedUser();

        _draws.Clear();
        foreach (var di in draws)
            _draws.Add(Mapper.Map<DrawVM>(di));

        _docs.Clear();
        foreach (var di in docs)
            _docs.Add(Mapper.Map<DocVM>(di));


        StateHasChanged();
    }

    private void OnSelectDraw(DrawVM draw)
    {
        _selectedDraw = draw;
        StateHasChanged();
    }

    private void OnSelectDoc(DocVM doc)
    {
        _selectedDoc = doc;
        StateHasChanged();
    }
    
    private async Task _onDrawHoursChanged(DrawVM draw, object val)
    {
        var previusValue = draw.ManHours;
        var value = Convert.ToInt32(val) > previusValue ? Convert.ToInt32(val) - previusValue : -(previusValue - Convert.ToInt32(val));
        draw.ManHours = Convert.ToInt32(val);
        _selectedProject.ManHours += (int?)value;
        _logedUser.Hours += value;
        _selectedDraw = draw;

        CompletedResult complete = await DataProvider.Projects.CalcProjectComplete(
                                    Mapper.Map<ProjectDto>(_selectedProject), 
                                    Mapper.Map<DrawDto>(_selectedDraw));

        _selectedDraw.Completed = complete.DrawCompleted;
        //_selectedDoc.Completed = complete.DrawCompleted;
        _selectedDiscipline.Completed = complete.DisciplineCompleted;
        _selectedProject.Completed = complete.ProjectCompleted;

        StateHasChanged();
    }

    private async Task _onDocHoursChanged(DocVM doc, object val)
    {
        var previusValue = doc.ManHours;
        var value = Convert.ToInt32(val) > previusValue ? Convert.ToInt32(val) - previusValue : -(previusValue - Convert.ToInt32(val));
        doc.ManHours = Convert.ToInt32(val);
        _selectedProject.ManHours += (int?)value;
        _logedUser.Hours += value;
        _selectedDoc = doc;

        CompletedResult complete = await DataProvider.Projects.CalcProjectComplete(
                                    Mapper.Map<ProjectDto>(_selectedProject),
                                    Mapper.Map<DocDto>(_selectedDoc));

        //_selectedDraw.Completed = complete.DrawCompleted;
        _selectedDoc.Completed = complete.DrawCompleted;
        _selectedDiscipline.Completed = complete.DisciplineCompleted;
        _selectedProject.Completed = complete.ProjectCompleted;

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
