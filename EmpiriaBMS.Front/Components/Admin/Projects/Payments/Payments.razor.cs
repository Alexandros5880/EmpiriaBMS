using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Components.Admin.General;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Projects.Payments;

public partial class Payments
{
    #region Data Grid
    private List<PaymentVM> _records = new List<PaymentVM>();
    private string _filterString = string.Empty;
    IQueryable<PaymentVM>? FilteredItems => _records?.AsQueryable().Where(x => x.ProjectName.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private PaymentVM _selectedRecord = new PaymentVM();

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

    private void HandleRowFocus(FluentDataGridRow<PaymentVM> row)
    {
        _selectedRecord = row.Item as PaymentVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.Payments.GetAll();
        _records = Mapper.Map<List<PaymentVM>>(dtos);
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

        IDialogReference dialog = await DialogService.ShowDialogAsync<PaymentDetailedDialog>(new PaymentVM(), parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            PaymentVM vm = result.Data as PaymentVM;
            var dto = Mapper.Map<PaymentDto>(vm);
            await DataProvider.Payments.Add(dto);
            await _getRecords();
        }
    }

    private async Task _edit(PaymentVM record)
    {
        DialogParameters parameters = new()
        {
            Title = $"Edit paymeny of project {record.ProjectName} with bank {record.Bank}",
            PrimaryActionEnabled = true,
            SecondaryActionEnabled = true,
            PrimaryAction = "Save",
            SecondaryAction = "Cancel",
            TrapFocus = true,
            Modal = true,
            PreventScroll = true,
            Width = "min(70%, 500px);"
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<PaymentDetailedDialog>(record, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            PaymentVM vm = result.Data as PaymentVM;
            var dto = Mapper.Map<PaymentDto>(vm);
            await DataProvider.Payments.Update(dto);
            await _getRecords();
        }
    }

    private async Task _delete(PaymentVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the payment of project {record.ProjectName}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.Payments.Delete(record.Id);
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
