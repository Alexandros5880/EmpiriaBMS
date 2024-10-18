using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Front.ViewModel.Components;

public class DisciplineVM : BaseVM
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

    private bool? _isSelected = false;
    public bool? IsSelected
    {
        get => _isSelected;
        set
        {
            if (value == _isSelected)
                return;
            _isSelected = value;
            NotifyPropertyChanged(nameof(IsSelected));
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

    private long _typeId;
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

    private DisciplineType _type;
    public DisciplineType Type
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

    private long _projectId;
    public long ProjectId
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

    public string ProjectName => Project != null ? Project.Name : "";

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

    public DisciplineVM()
    {
        EstimatedMandays = 0;
        EstimatedHours = 0;
        EstimatedCompleted = 0;
        DeclaredCompleted = 0;
    }
}
