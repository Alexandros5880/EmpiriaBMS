using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models;
using EmpiriaMS.Models.Models;
using EmpiriaMS.Models.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Config;
using AutoMapper;
using EmpiriaBMS.Core.ReturnModels;
using System.Collections;

namespace EmpiriaBMS.Core.Repositories;
public class ProjectsRepo : Repository<ProjectDto, Project>
{
    public ProjectsRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public new async Task<ProjectDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context
                             .Set<Project>()
                             .Include(r => r.Customer)
                             .Include(r => r.Invoice)
                             .Select(r => Mapping.Mapper.Map<ProjectDto>(r))
                             .FirstOrDefaultAsync(r => r.Id == id);
        }
    }

    public new async Task<ICollection<ProjectDto>> GetAll()
    {
        List<Project> projects;
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            projects = await _context.Set<Project>()
                                      .Include(r => r.Customer)
                                      .Include(r => r.Invoice)
                                      .OrderBy(e => e.DeadLine)
                                      .ToListAsync();

            return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
        }
    }

    public new async Task<ICollection<ProjectDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        List<Project> projects;
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (pageSize == 0 || pageIndex == 0)
            {
                projects = await _context.Set<Project>()
                                         .Include(r => r.Customer)
                                         .Include(r => r.Invoice)
                                         .OrderBy(e => e.DeadLine)
                                         .ToListAsync();
                return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
            }

            projects =  await _context.Set<Project>()
                                      .Skip((pageIndex - 1) * pageSize)
                                      .Take(pageSize)
                                      .Include(r => r.Customer)
                                      .Include(r => r.Invoice)
                                      .OrderBy(e => e.DeadLine)
                                      .ToListAsync();

            return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
        }
    }

    public new async Task<ICollection<ProjectDto>> GetAll(
        Expression<Func<Project, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Project> projects;
            if (pageSize == 0 || pageIndex == 0)
            {
                projects = await _context.Set<Project>()
                                         .Where(expresion)
                                         .Include(r => r.Customer)
                                         .Include(r => r.Invoice)
                                         .OrderBy(e => e.DeadLine)
                                         .ToListAsync();
                return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
            }

            projects = await _context.Set<Project>()
                                     .Where(expresion)
                                     .Skip((pageIndex - 1) * pageSize)
                                     .Take(pageSize)
                                     .Include(r => r.Customer)
                                     .Include(r => r.Invoice)
                                     .OrderBy(e => e.DeadLine)
                                     .ToListAsync();

            return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
        }
    }

    public new async Task<ICollection<ProjectDto>> GetAll(int userId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var disciplineIds = await _context.Set<DisciplineEmployee>()
                                            .Where(de => de.EmployeeId == userId)
                                            .Select(de => de.DisciplineId)
                                            .ToListAsync();

            var projects= await _context.Set<DisciplinePoject>()
                                            .Where(d => disciplineIds.Contains(d.DisciplineId))
                                            .Select(dp => dp.Project)
                                            .OrderBy(e => e.DeadLine)
                                            .ToListAsync();

            return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
        }
    }

    public new async Task<ICollection<ProjectDto>> GetAll(int userId, int pageSize = 0, int pageIndex = 0)
    {
        List<Project> projects;
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var disciplineIds = await _context.Set<DisciplineEmployee>()
                                            .Where(de => de.EmployeeId == userId)
                                            .Select(de => de.DisciplineId)
                                            .ToListAsync();


            if (pageSize == 0 || pageIndex == 0)
            {
                projects = await _context.Set<DisciplinePoject>()
                                         .Where(d => disciplineIds.Contains(d.DisciplineId))
                                         .Select(dp => dp.Project)
                                         .OrderBy(e => e.DeadLine)
                                         .ToListAsync();

                return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
            }

            projects = await _context.Set<DisciplinePoject>()
                                     .Where(d => disciplineIds.Contains(d.DisciplineId))
                                     .Select(dp => dp.Project)
                                     .Skip((pageIndex - 1) * pageSize)
                                     .Take(pageSize)
                                     .OrderBy(e => e.DeadLine)
                                     .ToListAsync();

            return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
        }
    }

    public new async Task<ICollection<ProjectDto>> GetAll(
        Expression<Func<Project, bool>> expresion, 
        int userId, 
        int pageSize = 0,
        int pageIndex = 0
    ) {
        List<Project> projects;
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var disciplineIds = await _context.Set<DisciplineEmployee>()
                                              .Where(de => de.EmployeeId == userId)
                                              .Select(de => de.DisciplineId)
                                              .ToListAsync();

            if (pageSize == 0 || pageIndex == 0)
            {
                projects = await _context.Set<DisciplinePoject>()
                                         .Where(d => disciplineIds.Contains(d.DisciplineId))
                                         .Select(dp => dp.Project)
                                         .Where(expresion)
                                         .OrderBy(e => e.DeadLine)
                                         .ToListAsync();

                return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
            }

            projects = await _context.Set<DisciplinePoject>()
                                     .Where(d => disciplineIds.Contains(d.DisciplineId))
                                     .Select(dp => dp.Project)
                                     .Where(expresion)
                                     .Skip((pageIndex - 1) * pageSize)
                                     .Take(pageSize)
                                     .OrderBy(e => e.DeadLine)
                                     .ToListAsync();

            return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
        }
    }

    public async Task<ICollection<DisciplineDto>> GetDisciplines(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var disciplines = await _context.Set<DisciplinePoject>()
                                             .Where(de => de.ProjectId == id)
                                             .Select(de => de.Discipline)
                                             .ToListAsync();

            return Mapping.Mapper.Map<List<Discipline>, List<DisciplineDto>>(disciplines);
        }
    }

    public async Task<int> CountDiscipline(int id)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
            return await _context.Set<DisciplinePoject>()
                                 .Where(de => de.ProjectId == id)
                                 .CountAsync();
    }

    public async Task<int> GetUsersWorkPackegedCompleted(int userId)
    {
        if (userId == 0)
            throw new ArgumentException(nameof(userId));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var disciplines = await _context.Set<DisciplineEmployee>()
                                              .Where(de => de.EmployeeId == userId)
                                              .Select(de => de.Discipline)
                                              .ToListAsync();

            var Draws2D = disciplines.Select(d => d.DisciplinesDraws.Select(dd => dd.Draw));
            List<int?> drawsCompleteds = new List<int?>();

            foreach (var d1 in Draws2D)
                foreach (var d2 in d1)
                    drawsCompleteds.Add(d2.CompletionEstimation);

            return drawsCompleteds.Sum() ?? 0;
        }
    }

    public async Task<CompletedResult> CalcProjectComplete(ProjectDto project, DrawDto draw, int logedUserId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            // Get Loges User DesciplineIds
            var disciplinesUserIds = await _context
                                        .Set<DisciplineEmployee>()
                                        .Where(de => de.EmployeeId == logedUserId)
                                        .Select(de => de.DisciplineId)
                                        .ToListAsync();

            // Get Selected Projects Desciplines
            var disciplinesProjectIds = await _context
                                            .Set<DisciplinePoject>()
                                            .Where(dp => dp.ProjectId == project.Id)
                                            .Where(dp => disciplinesUserIds.Contains(dp.DisciplineId))
                                            .Select(de => de.DisciplineId)
                                            .ToListAsync();

            // Add 2 List Remove Duplicates
            List<int> disciplinesIds = disciplinesUserIds.Union(disciplinesProjectIds).ToList();
            int disciplinesCount = disciplinesIds.Count();

            // Get Draws Sum Of Draws.CompletionEstimation
            List<Draw> draws = await _context
                                    .Set<DisciplineDraw>()
                                    .Where(dd => disciplinesIds.Contains(dd.DisciplineId))
                                    .Select(dd => dd.Draw)
                                    .ToListAsync();
            draws.Add(Mapping.Mapper.Map<Draw>(draw));
            var sumDrawsComp = draws.Select(m => m.CompletionEstimation).Sum();

            // Some Project Completion
            var sumProjectCompl = sumDrawsComp;



            var estimatedHours = project.EstimatedHours;
            var projectHours = project.MenHours;



            // Project Completed
            var projectCompleted = Convert.ToInt32((sumProjectCompl / estimatedHours) * 100);

            CompletedResult result = new CompletedResult()
            {
                ProjectCompleted = projectCompleted,
                DisciplineCompleted = projectCompleted / disciplinesCount,
                DrawCompleted = (projectCompleted / 2) / draws.Count
            };

            return result;
        }
    }

}
