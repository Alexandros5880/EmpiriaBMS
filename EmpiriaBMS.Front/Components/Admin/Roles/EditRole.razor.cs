using EmpiriaBMS.Front.Components.General;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Graph.Models;
using System.Collections.ObjectModel;
using System.Security;

namespace EmpiriaBMS.Front.Components.Admin.Roles;

public partial class EditRole
{
    private RoleVM _role;
    [Parameter]
    public RoleVM Role
    {
        get => _role;
        set => _role = value != null ? value : new RoleVM();
    }

    [Parameter]
    public bool IsReadMode { get; set; }

    [Parameter]
    public EventCallback OnSave { get; set; }

    [Parameter]
    public EventCallback OnCancel { get; set; }

    private ObservableCollection<PermissionVM> _permissions = new ObservableCollection<PermissionVM>();

    private bool _isAllChecked;
    public bool IsAllChecked
    {
        get => _isAllChecked;
        set
        {
            _isAllChecked = value;
            foreach (var permission in _permissions)
            {
                permission.IsSelected = value;
            }
        }
    }

    public async Task Prepair()
    {
        await _getPermissions();
    }

    private async Task _getPermissions()
    {
        var permissionsDto = await DataProvider.Permissions.GetAll();
        var permissions = Mapper.Map<List<PermissionVM>>(permissionsDto);
        var myPermissionIds = Role.RolesPermissions?.Select(rp => rp.PermissionId);
        foreach (var permission in permissions)
        {
            if (myPermissionIds?.Contains(permission.Id) ?? false)
                permission.IsSelected = true;
        }
        _permissions.Clear();
        permissions.ForEach(_permissions.Add);
    }

    protected override bool ShouldRender()
    {
        // Return false to prevent the entire component from re-rendering
        return true;
    }
}
