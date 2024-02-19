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

public class InvoiceDto : EntityDto
{
    public double? Total { get; set; }

    public double? Vat { get; set; }

    public double? Fee { get; set; }

    public int? Number { get; set; }

    public string? Mark { get; set; }

    public DateTime Date { get; set; }

    public int? ProjectId { get; set; }
    public Project? Project { get; set; }
}
