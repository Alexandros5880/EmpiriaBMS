using AutoMapper;
using EmpiriaBMS.Core;
using EmpiriaBMS.Front.Components.General;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.Bot.Builder;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.Admin.Roles;

public partial class Roles
{
    private Paginator _paginator;
    private ObservableCollection<RoleVM> _roles = new ObservableCollection<RoleVM>();
    private RoleVM _selectedRole = new RoleVM();

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            var pevLocation = previusLocationService.GetPreviousLocation();
            if (pevLocation?.GetType() == typeof(Roles))
            {
                var prevPage = (Roles)pevLocation;
                _roles = prevPage._roles;
                _selectedRole = prevPage._selectedRole;
                _paginator.SetVM(prevPage._paginator.Peginator);
            }
            else
            {
                previusLocationService.UpdatePreviousLocation(this);
                _paginator.SetRecordsLength(await DataProvider.Roles.Count());
                await _getRoles();
            }

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
        // Return false to prevent the entire component from re-rendering
        return true;
    }
}
