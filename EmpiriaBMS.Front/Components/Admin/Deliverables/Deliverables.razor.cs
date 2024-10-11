using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.Interop.TeamsSDK;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Deliverables;

public partial class Deliverables
{
    #region Data Grid
    private List<DeliverableVM> _records = new List<DeliverableVM>();
    private string _filterString = string.Empty;
    IQueryable<DeliverableVM> FilteredItems => _records?.AsQueryable().Where(x => x.TypeName.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private DeliverableVM _selectedRecord = new DeliverableVM();

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

    private void HandleRowFocus(FluentDataGridRow<DeliverableVM> row)
    {
        _selectedRecord = row.Item as DeliverableVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.Deliverables.GetAll();
        _records = Mapper.Map<List<DeliverableVM>>(dtos);
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

        IDialogReference dialog = await DialogService.ShowDialogAsync<DeliverableDetailedDialog>(new DeliverableVM(), parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            DeliverableVM vm = result.Data as DeliverableVM;
            var dto = Mapper.Map<DeliverableDto>(vm);
            await DataProvider.Deliverables.Add(dto);
            await _getRecords();
        }
    }

    private async Task _edit(DeliverableVM record)
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

        IDialogReference dialog = await DialogService.ShowDialogAsync<DeliverableDetailedDialog>(record, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            DeliverableVM vm = result.Data as DeliverableVM;
            var dto = Mapper.Map<DeliverableDto>(vm);
            await DataProvider.Deliverables.Update(dto);
            await _getRecords();
        }
    }

    private async Task _delete(DeliverableVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the deliverable of project {record.ProjectName} . dicipline type {record.DisciplineTypeName} of type of {record.TypeName}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.Deliverables.Delete(record.Id);
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
        var fileName = $"Deliverables-{date.ToEuropeFormat()}.csv";
        var data = FilteredItems.Select(c => new DeliverableExport(c)).ToList();
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
                List<DeliverableExport> data = await Data.ImportDataFromCsv<DeliverableExport>(stream);
                if (data != null && data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        var vm = item.Get();
                        var dto = Mapper.Map<DeliverableDto>(vm);
                        var added = await DataProvider.Deliverables.Add(dto);
                        if (added == null)
                            continue;
                        var addedVM = Mapper.Map<DeliverableVM>(added);
                        _records.Add(addedVM);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception Deliverables.ImportFromCSV(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
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
