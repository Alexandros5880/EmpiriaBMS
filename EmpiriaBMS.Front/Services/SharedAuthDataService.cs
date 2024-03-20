using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.TeamsFx;

namespace EmpiriaBMS.Front.Services;

public class SharedAuthDataService
{
    public UserInfo TeamsLogedUser { get; set; }
    public ICollection<RoleVM> LoggedUserRoles { get; set; } = new List<RoleVM>();
    public ICollection<PermissionDto> Permissions { get; set; } = new List<PermissionDto>();
    public ICollection<int> PermissionOrds { get; set; } = new List<int>();
    public UserVM LogedUser { get; set; }
    public double LogesUserHours { get; set; }
    public string LogedUserObjectId { get; set; } = null;

    public void Clear()
    {
        TeamsLogedUser = null;
        LogedUser = null;
        LogesUserHours = 0.0;
        LogedUserObjectId = null;
        LoggedUserRoles.Clear();
        Permissions.Clear();
        PermissionOrds.Clear();
    }
}
