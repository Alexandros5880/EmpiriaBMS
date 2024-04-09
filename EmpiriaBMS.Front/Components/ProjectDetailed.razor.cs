using AutoMapper;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Front.Components.Admin.DisciplinesTypes;
using System.Linq.Expressions;
using EmpiriaBMS.Front.Components.Admin.ProjectsTypes;
using System.Security.Cryptography;
using EmpiriaBMS.Front.ViewModel.Validation;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Components.Web;

namespace EmpiriaBMS.Front.Components;
public partial class ProjectDetailed : ComponentBase, IDisposable
{
    private bool disposedValue;
    private bool isNew = false;
    private string defaultCodeValue = "*******";

    #region Authorization Properties
    bool seeCode => _sharedAuthData.Permissions.Any(p => p.Ord == 13);
    #endregion

    private ProjectGroupVM _createdGroup = new ProjectGroupVM();
    private ProjectValidator _validator = new ProjectValidator();
    private List<ProjectGroupDto> _projectGroups = new List<ProjectGroupDto>();
    private List<ProjectStageDto> _projectStages = new List<ProjectStageDto>();
    private List<ProjectTypeDto> _projectTypes = new List<ProjectTypeDto>();
    private ProjectVM _project = new ProjectVM();

    private async Task _getProjectGroups()
    {
        _projectGroups.Clear();
        _projectGroups = (await DataProvider.ProjectsGroups.GetAll()).ToList();
    }

    private async Task _getProjectStages()
    {
        _projectStages.Clear();
        _projectStages = (await DataProvider.ProjectStages.GetAll()).ToList();
    }

    private async Task _getProjectTypes()
    {
        _projectTypes.Clear();
        _projectTypes = (await DataProvider.ProjectsTypes.GetAll()).ToList();
    } 

    public async void PrepairForNew()
    {
        isNew = true;
        await _getProjectGroups();
        await _getProjectStages();
        await _getProjectTypes();
        _createdGroup = new ProjectGroupVM();
        _project = new ProjectVM();
        _project.Active = true;
        //_project.GroupId = _projectGroups.FirstOrDefault().Id;
        //_project.StageId = _projectStages.FirstOrDefault().Id;
        //_project.TypeId = _projectTypes.FirstOrDefault().Id;
        _project.GroupId = 0;
        _project.StageId = 0;
        _project.TypeId = 0;
        StateHasChanged();
    }

    public async void PrepairForEdit(ProjectVM project)
    {
        isNew = false;
        await _getProjectGroups();
        await _getProjectStages();
        await _getProjectTypes();
        _createdGroup = new ProjectGroupVM();
        _project = project;
        StateHasChanged();
    }

    private void _updateProjectType(ChangeEventArgs e)
    {
        var projectTypeId = Convert.ToInt32(e.Value);
        _project.TypeId = projectTypeId;
        var typeDto = _projectTypes.FirstOrDefault(g => g.Id == projectTypeId);
        _project.Type = Mapping.Mapper.Map<ProjectType>(typeDto);
    }

    private void _updateProjectStage(ChangeEventArgs e)
    {
        var projectStageId = Convert.ToInt32(e.Value);
        _project.StageId = projectStageId;
        var stageDto = _projectStages.FirstOrDefault(g => g.Id == projectStageId);
        _project.Stage = Mapping.Mapper.Map<ProjectStage>(stageDto);
    }

    private void _updateProjectGroup(ChangeEventArgs e)
    {
        _createdGroup = new ProjectGroupVM();
        var projectGroupId = Convert.ToInt32(e.Value);
        _project.GroupId = projectGroupId;
        var groupDto = _projectGroups.FirstOrDefault(g => g.Id == projectGroupId);
        _project.Group = Mapping.Mapper.Map<ProjectGroup>(groupDto);

        _validator.ValidateProperty(_project, nameof(ProjectVM.GroupId), _project.GroupId);
        StateHasChanged();
    }

    private void _onGroupNameChange(ChangeEventArgs e)
    {
        var value = e.Value.ToString();
        _validator.ValidateProperty(_project, "GroupName", value);
        StateHasChanged();
    }

    private async Task _createGroup()
    {
        try
        {
            if (!_validator.ValidateProperty(_project, "GroupName", _createdGroup.Name))
                return;

            var dto = Mapper.Map<ProjectGroupDto>(_createdGroup);
            ProjectGroupDto result = await DataProvider.ProjectsGroups.Add(dto);
            if (result == null)
                throw new NullReferenceException(nameof(result));

            _createdGroup = new ProjectGroupVM();

            _project.GroupId = result.Id;
            _project.Group = Mapping.Mapper.Map<ProjectGroup>(result);

            PrepairForEdit(_project);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }

    }

    public async Task HandleValidSubmit()
    {
        try
        {
            _project.Group = null;
            _project.Stage = null;
            _project.Type = null;

            // Save Project
            ProjectDto saveProject;
            var exists = await DataProvider.Projects.Any(p =>  p.Id == _project.Id);
            if (exists)
                saveProject = await DataProvider.Projects.Update(Mapper.Map<ProjectDto>(_project));
            else
                saveProject = await DataProvider.Projects.Add(Mapper.Map<ProjectDto>(_project));

            if (saveProject == null)
                throw new NullReferenceException(nameof(saveProject));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                
            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
