using EmpiriaBMS.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpiriaBMS.Models.Models;
public class Invoice : Entity
{
    [Required]
    public int TypeId { get; set; }
    public InvoiceType Type { get; set; }

    public double? Total { get; set; }

    public Vat Vat { get; set; }

    public double? Fee { get; set; }

    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime? EstimatedDate { get; set; }

    public int? Number { get; set; }

    public string? Mark { get; set; }

    public int? ContractId { get; set; }

    public Contract? Contract { get; set; }

    public int ProjectId { get; set; }

    public Project Project { get; set; }

    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime Date { get; set; }

    public ICollection<Payment> Payments { get; set; }
}
