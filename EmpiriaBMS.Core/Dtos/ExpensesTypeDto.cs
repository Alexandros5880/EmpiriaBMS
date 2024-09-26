using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Dtos;

public class ExpensesTypeDto : EntityDto
{
    [Required]
    public string? Name { get; set; }

    public string? Description { get; set; }

    public ICollection<Invoice>? Invoices { get; set; }
}
