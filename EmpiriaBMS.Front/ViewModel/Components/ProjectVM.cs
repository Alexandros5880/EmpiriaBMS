using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpiriaBMS.Front.ViewModel.Components;
public class ProjectVM : BaseVM
{
    // Not Mapped
    private TimeSpan _time = TimeSpan.Zero;
    public TimeSpan Time
    {
        get => _time;
        set
        {
            if (value == _time)
                return;
            _time = value;
            NotifyPropertyChanged(nameof(Time));
        }
    }

    // Not Mapped
    private DateTime _timeDate = DateTime.Now;
    public DateTime TimeDatePassed
    {
        get => _timeDate;
        set
        {
            if (value == _timeDate)
                return;
            _timeDate = value;
            NotifyPropertyChanged(nameof(TimeDatePassed));
        }
    }

    private string _name;
    public string Name
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

    private string _code;
    public string Code
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

    private long? _stageId;
    public long? StageId
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

    private long? _projectManagerId;
    public long? ProjectManagerId
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

    private User _projectManager;
    public User ProjectManager
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

    private long? _offerId;
    public long? OfferId
    {
        get => _offerId;
        set
        {
            if (value == _offerId)
                return;
            _offerId = value;
            NotifyPropertyChanged(nameof(OfferId));
        }
    }

    private Offer _offer;
    public Offer Offer
    {
        get => _offer;
        set
        {
            if (value == _offer)
                return;
            _offer = value;
            NotifyPropertyChanged(nameof(Offer));
        }
    }

    private long? _addressId;
    public long? AddressId
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

    private Address _address;
    public Address Address
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

    public ICollection<Invoice> Invoices { get; set; }

    public ICollection<DailyTime> DailyTime { get; set; }

    public ICollection<Discipline> Disciplines { get; set; }

    public ICollection<Issue> Complains { get; set; }

    public ICollection<ProjectSubConstractor>? ProjectsSubConstructors { get; set; }

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
    }

    // Extra Hellping Properties
    [NotMapped]
    private string? _pmName;
    [NotMapped]
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

    [NotMapped]
    public string PMFullName => ProjectManager != null ? $"{ProjectManager.LastName} {ProjectManager.MidName} {ProjectManager.FirstName}" : "";

    [NotMapped]
    public string ClientFullName => Offer?.Client?.Name ?? "";

    [NotMapped]
    public List<long> SubConstructorsIds { get; set; }
}