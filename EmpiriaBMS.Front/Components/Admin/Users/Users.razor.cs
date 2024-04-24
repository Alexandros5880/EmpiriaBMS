using EmpiriaBMS.Front.Components.General;
using EmpiriaBMS.Front.Interop.TeamsSDK;
using EmpiriaBMS.Front.Services;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.DefaultComponents;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.Admin.Users;

public partial class Users
{
    #region Data Grid
    private List<UserVM> _records = new List<UserVM>();
    private string _filterString = string.Empty;
    IQueryable<UserVM>? FilteredItems => _records?.AsQueryable().Where(x => x.FullName.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };
    
    private UserVM _selectedRecord = new UserVM();

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

    private void HandleRowFocus(FluentDataGridRow<UserVM> row)
    {
        _selectedRecord = row.Item as UserVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.Users.GetAll();
        _records = Mapper.Map<List<UserVM>>(dtos);
    }

    private void _add()
    {

    }

    private void _edit(UserVM record)
    {

    }

    private void _delete(UserVM record)
    {

    }
    #endregion

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _getRecords();

            StateHasChanged();
        }
    }
}
