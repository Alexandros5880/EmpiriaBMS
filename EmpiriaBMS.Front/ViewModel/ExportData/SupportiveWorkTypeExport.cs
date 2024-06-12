using EmpiriaBMS.Front.ViewModel.Components;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class SupportiveWorkTypeExport
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
}
