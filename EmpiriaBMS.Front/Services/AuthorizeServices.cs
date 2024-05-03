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

    public Func<Task> CallBackOnAuthorize { get; set; }

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

    public async Task<bool> Authorize(int userId = 0, bool runInTeams = true)
    {
        _sharedAuthData.Clear();
        bool result = false;

        // TODO: When Fix Authorization with teams Remove that
        if (userId != 0)
        {
            var logedUser = await _dataProvider.Users.Get(userId);
            _sharedAuthData.LogedUser = _mapper.Map<UserVM>(logedUser);
            _sharedAuthData.LoggedUserRoles = (await _dataProvider.Roles.GetRoles(logedUser.Id))
                                                    .Select(r => _mapper.Map<RoleVM>(r))
                                                    .ToList();
            var parentRole = await _dataProvider.Roles.GetParentRole(logedUser.Id);
            _sharedAuthData.LoggedUserParentRole = _mapper.Map<RoleVM>(parentRole);
            _sharedAuthData.Permissions = (await _dataProvider.Roles.GetPermissions(logedUser.Id))
                                                    .ToList();
            _sharedAuthData.PermissionOrds = _sharedAuthData.Permissions.Select(p => p.Ord).ToList();

            result = true;
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
                _sharedAuthData.LoggedUserRoles = (await _dataProvider.Roles.GetRoles(logedUser.Id))
                                                        .Select(r => _mapper.Map<RoleVM>(r))
                                                        .ToList();
                var parentRole = await _dataProvider.Roles.GetParentRole(logedUser.Id);
                _sharedAuthData.LoggedUserParentRole = _mapper.Map<RoleVM>(parentRole);
                _sharedAuthData.Permissions = (await _dataProvider.Roles.GetPermissions(logedUser.Id))
                                                        .ToList();
                _sharedAuthData.PermissionOrds = _sharedAuthData.Permissions.Select(p => p.Ord).ToList();

                result = true;
            }
            else
            {
                // TODO: When Fix Authorization with teams Remove that
                // Save User and Display a message to admin to register this user
                await _getRandomUser();

                result = true;
            }
        }
        else
        {
            result = false;
        }

        if (CallBackOnAuthorize != null)
            await CallBackOnAuthorize.Invoke();

        return result;
    }

    // TODO: When Fix Authorization with teams Remove that
    private async Task _getRandomUser()
    {
        try
        {
            var users = await _dataProvider.Users.GetAll();
            var logedUser = users.FirstOrDefault();
            _sharedAuthData.LogedUser = _mapper.Map<UserVM>(logedUser);
            _sharedAuthData.LoggedUserRoles = (await _dataProvider.Roles.GetRoles(logedUser.Id))
                                                    .Select(r => _mapper.Map<RoleVM>(r))
                                                    .ToList();
            var parentRole = await _dataProvider.Roles.GetParentRole(logedUser.Id);
            _sharedAuthData.LoggedUserParentRole = _mapper.Map<RoleVM>(parentRole);
            _sharedAuthData.Permissions = (await _dataProvider.Roles.GetPermissions(logedUser.Id))
                                                    .ToList();
            _sharedAuthData.PermissionOrds = _sharedAuthData.Permissions.Select(p => p.Ord).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
    }
}
