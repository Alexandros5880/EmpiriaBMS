using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class DisciplineExport : IInport<DisciplineVM>
{
    public long EstimatedMandays { get; set; }

    public long EstimatedHours { get; set; }

    public float EstimatedCompleted { get; set; }

    public float DeclaredCompleted { get; set; }

    public int ProjectId { get; set; }

    public string ProjectName { get; set; }

    public int TypeId { get; set; }

    public string TypeName { get; set; }

    public DisciplineExport(DisciplineVM model)
    {
        EstimatedMandays = model.EstimatedMandays;
        EstimatedHours = model.EstimatedHours;
        EstimatedCompleted = model.EstimatedCompleted;
        DeclaredCompleted = model.DeclaredCompleted;
        ProjectId = model.ProjectId;
        ProjectName = model.Project?.Name ?? "";
        TypeId = model.TypeId;
        TypeName = model.Type?.Name ?? "";
    }

    public DisciplineExport()
    {

    }

    public DisciplineVM Get() => new DisciplineVM()
    {
        EstimatedMandays = EstimatedMandays,
        EstimatedHours = EstimatedHours,
        EstimatedCompleted = EstimatedCompleted,
        DeclaredCompleted = DeclaredCompleted,
        ProjectId = ProjectId,
        TypeId = TypeId,
    };
}
