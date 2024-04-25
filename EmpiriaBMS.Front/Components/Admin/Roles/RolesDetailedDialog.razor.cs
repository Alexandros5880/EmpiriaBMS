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
        var myPerDtos = await _dataProvider.Roles.GetMyPermissions(Content.Id);
        var otherPerDtos = await _dataProvider.Roles.GetOtherPermissions(Content.Id);

        var myPerVms = Mapper.Map<List<PermissionVM>>(myPerDtos);
        var otherPerVms = Mapper.Map<List<PermissionVM>>(otherPerDtos);

        _records.Clear();
        myPerVms.ForEach(p => {
            p.IsSelected = true;
            _records.Add(p);
        });
        otherPerVms.ForEach(p => {
            p.IsSelected = false;
            _records.Add(p);
        });
    }
    #endregion

    private async Task SaveAsync()
    {
        if (!IsNew)
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
        }
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