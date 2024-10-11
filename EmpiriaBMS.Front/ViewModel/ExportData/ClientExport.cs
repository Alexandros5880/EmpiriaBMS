using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class ClientExport : IInport<ClientVM>
{
    public string CompanyName { get; set; }

    public long AddressId { get; set; }

    public string Address { get; set; }


    public string Name { get; set; }


    public string Phone { get; set; }

    public string Description { get; set; }

    public ClientExport(ClientVM model)
    {
        CompanyName = model.CompanyName;
        AddressId = model.AddressId ?? 0;
        Address = model.Address?.FormattedAddress ?? "";
        Name = model.Name;
        Phone = model.Phone;
        Description = model.Description ?? "";
    }

    public ClientExport()
    {

    }

    public ClientVM Get() => new ClientVM()
    {
        CompanyName = CompanyName,
        AddressId = AddressId,
        Name = Name,
        Phone = Phone,
        Description = Description
    };

}
