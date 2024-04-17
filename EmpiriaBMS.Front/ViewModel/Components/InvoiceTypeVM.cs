using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaMS.Models.Models;

namespace EmpiriaBMS.Front.ViewModel.Components;

public class InvoiceTypeVM : BaseVM
{
    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            if (value == _name)
                return;
            _name = value;
            NotifyPropertyChanged(nameof(Name));
        }
    }

    public ICollection<InvoiceVM> Invoices { get; set; }
}
