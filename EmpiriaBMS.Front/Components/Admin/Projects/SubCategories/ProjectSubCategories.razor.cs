using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Projects.SubCategories;

public partial class ProjectSubCategories
{
    #region Data Grid
    private List<ProjectSubCategoryVM> _records = new List<ProjectSubCategoryVM>();
    private string _filterString = string.Empty;
    IQueryable<ProjectSubCategoryVM>? FilteredItems => _records?.AsQueryable().Where(x => x.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private ProjectSubCategoryVM _selectedRecord = new ProjectSubCategoryVM();

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

    private void HandleRowFocus(FluentDataGridRow<ProjectSubCategoryVM> row)
    {
        _selectedRecord = row.Item as ProjectSubCategoryVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.ProjectsSubCategories.GetAll();
        _records = Mapper.Map<List<ProjectSubCategoryVM>>(dtos);
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

        IDialogReference dialog = await DialogService.ShowDialogAsync<ProjectSubCategoryDetailed>(new ProjectSubCategoryVM(), parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            ProjectSubCategoryVM vm = result.Data as ProjectSubCategoryVM;
            var dto = Mapper.Map<ProjectSubCategoryDto>(vm);
            await DataProvider.ProjectsSubCategories.Add(dto);
            await _getRecords();
        }
    }

    private async Task _edit(ProjectSubCategoryVM record)
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

        IDialogReference dialog = await DialogService.ShowDialogAsync<ProjectSubCategoryDetailed>(record, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            ProjectSubCategoryVM vm = result.Data as ProjectSubCategoryVM;
            var dto = Mapper.Map<ProjectSubCategoryDto>(vm);
            await DataProvider.ProjectsSubCategories.Update(dto);
            await _getRecords();
        }
    }

    private async Task _delete(ProjectSubCategoryVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the project sub categories {record.Name}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.ProjectsSubCategories.Delete(record.Id);
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
        var fileName = $"ProjectSubCategories-{date.ToEuropeFormat()}.csv";
        var data = FilteredItems.Select(c => new ProjectSubCategoryExport(c)).ToList();
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
                List<ProjectSubCategoryExport> data = await Data.ImportData<ProjectSubCategoryExport>(stream);
                if (data != null && data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        var vm = item.Get();
                        var dto = Mapper.Map<ProjectSubCategoryDto>(vm);
                        var added = await DataProvider.ProjectsSubCategories.Add(dto);
                        if (added == null)
                            continue;
                        var addedDto = Mapper.Map<ProjectSubCategoryVM>(added);
                        _records.Add(addedDto);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception ProjectSubCategories.ImportFromCSV(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
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
