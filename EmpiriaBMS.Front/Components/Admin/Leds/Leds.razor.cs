using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Components.Admin.Contracts;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Leds;

public partial class Leds
{
    #region Data Grid
    private List<LedVM> _records = new List<LedVM>();
    private string _filterString = string.Empty;
    IQueryable<LedVM>? FilteredItems => _records?.AsQueryable().Where(x => x.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private LedVM _selectedRecord = new LedVM();

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

    private void HandleRowFocus(FluentDataGridRow<LedVM> row)
    {
        _selectedRecord = row.Item as LedVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.Leds.GetAll();
        _records = Mapper.Map<List<LedVM>>(dtos);
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

        IDialogReference dialog = await DialogService.ShowDialogAsync<LedDetailedDialog>(new LedVM(), parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            LedVM vm = result.Data as LedVM;
            var dto = Mapper.Map<LedDto>(vm);
            await DataProvider.Leds.Add(dto);
            await _getRecords();
        }
    }

    private async Task _edit(LedVM record)
    {
        DialogParameters parameters = new()
        {
            Title = $"Edit Record {record.Name}",
            PrimaryActionEnabled = true,
            SecondaryActionEnabled = true,
            PrimaryAction = "Save",
            SecondaryAction = "Cancel",
            TrapFocus = true,
            Modal = true,
            PreventScroll = true,
            Width = "min(70%, 500px);"
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<LedDetailedDialog>(record, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            LedVM vm = result.Data as LedVM;
            var dto = Mapper.Map<LedDto>(vm);
            await DataProvider.Leds.Update(dto);
            await _getRecords();
        }
    }

    private async Task _delete(LedVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete led {record.Name}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.Leds.Delete(record.Id);
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
