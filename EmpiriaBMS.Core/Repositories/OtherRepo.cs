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

    public async Task UpdateCompleted(int projectId, int disciplineId, int otherId, int completed)
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

            //await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateHours(int projectId, int otherId, double hours)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            // Get Parent Project
            var project = await _context.Set<Project>()
                                        .FirstOrDefaultAsync(p => p.Id == projectId);

            // Get Parent Discipline
            var projectDisciplinesIds = await _context.Set<DisciplinePoject>()
                                                      .Where(dp => dp.ProjectId == projectId)
                                                      .Select(dp => dp.DisciplineId)
                                                      .ToListAsync();

            var disciplinesOthers = await _context.Set<DisciplineOther>()
                                                  .Where(dd => projectDisciplinesIds.Contains(dd.DisciplineId))
                                                  .Where(dd => dd.OtherId == otherId)
                                                  .ToListAsync();

            var purentDisciplineId = disciplinesOthers.Select(dd => dd.DisciplineId)
                                                      .FirstOrDefault();
            var purentDiscipline = await _context.Set<Discipline>()
                                                 .FirstOrDefaultAsync(d => d.Id == purentDisciplineId);

            // Get Current Other
            var other = await _context.Set<Other>()
                                      .FirstOrDefaultAsync(d => d.Id == otherId);

            if (other == null)
                throw new NullReferenceException(nameof(other));

            // Add Hours To Drawing
            other.MenHours += hours;
            await _context.SaveChangesAsync();

            purentDiscipline.MenHours += Convert.ToInt64(hours);
            await _context.SaveChangesAsync();

            project.MenHours += Convert.ToInt64(hours);
            await _context.SaveChangesAsync();
        }
    }

    //public new async Task<OtherDto?> Get(int id)
    //{
    //    if (id == 0)
    //        throw new ArgumentNullException(nameof(id));

    //    using (var _context = _dbContextFactory.CreateDbContext())
    //    {
    //        var Other = await _context
    //                         .Set<Other>()
    //                         .Include(r => r.Discipline)
    //                         .FirstOrDefaultAsync(r => r.Id == id);

    //        return Mapping.Mapper.Map<OtherDto>(Other);
    //    }
    //}

    //public new async Task<ICollection<OtherDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    //{
    //    using (var _context = _dbContextFactory.CreateDbContext())
    //    {
    //        List<Other> ds;

    //        if (pageSize == 0 || pageIndex == 0)
    //        {
    //            ds =  await _context.Set<Other>()
    //                                 .Include(r => r.Discipline)
    //                                 .ToListAsync();

    //            return Mapping.Mapper.Map<List<Other>, List<OtherDto>>(ds);
    //        }

    //        ds = await _context.Set<Other>()
    //                             .Skip((pageIndex - 1) * pageSize)
    //                             .Take(pageSize)
    //                             .Include(r => r.Discipline)
    //                             .ToListAsync();

    //        return Mapping.Mapper.Map<List<Other>, List<OtherDto>>(ds);
    //    } 
    //}

    //public new async Task<ICollection<OtherDto>> GetAll(
    //    Expression<Func<Other, bool>> expresion,
    //    int pageSize = 0,
    //    int pageIndex = 0
    //) {
    //    using (var _context = _dbContextFactory.CreateDbContext())
    //    {
    //        List<Other> ds;

    //        if (pageSize == 0 || pageIndex == 0)
    //        {
    //            ds = await _context.Set<Other>()
    //                               .Where(expresion)
    //                               .Include(r => r.Discipline)
    //                               .ToListAsync();

    //            return Mapping.Mapper.Map<List<Other>, List<OtherDto>>(ds);
    //        }

    //        ds = await _context.Set<Other>()
    //                           .Where(expresion)
    //                           .Skip((pageIndex - 1) * pageSize)
    //                           .Take(pageSize)
    //                           .Include(r => r.Discipline)
    //                           .ToListAsync();

    //        return Mapping.Mapper.Map<List<Other>, List<OtherDto>>(ds);
    //    }
    //}
}
