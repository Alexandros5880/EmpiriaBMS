using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class PaymentTypeExport : IInport<PaymentTypeVM>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public PaymentTypeExport(PaymentTypeVM model)
    {
        Name = model.Name;
        Description = model.Description ?? "";
    }

    public PaymentTypeExport()
    {

    }

    public PaymentTypeVM Get() => new PaymentTypeVM()
    {
        Name = Name,
        Description = Description,
    };
}
