using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Roles;

public partial class RolesDetailedDialog : IDialogContentComponent<RoleVM>
{
    [Parameter]
    public RoleVM Content { get; set; } = default!;

    [CascadingParameter]
    public FluentDialog Dialog { get; set; } = default!;

    public bool IsNew => Content.Id == 0;

    #region Data Grid
    private List<PermissionVM> _records = new List<PermissionVM>();
    private string _filterString = string.Empty;
    IQueryable<PermissionVM> FilteredItems => _records?.AsQueryable().Where(x => x.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

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

    private async Task _getRecords()
    {
        var allPermissions = await _dataProvider.Permissions.GetAll();
        var allPermissionsVms = Mapper.Map<List<PermissionVM>>(allPermissions);

        var myPerIds = (await _dataProvider.Roles.GetMyPermissions(Content.Id)).Select(p => p.Id);

        var permissions = new HashSet<PermissionVM>();
        allPermissionsVms.ForEach(p => {
            p.IsSelected = myPerIds.Contains(p.Id);
            permissions.Add(p);
        });

        _records = permissions.OrderByDescending(p => p.IsSelected).ToList();
    }

    private void _onSelectionChange(int permissionId, bool val)
    {
        var permission = _records.FirstOrDefault(r => r.Id == permissionId);
        var index = _records.IndexOf(permission);
        _records[index].IsSelected = val;
    }
    #endregion

    private async Task SaveAsync()
    {
        var permissionsIds = _records.Where(r => r.IsSelected).Select(r => r.Id).ToList();
        List<RolePermission> rp = new List<RolePermission>();
        foreach (var id in permissionsIds)
        {
            rp.Add(new RolePermission()
            {
                RoleId = Content.Id,
                PermissionId = id
            });
        }
        Content.RolesPermissions = rp;

        await Dialog.CloseAsync(Content);
    }

    private async Task CancelAsync()
    {
        await Dialog.CancelAsync();
    }

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