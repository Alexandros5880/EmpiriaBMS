using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Enum;
using EmpiriaBMS.Models.Models;
using static Microsoft.Fast.Components.FluentUI.Emojis.Symbols.Color.Default;

namespace EmpiriaBMS.Front.ViewModel.Components;

public class DailyHourVM : BaseVM
{
    private DateTime _date;
    public DateTime Date
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

    private DailyTimeType _type;
    public DailyTimeType Type
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

    private DailyTimeType _isEditByAdmin;
    public DailyTimeType IsEditByAdmin
    {
        get => _isEditByAdmin;
        set
        {
            if (value == _isEditByAdmin)
                return;
            _isEditByAdmin = value;
            NotifyPropertyChanged(nameof(IsEditByAdmin));
        }
    }

    private int _userId;
    public int UserId
    {
        get => _userId;
        set
        {
            if (value == _userId)
                return;
            _userId = value;
            NotifyPropertyChanged(nameof(UserId));
        }
    }

    private User _user;
    public User User
    {
        get => _user;
        set
        {
            if (value == _user)
                return;
            _user = value;
            NotifyPropertyChanged(nameof(User));
        }
    }

    #region TimeSpan
    private long _dayes;
    public long Days
    {
        get => _dayes;
        set
        {
            if (value == _dayes)
                return;
            _dayes = value;
            NotifyPropertyChanged(nameof(Days));
        }
    }

    private long _hours;
    public long Hours
    {
        get => _hours;
        set
        {
            if (value == _hours)
                return;
            _hours = value;
            NotifyPropertyChanged(nameof(Hours));
        }
    }

    private long _minutes;
    public long Minutes
    {
        get => _minutes;
        set
        {
            if (value == _minutes)
                return;
            _minutes = value;
            NotifyPropertyChanged(nameof(Minutes));
        }
    }

    private long _seconds;
    public long Seconds
    {
        get => _seconds;
        set
        {
            if (value == _seconds)
                return;
            _seconds = value;
            NotifyPropertyChanged(nameof(Seconds));
        }
    }
    #endregion
}
