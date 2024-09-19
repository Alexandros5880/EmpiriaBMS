using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class RoleExport : IInport<RoleVM>
{
    public string Name { get; set; }

    public bool IsEmployee { get; set; }

    public bool IsEditable { get; set; }

    public int ParentRoleId { get; set; }

    public RoleExport(RoleVM model)
    {
        Name = model.Name ?? "";
        IsEmployee = model.IsEmployee;
        IsEditable = model.IsEditable;
        ParentRoleId = model.ParentRoleId ?? 0;
    }

    public RoleExport()
    {

    }

    public RoleVM Get() => new RoleVM()
    {
        Name = Name,
        IsEmployee = IsEmployee,
        IsEditable = IsEditable,
        ParentRoleId = ParentRoleId
    };
}
