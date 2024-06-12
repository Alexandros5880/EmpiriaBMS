using EmpiriaBMS.Front.ViewModel.Components;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class PermissionExport
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
}
