using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Enum;

public enum InvoiceCategory
{
    [Display(Name = "Incomes")]
    INCOMES,
    [Display(Name = "Expenses")]
    EXPENSES
}
