using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Projects.Offers.Types;

public partial class OfferTypes
{
    #region Data Grid
    private List<OfferTypeVM> _records = new List<OfferTypeVM>();
    private string _filterString = string.Empty;
    IQueryable<OfferTypeVM>? FilteredItems => _records?.AsQueryable().Where(x => x.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private OfferTypeVM _selectedRecord = new OfferTypeVM();

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

    private void HandleRowFocus(FluentDataGridRow<OfferTypeVM> row)
    {
        _selectedRecord = row.Item as OfferTypeVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.OfferTypes.GetAll();
        _records = Mapper.Map<List<OfferTypeVM>>(dtos);
    }

    private void _add()
    {

    }

    private void _edit(OfferTypeVM record)
    {

    }

    private void _delete(OfferTypeVM record)
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
