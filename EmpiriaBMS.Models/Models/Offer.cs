using EmpiriaBMS.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpiriaBMS.Models.Models;

public class Offer : Entity
{
    [Required]
    public long TypeId { get; set; }
    public OfferType Type { get; set; }

    [Required]
    public long StateId { get; set; }
    public OfferState State { get; set; }

    public long? CategoryId { get; set; }
    public ProjectCategory Category { get; set; }

    public long? SubCategoryId { get; set; }
    public ProjectSubCategory SubCategory { get; set; }

    public long? ClientId { get; set; }
    public Client? Client { get; set; }

    public long? ProjectId { get; set; }
    public Project? Project { get; set; }

    [Required]
    public OfferResult Result { get; set; }

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

    public ICollection<DailyTime>? DailyTime { get; set; }
}
