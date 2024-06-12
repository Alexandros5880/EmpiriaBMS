using EmpiriaBMS.Front.ViewModel.Components;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class ProjectStageExport
{
    public string Name { get; set; }

    public string Description { get; set; }

    public ProjectStageExport(ProjectStageVM model)
    {
        Name = model.Name ?? "";
        Description = model.Description ?? "";
    }

    public ProjectStageExport()
    {

    }
}
