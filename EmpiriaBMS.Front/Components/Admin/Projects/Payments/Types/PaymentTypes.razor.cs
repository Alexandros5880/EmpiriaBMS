﻿using EmpiriaBMS.Front.ViewModel.Components;
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

    private void _add()
    {

    }

    private void _edit(PaymentTypeVM record)
    {

    }

    private void _delete(PaymentTypeVM record)
    {

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