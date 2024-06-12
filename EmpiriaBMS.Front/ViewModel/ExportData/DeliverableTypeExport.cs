using EmpiriaBMS.Front.ViewModel.Components;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class DeliverableTypeExport
{
    public string Name { get; set; }

    public string Description { get; set; }

    public DeliverableTypeExport(DrawingTypeVM model)
    {
        Name = model.Name;
        Description = model.Description ?? "";
    }

    public DeliverableTypeExport()
    {

    }
}
