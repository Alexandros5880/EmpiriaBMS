using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;

namespace EmpiriaBMS.Front.ViewModel.Components;

public class PaymentVM : BaseVM
{
    private DateTime? _estimatedDate;
    public DateTime? EstimatedDate
    {
        get => _estimatedDate;
        set
        {
            if (value == _estimatedDate)
                return;
            _estimatedDate = value;
            NotifyPropertyChanged(nameof(EstimatedDate));
        }
    }

    private DateTime _paymentDate;
    public DateTime PaymentDate
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

    private double _paidFee;
    public double PaidFee
    {
        get => _paidFee;
        set
        {
            if (value == _paidFee)
                return;
            _paidFee = value;
            NotifyPropertyChanged(nameof(PaidFee));
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

    private int _typeId { get; set; }
    public int TypeId
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

    private int _invoiceId { get; set; }
    public int InvoiceId
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

    public PaymentVM() { }

    public PaymentVM(PaymentVM payment)
    {
        EstimatedDate = payment.EstimatedDate;
        PaymentDate = payment.PaymentDate;
        PaidFee = payment.PaidFee;
        Fee = payment.Fee;
        Bank = payment.Bank;
        TypeId = payment.TypeId;
        Type = payment.Type;
        InvoiceId = payment.InvoiceId;
        Invoice = payment.Invoice;
    }

}
