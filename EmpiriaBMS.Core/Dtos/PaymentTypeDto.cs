using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Dtos;

public class PaymentTypeDto : EntityDto
{
    public string Name { get; set; }

    public string? Description { get; set; }

    public ICollection<PaymentDto> Payments { get; set; }
}
