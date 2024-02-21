using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;

namespace EmpiriaBMS.Front.ViewModel.Components;

public class DisciplineVM : BaseVM
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

    private long? _estimatedHours;
    public long? EstimatedHours
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

    private long? _estimatedMenHours;
    public long? EstimatedMenHours
    {
        get => _estimatedMenHours;
        set
        {
            if (value == _estimatedMenHours)
                return;
            _estimatedMenHours = value;
            NotifyPropertyChanged(nameof(EstimatedMenHours));
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

    private User? _engineer;
    public User? Engineer
    {
        get => _engineer;
        set
        {
            if (value == _engineer)
                return;
            _engineer = value;
            NotifyPropertyChanged(nameof(Engineer));
        }
    }
}
