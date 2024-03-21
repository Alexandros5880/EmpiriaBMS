using AutoMapper;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Front.Components.Admin.DisciplinesTypes;
using System.Linq.Expressions;

namespace EmpiriaBMS.Front.Components;
public partial class ProjectDetailed : ComponentBase, IDisposable
{
    private bool disposedValue;
    private bool isNew = false;
    private string defaultCodeValue = "*******";

    #region Authorization Properties
    bool seeCode => _sharedAuthData.Permissions.Any(p => p.Ord == 13);
    #endregion

    List<ProjectTypeDto> _projectTypes = new List<ProjectTypeDto>();
    List<DisciplineTypeDto> _disciplineTypes = new List<DisciplineTypeDto>();
    private ProjectVM _project = new ProjectVM();
    List<DisciplineVM> _disciplines = new List<DisciplineVM>();

    private async Task _getProjectTypes() =>
        _projectTypes = (await DataProvider.ProjectsTypes.GetAll()).ToList();

    private async Task _getDisciplineTypes() =>
        _disciplineTypes = (await DataProvider.DisciplinesTypes.GetAll()).ToList();

    private async Task _getMyDisciplines()
    {
        if (_project == null)
            throw new NullReferenceException(nameof(_project));
        Expression<Func<Discipline, bool>> expression = d => d.ProjectId == _project.Id;
        List<DisciplineDto> disc = (await DataProvider.Disciplines.GetAll(expression)).ToList();
        _disciplines = Mapper.Map<List<DisciplineVM>>(disc);
    }

    public async void PrepairForNew()
    {
        isNew = true;
        await _getProjectTypes();
        await _getDisciplineTypes();
        _project = new ProjectVM();
        StateHasChanged();
    }

    public async void PrepairForEdit(ProjectVM project)
    {
        isNew = false;
        await _getProjectTypes();
        await _getDisciplineTypes();
        _project = project;
        await _getMyDisciplines();
        StateHasChanged();
    }

    public async Task HandleValidSubmit()
    {
        // TODO: Update subConstructon and customer validate and save.
        var exists = await DataProvider.Projects.Any(p =>  p.Id == _project.Id);
        if (exists)
            await DataProvider.Projects.Update(Mapper.Map<ProjectDto>(_project));
        else
            await DataProvider.Projects.Add(Mapper.Map<ProjectDto>(_project));
    }

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
