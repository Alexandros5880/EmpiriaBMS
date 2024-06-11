using EmpiriaBMS.Front.ViewModel.Components;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class OfferStateExport
{
    public string Name { get; set; }

    public string Description { get; set; }

    public OfferStateExport(OfferStateVM model)
    {
        Name = model.Name;
        Description = model.Description ?? "";
    }
}
