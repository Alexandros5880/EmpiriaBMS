using EmpiriaBMS.Core.Dtos.Base;

namespace EmpiriaBMS.Core.Dtos;

public class InvoiceTypeDto : EntityDto
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public ICollection<InvoiceDto>? Invoices { get; set; }
}
