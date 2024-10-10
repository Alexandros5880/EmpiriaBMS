using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Components.General;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.Home;

public partial class TeamsRequestedUsers : ComponentBase
{
    private bool _loading = false;

    [Parameter]
    public EventCallback OnSave { get; set; }

    private ObservableCollection<TeamsRequestedUserVM> _teamsRequestedUsers = new ObservableCollection<TeamsRequestedUserVM>();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _loading = true;

            await _getTeamsRequestedUsersCount();

            _loading = false;
            StateHasChanged();
        }
    }

    #region Data Grid
    private string _filterString = string.Empty;
    IQueryable<TeamsRequestedUserVM> FilteredItems => _teamsRequestedUsers?.AsQueryable().Where(x => x.DisplayName.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
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
        _teamsRequestedUsers.Remove(_selectedRecord);
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

    public void OnCreateUserCancel()
    {
        _selectedRecord = null;
        _selectedUser = null;
    }

    private async Task _getTeamsRequestedUsersCount()
    {
        try
        {
            var requestedUsersDtos = await DataProvider.TeamsRequestedUsers.GetAll();

            // TODO: Only For Debug
            for (int i = 0; i < 10; i++)
            {
                requestedUsersDtos.Add(new TeamsRequestedUserDto()
                {
                    DisplayName = $"User - {i}",    
                    ProxyAddress = $"alexandrosplatanios{i}@gmail.com",
                    ObjectId = Guid.NewGuid().ToString()
                });
            }

            var requestedUsersVms = Mapper.Map<List<TeamsRequestedUserVM>>(requestedUsersDtos);
            _teamsRequestedUsers.Clear();
            requestedUsersVms.ForEach(_teamsRequestedUsers.Add);
        }
        catch (Exception ex)
        {
            Logger.LogError($"Exception TeamsRequestedUsers._getTeamsRequestedUsersCount(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
            throw;
        }
    }

}