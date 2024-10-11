using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class SupportiveWorkExport : IInport<SupportiveWorkVM>
{
    public long TypeId { get; set; }

    public string Type { get; set; }

    public long DisciplineId { get; set; }

    public string DisciplineType { get; set; }

    public float CompletionEstimation { get; set; }

    public SupportiveWorkExport(SupportiveWorkVM model)
    {
        TypeId = model.TypeId ?? 0;
        Type = model.Type?.Name ?? "";
        DisciplineId = model.DisciplineId ?? 0;
        DisciplineType = model.Discipline?.Type.Name ?? "";
        CompletionEstimation = model.CompletionEstimation;
    }

    public SupportiveWorkExport()
    {

    }

    public SupportiveWorkVM Get() => new SupportiveWorkVM()
    {
        TypeId = TypeId,
        DisciplineId = DisciplineId,
        CompletionEstimation = CompletionEstimation,
    };
}
