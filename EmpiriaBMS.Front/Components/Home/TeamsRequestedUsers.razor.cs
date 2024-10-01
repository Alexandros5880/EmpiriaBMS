using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Home;

public partial class TeamsRequestedUsers : ComponentBase
{
    [Parameter]
    public List<TeamsRequestedUserVM> Source { get; set; }

    [Parameter]
    public EventCallback OnSave { get; set; }

    #region Data Grid
    private string _filterString = string.Empty;
    IQueryable<TeamsRequestedUserVM> FilteredItems => Source?.AsQueryable().Where(x => x.DisplayName.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 5 };

    private TeamsRequestedUserVM _selectedRecord = null;
    private UserVM _selectedUser = null;

    private void HandleFilter(ChangeEventArgs args)
    {
        if (args.Value is string value)
        {
            _filterString = value;
        }
        else if (string.IsNullOrWhiteSpace(_filterString) || string.IsNullOrEmpty(_filterString))
        {
            _filterString = string.Empty;
        }
    }

    private void OnRowFocused(FluentDataGridRow<TeamsRequestedUserVM> row)
    {
        var r = row;
        var record = r.Item as TeamsRequestedUserVM;
        if (record == null)
            return;
        _selectedRecord = record;
        var names = record.DisplayName.Split(' ');
        _selectedUser = new UserVM()
        {
            FirstName = names[0],
            LastName = names[1],
            ProxyAddress = record.ProxyAddress,
            TeamsObjectId = record.ObjectId,
        };
    }
    #endregion

    public async Task OnCreateUser(UserVM user)
    {
        Source.Remove(_selectedRecord);
        var dto = Mapper.Map<UserDto>(user);
        var added = await DataProvider.Users.Add(dto);
        if (added != null)
        {
            await DataProvider.TeamsRequestedUsers.DeleteByObjectId(user.TeamsObjectId);

            _selectedRecord = null;
            _selectedUser = null;
        }

        StateHasChanged();

        await OnSave.InvokeAsync(user);
    }

    public async Task OnCreateUserCancel()
    {
        _selectedRecord = null;
        _selectedUser = null;
    }

}