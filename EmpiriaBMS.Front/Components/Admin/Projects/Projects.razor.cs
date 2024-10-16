﻿using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Projects;

public partial class Projects
{
    private string _dialogWidth = "min(82%, 740px);";
    private string _dialogHeight = "min(85%, 880px);";

    [Parameter]
    public bool DisplayActions { get; set; } = true;

    [Parameter]
    public bool GetRecords { get; set; } = true;

    #region Data Grid
    [Parameter]
    public List<ProjectVM> Source { get; set; } = new List<ProjectVM>();

    private string _filterString = string.Empty;
    IQueryable<ProjectVM>? FilteredItems => Source?.AsQueryable().Where(x => x.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    [Parameter]
    public ProjectVM SelectedRecord { get; set; } = new ProjectVM();

    [Parameter]
    public EventCallback<ProjectVM> OnSelect { get; set; }

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

    private async Task HandleRowFocus(FluentDataGridRow<ProjectVM> row)
    {
        SelectedRecord = row.Item as ProjectVM;
        await OnSelect.InvokeAsync(SelectedRecord);
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.Projects.GetAll();
        Source = Mapper.Map<List<ProjectVM>>(dtos);
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
            PreventScroll = false,
            Width = _dialogWidth,
            Height = _dialogHeight
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<ProjectDetailedDialog>(new ProjectVM(), parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            ProjectVM vm = result.Data as ProjectVM;
            var dto = Mapper.Map<ProjectDto>(vm);


            // Save Project
            await DataProvider.Projects.Add(dto);
            await _getRecords();
        }
    }

    private async Task _edit(ProjectVM record)
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
            PreventScroll = false,
            Width = _dialogWidth,
            Height = _dialogHeight
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<ProjectDetailedDialog>(record, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            ProjectVM vm = result.Data as ProjectVM;
            var dto = Mapper.Map<ProjectDto>(vm);



            // Save Project
            await DataProvider.Projects.Update(dto);
            await _getRecords();
        }
    }

    private async Task _delete(ProjectVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the project {record.Name}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.Projects.Delete(record.Id);
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
            if (GetRecords)
                await _getRecords();

            StateHasChanged();
        }
    }

    #region Import/Export Data
    private async Task ExportToCSV()
    {
        var date = DateTime.Today;
        var fileName = $"Projects-{date.ToEuropeFormat()}.csv";
        var data = FilteredItems.Select(c => new ProjectExport(c)).ToList();
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
                List<ProjectExport> data = await Data.ImportDataFromCsv<ProjectExport>(stream);
                if (data != null && data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        var vm = item.Get();
                        var dto = Mapper.Map<ProjectDto>(vm);
                        var added = await DataProvider.Projects.Add(dto);
                        if (added == null)
                            continue;
                        var addedDto = Mapper.Map<ProjectVM>(added);
                        Source.Add(addedDto);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception Projects.ImportFromCSV(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
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
