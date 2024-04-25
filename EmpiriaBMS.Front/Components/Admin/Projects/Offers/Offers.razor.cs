using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Projects.Offers;

public partial class Offers
{
    #region Data Grid
    private List<OfferVM> _records = new List<OfferVM>();
    private string _filterString = string.Empty;
    IQueryable<OfferVM>? FilteredItems => _records?.AsQueryable().Where(x => x.ProjectName.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private OfferVM _selectedRecord = new OfferVM();

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

    private void HandleRowFocus(FluentDataGridRow<OfferVM> row)
    {
        _selectedRecord = row.Item as OfferVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.Offers.GetAll();
        _records = Mapper.Map<List<OfferVM>>(dtos);
    }

    private void _add()
    {

    }

    private void _edit(OfferVM record)
    {

    }

    private async Task _delete(OfferVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the offer of type {record.TypeName} of project {record.ProjectName}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.Offers.Delete(record.Id);
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
