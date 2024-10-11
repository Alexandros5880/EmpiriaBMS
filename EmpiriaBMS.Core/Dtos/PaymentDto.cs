using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Core.Dtos;

public class PaymentDto : EntityDto
{
    public DateTime PaymentDate { get; set; }

    public string? Bank { get; set; }

    public double Fee { get; set; }

    public string? Description { get; set; }

    public long TypeId { get; set; }
    public PaymentType Type { get; set; }

    public long InvoiceId { get; set; }

    public Invoice Invoice { get; set; }
}
