using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Core.Dtos;

public class InvoiceDto : EntityDto
{
    [Required]
    public InvoiceCategory Category { get; set; }

    public double? Total { get; set; }

    public Vat Vat { get; set; }

    public double? Fee { get; set; }

    public DateTime? EstimatedDate { get; set; }

    public DateTime PaymentDate { get; set; }

    public int? Number { get; set; }

    public string? Mark { get; set; }

    public int TypeId { get; set; }

    public InvoiceTypeDto? Type { get; set; }

    public int? ContractId { get; set; }

    public ContractDto? Contract { get; set; }

    public int ProjectId { get; set; }

    public ProjectDto? Project { get; set; }

    public ICollection<PaymentDto>? Payments { get; set; }
}
