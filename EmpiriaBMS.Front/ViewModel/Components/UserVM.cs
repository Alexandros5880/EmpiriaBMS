using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;

namespace EmpiriaBMS.Front.ViewModel.Components;
public class UserVM : BaseVM
{
    private string? _email;
    public string? Email
    {
        get => _email;
        set
        {
            if (value == _email)
                return;
            _email = value;
            NotifyPropertyChanged(nameof(Email));
        }
    }

    private string? _lastName;
    public string? LastName
    {
        get => _lastName;
        set
        {
            if (value == _lastName)
                return;
            _lastName = value;
            NotifyPropertyChanged(nameof(LastName));
        }
    }

    private string? _firstName;
    public string? FirstName
    {
        get => _firstName;
        set
        {
            if (value == _firstName)
                return;
            _firstName = value;
            NotifyPropertyChanged(nameof(FirstName));
        }
    }

    private string? _midName;
    public string? MidName
    {
        get => _midName;
        set
        {
            if (value == _midName)
                return;
            _midName = value;
            NotifyPropertyChanged(nameof(MidName));
        }
    }

    private string? _phone1;
    public string? Phone1
    {
        get => _phone1;
        set
        {
            if (value == _phone1)
                return;
            _phone1 = value;
            NotifyPropertyChanged(nameof(Phone1));
        }
    }

    private string? _phone2;
    public string? Phone2
    {
        get => _phone2;
        set
        {
            if (value == _phone2)
                return;
            _phone2 = value;
            NotifyPropertyChanged(nameof(Phone2));
        }
    }

    private string? _phone3;
    public string? Phone3
    {
        get => _phone3;
        set
        {
            if (value == _phone3)
                return;
            _phone3 = value;
            NotifyPropertyChanged(nameof(Phone3));
        }
    }

    private string? _description;
    public string? Description
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

    private double? _hours;
    public double? Hours
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

    private Project? _project;
    public Project? Project
    {
        get => _project;
        set
        {
            if (value == _project)
                return;
            _project = value;
            NotifyPropertyChanged(nameof(Project));
        }
    }

    [NotMapped]
    public string FullName => LastName + FullName;

    public UserVM()
    {
        Hours = 0;
    }
}