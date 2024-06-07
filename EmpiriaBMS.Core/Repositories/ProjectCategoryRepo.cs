using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpiriaBMS.Core.Repositories;

public class ProjectCategoryRepo : Repository<ProjectCategoryDto, ProjectCategory>, IDisposable
{
    public ProjectCategoryRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }
}
