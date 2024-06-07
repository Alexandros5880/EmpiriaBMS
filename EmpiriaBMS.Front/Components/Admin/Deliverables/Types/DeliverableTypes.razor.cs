using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Components.Admin.General;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Deliverables.Types;

public partial class DeliverableTypes
{
    #region Data Grid
    private List<DrawingTypeVM> _records = new List<DrawingTypeVM>();
    private string _filterString = string.Empty;
    IQueryable<DrawingTypeVM>? FilteredItems => _records?.AsQueryable().Where(x => x.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private DrawingTypeVM _selectedRecord = new DrawingTypeVM();

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

    private void HandleRowFocus(FluentDataGridRow<DrawingTypeVM> row)
    {
        _selectedRecord = row.Item as DrawingTypeVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.DrawingsTypes.GetAll();
        _records = Mapper.Map<List<DrawingTypeVM>>(dtos);
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

        IDialogReference dialog = await DialogService.ShowDialogAsync<UniqueTypeForm>(new DrawingTypeVM(), parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            DrawingTypeVM vm = result.Data as DrawingTypeVM;
            var dto = Mapper.Map<DrawingTypeDto>(vm);
            await DataProvider.DrawingsTypes.Add(dto);
            await _getRecords();
        }
    }

    private async Task _edit(DrawingTypeVM record)
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
            DrawingTypeVM vm = result.Data as DrawingTypeVM;
            var dto = Mapper.Map<DrawingTypeDto>(vm);
            await DataProvider.DrawingsTypes.Update(dto);
            await _getRecords();
        }
    }

    private async Task _delete(DrawingTypeVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the deliverable type  {record.Name}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.DrawingsTypes.Delete(record.Id);
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
