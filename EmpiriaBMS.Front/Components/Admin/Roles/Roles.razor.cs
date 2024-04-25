using AutoMapper;
using EmpiriaBMS.Core;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Components.Admin.General;
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

    private async Task _add()
    {
        DialogParameters parameters = new()
        {
            Title = $"New record...",
            PrimaryActionEnabled = true,
            SecondaryActionEnabled = true,
            PrimaryAction = "Save",
            SecondaryAction = "Cancel",
            TrapFocus = true,
            Modal = true,
            PreventScroll = true
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<RolesDetailedDialog>(new RoleVM(), parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            RoleVM vm = result.Data as RoleVM;
            var dto = Mapper.Map<RoleDto>(vm);
            await DataProvider.Roles.Add(dto); // TODO: Update Permissions
            await _getRecords();
        }
    }

    private async Task _edit(RoleVM record)
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

        IDialogReference dialog = await DialogService.ShowDialogAsync<RolesDetailedDialog>(record, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            RoleVM vm = result.Data as RoleVM;
            var dto = Mapper.Map<RoleDto>(vm);
            await DataProvider.Roles.Update(dto); // TODO: Update Permissions
            await _getRecords();
        }
    }

    private async Task _delete(RoleVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the role {record.Name}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.Roles.Delete(record.Id);
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
