using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components;
public partial class ProjectDetailed : ComponentBase
{
    FluentCombobox<ProjectStageVM> _stageCombo;
    FluentCombobox<UserVM> _pmCombo;

    private ProjectVM _project;
    [Parameter]
    public ProjectVM Content
    {
        get => _project;
        set
        {
            _project = value ?? new ProjectVM();
        }
    }

    [Parameter]
    public bool DisplayActions { get; set; } = true;

    public bool _isNew => Content?.Id != 0 && Content?.Id != null;

    ObservableCollection<ProjectStageVM> _stages = new ObservableCollection<ProjectStageVM>();
    ObservableCollection<UserVM> _pms = new ObservableCollection<UserVM>();

    private ProjectStageVM _stage = new ProjectStageVM();
    public ProjectStageVM Stage
    {
        get => _stage;
        set
        {
            if (_stage == value || value == null) return;
            _stage = value;
            Content.StageId = _stage.Id;
        }
    }

    private UserVM _pm = new UserVM();
    public UserVM Pm
    {
        get => _pm;
        set
        {
            if (_pm == value || value == null) return;
            _pm = value;
            Content.ProjectManagerId = _pm.Id;
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await Prepair();
        }
    }

    public async Task Prepair(ProjectVM project = null)
    {
        if (project != null)
            Content = project;

        await _getRecords();

        if (Content.Stage != null)
        {
            var stageDto = Mapping.Mapper.Map<ProjectStageDto>(Content.Stage);
            Stage = Mapper.Map<ProjectStageVM>(stageDto);
        }
        else if (Content.StageId != 0)
        {
            Stage = _stages.FirstOrDefault(c => c.Id == Content.StageId);
        }
        _stageCombo.Value = Stage.Name;

        if (Content.ProjectManager != null)
        {
            var pmDto = Mapping.Mapper.Map<UserDto>(Content.ProjectManager);
            Pm = Mapper.Map<UserVM>(pmDto);
        }
        else if (Content.ProjectManagerId != 0)
        {
            Pm = _pms.FirstOrDefault(c => c.Id == Content.ProjectManagerId);
        }
        _pmCombo.Value = Pm.FullName;

        StateHasChanged();
    }

    public async Task<ProjectVM> SaveAsync()
    {
        var valid = Validate();
        if (!valid)
            return null;

        try
        {
            Content.Stage = null;
            Content.Offer = null;

            // Save Project
            ProjectDto saveProject;
            var exists = await DataProvider.Projects.Any(p => p.Id == Content.Id);
            if (exists)
                saveProject = await DataProvider.Projects.Update(Mapper.Map<ProjectDto>(Content));
            else
                saveProject = await DataProvider.Projects.Add(Mapper.Map<ProjectDto>(Content));

            if (saveProject == null)
                throw new NullReferenceException(nameof(saveProject));

            var projectVm = Mapper.Map<ProjectVM>(saveProject);

            return projectVm;
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error

            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error

            return null;
        }
    }

    public ProjectVM GetProject() => Content as ProjectVM;

    #region Validation
    private bool validName = true;
    private bool validCode = true;
    private bool validStage = true;
    private bool validPm = true;
    private bool validEstHours = true;

    public bool Validate(string fieldname = null)
    {
        var valid = false;
        if (fieldname == null)
        {
            validName = !string.IsNullOrEmpty(Content.Name);
            validCode = !string.IsNullOrEmpty(Content.Code);
            validStage = _stage != null && _stage.Id != 0;
            validPm = _pm != null && _pm.Id != 0;
            validEstHours = Content.EstimatedHours > 0;

            valid = validName && validCode && validStage && validPm && validEstHours;
        }
        else
        {
            validName = true;
            validCode = true;
            validStage = true;
            validPm = true;

            switch (fieldname)
            {
                case "Name":
                    validName = !string.IsNullOrEmpty(Content.Name);
                    valid = validName;
                    break;
                case "Code":
                    validCode = !string.IsNullOrEmpty(Content.Code);
                    valid = validCode;
                    break;
                case "Stage":
                    validStage = _stage != null && _stage.Id != 0;
                    valid = validStage;
                    break;
                case "PM":
                    validPm = _pm != null && _pm.Id != 0;
                    valid = validPm;
                    break;
                case "EstimatedHours":
                    validEstHours = Content.EstimatedHours > 0;
                    valid = validEstHours;
                    break;
                default:
                    valid = true;
                    break;
            }
        }
        StateHasChanged();
        return valid;
    }
    #endregion

    #region Get Related Records
    private async Task _getRecords()
    {
        await _getStages();
        await _getProjectManagers();
    }

    private async Task _getStages()
    {
        var dtos = await DataProvider.ProjectStages.GetAll();
        var vms = Mapper.Map<List<ProjectStageVM>>(dtos);
        _stages.Clear();
        vms.ForEach(_stages.Add);
    }

    private async Task _getProjectManagers()
    {
        var dtos = await DataProvider.Users.GetProjectManagers();
        var vms = Mapper.Map<List<UserVM>>(dtos);
        _pms.Clear();
        vms.ForEach(_pms.Add);
    }
    #endregion
}
