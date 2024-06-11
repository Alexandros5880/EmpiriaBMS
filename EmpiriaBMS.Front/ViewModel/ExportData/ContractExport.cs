using EmpiriaBMS.Front.ViewModel.Components;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class ContractExport
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
}
