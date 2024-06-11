using EmpiriaBMS.Front.ViewModel.Components;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class PaymentTypeExport
{
    public string Name { get; set; }

    public string Description { get; set; }

    public PaymentTypeExport(PaymentTypeVM model)
    {
        Name = model.Name;
        Description = model.Description ?? "";
    }
}
