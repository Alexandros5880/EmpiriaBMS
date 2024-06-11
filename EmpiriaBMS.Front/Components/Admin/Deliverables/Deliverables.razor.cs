using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.Interop.TeamsSDK;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Deliverables;

public partial class Deliverables
{
    #region Data Grid
    private List<DrawingVM> _records = new List<DrawingVM>();
    private string _filterString = string.Empty;
    IQueryable<DrawingVM>? FilteredItems => _records?.AsQueryable().Where(x => x.TypeName.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private DrawingVM _selectedRecord = new DrawingVM();

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

    private void HandleRowFocus(FluentDataGridRow<DrawingVM> row)
    {
        _selectedRecord = row.Item as DrawingVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.Drawings.GetAll();
        _records = Mapper.Map<List<DrawingVM>>(dtos);
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

        IDialogReference dialog = await DialogService.ShowDialogAsync<DeliverableDetailedDialog>(new DrawingVM(), parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            DrawingVM vm = result.Data as DrawingVM;
            var dto = Mapper.Map<DrawingDto>(vm);
            await DataProvider.Drawings.Add(dto);
            await _getRecords();
        }
    }

    private async Task _edit(DrawingVM record)
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
            DrawingVM vm = result.Data as DrawingVM;
            var dto = Mapper.Map<DrawingDto>(vm);
            await DataProvider.Drawings.Update(dto);
            await _getRecords();
        }
    }

    private async Task _delete(DrawingVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the deliverable of project {record.ProjectName} . dicipline type {record.DisciplineTypeName} of type of {record.TypeName}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.Drawings.Delete(record.Id);
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
        var fileName = $"Deliverables-{date.ToEuropeFormat()}.csv";
        var data = FilteredItems.Select(c => new DeliverableExport(c)).ToList();
        if (data.Count > 0)
        {
            string csvContent = Data.GetCsvContent(data);
            await MicrosoftTeams.DownloadCsvFile(fileName, csvContent);
        }
    }
    #endregion
}
