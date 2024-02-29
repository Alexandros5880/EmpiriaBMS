using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpiriaBMS.Front.ViewModel.Components;

public class DrawingVM : BaseVM
{
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
    public string CompletionDateDisplay => $"{CompletionDate.Value.Day}/{CompletionDate.Value.Month}/{CompletionDate.Value.Year}";
}
