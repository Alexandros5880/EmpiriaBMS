using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpiriaBMS.Front.ViewModel.Components;

public class ContractVM : BaseVM
{
    private int _invoiceId { get; set; }
    public int InvoiceId
    {
        get => _invoiceId;
        set
        {
            if (value == _invoiceId)
                return;
            _invoiceId = value;
            NotifyPropertyChanged(nameof(InvoiceId));
        }
    }

    private InvoiceVM _invoice { get; set; }
    public InvoiceVM Invoice
    {
        get => _invoice;
        set
        {
            if (value == _invoice)
                return;
            _invoice = value;
            NotifyPropertyChanged(nameof(Invoice));
        }
    }

    private double _contractualFee { get; set; }
    public double ContractualFee
    {
        get => _contractualFee;
        set
        {
            if (value == _contractualFee)
                return;
            _contractualFee = value;
            NotifyPropertyChanged(nameof(ContractualFee));
        }
    }

    private DateTime? _date { get; set; }
    public DateTime? Date
    {
        get => _date;
        set
        {
            if (value == _date)
                return;
            _date = value;
            NotifyPropertyChanged(nameof(Date));
        }
    }

    private byte[]? _pMSignature { get; set; }
    public byte[]? PMSignature
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

    private string _description { get; set; }
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
}
