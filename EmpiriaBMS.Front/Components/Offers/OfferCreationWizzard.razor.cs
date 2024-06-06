using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Components.Admin.Invoices;
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
    private bool _invoiceTabEnable => _offerTabEnable && _projectsTabEnable && _projects.Count > 0;
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
            Date = DateTime.Now,
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
        _getInvoice();
        await TabMenuClick(0);
    }

    private async Task _close()
    {
        if (_invoices.Count > 0)
            await OnSave.InvokeAsync();
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
            }
            else
            {
                var updated = await _dataProvider.Offers.Add(dto);
                Offer = _mapper.Map<OfferVM>(updated);
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
    #endregion

    #region Invoices Tab
    private InvoiceDetailed _invoiceCompoment;
    private bool _loadingOnInvoice = false;
    private InvoiceVM _invoice { get; set; }
    List<InvoiceVM> _invoices = new List<InvoiceVM>();
    private ContractVM _contract { get; set; }

    private async Task _onInvoiceSelect(InvoiceVM invoice)
    {
        _invoice = invoice;
        _contract = _invoice.Contract;
        await _invoiceCompoment.Prepair();
    }

    private async Task _addInvoice()
    {
        _loadingOnInvoice = true;
        var invoice = await _invoiceCompoment.Save();
        if (invoice != null)
            _invoices.Add(invoice);
        _loadingOnInvoice = false;
    }
    #endregion

    #region Tab Actions
    bool[] tabs = new bool[4];
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
            if (_prevTabIndex == 0)
                await _ledCompoment.Prepair(Led);
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
            if (_prevTabIndex == 0)
                await _offerCompoment.Prepair(Offer);
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
                await _saveLed();
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

        // Invoice Tab
        else if (tabIndex == 3)
        {
            if (_prevTabIndex < 3)
            {
                await _saveProjects();

                if (_projectCompoment != null)
                    _project = _projectCompoment.GetProject();

                if (_invoiceCompoment != null)
                    await _invoiceCompoment.Prepair();
                if (_project != null)
                {
                    var invoicesDtos = await _dataProvider.Projects.GetInvoices(_project.Id);
                    _invoices = _mapper.Map<List<InvoiceVM>>(invoicesDtos);
                    if (_invoices != null && _invoices.Count > 0)
                    {
                        _invoice = _invoices.FirstOrDefault();
                    }
                    _invoice.ProjectId = _project.Id;
                    _invoice.Project = _project;

                    _invoice.TypeId = _invoice.TypeId;
                    _invoice.Type = _invoice.Type;

                    if (_invoice.Contract == null && _invoice.ContractId == 0)
                    {
                        _invoice.Contract = new ContractVM()
                        {
                            InvoiceId = _invoice.Id,
                            Invoice = _invoice,
                            Date = DateTime.Now,
                        };
                    }
                }
            }

            for (int i = 0; i < tabs.Length; i++) { tabs[i] = false; }
            tabs[tabIndex] = true;
        }

        _loading = false;
        StateHasChanged();
    }
    #endregion

    #region Validation
    private bool _validOffer;
    #endregion

    #region Get Related Records
    private async Task _getProjects()
    {
        var dtos = await _dataProvider.Projects.GetOffersProjects(Offer?.Id);

        //_project = _mapper.Map<ProjectVM>(dto);
    }

    private void _getInvoice()
    {
        if (_project != null && _project?.Invoices != null ? _project?.Invoices.Count > 0 : false)
        {
            var inv = _project.Invoices.FirstOrDefault();
            var dto = Mapping.Mapper.Map<InvoiceDto>(inv);
            _invoice = _mapper.Map<InvoiceVM>(dto);
            _contract = _invoice.Contract;
        }
        else
        {
            _contract = new ContractVM()
            {
                Date = DateTime.Now,
            };
            _invoice = new InvoiceVM()
            {
                Contract = _contract,
            };
            _contract.InvoiceId = _invoice.Id;
            _contract.Invoice = _invoice;
        }
    }
    #endregion
}
