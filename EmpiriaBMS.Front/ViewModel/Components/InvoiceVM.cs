using EmpiriaMS.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Front.ViewModel.Components.Projects;

namespace EmpiriaBMS.Front.ViewModel.Components;
public class InvoiceVM : BaseVM
{
    private bool _isChecked;
    public bool IsChecked
    {
        get => _isChecked;
        set
        {
            if (value == _isChecked)
                return;
            _isChecked = value;
            NotifyPropertyChanged(nameof(IsChecked));
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

    private ProjectVM? _project;
    public ProjectVM? Project
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

    public InvoiceVM()
    {
        IsChecked = false;
        Total = 0.0;
        Vat = 0.0;
        Fee = 0.0;
        Number = 0;
        Mark = string.Empty;
        Date = DateTime.Now;
    }
}