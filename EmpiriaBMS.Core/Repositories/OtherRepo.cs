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
using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Core.Repositories;

public class OtherRepo : Repository<OtherDto, Other>, IDisposable
{
    public OtherRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public new async Task<OtherDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var dr = await _context
                             .Set<Other>()
                             .FirstOrDefaultAsync(r => r.Id == id);

            return Mapping.Mapper.Map<OtherDto>(dr);
        }
    }

    public new async Task<ICollection<OtherDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Other> drs;

            if (pageSize == 0 || pageIndex == 0)
            {
                drs = await _context.Set<Other>()
                                     .ToListAsync();

                return Mapping.Mapper.Map<List<Other>, List<OtherDto>>(drs);
            }


            drs = await _context.Set<Other>()
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();

            return Mapping.Mapper.Map<List<Other>, List<OtherDto>>(drs);
        }
    }

    public new async Task<ICollection<OtherDto>> GetAll(
        Expression<Func<Other, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Other> drs;

            if (pageSize == 0 || pageIndex == 0)
            {
                drs = await _context.Set<Other>()
                                    .Where(expresion)
                                    .ToListAsync();

                return Mapping.Mapper.Map<List<Other>, List<OtherDto>>(drs);
            }


            drs = await _context.Set<Other>()
                                .Where(expresion)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

            return Mapping.Mapper.Map<List<Other>, List<OtherDto>>(drs);
        }
    }

    public async Task UpdateCompleted(int projectId, int disciplineId, int otherId, float completed)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            // Update Current Other
            var other = await _context.Set<Other>()
                                        .FirstOrDefaultAsync(d => d.Id == otherId);
            if (other == null)
                throw new NullReferenceException(nameof(other));
            other.CompletionEstimation += completed;

            // Calculate Parent Discipline Completed
            var discipline = await _context.Set<Discipline>()
                                           .Include(d => d.DisciplinesOthers)
                                           .FirstOrDefaultAsync(d => d.Id == disciplineId);
            if (discipline == null)
                throw new NullReferenceException(nameof(discipline));
            var allOthersIds = discipline.DisciplinesOthers.Select(dd => dd.OtherId).ToList();
            var allOthers = await _context.Set<Other>().Where(d => allOthersIds.Contains(d.Id))
                                                        .ToListAsync();
            var sumComplitionOfOthers = allOthers
                                          .Select(d => d.CompletionEstimation)
                                          .Sum();
            var othersCounter = discipline.DisciplinesOthers.Count();
            discipline.Completed = sumComplitionOfOthers / othersCounter;

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

    public async Task UpdateHours(int projectId, int disciplineId, int otherId, long hours)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            // Update Current Other
            var other = await _context.Set<Other>()
                                        .FirstOrDefaultAsync(d => d.Id == otherId);
            if (other == null)
                throw new NullReferenceException(nameof(other));
            other.MenHours += hours;

            // Calculate Parent Discipline Hours
            var discipline = await _context.Set<Discipline>()
                                           .Include(d => d.DisciplinesOthers)
                                           .FirstOrDefaultAsync(d => d.Id == disciplineId);
            if (discipline == null)
                throw new NullReferenceException(nameof(discipline));
            var allOthersIds = discipline.DisciplinesOthers.Select(dd => dd.OtherId).ToList();
            var allOthers = await _context.Set<Other>().Where(d => allOthersIds.Contains(d.Id))
                                                        .ToListAsync();
            var sumHoursOfOthers = allOthers.Select(d => d.MenHours).Sum();
            discipline.MenHours = sumHoursOfOthers;

            // Calculate Parent Project MenHours && EstimatedCompleted
            var project = await _context.Set<Project>()
                                        .Include(p => p.DisciplinesProjects)
                                        .FirstOrDefaultAsync(p => p.Id == projectId);
            var disciplineIds = project.DisciplinesProjects.Select(dp => dp.DisciplineId).ToList();
            var disciplines = await _context.Set<Discipline>()
                                            .Where(d => disciplineIds.Contains(d.Id))
                                            .ToListAsync();
            var sumMenHoursOfDisciplines = disciplines.Select(d => d.MenHours).Sum();
            project.MenHours = sumMenHoursOfDisciplines;
            decimal divitionResult = Convert.ToDecimal(project.MenHours / project.EstimatedHours);
            project.EstimatedCompleted = (float)divitionResult * 100;
            await _context.SaveChangesAsync();
        }
    }
}
