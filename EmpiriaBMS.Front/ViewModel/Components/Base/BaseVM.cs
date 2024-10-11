using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Front.ViewModel.Components.Base;
public class BaseVM : BNotifyPropertyChanged, ICloneable
{
    private long _id;
    public long Id
    {
        get => _id;
        set
        {
            if (value == _id)
                return;
            _id = value;
            NotifyPropertyChanged(nameof(Id));
        }
    }

    private DateTime? _createdDate;
    public DateTime? CreatedDate
    {
        get => _createdDate;
        set
        {
            if (value == _createdDate)
                return;
            _createdDate = value;
            NotifyPropertyChanged(nameof(CreatedDate));
        }
    }

    private DateTime? _lastUpdatedDate;
    public DateTime? LastUpdatedDate
    {
        get => _lastUpdatedDate;
        set
        {
            if (value == _lastUpdatedDate)
                return;
            _lastUpdatedDate = value;
            NotifyPropertyChanged(nameof(LastUpdatedDate));
        }
    }

    private bool _isDeleted;
    public bool IsDeleted
    {
        get => _isDeleted;
        set
        {
            if (value == _isDeleted)
                return;
            _isDeleted = value;
            NotifyPropertyChanged(nameof(IsDeleted));
        }
    }

    public BaseVM()
    {
        CreatedDate = DateTime.Now;
        LastUpdatedDate = DateTime.Now;
    }

    public object Clone() => this.MemberwiseClone();
}