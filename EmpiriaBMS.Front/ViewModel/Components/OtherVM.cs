using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Front.ViewModel.Components;

public class OtherVM : BaseVM
{
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

    private OtherType _type;
    public OtherType Type
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

    private int? __disciplineId;
    public int? DisciplineId
    {
        get => __disciplineId;
        set
        {
            if (value == __disciplineId)
                return;
            __disciplineId = value;
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
}

