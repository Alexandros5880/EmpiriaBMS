using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Components.Admin.Leds;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Enum;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;

namespace EmpiriaBMS.Front.Components.Offers;

public partial class OfferCreationWizzard
{
    private bool _isNew => Offer?.Id == 0;
    private bool _loading = false;

    public LedVM Led { get; set; } = default!;

    [Parameter]
    public OfferVM Offer { get; set; } = default!;

    [Parameter]
    public EventCallback OnSave { get; set; }

    [Parameter]
    public EventCallback OnCansel { get; set; }

    #region Actions Enabled Variables
    private bool _offerTabEnable => Led?.Result == LedResult.SUCCESSFUL;
    private bool _projectsTabEnable => _offerTabEnable && Offer?.Result == OfferResult.SUCCESSFUL;
    #endregion

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await Prepair();
        }
    }

    public async Task Prepair()
    {
        Offer = Offer != null ? Offer : new OfferVM()
        {
            Led = new Led()
            {
                Result = LedResult.UNSUCCESSFUL
            }
        };

        if (Offer?.Led == null)
        {
            Offer.Led = new Led()
            {
                Result = LedResult.UNSUCCESSFUL
            };
        }

        var ledDto = Mapping.Mapper.Map<LedDto>(Offer.Led);
        Led = _mapper.Map<LedVM>(ledDto);

        await _getProjects();
        await TabMenuClick(0);
    }

    #region Led Tab
    private LedDetailed _ledCompoment;

    private void _onLedResultChanged((string Value, string Text) resultOption)
    {
        LedResult result = (LedResult)Enum.Parse(typeof(LedResult), resultOption.Value);
        Led.Result = result;
    }

    private async Task _saveLed()
    {
        _loading = true;

        var valid = _ledCompoment.Validate();
        Led = _ledCompoment.GetLed();

        if (valid)
        {
            var dto = _mapper.Map<LedDto>(Led);

            // Save Address
            // If Addres Then Save Address
            if (dto?.Address != null && !(await _dataProvider.Address.Any(a => a.PlaceId.Equals(dto.Address.PlaceId))))
            {
                var addressDto = Mapping.Mapper.Map<AddressDto>(dto.Address);
                var address = await _dataProvider.Address.Add(addressDto);
                dto.AddressId = address.Id;
            }
            else if (dto?.Address != null && (await _dataProvider.Address.Any(a => a.PlaceId.Equals(dto.Address.PlaceId))))
            {
                var address = await _dataProvider.Address.GetByPlaceId(dto.Address.PlaceId);
                dto.AddressId = address.Id;
            }

            dto.Offer = null;
            dto.Client = null;
            dto.Address = null;
            if (dto.OfferId == 0)
                dto.OfferId = null;

            // Save Led
            if (await _dataProvider.Leds.Any(p => p.Id == Led.Id))
            {
                var updated = await _dataProvider.Leds.Update(dto);
                Led = _mapper.Map<LedVM>(updated);
            }
            else
            {
                var updated = await _dataProvider.Leds.Add(dto);
                Led = _mapper.Map<LedVM>(updated);
            }
        }

        _loading = false;
    }
    #endregion

    #region Offer Tab
    private OfferDetailed _offerCompoment;

    private void _onOfferResultChanged((string Value, string Text) resultOption)
    {
        OfferResult result = (OfferResult)Enum.Parse(typeof(OfferResult), resultOption.Value);
        Offer.Result = result;
        StateHasChanged();
    }

    private async Task _saveOffer()
    {
        _loading = true;

        var valid = _offerCompoment.Validate();
        Offer = _offerCompoment.GetOffer();
        Offer.LedId = Led.Id;

        if (valid)
        {
            var dto = _mapper.Map<OfferDto>(Offer);

            dto.Led = null;
            dto.Type = null;
            dto.State = null;
            dto.Category = null;
            dto.SubCategory = null;

            // Save Offer
            if (await _dataProvider.Offers.Any(p => p.Id == Offer.Id))
            {
                var updated = await _dataProvider.Offers.Update(dto);
                Offer = _mapper.Map<OfferVM>(updated);
                Led.OfferId = Offer.Id;
                var offerDto = _mapper.Map<OfferDto>(Offer);
                Led.Offer = Mapping.Mapper.Map<Offer>(offerDto);
            }
            else
            {
                var updated = await _dataProvider.Offers.Add(dto);
                Offer = _mapper.Map<OfferVM>(updated);
                Led.OfferId = Offer.Id;
                var offerDto = _mapper.Map<OfferDto>(Offer);
                Led.Offer = Mapping.Mapper.Map<Offer>(offerDto);
            }
        }

        _loading = false;
    }
    #endregion

    #region Project Tab
    private ProjectDetailed _projectCompoment;
    private bool _loadingOnProject = false;
    private ProjectVM _project { get; set; }
    List<ProjectVM> _projects = new List<ProjectVM>();

    private async Task _addProject()
    {
        _loadingOnProject = true;
        var project = await _projectCompoment.SaveAsync();
        if (project != null)
            _projects.Add(project);
        _loadingOnProject = false;
    }

    private ProjectVM _getNewProject()
    {
        var offerDto = _mapper.Map<OfferDto>(Offer);
        var offerVm = Mapping.Mapper.Map<Offer>(offerDto);
        return new ProjectVM()
        {
            Offer = offerVm,
            OfferId = offerVm.Id
        };
    }

    private async Task _onProjectSelect(ProjectVM project)
    {
        _project = project;
        //await _projectCompoment.Prepair(project, true);
    }

    private async Task _saveProjects()
    {
        _loading = true;

        var valid = _projects.Count > 0;

        if (valid)
        {
            _projects.ForEach(p =>
            {
                p.Stage = null;
                p.ProjectManager = null;
                p.Offer = null;
            });
            var dtos = _mapper.Map<List<ProjectDto>>(_projects);

            // Save Projects
            List<ProjectVM> projects = new List<ProjectVM>();
            foreach (var dto in dtos)
            {
                ProjectVM project;
                if (await _dataProvider.Projects.Any(p => p.Id == dto.Id))
                {
                    var updated = await _dataProvider.Projects.Update(dto);
                    project = _mapper.Map<ProjectVM>(updated);
                }
                else
                {
                    var updated = await _dataProvider.Projects.Add(dto);
                    project = _mapper.Map<ProjectVM>(updated);
                }
                projects.Add(project);
            }

            _projects.Clear();
            _projects.AddRange(projects);
            _project = _getNewProject();
        }

        _loading = false;
    }

    private async Task _getProjects()
    {
        var dtos = await _dataProvider.Projects.GetOffersProjects(Offer?.Id);
        _projects = _mapper.Map<List<ProjectVM>>(dtos);
    }
    #endregion

    #region Tab Actions
    bool[] tabs = new bool[3];
    int _tabIndex = 0;
    int _prevTabIndex = 0;

    private async Task TabMenuClick(int tabIndex)
    {
        _loading = true;
        _tabIndex = tabIndex;

        for (int i = 0; i < tabs.Length; i++)
            if (tabs[i] == true)
                _prevTabIndex = i;

        // Led Tab
        if (tabIndex == 0)
        {
            for (int i = 0; i < tabs.Length; i++) { tabs[i] = false; }
            tabs[tabIndex] = true;

            StateHasChanged();
            await _ledCompoment.Prepair(Led, _prevTabIndex == 0);
        }

        // Offer Tab
        else if (tabIndex == 1)
        {
            // If prev tab was Led validate and save Led
            if (_prevTabIndex == 0)
            {
                bool validLed = _ledCompoment?.Validate() ?? false;
                if (validLed == false)
                {
                    _loading = false;
                    StateHasChanged();
                    return;
                }
                await _saveLed();
            }

            for (int i = 0; i < tabs.Length; i++) { tabs[i] = false; }
            tabs[tabIndex] = true;

            StateHasChanged();
            await _offerCompoment.Prepair(Offer, _prevTabIndex == 0);
        }

        // Project Tabs
        else if (tabIndex == 2)
        {
            // If prev tab was Offer validate and save Offer
            if (_prevTabIndex == 1)
            {
                bool validOffer = _offerCompoment?.Validate() ?? false;
                if (validOffer == false)
                {
                    _loading = false;
                    StateHasChanged();
                    return;
                }
                await _saveOffer();
            }

            for (int i = 0; i < tabs.Length; i++) { tabs[i] = false; }
            tabs[tabIndex] = true;

            StateHasChanged();
            if (_prevTabIndex == 1)
            {
                var project = _getNewProject();
                await _projectCompoment.Prepair(project);
            }
        }

        _loading = false;
        StateHasChanged();
    }
    #endregion
}
