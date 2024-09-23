using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Components.Admin.Payments;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components;

public partial class Payments : ComponentBase
{
    [Parameter]
    public InvoiceVM Invoice { get; set; }

    [Parameter]
    public bool IsWorkingMode { get; set; } = false;

    #region Data Grid
    private List<PaymentVM> _records = new List<PaymentVM>();
    private string _filterString = string.Empty;
    IQueryable<PaymentVM> FilteredItems => _records?.AsQueryable().Where(x => x.ProjectName.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private PaymentVM _selectedRecord = new PaymentVM();

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

    private void HandleRowFocus(FluentDataGridRow<PaymentVM> row)
    {
        _selectedRecord = row.Item as PaymentVM;
    }

    private async Task _getRecords(int invoiceId)
    {
        var dtos = await DataProvider.Payments.GetAllByInvoice(invoiceId);
        _records = Mapper.Map<List<PaymentVM>>(dtos);
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

        PaymentParameter param = new PaymentParameter()
        {
            Content = new PaymentVM()
            {
                InvoiceId = Invoice.Id
            },
            DisplayInvoiceSelection = false,
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<PaymentDetailedDialog>(param, parameters);
        DialogResult result = await dialog.Result;

        if (result.Data is not null)
        {
            PaymentVM vm = result.Data as PaymentVM;
            var dto = Mapper.Map<PaymentDto>(vm);
            await DataProvider.Payments.Add(dto);
            await _getRecords(Invoice.Id);
        }
    }

    private async Task _edit(PaymentVM record)
    {
        DialogParameters parameters = new()
        {
            Title = $"Edit paymeny of project {record.ProjectName} with bank {record.Bank}",
            PrimaryActionEnabled = true,
            SecondaryActionEnabled = true,
            PrimaryAction = "Save",
            SecondaryAction = "Cancel",
            TrapFocus = true,
            Modal = true,
            PreventScroll = true,
            Width = "min(70%, 500px);"
        };

        PaymentParameter param = new PaymentParameter()
        {
            Content = record,
            DisplayInvoiceSelection = false,
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<PaymentDetailedDialog>(param, parameters);
        DialogResult result = await dialog.Result;

        if (result.Data is not null)
        {
            PaymentVM vm = result.Data as PaymentVM;
            var dto = Mapper.Map<PaymentDto>(vm);
            await DataProvider.Payments.Update(dto);
            await _getRecords(Invoice.Id);
        }
    }

    private async Task _delete(PaymentVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the payment of project {record.ProjectName}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.Payments.Delete(record.Id);
        }

        await dialog.CloseAsync();
        await _getRecords(Invoice.Id);
    }
    #endregion

    public async Task Prepair(int invoiceId)
    {
        if (invoiceId != 0)
        {
            await _getRecords(invoiceId);
            StateHasChanged();
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            if (Invoice != null)
            {
                await _getRecords(Invoice.Id);
                StateHasChanged();
            }
        }
    }
}
