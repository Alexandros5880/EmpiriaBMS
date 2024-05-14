using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Components.Admin.General;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Projects.Offers.Results;

public partial class OfferResults
{
    #region Data Grid
    private List<OfferResultVM> _records = new List<OfferResultVM>();
    private string _filterString = string.Empty;
    IQueryable<OfferResultVM>? FilteredItems => _records?.AsQueryable().Where(x => x.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private OfferResultVM _selectedRecord = new OfferResultVM();

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

    private void HandleRowFocus(FluentDataGridRow<OfferResultVM> row)
    {
        _selectedRecord = row.Item as OfferResultVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.OfferResult.GetAll();
        _records = Mapper.Map<List<OfferResultVM>>(dtos);
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

        IDialogReference dialog = await DialogService.ShowDialogAsync<UniqueTypeForm>(new OfferResultVM(), parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            OfferResultVM vm = result.Data as OfferResultVM;
            var dto = Mapper.Map<OfferResultDto>(vm);
            await DataProvider.OfferResult.Add(dto);
            await _getRecords();
        }
    }

    private async Task _edit(OfferResultVM record)
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
            OfferResultVM vm = result.Data as OfferResultVM;
            var dto = Mapper.Map<OfferResultDto>(vm);
            await DataProvider.OfferResult.Update(dto);
            await _getRecords();
        }
    }

    private async Task _delete(OfferResultVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the offer state {record.Name}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.OfferResult.Delete(record.Id);
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