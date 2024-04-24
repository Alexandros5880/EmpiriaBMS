using AutoMapper;
using EmpiriaBMS.Core;
using EmpiriaBMS.Front.Components.General;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Bot.Builder;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.Admin.Roles;

public partial class Roles
{
    #region Data Grid
    private List<RoleVM> _records = new List<RoleVM>();
    private string _filterString = string.Empty;
    IQueryable<RoleVM>? FilteredItems => _records?.AsQueryable().Where(x => x.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private RoleVM _selectedRecord = new RoleVM();

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

    private void HandleRowFocus(FluentDataGridRow<RoleVM> row)
    {
        _selectedRecord = row.Item as RoleVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.Roles.GetAll();
        _records = Mapper.Map<List<RoleVM>>(dtos);
    }

    private void _add()
    {

    }

    private void _edit(RoleVM record)
    {

    }

    private void _delete(RoleVM record)
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
