using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.Components.Admin.General;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.SupportiveWorks.Types;

public partial class SupportiveWorkTypes
{
    #region Data Grid
    private List<SupportiveWorkTypeVM> _records = new List<SupportiveWorkTypeVM>();
    private string _filterString = string.Empty;
    IQueryable<SupportiveWorkTypeVM>? FilteredItems => _records?.AsQueryable().Where(x => x.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private SupportiveWorkTypeVM _selectedRecord = new SupportiveWorkTypeVM();

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

    private void HandleRowFocus(FluentDataGridRow<SupportiveWorkTypeVM> row)
    {
        _selectedRecord = row.Item as SupportiveWorkTypeVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.SupportiveWorksTypes.GetAll();
        _records = Mapper.Map<List<SupportiveWorkTypeVM>>(dtos);
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
            PreventScroll = true
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<UniqueTypeForm>(new SupportiveWorkTypeVM(), parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            SupportiveWorkTypeVM vm = result.Data as SupportiveWorkTypeVM;
            var dto = Mapper.Map<SupportiveWorkTypeDto>(vm);
            await DataProvider.SupportiveWorksTypes.Add(dto);
            await _getRecords();
        }
    }

    private async Task _edit(SupportiveWorkTypeVM record)
    {
        DialogParameters parameters = new()
        {
            Title = $"Edit {record.Name}",
            PrimaryActionEnabled = true,
            SecondaryActionEnabled = true,
            PrimaryAction = "Save",
            SecondaryAction = "Cancel",
            TrapFocus = true,
            Modal = true,
            PreventScroll = true
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<UniqueTypeForm>(record, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            SupportiveWorkTypeVM vm = result.Data as SupportiveWorkTypeVM;
            var dto = Mapper.Map<SupportiveWorkTypeDto>(vm);
            await DataProvider.SupportiveWorksTypes.Update(dto);
            await _getRecords();
        }
    }

    private async Task _delete(SupportiveWorkTypeVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the supportive work type {record.Name}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.SupportiveWorksTypes.Delete(record.Id);
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
        var fileName = $"SuuportiveWorkTypes-{date.ToEuropeFormat()}.csv";
        var data = FilteredItems.Select(c => new SupportiveWorkTypeExport(c)).ToList();
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
                List<SupportiveWorkTypeExport> data = await Data.ImportData<SupportiveWorkTypeExport>(stream);
                if (data != null && data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        var vm = item.Get();
                        var dto = Mapper.Map<SupportiveWorkTypeDto>(vm);
                        var added = await DataProvider.SupportiveWorksTypes.Add(dto);
                        if (added == null)
                            continue;
                        var addedDto = Mapper.Map<SupportiveWorkTypeVM>(added);
                        _records.Add(addedDto);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception SupportiveWorkTypes.ImportFromCSV(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
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
