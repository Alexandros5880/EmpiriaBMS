using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Components.Admin.General;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Projects.Offers.States;

public partial class OfferStates
{
    #region Data Grid
    private List<OfferStateVM> _records = new List<OfferStateVM>();
    private string _filterString = string.Empty;
    IQueryable<OfferStateVM>? FilteredItems => _records?.AsQueryable().Where(x => x.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private OfferStateVM _selectedRecord = new OfferStateVM();

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

    private void HandleRowFocus(FluentDataGridRow<OfferStateVM> row)
    {
        _selectedRecord = row.Item as OfferStateVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.OfferStates.GetAll();
        _records = Mapper.Map<List<OfferStateVM>>(dtos);
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

        IDialogReference dialog = await DialogService.ShowDialogAsync<UniqueTypeForm>(new OfferStateVM(), parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            OfferStateVM vm = result.Data as OfferStateVM;
            var dto = Mapper.Map<OfferStateDto>(vm);
            await DataProvider.OfferStates.Add(dto);
            await _getRecords();
        }
    }

    private async Task _edit(OfferStateVM record)
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
            OfferStateVM vm = result.Data as OfferStateVM;
            var dto = Mapper.Map<OfferStateDto>(vm);
            await DataProvider.OfferStates.Update(dto);
            await _getRecords();
        }
    }

    private async Task _delete(OfferStateVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the offer state {record.Name}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.OfferStates.Delete(record.Id);
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
