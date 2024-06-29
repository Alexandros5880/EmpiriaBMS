using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;
using System.Globalization;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class ContractExport : IInport<ContractVM>
{
    public int Id { get; set; }

    public int InvoiceId { get; set; }

    public string InvoiceMark { get; set; }

    public double ContractualFee { get; set; }

    public string Date { get; set; }

    public string Description { get; set; }

    public ContractExport(Logging.LoggerManager Logger, ContractVM model)
    {
        Id = model.Id;
        InvoiceId = model.InvoiceId;
        InvoiceMark = model.Invoice?.Mark ?? "";
        ContractualFee = model.ContractualFee;
        Date = model.Date?.ToEuropeFormat() ?? "";
        Description = model.Description ?? "";
    }

    public ContractExport(Logging.LoggerManager Logger)
    {

    }

    public ContractVM Get()
    {
        DateTime? date;
        try
        {
            string format = "dd-MM-yyyy"; //  MM-dd-yyyy hh:mm:ss tt
            date = DateTime.ParseExact(Date, format, CultureInfo.InvariantCulture);
        }
        catch (FormatException)
        {
            Console.WriteLine($"'{Date}' is not in the correct format.");
            date = null;
        }

        return new ContractVM()
        {
            InvoiceId = InvoiceId,
            ContractualFee = ContractualFee,
            Date = date,
            Description = Description,
        };
    }
}
