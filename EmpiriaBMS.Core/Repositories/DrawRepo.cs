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
using EmpiriaBMS.Core.Hellpers;
using System.Data.Common;


namespace EmpiriaBMS.Core.Repositories;

public class DrawRepo : Repository<DrawDto, Draw>, IDisposable
{
    public DrawRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public new async Task<DrawDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var dr = await _context
                             .Set<Draw>()
                             .FirstOrDefaultAsync(r => r.Id == id);

            return Mapping.Mapper.Map<DrawDto>(dr);
        }
    }

    public new async Task<ICollection<DrawDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Draw> drs;

            if (pageSize == 0 || pageIndex == 0)
            {
                drs = await _context.Set<Draw>()
                                     .ToListAsync();

                return Mapping.Mapper.Map<List<Draw>, List<DrawDto>>(drs);
            }


            drs = await _context.Set<Draw>()
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();

            return Mapping.Mapper.Map<List<Draw>, List<DrawDto>>(drs);
        }
    }

    public new async Task<ICollection<DrawDto>> GetAll(
        Expression<Func<Draw, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Draw> drs;

            if (pageSize == 0 || pageIndex == 0)
            {
                drs = await _context.Set<Draw>()
                                    .Where(expresion)
                                    .ToListAsync();

                return Mapping.Mapper.Map<List<Draw>, List<DrawDto>>(drs);
            }


            drs = await _context.Set<Draw>()
                                .Where(expresion)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

            return Mapping.Mapper.Map<List<Draw>, List<DrawDto>>(drs);
        }
    }

    public async Task UpdateCompleted(int projectId, int disciplineId, int drawId, float completed)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            // Update Current Drawing
            var drawing = await _context.Set<Draw>()
                                        .FirstOrDefaultAsync(d => d.Id == drawId);
            if (drawing == null)
                throw new NullReferenceException(nameof(drawing));
            drawing.CompletionEstimation += completed;

            // Calculate Parent Discipline Completed
            var discipline = await _context.Set<Discipline>()
                                           .Include(d => d.DisciplinesDraws)
                                           .FirstOrDefaultAsync(d => d.Id == disciplineId);
            if (discipline == null)
                throw new NullReferenceException(nameof(discipline));
            var allDrawingsIds = discipline.DisciplinesDraws.Select(dd => dd.DrawId).ToList();
            var allDrawings = await _context.Set<Draw>().Where(d => allDrawingsIds.Contains(d.Id))
                                                        .ToListAsync();
            var sumComplitionOfDrawings = allDrawings
                                          .Select(d => d.CompletionEstimation)
                                          .Sum();
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

    public async Task UpdateHours(int projectId, int disciplineId, int drawId, long hours)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            // Update Current Drawing
            var drawing = await _context.Set<Draw>()
                                        .FirstOrDefaultAsync(d => d.Id == drawId);
            if (drawing == null)
                throw new NullReferenceException(nameof(drawing));
            drawing.MenHours += hours;

            // Calculate Parent Discipline Hours
            var discipline = await _context.Set<Discipline>()
                                           .Include(d => d.DisciplinesDraws)
                                           .FirstOrDefaultAsync(d => d.Id == disciplineId);
            if (discipline == null)
                throw new NullReferenceException(nameof(discipline));
            var allDrawingsIds = discipline.DisciplinesDraws.Select(dd => dd.DrawId).ToList();
            var allDrawings = await _context.Set<Draw>().Where(d => allDrawingsIds.Contains(d.Id))
                                                        .ToListAsync();
            var sumHoursOfDrawings = allDrawings.Select(d => d.MenHours).Sum();
            discipline.MenHours = sumHoursOfDrawings;

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