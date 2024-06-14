using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class InvoiceTypeExport : IInport<InvoiceTypeVM>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public InvoiceTypeExport(InvoiceTypeVM model)
    {
        Name = model.Name ?? "";
        Description = model.Description ?? "";
    }

    public InvoiceTypeExport()
    {

    }

    public InvoiceTypeVM Get() => new InvoiceTypeVM()
    {
        Name = Name,
        Description = Description,
    };
}
