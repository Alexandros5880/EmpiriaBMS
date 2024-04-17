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
    public DateTime? EstimatedDate { get; set; }

    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime PaymentDate { get; set; }

    public string? Bank { get; set; }

    public double PaidFee { get; set; }

    [Required]
    public double Fee { get; set; }

    public string? Description { get; set; }

    [Required]
    public int TypeId { get; set; }
    public PaymentType Type { get; set; }

    [Required]
    public int InvoiceId { get; set; }

    public Invoice Invoice { get; set; }
}
