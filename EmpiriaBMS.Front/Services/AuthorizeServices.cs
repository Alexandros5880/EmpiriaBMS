using AutoMapper;
using EmpiriaBMS.Core;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.TeamsFx;
using NuGet.Protocol;
using System.Diagnostics;

namespace EmpiriaBMS.Front.Services;

public class AuthorizeServices
{
    private IDataProvider _dataProvider;
    private TeamsUserCredential _teamsUserCredential;
    private IMapper _mapper;

    public ICollection<RoleVM> LoggedUserRoles { get; set; } = new List<RoleVM>();
    public ICollection<PermissionDto> Permissions { get; set; } = new List<PermissionDto>();
    public ICollection<int> PermissionOrds { get; set; } = new List<int>();
    public UserVM LogedUser { get; set; }
    public double LogesUserHours { get; set; }

    // Engineer, Designer, Project Manager, CTO, COO, Guest, CEO, Customer, Admin
    public string DefaultRoleName { get; set; } = "Admin";
    public int DefaultRoleId { get; set; } = 0;
    public string LogedUserObjectId { get; set; } = null;

    public Func<Task> CallBackOnAuthorize { get; set; }

    public AuthorizeServices(
        IDataProvider dataProvider,
        TeamsUserCredential teamsUserCredential,
        IMapper mapper
    ) {
        _dataProvider = dataProvider;
        _teamsUserCredential = teamsUserCredential;
        _mapper = mapper;
    }

    public async Task Authorize()
    {
        await _getRandomUserByRole();

        if (CallBackOnAuthorize != null)
            await CallBackOnAuthorize.Invoke();
    }

    public async Task Authorize(int roleId = 0, bool runInTeams = true)
    {
        if (runInTeams)
        {
            // TODO: Get Teams Logged User And Mach him With Our Users
            UserInfo teamsUser = teamsUser = await _teamsUserCredential.GetUserInfoAsync();

            LogedUserObjectId = teamsUser.ObjectId;
            //var userExists = _dataProvider.Users.Exists(teamsUser.PreferredUserName);

            //await _getLogedUser(LogedUserObjectId);
        }

        
        // TODO: When Fix Authorization with teams Remove that
        await _getRandomUserByRole(roleId);



        if (CallBackOnAuthorize != null)
            await CallBackOnAuthorize.Invoke();
    }

    public async Task Authorize(string objectId)
    {
        await _getLogedUser(objectId);

        if (CallBackOnAuthorize != null)
            await CallBackOnAuthorize.Invoke();
    }

    private async Task _getLogedUser(string objectId)
    {
        try
        {
            var users = await _dataProvider.Roles.GetUsers(DefaultRoleId);
            var dbUser = users.FirstOrDefault();

            if (dbUser == null)
                throw new NullReferenceException(nameof(dbUser));

            LogedUser = _mapper.Map<UserVM>(dbUser);

            LogesUserHours = await _dataProvider.Users.GetUserHoursFromLastMonday(LogedUser.Id, DateTime.Now);

            LoggedUserRoles = (await _dataProvider.Roles.GetRoles(dbUser.Id))
                                                        .Select(r => _mapper.Map<RoleVM>(r))
                                                        .ToList();

            Permissions = (await _dataProvider.Roles.GetPermissions(dbUser.Id))
                                                    .ToList();
            PermissionOrds = Permissions.Select(p => p.Ord).ToList();

            // if (_loggedUserRoles.Select(r => r.Name).ToList().Contains("Admin"))
            // {

            // }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
    }

    private async Task _getRandomUserByRole(int roleId = 0)
    {
        try
        {
            DefaultRoleId = roleId != 0 ? roleId : await _getRoleId(DefaultRoleName);

            var users = await _dataProvider.Roles.GetUsers(DefaultRoleId);
            var dbUser = users.FirstOrDefault();

            if (dbUser == null)
                throw new NullReferenceException(nameof(dbUser));

            LogedUser = _mapper.Map<UserVM>(dbUser);

            LogesUserHours = await _dataProvider.Users.GetUserHoursFromLastMonday(LogedUser.Id, DateTime.Now);

            LoggedUserRoles = (await _dataProvider.Roles.GetRoles(dbUser.Id))
                                                        .Select(r => _mapper.Map<RoleVM>(r))
                                                        .ToList();

            Permissions = (await _dataProvider.Roles.GetPermissions(dbUser.Id))
                                                    .ToList();
            PermissionOrds = Permissions.Select(p => p.Ord).ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
    }

    private async Task<int> _getRoleId(string roleName)
    {
        try
        {
            var role = await _dataProvider.Roles.Get(roleName);
            return role?.Id ?? 0;
        }
        catch (Exception ex)
        {
            // TODO: Log Error
            Debug.WriteLine($"Exception: {ex.Message}");
            return 0;
        }
    }
}
