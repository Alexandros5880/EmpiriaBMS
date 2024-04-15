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
    public DateTime? EstimatedDate { get; set; }

    public DateTime PaymentDate { get; set; }

    public string? Bank { get; set; }

    public double PaidFee { get; set; }

    public double Fee { get; set; }

    public string? Description { get; set; }

    public int TypeId { get; set; }
    public PaymentType Type { get; set; }

    public int InvoiceId { get; set; }

    public Invoice Invoice { get; set; }
}
