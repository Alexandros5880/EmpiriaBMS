using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaMS.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Core.Dtos;

public class PaymentDto : EntityDto
{
    public DateTime? EstPaymentDate { get; set; }

    public DateTime? PaymentDate { get; set; }

    public int? DelayInPayment { get; set; }

    public string? PaymentDetails { get; set; }

    public double? DayCost { get; set; }

    public string? Bank { get; set; }

    public int? DaysUntilPayment { get; set; }

    public double? PendingPayments { get; set; }

    public ICollection<InvoicePayment> InvoicesPayments { get; set; }
}
