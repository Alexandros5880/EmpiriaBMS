using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpiriaMS.Models.Models.Base;

namespace EmpiriaMS.Models.Models;
public class Invoice : Entity
{
    public double? Total { get; set; }

    public double? Vat { get; set; }

    public double? Fee { get; set; }

    public int? Number { get; set; }

    public string? Mark { get; set; }

    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime Date { get; set; }

    [ForeignKey("Project")]
    public string? ProjectId { get; set; }
    public Project? Project { get; set; }

    public Invoice()
    {
        Total = 0.0;
        Vat = 0.0;
        Fee = 0.0;
        Number = 0;
        Mark = string.Empty;
        Date = DateTime.Now;
    }

    public void SetValues(Invoice entity)
    {
        Total = entity.Total;
        Vat = entity.Vat;
        Fee = entity.Fee;
        Number = entity.Number;
        Mark = entity.Mark;
        Date = entity.Date;
    }
}
