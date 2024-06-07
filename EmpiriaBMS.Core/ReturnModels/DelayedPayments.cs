using EmpiriaBMS.Core.Dtos;

namespace EmpiriaBMS.Core.ReturnModels;

public class DelayedPayments
{
    public int DelayedPaymentsCount { get; set; }
    public ProjectDto Project { get; set; }
    public List<PaymentDto> Payments { get; set; }
}
