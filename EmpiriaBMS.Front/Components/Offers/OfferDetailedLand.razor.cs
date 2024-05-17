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
            _contract = new ContractVM();
            _project = new ProjectVM();
            _invoice = new InvoiceVM();
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

    public async Task PrepairForAdd()
    {
        _isNew = true;
        _contract = new ContractVM();
        _project = new ProjectVM();
        _invoice = new InvoiceVM();
        Offer = new OfferVM();
        _validOffer = true;
        Offer.PropertyChanged += Offer_PropertyChanged;
        await TabMenuClick(0);
        _offerCompoment?.ResetValidation();
        StateHasChanged();
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

    private void _addInvoice()
    {
        _invoice = new InvoiceVM()
        {
            ProjectId = _project.Id,
            Project = _project,
        };
        _invoices.Add(_invoice);
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
                if (Offer.ProjectId != null && Offer.ProjectId != 0)
                {
                    var project = await _dataProvider.Projects.Get((int)Offer.ProjectId);
                    _project = _mapper.Map<ProjectVM>(project);
                    _projectCompoment.PrepairForEdit();
                }
                else
                {
                    _project = new ProjectVM();
                }

                for (int i = 0; i < tabs.Length; i++) { tabs[i] = false; }
                tabs[tabIndex] = true;
            }
            StateHasChanged();
        }

        if (tabIndex == 2) // Invoice Tab
        {
            if (_project.Id != 0)
            {
                var invoices = await _dataProvider.Projects.GetInvoices(_project.Id);
                if (invoices != null && invoices.Count > 0)
                {
                    _invoices = _mapper.Map<List<InvoiceVM>>(invoices);
                    _invoice = _invoices.FirstOrDefault();
                }
            }

            for (int i = 0; i < tabs.Length; i++) { tabs[i] = false; }
            tabs[tabIndex] = true;
            StateHasChanged();
        }

        if (tabIndex == 3) // Contract Tab
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
