using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Enum;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Core.Dtos;

public class OfferDto : EntityDto
{
    public long TypeId { get; set; }
    public OfferType Type { get; set; }

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

    public OfferResult Result { get; set; }

    public string Code { get; set; }

    public DateTime? Date { get; set; }

    public string? Description { get; set; }

    public double? PudgetPrice { get; set; }

    public double? OfferPrice { get; set; }

    public string? Observations { get; set; }

    public string? TeamText { get; set; }

    public string? Comments { get; set; }

    public ICollection<DailyTime> DailyTime { get; set; }
}
