using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.Validation.Base;

namespace EmpiriaBMS.Front.ViewModel.Validation;

public class OfferValidator : BaseValidator<OfferVM>
{
    #region State
    private bool _stateValid = false;
    public bool StateValid
    {
        get => _stateValid;
        set
        {
            if (value == _stateValid)
                return;
            _stateValid = value;
            NotifyPropertyChanged(nameof(StateValid));
        }
    }

    private string _stateErr = null;
    public string StateErr
    {
        get => _stateErr;
        set
        {
            if (value == _stateErr)
                return;
            _stateErr = value;
            NotifyPropertyChanged(nameof(StateErr));
        }
    }
    #endregion

    #region Type
    private bool _typeValid = false;
    public bool TypeValid
    {
        get => _stateValid;
        set
        {
            if (value == _typeValid)
                return;
            _typeValid = value;
            NotifyPropertyChanged(nameof(TypeValid));
        }
    }

    private string _typeErr = null;
    public string TypeErr
    {
        get => _typeErr;
        set
        {
            if (value == _typeErr)
                return;
            _typeErr = value;
            NotifyPropertyChanged(nameof(TypeErr));
        }
    }
    #endregion

    #region Code
    private bool _codeValid = false;
    public bool CodeValid
    {
        get => _codeValid;
        set
        {
            if (value == _codeValid)
                return;
            _codeValid = value;
            NotifyPropertyChanged(nameof(CodeValid));
        }
    }

    private string _codeErr = null;
    public string CodeErr
    {
        get => _codeErr;
        set
        {
            if (value == _codeErr)
                return;
            _codeErr = value;
            NotifyPropertyChanged(nameof(CodeErr));
        }
    }
    #endregion

    #region Date
    private bool _dateValid = false;
    public bool DateValid
    {
        get => _dateValid;
        set
        {
            if (value == _dateValid)
                return;
            _dateValid = value;
            NotifyPropertyChanged(nameof(DateValid));
        }
    }

    private string _dateErr = null;
    public string DateErr
    {
        get => _dateErr;
        set
        {
            if (value == _dateErr)
                return;
            _dateErr = value;
            NotifyPropertyChanged(nameof(DateErr));
        }
    }
    #endregion

    #region PudgetPrice
    private bool _pudgetPriceValid = false;
    public bool PudgetPriceValid
    {
        get => _pudgetPriceValid;
        set
        {
            if (value == _pudgetPriceValid)
                return;
            _pudgetPriceValid = value;
            NotifyPropertyChanged(nameof(PudgetPriceValid));
        }
    }

    private string _pudgetPriceErr = null;
    public string PudgetPriceErr
    {
        get => _pudgetPriceErr;
        set
        {
            if (value == _pudgetPriceErr)
                return;
            _pudgetPriceErr = value;
            NotifyPropertyChanged(nameof(PudgetPriceErr));
        }
    }
    #endregion

    #region OfferPrice
    private bool _offerPriceeValid = false;
    public bool OfferPriceValid
    {
        get => _offerPriceeValid;
        set
        {
            if (value == _offerPriceeValid)
                return;
            _offerPriceeValid = value;
            NotifyPropertyChanged(nameof(OfferPriceValid));
        }
    }

    private string _offerPriceErr = null;
    public string OfferPriceErr
    {
        get => _offerPriceErr;
        set
        {
            if (value == _offerPriceErr)
                return;
            _offerPriceErr = value;
            NotifyPropertyChanged(nameof(OfferPriceErr));
        }
    }
    #endregion


    public new bool ValidateProperty(OfferVM obj, string propertyName, object fieldValue = null)
    {
        try
        {
            object value = fieldValue != null ? fieldValue : _getPropertyValue(obj, propertyName);

            switch (propertyName)
            {
                case nameof(OfferVM.StateId):
                    StateValid = Convert.ToInt32(value) != 0;
                    StateErr = StateValid ? null : "State requared!";
                    return StateValid;
                case nameof(OfferVM.TypeId):
                    TypeValid = Convert.ToInt32(value) != 0;
                    TypeErr = TypeValid ? null : "Type requared!";
                    return TypeValid;
                case nameof(OfferVM.Code):
                    CodeValid = string.IsNullOrEmpty(obj.Code);
                    CodeErr = CodeValid ? null : "Code requared!";
                    return CodeValid;
                case nameof(OfferVM.Date):
                    DateValid = ((DateTime)value) >= DateTime.Now;
                    DateErr = DateValid ? null : "Date requared!";
                    return DateValid;
                case nameof(OfferVM.PudgetPrice):
                    PudgetPriceValid = Convert.ToInt32(value) != 0;
                    PudgetPriceErr = PudgetPriceValid ? null : "PudgetPrice requared!";
                    return PudgetPriceValid;
                case nameof(OfferVM.OfferPrice):
                    OfferPriceValid = Convert.ToInt32(value) != 0;
                    OfferPriceErr = OfferPriceValid ? null : "OfferPrice requared!";
                    return OfferPriceValid;
                default:
                    return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error

            return false;
        }
    }

    public new bool Validate(OfferVM obj)
    {
        try
        {
            ValidateProperty(obj, nameof(OfferVM.State), obj.StateId);
            ValidateProperty(obj, nameof(OfferVM.Type), obj.TypeId);
            ValidateProperty(obj, nameof(OfferVM.Code), obj.Code);
            ValidateProperty(obj, nameof(OfferVM.Date), obj.Date);
            ValidateProperty(obj, nameof(OfferVM.PudgetPrice), obj.PudgetPrice);
            ValidateProperty(obj, nameof(OfferVM.OfferPrice), obj.OfferPrice);

            return StateValid || TypeValid || CodeValid || DateValid || PudgetPriceValid || OfferPriceValid;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error

            return false;
        }
    }

}
