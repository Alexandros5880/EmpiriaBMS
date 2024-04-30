using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Components.Admin.General;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Projects.Payments.Types;

public partial class PaymentTypes
{
    #region Data Grid
    private List<PaymentTypeVM> _records = new List<PaymentTypeVM>();
    private string _filterString = string.Empty;
    IQueryable<PaymentTypeVM>? FilteredItems => _records?.AsQueryable().Where(x => x.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private PaymentTypeVM _selectedRecord = new PaymentTypeVM();

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

    private void HandleRowFocus(FluentDataGridRow<PaymentTypeVM> row)
    {
        _selectedRecord = row.Item as PaymentTypeVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.PaymentTypes.GetAll();
        _records = Mapper.Map<List<PaymentTypeVM>>(dtos);
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

        IDialogReference dialog = await DialogService.ShowDialogAsync<UniqueTypeForm>(new PaymentTypeVM(), parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            PaymentTypeVM vm = result.Data as PaymentTypeVM;
            var dto = Mapper.Map<PaymentTypeDto>(vm);
            await DataProvider.PaymentTypes.Add(dto);
            await _getRecords();
        }
    }

    private async Task _edit(PaymentTypeVM record)
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
            PaymentTypeVM vm = result.Data as PaymentTypeVM;
            var dto = Mapper.Map<PaymentTypeDto>(vm);
            await DataProvider.PaymentTypes.Update(dto);
            await _getRecords();
        }
    }

    private async Task _delete(PaymentTypeVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the payment type {record.Name}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.PaymentTypes.Delete(record.Id);
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
