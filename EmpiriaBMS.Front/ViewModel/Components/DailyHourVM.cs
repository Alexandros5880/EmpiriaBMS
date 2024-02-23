using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Models;

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
            NotifyPropertyChanged(nameof(_date));
        }
    }

    private Timespan _timeSpan;
    public Timespan TimeSpan
    {
        get => _timeSpan;
        set
        {
            if (value == _timeSpan)
                return;
            _timeSpan = value;
            NotifyPropertyChanged(nameof(TimeSpan));
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
}
