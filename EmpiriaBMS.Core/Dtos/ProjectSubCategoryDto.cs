﻿using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Core.Dtos;

public class ProjectSubCategoryDto : EntityDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public long? CategoryId { get; set; }
    public ProjectCategory Category { get; set; }

    public ICollection<Project> Projects { get; set; }

    public ICollection<Offer> Offers { get; set; }
}
