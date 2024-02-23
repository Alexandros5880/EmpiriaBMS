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

    public async Task<bool> UpdateHours(int projectId, int drawId, double hours)
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

            var purentDiscipline = disciplinesDraws.Select(dd => dd.Discipline)
                                                   .FirstOrDefault();

            // Get Current Drawing
            var drawing = disciplinesDraws.Select(dd => dd.Draw)
                                          .FirstOrDefault();

            // Add Hours To Drawing
            drawing.MenHours += hours;
            purentDiscipline.MenHours += Convert.ToInt64(hours);
            project.MenHours += Convert.ToInt64(hours);

            // Validate Tha Drawing.MenHours < From Discipline.EstimatedHours
            var disciplineValid = purentDiscipline.EstimatedHours > purentDiscipline.MenHours;

            // Calculate Discipline.Completed   με το "Discipline.EstimatedHours" και το "Discipline.MenHours"
            purentDiscipline.Completed = Convert.ToInt32(purentDiscipline.EstimatedHours * purentDiscipline.MenHours / 100);

            // Validate Project.MenHours < Project.EstimatedHours
            var projectValid = project.EstimatedHours > project.MenHours;

            // Με Βάση το "Project.EstimatedHours" και το "Project.MenHours" υπολογίζω το "ProjectComplete".

            await _context.SaveChangesAsync();

            return disciplineValid && projectValid;
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