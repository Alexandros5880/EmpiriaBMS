﻿using EmpiriaBMS.Front.ViewModel.Components;
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

    private void _add()
    {

    }

    private void _edit(PaymentVM record)
    {

    }

    private void _delete(PaymentVM record)
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