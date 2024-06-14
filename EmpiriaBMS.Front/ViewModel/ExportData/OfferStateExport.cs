using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class OfferStateExport : IInport<OfferStateVM>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public OfferStateExport(OfferStateVM model)
    {
        Name = model.Name;
        Description = model.Description ?? "";
    }

    public OfferStateExport()
    {

    }

    public OfferStateVM Get() => new OfferStateVM()
    {
        Name = Name,
        Description = Description,
    };
}
