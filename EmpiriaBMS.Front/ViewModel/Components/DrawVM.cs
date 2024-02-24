using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpiriaBMS.Front.ViewModel.Components;

public class DrawVM : BaseVM
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

    private long _menHours;
    public long MenHours
    {
        get => _menHours;
        set
        {
            if (value == _menHours)
                return;
            _menHours = value;
            NotifyPropertyChanged(nameof(MenHours));
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
