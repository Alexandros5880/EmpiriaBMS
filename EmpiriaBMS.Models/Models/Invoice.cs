using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Models.Models;
public class Invoice : Entity
{
    [Required]
    public int TypeId { get; set; }
    public InvoiceType Type { get; set; }

    public double? Total { get; set; }

    public double? Vat { get; set; }

    public double? Fee { get; set; }

    public int? Number { get; set; }

    public string? Mark { get; set; }

    public int ProjectId { get; set; }

    public Project Project { get; set; }

    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime Date { get; set; }

    public ICollection<Payment> Payments { get; set; }
}
