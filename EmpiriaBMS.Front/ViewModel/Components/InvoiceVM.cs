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

    private double? _total;
    public double? Total
    {
        get => _total;
        set
        {
            if (value == _total)
                return;
            _total = value;
            NotifyPropertyChanged(nameof(Total));
        }
    }

    private Vat _vat;
    public Vat Vat
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

    private double? _fee;
    public double? Fee
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

    private DateTime? _estimatedDate;
    public DateTime? EstimatedDate
    {
        get => _estimatedDate;
        set
        {
            if (value == _estimatedDate)
                return;
            _estimatedDate = value;
            NotifyPropertyChanged(nameof(EstimatedDate));
        }
    }

    private int? _number;
    public int? Number
    {
        get => _number;
        set
        {
            if (value == _number)
                return;
            _number = value;
            NotifyPropertyChanged(nameof(Number));
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
        PaymentDate = DateTime.Now;
    }

    public InvoiceVM(InvoiceVM invoice)
    {
        Total = invoice.Total;
        Vat = invoice.Vat;
        Fee = invoice.Fee;
        Number = invoice.Number;
        Mark = invoice.Mark;
        EstimatedDate = invoice.EstimatedDate;
        PaymentDate = invoice.PaymentDate;
        TypeId = invoice.TypeId;
        Type = null;
        ProjectId = invoice.ProjectId;
        Project = null;
        Payments = invoice.Payments;
    }
}