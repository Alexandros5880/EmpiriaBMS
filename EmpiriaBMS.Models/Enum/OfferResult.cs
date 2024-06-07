using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Models.Enum;

public enum OfferResult
{
    [Display(Name = "UNSUCCESSFUL")]
    UNSUCCESSFUL = 0,
    [Display(Name = "SUCCESSFUL")]
    SUCCESSFUL = 1,
    [Display(Name = "WAITING FOR RESUL")]
    WAITING = 2
}
