using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;
using System.Globalization;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class ProjectExport : IInport<ProjectVM>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public string Code { get; set; }

    public long EstimatedMandays { get; set; }

    public long EstimatedHours { get; set; }

    public int StageId { get; set; }

    public string StageName { get; set; }

    public bool Active { get; set; }

    public string StartDate { get; set; }

    public string DeadLine { get; set; }

    public float EstimatedCompleted { get; set; }

    public float DeclaredCompleted { get; set; }

    public int ProjectManagerId { get; set; }

    public string ProjectManagerName { get; set; }

    public int OfferId { get; set; }

    public string OfferCode { get; set; }

    public string OfferType { get; set; }

    public string OfferState { get; set; }

    public string OfferCategory { get; set; }

    public string OfferSubCategory { get; set; }


    public ProjectExport(ProjectVM model)
    {
        Name = model.Name ?? "";
        Description = model.Description ?? "";
        Code = model.Code ?? "";
        EstimatedMandays = model.EstimatedMandays;
        EstimatedHours = model.EstimatedHours;
        StageId = model.StageId ?? 0;
        StageName = model.Stage?.Name ?? "";
        Active = model.Active;
        StartDate = model.StartDate?.ToEuropeFormat() ?? "";
        DeadLine = model.DeadLine?.ToEuropeFormat() ?? "";
        EstimatedCompleted = model.EstimatedCompleted;
        DeclaredCompleted = model.DeclaredCompleted;
        ProjectManagerId = model.ProjectManagerId ?? 0;
        ProjectManagerName = model.ProjectManager?.FullName ?? "";
        OfferId = model.OfferId ?? 0;
        OfferCode = model.Offer?.Code;
        OfferType = model.Offer?.Type?.Name ?? "";
        OfferState = model.Offer?.State?.Name ?? "";
        OfferCategory = model.Offer?.Category?.Name ?? "";
        OfferSubCategory = model.Offer?.SubCategory?.Name ?? "";
    }

    public ProjectExport()
    {

    }

    public ProjectVM Get()
    {
        // StartDate
        DateTime? startDate;
        try
        {
            string format = "dd-MM-yyyy"; //  MM-dd-yyyy hh:mm:ss tt
            startDate = DateTime.ParseExact(StartDate, format, CultureInfo.InvariantCulture);
        }
        catch (FormatException)
        {
            startDate = null;
        }

        // DeadLine
        DateTime? deadLine;
        try
        {
            string format = "dd-MM-yyyy"; //  MM-dd-yyyy hh:mm:ss tt
            deadLine = DateTime.ParseExact(DeadLine, format, CultureInfo.InvariantCulture);
        }
        catch (FormatException)
        {
            deadLine = null;
        }

        return new ProjectVM()
        {
            Name = Name,
            Description = Description,
            Code = Code,
            EstimatedMandays = EstimatedMandays,
            EstimatedHours = EstimatedHours,
            StageId = StageId,
            Active = Active,
            StartDate = startDate,
            DeadLine = deadLine,
            EstimatedCompleted = EstimatedCompleted,
            DeclaredCompleted = DeclaredCompleted,
            ProjectManagerId = ProjectManagerId,
            OfferId = OfferId
        };
    }
}
