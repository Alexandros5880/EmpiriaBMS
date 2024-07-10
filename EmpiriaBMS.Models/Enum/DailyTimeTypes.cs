using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Models.Enum;

public enum DailyTimeTypes
{
    [Display(Name = "Daily Time")]
    DailyUser = 0,
    [Display(Name = "Personal Time")]
    PersonalUser = 1,
    [Display(Name = "Training Time")]
    TrainingUser = 2,
    [Display(Name = "Corporate Time")]
    CorporateUser = 3,
    [Display(Name = "Time on Lead")]
    Lead = 4,
    [Display(Name = "Time on Offer")]
    Offer = 5,
    [Display(Name = "Time on Project")]
    Project = 6,
    [Display(Name = "Time on Discipline")]
    Discipline = 7,
    [Display(Name = "Time on Deliverable")]
    Deliverable = 8,
    [Display(Name = "Time on SupportiveWork")]
    SupportiveWork = 9
}
