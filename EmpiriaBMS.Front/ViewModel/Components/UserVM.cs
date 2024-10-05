using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpiriaBMS.Front.ViewModel.Components;
public class UserVM : BaseVM
{
    private bool _isSelected = false;
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

    private string _proxyAddress;
    public string ProxyAddress
    {
        get => _proxyAddress;
        set
        {
            if (value == _proxyAddress)
                return;
            _proxyAddress = value;
            NotifyPropertyChanged(nameof(ProxyAddress));
        }
    }

    private string _passwordHash;
    public string PasswordHash
    {
        get => _passwordHash;
        set
        {
            if (value == _passwordHash)
                return;
            _passwordHash = value;
            NotifyPropertyChanged(nameof(PasswordHash));
        }
    }

    private string _password;
    public string Password
    {
        get => _password;
        set
        {
            if (value == _password)
                return;
            _password = value;
            NotifyPropertyChanged(nameof(Password));
        }
    }

    private string _lastName;
    public string LastName
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

    private string _firstName;
    public string FirstName
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

    private string _midName;
    public string MidName
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

    private string? _teamsObjectId;
    public string? TeamsObjectId
    {
        get => _teamsObjectId;
        set
        {
            if (value == _teamsObjectId)
                return;
            _teamsObjectId = value;
            NotifyPropertyChanged(nameof(TeamsObjectId));
        }
    }

    private string _phone1;
    public string Phone1
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

    private string _phone2;
    public string Phone2
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

    private string _phone3;
    public string Phone3
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

    private int? _clientId;
    public int? ClientId
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

    public ICollection<Email>? Emails { get; set; }

    public ICollection<Project>? PMProjects { get; set; }

    public ICollection<Discipline>? Disciplines { get; set; }

    public ICollection<UserRole>? UserRoles { get; set; }

    public ICollection<DeliverableEmployee>? DeliverablesEmployees { get; set; }

    public ICollection<SupportiveWorkEmployee>? SupportiveWorksEmployees { get; set; }

    public ICollection<DisciplineEngineer>? DisciplinesEngineers { get; set; }

    public ICollection<DailyTime>? DailyTime { get; set; }

    public ICollection<DailyTime>? PersonalTime { get; set; }

    public ICollection<DailyTime>? TrainingTime { get; set; }

    public ICollection<DailyTime>? CorporateEventTime { get; set; }

    public ICollection<Issue>? MyIssues { get; set; }

    public ICollection<SubConstructor>? SubConstructors { get; set; }

    [NotMapped]
    public string FullName => $"{LastName} {MidName} {FirstName}";

    [NotMapped]
    public ICollection<int>? MyRolesIds { get; set; }
}