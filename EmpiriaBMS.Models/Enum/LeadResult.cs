using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Models.Enum;

public enum LeadResult
{
    [Display(Name = "SUCCESSFUL")]
    SUCCESSFUL = 0,
    [Display(Name = "UNSUCCESSFUL")]
    UNSUCCESSFUL = 1
}
