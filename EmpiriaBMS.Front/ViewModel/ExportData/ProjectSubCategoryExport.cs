using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class ProjectSubCategoryExport : IInport<ProjectSubCategoryVM>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public bool CanAssignePM { get; set; }

    public long CategoryId { get; set; }

    public string CategoryName { get; set; }

    public ProjectSubCategoryExport(ProjectSubCategoryVM model)
    {
        Name = model.Name ?? "";
        Description = model.Description ?? "";
        CategoryId = model.CategoryId ?? 0;
        CategoryName = model.Category?.Name ?? "";
    }
    public ProjectSubCategoryExport()
    {

    }

    public ProjectSubCategoryVM Get() => new ProjectSubCategoryVM()
    {
        Name = Name,
        Description = Description,
        CategoryId = CategoryId
    };
}
