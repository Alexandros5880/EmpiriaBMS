using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Front.ViewModel.Interfaces;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Front.ViewModel.Components;

public class ProjectStageVM : BaseVM, ITypeVM
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

    public ICollection<Project> Projects { get; set; }
}
