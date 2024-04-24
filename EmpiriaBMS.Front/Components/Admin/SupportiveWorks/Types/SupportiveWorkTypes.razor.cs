using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.SupportiveWorks.Types;

public partial class SupportiveWorkTypes
{
    #region Data Grid
    private List<OtherTypeVM> _records = new List<OtherTypeVM>();
    private string _filterString = string.Empty;
    IQueryable<OtherTypeVM>? FilteredItems => _records?.AsQueryable().Where(x => x.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private OtherTypeVM _selectedRecord = new OtherTypeVM();

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

    private void HandleRowFocus(FluentDataGridRow<OtherTypeVM> row)
    {
        _selectedRecord = row.Item as OtherTypeVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.OthersTypes.GetAll();
        _records = Mapper.Map<List<OtherTypeVM>>(dtos);
    }

    private void _add()
    {

    }

    private void _edit(OtherTypeVM record)
    {

    }

    private void _delete(OtherTypeVM record)
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
