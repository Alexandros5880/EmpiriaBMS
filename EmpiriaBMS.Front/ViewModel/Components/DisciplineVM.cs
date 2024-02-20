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

    private long? _estimatedManHours;
    public long? EstimatedManHours
    {
        get => _estimatedManHours;
        set
        {
            if (value == _estimatedManHours)
                return;
            _estimatedManHours = value;
            NotifyPropertyChanged(nameof(EstimatedManHours));
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
