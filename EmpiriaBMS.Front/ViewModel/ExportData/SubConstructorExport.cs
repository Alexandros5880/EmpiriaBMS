using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class SubConstructorExport : IInport<SubConstructorVM>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Phone { get; set; }

    public SubConstructorExport(SubConstructorVM model)
    {
        Name = model.Name;
        Description = model.Description;
        Phone = model.Phone;
    }

    public SubConstructorExport()
    {

    }

    public SubConstructorVM Get() => new SubConstructorVM()
    {
        Name = Name,
        Description = Description,
        Phone = Phone
    };

}
