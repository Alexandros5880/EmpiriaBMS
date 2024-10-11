using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpiriaBMS.Front.ViewModel.Components;

public class ProjectSubCategoryVM : BaseVM
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

    private string _description;
    public string Description
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

    private long? _categoryId;
    public long? CategoryId
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

    public ICollection<Offer> Offers { get; set; }

    [NotMapped]
    public string ParentCategoryName => Category != null ? Category.Name : "";
}
