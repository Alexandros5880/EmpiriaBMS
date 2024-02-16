using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpiriaMS.Models.Models.Base;
using EmpiriaMS.Models.Enums;
using EmpiriaBMS.Models.Models;

namespace EmpiriaMS.Models.Models;
public class Project : Entity
{
    [Required]
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Code { get; set; }

    public string? Drawing { get; set; }

    [Required]
    public PlanTypes PlanType { get; set; }

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

    [Range(0, 100)]
    public int? Completed { get; set; }

    public int? ManHours { get; set; }

    [ForeignKey("Customer")]
    public string? CustomerId { get; set; }
    public User? Customer { get; set; }

    [ForeignKey("Invoice")]
    public string? InvoiceId { get; set; }
    public Invoice? Invoice { get; set; }

    public Project()
    {
        Name = string.Empty;
        Description = string.Empty;
        Code = string.Empty;
        Drawing = string.Empty;
        PlanType = PlanTypes.ELEC;
        WorkingDays = null;
        DurationDate = DateTime.Now.AddYears(1);
        EstPaymentDate = DateTime.Now.AddYears(1);
        PaymentDate = DateTime.Now.AddYears(1);
        DelayInPayment = 0;
        PaymentDetailes = string.Empty;
        DayCost = 0.0;
        Bank = string.Empty;
        PaidFee = 0.0;
        DaysUntilPayment = 0;
        PendingPayments = 0;
        CalculationDaly = 0;
        Completed = 0;
        ManHours = 0;
    }

    public void SetValues(Project entity)
    {
        Name = entity.Name;
        Description = entity.Description;
        Code = entity.Code;
        Drawing = entity.Drawing;
        PlanType = entity.PlanType;
        WorkingDays = entity.WorkingDays;
        DurationDate = entity.DurationDate;
        EstPaymentDate = entity.EstPaymentDate;
        PaymentDate = entity.PaymentDate;
        DelayInPayment = entity.DelayInPayment;
        PaymentDetailes = entity.PaymentDetailes;
        DayCost = entity.DayCost;
        Bank = entity.Bank;
        PaidFee = entity.PaidFee;
        DaysUntilPayment = entity.DaysUntilPayment;
        PendingPayments = entity.PendingPayments;
        CalculationDaly = entity.CalculationDaly;
        Completed = entity.Completed;
        ManHours = entity.ManHours;
        CustomerId = entity.CustomerId;
        Customer = entity.Customer;
        InvoiceId = entity.InvoiceId;
        Invoice = entity.Invoice;
    }
}