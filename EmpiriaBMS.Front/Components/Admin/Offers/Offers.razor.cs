using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.Interop.TeamsSDK;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Offers;

public partial class Offers
{
    #region Data Grid
    private List<OfferVM> _records = new List<OfferVM>();
    private string _filterString = string.Empty;
    IQueryable<OfferVM> FilteredItems => _records?.AsQueryable();//.Where(x => x.ProjectName.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
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
            Width = "min(70vw, 700px);",
            Height = "max(70vh, 700px) !important;",
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<OfferDetailedDialog>(new OfferVM(), parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            OfferVM vm = result.Data as OfferVM;
            var dto = Mapper.Map<OfferDto>(vm);
            await DataProvider.Offers.Add(dto);
            await _getRecords();
        }
    }

    private async Task _edit(OfferVM record)
    {
        DialogParameters parameters = new()
        {
            Title = $"Edit {record.TypeName: 'Record'}",
            PrimaryActionEnabled = true,
            SecondaryActionEnabled = true,
            PrimaryAction = "Save",
            SecondaryAction = "Cancel",
            TrapFocus = true,
            Modal = true,
            PreventScroll = true,
            Width = "min(70vw, 700px);",
            Height = "max(70vh, 700px) !important;",
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<OfferDetailedDialog>(record, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            OfferVM vm = result.Data as OfferVM;
            var dto = Mapper.Map<OfferDto>(vm);
            await DataProvider.Offers.Update(dto);
            await _getRecords();
        }
    }

    private async Task _delete(OfferVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the offer of type {record.TypeName} ?", "Yes", "No", "Deleting record...");

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

    #region Import/Export Data
    private async Task ExportToCSV()
    {
        var date = DateTime.Today;
        var fileName = $"Offers-{date.ToEuropeFormat()}.csv";
        var data = FilteredItems.Select(c => new OfferExport(c)).ToList();
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
                List<OfferExport> data = await Data.ImportDataFromCsv<OfferExport>(stream);
                if (data != null && data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        var vm = item.Get();
                        var dto = Mapper.Map<OfferDto>(vm);
                        var added = await DataProvider.Offers.Add(dto);
                        if (added == null)
                            continue;
                        var addedDto = Mapper.Map<OfferVM>(added);
                        _records.Add(addedDto);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception Offers.ImportFromCSV(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
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
