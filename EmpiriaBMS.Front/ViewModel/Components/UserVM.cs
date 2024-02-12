namespace EmpiriaBMS.Front.ViewModel.Components;
public class UserVM : BNotifyPropertyChanged
{
    private bool _isChecked;
    public bool IsChecked
    {
        get => _isChecked;
        set
        {
            _isChecked = value;
            NotifyPropertyChanged(nameof(IsChecked));
        }
    }

    private string? _email;
    public string? Email
    {
        get => _email;
        set
        {
            _email = value;
            NotifyPropertyChanged(nameof(Email));
        }
    }

    private string? _lastName;
    public string? LastName
    {
        get => _lastName;
        set
        {
            _lastName = value;
            NotifyPropertyChanged(nameof(LastName));
        }
    }

    private string? _firstName;
    public string? FirstName
    {
        get => _firstName;
        set
        {
            _firstName = value;
            NotifyPropertyChanged(nameof(FirstName));
        }
    }

    private string? _midName;
    public string? MidName
    {
        get => _midName;
        set
        {
            _midName = value;
            NotifyPropertyChanged(nameof(MidName));
        }
    }

    private string? _phone1;
    public string? Phone1
    {
        get => _phone1;
        set
        {
            _phone1 = value;
            NotifyPropertyChanged(nameof(Phone1));
        }
    }

    private string? _phone2;
    public string? Phone2
    {
        get => _phone2;
        set
        {
            _phone2 = value;
            NotifyPropertyChanged(nameof(Phone2));
        }
    }

    private string? _phone3;
    public string? Phone3
    {
        get => _phone3;
        set
        {
            _phone3 = value;
            NotifyPropertyChanged(nameof(Phone3));
        }
    }

    private string? _description;
    public string? Description
    {
        get => _description;
        set
        {
            _description = value;
            NotifyPropertyChanged(nameof(Description));
        }
    }
}