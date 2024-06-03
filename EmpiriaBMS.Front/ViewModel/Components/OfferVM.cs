using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Enum;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Front.ViewModel.Components;

public class OfferVM : BaseVM
{
    // Type
    private int _typeId;
    public int TypeId
    {
        get => _typeId;
        set
        {
            if (value == _typeId)
                return;
            _typeId = value;
            NotifyPropertyChanged(nameof(TypeId));
        }
    }

    private OfferType _type;
    public OfferType Type
    {
        get => _type;
        set
        {
            if (value == _type)
                return;
            _type = value;
            NotifyPropertyChanged(nameof(Type));
        }
    }

    public string TypeName => Type != null ? Type.Name : "";

    // State
    private int _stateId;
    public int StateId
    {
        get => _stateId;
        set
        {
            if (value == _stateId)
                return;
            _stateId = value;
            NotifyPropertyChanged(nameof(StateId));
        }
    }

    private OfferState _state;
    public OfferState State
    {
        get => _state;
        set
        {
            if (value == _state)
                return;
            _state = value;
            NotifyPropertyChanged(nameof(State));
        }
    }

    public string StateName => State != null ? State.Name : "";

    // Project Category
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

    public string ProjectCategoryName => Category != null ? Category.Name : "";

    // Project SubCategory
    private int? _subCategoryId;
    public int? SubCategoryId
    {
        get => _subCategoryId;
        set
        {
            if (value == _subCategoryId)
                return;
            _subCategoryId = value;
            NotifyPropertyChanged(nameof(SubCategoryId));
        }
    }

    private ProjectSubCategory _subCategory;
    public ProjectSubCategory SubCategory
    {
        get => _subCategory;
        set
        {
            if (value == _subCategory)
                return;
            _subCategory = value;
            NotifyPropertyChanged(nameof(SubCategory));
        }
    }

    public string ProjectSubCategoryName => SubCategory != null ? SubCategory.Name : "";

    // Led
    private int? _ledId;
    public int? LedId
    {
        get => _ledId;
        set
        {
            if (value == _ledId)
                return;
            _ledId = value;
            NotifyPropertyChanged(nameof(LedId));
        }
    }

    private Led? _led;
    public Led? Led
    {
        get => _led;
        set
        {
            if (value == _led)
                return;
            _led = value;
            NotifyPropertyChanged(nameof(Led));
        }
    }

    public string LedName => Led != null ? Led.Name : "";

    // Result
    public OfferResult Result { get; set; }
    public string ResultName => Result.GetDisplayName();

    // Other Properties
    private string _code;
    public string Code
    {
        get => _code;
        set
        {
            if (value == _code)
                return;
            _code = value;
            NotifyPropertyChanged(nameof(Code));
        }
    }

    private DateTime? _date;
    public DateTime? Date
    {
        get => _date;
        set
        {
            if (value == _date)
                return;
            _date = value;
            NotifyPropertyChanged(nameof(Date));
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

    private double? _pudgetPrice;
    public double? PudgetPrice
    {
        get => _pudgetPrice;
        set
        {
            if (value == _pudgetPrice)
                return;
            _pudgetPrice = value;
            NotifyPropertyChanged(nameof(PudgetPrice));
        }
    }

    private double? _offerPrice;
    public double? OfferPrice
    {
        get => _offerPrice;
        set
        {
            if (value == _offerPrice)
                return;
            _offerPrice = value;
            NotifyPropertyChanged(nameof(OfferPrice));
        }
    }

    private string? _observations;
    public string? Observations
    {
        get => _observations;
        set
        {
            if (value == _observations)
                return;
            _observations = value;
            NotifyPropertyChanged(nameof(Observations));
        }
    }

    private string? _teamText;
    public string? TeamText
    {
        get => _teamText;
        set
        {
            if (value == _teamText)
                return;
            _teamText = value;
            NotifyPropertyChanged(nameof(TeamText));
        }
    }

    private string? _comments;
    public string? Comments
    {
        get => _comments;
        set
        {
            if (value == _comments)
                return;
            _comments = value;
            NotifyPropertyChanged(nameof(Comments));
        }
    }

    public ICollection<Project>? Projects { get; set; }
}
