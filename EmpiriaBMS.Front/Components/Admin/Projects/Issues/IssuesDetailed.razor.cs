﻿using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Components.General;
using EmpiriaBMS.Front.Interop.TeamsSDK;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.Admin.Projects.Issues;

public partial class IssuesDetailed
{
    [Parameter]
    public string Title { get; set; } = null;

    [Parameter]
    public bool DisplayActions { get; set; } = false;

    [Parameter]
    public bool CalledFromDash { get; set; } = false;

    [Parameter]
    public IssueVM Content { get; set; } = default!;

    [Parameter]
    public EventCallback<IssueVM> OnSave { get; set; } = default!;

    [Parameter]
    public EventCallback OnCancel { get; set; } = default!;

    SignaturePad verificatorSignature;
    SignaturePad pMSignature;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _getRecords();

            if (Content.Project != null)
            {
                var projectDto = Mapping.Mapper.Map<ProjectDto>(Content.Project);
                Project = _mapper.Map<ProjectVM>(projectDto);
            }

            if (Content.DisplayedRole != null)
            {
                var roleDto = Mapping.Mapper.Map<RoleDto>(Content.DisplayedRole);
                Role = _mapper.Map<RoleVM>(roleDto);
            }

            if (Content.Creator != null)
            {
                var creatorDto = Mapping.Mapper.Map<UserDto>(Content.Creator);
                Creator = _mapper.Map<UserVM>(creatorDto);
            }

            StateHasChanged();
        }
    }

    private async Task SaveAsync()
    {
        var valid = Validate();
        if (!valid) return;

        Content.PMSignature = pMSignature != null ? await pMSignature.GetImageData() : null;
        Content.VerificatorSignature = verificatorSignature != null ? await verificatorSignature.GetImageData() : null;

        await OnSave.InvokeAsync(Content);
    }

    private async Task CancelAsync()
    {
        await OnSave.InvokeAsync();
    }

    #region Documents
    private async Task DownloadFile(DocumentVM document)
    {
        var dto = _mapper.Map<DocumentDto>(document);
        await MicrosoftTeams.DownloadFile(dto);
    }

    private void DeleteFile(DocumentVM document)
    {
        var dto = _mapper.Map<DocumentDto>(document);
        _dataProvider.Issues.DeleteDocument(dto);
        _documents.Remove(document);
        _deletedDocuments.Add(document);
    }

    private async Task AddFile(DocumentVM document)
    {
        var dto = _mapper.Map<DocumentDto>(document);
        await _dataProvider.Issues.AddDocument(dto);
        _documents.Add(document);
        _deletedDocuments.Remove(document);
    }
    #endregion

    #region Validation
    private bool validProject = true;
    private bool validRole = true;
    private bool validCreator = true;
    private bool validDescription = true;

    private bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validProject = Content.ProjectId != 0;
            validRole = Content.DisplayedRoleId != 0;
            validCreator = Content.CreatorId != 0;
            validDescription = !string.IsNullOrEmpty(Content.Description);

            return validProject && validRole && validCreator && validDescription;
        }
        else
        {
            validProject = true;
            validRole = true;
            validCreator = true;
            validDescription = true;

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
                case "Description":
                    validDescription = !string.IsNullOrEmpty(Content.Description);
                    return validDescription;
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
    ObservableCollection<DocumentVM> _documents = new ObservableCollection<DocumentVM>();
    ObservableCollection<DocumentVM> _deletedDocuments = new ObservableCollection<DocumentVM>();

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
        await _getMyDocuments();
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

    private async Task _getMyDocuments()
    {
        if (Content == null || Content.Id == 0)
            return;
        var dtos = await _dataProvider.Issues.GetMyDocuments(Content.Id);
        var vms = _mapper.Map<List<DocumentVM>>(dtos);
        _documents.Clear();
        vms.ForEach(_documents.Add);
    }
    #endregion
}
