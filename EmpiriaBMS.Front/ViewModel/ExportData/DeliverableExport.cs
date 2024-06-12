using EmpiriaBMS.Front.ViewModel.Components;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class DeliverableExport
{
    public int TypeId { get; set; }

    public string TypeName { get; set; }

    public int DisciplineId { get; set; }

    public string DisciplineType { get; set; }

    public int ProjectId { get; set; }

    public string ProjectName { get; set; }

    public float CompletionEstimation { get; set; }

    public string CompletionDate { get; set; }

    public DeliverableExport(DrawingVM model)
    {
        TypeId = model.TypeId ?? 0;
        TypeName = model.Type?.Name ?? "";
        DisciplineId = model.DisciplineId ?? 0;
        DisciplineType = model.Discipline?.Type?.Name ?? "";
        ProjectId = model.Discipline?.ProjectId ?? 0;
        ProjectName = model.Discipline?.Project?.Name ?? "";
        CompletionEstimation = model.CompletionEstimation;
        CompletionDate = model.CompletionDate?.ToEuropeFormat() ?? "";
    }

    public DeliverableExport()
    {

    }
}
