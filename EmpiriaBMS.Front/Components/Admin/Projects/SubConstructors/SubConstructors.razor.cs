using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Fast.Components.FluentUI;
using EmpiriaBMS.Models.Models;
using Humanizer;

namespace EmpiriaBMS.Front.Components.Admin.Projects.SubConstructors;

public partial class SubConstructors
{
    #region Data Grid
    private List<SubConstructorVM> _records = new List<SubConstructorVM>();
    private string _filterString = string.Empty;
    IQueryable<SubConstructorVM>? FilteredItems => _records?.AsQueryable().Where(x => x.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private SubConstructorVM _selectedRecord = new SubConstructorVM();

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

    private void HandleRowFocus(FluentDataGridRow<SubConstructorVM> row)
    {
        _selectedRecord = row.Item as SubConstructorVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.SubConstructors.GetAll();
        _records = Mapper.Map<List<SubConstructorVM>>(dtos);
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
            Width = "min(80%, 700px);"
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<SubConstructorDetailedDialog>(new SubConstructorVM(), parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            SubConstructorVM vm = result.Data as SubConstructorVM;
            _records.Insert(0, vm);
        }
    }

    private async Task _edit(SubConstructorVM record)
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
            PreventScroll = true,
            Width = "min(80%, 700px);"
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<SubConstructorDetailedDialog>(record, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            SubConstructorVM vm = result.Data as SubConstructorVM;
            var old = _records.FirstOrDefault(r => r.Id == vm.Id);
            var index = _records.IndexOf(old);
            _records.Remove(old);
            _records.Insert(index, vm);
        }
    }

    private async Task _delete(SubConstructorVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the SubConstructor {record.Name}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.SubConstructors.RemoveEmailsAll(record.Id);
            await DataProvider.SubConstructors.Delete(record.Id);
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
        var fileName = $"SubConstructors-{date.ToEuropeFormat()}.csv";
        var data = FilteredItems.Select(c => new SubConstructorExport(c)).ToList();
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
                List<SubConstructorExport> data = await Data.ImportDataFromCsv<SubConstructorExport>(stream);
                if (data != null && data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        var vm = item.Get();
                        var dto = Mapper.Map<SubConstructorDto>(vm);
                        var added = await DataProvider.SubConstructors.Add(dto);
                        if (added == null)
                            continue;
                        var addedDto = Mapper.Map<SubConstructorVM>(added);
                        _records.Add(addedDto);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception SubConstructors.ImportFromCSV(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
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
