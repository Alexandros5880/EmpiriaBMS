using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.Interop.TeamsSDK;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData;
using Microsoft.AspNetCore.Components;
using Microsoft.CodeAnalysis;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Invoices;

public partial class Invoices : ComponentBase
{
    [Parameter]
    public EventCallback<InvoiceVM> OnSelect { get; set; }

    #region Data Grid
    public List<InvoiceVM> _invoices { get; set; }
    private string _filterString = string.Empty;
    IQueryable<InvoiceVM>? FilteredItems => _invoices?.AsQueryable().Where(x => x.ProjectName.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private Dictionary<int, double> _pendingPayments = new Dictionary<int, double>();

    [Parameter]
    public InvoiceVM SelectedRecord { get; set; } = new InvoiceVM();

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

    public async Task Refresh() => await _getRecords();

    private async Task HandleRowFocus(FluentDataGridRow<InvoiceVM> row)
    {
        SelectedRecord = row.Item as InvoiceVM;
        await OnSelect.InvokeAsync(SelectedRecord);
    }

    private bool IsRowSelect(int rowId)
    {
        return SelectedRecord.Id == rowId;
    }

    private async Task _getRecords()
    {
        var dtosInv = await DataProvider.Invoices.GetAll();
        _invoices = Mapper.Map<List<InvoiceVM>>(dtosInv);
        await _loadPendingPayments();
    }

    private async Task _loadPendingPayments()
    {
        foreach (var item in _invoices)
        {
            _pendingPayments[item.Id] = await DataProvider.Invoices.GetSumOfPotencialFee(item.Id);
        }
    }

    private async Task _add()
    {
        SelectedRecord = new InvoiceVM()
        {
            EstimatedDate = DateTime.Now,
            PaymentDate = DateTime.Now,
        };
        StateHasChanged();
        await OnSelect.InvokeAsync(SelectedRecord);

        //DialogParameters parameters = new()
        //{
        //    Title = $"New Record",
        //    PrimaryActionEnabled = true,
        //    SecondaryActionEnabled = true,
        //    PrimaryAction = "Save",
        //    SecondaryAction = "Cancel",
        //    TrapFocus = true,
        //    Modal = true,
        //    PreventScroll = true,
        //    Width = "min(70%, 500px);"
        //};

        //IDialogReference dialog = await DialogService.ShowDialogAsync<InvoiceDetailedDialog>(new InvoiceVM(), parameters);
        //DialogResult? result = await dialog.Result;

        //if (result.Data is not null)
        //{
        //    InvoiceVM vm = result.Data as InvoiceVM;
        //    var dto = Mapper.Map<InvoiceDto>(vm);
        //    await DataProvider.Invoices.Add(dto);
        //    await _getRecords();
        //}
    }

    //private async Task _edit(InvoiceVM record)
    //{
    //    DialogParameters parameters = new()
    //    {
    //        Title = $"Edit {record.Project?.Name: 'Record'}",
    //        PrimaryActionEnabled = true,
    //        SecondaryActionEnabled = true,
    //        PrimaryAction = "Save",
    //        SecondaryAction = "Cancel",
    //        TrapFocus = true,
    //        Modal = true,
    //        PreventScroll = true,
    //        Width = "min(70%, 500px);"
    //    };

    //    IDialogReference dialog = await DialogService.ShowDialogAsync<InvoiceDetailedDialog>(record, parameters);
    //    DialogResult? result = await dialog.Result;

    //    if (result.Data is not null)
    //    {
    //        InvoiceVM vm = result.Data as InvoiceVM;
    //        var dto = Mapper.Map<InvoiceDto>(vm);
    //        await DataProvider.Invoices.Update(dto);
    //        await _getRecords();
    //    }
    //}

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

    private async Task<double> _getPendingPaiment(InvoiceVM record)
    {

        return 0.0;
    }
    #endregion

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            if (_invoices == null || _invoices.Count == 0)
                await _getRecords();

            StateHasChanged();
        }
    }

    #region Export Data
    private async Task _exportToCSV()
    {
        var date = DateTime.Today;

        var invoice = FilteredItems.FirstOrDefault(i => i.Contract != null);

        // Export Invoices
        var invoicesFileName = $"Invoices-{date.ToEuropeFormat()}.csv";
        var invoices = FilteredItems.Select(_getInvExport).ToList();
        if (invoices.Count > 0)
        {
            string csvContent = Data.GetCsvContent(invoices);
            await MicrosoftTeams.DownloadCsvFile(invoicesFileName, csvContent);
        }

        // Export Payments
        var paymentsFileName = $"Payments-{date.ToEuropeFormat()}.csv";
        var invoicesIds = FilteredItems.Select(i => i.Id).ToArray();
        var payments = await DataProvider.Payments.GetAllByInvoices(invoicesIds);
        var paymentsExp = payments.Select(_getPayExport).ToList();
        if (paymentsExp.Count > 0)
        {
            string csvContent = Data.GetCsvContent(paymentsExp);
            await MicrosoftTeams.DownloadCsvFile(paymentsFileName, csvContent);
        }
    }

    private InvoiceExport _getInvExport(InvoiceVM inv)
    {
        var exp = new InvoiceExport(inv);
        return exp;
    }

    private PaymentExport _getPayExport(PaymentDto pay)
    {
        var vm = Mapper.Map<PaymentVM>(pay);
        var exp = new PaymentExport(vm);
        return exp;
    }
    #endregion
}
