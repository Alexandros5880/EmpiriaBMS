using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.Interop.TeamsSDK;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Disciplines;

public partial class Disciplines
{
    #region Data Grid
    private List<DisciplineVM> _records = new List<DisciplineVM>();
    private string _filterString = string.Empty;
    IQueryable<DisciplineVM> FilteredItems => _records?.AsQueryable().Where(x => x.ProjectName.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private DisciplineVM _selectedRecord = new DisciplineVM();

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

    private void HandleRowFocus(FluentDataGridRow<DisciplineVM> row)
    {
        _selectedRecord = row.Item as DisciplineVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.Disciplines.GetAll();
        _records = Mapper.Map<List<DisciplineVM>>(dtos);
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

        IDialogReference dialog = await DialogService.ShowDialogAsync<DisciplineDetailedDialog>(new DisciplineVM(), parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            DisciplineVM vm = result.Data as DisciplineVM;
            var dto = Mapper.Map<DisciplineDto>(vm);
            await DataProvider.Disciplines.Add(dto);
            await _getRecords();
        }
    }

    private async Task _edit(DisciplineVM record)
    {
        DialogParameters parameters = new()
        {
            Title = $"Edit {record.Type.Name}",
            PrimaryActionEnabled = true,
            SecondaryActionEnabled = true,
            PrimaryAction = "Save",
            SecondaryAction = "Cancel",
            TrapFocus = true,
            Modal = true,
            PreventScroll = true
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<DisciplineDetailedDialog>(record, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            DisciplineVM vm = result.Data as DisciplineVM;
            var dto = Mapper.Map<DisciplineDto>(vm);
            await DataProvider.Disciplines.Update(dto);
            await _getRecords();
        }
    }

    private async Task _delete(DisciplineVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the discipline of type {record.TypeName} of project {record.ProjectName}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.Disciplines.Delete(record.Id);
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
        var fileName = $"Disciplines-{date.ToEuropeFormat()}.csv";
        var data = FilteredItems.Select(c => new DisciplineExport(c)).ToList();
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
                List<DisciplineExport> data = await Data.ImportDataFromCsv<DisciplineExport>(stream);
                if (data != null && data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        var vm = item.Get();
                        var dto = Mapper.Map<DisciplineDto>(vm);
                        var added = await DataProvider.Disciplines.Add(dto);
                        if (added == null)
                            continue;
                        var addedDto = Mapper.Map<DisciplineVM>(added);
                        _records.Add(addedDto);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception Disciplines.ImportFromCSV(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
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
