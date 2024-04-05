using EmpiriaMS.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Front.ViewModel.Components;
public class InvoiceVM : BaseVM
{
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

    private double? _vat;
    public double? Vat
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

    private DateTime _date;
    public DateTime Date
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

    public List<ProjectInvoice> ProjectsInvoices { get; set; }

    public List<InvoicePayment> InvoicesPayments { get; set; }

    public InvoiceVM()
    {
        Date = DateTime.Now;
    }
}