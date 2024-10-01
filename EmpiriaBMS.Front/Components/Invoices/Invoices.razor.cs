using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.Interop.TeamsSDK;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData;
using EmpiriaBMS.Models.Enum;
using Microsoft.AspNetCore.Components;
using Microsoft.CodeAnalysis;
using Microsoft.Fast.Components.FluentUI;
using EmpiriaBMS.Front.Components.Admin.Invoices;
using EmpiriaBMS.Front.Horizontal;

namespace EmpiriaBMS.Front.Components.Invoices;

public partial class Invoices : ComponentBase
{
    private bool _loading = false;

    [Parameter]
    public EventCallback<InvoiceVM> OnSelect { get; set; }

    [Parameter]
    public bool IsWorkingMode { get; set; } = false;

    [Parameter]
    public InvoiceCategory InvoiceCategory { get; set; }

    [Parameter]
    public bool DisplayTitle { get; set; } = false;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            if (_loading == false)
            {
                _loading = true;
                StateHasChanged();
            }

            if (_invoices == null || _invoices.Count == 0)
                await _getRecords();

            if (_loading == true)
            {
                _loading = false;
                StateHasChanged();
            }
        }
    }

    public async Task Refresh()
    {
        if (_loading == false)
        {
            _loading = true;
            StateHasChanged();
        }

        await _getRecords();

        if (_loading == true)
        {
            _loading = false;
            StateHasChanged();
        }
    }

    #region Data Grid
    public List<InvoiceVM> _invoices { get; set; }
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    [Parameter]
    public InvoiceVM SelectedRecord { get; set; } = new InvoiceVM();

    private async Task HandleRowFocus(FluentDataGridRow<InvoiceVM> row)
    {
        SelectedRecord = row.Item as InvoiceVM;
        await OnSelect.InvokeAsync(SelectedRecord);
        StateHasChanged();
        // Yield control to ensure the UI is updated before proceeding
        await Task.Yield();
        await MicrosoftTeams.ScrollToElement("invoice-detailes");
    }

    private bool IsRowSelect(int rowId)
    {
        return SelectedRecord?.Id == rowId;
    }

    private async Task _getRecords()
    {
        var dtosInv = await DataProvider.Invoices.GetAll(InvoiceCategory);
        _invoices = Mapper.Map<List<InvoiceVM>>(dtosInv);
    }

    private async Task _add()
    {
        SelectedRecord = new InvoiceVM()
        {
            EstimatedPayment = DateTime.Now,
            ActualPayment = DateTime.Now,
            Category = InvoiceCategory
        };

        var title = InvoiceCategory == EmpiriaBMS.Models.Enum.InvoiceCategory.INCOMES ? "Income" : "Expense";

        // DisplayProject

        MyDialogParameters parameters = new()
        {
            Title = $"New {title}",
            PrimaryActionEnabled = true,
            SecondaryActionEnabled = true,
            PrimaryAction = "Save",
            SecondaryAction = "Cancel",
            TrapFocus = true,
            Modal = true,
            PreventScroll = true,
            Width = "50vw;",
            Height = "85vh;",
            DisplayProject = true,
            IsWorkingMode = IsWorkingMode,
            InvoiceCategory = InvoiceCategory
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<InvoiceDetailedDialog>(SelectedRecord, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            await Refresh();
        }
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
    #endregion

    #region Filters
    private string _filterProjectString = string.Empty;
    private string _filterNumberString = string.Empty;
    IQueryable<InvoiceVM>? FilteredItems => 
        _invoices?.AsQueryable().Where(i => _filterOnQuery(i));

    private void HandleProjectFilter(ChangeEventArgs args)
    {
        if (args.Value is string value)
        {
            _filterProjectString = value;
        }
        else if (string.IsNullOrWhiteSpace(_filterProjectString) || string.IsNullOrEmpty(_filterProjectString))
        {
            _filterProjectString = string.Empty;
        }
    }

    private void HandleNumberFilter(ChangeEventArgs args)
    {
        if (args.Value is string value)
        {
            _filterNumberString = value;
        }
        else if (string.IsNullOrWhiteSpace(_filterNumberString) || string.IsNullOrEmpty(_filterNumberString))
        {
            _filterNumberString = string.Empty;
        }
    }
    
    private bool _filterOnQuery(InvoiceVM invoice)
    {
        var projectFilter = invoice.ProjectName
                .Contains(_filterProjectString, StringComparison.CurrentCultureIgnoreCase);

        var numberFilter = string.IsNullOrEmpty(_filterNumberString)
            || invoice.InvoiceNumber == Convert.ToInt32(_filterNumberString);

        return projectFilter && numberFilter;
    }
    #endregion

    #region Export Data
    private async Task _exportToCSV()
    {
        var date = DateTime.Today;

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
