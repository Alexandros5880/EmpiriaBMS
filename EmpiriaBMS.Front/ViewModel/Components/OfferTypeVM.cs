using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Front.ViewModel.Components;

public class OfferTypeVM : BaseVM
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

    public ICollection<Offer> Offers { get; set; }
}
