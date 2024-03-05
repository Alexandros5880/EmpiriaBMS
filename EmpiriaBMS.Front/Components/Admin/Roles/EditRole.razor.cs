using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;

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
}
