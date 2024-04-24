using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Projects.Offers.States;

public partial class OfferStates
{
    #region Data Grid
    private List<OfferStateVM> _records = new List<OfferStateVM>();
    private string _filterString = string.Empty;
    IQueryable<OfferStateVM>? FilteredItems => _records?.AsQueryable().Where(x => x.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private OfferStateVM _selectedRecord = new OfferStateVM();

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

    private void HandleRowFocus(FluentDataGridRow<OfferStateVM> row)
    {
        _selectedRecord = row.Item as OfferStateVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.OfferStates.GetAll();
        _records = Mapper.Map<List<OfferStateVM>>(dtos);
    }

    private void _add()
    {

    }

    private void _edit(OfferStateVM record)
    {

    }

    private void _delete(OfferStateVM record)
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
