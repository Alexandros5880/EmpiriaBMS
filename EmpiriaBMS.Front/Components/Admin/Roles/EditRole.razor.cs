using EmpiriaBMS.Front.ViewModel.Components;

namespace EmpiriaBMS.Front.Components.Admin.Roles;

public partial class EditRole
{
    private RoleVM _role = new RoleVM();

    private void Save()
    {
        Console.WriteLine($"Name: {_role.Name}");
        Console.WriteLine($"IsEmployee: {_role.IsEmployee}");
    }
}
