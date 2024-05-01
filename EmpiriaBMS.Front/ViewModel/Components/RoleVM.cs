using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpiriaBMS.Front.ViewModel.Components;
public class RoleVM : BaseVM
{
    private bool _isSelected = false;
    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            if (value == _isSelected)
                return;
            _isSelected = value;
            NotifyPropertyChanged(nameof(IsSelected));
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

    private bool _isEmployee;
    public bool IsEmployee
    {
        get => _isEmployee;
        set
        {
            if (value == _isEmployee)
                return;
            _isEmployee = value;
            NotifyPropertyChanged(nameof(IsEmployee));
        }
    }

    private bool _isEditable;
    public bool IsEditable
    {
        get => _isEditable;
        set
        {
            if (value == _isEditable)
                return;
            _isEditable = value;
            NotifyPropertyChanged(nameof(IsEditable));
        }
    }

    public ICollection<RolePermission> RolesPermissions { get; set; }
}