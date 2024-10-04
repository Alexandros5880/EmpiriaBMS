using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmpiriaBMS.Core.Repositories;

public class DisciplineRepo : Repository<DisciplineDto, Discipline>, IDisposable
{
    public DisciplineRepo(
        IDbContextFactory<AppDbContext> DbFactory,
        Logging.LoggerManager logger
    ) : base(DbFactory, logger) { }

    public new async Task<DisciplineDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var disclipline = await _context
                             .Set<Discipline>()
                             .Where(r => !r.IsDeleted)
                             .Include(d => d.Type)
                             .Include(d => d.Project)
                             .FirstOrDefaultAsync(r => r.Id == id);

            return Mapping.Mapper.Map<DisciplineDto>(disclipline);
        }
    }

    public new async Task<ICollection<DisciplineDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Discipline> ds;
            if (pageSize == 0 || pageIndex == 0)
            {
                ds = await _context.Set<Discipline>()
                                   .Where(r => !r.IsDeleted)
                                   .Include(d => d.Type)
                                   .Include(d => d.Project)
                                   .ToListAsync();

                return Mapping.Mapper.Map<List<Discipline>, List<DisciplineDto>>(ds);
            }

            ds = await _context.Set<Discipline>()
                               .Where(r => !r.IsDeleted)
                               .Include(d => d.Type)
                               .Include(d => d.Project)
                               .Skip((pageIndex - 1) * pageSize)
                               .Take(pageSize)
                               .ToListAsync();

            return Mapping.Mapper.Map<List<Discipline>, List<DisciplineDto>>(ds);
        }
    }

    public new async Task<ICollection<DisciplineDto>> GetAll(
        Expression<Func<Discipline, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    )
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Discipline> ds;
            if (pageSize == 0 || pageIndex == 0)
            {
                ds = await _context.Set<Discipline>().Where(r => !r.IsDeleted)
                                   .Include(d => d.Type)
                                   .Include(d => d.Project)
                                   .Where(expresion)
                                   .ToListAsync();

                return Mapping.Mapper.Map<List<Discipline>, List<DisciplineDto>>(ds);
            }

            ds = await _context.Set<Discipline>().Where(r => !r.IsDeleted)
                               .Include(d => d.Type)
                               .Include(d => d.Project)
                               .Where(expresion)
                               .Skip((pageIndex - 1) * pageSize)
                               .Take(pageSize)
                               .ToListAsync();

            return Mapping.Mapper.Map<List<Discipline>, List<DisciplineDto>>(ds);
        }
    }

    public async new Task<DisciplineDto> Add(DisciplineDto entity, bool update = false)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.CreatedDate = update ? DateTime.Now.ToUniversalTime() : entity.CreatedDate;
            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var entry = Mapping.Mapper.Map<Discipline>(entity);
                var result = await _context.Set<Discipline>().AddAsync(entry);
                await _context.SaveChangesAsync();

                var id = result.Entity?.Id;
                if (id == null)
                    throw new NullReferenceException(nameof(id));

                var endry = await Get((int)id);

                return Mapping.Mapper.Map<DisciplineDto>(endry);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On DisciplineRepo.Add(Discipline): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return null;
        }
    }

    public async new Task<DisciplineDto> Update(DisciplineDto entity)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var entry = await Get(entity.Id);
                if (entry != null)
                {
                    _context.Entry(entry).CurrentValues.SetValues(Mapping.Mapper.Map<Discipline>(entity));
                    await _context.SaveChangesAsync();
                }

                return Mapping.Mapper.Map<DisciplineDto>(entry);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On DisciplineRepo.Update(Discipline): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return null;
        }
    }

    public async Task<List<DeliverableDto>> GetDraws(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var draws = await _context
                             .Set<Deliverable>()
                             .Where(r => !r.IsDeleted)
                             .Where(d => d.DisciplineId == id)
                             .Include(d => d.Type)
                             .ToListAsync();

            return Mapping.Mapper.Map<List<Deliverable>, List<DeliverableDto>>(draws);
        }
    }

    public async Task<List<DeliverableDto>> GetDraws(int id, int userId, bool all)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Deliverable> drawings;
            var disciplineDrawingsIds = await _context
                                         .Set<Deliverable>()
                                         .Where(r => !r.IsDeleted)
                                         .Where(d => d.DisciplineId == id)
                                         .Select(d => d.Id)
                                         .ToListAsync();
            if (all)
            {
                drawings = await _context.Set<Deliverable>()

                    .Where(r => !r.IsDeleted)
                                         .Where(d => disciplineDrawingsIds.Contains(d.Id))
                                         .Include(d => d.Type)
                                         .ToListAsync();
            }
            else
            {
                var deliverablesIds = await _context.Set<DeliverableEmployee>()
                                               .Where(r => !r.IsDeleted)
                                               .Where(de => disciplineDrawingsIds.Contains(de.DeliverableId))
                                               .Where(de => de.EmployeeId == userId)
                                               .Select(de => de.DeliverableId)
                                               .ToListAsync();

                drawings = await _context.Set<Deliverable>()
                                          .Where(r => !r.IsDeleted)
                                         .Where(d => deliverablesIds.Contains(d.Id))
                                         .Include(d => d.Type)
                                         .ToListAsync();
            }

            return Mapping.Mapper.Map<List<Deliverable>, List<DeliverableDto>>(drawings);
        }
    }

    public async Task<List<SupportiveWorkDto>> GetOthers(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var others = await _context
                             .Set<SupportiveWork>()
                             .Where(r => !r.IsDeleted)
                             .Where(d => d.DisciplineId == id)
                             .Include(d => d.Type)
                             .ToListAsync();

            return Mapping.Mapper.Map<List<SupportiveWork>, List<SupportiveWorkDto>>(others);
        }
    }

    public async Task<List<SupportiveWorkDto>> GetOthers(int id, int userId, bool all)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<SupportiveWork> others;
            var disciplineOthersIds = await _context
                                         .Set<SupportiveWork>()
                                         .Where(r => !r.IsDeleted)
                                         .Where(d => d.DisciplineId == id)
                                         .Select(d => d.Id)
                                         .ToListAsync();
            if (all)
            {
                others = await _context.Set<SupportiveWork>()
                                       .Where(r => !r.IsDeleted)
                                       .Where(o => disciplineOthersIds.Contains(o.Id))
                                       .Include(d => d.Type)
                                       .ToListAsync();
            }
            else
            {
                var otherIds = await _context.Set<SupportiveWorkEmployee>()
                                             .Where(r => !r.IsDeleted)
                                             .Where(de => disciplineOthersIds.Contains(de.SupportiveWorkId))
                                             .Where(de => de.EmployeeId == userId)
                                             .Select(de => de.SupportiveWorkId)
                                             .ToListAsync();

                others = await _context.Set<SupportiveWork>()
                                       .Where(r => !r.IsDeleted)
                                       .Where(o => otherIds.Contains(o.Id))
                                       .Include(d => d.Type)
                                       .ToListAsync();
            }

            var result = Mapping.Mapper.Map<List<SupportiveWork>, List<SupportiveWorkDto>>(others);

            return result.OrderBy(d => d.Type?.Name).ToList();
        }
    }

    public async Task<long> GetMenHoursAsync(int disciplineId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context.Set<DailyTime>()
                                 .Where(r => !r.IsDeleted)
                                 .Where(mh => mh.DisciplineId == disciplineId)
                                 .Select(mh => mh.Hours)
                                 .SumAsync();
        }
    }

    public long GetMenHours(int disciplineId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return _context.Set<DailyTime>()
                           .Where(r => !r.IsDeleted)
                           .Where(mh => mh.DisciplineId == disciplineId)
                           .Select(mh => mh.Hours)
                           .Sum();
        }
    }

    public async Task<ICollection<UserDto>> GetEngineers(int disciplineId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var users = await _context.Set<DisciplineEngineer>()
                                      .Where(r => !r.IsDeleted)
                                      .Where(de => de.DisciplineId == disciplineId)
                                      .Include(de => de.Engineer)
                                      .Select(de => de.Engineer)
                                      .ToListAsync();

            return Mapping.Mapper.Map<List<UserDto>>(users);
        }
    }

    public async Task AddEngineers(int disciplineId, ICollection<UserDto> engineers)
    {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                foreach (var e in engineers)
                {
                    DisciplineEngineer de = new DisciplineEngineer()
                    {
                        CreatedDate = DateTime.Now,
                        LastUpdatedDate = DateTime.Now,
                        DisciplineId = disciplineId,
                        EngineerId = e.Id
                    };

                    // Check If Exists
                    var exists = await _context.Set<DisciplineEngineer>()
                        .AnyAsync(de => de.DisciplineId == disciplineId && de.EngineerId == e.Id);
                    if (exists)
                    {
                        var discEng = await _context.Set<DisciplineEngineer>()
                            .FirstOrDefaultAsync(de => de.DisciplineId == disciplineId && de.EngineerId == e.Id);

                        if (discEng?.IsDeleted ?? false)
                        {
                            discEng.IsDeleted = false;
                            await _context.SaveChangesAsync();
                        }

                        continue;
                    }

                    await _context.Set<DisciplineEngineer>().AddAsync(de);
                    await _context.SaveChangesAsync();
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On DisciplineRepo.AddEngineers(int disciplineId, ICollection<UserDto> engineers): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    public async Task RemoveEngineers(int disciplineId, ICollection<int> engineersIds)
    {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var engineers = await _context.Set<DisciplineEngineer>()
                                              .Where(r => !r.IsDeleted)
                                              .Where(d => engineersIds.Contains(d.EngineerId)
                                                                    && d.DisciplineId == disciplineId)
                                              .ToListAsync();

                if (engineers == null)
                    throw new NullReferenceException(nameof(engineers));

                foreach (var engineer in engineers)
                {
                    await DeleteDisciplineEngineer(engineer);
                    //_context.Set<DisciplineEngineer>().Remove(engineer);
                }

                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On DisciplineRepo.RemoveEngineers(int disciplineId, ICollection<int> engineersIds): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    public async Task<DisciplineEngineer> DeleteDisciplineEngineer(DisciplineEngineer entity)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var entry = await _context.Set<DisciplineEngineer>().FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (entry != null)
                {
                    entry.IsDeleted = true;
                    await _context.SaveChangesAsync();
                }

                return entry;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On DisciplineRepo.DeleteDisciplineEngineer({Mapping.Mapper.Map<DisciplineEngineerDto>(entity).GetType()}): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return null;
        }
    }
}
