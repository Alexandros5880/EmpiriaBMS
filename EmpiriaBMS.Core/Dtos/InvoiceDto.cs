using EmpiriaMS.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaBMS.Models.Enum;

namespace EmpiriaBMS.Core.Dtos;

public class InvoiceDto : EntityDto
{
    public double? Total { get; set; }

    public double? Vat { get; set; }

    public double? Fee { get; set; }

    public int? Number { get; set; }

    public string? Mark { get; set; }

    public DateTime Date { get; set; }

    public InvoiceType Type { get; set; }

    public int ProjectId { get; set; }

    public Project Project { get; set; }

    public ICollection<Payment> Payments { get; set; }
}
