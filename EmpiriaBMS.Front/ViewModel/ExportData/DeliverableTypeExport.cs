using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class DeliverableTypeExport : IInport<DeliverableTypeVM>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public DeliverableTypeExport(DeliverableTypeVM model)
    {
        Name = model.Name;
        Description = model.Description ?? "";
    }

    public DeliverableTypeExport()
    {

    }

    public DeliverableTypeVM Get() => new DeliverableTypeVM()
    {
        Name = Name,
        Description = Description,
    };
}
