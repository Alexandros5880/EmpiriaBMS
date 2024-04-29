using AutoMapper;
using EmpiriaBMS.Core;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.Interfaces;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using NuGet.Packaging;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.Admin.Projects.Issues;

public partial class IssuesDetailedDialog : IDialogContentComponent<IssueVM>
{
    [Parameter]
    public IssueVM Content { get; set; } = default!;

    [CascadingParameter]
    public FluentDialog Dialog { get; set; } = default!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _getRecords();

            StateHasChanged();
        }
    }

    private async Task SaveAsync()
    {
        var valid = Validate();
        if (!valid) return;

        await Dialog.CloseAsync(Content);
    }

    private async Task CancelAsync()
    {
        await Dialog.CancelAsync();
    }

    #region Validation
    private bool validProject = true;
    private bool validRole = true;
    private bool validCreator = true;

    private bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validProject = Content.ProjectId != 0;
            validRole = Content.DisplayedRoleId != 0;
            validCreator = Content.CreatorId != 0;

            return validProject && validRole && validCreator;
        }
        else
        {
            validProject = true;
            validRole = true;
            validCreator = true;

            switch (fieldname)
            {
                case "Project":
                    validProject = Content.ProjectId != 0;
                    return validProject;
                case "Role":
                    validRole = Content.DisplayedRoleId != 0;
                    return validRole;
                case "Creator":
                    validCreator = Content.CreatorId != 0;
                    return validCreator;
                default:
                    return true;
            }

        }
    }
    #endregion

    #region Get Related Records
    ObservableCollection<ProjectVM> _projects = new ObservableCollection<ProjectVM>();
    ObservableCollection<RoleVM> _roles = new ObservableCollection<RoleVM>();
    ObservableCollection<UserVM> _users = new ObservableCollection<UserVM>();

    private ProjectVM _project = new ProjectVM();
    public ProjectVM Project
    {
        get => _project;
        set
        {
            if (_project == value || value == null) return;
            _project = value;
            Content.ProjectId = _project.Id;
        }
    }

    private RoleVM _role = new RoleVM();
    public RoleVM Role
    {
        get => _role;
        set
        {
            if (_role == value || value == null) return;
            _role = value;
            Content.DisplayedRoleId = _role.Id;
        }
    }

    private UserVM _creator = new UserVM();
    public UserVM Creator
    {
        get => _creator;
        set
        {
            if (_creator == value || value == null) return;
            _creator = value;
            Content.CreatorId = _creator.Id;
        }
    }

    private async Task _getRecords()
    {
        await _getProjects();
        await _getRoles();
        await _getUsers();
    }

    private async Task _getProjects()
    {
        var dtos = await _dataProvider.Projects.GetAll();
        var vms = _mapper.Map<List<ProjectVM>>(dtos);
        _projects.Clear();
        vms.ForEach(_projects.Add);
    }

    private async Task _getRoles()
    {
        var dtos = await _dataProvider.Roles.GetAll();
        var vms = _mapper.Map<List<RoleVM>>(dtos);
        _roles.Clear();
        vms.ForEach(_roles.Add);
    }

    private async Task _getUsers()
    {
        var dtos = await _dataProvider.Users.GetAll();
        var vms = _mapper.Map<List<UserVM>>(dtos);
        _users.Clear();
        vms.ForEach(_users.Add);
    }
    #endregion
}
