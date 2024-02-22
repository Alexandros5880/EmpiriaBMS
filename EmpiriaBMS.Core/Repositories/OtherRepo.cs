using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaMS.Models.Models;
using EmpiriaMS.Models;
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


    // TODO: FIX THAT
    public async Task<bool> UpdateHours(int projectId, int otherId, double hours)
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

            var purentDiscipline = disciplinesOthers.Select(dd => dd.Discipline)
                                                   .FirstOrDefault();

            // Get Current Other
            var other = disciplinesOthers.Select(dd => dd.Other)
                                          .FirstOrDefault();

            // Add Hours To Other
            other.MenHours += hours;
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
