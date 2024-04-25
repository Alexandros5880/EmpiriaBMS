using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Disciplines.Types;

public partial class DisciplineTypes
{
    #region Data Grid
    private List<DisciplineTypeVM> _records = new List<DisciplineTypeVM>();
    private string _filterString = string.Empty;
    IQueryable<DisciplineTypeVM>? FilteredItems => _records?.AsQueryable().Where(x => x.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private DisciplineTypeVM _selectedRecord = new DisciplineTypeVM();

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

    private void HandleRowFocus(FluentDataGridRow<DisciplineTypeVM> row)
    {
        _selectedRecord = row.Item as DisciplineTypeVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.DisciplinesTypes.GetAll();
        _records = Mapper.Map<List<DisciplineTypeVM>>(dtos);
    }

    private void _add()
    {

    }

    private void _edit(DisciplineTypeVM record)
    {

    }

    private async Task _delete(DisciplineTypeVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the dicipline type {record.Name}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.DisciplinesTypes.Delete(record.Id);
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
