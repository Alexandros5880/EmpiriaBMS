using EmpiriaBMS.Front.Components.General;
using EmpiriaBMS.Front.Interop.TeamsSDK;
using EmpiriaBMS.Front.Services;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.DefaultComponents;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.Admin.Users;

public partial class Users
{
    private Paginator _paginator;
    private ObservableCollection<UserVM> _users = new ObservableCollection<UserVM>();
    private UserVM _selectedUser = new UserVM();

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _paginator.SetRecordsLength(await DataProvider.Users.Count());
            await _getUsers();

            StateHasChanged();
        }
    }

    private async Task _getUsers()
    {
        var dtos = await DataProvider.Users.GetAll(_paginator.PageSize, _paginator.PageIndex);
        var vms = Mapper.Map<List<UserVM>>(dtos);
        _users.Clear();
        vms.ForEach(_users.Add);
    }

    private void _onSelectUser(int id)
    {
        _selectedUser = _users.FirstOrDefault(u => u.Id == id);
    }

    protected override bool ShouldRender()
    {
        // Return false to prevent the entire component from re-rendering
        return true;
    }
}
