using EmpiriaMS.Models.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using EmpiriaBMS.Models.Models;
using EmpiriaBMS.Front.ViewModel.Components.Base;

namespace EmpiriaBMS.Front.ViewModel.Components;
public class ProjectVM : BaseVM
{
    private string? _name;
    public string? Name
    {
        get => _name;
        set
        {
            if (value == _name)
                return;
            _name = value;
            NotifyPropertyChanged(nameof(Name));
        }
    }

    private string? _description;
    public string? Description
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

    private string? _code;
    public string? Code
    {
        get => _code;
        set
        {
            if (value == _code)
                return;
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
            if (value == _drawing)
                return;
            _drawing = value;
            NotifyPropertyChanged(nameof(Drawing));
        }
    }

    private long? _estimatedMandays;
    public long? EstimatedMandays
    {
        get => _estimatedMandays;
        set
        {
            if (value == _estimatedMandays)
                return;
            _estimatedMandays = value;
            NotifyPropertyChanged(nameof(EstimatedMandays));
        }
    }

    private long? _estimatedHours;
    public long? EstimatedHours
    {
        get => _estimatedHours;
        set
        {
            if (value == _estimatedHours)
                return;
            _estimatedHours = value;
            NotifyPropertyChanged(nameof(_estimatedHours));
        }
    }

    private DateTime? _durationDate;
    public DateTime? DurationDate
    {
        get => _durationDate;
        set
        {
            if (value == _durationDate)
                return;
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

    private string? _paymentDetailes;
    public string? PaymentDetailes
    {
        get => _paymentDetailes;
        set
        {
            if (value == _paymentDetailes)
                return;
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
            if (value == _dayCost)
                return;
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
            if (value == _bank)
                return;
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
            if (value == _paidFee)
                return;
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

    private int? _calculationDaly;
    public int? CalculationDaly
    {
        get => _calculationDaly;
        set
        {
            if (value == _calculationDaly)
                return;
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
            if (value == _completed)
                return;
            _completed = value;
            NotifyPropertyChanged(nameof(Completed));
        }
    }

    private long? _manHours;
    public long? ManHours
    {
        get => _manHours;
        set
        {
            if (value == _manHours)
                return;
            _manHours = value;
            NotifyPropertyChanged(nameof(ManHours));
        }
    }

    private User? _customer;
    public User? Customer
    {
        get => _customer;
        set
        {
            if (value == _customer)
                return;
            _customer = value;
            NotifyPropertyChanged(nameof(Customer));
        }
    }

    private Invoice? _invoice;
    public Invoice? Invoice
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

    public ProjectVM()
    {
        DurationDate = DateTime.Now.AddYears(1);
        EstPaymentDate = DateTime.Now.AddYears(1);
        PaymentDate = DateTime.Now.AddYears(1);
    }
}