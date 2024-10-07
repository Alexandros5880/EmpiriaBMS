using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using System;
using System.Collections.ObjectModel;
using EmpiriaBMS.Front.Components.General;
using EmpiriaBMS.Front.Components.Admin.Projects.SubCategories;
using EmpiriaBMS.Front.Components.Admin.Projects.SubConstructors;

namespace EmpiriaBMS.Front.Components.Home.Projects;
public partial class ProjectDetailedDialog : IDialogContentComponent<ProjectVM>
{
    [Parameter]
    public ProjectVM Content { get; set; } = default!;

    [CascadingParameter]
    public FluentDialog Dialog { get; set; } = default!;

    ObservableCollection<OfferVM> _offers = new ObservableCollection<OfferVM>();
    ObservableCollection<ProjectStageVM> _stages = new ObservableCollection<ProjectStageVM>();
    ObservableCollection<UserVM> _pms = new ObservableCollection<UserVM>();
    private ObservableCollection<SubConstructorVM> _subConstructors = new ObservableCollection<SubConstructorVM>();

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
            await _getRecords();

            await RefreshMap();

            StateHasChanged();
        }
    }

    private async Task SaveAsync()
    {
        var valid = Validate();
        if (!valid)
            return;

        Content.SubConstructorsIds = _subConstructors.Where(r => r.IsSelected).Select(s => s.Id).ToList();

        await Dialog.CloseAsync(Content);
    }

    private async Task CancelAsync()
    {
        await Dialog.CancelAsync();
    }

    #region Sub Constractors
    private SubConstructorDetailed _subConstructionDetailComp;
    private bool _addSubConstructorMode = false;

    private void _addSubConstructor()
    {
        _addSubConstructorMode = true;
    }

    private void _onSubConstructorSave(SubConstructorVM updated)
    {
        _subConstructors.Insert(0, updated);
        _addSubConstructorMode = false;
    }

    private void _onSubConstructorCancel()
    {
        _addSubConstructorMode = false;
    }
    #endregion

    #region Validation
    private bool validOffer = true;
    private bool validName = true;
    private bool validCode = true;
    private bool validStage = true;
    private bool validPm = true;

    private bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validOffer = _offer != null && _offer.Id != 0;
            validName = !string.IsNullOrEmpty(Content.Name);
            validCode = !string.IsNullOrEmpty(Content.Code);
            validStage = _stage != null && _stage.Id != 0;
            validPm = _pm != null && _pm.Id != 0;

            return validOffer && validName && validCode && validStage && validPm;
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
                    return validOffer;
                case "Name":
                    validName = !string.IsNullOrEmpty(Content.Name);
                    return validName;
                case "Code":
                    validCode = !string.IsNullOrEmpty(Content.Code);
                    return validCode;
                case "Stage":
                    validStage = _stage != null && _stage.Id != 0;
                    return validStage;
                case "PM":
                    validPm = _pm != null && _pm.Id != 0;
                    return validPm;
                default:
                    return true;
            }

        }
    }
    #endregion

    #region Get Related Records
    private bool _loadRecords = true;

    private async Task _getRecords()
    {
        _loadRecords = true;
        await _getOffers();
        await _getStages();
        await _getProjectManagers();
        await _getSubConstructors();
        _loadRecords = false;
    }

    private async Task _getStages()
    {
        var dtos = await DataProvider.ProjectStages.GetAll();
        var vms = Mapper.Map<List<ProjectStageVM>>(dtos);
        _stages.Clear();
        vms.ForEach(_stages.Add);

        Stage = _stages.FirstOrDefault(c => c.Id == Content.StageId) ?? null;
    }

    private async Task _getProjectManagers()
    {
        var dtos = await DataProvider.Users.GetProjectManagers();
        var vms = Mapper.Map<List<UserVM>>(dtos);
        _pms.Clear();
        vms.ForEach(_pms.Add);

        Pm = _pms.FirstOrDefault(c => c.Id == Content.ProjectManagerId) ?? null;
    }

    private async Task _getOffers()
    {
        var dtos = await DataProvider.Offers.GetAll(result: Models.Enum.OfferResult.SUCCESSFUL);
        var vms = Mapper.Map<List<OfferVM>>(dtos);
        _offers.Clear();
        vms.ForEach(_offers.Add);

        Offer = _offers.FirstOrDefault(o => o.Id == Content.OfferId) ?? null;
    }

    private async Task _getSubConstructors()
    {
        if (Content.Id == 0)
            return;

        var dtos = await DataProvider.SubConstructors.GetAll();
        var vms = Mapper.Map<List<SubConstructorVM>>(dtos);

        var mySubConstructorsIds = (await DataProvider.Projects.GetSubConstructorsIds(Content.Id));

        _subConstructors.Clear();
        vms.ForEach(s =>
        {
            s.IsSelected = mySubConstructorsIds.Contains(s.Id);
            _subConstructors.Add(s);
        });
    }
    #endregion

    #region Map Address
    private Map _map;

    public async Task RefreshMap()
    {
        if (Content.Id != 0 && Content.Address != null)
        {
            await _map.SetAddress(Content.Address);
        }
    }

    private void _onSearchAddressChange()
    {
        var address = _map.GetAddress();
        if (address != null)
            Content.Address = address;
    }
    #endregion
}
