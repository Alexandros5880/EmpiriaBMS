using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Projects.Invoices.Types;

public partial class InvoiceTypes
{
    #region Data Grid
    private List<InvoiceTypeVM> _records = new List<InvoiceTypeVM>();
    private string _filterString = string.Empty;
    IQueryable<InvoiceTypeVM>? FilteredItems => _records?.AsQueryable().Where(x => x.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private InvoiceTypeVM _selectedRecord = new InvoiceTypeVM();

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

    private void HandleRowFocus(FluentDataGridRow<InvoiceTypeVM> row)
    {
        _selectedRecord = row.Item as InvoiceTypeVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.InvoiceTypes.GetAll();
        _records = Mapper.Map<List<InvoiceTypeVM>>(dtos);
    }

    private void _add()
    {

    }

    private void _edit(InvoiceTypeVM record)
    {

    }

    private void _delete(InvoiceTypeVM record)
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
