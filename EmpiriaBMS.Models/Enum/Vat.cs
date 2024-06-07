using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Enum;
public enum Vat
{
    [Display(Name = "0")]
    Zero = 0,

    [Display(Name = "17")]
    Seventeen = 17,

    [Display(Name = "24")]
    TwentyFour = 24
}
