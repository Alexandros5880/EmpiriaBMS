using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Front.ViewModel.Components;

public class PermissionVM : BaseVM
{
    private bool? _isSelected;
    public bool? IsSelected
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

    private int _ord;
    public int Ord
    {
        get => _ord;
        set
        {
            if (value == _ord)
                return;
            _ord = value;
            NotifyPropertyChanged(nameof(Ord));
        }
    }

    public ICollection<RolePermission> RolesPermissions { get; set; }
}