using EmpiriaBMS.Front.ViewModel.Components.Base;
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
    private int  _stateId;
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

    // Result
    private int _resultId;
    public int ResultId
    {
        get => _resultId;
        set
        {
            if (value == _resultId)
                return;
            _resultId = value;
            NotifyPropertyChanged(nameof(ResultId));
        }
    }

    private OfferResult _result;
    public OfferResult Result
    {
        get => _result;
        set
        {
            if (value == _result)
                return;
            _result = value;
            NotifyPropertyChanged(nameof(Result));
        }
    }

    public string ResultName => Result != null ? Result.Name : "";

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

    private int? _projectId;
    public int? ProjectId
    {
        get => _projectId;
        set
        {
            if (value == _projectId)
                return;
            _projectId = value;
            NotifyPropertyChanged(nameof(ProjectId));
        }
    }

    private Project? _project;
    public Project? Project
    {
        get => _project;
        set
        {
            if (value == _project)
                return;
            _project = value;
            NotifyPropertyChanged(nameof(Project));
        }
    }

    public string ProjectName => Project != null ? Project.Name : "";
}
