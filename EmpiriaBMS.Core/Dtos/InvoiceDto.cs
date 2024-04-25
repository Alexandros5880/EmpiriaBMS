using EmpiriaBMS.Core.Dtos.Base;

namespace EmpiriaBMS.Core.Dtos;

public class InvoiceDto : EntityDto
{
    public double? Total { get; set; }

    public double? Vat { get; set; }

    public double? Fee { get; set; }

    public int? Number { get; set; }

    public string? Mark { get; set; }

    public DateTime Date { get; set; }

    public int TypeId { get; set; }

    public InvoiceTypeDto? Type { get; set; }

    public int ProjectId { get; set; }

    public ProjectDto? Project { get; set; }

    public ICollection<PaymentDto>? Payments { get; set; }
}
