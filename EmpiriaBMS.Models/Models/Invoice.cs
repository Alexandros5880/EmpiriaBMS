﻿using EmpiriaBMS.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpiriaBMS.Models.Models;
public class Invoice : Entity
{
    [Required]
    public InvoiceCategory Category { get; set; }

    [Required]
    public long TypeId { get; set; }
    public InvoiceType? Type { get; set; }

    public long? ExpensesTypeId { get; set; }
    public ExpensesType? ExpensesType { get; set; }

    public int Vat { get; set; }

    public double Fee { get; set; }

    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime? EstimatedPayment { get; set; }

    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime ActualPayment { get; set; }

    public int? InvoiceNumber { get; set; }

    public string? Mark { get; set; }

    public long ProjectId { get; set; }

    public Project? Project { get; set; }

    public ICollection<Payment>? Payments { get; set; }
}
