using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Components.Admin.General;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Projects.Stages;

public partial class Stages
{
    #region Data Grid
    private List<ProjectStageVM> _records = new List<ProjectStageVM>();
    private string _filterString = string.Empty;
    IQueryable<ProjectStageVM>? FilteredItems => _records?.AsQueryable().Where(x => x.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private ProjectStageVM _selectedRecord = new ProjectStageVM();

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

    private void HandleRowFocus(FluentDataGridRow<ProjectStageVM> row)
    {
        _selectedRecord = row.Item as ProjectStageVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.ProjectStages.GetAll();
        _records = Mapper.Map<List<ProjectStageVM>>(dtos);
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

        IDialogReference dialog = await DialogService.ShowDialogAsync<UniqueTypeForm>(new ProjectStageVM(), parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            ProjectStageVM vm = result.Data as ProjectStageVM;
            var dto = Mapper.Map<ProjectStageDto>(vm);
            await DataProvider.ProjectStages.Add(dto);
            await _getRecords();
        }
    }

    private async Task _edit(ProjectStageVM record)
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

        IDialogReference dialog = await DialogService.ShowDialogAsync<UniqueTypeForm>(record, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            ProjectStageVM vm = result.Data as ProjectStageVM;
            var dto = Mapper.Map<ProjectStageDto>(vm);
            await DataProvider.ProjectStages.Update(dto);
            await _getRecords();
        }
    }

    private async Task _delete(ProjectStageVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the stage {record.Name}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.ProjectStages.Delete(record.Id);
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
}
