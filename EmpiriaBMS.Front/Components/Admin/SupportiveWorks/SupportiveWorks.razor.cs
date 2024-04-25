using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.SupportiveWorks;

public partial class SupportiveWorks
{
    #region Data Grid
    private List<OtherVM> _records = new List<OtherVM>();
    private string _filterString = string.Empty;
    IQueryable<OtherVM>? FilteredItems => _records?.AsQueryable().Where(x => x.TypeName.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private OtherVM _selectedRecord = new OtherVM();

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

    private void HandleRowFocus(FluentDataGridRow<OtherVM> row)
    {
        _selectedRecord = row.Item as OtherVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.Others.GetAll();
        _records = Mapper.Map<List<OtherVM>>(dtos);
    }

    private void _add()
    {

    }

    private void _edit(OtherVM record)
    {

    }

    private void _delete(OtherVM record)
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
