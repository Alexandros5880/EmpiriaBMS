﻿using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Projects.Issues;

public partial class Issues
{
    #region Data Grid
    private List<IssueVM> _records = new List<IssueVM>();
    private string _filterString = string.Empty;
    IQueryable<IssueVM>? FilteredItems => _records?.AsQueryable().Where(x => x.ProjectName.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private IssueVM _selectedRecord = new IssueVM();

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

    private void HandleRowFocus(FluentDataGridRow<IssueVM> row)
    {
        _selectedRecord = row.Item as IssueVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.Issues.GetAll();
        _records = Mapper.Map<List<IssueVM>>(dtos);
    }

    private void _add()
    {

    }

    private void _edit(IssueVM record)
    {

    }

    private void _delete(IssueVM record)
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