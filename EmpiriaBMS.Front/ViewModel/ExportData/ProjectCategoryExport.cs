using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class ProjectCategoryExport : IInport<ProjectCategoryVM>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public ProjectCategoryExport(ProjectCategoryVM model)
    {
        Name = model.Name ?? "";
        Description = model.Description ?? "";
    }

    public ProjectCategoryExport()
    {

    }

    public ProjectCategoryVM Get() => new ProjectCategoryVM()
    {
        Name = Name,
        Description = Description
    };
}
