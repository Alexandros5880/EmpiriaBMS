using EmpiriaBMS.Front.ViewModel.Components.Base;

namespace EmpiriaBMS.Front.ViewModel.Components;

public class ProjectCategoryVM : BaseValidator
{
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

    private string? _description;
    public string? Description
    {
        get => _description;
        set
        {
            if (value == _description)
                return;
            _description = value;
            NotifyPropertyChanged(nameof(Description));
        }
    }

    private bool _canAssignePM;
    public bool CanAssignePM
    {
        get => _canAssignePM;
        set
        {
            if (value == _canAssignePM)
                return;
            _canAssignePM = value;
            NotifyPropertyChanged(nameof(CanAssignePM));
        }
    }
}
