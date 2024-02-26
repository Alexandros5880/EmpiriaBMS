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
using AutoMapper;


namespace EmpiriaBMS.Core.Repositories;

public class DrawingRepo : Repository<DrawingDto, Drawing>, IDisposable
{
    public DrawingRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public new async Task<DrawingDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var dr = await _context
                             .Set<Drawing>()
                             .FirstOrDefaultAsync(r => r.Id == id);

            return Mapping.Mapper.Map<DrawingDto>(dr);
        }
    }

    public new async Task<ICollection<DrawingDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Drawing> drs;

            if (pageSize == 0 || pageIndex == 0)
            {
                drs = await _context.Set<Drawing>()
                                     .ToListAsync();

                return Mapping.Mapper.Map<List<Drawing>, List<DrawingDto>>(drs);
            }


            drs = await _context.Set<Drawing>()
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();

            return Mapping.Mapper.Map<List<Drawing>, List<DrawingDto>>(drs);
        }
    }

    public new async Task<ICollection<DrawingDto>> GetAll(
        Expression<Func<Drawing, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Drawing> drs;

            if (pageSize == 0 || pageIndex == 0)
            {
                drs = await _context.Set<Drawing>()
                                    .Where(expresion)
                                    .ToListAsync();

                return Mapping.Mapper.Map<List<Drawing>, List<DrawingDto>>(drs);
            }


            drs = await _context.Set<Drawing>()
                                .Where(expresion)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

            return Mapping.Mapper.Map<List<Drawing>, List<DrawingDto>>(drs);
        }
    }

    public async Task<long> GetMenHoursAsync(int drwaingId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context.Set<ManHour>()
                                 .Where(mh => mh.DrawingId == drwaingId)
                                 .Select(mh => mh.Hours)
                                 .SumAsync();
        }
    }

    public long GetMenHours(int drwaingId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return _context.Set<ManHour>()
                                 .Where(mh => mh.DrawingId == drwaingId)
                                 .Select(mh => mh.Hours)
                                 .Sum();
        }
    }

    public async Task UpdateCompleted(int projectId, int disciplineId, int drawId, float completed)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            // Update Current Drawing
            var drawing = await _context.Set<Drawing>()
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
            var allDrawings = await _context.Set<Drawing>().Where(d => allDrawingsIds.Contains(d.Id))
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

    public async Task UpdateHours(int userId, int projectId, int disciplineId, int drawId, long hours)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            ManHour mhours = new ManHour()
            {
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = userId,
                ProjectId = projectId,
                DisciplineId = disciplineId,
                DrawingId = drawId,
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

    public async Task<ICollection<UserDto>> GetDesigners(int drwaingId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var users = await _context.Set<DrawingEmployee>()
                                 .Where(de => de.DrawingId == drwaingId)
                                 .Include(de => de.Employee)
                                 .Select(de => de.Employee)
                                 .ToListAsync();

            return Mapping.Mapper.Map<List<UserDto>>(users);
        }
    }

    public async Task AddDesigners(int drawingId, ICollection<UserDto> designers)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            foreach(var d in designers)
            {
                DrawingEmployee de = new DrawingEmployee()
                {
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    DrawingId = drawingId,
                    EmployeeId = d.Id
                };

                // Check If Exists
                var exists = await _context.Set<DrawingEmployee>()
                    .AnyAsync(de => de.DrawingId == drawingId && de.EmployeeId == d.Id);
                if (exists) continue;

                await _context.Set<DrawingEmployee>().AddAsync(de);
                await _context.SaveChangesAsync();
            }
        }
    }

    public async Task RemoveDesigners(int drwaingId, ICollection<int> designersIds)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var designers = await _context.Set<DrawingEmployee>()
                                              .Where(d => designersIds.Contains(d.EmployeeId))
                                              .ToListAsync();

            if (designers == null)
                throw new NullReferenceException(nameof(designers));

            foreach (var designer in designers)
            {
                _context.Set<DrawingEmployee>().Remove(designer);
            }

            await _context.SaveChangesAsync();
        }
    }
}