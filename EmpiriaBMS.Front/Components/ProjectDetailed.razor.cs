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
    List<ProjectTypeDto> projectTypes = new List<ProjectTypeDto>();
    private InvoiceVM _invoice = new InvoiceVM();
    private ProjectVM _project = new ProjectVM();
    private UserVM _customer = new UserVM();
    private UserVM _subConstructor = new UserVM();

    private async Task _getProjectTypes()
    {
        projectTypes = (await DataProvider.ProjectsTypes.GetAll()).ToList();
    }

    public async void PrepairForNew()
    {
        await _getProjectTypes();
        _project = new ProjectVM();
        _invoice = new InvoiceVM();
        _customer = new UserVM();
        _subConstructor = new UserVM();
        StateHasChanged();
    }

    public async void PrepairForEdit(ProjectVM project)
    {
        await _getProjectTypes();
        _project = project;
        var invDto = await DataProvider.Invoices.Get((int)_project.InvoiceId);
        _invoice = Mapper.Map<InvoiceVM>(invDto);
        var userDto = await DataProvider.Users.Get((int)_project.CustomerId);
        _customer = Mapper.Map<UserVM>(userDto);
        var subConstructorDto = await DataProvider.Users.Get((int)_project.SubContractorId);
        _subConstructor = Mapper.Map<UserVM>(subConstructorDto);
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
