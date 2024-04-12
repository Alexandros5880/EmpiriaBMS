using EmpiriaBMS.Front.ViewModel.Components.Base;

namespace EmpiriaBMS.Front.ViewModel.Components;

public class ProjectSubCategoryVM : BaseValidator
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
}
