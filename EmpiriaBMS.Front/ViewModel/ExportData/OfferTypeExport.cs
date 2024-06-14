using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class OfferTypeExport : IInport<OfferTypeVM>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public OfferTypeExport(OfferTypeVM model)
    {
        Name = model.Name;
        Description = model.Description ?? "";
    }

    public OfferTypeExport()
    {

    }

    public OfferTypeVM Get() => new OfferTypeVM()
    {
        Name = Name,
        Description = Description,
    };
}
