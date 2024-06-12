using EmpiriaBMS.Front.ViewModel.Components;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class InvoiceExport
{
    public int TypeId { get; set; }
    public string TypeName { get; set; }
    public double Total { get; set; }
    public int Vat { get; set; }
    public double Fee { get; set; }
    public string EstimatedDate { get; set; }
    public int Number { get; set; }
    public string Mark { get; set; }
    public int ContractId { get; set; }
    public double ContractContractualFee { get; set; }
    public string ContractDate { get; set; }
    public string ContractDescription { get; set; }
    public int ProjectId { get; set; }
    public string ProjectCode { get; set; }
    public string ProjectName { get; set; }
    public string ProjectPM { get; set; }

    public InvoiceExport(InvoiceVM model)
    {
        TypeId = model.TypeId;
        TypeName = model.Type?.Name ?? "";
        Total = model.Total ?? 0;
        Vat = Convert.ToInt32(model.Vat);
        Fee = model.Fee ?? 0;
        EstimatedDate = model.EstimatedDate?.ToEuropeFormat() ?? "";
        Number = model.Number ?? 0;
        Mark = model.Mark ?? "";
        ContractId = model.ContractId ?? 0;
        ContractContractualFee = model.Contract?.ContractualFee ?? 0;
        ContractDate = model.Contract?.Date?.ToEuropeFormat() ?? "";
        ContractDescription = model.Contract?.Description ?? "";
        ProjectId = model.ProjectId;
        ProjectCode = model.Project?.Code ?? "";
        ProjectName = model.Project?.Name ?? "";
        ProjectPM = model.Project?.ProjectManager?.FirstName ?? "";
    }

    public InvoiceExport()
    {

    }
}
