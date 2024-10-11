using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Front.ViewModel.Components;

public class PaymentVM : BaseVM
{
    private DateTime? _paymentDate;
    public DateTime? PaymentDate
    {
        get => _paymentDate;
        set
        {
            if (value == _paymentDate)
                return;
            _paymentDate = value;
            NotifyPropertyChanged(nameof(PaymentDate));
        }
    }

    private string _bank;
    public string Bank
    {
        get => _bank;
        set
        {
            if (value == _bank)
                return;
            _bank = value;
            NotifyPropertyChanged(nameof(Bank));
        }
    }

    private double _fee;
    public double Fee
    {
        get => _fee;
        set
        {
            if (value == _fee)
                return;
            _fee = value;
            NotifyPropertyChanged(nameof(Fee));
        }
    }

    private string _description;
    public string Description
    {
        get => _description;
        set
        {
            if (value == _description)
                return;
            _description = value;
            NotifyPropertyChanged(nameof(Description));
        }
    }

    private long _typeId { get; set; }
    public long TypeId
    {
        get => _typeId;
        set
        {
            if (value == _typeId)
                return;
            _typeId = value;
            NotifyPropertyChanged(nameof(TypeId));
        }
    }

    private PaymentType _type { get; set; }
    public PaymentType Type
    {
        get => _type;
        set
        {
            if (value == _type)
                return;
            _type = value;
            NotifyPropertyChanged(nameof(Type));
        }
    }

    public string TypeName => Type != null ? Type.Name : "";

    private long _invoiceId { get; set; }
    public long InvoiceId
    {
        get => _invoiceId;
        set
        {
            if (value == _invoiceId)
                return;
            _invoiceId = value;
            NotifyPropertyChanged(nameof(InvoiceId));
        }
    }

    private Invoice _invoice { get; set; }
    public Invoice Invoice
    {
        get => _invoice;
        set
        {
            if (value == _invoice)
                return;
            _invoice = value;
            NotifyPropertyChanged(nameof(Invoice));
        }
    }

    public string ProjectName => Invoice?.Project?.Name ?? "";
    public string InvoiceTypeName => Invoice?.Type?.Name ?? "";

    public PaymentVM() { }

    public PaymentVM(PaymentVM payment)
    {
        PaymentDate = payment.PaymentDate;
        Fee = payment.Fee;
        Bank = payment.Bank;
        TypeId = payment.TypeId;
        Type = payment.Type;
        InvoiceId = payment.InvoiceId;
        Invoice = payment.Invoice;
    }

}
