using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class SupportiveWorkTypeExport : IInport<SupportiveWorkTypeVM>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public SupportiveWorkTypeExport(SupportiveWorkTypeVM model)
    {
        Name = model.Name ?? "";
        Description = model.Description ?? "";
    }

    public SupportiveWorkTypeExport()
    {

    }

    public SupportiveWorkTypeVM Get() => new SupportiveWorkTypeVM()
    {
        Name = Name,
        Description = Description,
    };
}
