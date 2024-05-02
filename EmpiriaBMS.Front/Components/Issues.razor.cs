using AutoMapper;
using EmpiriaBMS.Core;
using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Components.Admin.Projects.Issues;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components;

public partial class Issues : ComponentBase
{
    private bool disposedValue;

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
            Console.WriteLine($"Exception Issues.HandleValidSubmit() \n Exception: {ex.Message}  ->  \n InnerException: ");
            Console.Write(ex.InnerException.Message);
        }
    }
    
    private string _filterString = string.Empty;
    IQueryable<IssueVM>? FilteredItems => Source?.AsQueryable().Where(x => x.ProjectName.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 5 };

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
        StateHasChanged();
    }
}
