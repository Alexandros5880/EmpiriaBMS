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
                                     .ToListAsync();

                return Mapping.Mapper.Map<List<Discipline>, List<DisciplineDto>>(ds);
            }

            ds = await _context.Set<Discipline>()
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
                                     .Where(expresion)
                                     .ToListAsync();

                return Mapping.Mapper.Map<List<Discipline>, List<DisciplineDto>>(ds);
            }

            ds = await _context.Set<Discipline>()
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
                             .Where(d => d.DisciplinesDraws.Select(o => o.DisciplineId).Contains(id))
                             .ToListAsync();

            return Mapping.Mapper.Map<List<Drawing>, List<DrawingDto>>(draws);
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
                             .Where(d => d.DisciplinesOthers.Select(o => o.DisciplineId).Contains(id))
                             .ToListAsync();

            return Mapping.Mapper.Map<List<Other>, List<OtherDto>>(others);
        }
    }

    public async Task<long> GetMenHoursAsync(int disciplineId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context.Set<ManHour>()
                                 .Where(mh => mh.DisciplineId == disciplineId)
                                 .Select(mh => mh.Hours)
                                 .SumAsync();
        }
    }

    public long GetMenHours(int disciplineId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return _context.Set<ManHour>()
                           .Where(mh => mh.DisciplineId == disciplineId)
                           .Select(mh => mh.Hours)
                           .Sum();
        }
    }

    public async Task UpdateCompleted(int projectId, int disciplineId, float completed)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            // Calculate Parent Discipline Completed
            var discipline = await _context.Set<Discipline>()
                                           .Include(d => d.DisciplinesDraws)
                                           .FirstOrDefaultAsync(d => d.Id == disciplineId);
            if (discipline == null)
                throw new NullReferenceException(nameof(discipline));
            var allDrawingsIds = discipline.DisciplinesDraws.Select(dd => dd.DrawId).ToList();
            var allDrawings = await _context.Set<Drawing>().Where(d => allDrawingsIds.Contains(d.Id))
                                                        .ToListAsync();
            var sumComplitionOfDrawings = allDrawings
                                          .Select(d => d.CompletionEstimation)
                                          .Sum();

            sumComplitionOfDrawings += completed;

            var drawsCounter = discipline.DisciplinesDraws.Count();
            discipline.Completed = sumComplitionOfDrawings / drawsCounter;

            // Calculate Parent Project Complition
            var project = await _context.Set<Project>()
                                        .Include(p => p.DisciplinesProjects)
                                        .FirstOrDefaultAsync(p => p.Id == projectId);
            var disciplineIds = project.DisciplinesProjects.Select(dp => dp.DisciplineId).ToList();
            var disciplines = await _context.Set<Discipline>()
                                            .Where(d => disciplineIds.Contains(d.Id))
                                            .ToListAsync();
            var sumCompplitionOfDisciplines = disciplines.Select(d => d.Completed).Sum();
            var disciplinesCounter = disciplineIds.Count();
            project.Completed = sumCompplitionOfDisciplines / disciplinesCounter;

            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateHours(int userId, int projectId, int disciplineId, long hours)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            ManHour mhours = new ManHour()
            {
                UserId = userId,
                ProjectId = projectId,
                DisciplineId = disciplineId,
                Hours = hours
            };
            await _context.Set<ManHour>().AddAsync(mhours);

            // Get Discipline && Calculate Estimated Hours
            var discipline = await _context.Set<Discipline>()
                                           .Include(p => p.MenHours)
                                           .FirstOrDefaultAsync(p => p.Id == disciplineId);
            if (discipline == null)
                throw new NullReferenceException(nameof(discipline));
            var disciplineMenHours = discipline.MenHours.Select(h => h.Hours).Sum();

            decimal divitionDiscResult = Convert.ToDecimal(disciplineMenHours) / Convert.ToDecimal(discipline.EstimatedHours);
            discipline.EstimatedCompleted = (float)divitionDiscResult * 100;

            // Get Project && Calculate Estimated Hours
            var project = await _context.Set<Project>()
                                        .Include(p => p.MenHours)
                                        .FirstOrDefaultAsync(p => p.Id == projectId);
            if (project == null)
                throw new NullReferenceException(nameof(project));
            var projectMenHours = project.MenHours.Select(h => h.Hours).Sum();

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
