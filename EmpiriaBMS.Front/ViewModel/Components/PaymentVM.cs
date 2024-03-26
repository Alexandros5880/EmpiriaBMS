using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaMS.Models.Models;

namespace EmpiriaBMS.Front.ViewModel.Components;

public class PaymentVM : BaseVM
{
    private DateTime? _estPaymentDate;
    public DateTime? EstPaymentDate
    {
        get => _estPaymentDate;
        set
        {
            if (value == _estPaymentDate)
                return;
            _estPaymentDate = value;
            NotifyPropertyChanged(nameof(EstPaymentDate));
        }
    }

    private DateTime? _paymentDate;
    public DateTime? PaymentDate
    {
        get => _paymentDate;
        set
        {
            if (value == _paymentDate)
                return;
            _paymentDate = value;
            NotifyPropertyChanged(nameof(PaymentDate));
        }
    }

    private int? _delayInPayment;
    public int? DelayInPayment
    {
        get => _delayInPayment;
        set
        {
            if (value == _delayInPayment)
                return;
            _delayInPayment = value;
            NotifyPropertyChanged(nameof(DelayInPayment));
        }
    }

    private string _paymentDetails;
    public string PaymentDetails
    {
        get => _paymentDetails;
        set
        {
            if (value == _paymentDetails)
                return;
            _paymentDetails = value;
            NotifyPropertyChanged(nameof(PaymentDetails));
        }
    }

    private double? _dayCost;
    public double? DayCost
    {
        get => _dayCost;
        set
        {
            if (value == _dayCost)
                return;
            _dayCost = value;
            NotifyPropertyChanged(nameof(DayCost));
        }
    }

    private string _bank;
    public string Bank
    {
        get => _bank;
        set
        {
            if (value == _bank)
                return;
            _bank = value;
            NotifyPropertyChanged(nameof(Bank));
        }
    }

    private int? _daysUntilPayment;
    public int? DaysUntilPayment
    {
        get => _daysUntilPayment;
        set
        {
            if (value == _daysUntilPayment)
                return;
            _daysUntilPayment = value;
            NotifyPropertyChanged(nameof(DaysUntilPayment));
        }
    }

    private double? _pendingPayments;
    public double? PendingPayments
    {
        get => _pendingPayments;
        set
        {
            if (value == _pendingPayments)
                return;
            _pendingPayments = value;
            NotifyPropertyChanged(nameof(PendingPayments));
        }
    }

    private int? _projectId;
    public int? ProjectId
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
}
