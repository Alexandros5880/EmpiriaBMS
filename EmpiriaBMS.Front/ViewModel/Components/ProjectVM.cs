using EmpiriaMS.Models.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using EmpiriaBMS.Models.Models;
using EmpiriaBMS.Front.ViewModel.Components.Base;

namespace EmpiriaBMS.Front.ViewModel.Components;
public class ProjectVM : BaseValidator
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

    private int? _subCategoryId;
    public int? SubCategoryId
    {
        get => _subCategoryId;
        set
        {
            if (value == _subCategoryId)
                return;
            _subCategoryId = value;
            NotifyPropertyChanged(nameof(SubCategoryId));
        }
    }

    private ProjectSubCategory _subCategory;
    public ProjectSubCategory SubCategory
    {
        get => _subCategory;
        set
        {
            if (value == _subCategory)
                return;
            _subCategory = value;
            NotifyPropertyChanged(nameof(SubCategory));
        }
    }

    private int? _categoryId;
    public int? CategoryId
    {
        get => _categoryId;
        set
        {
            if (value == _categoryId)
                return;
            _categoryId = value;
            NotifyPropertyChanged(nameof(CategoryId));
        }
    }

    private ProjectCategory _category;
    public ProjectCategory Category
    {
        get => _category;
        set
        {
            if (value == _category)
                return;
            _category = value;
            NotifyPropertyChanged(nameof(Category));
        }
    }

    private int? _stageId;
    public int? StageId
    {
        get => _stageId;
        set
        {
            if (value == _stageId)
                return;
            _stageId = value;
            NotifyPropertyChanged(nameof(StageId));
        }
    }

    private ProjectStage _stage;
    public ProjectStage Stage
    {
        get => _stage;
        set
        {
            if (value == _stage)
                return;
            _stage = value;
            NotifyPropertyChanged(nameof(Stage));
        }
    }

    private int? _addressId;
    public int? AddressId
    {
        get => _addressId;
        set
        {
            if (value == _addressId)
                return;
            _addressId = value;
            NotifyPropertyChanged(nameof(AddressId));
        }
    }

    private Address? _address;
    public Address? Address
    {
        get => _address;
        set
        {
            if (value == _address)
                return;
            _address = value;
            NotifyPropertyChanged(nameof(Address));
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

    private float _declaredCompleted;
    public float DeclaredCompleted
    {
        get => _declaredCompleted;
        set
        {
            if (value == _declaredCompleted)
                return;
            _declaredCompleted = value;
            NotifyPropertyChanged(nameof(DeclaredCompleted));
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

    public ICollection<Project> Projects { get; set; } // TODO: ProjectVM -> Projects ???

    public ICollection<Invoice> Invoices { get; set; }

    public ICollection<ProjectSubConstructor> ProjectsSubConstructors { get; set; }

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
        _declaredCompleted = 0;
    }
}