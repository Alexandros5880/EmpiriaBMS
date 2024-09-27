using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Enum;

public enum ClientResult
{
    [Display(Name = "SUCCESSFUL")]
    SUCCESSFUL = 0,
    [Display(Name = "UNSUCCESSFUL")]
    UNSUCCESSFUL = 1,
    [Display(Name = "WAITING")]
    WAITING = 2
}
