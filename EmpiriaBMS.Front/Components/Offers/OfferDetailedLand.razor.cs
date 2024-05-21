using AutoMapper;
using EmpiriaBMS.Core;
using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Components.Admin.Projects.Contracts;
using EmpiriaBMS.Front.Components.Admin.Projects.Invoices;
using EmpiriaBMS.Front.Components.General;
using EmpiriaBMS.Front.Services;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Humanizer;
using Microsoft.AspNetCore.Components;

namespace EmpiriaBMS.Front.Components.Offers;

public partial class OfferDetailedLand : IDisposable
{
    private bool _isNew = true;
    private bool _loading = false;
    private bool _loadingOnInvoice = false;

    private OfferVM _offer;
    [Parameter]
    public OfferVM Offer
    {
        get => _offer;
        set
        {
            _offer = value;
            _isNew = _offer.Id == 0;
            if (_isNew)
            {
                _contract = new ContractVM();
                _project = new ProjectVM();
                _invoice = new InvoiceVM();
                _offerCompoment?.ResetValidation();
            }
            
            TabMenuClick(0);
        }
    }

    [Parameter]
    public ICollection<OfferTypeVM> Types { get; set; }

    [Parameter]
    public ICollection<OfferStateVM> States { get; set; }

    [Parameter]
    public ICollection<OfferResultVM> Results { get; set; }

    [Parameter]
    public EventCallback OnSave { get; set; }

    [Parameter]
    public EventCallback OnCansel { get; set; }

    private ContractVM _contract { get; set; } = new ContractVM();
    private ProjectVM _project { get; set; } = new ProjectVM();
    private InvoiceVM _invoice { get; set; } = new InvoiceVM();
    List<InvoiceVM> _invoices = new List<InvoiceVM>();

    private bool _contractTabEnable => Offer.ResultId == Results.FirstOrDefault(r => r.Name.Equals("SUCCESSFUL"))?.Id;

    #region Compoment Refrences
    private ProjectDetailed _projectCompoment;
    private OfferDetailed _offerCompoment;
    private InvoiceDetailed _invoiceCompoment;
    private ContractDetailed _contractCompoment;
    #endregion

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            if (_isNew)
            {
                _contract = new ContractVM();
                _project = new ProjectVM();
                _invoice = new InvoiceVM();
                _validOffer = true;
                _offerCompoment?.ResetValidation();
            }
            Offer.PropertyChanged += Offer_PropertyChanged;
            StateHasChanged();
        }
    }

    private void Offer_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        switch(e.PropertyName)
        {
            case nameof(Offer.ResultId):
                StateHasChanged();
                break;
        }
    }

    private async Task _close()
    {
        await OnSave.InvokeAsync();
    }

    private void _onInvoiceSelect(InvoiceVM invoice)
    {
        _invoice = invoice;
        StateHasChanged();
    }

    private async Task _addInvoice()
    {
        _loadingOnInvoice = true;
        var _validInvoice = _invoiceCompoment.Validate();
        if (_validInvoice)
        {
            await _upsertInvoice();
            _invoices.Add(_invoice);
            _invoice = new InvoiceVM();
        }
        _loadingOnInvoice = false;
    }

    #region Update Records
    private async Task _upsertProject()
    {
        if (_project is not null)
        {
            var dto = _mapper.Map<ProjectDto>(_project);    

            // If Addres Save Address
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

            // Remove Related Objects For DB Conflicts
            dto.Category = null;
            dto.Client = null;
            if (dto.ClientId == 0)
                dto.ClientId = null;
            dto.Stage = null;
            dto.Address = null;
            dto.ProjectManager = null;

            // Save Project
            ProjectDto updatedProject;
            if (_project.Id != 0 && await _dataProvider.Projects.Any(p => p.Id == _project.Id))
            {
                updatedProject = await _dataProvider.Projects.Update(dto);
            }
            else
            {
                updatedProject = await _dataProvider.Projects.Add(dto);
            }
            
            _project = _mapper.Map<ProjectVM>(updatedProject);
        }
    }
    
    private async Task _upsertOffer()
    {
        if (Offer is not null &&  _project != null && _project.Id != 0)
        {
            Offer.ProjectId = _project.Id;
            var dto = _mapper.Map<OfferDto>(Offer);
            // Save Offer
            OfferDto updatedOffer;
            if (await _dataProvider.Offers.Any(p => p.Id == Offer.Id))
            {
                updatedOffer = await _dataProvider.Offers.Update(dto);
            }
            else
            {
                updatedOffer = await _dataProvider.Offers.Add(dto);
            }

            Offer = _mapper.Map<OfferVM>(updatedOffer);
        }
    }

    private async Task _upsertInvoice()
    {
        if (_invoice is not null && _project != null && _project.Id != 0)
        {
            _invoice.ProjectId = _project.Id;
            var dto = _mapper.Map<InvoiceDto>(_invoice);
            // Save Invoice
            InvoiceDto updatedInvoice;
            if (await _dataProvider.Invoices.Any(p => p.Id == _invoice.Id))
            {
                updatedInvoice = await _dataProvider.Invoices.Update(dto);
            }
            else
            {
                updatedInvoice = await _dataProvider.Invoices.Add(dto);
            }

            _invoice = _mapper.Map<InvoiceVM>(updatedInvoice);
        }
    }

    private async Task _upsertContract()
    {
        if (_contract is not null && _invoice != null && _invoice.Id != 0)
        {
            _contract.InvoiceId = _invoice.Id;
            var dto = _mapper.Map<ContractDto>(_contract);
            // Save Contract
            ContractDto updatedContract;
            if (await _dataProvider.Invoices.Any(p => p.Id == _contract.Id))
            {
                updatedContract = await _dataProvider.Contracts.Update(dto);
            }
            else
            {
                updatedContract = await _dataProvider.Contracts.Add(dto);
            }

            _contract = _mapper.Map<ContractVM>(updatedContract);
        }
    }
    #endregion

    #region Tab Actions
    bool[] tabs = new bool[5];

    private async Task TabMenuClick(int tabIndex)
    {
        _loading = true;

        if (tabIndex == 0) // Invoice Tab
        {
            var _validOffer = _offerCompoment?.Validate();
            for (int i = 0; i < tabs.Length; i++) { tabs[i] = false; }
            tabs[tabIndex] = true;
            StateHasChanged();
        }

        if (tabIndex == 1) // Project Tabs
        {
            var _validOffer = _offerCompoment.Validate();
            if (_validOffer)
            {
                if (_projectCompoment != null)
                    await _projectCompoment.Prepair();
                if (Offer.ProjectId != null && Offer.ProjectId != 0)
                {
                    var project = await _dataProvider.Projects.Get((int)Offer.ProjectId);
                    _project = _mapper.Map<ProjectVM>(project);
                }

                for (int i = 0; i < tabs.Length; i++) { tabs[i] = false; }
                tabs[tabIndex] = true;
            }
            StateHasChanged();
        }

        if (tabIndex == 2) // Invoice Tab
        {
            var _validProject = _projectCompoment.Validate();
            if (_validProject)
            {
                _project = _projectCompoment.GetProject();
                // If Project Valid Save Project And Offer
                await _upsertProject();
                await _upsertOffer();

                if (_invoiceCompoment != null)
                    await _invoiceCompoment.Prepair();
                if (_project != null)
                {
                    var invoicesDtos = Mapping.Mapper.Map<List<InvoiceDto>>(_project.Invoices);
                    _invoices = _mapper.Map<List<InvoiceVM>>(invoicesDtos);
                    if (_invoices != null && _invoices.Count > 0)
                    {
                        _invoice = _invoices.FirstOrDefault();
                    }
                    _invoice.ProjectId = _project.Id;
                    _invoice.Project = _project;

                    _invoice.TypeId = _invoice.TypeId;
                    _invoice.Type = _invoice.Type;
                }
                for (int i = 0; i < tabs.Length; i++) { tabs[i] = false; }
                tabs[tabIndex] = true;
                StateHasChanged();
            }
        }

        if (tabIndex == 3) // Contract Tab
        {
            var _validInvoice = _invoiceCompoment.Validate();
            if (_validInvoice && _invoices.Count > 0)
            {
                if (_invoice.ContractId != 0)
                {
                    var contract = await _dataProvider.Contracts.Get(_invoice.ContractId);
                    if (contract != null)
                        _contract = _mapper.Map<ContractVM>(contract);
                    else
                        _contract = new ContractVM()
                        {
                            InvoiceId = _invoice.Id,
                            Invoice = _invoice,
                            Date = DateTime.Now,
                        };
                }
                else
                {
                    _contract = new ContractVM()
                    {
                        InvoiceId = _invoice.Id,
                        Invoice = _invoice,
                        Date = DateTime.Now,
                    };
                }

                for (int i = 0; i < tabs.Length; i++) { tabs[i] = false; }
                tabs[tabIndex] = true;
                StateHasChanged();
            }
        }

        if (tabIndex == 4) // Ready!
        {
            var _validContract = _contractCompoment.Validate();
            if (_validContract)
            {
                

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

    #region Disable Pattern
    private bool disposedValue;
    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                Offer.PropertyChanged -= Offer_PropertyChanged;
            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
    #endregion
}
