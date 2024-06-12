using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class SupportiveWorkExport : IInport<OtherVM>
{
    public int TypeId { get; set; }

    public string Type { get; set; }

    public int DisciplineId { get; set; }

    public string DisciplineType { get; set; }

    public float CompletionEstimation { get; set; }

    public SupportiveWorkExport(OtherVM model)
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

    public OtherVM Get() => new OtherVM()
    {
        TypeId = TypeId,
        DisciplineId = DisciplineId,
        CompletionEstimation = CompletionEstimation,
    };
}
