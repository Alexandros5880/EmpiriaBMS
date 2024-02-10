using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpiriaMS.Models.Models.Base;
using EmpiriaMS.Models.Enums;

namespace EmpiriaMS.Models.Models;
public class Project : Entity
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public string? Code { get; set; }

    public string? Drawing { get; set; }

    public PlanType PlanType { get; set; }

    public int? WorkingDays { get; set; }

    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime? DurationDate { get; set; }

    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime? EstPaymentDate { get; set; }

    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime? PaymentDate { get; set; }

    public int? DelayInPayment { get; set; }

    public string? PaymentDetailes { get; set; }

    public double? DayCost { get; set; }

    public string? Bank { get; set; }

    public double? PaidFee { get; set; }

    public int? DaysUntilPayment { get; set; }

    public double? PendingPayments { get; set; }

    public int? CalculationDaly { get; set; }

    public int Completed { get; set; }

    public int ManHours { get; set; }

    [ForeignKey("Customer")]
    public required string CustomerId { get; set; }
    public required Customer Customer { get; set; }

    [ForeignKey("Invoice")]
    public string? InvoiceId { get; set; }
    public Invoice? Invoice { get; set; }

    public required IEnumerable<Employee> Employees { get; set; }
}