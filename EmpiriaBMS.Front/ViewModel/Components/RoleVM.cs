using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaMS.Models.Models;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.ViewModel.Components;
public class RoleVM : BaseVM
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

    private string? _name;
    public string? Name
    {
        get => _name;
        set
        {
            _name = value;
            NotifyPropertyChanged(nameof(Name));
        }
    }

    public ICollection<UserVM>? Employees { get; set; }

}