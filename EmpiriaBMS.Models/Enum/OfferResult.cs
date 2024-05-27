using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Enum;

public enum OfferResult
{
    [Display(Name = "UNSUCCESSFUL")]
    UNSUCCESSFUL,
    [Display(Name = "SUCCESSFUL")]
    SUCCESSFUL,
    [Display(Name = "WAITING FOR RESUL")]
    WAITING
}
