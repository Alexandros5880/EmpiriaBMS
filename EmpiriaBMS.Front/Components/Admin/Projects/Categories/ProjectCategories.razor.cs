using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Projects.Categories;

public partial class ProjectCategories
{
    #region Data Grid
    private List<ProjectCategoryVM> _records = new List<ProjectCategoryVM>();
    private string _filterString = string.Empty;
    IQueryable<ProjectCategoryVM>? FilteredItems => _records?.AsQueryable().Where(x => x.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private ProjectCategoryVM _selectedRecord = new ProjectCategoryVM();

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

    private void HandleRowFocus(FluentDataGridRow<ProjectCategoryVM> row)
    {
        _selectedRecord = row.Item as ProjectCategoryVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.ProjectsCategories.GetAll();
        _records = Mapper.Map<List<ProjectCategoryVM>>(dtos);
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

        IDialogReference dialog = await DialogService.ShowDialogAsync<ProjectCategoryDetailedDialog>(new ProjectCategoryVM(), parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            ProjectCategoryVM vm = result.Data as ProjectCategoryVM;
            var dto = Mapper.Map<ProjectCategoryDto>(vm);
            await DataProvider.ProjectsCategories.Add(dto);
            await _getRecords();
        }
    }

    private async Task _edit(ProjectCategoryVM record)
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

        IDialogReference dialog = await DialogService.ShowDialogAsync<ProjectCategoryDetailedDialog>(record, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            ProjectCategoryVM vm = result.Data as ProjectCategoryVM;
            var dto = Mapper.Map<ProjectCategoryDto>(vm);
            await DataProvider.ProjectsCategories.Update(dto);
            await _getRecords();
        }
    }

    private async Task _delete(ProjectCategoryVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the project category {record.Name}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.ProjectsCategories.Delete(record.Id);
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
        var fileName = $"ProjectCategories-{date.ToEuropeFormat()}.csv";
        var data = FilteredItems.Select(c => new ProjectCategoryExport(c)).ToList();
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
                List<ProjectCategoryExport> data = await Data.ImportData<ProjectCategoryExport>(stream);
                if (data != null && data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        var vm = item.Get();
                        var dto = Mapper.Map<ProjectCategoryDto>(vm);
                        var added = await DataProvider.ProjectsCategories.Add(dto);
                        if (added == null)
                            continue;
                        var addedDto = Mapper.Map<ProjectCategoryVM>(added);
                        _records.Add(addedDto);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception ProjectCategories import: {ex.Message}, \nInner: {ex.InnerException?.Message}");
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
