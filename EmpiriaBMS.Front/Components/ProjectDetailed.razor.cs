using AutoMapper;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using EmpiriaBMS.Core.Config;

namespace EmpiriaBMS.Front.Components;
public partial class ProjectDetailed : ComponentBase, IDisposable
{
    private bool disposedValue;
    private string defaultValue = "*******";

    #region Authorization Properties
    bool seeCode => _sharedAuthData.Permissions.Any(p => p.Ord == 13);
    #endregion

    List<ProjectTypeDto> projectTypes = new List<ProjectTypeDto>();
    private ProjectVM _project = new ProjectVM();

    private async Task _getProjectTypes()
    {
        projectTypes = (await DataProvider.ProjectsTypes.GetAll()).ToList();
    }

    public async void PrepairForNew()
    {
        await _getProjectTypes();
        _project = new ProjectVM();
        StateHasChanged();
    }

    public async void PrepairForEdit(ProjectVM project)
    {
        await _getProjectTypes();
        _project = project;
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
