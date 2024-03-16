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

    private long _estimatedMandays;
    public long EstimatedMandays
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

    private long _estimatedHours;
    public long EstimatedHours
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

    private float _estimatedCompleted;
    public float EstimatedCompleted
    {
        get => _estimatedCompleted;
        set
        {
            if (value == _estimatedCompleted)
                return;
            _estimatedCompleted = value;
            NotifyPropertyChanged(nameof(EstimatedCompleted));
        }
    }

    private float _completed;
    public float Completed
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

    private float _workPackegedCompleted;
    public float WorkPackegedCompleted
    {
        get => _workPackegedCompleted;
        set
        {
            if (value == _workPackegedCompleted)
                return;
            _workPackegedCompleted = value;
            NotifyPropertyChanged(nameof(WorkPackegedCompleted));
        }
    }

    private bool _active;
    public bool Active
    {
        get => _active;
        set
        {
            if (value == _active)
                return;
            _active = value;
            NotifyPropertyChanged(nameof(Active));
        }
    }

    private DateTime? _deadLine;
    public DateTime? DeadLine
    {
        get => _deadLine;
        set
        {
            if (value == _deadLine)
                return;
            _deadLine = value;
            NotifyPropertyChanged(nameof(DeadLine));
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

    private DateTime? _workPackege;
    public DateTime? WorkPackege
    {
        get => _workPackege;
        set
        {
            if (value == _workPackege)
                return;
            _workPackege = value;
            NotifyPropertyChanged(nameof(WorkPackege));
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

    private ProjectType _type;
    public ProjectType Type
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

    private User? _subContractor;
    public User? SubContractor
    {
        get => _subContractor;
        set
        {
            if (value == _subContractor)
                return;
            _subContractor = value;
            NotifyPropertyChanged(nameof(SubContractor));
        }
    }

    private User? _projectManager;
    public User? ProjectManager
    {
        get => _projectManager;
        set
        {
            if (value == _projectManager)
                return;
            _projectManager = value;
            NotifyPropertyChanged(nameof(ProjectManager));
        }
    }

    private string? _pmName;
    public string? PmName
    {
        get => _pmName;
        set
        {
            if (value == _pmName)
                return;
            _pmName = value;
            NotifyPropertyChanged(nameof(PmName));
        }
    }

    public List<Project> Projects { get; set; }

    [NotMapped]
    public string DeadlineDisplay => $"{DeadLine.Value.Day}/{DeadLine.Value.Month}/{DeadLine.Value.Year}";

    public ProjectVM()
    {
        DurationDate = DateTime.Now.AddYears(1);
        EstPaymentDate = DateTime.Now.AddYears(1);
        PaymentDate = DateTime.Now.AddYears(1);
    }
}