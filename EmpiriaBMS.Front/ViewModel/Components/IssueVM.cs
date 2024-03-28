using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;

namespace EmpiriaBMS.Front.ViewModel.Components;

public class IssueVM : BaseVM
{
    private DateTime _complaintDate;
    public DateTime ComplaintDate
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

    private int _roleId;
    public int RoleId
    {
        get => _roleId;
        set
        {
            if (value == _roleId)
                return;
            _roleId = value;
            NotifyPropertyChanged(nameof(RoleId));
        }
    }

    private Role _role;
    public Role Role
    {
        get => _role;
        set
        {
            if (value == _role)
                return;
            _role = value;
            NotifyPropertyChanged(nameof(Role));
        }
    }

    private string _about;
    public string About
    {
        get => _about;
        set
        {
            if (value == _about)
                return;
            _about = value;
            NotifyPropertyChanged(nameof(About));
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

    private DateTime _solutionDate;
    public DateTime SolutionDate
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

    private DateTime _verificationDate;
    public DateTime VerificationDate
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
