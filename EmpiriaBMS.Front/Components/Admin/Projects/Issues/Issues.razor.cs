using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Projects.Issues;

public partial class Issues
{
    #region Data Grid
    private List<IssueVM> _records = new List<IssueVM>();
    private string _filterString = string.Empty;
    IQueryable<IssueVM>? FilteredItems => _records?.AsQueryable().Where(x => x.ProjectName.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private IssueVM _selectedRecord = new IssueVM();

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

    private void HandleRowFocus(FluentDataGridRow<IssueVM> row)
    {
        _selectedRecord = row.Item as IssueVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.Issues.GetAll();
        _records = Mapper.Map<List<IssueVM>>(dtos);
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
            Width = "min(85%, 800px);"
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<IssuesDetailedDialog>(new IssueVM()
        {
            Project = new Project(),
            DisplayedRole = new Role(),
            Creator = new User()
        }, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            IssueVM vm = result.Data as IssueVM;
            var dto = Mapper.Map<IssueDto>(vm);
            await DataProvider.Issues.Add(dto);
            await _getRecords();
        }
    }

    private async Task _edit(IssueVM record)
    {
        DialogParameters parameters = new()
        {
            Title = $"Edit {record.Project?.Name ?? "Issue"}",
            PrimaryActionEnabled = true,
            SecondaryActionEnabled = true,
            PrimaryAction = "Save",
            SecondaryAction = "Cancel",
            TrapFocus = true,
            Modal = true,
            PreventScroll = true,
            Width = "min(85%, 800px);"
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<IssuesDetailedDialog>(record, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            IssueVM vm = result.Data as IssueVM;
            var dto = Mapper.Map<IssueDto>(vm);
            await DataProvider.Issues.Update(dto);
            await _getRecords();
        }
    }

    private async Task _delete(IssueVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the issue <{record.Description}>?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.Issues.Delete(record.Id);
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

    #region Export Data
    private async Task ExportToCSV()
    {
        var date = DateTime.Today;
        var fileName = $"Issues-{date.ToEuropeFormat()}.csv";
        var data = FilteredItems.Select(c => new IssueExport(c)).ToList();
        if (data.Count > 0)
        {
            string csvContent = Data.GetCsvContent(data);
            await MicrosoftTeams.DownloadCsvFile(fileName, csvContent);
        }
    }
    #endregion
}
