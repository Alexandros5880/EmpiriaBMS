using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Core.ReturnModels;

public class ReportProjectReturnModel
{
    public Project Project { get; set; }
    public Offer Offer { get; set; }
    public ProjectCategory Category { get; set; }
    public ProjectSubCategory SubCategory { get; set; }
    public Lead Lead { get; set; }
    public Client Client { get; set; }
    public TimeSpan TotalWorkedTime { get; set; }
    public double TotalWorkedSum { get; set; }
}