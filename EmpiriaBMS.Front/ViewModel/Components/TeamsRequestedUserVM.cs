namespace EmpiriaBMS.Front.ViewModel.Components;

public class TeamsRequestedUserVM : UserVM
{
    private string _displayName;
    public string DisplayName
    {
        get => _displayName;
        set
        {
            if (value == _displayName)
                return;
            _displayName = value;
            NotifyPropertyChanged(nameof(DisplayName));
        }
    }

    private string _proxyAddress;
    public string ProxyAddress
    {
        get => _proxyAddress;
        set
        {
            if (value == _proxyAddress)
                return;
            _proxyAddress = value;
            NotifyPropertyChanged(nameof(ProxyAddress));
        }
    }

    private string _objectId;
    public string ObjectId
    {
        get => _objectId;
        set
        {
            if (value == _objectId)
                return;
            _objectId = value;
            NotifyPropertyChanged(nameof(ObjectId));
        }
    }
}
