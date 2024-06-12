using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class SupportiveWorkTypeExport : IInport<OtherTypeVM>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public SupportiveWorkTypeExport(OtherTypeVM model)
    {
        Name = model.Name ?? "";
        Description = model.Description ?? "";
    }

    public SupportiveWorkTypeExport()
    {

    }

    public OtherTypeVM Get() => new OtherTypeVM()
    {
        Name = Name,
        Description = Description,
    };
}
