using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Enum;

namespace EmpiriaBMS.Front.ViewModel.Components;
public class InvoiceVM : BaseVM
{
    private InvoiceCategory _category;
    public InvoiceCategory Category
    {
        get => _category;
        set
        {
            if (value == _category)
                return;
            _category = value;
            NotifyPropertyChanged(nameof(Category));
        }
    }
    public double Total => (Fee * (1 + Vat / 100)) + Fee;

    private int _vat;
    public int Vat
    {
        get => _vat;
        set
        {
            if (value == _vat)
                return;
            _vat = value;
            NotifyPropertyChanged(nameof(Vat));
        }
    }

    private double _fee;
    public double Fee
    {
        get => _fee;
        set
        {
            if (value == _fee)
                return;
            _fee = value;
            NotifyPropertyChanged(nameof(Fee));
        }
    }

    private DateTime? _estimatedPayment;
    public DateTime? EstimatedPayment
    {
        get => _estimatedPayment;
        set
        {
            if (value == _estimatedPayment)
                return;
            _estimatedPayment = value;
            NotifyPropertyChanged(nameof(EstimatedPayment));
        }
    }

    private int? _invoiceNumber;
    public int? InvoiceNumber
    {
        get => _invoiceNumber;
        set
        {
            if (value == _invoiceNumber)
                return;
            _invoiceNumber = value;
            NotifyPropertyChanged(nameof(InvoiceNumber));
        }
    }

    private string? _mark;
    public string? Mark
    {
        get => _mark;
        set
        {
            if (value == _mark)
                return;
            _mark = value;
            NotifyPropertyChanged(nameof(Mark));
        }
    }

    private DateTime? _actualPayment;
    public DateTime? ActualPayment
    {
        get => _actualPayment;
        set
        {
            if (value == _actualPayment)
                return;
            _actualPayment = value;
            NotifyPropertyChanged(nameof(ActualPayment));
        }
    }

    private int _typeId { get; set; }
    public int TypeId
    {
        get => _typeId;
        set
        {
            if (value == _typeId)
                return;
            _typeId = value;
            NotifyPropertyChanged(nameof(TypeId));
        }
    }

    private InvoiceTypeVM _type { get; set; }
    public InvoiceTypeVM Type
    {
        get => _type;
        set
        {
            if (value == _type)
                return;
            _type = value;
            NotifyPropertyChanged(nameof(Type));
        }
    }

    public string TypeName => Type != null ? Type.Name : "";

    private int? _contractId { get; set; }
    public int? ContractId
    {
        get => _contractId;
        set
        {
            if (value == _contractId)
                return;
            _contractId = value;
            NotifyPropertyChanged(nameof(ContractId));
        }
    }

    private ContractVM _contract { get; set; }
    public ContractVM Contract
    {
        get => _contract;
        set
        {
            if (value == _contract)
                return;
            _contract = value;
            NotifyPropertyChanged(nameof(Contract));
        }
    }

    private int _projectId { get; set; }
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

    private ProjectVM _project { get; set; }
    public ProjectVM Project
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

    public ICollection<PaymentVM> Payments { get; set; }

    public InvoiceVM()
    {
        ActualPayment = DateTime.Now;
    }

    public InvoiceVM(InvoiceVM invoice)
    {
        Vat = invoice.Vat;
        Fee = invoice.Fee;
        InvoiceNumber = invoice.InvoiceNumber;
        Mark = invoice.Mark;
        EstimatedPayment = invoice.EstimatedPayment;
        ActualPayment = invoice.ActualPayment;
        TypeId = invoice.TypeId;
        Type = null;
        ProjectId = invoice.ProjectId;
        Project = null;
        Payments = invoice.Payments;
    }
}