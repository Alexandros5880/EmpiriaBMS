using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;

namespace EmpiriaBMS.Front.ViewModel.Components;

public class PaymentVM : BaseValidator
{
    private DateTime? _estPaymentDate;
    public DateTime? EstPaymentDate
    {
        get => _estPaymentDate;
        set
        {
            if (value == _estPaymentDate)
                return;
            _estPaymentDate = value;
            NotifyPropertyChanged(nameof(EstPaymentDate));
        }
    }

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

    private int? _delayInPayment;
    public int? DelayInPayment
    {
        get => _delayInPayment;
        set
        {
            if (value == _delayInPayment)
                return;
            _delayInPayment = value;
            NotifyPropertyChanged(nameof(DelayInPayment));
        }
    }

    private string _paymentDetails;
    public string PaymentDetails
    {
        get => _paymentDetails;
        set
        {
            if (value == _paymentDetails)
                return;
            _paymentDetails = value;
            NotifyPropertyChanged(nameof(PaymentDetails));
        }
    }

    private double? _dayCost;
    public double? DayCost
    {
        get => _dayCost;
        set
        {
            if (value == _dayCost)
                return;
            _dayCost = value;
            NotifyPropertyChanged(nameof(DayCost));
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

    private int? _daysUntilPayment;
    public int? DaysUntilPayment
    {
        get => _daysUntilPayment;
        set
        {
            if (value == _daysUntilPayment)
                return;
            _daysUntilPayment = value;
            NotifyPropertyChanged(nameof(DaysUntilPayment));
        }
    }

    private double? _pendingPayments;
    public double? PendingPayments
    {
        get => _pendingPayments;
        set
        {
            if (value == _pendingPayments)
                return;
            _pendingPayments = value;
            NotifyPropertyChanged(nameof(PendingPayments));
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

    public PaymentVM()
    {
        EstPaymentDate = DateTime.Now;
        PaymentDate = DateTime.Now;
    }

    public PaymentVM(PaymentVM payment)
    {
        EstPaymentDate = payment.EstPaymentDate;
        PaymentDate = payment.PaymentDate;
        DelayInPayment = payment.DelayInPayment;
        PaymentDetails = payment.PaymentDetails;
        DayCost = payment.DayCost;
        Bank = payment.Bank;
        DaysUntilPayment = payment.DaysUntilPayment;
        PendingPayments = payment.PendingPayments;
        TypeId = payment.TypeId;
        Type = null;
        InvoiceId = payment.InvoiceId;
        Invoice = null;
    }

}
