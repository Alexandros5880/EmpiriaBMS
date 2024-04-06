using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpiriaMS.Models.Models.Base;
using EmpiriaMS.Models.Models;

namespace EmpiriaBMS.Models.Models;

public class Payment : Entity
{
    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime? EstPaymentDate { get; set; }

    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime? PaymentDate { get; set; }

    public int? DelayInPayment { get; set; }

    public string? PaymentDetails { get; set; }

    public double? DayCost { get; set; }

    public string? Bank { get; set; }

    public int? DaysUntilPayment { get; set; }

    public double? PendingPayments { get; set; }

    public int InvoiceId { get; set; }

    public Invoice Invoice { get; set; }
}
