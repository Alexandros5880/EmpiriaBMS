using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Front.ViewModel.Components;
public class RoleVM : BaseVM
{
    private bool _isChecked;
    public bool IsChecked
    {
        get => _isChecked;
        set
        {
            if (value == _isChecked)
                return;
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
            if (value == _name)
                return;
            _name = value;
            NotifyPropertyChanged(nameof(Name));
        }
    }

    public bool IsEmployee { get; set; }

    public RoleVM()
    {
        IsChecked = false;
        Name = string.Empty;
    }
}