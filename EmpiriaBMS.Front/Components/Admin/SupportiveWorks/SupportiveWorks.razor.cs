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
    private List<OtherVM> _records = new List<OtherVM>();
    private string _filterString = string.Empty;
    IQueryable<OtherVM>? FilteredItems => _records?.AsQueryable().Where(x => x.TypeName.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private OtherVM _selectedRecord = new OtherVM();

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

    private void HandleRowFocus(FluentDataGridRow<OtherVM> row)
    {
        _selectedRecord = row.Item as OtherVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.Others.GetAll();
        _records = Mapper.Map<List<OtherVM>>(dtos);
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

        IDialogReference dialog = await DialogService.ShowDialogAsync<SupportiveWorkDetailedDialog>(new OtherVM(), parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            OtherVM vm = result.Data as OtherVM;
            var dto = Mapper.Map<OtherDto>(vm);
            await DataProvider.Others.Add(dto);
            await _getRecords();
        }
    }

    private async Task _edit(OtherVM record)
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
            OtherVM vm = result.Data as OtherVM;
            var dto = Mapper.Map<OtherDto>(vm);
            await DataProvider.Others.Update(dto);
            await _getRecords();
        }
    }

    private async Task _delete(OtherVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the supportive work of type {record.TypeName} of discipline {record.DisciplineTypeName} of project {record.ProjectName}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.Others.Delete(record.Id);
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
                List<SupportiveWorkExport> data = await Data.ImportData<SupportiveWorkExport>(stream);
                if (data != null && data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        var vm = item.Get();
                        var dto = Mapper.Map<OtherDto>(vm);
                        var added = await DataProvider.Others.Add(dto);
                        if (added == null)
                            continue;
                        var addedVm = Mapper.Map<OtherVM>(added);
                        _records.Add(addedVm);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Others import: {ex.Message}, \nInner: {ex.InnerException?.Message}");
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
