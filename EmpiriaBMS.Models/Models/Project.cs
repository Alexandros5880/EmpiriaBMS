using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpiriaMS.Models.Models.Base;
using EmpiriaBMS.Models.Models;

namespace EmpiriaMS.Models.Models;
public class Project : Entity
{
    [Required]
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Code { get; set; }

    public long EstimatedMandays { get; set; }

    public long EstimatedHours { get; set; }

    public float EstimatedCompleted { get; set; }

    public float Completed { get; set; }

    public float WorkPackegedCompleted { get; set; }

    public bool Active { get; set; }

    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime? DeadLine { get; set; }

    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime? WorkPackege { get; set; }

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

    public int TypeId { get; set; }
    public ProjectType Type { get; set; }

    public int? SubContractorId { get; set; }
    public User? SubContractor { get; set; }

    public User? Customer { get; set; }

    public Invoice? Invoice { get; set; }

    public ICollection<DailyTime> DailyTime { get; set; }

    public ICollection<Discipline> Disciplines { get; set; }

    public ICollection<ProjectPmanager> ProjectsPmanagers { get; set; }

    public ICollection<Complain> Complains { get; set; }
}