using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Enum;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Core.Dtos;

public class OfferDto : EntityDto
{
    public int TypeId { get; set; }
    public OfferType Type { get; set; }

    public int StateId { get; set; }
    public OfferState State { get; set; }

    public int? CategoryId { get; set; }
    public ProjectCategory Category { get; set; }

    public int? SubCategoryId { get; set; }
    public ProjectSubCategory SubCategory { get; set; }

    public int? LeadId { get; set; }
    public Lead? Lead { get; set; }

    public OfferResult Result { get; set; }

    public string Code { get; set; }

    public DateTime? Date { get; set; }

    public string? Description { get; set; }

    public double? PudgetPrice { get; set; }

    public double? OfferPrice { get; set; }

    public string? Observations { get; set; }

    public string? TeamText { get; set; }

    public string? Comments { get; set; }

    public ICollection<Project>? Projects { get; set; }

    public ICollection<DailyTime> DailyTime { get; set; }
}
