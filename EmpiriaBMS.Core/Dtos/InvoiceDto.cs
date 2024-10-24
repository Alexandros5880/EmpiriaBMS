﻿using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Enum;
using EmpiriaBMS.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Core.Dtos;

public class InvoiceDto : EntityDto
{
    [Required]
    public InvoiceCategory Category { get; set; }

    public int Vat { get; set; }

    public double Fee { get; set; }

    public DateTime? EstimatedPayment { get; set; }

    public DateTime ActualPayment { get; set; }

    public int? InvoiceNumber { get; set; }

    public string? Mark { get; set; }

    public long TypeId { get; set; }
    public InvoiceTypeDto? Type { get; set; }

    public long? ExpensesTypeId { get; set; }
    public ExpensesType? ExpensesType { get; set; }

    public long ProjectId { get; set; }
    public ProjectDto? Project { get; set; }

    public ICollection<PaymentDto>? Payments { get; set; }
}
