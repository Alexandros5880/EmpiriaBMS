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
    private readonly IDataProvider _dataProvider;
    private readonly TeamsUserCredential _teamsUserCredential;
    private readonly IMapper _mapper;
    private readonly SharedAuthDataService _sharedAuthData;

    public Action CallBackOnAuthorize { get; set; }

    public AuthorizeServices(
        IDataProvider dataProvider,
        TeamsUserCredential teamsUserCredential,
        IMapper mapper,
        SharedAuthDataService sharedData
    ) {
        _dataProvider = dataProvider;
        _teamsUserCredential = teamsUserCredential;
        _mapper = mapper;
        _sharedAuthData = sharedData;
    }

    public async Task Authorize(int roleId = 0, bool runInTeams = true)
    {
        _sharedAuthData.Clear();

        // TODO: When Fix Authorization with teams Remove that
        if (roleId != 0)
        {
            await _getRandomUserByRole(roleId);
        }

        else if (runInTeams)
        {
            // TODO: Get Teams Logged User And Mach him With Our Users
            UserInfo teamsUser = teamsUser = await _teamsUserCredential.GetUserInfoAsync();

            _sharedAuthData.TeamsLogedUser = teamsUser;
            _sharedAuthData.LogedUserObjectId = teamsUser.ObjectId;

            var userExists = await _dataProvider.Users.Exists(teamsUser.PreferredUserName);

            if (userExists)
            {
                var logedUser = await _dataProvider.Users.Get(teamsUser.PreferredUserName);
                _sharedAuthData.LogedUser = _mapper.Map<UserVM>(logedUser);
                _sharedAuthData.LogesUserHours = await _dataProvider.Users.GetUserHoursFromLastMonday(_sharedAuthData.LogedUser.Id, DateTime.Now);
                _sharedAuthData.LoggedUserRoles = (await _dataProvider.Roles.GetRoles(logedUser.Id))
                                                        .Select(r => _mapper.Map<RoleVM>(r))
                                                        .ToList();

                _sharedAuthData.Permissions = (await _dataProvider.Roles.GetPermissions(logedUser.Id))
                                                        .ToList();
                _sharedAuthData.PermissionOrds = _sharedAuthData.Permissions.Select(p => p.Ord).ToList();
            }
            else
            {
                // TODO: When Fix Authorization with teams Remove that
                await _getRandomUserByRole();
            }
        }
        else
        {
            // TODO: Go to login page
        }

        if (CallBackOnAuthorize != null)
            CallBackOnAuthorize.Invoke();
    }

    public async Task UpdateUserHours() =>
        _sharedAuthData.LogesUserHours = await _dataProvider.Users.GetUserHoursFromLastMonday(_sharedAuthData.LogedUser.Id, DateTime.Now);


    // TODO: When Fix Authorization with teams Remove that
    private async Task _getLogedUser(string objectId)
    {
        try
        {
            var users = await _dataProvider.Roles.GetUsers(_sharedAuthData.DefaultRoleId);
            var dbUser = users.FirstOrDefault();

            if (dbUser == null)
                throw new NullReferenceException(nameof(dbUser));

            _sharedAuthData.LogedUser = _mapper.Map<UserVM>(dbUser);

            _sharedAuthData.LogesUserHours = await _dataProvider.Users
                            .GetUserHoursFromLastMonday(_sharedAuthData.LogedUser.Id, DateTime.Now);

            _sharedAuthData.LoggedUserRoles = (await _dataProvider.Roles.GetRoles(dbUser.Id))
                                                        .Select(r => _mapper.Map<RoleVM>(r))
                                                        .ToList();

            _sharedAuthData.Permissions = (await _dataProvider.Roles.GetPermissions(dbUser.Id))
                                                    .ToList();
            _sharedAuthData.PermissionOrds = _sharedAuthData.Permissions.Select(p => p.Ord).ToList();

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
            _sharedAuthData.DefaultRoleId = roleId != 0 ? roleId : await _getRoleId(_sharedAuthData.DefaultRoleName);

            var users = await _dataProvider.Roles.GetUsers(_sharedAuthData.DefaultRoleId);
            var dbUser = users.FirstOrDefault();

            if (dbUser == null)
                throw new NullReferenceException(nameof(dbUser));

            _sharedAuthData.LogedUser = _mapper.Map<UserVM>(dbUser);

            _sharedAuthData.LogesUserHours = await _dataProvider.Users.GetUserHoursFromLastMonday(_sharedAuthData.LogedUser.Id, DateTime.Now);

            _sharedAuthData.LoggedUserRoles = (await _dataProvider.Roles.GetRoles(dbUser.Id))
                                                        .Select(r => _mapper.Map<RoleVM>(r))
                                                        .ToList();

            _sharedAuthData.Permissions = (await _dataProvider.Roles.GetPermissions(dbUser.Id))
                                                    .ToList();
            _sharedAuthData.PermissionOrds = _sharedAuthData.Permissions.Select(p => p.Ord).ToList();
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
