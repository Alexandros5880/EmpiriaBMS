using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Components.Admin.Invoices;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Enum;
using Microsoft.AspNetCore.Components;

namespace EmpiriaBMS.Front.Components.Offers;

public partial class OfferCreationWizzard
{
    private bool _isNew => Offer?.Id == 0;
    private bool _loading = false;
    private bool _loadingOnInvoice = false;

    [Parameter]
    public OfferVM Offer { get; set; } = default!;

    [Parameter]
    public EventCallback OnSave { get; set; }

    [Parameter]
    public EventCallback OnCansel { get; set; }

    private ProjectVM _project { get; set; }
    private InvoiceVM _invoice { get; set; }
    List<InvoiceVM> _invoices = new List<InvoiceVM>();
    private ContractVM _contract { get; set; }

    private bool _contractTabEnable => Offer?.Result == OfferResult.SUCCESSFUL;

    #region Compoment Refrences
    private ProjectDetailed _projectCompoment;
    private OfferDetailed _offerCompoment;
    private InvoiceDetailed _invoiceCompoment;
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
        };
        await _getProject();
        _getInvoice();
        await TabMenuClick(0);
    }

    private async Task _close()
    {
        if (_invoices.Count > 0)
            await OnSave.InvokeAsync();
    }

    private async Task _onInvoiceSelect(InvoiceVM invoice)
    {
        _invoice = invoice;
        _contract = _invoice.Contract;
        await _invoiceCompoment.Prepair(invoice, true);
    }

    private async Task _addInvoice()
    {
        _loadingOnInvoice = true;
        var invoice = await _invoiceCompoment.Save();
        if (invoice != null)
            _invoices.Add(invoice);
        _loadingOnInvoice = false;
    }

    private async Task _saveBase()
    {
        // Update Project
        var projectUpdated = await _upsertProject(_project);
        if (projectUpdated == null)
            return;
        var projectDto = _mapper.Map<ProjectDto>(projectUpdated);

        // Update Offer
        var offerUpdated = await _upsertOffer(Offer);
        if (offerUpdated == null)
            return;
        Offer = offerUpdated;

        // Update Offer Related Project
        _project = projectUpdated;
    }

    #region Update Records
    private async Task<ProjectVM> _upsertProject(ProjectVM project)
    {
        if (project is not null)
        {
            var p = project.Clone() as ProjectVM;
            var dto = _mapper.Map<ProjectDto>(p);

            // Remove Related Objects For DB Conflicts
            dto.Category = null;
            dto.Stage = null;
            dto.ProjectManager = null;

            // Save Project
            if (_project.Id != 0 && await _dataProvider.Projects.Any(p => p.Id == _project.Id))
            {
                ProjectDto updated = await _dataProvider.Projects.Update(dto);
                if (updated != null)
                    return _mapper.Map<ProjectVM>(updated);
                else
                    return null;
            }
            else
            {
                ProjectDto updated = await _dataProvider.Projects.Add(dto);
                if (updated != null)
                    return _mapper.Map<ProjectVM>(updated);
                else
                    return null;
            }
        }
        else
            return null;
    }
    
    private async Task<OfferVM> _upsertOffer(OfferVM offer)
    {
        if (offer is not null)
        {
            var obj = offer.Clone() as OfferVM;
            var dto = _mapper.Map<OfferDto>(obj);
            dto.Type = null;
            dto.State = null;
            dto.Result = OfferResult.WAITING;
            // Save Offer
            if (await _dataProvider.Offers.Any(p => p.Id == offer.Id))
            {
                OfferDto updatedOffer = await _dataProvider.Offers.Update(dto);
                if (updatedOffer != null)
                    return _mapper.Map<OfferVM>(updatedOffer);
                else
                    return null;
            }
            else
            {
                OfferDto updatedOffer = await _dataProvider.Offers.Add(dto);
                if (updatedOffer != null)
                    return _mapper.Map<OfferVM>(updatedOffer);
                else
                    return null;
            }
        }
        else
            return null;
    }
    #endregion

    #region Tab Actions
    bool[] tabs = new bool[4];

    private async Task TabMenuClick(int tabIndex)
    {
        _loading = true;

        // Offer Tab
        if (tabIndex == 0)
        {
            var _validOffer = _offerCompoment?.Validate();
            for (int i = 0; i < tabs.Length; i++) { tabs[i] = false; }
            tabs[tabIndex] = true;
            var offer = Offer;
            StateHasChanged();
        }

        // Project Tabs
        if (tabIndex == 1)
        {
            if (_offerCompoment != null && _offerCompoment.Validate())
            {
                if (_projectCompoment != null)
                    await _projectCompoment.Prepair();


                for (int i = 0; i < tabs.Length; i++) { tabs[i] = false; }
                tabs[tabIndex] = true;
            }
            StateHasChanged();
        }

        // Invoice Tab
        if (tabIndex == 2)
        {
            if (_projectCompoment != null && _projectCompoment.Validate() || !_isNew)
            {
                if (_projectCompoment != null)
                    _project = _projectCompoment.GetProject();

                await _saveBase();

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
                for (int i = 0; i < tabs.Length; i++) { tabs[i] = false; }
                tabs[tabIndex] = true;
                StateHasChanged();
            }
        }

        _loading = false;
    }
    #endregion

    #region Validation
    private bool _validOffer;
    #endregion

    #region Get Related Records
    private async Task _getProject()
    {
        //if (Offer?.Project != null)
        //{
        //    var dto = Mapping.Mapper.Map<ProjectDto>(Offer.Project);
        //    _project = _mapper.Map<ProjectVM>(dto);
        //}
        //else if (Offer?.ProjectId != 0 && Offer?.ProjectId != null)
        //{
        //    var dto = await _dataProvider.Projects.Get((int)Offer.ProjectId);
        //    _project = _mapper.Map<ProjectVM>(dto);
        //}
        //else
        //{
        //    _project = new ProjectVM();
        //}
    }

    private void _getInvoice()
    {
        if (_project != null && _project?.Invoices != null ? _project?.Invoices.Count > 0 : false)
        {
            var inv = _project.Invoices.FirstOrDefault();
            var dto = Mapping.Mapper.Map<InvoiceDto>(inv);
            _invoice = _mapper.Map<InvoiceVM>(dto);
            _contract = _invoice.Contract;
        } else
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
