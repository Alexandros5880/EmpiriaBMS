using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class DeliverableTypeExport : IInport<DrawingTypeVM>
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

    public DrawingTypeVM Get() => new DrawingTypeVM()
    {
        Name = Name,
        Description = Description,
    };
}
