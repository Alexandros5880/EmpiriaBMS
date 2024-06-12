using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class DisciplineTypeExport : IInport<DisciplineTypeVM>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public DisciplineTypeExport(DisciplineTypeVM model)
    {
        Name = model.Name;
        Description = model.Description ?? "";
    }

    public DisciplineTypeExport()
    {

    }

    public DisciplineTypeVM Get() => new DisciplineTypeVM()
    {
        Name = Name,
        Description = Description,
    };
}
