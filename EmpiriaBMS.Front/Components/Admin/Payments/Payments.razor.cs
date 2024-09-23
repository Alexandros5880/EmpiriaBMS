using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Payments;

public partial class Payments
{
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

    private async Task _getRecords()
    {
        var dtos = await DataProvider.Payments.GetAll();
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
            Content = new PaymentVM(),
            DisplayInvoiceSelection = true,
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<PaymentDetailedDialog>(param, parameters);
        DialogResult result = await dialog.Result;

        if (result.Data is not null)
        {
            PaymentVM vm = result.Data as PaymentVM;
            var dto = Mapper.Map<PaymentDto>(vm);
            await DataProvider.Payments.Add(dto);
            await _getRecords();
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
            DisplayInvoiceSelection = true,
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<PaymentDetailedDialog>(param, parameters);
        DialogResult result = await dialog.Result;

        if (result.Data is not null)
        {
            PaymentVM vm = result.Data as PaymentVM;
            var dto = Mapper.Map<PaymentDto>(vm);
            await DataProvider.Payments.Update(dto);
            await _getRecords();
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

    #region Import/Export Data
    private async Task ExportToCSV()
    {
        var date = DateTime.Today;
        var fileName = $"Payments-{date.ToEuropeFormat()}.csv";
        var data = FilteredItems.Select(c => new PaymentExport(c)).ToList();
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
                List<PaymentExport> data = await Data.ImportDataFromCsv<PaymentExport>(stream);
                if (data != null && data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        var vm = item.Get();
                        var dto = Mapper.Map<PaymentDto>(vm);
                        var added = await DataProvider.Payments.Add(dto);
                        if (added == null)
                            continue;
                        var addedDto = Mapper.Map<PaymentVM>(added);
                        _records.Add(addedDto);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception Payments.ImportFromCSV(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
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
