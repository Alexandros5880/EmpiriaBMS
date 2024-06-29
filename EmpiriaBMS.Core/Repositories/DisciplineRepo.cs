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
                                 .Include(mh => mh.TimeSpan)
                                 .Select(mh => mh.TimeSpan.Hours)
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
                           .Include(mh => mh.TimeSpan)
                           .Select(mh => mh.TimeSpan.Hours)
                           .Sum();
        }
    }

    public async Task AddTime(int userId, int projectId, int disciplineId, TimeSpan timespan, bool isEditByAdmin = false)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            DailyTime time = new DailyTime()
            {
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Date = DateTime.Now,
                DailyUserId = userId,
                ProjectId = projectId,
                DisciplineId = disciplineId,
                TimeSpan = new Timespan(timespan.Days, timespan.Hours, timespan.Minutes, timespan.Seconds),
                IsEditByAdmin = isEditByAdmin
            };
            await _context.Set<DailyTime>().AddAsync(time);

            // Get Discipline && Calculate Estimated Hours
            var discipline = await _context.Set<Discipline>()
                                           .Where(r => !r.IsDeleted)
                                           .Include(p => p.DailyTime)
                                           .FirstOrDefaultAsync(p => p.Id == disciplineId);
            if (discipline == null)
                throw new NullReferenceException(nameof(discipline));
            var disciplineMenHours = discipline.DailyTime.Select(h => h.TimeSpan.Hours).Sum();

            decimal divitionDiscResult = Convert.ToDecimal(disciplineMenHours) / Convert.ToDecimal(discipline.EstimatedHours);
            discipline.EstimatedCompleted = (float)divitionDiscResult * 100;

            // Get Project && Calculate Estimated Hours
            var project = await _context.Set<Project>()
                                        .Where(r => !r.IsDeleted)
                                        .Include(p => p.DailyTime)
                                        .FirstOrDefaultAsync(p => p.Id == projectId);
            if (project == null)
                throw new NullReferenceException(nameof(project));
            var projectsTimes = project.DailyTime.Select(dt => dt.TimeSpan).ToList();
            var projectMenHours = projectsTimes.Select(t => t.Hours).Sum();

            decimal divitionProResult = Convert.ToDecimal(projectMenHours) / Convert.ToDecimal(project.EstimatedHours);
            project.EstimatedCompleted = (float)divitionProResult * 100;

            // Save Changes
            await _context.SaveChangesAsync();
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
                var exists = await _context.Set<DisciplineEngineer>().Where(r => !r.IsDeleted)
                                           .AnyAsync(de => de.DisciplineId == disciplineId && de.EngineerId == e.Id);
                if (exists) continue;

                await _context.Set<DisciplineEngineer>().AddAsync(de);
                await _context.SaveChangesAsync();
            }
        }
    }

    public async Task RemoveEngineers(int disciplineId, ICollection<int> engineersIds)
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
            Console.WriteLine($"Exception On DisciplineRepo.DeleteDisciplineEngineer({Mapping.Mapper.Map<DisciplineEngineerDto>(entity).GetType()}): {ex.Message}, \nInner: {ex.InnerException.Message}");
            return null;
        }
    }
}
