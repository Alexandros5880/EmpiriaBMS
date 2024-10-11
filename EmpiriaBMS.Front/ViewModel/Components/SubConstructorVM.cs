using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpiriaBMS.Front.ViewModel.Components;

public class SubConstructorVM : BaseVM
{
    private bool _isSelected;
    [NotMapped]
    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            if (value == _isSelected)
                return;
            _isSelected = value;
            NotifyPropertyChanged(nameof(IsSelected));
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

    private long? _userId;
    public long? UserId
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

    public ICollection<ProjectSubConstractor> ProjectsSubConstructors { get; set; }

    public ICollection<Email> Emails { get; set; }
}
