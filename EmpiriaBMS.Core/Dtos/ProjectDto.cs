using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpiriaBMS.Core.Dtos.Base;

namespace EmpiriaBMS.Core.Dtos;

public class ProjectDto : EntityDto
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Code { get; set; }

    public string? Drawing { get; set; }

    public long? EstimatedMandays { get; set; }

    public long? EstimatedHours { get; set; }

    public DateTime? DurationDate { get; set; }

    public DateTime? EstPaymentDate { get; set; }

    public DateTime? PaymentDate { get; set; }

    public int? DelayInPayment { get; set; }

    public string? PaymentDetailes { get; set; }

    public double? DayCost { get; set; }

    public string? Bank { get; set; }

    public double? PaidFee { get; set; }

    public int? DaysUntilPayment { get; set; }

    public double? PendingPayments { get; set; }

    public int? CalculationDaly { get; set; }

    public int? Completed { get; set; }

    public long? ManHours { get; set; }

    public User? Customer { get; set; }

    public Invoice? Invoice { get; set; }
}
