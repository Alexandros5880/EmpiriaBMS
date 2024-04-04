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
            NotifyPropertyChanged(nameof(EstimatedHours));
        }
    }

    private double? _fee;
    public double? Fee
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

    private int? _typeId;
    public int? TypeId
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

    private int? _projectId;
    public int? ProjectId
    {
        get => _projectId;
        set
        {
            if (value == _projectId)
                return;
            _projectId = value;
            NotifyPropertyChanged(nameof(ProjectId));
        }
    }

    private Project _project;
    public Project Project
    {
        get => _project;
        set
        {
            if (value == _project)
                return;
            _project = value;
            NotifyPropertyChanged(nameof(Project));
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

    private float _workPackegedDeclaredCompleted;
    public float WorkPackegedDeclaredCompleted
    {
        get => _workPackegedDeclaredCompleted;
        set
        {
            if (value == _workPackegedDeclaredCompleted)
                return;
            _workPackegedDeclaredCompleted = value;
            NotifyPropertyChanged(nameof(WorkPackegedDeclaredCompleted));
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

    private DateTime? _startDate;
    public DateTime? StartDate
    {
        get => _startDate;
        set
        {
            if (value == _startDate)
                return;
            _startDate = value;
            NotifyPropertyChanged(nameof(StartDate));
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

    private int? _customerId;
    public int? CustomerId
    {
        get => _customerId;
        set
        {
            if (value == _customerId)
                return;
            _customerId = value;
            NotifyPropertyChanged(nameof(CustomerId));
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

    private int? _invoiceId;
    public int? InvoiceId
    {
        get => _invoiceId;
        set
        {
            if (value == _invoiceId)
                return;
            _invoiceId = value;
            NotifyPropertyChanged(nameof(Invoice));
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

    private int? _paymentId;
    public int? PaymentId
    {
        get => _paymentId;
        set
        {
            if (value == _paymentId)
                return;
            _paymentId = value;
            NotifyPropertyChanged(nameof(PaymentId));
        }
    }

    private Payment? _payment;
    public Payment? Payment
    {
        get => _payment;
        set
        {
            if (value == _payment)
                return;
            _payment = value;
            NotifyPropertyChanged(nameof(Payment));
        }
    }

    private int? _subContractorId;
    public int? SubContractorId
    {
        get => _subContractorId;
        set
        {
            if (value == _subContractorId)
                return;
            _subContractorId = value;
            NotifyPropertyChanged(nameof(SubContractorId));
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

    private int? _projectManagerId;
    public int? ProjectManagerId
    {
        get => _projectManagerId;
        set
        {
            if (value == _projectManagerId)
                return;
            _projectManagerId = value;
            NotifyPropertyChanged(nameof(ProjectManagerId));
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
        DeadLine = DateTime.Now.AddMonths(1);
        StartDate = DateTime.Now;
        Name = "";
        Code = "";
        Description = "";
        Active = true;
        EstimatedMandays = 0;
        EstimatedHours = 0;
        EstimatedCompleted = 0;
        Completed = 0;
        WorkPackegedDeclaredCompleted = 0;
    }
}