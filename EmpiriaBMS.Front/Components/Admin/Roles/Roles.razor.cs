using AutoMapper;
using EmpiriaBMS.Core;
using EmpiriaBMS.Front.Components.General;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.Bot.Builder;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.Admin.Roles;

public partial class Roles
{
    private Paginator _paginator;
    private ObservableCollection<RoleVM> _roles = new ObservableCollection<RoleVM>();
    private RoleVM _selectedRole = new RoleVM();

    private EditRole _editRoleCompoment;

    // Add / Edit Dialog
    private bool _isEditMode = false;
    //private FluentDialog? _addEditDialog;
    //private bool _isAddEditDialogOdepened = false;

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _paginator.SetRecordsLength(await DataProvider.Roles.Count());
            await _getRoles();

            StateHasChanged();
        }
    }

    private async Task _getRoles()
    {
        var dtos = await DataProvider.Roles.GetAll(_paginator.PageSize, _paginator.PageIndex);
        var vms = Mapper.Map<List<RoleVM>>(dtos);
        _roles.Clear();
        vms.ForEach(_roles.Add);
    }

    private void _onSelectRole(int id)
    {
        _selectedRole = _roles.FirstOrDefault(r => r.Id == id);
    }

    protected override bool ShouldRender()
    {
        return true;
    }

    private async Task _add()
    {
        _selectedRole = null;
        _isEditMode = true;
        //_addEditDialog.Show();
        //_isAddEditDialogOdepened = true;
    }

    private async Task _edit()
    {
        _isEditMode = true;
        //_addEditDialog.Show();
        //_isAddEditDialogOdepened = true;
    }

    private async Task _delete(int id)
    {
        await Task.Delay(1333);
    }

    private async Task _save()
    {
        await Task.Delay(1333);
        _isEditMode = false;
        //_addEditDialog.Hide();
        //_isAddEditDialogOdepened = false;
    }

    private void _cancel()
    {
        _isEditMode = false;
        //_addEditDialog.Hide();
        //_isAddEditDialogOdepened = false;
    }
}
