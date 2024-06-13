using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;
using EmpiriaBMS.Models.Enum;
using System.Globalization;

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

    public LedVM Get()
    {
        DateTime? date;
        try
        {
            string format = "dd-MM-yyyy"; //  MM-dd-yyyy hh:mm:ss tt
            date = DateTime.ParseExact(ExpectedDurationDate, format, CultureInfo.InvariantCulture);
        }
        catch (FormatException)
        {
            Console.WriteLine($"'{ExpectedDurationDate}' is not in the correct format.");
            date = null;
        }

        return new LedVM()
        {
            Name = Name,
            ClientId = ClientId,
            AddressId = AddressId,
            PotencialFee = PotencialFee,
            ExpectedDurationDate = date,
            Result = Result.GetValueFromDisplayName<LedResult>()
        };
    }
}
