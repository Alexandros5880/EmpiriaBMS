using EmpiriaBMS.Front.ViewModel.Components;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class RoleExport
{
    public string? Name { get; set; }

    public bool IsEmployee { get; set; }

    public bool IsEditable { get; set; }

    public RoleExport(RoleVM model)
    {
        Name = model.Name ?? "";
        IsEmployee = model.IsEmployee;
        IsEditable = model.IsEditable;
    }

    public RoleExport()
    {

    }
}
