using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class ProjectStageExport : IInport<ProjectStageVM>
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

    public ProjectStageVM Get() => new ProjectStageVM()
    {
        Name = Name,
        Description = Description,
    };
}
