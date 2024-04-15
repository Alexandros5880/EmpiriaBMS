using EmpiriaBMS.Models.Models;
using EmpiriaBMS.Core.Dtos.Base;

namespace EmpiriaBMS.Core.Dtos;

public class OfferDto : EntityDto
{
    public int TypeId { get; set; }
    public OfferType Type { get; set; }


    public int StateId { get; set; }
    public OfferState State { get; set; }


    public string Code { get; set; }

    public DateTime? Date { get; set; }

    public string? Description { get; set; }

    public double? PudgetPrice { get; set; }

    public double? OfferPrice { get; set; }

    public string? Observations { get; set; }

    public string? TeamText { get; set; }

    public string? Comments { get; set; }
}
