using EmpiriaMS.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EmpiriaBMS.Front.ViewModel.Components.Base;

namespace EmpiriaBMS.Front.ViewModel.Components;
public class InvoiceVM : BaseVM
{
    private bool _isChecked;
    public bool IsChecked
    {
        get => _isChecked;
        set
        {
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
            _date = value;
            NotifyPropertyChanged(nameof(Date));
        }
    }

    private string? _projectId;
    public string? ProjectId
    {
        get => _projectId;
        set
        {
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
            _project = value;
            NotifyPropertyChanged(nameof(Project));
        }
    }
}