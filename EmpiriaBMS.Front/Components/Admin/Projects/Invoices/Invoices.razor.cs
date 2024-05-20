using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Components.Admin.Projects.Offers;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Projects.Invoices;

public partial class Invoices
{
    #region Data Grid
    [Parameter]
    public List<InvoiceVM> Source { get; set; }
    private string _filterString = string.Empty;
    IQueryable<InvoiceVM>? FilteredItems => Source?.AsQueryable().Where(x => x.ProjectName.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
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
        Source = Mapper.Map<List<InvoiceVM>>(dtos);
    }

    private async Task _add()
    {
        DialogParameters parameters = new()
        {
            Title = $"New Record",
            PrimaryActionEnabled = true,
            SecondaryActionEnabled = true,
            PrimaryAction = "Save",
            SecondaryAction = "Cancel",
            TrapFocus = true,
            Modal = true,
            PreventScroll = true,
            Width = "min(70%, 500px);"
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<InvoiceDetailedDialog>(new InvoiceVM(), parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            InvoiceVM vm = result.Data as InvoiceVM;
            var dto = Mapper.Map<InvoiceDto>(vm);
            await DataProvider.Invoices.Add(dto);
            await _getRecords();
        }
    }

    private async Task _edit(InvoiceVM record)
    {
        DialogParameters parameters = new()
        {
            Title = $"Edit {record.Project?.Name: 'Record'}",
            PrimaryActionEnabled = true,
            SecondaryActionEnabled = true,
            PrimaryAction = "Save",
            SecondaryAction = "Cancel",
            TrapFocus = true,
            Modal = true,
            PreventScroll = true,
            Width = "min(70%, 500px);"
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<InvoiceDetailedDialog>(record, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            InvoiceVM vm = result.Data as InvoiceVM;
            var dto = Mapper.Map<InvoiceDto>(vm);
            await DataProvider.Invoices.Update(dto);
            await _getRecords();
        }
    }

    private async Task _delete(InvoiceVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete invoice type{record.TypeName} of project {record.ProjectName}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.Invoices.Delete(record.Id);
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
            if (Source == null || Source.Count > 0)
                await _getRecords();

            StateHasChanged();
        }
    }
}
