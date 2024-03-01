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

    public async Task<long> GetMenHoursAsync(int otherId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context.Set<ManHour>()
                                 .Where(mh => mh.OtherId == otherId)
                                 .Select(mh => mh.Hours)
                                 .SumAsync();
        }
    }

    public long GetMenHours(int otherId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return _context.Set<ManHour>()
                                 .Where(mh => mh.OtherId == otherId)
                                 .Select(mh => mh.Hours)
                                 .Sum();
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
                                           .Include(d => d.Others)
                                           .FirstOrDefaultAsync(d => d.Id == disciplineId);
            if (discipline == null)
                throw new NullReferenceException(nameof(discipline));
            var allOthers = discipline.Others;
            var sumComplitionOfOthers = allOthers
                                          .Select(d => d.CompletionEstimation)
                                          .Sum();
            var othersCounter = allOthers.Count();
            discipline.Completed = sumComplitionOfOthers / othersCounter;

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

    public async Task UpdateHours(int userId, int projectId, int disciplineId, int otherId, long hours)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            ManHour mhours = new ManHour()
            {
                UserId = userId,
                ProjectId = projectId,
                DisciplineId = disciplineId,
                OtherId = otherId,
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
}
