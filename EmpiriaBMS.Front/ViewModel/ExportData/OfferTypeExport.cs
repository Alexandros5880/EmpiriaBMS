using EmpiriaBMS.Front.ViewModel.Components;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class OfferTypeExport
{
    public string Name { get; set; }

    public string Description { get; set; }

    public OfferTypeExport(OfferTypeVM model)
    {
        Name = model.Name;
        Description = model.Description ?? "";
    }
}
