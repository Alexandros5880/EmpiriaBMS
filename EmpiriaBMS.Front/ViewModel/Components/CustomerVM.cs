using EmpiriaMS.Models.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Front.ViewModel.Components;
public class CustomerVM : UserVM
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
    
    public virtual ICollection<ProjectVM>? Projects { get; set; }
}