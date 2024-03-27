using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EmpiriaBMS.Models.Models;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Config;

namespace EmpiriaBMS.Core.Repositories;

public class DisciplineRepo : Repository<DisciplineDto, Discipline>, IDisposable
{
    public DisciplineRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public new async Task<DisciplineDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var disclipline = await _context
                             .Set<Discipline>()
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
                                   .Include(d => d.Type)
                                   .ToListAsync();

                return Mapping.Mapper.Map<List<Discipline>, List<DisciplineDto>>(ds);
            }

            ds = await _context.Set<Discipline>()
                               .Include(d => d.Type)
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
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Discipline> ds;
            if (pageSize == 0 || pageIndex == 0)
            {
                ds = await _context.Set<Discipline>()
                                   .Include(d => d.Type)
                                   .Where(expresion)
                                   .ToListAsync();

                return Mapping.Mapper.Map<List<Discipline>, List<DisciplineDto>>(ds);
            }

            ds = await _context.Set<Discipline>()
                               .Include(d => d.Type)
                               .Where(expresion)
                               .Skip((pageIndex - 1) * pageSize)
                               .Take(pageSize)
                               .ToListAsync();

            return Mapping.Mapper.Map<List<Discipline>, List<DisciplineDto>>(ds);
        }
    }

    public async Task<List<DrawingDto>> GetDraws(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var draws = await _context
                             .Set<Drawing>()
                             .Where(d => d.DisciplineId == id)
                             .Include(d => d.Type)
                             .ToListAsync();

            return Mapping.Mapper.Map<List<Drawing>, List<DrawingDto>>(draws);
        }
    }

    public async Task<List<DrawingDto>> GetDraws(int id, int userId, bool all)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Drawing> drawings;
            var disciplineDrawingsIds = await _context
                                         .Set<Drawing>()
                                         .Where(d => d.DisciplineId == id)
                                         .Select(d => d.Id)
                                         .ToListAsync();
            if (all)
            {
                drawings = await _context.Set<Drawing>()
                                         .Where(d => disciplineDrawingsIds.Contains(d.Id))
                                         .Include(d => d.Type)
                                         .ToListAsync();
            }
            else
            {
                var drawingIds = await _context.Set<DrawingEmployee>()
                                                    .Where(de => disciplineDrawingsIds.Contains(de.DrawingId))
                                                    .Where(de => de.EmployeeId == userId)
                                                    .Select(de => de.DrawingId)
                                                    .ToListAsync();

                drawings = await _context.Set<Drawing>()
                                         .Where(d => drawingIds.Contains(d.Id))
                                         .Include(d => d.Type)
                                         .ToListAsync();
            }

            return Mapping.Mapper.Map<List<Drawing>, List<DrawingDto>>(drawings);
        }
    }

    public async Task<List<OtherDto>> GetOthers(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var others = await _context
                             .Set<Other>()
                             .Where(d => d.DisciplineId == id)
                             .Include(d => d.Type)
                             .ToListAsync();

            return Mapping.Mapper.Map<List<Other>, List<OtherDto>>(others);
        }
    }

    public async Task<List<OtherDto>> GetOthers(int id, int userId, bool all)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Other> others;
            var disciplineOthersIds = await _context
                                         .Set<Other>()
                                         .Where(d => d.DisciplineId == id)
                                         .Select(d => d.Id)
                                         .ToListAsync();
            if (all)
            {
                others = await _context.Set<Other>()
                                       .Where(o => disciplineOthersIds.Contains(o.Id))
                                       .Include(d => d.Type)
                                       .ToListAsync();
            }
            else
            {
                var otherIds = await _context.Set<OtherEmployee>()
                                                    .Where(de => disciplineOthersIds.Contains(de.OtherId))
                                                    .Where(de => de.EmployeeId == userId)
                                                    .Select(de => de.OtherId)
                                                    .ToListAsync();

                others = await _context.Set<Other>()
                                       .Where(o => otherIds.Contains(o.Id))
                                       .Include(d => d.Type)
                                       .ToListAsync();
            }

            return Mapping.Mapper.Map<List<Other>, List<OtherDto>>(others);
        }
    }

    public async Task<long> GetMenHoursAsync(int disciplineId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context.Set<DailyTime>()
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
                           .Where(mh => mh.DisciplineId == disciplineId)
                           .Include(mh => mh.TimeSpan)
                           .Select(mh => mh.TimeSpan.Hours)
                           .Sum();
        }
    }

    public async Task UpdateCompleted(int projectId, int disciplineId, float completed)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            // Calculate Parent Discipline Completed
            var discipline = await _context.Set<Discipline>()
                                           .Include(d => d.Project)
                                           .Include(d => d.Drawings)
                                           .Include(d => d.Others)
                                           .FirstOrDefaultAsync(d => d.Id == disciplineId);
            if (discipline == null)
                throw new NullReferenceException(nameof(discipline));
            var allDrawings = discipline.Drawings;
            var sumComplitionOfDrawings = allDrawings
                                          .Select(d => d.CompletionEstimation)
                                          .Sum();

            sumComplitionOfDrawings += completed;

            var drawsCounter = allDrawings.Count();
            discipline.Completed = sumComplitionOfDrawings / drawsCounter;

            // Calculate Parent Project Complition
            var disciplines = await _context.Set<Discipline>()
                                            .Where(d => d.ProjectId == projectId)
                                            .ToListAsync();
            var project = discipline.Project;
            var sumCompplitionOfDisciplines = disciplines.Select(d => d.Completed).Sum();
            var disciplinesCounter = disciplines.Count();
            project.Completed = sumCompplitionOfDisciplines / disciplinesCounter;

            await _context.SaveChangesAsync();
        }
    }

    public async Task AddTime(int userId, int projectId, int disciplineId, TimeSpan timespan)
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
                TimeSpan = new Timespan(timespan.Days, timespan.Hours, timespan.Minutes, timespan.Seconds)
            };
            await _context.Set<DailyTime>().AddAsync(time);

            // Get Discipline && Calculate Estimated Hours
            var discipline = await _context.Set<Discipline>()
                                           .Include(p => p.DailyTime)
                                           .FirstOrDefaultAsync(p => p.Id == disciplineId);
            if (discipline == null)
                throw new NullReferenceException(nameof(discipline));
            var disciplineMenHours = discipline.DailyTime.Select(h => h.TimeSpan.Hours).Sum();

            decimal divitionDiscResult = Convert.ToDecimal(disciplineMenHours) / Convert.ToDecimal(discipline.EstimatedHours);
            discipline.EstimatedCompleted = (float)divitionDiscResult * 100;

            // Get Project && Calculate Estimated Hours
            var project = await _context.Set<Project>()
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
                var exists = await _context.Set<DisciplineEngineer>()
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
                                              .Where(d => engineersIds.Contains(d.EngineerId)
                                                                && d.DisciplineId == disciplineId)
                                              .ToListAsync();

            if (engineers == null)
                throw new NullReferenceException(nameof(engineers));

            foreach (var engineer in engineers)
            {
                _context.Set<DisciplineEngineer>().Remove(engineer);
            }

            await _context.SaveChangesAsync();
        }
    }
}
