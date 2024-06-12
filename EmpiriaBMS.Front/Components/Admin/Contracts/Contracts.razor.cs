using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.Interop.TeamsSDK;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Contracts;

public partial class Contracts
{
    #region Data Grid
    private List<InvoiceVM> _invoices = new List<InvoiceVM>();
    private List<ContractVM> _records = new List<ContractVM>();
    private string _filterString = string.Empty;
    IQueryable<ContractVM>? FilteredItems => _records?.AsQueryable().Where(x => x.Description.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private ContractVM _selectedRecord = new ContractVM();

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

    private void HandleRowFocus(FluentDataGridRow<ContractVM> row)
    {
        _selectedRecord = row.Item as ContractVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.Contracts.GetAll();
        _records = Mapper.Map<List<ContractVM>>(dtos);

        _invoices.Clear();
        var invoicesIds = dtos.Select(c => c.InvoiceId).ToHashSet();
        foreach (var invoiceId in invoicesIds)
        {
            var invDto = await DataProvider.Invoices.Get(invoiceId);
            var invVm = Mapper.Map<InvoiceVM>(invDto);
            _invoices.Add(invVm);
        }
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

        IDialogReference dialog = await DialogService.ShowDialogAsync<ContractDetailedDialog>(new ContractVM(), parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            ContractVM vm = result.Data as ContractVM;
            var dto = Mapper.Map<ContractDto>(vm);
            await DataProvider.Contracts.Add(dto);
            await _getRecords();
        }
    }

    private async Task _edit(ContractVM record)
    {
        record.Invoice = _getInvoice(record.InvoiceId);
        DialogParameters parameters = new()
        {
            Title = $"Edit contract for {record.Invoice?.Project?.Name} project",
            PrimaryActionEnabled = true,
            SecondaryActionEnabled = true,
            PrimaryAction = "Save",
            SecondaryAction = "Cancel",
            TrapFocus = true,
            Modal = true,
            PreventScroll = true,
            Width = "min(70%, 500px);"
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<ContractDetailedDialog>(record, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            ContractVM vm = result.Data as ContractVM;
            var dto = Mapper.Map<ContractDto>(vm);
            await DataProvider.Contracts.Update(dto);
            await _getRecords();
        }
    }

    private async Task _delete(ContractVM record)
    {
        record.Invoice = _getInvoice(record.InvoiceId);
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete contract of project {record.Invoice?.Project?.Name ?? "--"}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.Contracts.Delete(record.Id);
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

    private InvoiceVM _getInvoice(int invoiceId) =>
        _invoices.FirstOrDefault(i => i.Id == invoiceId);

    #region Import/Export Data
    private async Task ExportToCSV()
    {
        var date = DateTime.Today;
        var fileName = $"Contracts-{date.ToEuropeFormat()}.csv";
        var data = FilteredItems.Select(c => new ContractExport(c)).ToList();
        if (data.Count > 0)
        {
            string csvContent = Data.GetCsvContent(data);
            await MicrosoftTeams.DownloadCsvFile(fileName, csvContent);
        }
    }

    private InputFile fileInput;
    private async Task ImportFromCSV(InputFileChangeEventArgs e)
    {
        var file = e.File;
        var filePath = file.Name;
        var fileType = file.ContentType;
        if (fileType?.Equals("text/csv") ?? false)
        {
            try
            {
                Stream stream = file.OpenReadStream();
                await Data.ImportData<ContractExport>(stream);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Contracts import: {ex.Message}, \nInner: {ex.InnerException?.Message}");
                // TODO: log error
            }
        }
    }
    private async Task TriggerFileInput()
    {
        var element = fileInput.Element;
        await MicrosoftTeams.TriggerFileInputClick(element);
    }
    #endregion
}
