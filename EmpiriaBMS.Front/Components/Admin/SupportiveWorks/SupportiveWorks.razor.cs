using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.SupportiveWorks;

public partial class SupportiveWorks
{
    #region Data Grid
    private List<SupportiveWorkVM> _records = new List<SupportiveWorkVM>();
    private string _filterString = string.Empty;
    IQueryable<SupportiveWorkVM>? FilteredItems => _records?.AsQueryable().Where(x => x.TypeName.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private SupportiveWorkVM _selectedRecord = new SupportiveWorkVM();

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

    private void HandleRowFocus(FluentDataGridRow<SupportiveWorkVM> row)
    {
        _selectedRecord = row.Item as SupportiveWorkVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.SupportiveWorks.GetAll();
        _records = Mapper.Map<List<SupportiveWorkVM>>(dtos);
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

        IDialogReference dialog = await DialogService.ShowDialogAsync<SupportiveWorkDetailedDialog>(new SupportiveWorkVM(), parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            SupportiveWorkVM vm = result.Data as SupportiveWorkVM;
            var dto = Mapper.Map<SupportiveWorkDto>(vm);
            await DataProvider.SupportiveWorks.Add(dto);
            await _getRecords();
        }
    }

    private async Task _edit(SupportiveWorkVM record)
    {
        DialogParameters parameters = new()
        {
            Title = $"Edit DT-[{record.DisciplineTypeName}] T-[{record.TypeName}]",
            PrimaryActionEnabled = true,
            SecondaryActionEnabled = true,
            PrimaryAction = "Save",
            SecondaryAction = "Cancel",
            TrapFocus = true,
            Modal = true,
            PreventScroll = true,
            Width = "min(70%, 500px);"
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<SupportiveWorkDetailedDialog>(record, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            SupportiveWorkVM vm = result.Data as SupportiveWorkVM;
            var dto = Mapper.Map<SupportiveWorkDto>(vm);
            await DataProvider.SupportiveWorks.Update(dto);
            await _getRecords();
        }
    }

    private async Task _delete(SupportiveWorkVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the supportive work of type {record.TypeName} of discipline {record.DisciplineTypeName} of project {record.ProjectName}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.SupportiveWorks.Delete(record.Id);
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
        var fileName = $"SupportiveWorks-{date.ToEuropeFormat()}.csv";
        var data = FilteredItems.Select(c => new SupportiveWorkExport(c)).ToList();
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
                List<SupportiveWorkExport> data = await Data.ImportDataFromCsv<SupportiveWorkExport>(stream);
                if (data != null && data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        var vm = item.Get();
                        var dto = Mapper.Map<SupportiveWorkDto>(vm);
                        var added = await DataProvider.SupportiveWorks.Add(dto);
                        if (added == null)
                            continue;
                        var addedVm = Mapper.Map<SupportiveWorkVM>(added);
                        _records.Add(addedVm);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception SupportiveWorks.ImportFromCSV(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
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
