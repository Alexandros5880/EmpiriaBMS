using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Front.ViewModel.Components;

public class IssueVM : BaseVM
{
    private DateTime? _complaintDate;
    public DateTime? ComplaintDate
    {
        get => _complaintDate;
        set
        {
            if (value == _complaintDate)
                return;
            _complaintDate = value;
            NotifyPropertyChanged(nameof(ComplaintDate));
        }
    }

    private int _projectId;
    public int ProjectId 
    {
        get => _projectId;
        set
        {
            if (value == _projectId)
                return;
            _projectId = value;
            NotifyPropertyChanged(nameof(ProjectId));
        }
    }

    private Project _project;
    public Project Project
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

    public string ProjectName => Project != null ? Project.Name : "";

    private int _displayedRoleId;
    public int DisplayedRoleId
    {
        get => _displayedRoleId;
        set
        {
            if (value == _displayedRoleId)
                return;
            _displayedRoleId = value;
            NotifyPropertyChanged(nameof(DisplayedRoleId));
        }
    }

    private Role _displayedRole;
    public Role DisplayedRole
    {
        get => _displayedRole;
        set
        {
            if (value == _displayedRole)
                return;
            _displayedRole = value;
            NotifyPropertyChanged(nameof(DisplayedRole));
        }
    }

    public string DisplayedRoleName => DisplayedRole != null ? DisplayedRole.Name : "";

    private int _creatorId;
    public int CreatorId
    {
        get => _creatorId;
        set
        {
            if (value == _creatorId)
                return;
            _creatorId = value;
            NotifyPropertyChanged(nameof(CreatorId));
        }
    }

    private User _creator;
    public User Creator
    {
        get => _creator;
        set
        {
            if (value == _creator)
                return;
            _creator = value;
            NotifyPropertyChanged(nameof(Creator));
        }
    }

    public string CreatorName => Creator != null ? Creator.FirstName : "";

    public ICollection<Document> Documents { get; set; }

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

    private string _solution;
    public string Solution
    {
        get => _solution;
        set
        {
            if (value == _solution)
                return;
            _solution = value;
            NotifyPropertyChanged(nameof(Solution));
        }
    }

    private DateTime? _solutionDate;
    public DateTime? SolutionDate
    {
        get => _solutionDate;
        set
        {
            if (value == _solutionDate)
                return;
            _solutionDate = value;
            NotifyPropertyChanged(nameof(SolutionDate));
        }
    }

    private string _evaluation;
    public string Evaluation
    {
        get => _evaluation;
        set
        {
            if (value == _evaluation)
                return;
            _evaluation = value;
            NotifyPropertyChanged(nameof(Evaluation));
        }
    }

    private string _verification;
    public string Verification
    {
        get => _verification;
        set
        {
            if (value == _verification)
                return;
            _verification = value;
            NotifyPropertyChanged(nameof(Verification));
        }
    }

    private DateTime? _verificationDate;
    public DateTime? VerificationDate
    {
        get => _verificationDate;
        set
        {
            if (value == _verificationDate)
                return;
            _verificationDate = value;
            NotifyPropertyChanged(nameof(VerificationDate));
        }
    }

    private byte[] _verificatorSignature;
    public byte[] VerificatorSignature
    {
        get => _verificatorSignature;
        set
        {
            if (value == _verificatorSignature)
                return;
            _verificatorSignature = value;
            NotifyPropertyChanged(nameof(VerificatorSignature));
        }
    }

    private byte[] _pMSignature;
    public byte[] PMSignature
    {
        get => _pMSignature;
        set
        {
            if (value == _pMSignature)
                return;
            _pMSignature = value;
            NotifyPropertyChanged(nameof(PMSignature));
        }
    }

    private bool _isClose;
    public bool IsClose
    {
        get => _isClose;
        set
        {
            if (value == _isClose)
                return;
            _isClose = value;
            NotifyPropertyChanged(nameof(IsClose));
        }
    }
}
