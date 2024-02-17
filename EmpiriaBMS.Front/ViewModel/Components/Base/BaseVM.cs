using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Front.ViewModel.Components.Base;
public class BaseVM : BNotifyPropertyChanged
{
    private string _id;
    public string Id
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

    public BaseVM()
    {
        Id = String.Empty;
        CreatedDate = DateTime.Now;
        LastUpdatedDate = DateTime.Now;
    }
}