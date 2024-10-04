using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmpiriaBMS.Core.Repositories;

public class SupportiveWorkRepo : Repository<SupportiveWorkDto, SupportiveWork>, IDisposable
{
    public SupportiveWorkRepo(
        IDbContextFactory<AppDbContext> DbFactory,
        Logging.LoggerManager logger
    ) : base(DbFactory, logger) { }

    public new async Task<SupportiveWorkDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var dr = await _context
                             .Set<SupportiveWork>()
                             .Where(r => !r.IsDeleted)
                             .Include(d => d.Type)
                             .Include(d => d.Discipline)
                             .ThenInclude(d => d.Type)
                             .Include(d => d.Discipline)
                             .ThenInclude(dis => dis.Project)
                             .Include(o => o.Discipline)
                             .ThenInclude(d => d.Type)
                             .FirstOrDefaultAsync(r => r.Id == id);

            return Mapping.Mapper.Map<SupportiveWorkDto>(dr);
        }
    }

    public new async Task<ICollection<SupportiveWorkDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<SupportiveWork> drs;

            if (pageSize == 0 || pageIndex == 0)
            {
                drs = await _context.Set<SupportiveWork>()
                                    .Where(r => !r.IsDeleted)
                                    .Include(d => d.Type)
                                    .Include(d => d.Discipline)
                                    .ThenInclude(d => d.Type)
                                    .Include(d => d.Discipline)
                                    .ThenInclude(dis => dis.Project)
                                    .Include(o => o.Discipline)
                                    .ThenInclude(d => d.Type)
                                    .ToListAsync();

                return Mapping.Mapper.Map<List<SupportiveWork>, List<SupportiveWorkDto>>(drs);
            }


            drs = await _context.Set<SupportiveWork>()
                                .Where(r => !r.IsDeleted)
                                .Include(d => d.Type)
                                .Include(d => d.Discipline)
                                .ThenInclude(d => d.Type)
                                .Include(d => d.Discipline)
                                .ThenInclude(dis => dis.Project)
                                .Include(o => o.Discipline)
                                .ThenInclude(d => d.Type)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

            return Mapping.Mapper.Map<List<SupportiveWork>, List<SupportiveWorkDto>>(drs);
        }
    }

    public new async Task<ICollection<SupportiveWorkDto>> GetAll(
        Expression<Func<SupportiveWork, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    )
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<SupportiveWork> drs;

            if (pageSize == 0 || pageIndex == 0)
            {
                drs = await _context.Set<SupportiveWork>()
                                    .Where(r => !r.IsDeleted)
                                    .Include(d => d.Type)
                                    .Include(d => d.Discipline)
                                    .ThenInclude(d => d.Type)
                                    .Include(d => d.Discipline)
                                    .ThenInclude(dis => dis.Project)
                                    .Include(o => o.Discipline)
                                    .ThenInclude(d => d.Type)
                                    .Where(expresion)
                                    .ToListAsync();

                return Mapping.Mapper.Map<List<SupportiveWork>, List<SupportiveWorkDto>>(drs);
            }


            drs = await _context.Set<SupportiveWork>()
                                .Where(r => !r.IsDeleted)
                                .Include(d => d.Type)
                                .Include(d => d.Discipline)
                                .ThenInclude(d => d.Type)
                                .Include(d => d.Discipline)
                                .ThenInclude(dis => dis.Project)
                                .Include(o => o.Discipline)
                                .ThenInclude(d => d.Type)
                                .Where(expresion)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

            return Mapping.Mapper.Map<List<SupportiveWork>, List<SupportiveWorkDto>>(drs);
        }
    }

    public async new Task<SupportiveWorkDto> Add(SupportiveWorkDto entity, bool update = false)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.CreatedDate = update ? DateTime.Now.ToUniversalTime() : entity.CreatedDate;
            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var entry = Mapping.Mapper.Map<SupportiveWork>(entity);
                var result = await _context.Set<SupportiveWork>().AddAsync(entry);
                await _context.SaveChangesAsync();

                var id = result.Entity?.Id;
                if (id == null)
                    throw new NullReferenceException(nameof(id));

                var endry = await Get((int)id);

                return Mapping.Mapper.Map<SupportiveWorkDto>(endry);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On SupportiveWorkRepo.Add(SupportiveWork): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return null;
        }
    }

    public async new Task<SupportiveWorkDto> Update(SupportiveWorkDto entity)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var entry = await _context.Set<SupportiveWork>().FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (entry != null)
                {
                    _context.Entry(entry).CurrentValues.SetValues(Mapping.Mapper.Map<SupportiveWork>(entity));
                    await _context.SaveChangesAsync();
                }

                return Mapping.Mapper.Map<SupportiveWorkDto>(entry);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On SupportiveWorkRepo.Update(SupportiveWork): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return null;
        }
    }

    public async Task<long> GetMenHoursAsync(int otherId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context.Set<DailyTime>()
                                 .Where(r => !r.IsDeleted)
                                 .Where(mh => mh.SupportiveWorkId == otherId)
                                 .Select(mh => mh.Hours)
                                 .SumAsync();
        }
    }

    public long GetMenHours(int otherId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return _context.Set<DailyTime>()
                           .Where(r => !r.IsDeleted)
                           .Where(mh => mh.SupportiveWorkId == otherId)
                           .Select(mh => mh.Hours)
                           .Sum();
        }
    }
}
