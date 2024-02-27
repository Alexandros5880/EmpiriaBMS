using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;
using Microsoft.EntityFrameworkCore.Storage;

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
}
