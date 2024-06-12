using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class IssueExport : IInport<IssueVM>
{
    public string ComplaintDate { get; set; }

    public int ProjectId { get; set; }

    public string ProjectName { get; set; }

    public string ProjectCode { get; set; }

    public int DisplayedRoleId { get; set; }

    public string DisplayedRole { get; set; }

    public int CreatorId { get; set; }

    public string Creator { get; set; }

    public string Description { get; set; }

    public string Solution { get; set; }

    public string SolutionDate { get; set; }

    public string Evaluation { get; set; }

    public string Verification { get; set; }

    public string VerificationDate { get; set; }

    public bool IsClose { get; set; }

    public IssueExport(IssueVM model)
    {
        ComplaintDate = model.ComplaintDate?.ToEuropeFormat() ?? "";
        ProjectId = model.ProjectId;
        ProjectName = model.Project?.Name ?? "";
        ProjectCode = model.Project?.Code ?? "";
        DisplayedRoleId = model.DisplayedRoleId;
        DisplayedRole = model.DisplayedRole?.Name ?? "";
        CreatorId = model.CreatorId;
        Creator = model.Creator?.FullName ?? "";
        Description = model.Description ?? "";
        Solution = model.Solution ?? "";
        SolutionDate = model.SolutionDate?.ToEuropeFormat() ?? "";
        Evaluation = model.Evaluation ?? "";
        Verification = model.Verification ?? "";
        VerificationDate = model.VerificationDate?.ToEuropeFormat() ?? "";
        IsClose = model.IsClose;
    }

    public IssueExport()
    {

    }

    public IssueVM Get() => new IssueVM()
    {
        ComplaintDate = Convert.ToDateTime(ComplaintDate),
        ProjectId = ProjectId,
        DisplayedRoleId = DisplayedRoleId,
        CreatorId = CreatorId,
        Description = Description,
        Solution = Solution,
        SolutionDate = Convert.ToDateTime(SolutionDate),
        Evaluation = Evaluation,
        Verification = Verification,
        VerificationDate = Convert.ToDateTime(VerificationDate),
        IsClose = IsClose
    };
}
