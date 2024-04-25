using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Front.ViewModel.Components;

public class ProjectSubCategoryVM : BaseVM
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

    private int? _categoryId;
    public int? CategoryId
    {
        get => _categoryId;
        set
        {
            if (value == _categoryId)
                return;
            _categoryId = value;
            NotifyPropertyChanged(nameof(CategoryId));
        }
    }

    private ProjectCategory _category;
    public ProjectCategory Category
    {
        get => _category;
        set
        {
            if (value == _category)
                return;
            _category = value;
            NotifyPropertyChanged(nameof(Category));
        }
    }

    public ICollection<Project> Projects { get; set; }

    public string ParentCategoryName => Category != null ? Category.Name : "";
}
