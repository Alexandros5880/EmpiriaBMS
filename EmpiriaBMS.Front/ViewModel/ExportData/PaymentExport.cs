using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;
using System.Globalization;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class PaymentExport : IInport<PaymentVM>
{
    public string PaymentDate { get; set; }
    public string Bank { get; set; }
    public double Fee { get; set; }
    public string Description { get; set; }
    public int TypeId { get; set; }
    public string TypeName { get; set; }
    public int InvoiceId { get; set; }
    public string InvoiceMark { get; set; }
    public string InvoiceType { get; set; }
    public int ProjectId { get; set; }
    public string ProjectCode { get; set; }
    public string ProjectName { get; set; }
    public string ProjectPM { get; set; }

    public PaymentExport(PaymentVM model)
    {
        PaymentDate = model.PaymentDate?.ToEuropeFormat() ?? "";
        Bank = model.Bank ?? "";
        Fee = model.Fee;
        Description = model.Description ?? "";
        TypeId = model.TypeId;
        TypeName = model.Type.Name;
        InvoiceId = model.InvoiceId;
        InvoiceMark = model.Invoice.Mark ?? "";
        InvoiceType = model.Invoice.Type.Name;
        ProjectId = model.Invoice.ProjectId;
        ProjectCode = model.Invoice.Project.Code ?? "";
        ProjectName = model.Invoice.Project.Name ?? "";
        ProjectPM = model.Invoice.Project.ProjectManager?.FullName ?? "";
    }

    public PaymentExport()
    {

    }

    public PaymentVM Get()
    {
        DateTime? date;
        try
        {
            string format = "dd-MM-yyyy"; //  MM-dd-yyyy hh:mm:ss tt
            date = DateTime.ParseExact(PaymentDate, format, CultureInfo.InvariantCulture);
        }
        catch (FormatException)
        {
            date = null;
        }

        return new PaymentVM()
        {
            PaymentDate = date,
            Bank = Bank,
            Fee = Fee,
            Description = Description,
            TypeId = TypeId,
            InvoiceId = InvoiceId
        };
    }
}
