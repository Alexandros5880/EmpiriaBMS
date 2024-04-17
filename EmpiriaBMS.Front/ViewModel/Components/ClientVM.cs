using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;
using Microsoft.Kiota.Abstractions;

namespace EmpiriaBMS.Front.ViewModel.Components;

public class ClientVM : UserVM
{
    private string _companyName;
    public string CompanyName
    {
        get => _companyName;
        set
        {
            if (value == _companyName)
                return;
            _companyName = value;
            NotifyPropertyChanged(nameof(CompanyName));
        }
    }

    private int? _addressId;
    public int? AddressId
    {
        get => _addressId;
        set
        {
            if (value == _addressId)
                return;
            _addressId = value;
            NotifyPropertyChanged(nameof(AddressId));
        }
    }

    private Address? _address;
    public Address? Address
    {
        get => _address;
        set
        {
            if (value == _address)
                return;
            _address = value;
            NotifyPropertyChanged(nameof(Address));
        }
    }

    public ICollection<Project> Projects { get; set; }
}
