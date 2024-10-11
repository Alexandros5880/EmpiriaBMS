using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpiriaBMS.Core.Repositories;

public class SupportiveWorkTypeRepo : Repository<SupportiveWorkTypeDto, SupportiveWorkType>, IDisposable
{
    public SupportiveWorkTypeRepo(
        IDbContextFactory<AppDbContext> DbFactory,
        Logging.LoggerManager logger
    ) : base(DbFactory, logger) { }

    public async Task<List<SupportiveWorkTypeDto>> GetOtherTypesSelections(long disciplineId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (disciplineId == 0)
            {
                var noOtherTypes = await _context.Set<SupportiveWorkType>()
                                                 .Where(r => !r.IsDeleted)
                                                 .ToListAsync();

                return Mapping.Mapper.Map<List<SupportiveWorkTypeDto>>(noOtherTypes);
            }
            else
            {
                var noOtherTypesIds = await _context.Set<SupportiveWork>()
                                                    .Where(r => !r.IsDeleted)
                                                    .Where(d => d.DisciplineId == disciplineId)
                                                    .Select(d => d.TypeId)
                                                    .ToListAsync();

                if (noOtherTypesIds == null)
                    throw new NullReferenceException(nameof(noOtherTypesIds));

                if (noOtherTypesIds.Count() == 0)
                {
                    var allOtherTypes = await _context.Set<SupportiveWorkType>()
                                                      .Where(r => !r.IsDeleted)
                                                      .ToListAsync();

                    return Mapping.Mapper.Map<List<SupportiveWorkTypeDto>>(allOtherTypes);
                }

                var noOtherTypes = await _context.Set<SupportiveWorkType>()
                                                 .Where(r => !r.IsDeleted)
                                                 .Where(t => !noOtherTypesIds.Contains(t.Id))
                                                 .ToListAsync();

                return Mapping.Mapper.Map<List<SupportiveWorkTypeDto>>(noOtherTypes);
            }
        }
    }

    public async Task<bool> HasOtherTypesSelections(long disciplineId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (disciplineId == 0)
                throw new ArgumentNullException(nameof(disciplineId));

            var noOtherTypesIds = await _context.Set<SupportiveWork>()
                                                .Where(r => !r.IsDeleted)
                                                .Where(d => d.DisciplineId == disciplineId)
                                                .Select(d => d.TypeId)
                                                .ToListAsync();

            if (noOtherTypesIds == null)
                throw new NullReferenceException(nameof(noOtherTypesIds));

            var result = await _context.Set<SupportiveWorkType>()
                                       .Where(r => !r.IsDeleted)
                                       .AnyAsync(t => !noOtherTypesIds.Contains(t.Id));

            return result;
        }
    }
}
