using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class PermissionExport : IInport<PermissionVM>
{
    public string Name { get; set; }

    public int Ord { get; set; }

    public PermissionExport(PermissionVM model)
    {
        Name = model.Name;
        Ord = model.Ord;
    }

    public PermissionExport()
    {

    }

    public PermissionVM Get() => new PermissionVM()
    {
        Name = Name,
        Ord = Ord,
    };
}
