using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace EmpiriaBMS.Front.ViewModel.Components;

public class DeliverableVM : BaseVM
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

    private long? _typeId;
    public long? TypeId
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

    private DeliverableType _type;
    public DeliverableType Type
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

    [NotMapped]
    public string TypeName => Type != null ? Type.Name : "";

    private float _completionEstimation;
    public float CompletionEstimation
    {
        get => _completionEstimation;
        set
        {
            if (value == _completionEstimation)
                return;
            _completionEstimation = value;
            NotifyPropertyChanged(nameof(CompletionEstimation));
        }
    }

    private DateTime? _completionDate;
    public DateTime? CompletionDate
    {
        get => _completionDate;
        set
        {
            if (value == _completionDate)
                return;
            _completionDate = value;
            NotifyPropertyChanged(nameof(CompletionDate));
        }
    }

    private long? _disciplineId;
    public long? DisciplineId
    {
        get => _disciplineId;
        set
        {
            if (value == _disciplineId)
                return;
            _disciplineId = value;
            NotifyPropertyChanged(nameof(DisciplineId));
        }
    }

    private Discipline _discipline;
    public Discipline Discipline
    {
        get => _discipline;
        set
        {
            if (value == _discipline)
                return;
            _discipline = value;
            NotifyPropertyChanged(nameof(Discipline));
        }
    }

    [NotMapped]
    public string DisciplineTypeName => Discipline != null && Discipline.Type != null ? Discipline.Type.Name : "";

    [NotMapped]
    public string ProjectName => Discipline != null && Discipline.Project != null ? Discipline.Project.Name : "";

    [NotMapped]
    public string CompletionDateDisplay => $"{CompletionDate.Value.Day}/{CompletionDate.Value.Month}/{CompletionDate.Value.Year}";
}
