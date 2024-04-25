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

public class DrawingRepo : Repository<DrawingDto, Drawing>
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
                             .Include(d => d.Type)
                             .Include(d => d.Discipline)
                             .ThenInclude(dis => dis.Project)
                             .Include(o => o.Discipline)
                             .ThenInclude(d => d.Type)
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
                                    .Include(d => d.Type)
                                    .Include(d => d.Discipline)
                                    .ThenInclude(dis => dis.Project)
                                    .Include(o => o.Discipline)
                                    .ThenInclude(d => d.Type)
                                    .ToListAsync();

                return Mapping.Mapper.Map<List<Drawing>, List<DrawingDto>>(drs);
            }


            drs = await _context.Set<Drawing>()
                                .Include(d => d.Type)
                                .Include(d => d.Discipline)
                                .ThenInclude(dis => dis.Project)
                                .Include(o => o.Discipline)
                                .ThenInclude(d => d.Type)
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
                                    .Include(d => d.Type)
                                    .Include(d => d.Discipline)
                                    .ThenInclude(dis => dis.Project)
                                    .Include(o => o.Discipline)
                                    .ThenInclude(d => d.Type)
                                    .Where(expresion)
                                    .ToListAsync();

                return Mapping.Mapper.Map<List<Drawing>, List<DrawingDto>>(drs);
            }


            drs = await _context.Set<Drawing>()
                                .Include(d => d.Type)
                                .Include(d => d.Discipline)
                                .ThenInclude(dis => dis.Project)
                                .Include(o => o.Discipline)
                                .ThenInclude(d => d.Type)
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
            return await _context.Set<DailyTime>()
                                 .Where(mh => mh.DrawingId == drwaingId)
                                 .Include(mh => mh.TimeSpan)
                                 .Select(mh => mh.TimeSpan.Hours)
                                 .SumAsync();
        }
    }

    public long GetMenHours(int drwaingId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return _context.Set<DailyTime>()
                           .Where(mh => mh.DrawingId == drwaingId)
                           .Include(mh => mh.TimeSpan)
                           .Select(mh => mh.TimeSpan.Hours)
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
                                           .Include(d => d.Drawings)
                                           .FirstOrDefaultAsync(d => d.Id == disciplineId);
            if (discipline == null)
                throw new NullReferenceException(nameof(discipline));
            var allDrawings = discipline.Drawings;
            var sumComplitionOfDrawings = allDrawings
                                          .Select(d => d.CompletionEstimation)
                                          .Sum();
            var drawsCounter = allDrawings.Count();
            discipline.DeclaredCompleted = sumComplitionOfDrawings / drawsCounter;

            // Calculate Parent Project Complition
            var disciplines = await _context.Set<Discipline>()
                                            .Where(d => d.ProjectId == projectId)
                                            .Include(d => d.Project)
                                            .ToListAsync();
            var project = discipline.Project;
            var sumCompplitionOfDisciplines = disciplines.Select(d => d.DeclaredCompleted).Sum();
            var disciplinesCounter = disciplines.Count();
            project.DeclaredCompleted = sumCompplitionOfDisciplines / disciplinesCounter;

            await _context.SaveChangesAsync();
        }
    }

    public async Task AddTime(int userId, int projectId, int disciplineId, int drawId, TimeSpan timespan)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            TimeSpan[] timeSpans = TimeHelper.SplitTimeSpanToDays(timespan);
            for (int i = timeSpans.Count()-1; i >= 0; i--)
            {
                DailyTime time = new DailyTime()
                {
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    Date = DateTime.Now.AddDays(-i),
                    DailyUserId = userId,
                    ProjectId = projectId,
                    DisciplineId = disciplineId,
                    DrawingId = drawId,
                    TimeSpan = new Timespan(
                        timeSpans[i].Days,
                        timeSpans[i].Hours,
                        timeSpans[i].Minutes,
                        timeSpans[i].Seconds)
                };
                await _context.Set<DailyTime>().AddAsync(time);
            }

            // Save Changes
            await _context.SaveChangesAsync();

            // Get Discipline && Calculate Estimated Hours
            var discipline = await _context.Set<Discipline>()
                                           .Include(p => p.DailyTime)
                                           .FirstOrDefaultAsync(p => p.Id == disciplineId);
            if (discipline == null)
                throw new NullReferenceException(nameof(discipline));
            var disciplineMenHours = await _context.Set<DailyTime>()
                                          .Where(d => d.DisciplineId == disciplineId)
                                          .Select(d => d.TimeSpan.Hours)
                                          .SumAsync();
            decimal divitionDiscResult = Convert.ToDecimal(disciplineMenHours) 
                                                    / Convert.ToDecimal(discipline.EstimatedHours);
            discipline.EstimatedCompleted = (float)divitionDiscResult * 100;

            // Get Project && Calculate Estimated Hours
            var project = await _context.Set<Project>()
                                        .Include(p => p.DailyTime)
                                        .FirstOrDefaultAsync(p => p.Id == projectId);
            if (project == null)
                throw new NullReferenceException(nameof(project));
            var projectsTimes = project.DailyTime.Select(dt => dt.TimeSpan).ToList();
            var projectMenHours = await _context.Set<DailyTime>()
                                          .Where(d => d.ProjectId == projectId)
                                          .Select(d => d.TimeSpan.Hours)
                                          .SumAsync();
            decimal divitionProResult = Convert.ToDecimal(projectMenHours) 
                                                    / Convert.ToDecimal(project.EstimatedHours);
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

    public async Task RemoveDesigners(int drawingId, ICollection<int> designersIds)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var designers = await _context.Set<DrawingEmployee>()
                                              .Where(d => designersIds.Contains(d.EmployeeId) 
                                                                        && d.DrawingId == drawingId)
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