using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpiriaBMS.Models.Models;

public class Offer : Entity
{
    [Required]
    public int TypeId { get; set; }
    public OfferType Type { get; set; }

    [Required]
    public int StateId { get; set; }
    public OfferState State { get; set; }

    [Required]
    public string Code { get; set; }

    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime? Date { get; set; }

    public double? PudgetPrice { get; set; }

    public double? OfferPrice { get; set; }

    public string? Description { get; set; }

    public string? Observations { get; set; }

    public string? TeamText { get; set; }

    public string? Comments { get; set; }

    public int? ProjectId { get; set; }

    public Project? Project { get; set; }
}
