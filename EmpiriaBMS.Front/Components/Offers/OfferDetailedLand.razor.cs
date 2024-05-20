using AutoMapper;
using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Components.Admin.Projects.Invoices;
using EmpiriaBMS.Front.Components.General;
using EmpiriaBMS.Front.Services;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;

namespace EmpiriaBMS.Front.Components.Offers;

public partial class OfferDetailedLand : IDisposable
{
    private bool _isNew = true;
    private bool _loading = false;

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

    private async Task _contractSave()
    {
        _loading = true;
        // TODO: Save Contract
        await Task.Delay(1000);
        _loading = false;
    }

    #region Tab Actions
    bool[] tabs = new bool[5];

    private async Task TabMenuClick(int tabIndex)
    {

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
            var _valiProject = _projectCompoment.Validate();
            if (_valiProject)
            {
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
            var _valiInvoice = _invoiceCompoment.Validate();
            if (_valiInvoice)
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
