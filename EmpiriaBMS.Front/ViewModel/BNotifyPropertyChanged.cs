using System.ComponentModel;

namespace EmpiriaBMS.Front.ViewModel;
public class BNotifyPropertyChanged : INotifyPropertyChanged
{

    public event PropertyChangedEventHandler PropertyChanged;
    protected void NotifyPropertyChanged(string propertyName)
    {
        var handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}