using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Models.Enum;

public enum DailyTimeTypes
{
    [Display(Name = "General on User")]
    GeneralUserTime = 0,
    [Display(Name = "Personal Time")]
    PersonalTime = 1,
    [Display(Name = "Training Time")]
    TrainingTime = 2,
    [Display(Name = "Corporate Time")]
    CorporateTime = 3,
    [Display(Name = "Time on Client")]
    ClientTime = 4,
    [Display(Name = "Time on Offer")]
    OfferTime = 5,
    [Display(Name = "Time on Project")]
    ProjectTime = 6,
    [Display(Name = "Time on Discipline")]
    DisciplineTime = 7,
    [Display(Name = "Time on Deliverable")]
    DeliverableTime = 8,
    [Display(Name = "Time on SupportiveWork")]
    SupportiveWorkTime = 9,
    [Display(Name = "Unused Time")]
    UnusedTime = 10
}
