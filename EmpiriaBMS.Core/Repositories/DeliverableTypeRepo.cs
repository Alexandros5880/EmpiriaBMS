using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpiriaBMS.Core.Repositories;

public class DeliverableTypeRepo : Repository<DeliverableTypeDto, DeliverableType>, IDisposable
{
    public DeliverableTypeRepo(
        IDbContextFactory<AppDbContext> DbFactory,
        Logging.LoggerManager logger
    ) : base(DbFactory, logger) { }

    public async Task<List<DeliverableTypeDto>> GetDrawingTypesSelections(int disciplineId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            try
            {
                if (disciplineId == 0)
                {
                    var noDrawingTypes = await _context.Set<DeliverableType>()
                                                       .Where(r => !r.IsDeleted)
                                                       .ToListAsync();

                    return Mapping.Mapper.Map<List<DeliverableTypeDto>>(noDrawingTypes);
                }
                else
                {
                    var noDrawingTypesIds = await _context.Set<Deliverable>()
                                                          .Where(r => !r.IsDeleted)
                                                          .Where(d => d.DisciplineId == disciplineId)
                                                          .Select(d => d.TypeId)
                                                          .ToListAsync();

                    if (noDrawingTypesIds == null)
                        throw new NullReferenceException(nameof(noDrawingTypesIds));

                    if (noDrawingTypesIds.Count() == 0)
                    {
                        var allDrawingTypes = await _context.Set<DeliverableType>()
                                                            .Where(r => !r.IsDeleted)
                                                            .ToListAsync();

                        return Mapping.Mapper.Map<List<DeliverableTypeDto>>(allDrawingTypes);
                    }

                    var noDrawingTypes = await _context.Set<DeliverableType>()
                                                       .Where(r => !r.IsDeleted)
                                                       .Where(t => !noDrawingTypesIds.Contains(t.Id))
                                                       .ToListAsync();

                    return Mapping.Mapper.Map<List<DeliverableTypeDto>>(noDrawingTypes);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception On DeliverableTypeRepo.GetDrawingTypesSelections(int disciplineId): {ex.Message}, \nInner: {ex.InnerException?.Message}");
                return default(List<DeliverableTypeDto>)!;
            }
        }
    }

    public async Task<bool> HasDeliverableTypesSelections(int disciplineId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (disciplineId == 0)
                throw new ArgumentNullException(nameof(disciplineId));

            var noDrawingTypesIds = await _context.Set<Deliverable>()
                                                  .Where(r => !r.IsDeleted)
                                                  .Where(d => d.DisciplineId == disciplineId)
                                                  .Select(d => d.TypeId)
                                                  .ToListAsync();

            if (noDrawingTypesIds == null)
                throw new NullReferenceException(nameof(noDrawingTypesIds));

            var result = await _context.Set<DeliverableType>()
                                       .Where(r => !r.IsDeleted)
                                       .AnyAsync(t => !noDrawingTypesIds.Contains(t.Id));

            return result;
        }
    }
}

