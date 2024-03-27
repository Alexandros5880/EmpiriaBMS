using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;

namespace EmpiriaBMS.Front.Components;

public partial class UserDetailed : ComponentBase, IDisposable
{
    private bool disposedValue;

    [Parameter]
    public string Title { get; set; }

    [Parameter]
    public UserVM User { get; set; }

    private List<ProjectVM> _projects = new List<ProjectVM>();

    private async Task _getProjects()
    {
        var dtos = await DataProvider.Projects.GetAll();
        _projects = Mapper.Map<List<ProjectVM>>(dtos);
    }

    public async void PrepairForNew()
    {
        await _getProjects();
        StateHasChanged();
    }

    public async void PrepairForEdit(ProjectVM project)
    {
        await _getProjects();
        StateHasChanged();
    }

    public async Task HandleValidSubmit()
    {
        var exists = await DataProvider.Users.Any(p => p.Id == User.Id);
        if (exists)
            await DataProvider.Users.Update(Mapper.Map<UserDto>(User));
        else
            await DataProvider.Users.Add(Mapper.Map<UserDto>(User));
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
