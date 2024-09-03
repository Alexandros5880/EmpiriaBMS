using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Models.Models;

public class Payment : Entity
{
    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime PaymentDate { get; set; }

    public string? Bank { get; set; }

    [Required]
    public double Fee { get; set; }

    public string? Description { get; set; }

    [Required]
    public int TypeId { get; set; }
    public PaymentType? Type { get; set; }

    [Required]
    public int InvoiceId { get; set; }

    public Invoice? Invoice { get; set; }
}
