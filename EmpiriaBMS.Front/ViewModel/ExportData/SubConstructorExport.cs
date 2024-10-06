using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class SubConstructorExport : IInport<SubConstructorVM>
{
    public string Name { get; set; }

    public SubConstructorExport(SubConstructorVM model)
    {
        Name = model.Name;
    }

    public SubConstructorExport()
    {

    }

    public SubConstructorVM Get() => new SubConstructorVM()
    {
        Name = Name
    };

}
