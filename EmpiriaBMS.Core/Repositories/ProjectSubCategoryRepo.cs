using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpiriaBMS.Core.Repositories;

public class ProjectSubCategoryRepo : Repository<ProjectSubCategoryDto, ProjectSubCategory>
{
    public ProjectSubCategoryRepo(
        IDbContextFactory<AppDbContext> DbFactory,
        Logging.LoggerManager logger
    ) : base(DbFactory, logger) { }

    public async Task<ICollection<ProjectSubCategoryDto>> GetAll(int parentId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<ProjectSubCategory> items;

            items = await _context.Set<ProjectSubCategory>()
                                  .Where(r => !r.IsDeleted)
                                  .Where(p => p.CategoryId == parentId)
                                  .ToListAsync();

            return Mapping.Mapper.Map<List<ProjectSubCategoryDto>>(items);
        }
    }
}
