using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
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
            // Get User Roles
            var roleIds = await _context.Set<UserRole>()
                                        .Where(r => r.UserId == userId)
                                        .Select(r => r.RoleId)
                                        .ToListAsync();

            var roles = await _context.Roles.Where(r => roleIds.Contains(r.Id))
                                            .ToListAsync();

            if (roles.Any(r => r.Name.Equals("CEO")
                    || r.Name.Equals("CTO") || r.Name.Equals("COO")))
            {
                var allProjects = await _context.Set<Project>().ToListAsync();

                return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(allProjects.Distinct().ToList());
            }

            // Filter Projects
            var myDrawingIds = await _context.Set<DrawingEmployee>()
                                             .Where(de => de.EmployeeId == userId)
                                             .Select(e => e.DrawingId)
                                             .ToListAsync();

            var drawingsDisciplinesIds = await _context.Set<DisciplineDraw>()
                                                 .Where(dd => myDrawingIds.Contains(dd.DrawId))
                                                 .Select(e => e.DisciplineId)
                                                 .ToListAsync();

            var engineerDisciplineIds = await _context.Set<DisciplineEngineer>()
                                                      .Where(d => d.EngineerId == userId)
                                                      .Select(e => e.DisciplineId)
                                                      .ToListAsync();

            var myDisciplinesIds = drawingsDisciplinesIds.Union(engineerDisciplineIds);

            var projectsFromDisciplineIds = await _context.Set<DisciplinePoject>()
                                                        .Where(dp => myDisciplinesIds.Contains(dp.DisciplineId))
                                                        .Select(dp => dp.ProjectId)
                                                        .ToArrayAsync();

            var projectsFromProjectManagerIds = await _context.Set<ProjectPmanager>()
                                                        .Where(pp => pp.ProjectManagerId == userId)
                                                        .Select(pp => pp.ProjectId)
                                                        .ToArrayAsync();

            var projectsIds = projectsFromDisciplineIds.Union(projectsFromProjectManagerIds);

            var projects = await _context.Set<Project>().Where(p => projectsIds.Contains(p.Id)).ToListAsync();

            return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
        }
    }

    public new async Task<ICollection<ProjectDto>> GetAll(int userId, int pageSize = 0, int pageIndex = 0)
    {
        List<Project> projects;
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            // Get User Roles
            var roleIds = await _context.Set<UserRole>()
                                        .Where(r => r.UserId == userId)
                                        .Select(r => r.RoleId)
                                        .ToListAsync();

            var roles = await _context.Roles.Where(r => roleIds.Contains(r.Id))
                                            .ToListAsync();

            if (roles.Any(r => r.Name.Equals("CEO")
                    || r.Name.Equals("CTO") || r.Name.Equals("COO")))
            {
                if (pageSize == 0 || pageIndex == 0)
                {
                    projects = await _context.Set<Project>()
                                             .OrderBy(e => e.DeadLine)
                                             .ToListAsync();

                    return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
                }

                projects = await _context.Set<Project>()
                                         .Skip((pageIndex - 1) * pageSize)
                                         .Take(pageSize)
                                         .OrderBy(e => e.DeadLine)
                                         .ToListAsync();

                return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
            }

            // Filter Projects
            var myDrawingIds = await _context.Set<DrawingEmployee>()
                                             .Where(de => de.EmployeeId == userId)
                                             .Select(e => e.DrawingId)
                                             .ToListAsync();

            var drawingsDisciplinesIds = await _context.Set<DisciplineDraw>()
                                                 .Where(dd => myDrawingIds.Contains(dd.DrawId))
                                                 .Select(e => e.DisciplineId)
                                                 .ToListAsync();

            var engineerDisciplineIds = await _context.Set<DisciplineEngineer>()
                                                      .Where(d => d.EngineerId == userId)
                                                      .Select(e => e.DisciplineId)
                                                      .ToListAsync();

            var myDisciplinesIds = drawingsDisciplinesIds.Union(engineerDisciplineIds);

            var projectsFromDisciplineIds = await _context.Set<DisciplinePoject>()
                                                        .Where(dp => myDisciplinesIds.Contains(dp.DisciplineId))
                                                        .Select(dp => dp.ProjectId)
                                                        .ToArrayAsync();

            var projectsFromProjectManagerIds = await _context.Set<ProjectPmanager>()
                                                        .Where(pp => pp.ProjectManagerId == userId)
                                                        .Select(pp => pp.ProjectId)
                                                        .ToArrayAsync();

            var projectsIds = projectsFromDisciplineIds.Union(projectsFromProjectManagerIds);

            if (pageSize == 0 || pageIndex == 0)
            {
                projects = await _context.Set<Project>()
                                         .Where(p => projectsIds.Contains(p.Id))
                                         .OrderBy(e => e.DeadLine)
                                         .ToListAsync();

                return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
            }

            projects = await _context.Set<Project>()
                                     .Where(p => projectsIds.Contains(p.Id))
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
            // Get User Roles
            var roleIds = await _context.Set<UserRole>()
                                        .Where(r => r.UserId == userId)
                                        .Select(r => r.RoleId)
                                        .ToListAsync();

            var roles = await _context.Roles.Where(r => roleIds.Contains(r.Id))
                                            .ToListAsync();

            if (roles.Any(r => r.Name.Equals("CEO")
                    || r.Name.Equals("CTO") || r.Name.Equals("COO")))
            {
                if (pageSize == 0 || pageIndex == 0)
                {
                    projects = await _context.Set<Project>()
                                             .Where(expresion)
                                             .OrderBy(e => e.DeadLine)
                                             .ToListAsync();

                    return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
                }

                projects = await _context.Set<Project>()
                                         .Where(expresion)
                                         .Skip((pageIndex - 1) * pageSize)
                                         .Take(pageSize)
                                         .OrderBy(e => e.DeadLine)
                                         .ToListAsync();

                return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
            }

            // Filter Projects
            var myDrawingIds = await _context.Set<DrawingEmployee>()
                                             .Where(de => de.EmployeeId == userId)
                                             .Select(e => e.DrawingId)
                                             .ToListAsync();

            var drawingsDisciplinesIds = await _context.Set<DisciplineDraw>()
                                                 .Where(dd => myDrawingIds.Contains(dd.DrawId))
                                                 .Select(e => e.DisciplineId)
                                                 .ToListAsync();

            var engineerDisciplineIds = await _context.Set<DisciplineEngineer>()
                                                      .Where(d => d.EngineerId == userId)
                                                      .Select(e => e.DisciplineId)
                                                      .ToListAsync();

            var myDisciplinesIds = drawingsDisciplinesIds.Union(engineerDisciplineIds);

            var projectsFromDisciplineIds = await _context.Set<DisciplinePoject>()
                                                        .Where(dp => myDisciplinesIds.Contains(dp.DisciplineId))
                                                        .Select(dp => dp.ProjectId)
                                                        .ToArrayAsync();

            var projectsFromProjectManagerIds = await _context.Set<ProjectPmanager>()
                                                        .Where(pp => pp.ProjectManagerId == userId)
                                                        .Select(pp => pp.ProjectId)
                                                        .ToArrayAsync();

            var projectsIds = projectsFromDisciplineIds.Union(projectsFromProjectManagerIds);

            if (pageSize == 0 || pageIndex == 0)
            {
                projects = await _context.Set<Project>()
                                         .Where(p => projectsIds.Contains(p.Id))
                                         .Where(expresion)
                                         .OrderBy(e => e.DeadLine)
                                         .ToListAsync();

                return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
            }

            projects = await _context.Set<Project>()
                                     .Where(p => projectsIds.Contains(p.Id))
                                     .Where(expresion)
                                     .Skip((pageIndex - 1) * pageSize)
                                     .Take(pageSize)
                                     .OrderBy(e => e.DeadLine)
                                     .ToListAsync();

            return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
        }
    }

    public async Task<long> GetMenHoursAsync(int projectId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context.Set<ManHour>()
                                 .Where(mh => mh.ProjectId == projectId)
                                 .Select(mh => mh.Hours)
                                 .SumAsync();
        }
    }

    public long GetMenHours(int projectId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return _context.Set<ManHour>()
                                 .Where(mh => mh.ProjectId == projectId)
                                 .Select(mh => mh.Hours)
                                 .Sum();
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

    public async Task<ICollection<UserDto>> GetProjectManagers(int projectId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var users = await _context.Set<ProjectPmanager>()
                                      .Where(de => de.ProjectId == projectId)
                                      .Include(de => de.ProjectManager)
                                      .Select(de => de.ProjectManager)
                                      .ToListAsync();

            return Mapping.Mapper.Map<List<UserDto>>(users);
        }
    }

    public async Task AddProjectManager(int projectId, ICollection<UserDto> pms)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            foreach (var e in pms)
            {
                ProjectPmanager pm = new ProjectPmanager()
                {
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    ProjectId = projectId,
                    ProjectManagerId = e.Id
                };

                // Check If Exists
                var exists = await _context.Set<ProjectPmanager>()
                    .AnyAsync(pm => pm.ProjectId == projectId && pm.ProjectManagerId == e.Id);
                if (exists) continue;

                await _context.Set<ProjectPmanager>().AddAsync(pm);
                await _context.SaveChangesAsync();
            }
        }
    }

    public async Task RemoveProjectManager(int projectId, ICollection<int> projectManagersIds)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var pms = await _context.Set<ProjectPmanager>()
                                              .Where(d => projectManagersIds.Contains(d.ProjectManagerId)
                                                                && d.ProjectId == projectId)
                                              .ToListAsync();

            if (pms == null)
                throw new NullReferenceException(nameof(pms));

            foreach (var projectManager in pms)
            {
                _context.Set<ProjectPmanager>().Remove(projectManager);
            }

            await _context.SaveChangesAsync();
        }
    }
}
