using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class ContractExport : IInport<ContractVM>
{
    public int Id { get; set; }

    public int InvoiceId { get; set; }

    public string InvoiceMark { get; set; }

    public double ContractualFee { get; set; }

    public string Date { get; set; }

    public string Description { get; set; }

    public ContractExport(ContractVM model)
    {
        Id = model.Id;
        InvoiceId = model.InvoiceId;
        InvoiceMark = model.Invoice?.Mark ?? "";
        ContractualFee = model.ContractualFee;
        Date = model.Date?.ToEuropeFormat() ?? "";
        Description = model.Description ?? "";
    }

    public ContractExport()
    {

    }

    public ContractVM Get() => new ContractVM()
    {
        InvoiceId = InvoiceId,
        ContractualFee = ContractualFee,
        Date = Convert.ToDateTime(Date),
        Description = Description,
    };
}
