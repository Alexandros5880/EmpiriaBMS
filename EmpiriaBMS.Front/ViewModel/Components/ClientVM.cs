using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Enum;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Front.ViewModel.Components;

public class ClientVM : BaseVM
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

    // Not Mapped
    private DateTime _timeDate = DateTime.Now;
    public DateTime TimeDatePassed
    {
        get => _timeDate;
        set
        {
            if (value == _timeDate)
                return;
            _timeDate = value;
            NotifyPropertyChanged(nameof(TimeDatePassed));
        }
    }

    private string _companyName;
    public string CompanyName
    {
        get => _companyName;
        set
        {
            if (value == _companyName)
                return;
            _companyName = value;
            NotifyPropertyChanged(nameof(CompanyName));
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

    private string _phone;
    public string Phone
    {
        get => _phone;
        set
        {
            if (value == _phone)
                return;
            _phone = value;
            NotifyPropertyChanged(nameof(Phone));
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

    private long? _addressId;
    public long? AddressId
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

    private Address? _address;
    public Address? Address
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

    private ClientResult _result;
    public ClientResult Result
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

    public ICollection<DailyTime>? DailyTime { get; set; }

    public ICollection<Offer>? Offers { get; set; }

    public string AddressFormated => Address != null ? Address.FormattedAddress : "";

    public ICollection<User>? Users { get; set; }

    public ICollection<Email>? Emails { get; set; }
}
