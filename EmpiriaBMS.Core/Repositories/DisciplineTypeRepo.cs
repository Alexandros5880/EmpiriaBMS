using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpiriaBMS.Core.Repositories;

public class DisciplineTypeRepo : Repository<DisciplineTypeDto, DisciplineType>, IDisposable
{
    public DisciplineTypeRepo(
        IDbContextFactory<AppDbContext> DbFactory,
        Logging.LoggerManager logger
    ) : base(DbFactory, logger) { }

    public async Task<bool> HasDisciplineTypesSelections(long projectId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (projectId == 0)
                throw new ArgumentNullException(nameof(projectId));

            var disciplineTypesIds = await _context.Set<Discipline>()
                                                   .Where(r => !r.IsDeleted)
                                                   .Where(d => d.ProjectId == projectId)
                                                   .Select(d => d.TypeId)
                                                   .ToListAsync();

            if (disciplineTypesIds == null)
                throw new NullReferenceException(nameof(disciplineTypesIds));

            var result = await _context.Set<DisciplineType>()
                                       .Where(r => !r.IsDeleted)
                                       .AnyAsync(t => !disciplineTypesIds.Contains(t.Id));

            return result;
        }
    }
}
