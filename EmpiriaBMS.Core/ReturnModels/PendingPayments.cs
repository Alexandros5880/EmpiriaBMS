using EmpiriaBMS.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.ReturnModels;

public class PendingPayments
{
    public int DelayedPaymentsCount { get; set; }
    public ProjectDto Project { get; set; }
    public List<PaymentDto> Payments { get; set; }
    public double PendingFee { get; set; }
}
