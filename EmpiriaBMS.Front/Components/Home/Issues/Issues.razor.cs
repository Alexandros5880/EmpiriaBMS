﻿using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Home.Issues;

public partial class Issues : ComponentBase
{
    [Parameter]
    public List<IssueVM> Source { get; set; }

    [Parameter]
    public EventCallback OnSave { get; set; }

    public async Task HandleValidSubmit()
    {
        try
        {
            List<IssueVM> vms = Source.ToList();
            List<IssueDto> dtos = Mapper.Map<List<IssueDto>>(vms);
            await DataProvider.Issues.UpdateAll(dtos);
            await OnSave.InvokeAsync();
        }
        catch (Exception ex)
        {
            Logger.LogError($"Exception Issues.HandleValidSubmit(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }
    }

    private string _filterString = string.Empty;
    IQueryable<IssueVM> FilteredItems => Source?.AsQueryable().Where(x => x.ProjectName.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 5 };

    private IssueVM _selectedRecord = null;

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

    private void OnRowFocused(FluentDataGridRow<IssueVM> row)
    {
        var r = row;
        var record = r.Item as IssueVM;
        _selectedRecord = record;
    }

    private void _editOnCancel()
    {
        _selectedRecord = null;
    }

    private async Task SaveDetailed()
    {
        await OnSave.InvokeAsync(this);
    }

}