﻿using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Components.Admin.General;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Invoices.Types;

public partial class InvoiceTypes
{
    #region Data Grid
    private List<InvoiceTypeVM> _records = new List<InvoiceTypeVM>();
    private string _filterString = string.Empty;
    IQueryable<InvoiceTypeVM>? FilteredItems => _records?.AsQueryable().Where(x => x.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private InvoiceTypeVM _selectedRecord = new InvoiceTypeVM();

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

    private void HandleRowFocus(FluentDataGridRow<InvoiceTypeVM> row)
    {
        _selectedRecord = row.Item as InvoiceTypeVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.InvoiceTypes.GetAll();
        _records = Mapper.Map<List<InvoiceTypeVM>>(dtos);
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

        IDialogReference dialog = await DialogService.ShowDialogAsync<UniqueTypeForm>(new InvoiceTypeVM(), parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            InvoiceTypeVM vm = result.Data as InvoiceTypeVM;
            var dto = Mapper.Map<InvoiceTypeDto>(vm);
            await DataProvider.InvoiceTypes.Add(dto);
            await _getRecords();
        }
    }

    private async Task _edit(InvoiceTypeVM record)
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
            InvoiceTypeVM vm = result.Data as InvoiceTypeVM;
            var dto = Mapper.Map<InvoiceTypeDto>(vm);
            await DataProvider.InvoiceTypes.Update(dto);
            await _getRecords();
        }
    }

    private async Task _delete(InvoiceTypeVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete invoice type {record.Name}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.InvoiceTypes.Delete(record.Id);
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