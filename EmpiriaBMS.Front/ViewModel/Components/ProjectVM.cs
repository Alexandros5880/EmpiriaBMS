using EmpiriaMS.Models.Enums;
using EmpiriaMS.Models.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.ViewModel.Components;
public class ProjectVM : BNotifyPropertyChanged
{
    private string? _name;
    public string? Name
    {
        get => _name;
        set
        {
            _name = value;
            NotifyPropertyChanged(nameof(Name));
        }
    }

    private string _description;
    public string? Description
    {
        get => _description;
        set
        {
            _description = value;
            NotifyPropertyChanged(nameof(Description));
        }
    }

    private string? _code;
    public string? Code
    {
        get => _code;
        set
        {
            _code = value;
            NotifyPropertyChanged(nameof(Code));
        }
    }

    private string? _drawing;
    public string? Drawing
    {
        get => _drawing;
        set
        {
            _drawing = value;
            NotifyPropertyChanged(nameof(Drawing));
        }
    }

    private PlanType _planType;
    public PlanType PlanType
    {
        get => _planType;
        set
        {
            _planType = value;
            NotifyPropertyChanged(nameof(PlanType));
        }
    }

    private int? _workingDays;
    public int? WorkingDays
    {
        get => _workingDays;
        set
        {
            _workingDays = value;
            NotifyPropertyChanged(nameof(WorkingDays));
        }
    }

    private DateTime? _durationDate;
    public DateTime? DurationDate
    {
        get => _durationDate;
        set
        {
            _durationDate = value;
            NotifyPropertyChanged(nameof(DurationDate));
        }
    }

    private DateTime? _estPaymentDate;
    public DateTime? EstPaymentDate
    {
        get => _estPaymentDate;
        set
        {
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
            _paymentDate = value;
            NotifyPropertyChanged(nameof(PaymentDate));
        }
    }

    private int? delayInPayment;
    public int? DelayInPayment
    {
        get => delayInPayment;
        set
        {
            delayInPayment = value;
            NotifyPropertyChanged(nameof(DelayInPayment));
        }
    }

    private string? _paymentDetailes;
    public string? PaymentDetailes
    {
        get => _paymentDetailes;
        set
        {
            _paymentDetailes = value;
            NotifyPropertyChanged(nameof(PaymentDetailes));
        }
    }

    private double? _dayCost;
    public double? DayCost
    {
        get => _dayCost;
        set
        {
            _dayCost = value;
            NotifyPropertyChanged(nameof(DayCost));
        }
    }

    private string? _bank;
    public string? Bank
    {
        get => _bank;
        set
        {
            _bank = value;
            NotifyPropertyChanged(nameof(Bank));
        }
    }

    private double? _paidFee;
    public double? PaidFee
    {
        get => _paidFee;
        set
        {
            _paidFee = value;
            NotifyPropertyChanged(nameof(PaidFee));
        }
    }

    private int? _daysUntilPayment;
    public int? DaysUntilPayment
    {
        get => _daysUntilPayment;
        set
        {
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
            _pendingPayments = value;
            NotifyPropertyChanged(nameof(PendingPayments));
        }
    }

    private int? _calculationDaly;
    public int? CalculationDaly
    {
        get => _calculationDaly;
        set
        {
            _calculationDaly = value;
            NotifyPropertyChanged(nameof(CalculationDaly));
        }
    }

    private int? _completed;
    public int? Completed
    {
        get => _completed;
        set
        {
            _completed = value;
            NotifyPropertyChanged(nameof(Completed));
        }
    }

    private int? _manHours;
    public int? ManHours
    {
        get => _manHours;
        set
        {
            _manHours = value;
            NotifyPropertyChanged(nameof(ManHours));
        }
    }

    private string? _customerId;
    public string? CustomerId
    {
        get => _customerId;
        set
        {
            _customerId = value;
            NotifyPropertyChanged(nameof(CustomerId));
        }
    }

    private Customer? _customer;
    public Customer? Customer
    {
        get => _customer;
        set
        {
            _customer = value;
            NotifyPropertyChanged(nameof(Customer));
        }
    }

    private string? _invoiceId;
    public string? InvoiceId
    {
        get => _invoiceId;
        set
        {
            _invoiceId = value;
            NotifyPropertyChanged(nameof(InvoiceId));
        }
    }

    private Invoice? _invoice;
    public Invoice? Invoice
    {
        get => _invoice;
        set
        {
            _invoice = value;
            NotifyPropertyChanged(nameof(Invoice));
        }
    }

    public ICollection<EmployeeVM>? Employees { get; set; }

}