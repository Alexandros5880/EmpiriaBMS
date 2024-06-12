using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;
using EmpiriaBMS.Models.Enum;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class LedExport : IInport<LedVM>
{
    public string Name { get; set; }

    public int ClientId { get; set; }
    public string ClientName { get; set; }

    public int AddressId { get; set; }
    public string AddressPlaceId { get; set; }
    public string Address { get; set; }

    public double PotencialFee { get; set; }

    public string ExpectedDurationDate { get; set; }

    public string Result { get; set; }

    public LedExport(LedVM model)
    {
        Name = model.Name;
        ClientId = model.ClientId;
        ClientName = model.Client?.FullName ?? "";
        AddressId = model.AddressId ?? 0;
        AddressPlaceId = model.Address?.PlaceId ?? "";
        Address = model.Address?.FormattedAddress ?? "";
        PotencialFee = model.PotencialFee;
        ExpectedDurationDate = model.ExpectedDurationDate?.ToEuropeFormat() ?? "";
        Result = Convert.ToString(model.Result);
    }

    public LedExport()
    {

    }

    public LedVM Get() => new LedVM()
    {
        Name = Name,
        ClientId = ClientId,
        AddressId = AddressId,
        PotencialFee = PotencialFee,
        ExpectedDurationDate = Convert.ToDateTime(ExpectedDurationDate),
        Result = Result.GetValueFromDisplayName<LedResult>()
    };
}
