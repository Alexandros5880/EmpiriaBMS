using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using Microsoft.IdentityModel.Tokens;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.Admin.Projects.Payments;

public partial class PaymentDetailedDialog : IDialogContentComponent<PaymentParameter>
{
    private PaymentParameter _content;
    [Parameter]
    public PaymentParameter Content
    {
        get => _content;
        set
        {
            _content = value;
            Payment = value.Content;
            _displayInvoiceSelection = value.DisplayInvoiceSelection;
        }
    }

    [CascadingParameter]
    public FluentDialog Dialog { get; set; } = default!;

    private PaymentVM Payment;
    private bool _displayInvoiceSelection = true;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _getRecords();

            if (Payment.Invoice != null)
            {
                var invoiceDto = Mapping.Mapper.Map<InvoiceDto>(Payment.Invoice);
                Invoice = _mapper.Map<InvoiceVM>(invoiceDto);
            }

            if (Payment.Type != null)
            {
                var typeDto = Mapping.Mapper.Map<PaymentTypeDto>(Payment.Type);
                Type = _mapper.Map<PaymentTypeVM>(typeDto);
            }

            StateHasChanged();
        }
    }

    private async Task SaveAsync()
    {
        var valid = Validate();
        if (!valid) return;

        await Dialog.CloseAsync(Payment);
    }

    private async Task CancelAsync()
    {
        await Dialog.CancelAsync();
    }

    #region Validation
    private bool validType = true;
    private bool validInvoice = true;
    private bool validFee = true;

    private bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validType = Payment.TypeId != 0;
            validInvoice = Payment.InvoiceId != 0;
            validFee = Payment.Fee > 0;

            return validType && validInvoice && validFee;
        }
        else
        {
            validType = true;
            validInvoice = true;
            validFee = true;

            switch (fieldname)
            {
                case "Type":
                    validType = Payment.TypeId != 0;
                    return validType;
                case "Invoice":
                    validInvoice = Payment.InvoiceId != 0;
                    return validInvoice;
                case "Fee":
                    validFee = Payment.Fee > 0;
                    return validFee;
                default:
                    return true;
            }

        }
    }
    #endregion

    #region Get Related Records
    ObservableCollection<InvoiceVM> _invoices = new ObservableCollection<InvoiceVM>();
    ObservableCollection<PaymentTypeVM> _types = new ObservableCollection<PaymentTypeVM>();

    private InvoiceVM _invoice = new InvoiceVM();
    public InvoiceVM Invoice
    {
        get => _invoice;
        set
        {
            if (_invoice == value || value == null) return;
            _invoice = value;
            Payment.InvoiceId = _invoice.Id;
        }
    }

    private PaymentTypeVM _type = new PaymentTypeVM();
    public PaymentTypeVM Type
    {
        get => _type;
        set
        {
            if (_type == value || value == null) return;
            _type = value;
            Payment.TypeId = _type.Id;
        }
    }

    private async Task _getRecords()
    {
        await _getInvoices();
        await _getTypes();
    }

    private async Task _getInvoices()
    {
        var dtos = await _dataProvider.Invoices.GetAll();
        var vms = _mapper.Map<List<InvoiceVM>>(dtos);
        _invoices.Clear();
        vms.ForEach(_invoices.Add);
    }

    private async Task _getTypes()
    {
        var dtos = await _dataProvider.PaymentTypes.GetAll();
        var vms = _mapper.Map<List<PaymentTypeVM>>(dtos);
        _types.Clear();
        vms.ForEach(_types.Add);
    }
    #endregion
}