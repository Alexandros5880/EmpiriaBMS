using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;
using System.Globalization;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class DeliverableExport : IInport<DrawingVM>
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

    public DrawingVM Get()
    {
        DateTime? date;
        try
        {
            string format = "dd-MM-yyyy"; //  MM-dd-yyyy hh:mm:ss tt
            date = DateTime.ParseExact(CompletionDate, format, CultureInfo.InvariantCulture);
        }
        catch (FormatException)
        {
            Console.WriteLine($"'{CompletionDate}' is not in the correct format.");
            date = null;
        }

        return new DrawingVM()
        {
            TypeId = TypeId,
            DisciplineId = DisciplineId,
            CompletionEstimation = CompletionEstimation,
            CompletionDate = date,
        };
    }
}
