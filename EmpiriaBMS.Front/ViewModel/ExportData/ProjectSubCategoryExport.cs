﻿using EmpiriaBMS.Front.ViewModel.Components;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class ProjectSubCategoryExport
{
    public string Name { get; set; }

    public string Description { get; set; }

    public bool CanAssignePM { get; set; }

    public ProjectSubCategoryExport(ProjectSubCategoryVM model)
    {
        Name = model.Name ?? "";
        Description = model.Description ?? "";
        CanAssignePM = model.CanAssignePM;
    }
}