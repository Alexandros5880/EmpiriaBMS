using EmpiriaBMS.Front.ViewModel.Components;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class DisciplineTypeExport
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
}
