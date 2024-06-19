using EmpiriaBMS.Core.Dtos;

namespace EmpiriaBMS.Core.ReturnModels;

public class PendingPayments
{
    public int PendingPaymentsCount { get; set; }
    public ProjectDto Project { get; set; }
    public List<PaymentDto> Payments { get; set; }
    public double PendingSum { get; set; }
}
