using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Permissions;

public partial class Permissions
{
    #region Data Grid
    private List<PermissionVM> _records = new List<PermissionVM>();
    private string _filterString = string.Empty;
    IQueryable<PermissionVM>? FilteredItems => _records?.AsQueryable().Where(x => x.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private PermissionVM _selectedRecord = new PermissionVM();

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

    private void HandleRowFocus(FluentDataGridRow<PermissionVM> row)
    {
        _selectedRecord = row.Item as PermissionVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.Permissions.GetAll();
        _records = Mapper.Map<List<PermissionVM>>(dtos);
    }

    private void _add()
    {

    }

    private void _edit(PermissionVM record)
    {

    }

    private async Task _delete(PermissionVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the permission {record.Name}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.Permissions.Delete(record.Id);
        }

        await dialog.CloseAsync();
        await _getRecords();
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
