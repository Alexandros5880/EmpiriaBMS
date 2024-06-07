using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Enum;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Front.ViewModel.Components;

public class LedVM : BaseVM
{
    // Not Mapped
    private TimeSpan _time = TimeSpan.Zero;
    public TimeSpan Time
    {
        get => _time;
        set
        {
            if (value == _time)
                return;
            _time = value;
            NotifyPropertyChanged(nameof(Time));
        }
    }

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

    private int _clientId;
    public int ClientId
    {
        get => _clientId;
        set
        {
            if (value == _clientId)
                return;
            _clientId = value;
            NotifyPropertyChanged(nameof(ClientId));
        }
    }

    private Client _client;
    public Client Client
    {
        get => _client;
        set
        {
            if (value == _client)
                return;
            _client = value;
            NotifyPropertyChanged(nameof(Client));
        }
    }

    private int? _addressId;
    public int? AddressId
    {
        get => _addressId;
        set
        {
            if (value == _addressId)
                return;
            _addressId = value;
            NotifyPropertyChanged(nameof(AddressId));
        }
    }

    private Address _address;
    public Address Address
    {
        get => _address;
        set
        {
            if (value == _address)
                return;
            _address = value;
            NotifyPropertyChanged(nameof(Address));
        }
    }

    private double _potencialFee;
    public double PotencialFee
    {
        get => _potencialFee;
        set
        {
            if (value == _potencialFee)
                return;
            _potencialFee = value;
            NotifyPropertyChanged(nameof(PotencialFee));
        }
    }

    private DateTime? _expectedDurationDate;
    public DateTime? ExpectedDurationDate
    {
        get => _expectedDurationDate;
        set
        {
            if (value == _expectedDurationDate)
                return;
            _expectedDurationDate = value;
            NotifyPropertyChanged(nameof(ExpectedDurationDate));
        }
    }

    private LedResult _result;
    public LedResult Result
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

    public ICollection<DailyTime> DailyTime { get; set; }
}
