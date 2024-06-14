using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Permissions;

public partial class Permissions
{
    #region Data Grid
    private List<PermissionVM> _records = new List<PermissionVM>();
    private string _filterString = string.Empty;
    IQueryable<PermissionVM>? FilteredItems => _records?.AsQueryable().Where(x => x.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 15 };

    private PermissionVM _selectedRecord = new PermissionVM();

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

    private void HandleRowFocus(FluentDataGridRow<PermissionVM> row)
    {
        _selectedRecord = row.Item as PermissionVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.Permissions.GetAll();
        _records = Mapper.Map<List<PermissionVM>>(dtos);
    }

    private void _add()
    {

    }

    private void _edit(PermissionVM record)
    {

    }

    private async Task _delete(PermissionVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the permission {record.Name}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.Permissions.Delete(record.Id);
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
        var fileName = $"Permissions-{date.ToEuropeFormat()}.csv";
        var data = FilteredItems.Select(c => new PermissionExport(c)).ToList();
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
                List<PermissionExport> data = await Data.ImportData<PermissionExport>(stream);
                if (data != null && data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        var vm = item.Get();
                        var dto = Mapper.Map<PermissionDto>(vm);
                        var added = await DataProvider.Permissions.Add(dto);
                        if (added == null)
                            continue;
                        var addedDto = Mapper.Map<PermissionVM>(added);
                        _records.Add(addedDto);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Permissions import: {ex.Message}, \nInner: {ex.InnerException?.Message}");
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
