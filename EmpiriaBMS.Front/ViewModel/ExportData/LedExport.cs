using EmpiriaBMS.Front.ViewModel.Components;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class LedExport
{
    public string Name { get; set; }

    public int ClientId { get; set; }
    public string ClientName { get; set; }

    public string Address { get; set; }

    public double PotencialFee { get; set; }

    public string ExpectedDurationDate { get; set; }

    public string Result { get; set; }

    public LedExport(LedVM model)
    {
        Name = model.Name;
        ClientId = model.ClientId;
        ClientName = model.Client?.FullName ?? "";
        Address = model.Address?.FormattedAddress ?? "";
        PotencialFee = model.PotencialFee;
        ExpectedDurationDate = model.ExpectedDurationDate?.ToEuropeFormat() ?? "";
        Result = Convert.ToString(model.Result);
    }
}
