using EmpiriaBMS.Front.ViewModel.Components;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class InvoiceTypeExport
{
    public string Name { get; set; }

    public string Description { get; set; }

    public InvoiceTypeExport(InvoiceTypeVM model)
    {
        Name = model.Name ?? "";
        Description = model.Description ?? "";
    }
}
