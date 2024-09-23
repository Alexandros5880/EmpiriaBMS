using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components;
public partial class ProjectDetailed : ComponentBase
{
    FluentCombobox<OfferVM> _offerCombo;
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

    ObservableCollection<OfferVM> _offers = new ObservableCollection<OfferVM>();
    ObservableCollection<ProjectStageVM> _stages = new ObservableCollection<ProjectStageVM>();
    ObservableCollection<UserVM> _pms = new ObservableCollection<UserVM>();

    private OfferVM _offer = new OfferVM();
    public OfferVM Offer
    {
        get => _offer;
        set
        {
            if (_offer == value || value == null) return;
            _offer = value;
            Content.OfferId = _offer.Id;
        }
    }

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

        // Offer
        if (Content.Offer != null)
        {
            var offerDto = Mapping.Mapper.Map<OfferDto>(Content.Offer);
            Offer = Mapper.Map<OfferVM>(offerDto);
            _offerCombo.Value = Offer.Code;
        }
        else if (Content.OfferId != 0 && Content.OfferId != null)
        {
            Offer = _offers.OrderByDescending(o => o.CreatedDate).FirstOrDefault(c => c.Id == Content.OfferId);
            _offerCombo.Value = Offer.Code;
        }
        else
        {
            Offer = new OfferVM();
            _offerCombo.Value = string.Empty;
        }


        // Stage
        if (Content.Stage != null)
        {
            var stageDto = Mapping.Mapper.Map<ProjectStageDto>(Content.Stage);
            Stage = Mapper.Map<ProjectStageVM>(stageDto);
            _stageCombo.Value = Stage.Name;
        }
        else if (Content.StageId != 0)
        {
            Stage = _stages.FirstOrDefault(c => c.Id == Content.StageId);
            _stageCombo.Value = Stage.Name;
        }
        else
        {
            Stage = new ProjectStageVM();
            _stageCombo.Value = string.Empty;
        }

        // ProjectManager
        if (_pmCombo != null)
        {
            if (Content.ProjectManager != null)
            {
                var pmDto = Mapping.Mapper.Map<UserDto>(Content.ProjectManager);
                Pm = Mapper.Map<UserVM>(pmDto);
                _pmCombo.Value = Pm.FullName;
            }
            else if (Content.ProjectManagerId != 0 && Content.ProjectManagerId != null)
            {
                Pm = _pms.FirstOrDefault(c => c.Id == Content.ProjectManagerId);
                _pmCombo.Value = Pm.FullName;
            }
            else
            {
                Pm = new UserVM();
                _pmCombo.Value = string.Empty;
            }
        }

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

            Content = projectVm;

            return projectVm;
        }
        catch (NullReferenceException ex)
        {
            Logger.LogError($"Exception ProjectDetailed.SaveAsync(): {ex.Message}, \n Inner Exception: {ex.InnerException}");

            return null;
        }
        catch (Exception ex)
        {
            Logger.LogError($"Exception ProjectDetailed.SaveAsync(): {ex.Message}, \n Inner Exception: {ex.InnerException}");

            return null;
        }
    }

    public ProjectVM GetProject() => Content as ProjectVM;

    #region Validation
    private bool validOffer = true;
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
            validOffer = _offer != null && _offer.Id != 0;
            validName = !string.IsNullOrEmpty(Content.Name);
            validCode = !string.IsNullOrEmpty(Content.Code);
            validStage = _stage != null && _stage.Id != 0;
            validPm = _pm != null && _pm.Id != 0;
            validEstHours = Content.EstimatedHours > 0;

            valid = validOffer && validName && validCode && validStage && validPm && validEstHours;
        }
        else
        {
            validOffer = true;
            validName = true;
            validCode = true;
            validStage = true;
            validPm = true;

            switch (fieldname)
            {
                case "Offer":
                    validOffer = _offer != null && _offer.Id != 0;
                    valid = validOffer;
                    break;
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
        await _getOffers();
        await _getStages();
        await _getProjectManagers();
        await _getOffer();
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

    private async Task _getOffer()
    {
        if (Content == null || Content.OfferId == null)
            return;

        var dto = await DataProvider.Offers.Get((int)Content.OfferId);
        _offer = Mapper.Map<OfferVM>(dto);
    }

    private async Task _getOffers()
    {
        var dtos = await DataProvider.Offers.GetAll(result: Models.Enum.OfferResult.SUCCESSFUL);
        var vms = Mapper.Map<List<OfferVM>>(dtos);
        _offers.Clear();
        vms.ForEach(_offers.Add);
    }
    #endregion
}
