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

    public async Task UpdateCompleted(int projectId, int drawId, int completed)
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

            var disciplinesDraws = await _context.Set<DisciplineDraw>()
                                                 .Where(dd => projectDisciplinesIds.Contains(dd.DisciplineId))
                                                 .Where(dd => dd.DrawId == drawId)
                                                 .ToListAsync();

            var purentDisciplineId = disciplinesDraws.Select(dd => dd.DisciplineId)
                                                     .FirstOrDefault();
            var purentDiscipline = await _context.Set<Discipline>()
                                                 .FirstOrDefaultAsync(d => d.Id == purentDisciplineId);

            // Get Current Drawing
            var drawing = await _context.Set<Draw>()
                                        .FirstOrDefaultAsync(d => d.Id == drawId);


            if (drawing == null)
                throw new NullReferenceException(nameof(drawing));

            // Add Hours To Drawing
            drawing.CompletionEstimation += completed;
            await _context.SaveChangesAsync();

            // Calculate Parent Discipline Completed
            var allDrawingsIds = purentDiscipline.DisciplinesDraws.Select(dd => dd.DrawId);
            var allDrawings = await _context.Set<Draw>().Where(d => allDrawingsIds.Contains(d.Id))
                                                        .ToListAsync();
            var sumComplitionOfDrawings = allDrawings
                                          .Select(d => d.CompletionEstimation)
                                          .Sum();
            sumComplitionOfDrawings += completed;

            var drawsCounter = purentDiscipline.DisciplinesDraws.Count() + 1;
            purentDiscipline.Completed = (sumComplitionOfDrawings / drawsCounter) * 100;
            await _context.SaveChangesAsync();

            // Calculate Parent Project Complition
            var sumCompplitionOfDisciplines = await _context.Set<Discipline>()
                                                            .Where(d => projectDisciplinesIds.Contains(d.Id))
                                                            .Select(d => d.Completed)
                                                            .SumAsync();

            var disciplinesCounter = projectDisciplinesIds.Count();

            project.Completed = (sumCompplitionOfDisciplines / disciplinesCounter) * 100;

            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateHours(int projectId, int drawId, double hours)
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

            var disciplinesDraws = await _context.Set<DisciplineDraw>()
                                                 .Where(dd => projectDisciplinesIds.Contains(dd.DisciplineId))
                                                 .Where(dd => dd.DrawId == drawId)
                                                 .ToListAsync();

            var purentDisciplineId = disciplinesDraws.Select(dd => dd.DisciplineId)
                                                     .FirstOrDefault();
            var purentDiscipline = await _context.Set<Discipline>()
                                                 .FirstOrDefaultAsync(d => d.Id == purentDisciplineId);

            // Get Current Drawing
            var drawing = await _context.Set<Draw>()
                                        .FirstOrDefaultAsync(d => d.Id == drawId);

            if (drawing == null)
                throw new NullReferenceException(nameof(drawing));

            // Add Hours To Drawing
            drawing.MenHours += hours;
            await _context.SaveChangesAsync();

            purentDiscipline.MenHours += Convert.ToInt64(hours);
            await _context.SaveChangesAsync();

            project.MenHours += Convert.ToInt64(hours);
            await _context.SaveChangesAsync();

            await _context.SaveChangesAsync();
        }
    }

    //public async Task<int> GetUsersWorkPackegedCompleted(int userId)
    //{
    //    if (userId == 0)
    //        throw new ArgumentException(nameof(userId));

    //    using (var _context = _dbContextFactory.CreateDbContext())
    //    {
    //        var disciplines = await _context.Set<DisciplineEmployee>()
    //                                          .Where(de => de.EmployeeId == userId)
    //                                          .Select(de => de.Discipline)
    //                                          .ToListAsync();

    //        var Draws2D = disciplines.Select(d => d.DisciplinesDraws.Select(dd => dd.Draw));
    //        List<int?> drawsCompleteds = new List<int?>();

    //        foreach(var d1 in Draws2D)
    //            foreach (var d2 in d1)
    //                drawsCompleteds.Add(d2.CompletionEstimation);

    //        return drawsCompleteds.Sum() ?? 0;
    //    }
    //}
}