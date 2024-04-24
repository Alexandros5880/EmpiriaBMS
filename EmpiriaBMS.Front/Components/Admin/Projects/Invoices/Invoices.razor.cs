using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Projects.Invoices;

public partial class Invoices
{
    #region Data Grid
    private List<InvoiceVM> _records = new List<InvoiceVM>();
    private string _filterString = string.Empty;
    IQueryable<InvoiceVM>? FilteredItems => _records?.AsQueryable().Where(x => x.ProjectName.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private InvoiceVM _selectedRecord = new InvoiceVM();

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

    private void HandleRowFocus(FluentDataGridRow<InvoiceVM> row)
    {
        _selectedRecord = row.Item as InvoiceVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.Invoices.GetAll();
        _records = Mapper.Map<List<InvoiceVM>>(dtos);
    }

    private void _add()
    {

    }

    private void _edit(InvoiceVM record)
    {

    }

    private void _delete(InvoiceVM record)
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
