using EmpiriaMS.Models.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Front.ViewModel.Components;
public class EmployeeVM : UserVM
{
    private bool _isChecked;
    public bool IsChecked
    {
        get => _isChecked;
        set
        {
            _isChecked = value;
            NotifyPropertyChanged(nameof(IsChecked));
        }
    }

    private double? _hours;
    public double? Hours
    {
        get => _hours;
        set
        {
            _hours = value;
            NotifyPropertyChanged(nameof(Hours));
        }
    }

    public virtual ICollection<ProjectVM>? Projects { get; set; }

    [Required]
    public virtual ICollection<RoleVM>? Roles { get; set; }
}