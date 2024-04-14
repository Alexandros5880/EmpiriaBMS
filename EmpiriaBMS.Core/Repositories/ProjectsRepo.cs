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
                             .Include(r => r.Invoices)
                             .Include(p => p.Stage)
                             .Include(p => p.Address)
                             .Include(p => p.Category)
                             .Include(p => p.ProjectManager)
                             .Include(p => p.ProjectsSubConstructors)
                             .Select(r => Mapping.Mapper.Map<ProjectDto>(r))
                             .FirstOrDefaultAsync(r => r.Id == id);
        }
    }

    public async Task<ICollection<ProjectDto>> GetAll()
    {
        List<Project> projects;
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            projects = await _context.Set<Project>()
                                      .Include(r => r.Customer)
                                      .Include(r => r.Invoices)
                                      .Include(p => p.Stage)
                                      .Include(p => p.Address)
                                      .Include(p => p.Category)
                                      .Include(p => p.ProjectManager)
                                      .Include(p => p.ProjectsSubConstructors)
                                      .OrderBy(e => !e.Active)
                                      .ThenByDescending(e => e.DeadLine)
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
                                         .Include(r => r.Invoices)
                                         .Include(p => p.Stage)
                                         .Include(p => p.Address)
                                         .Include(p => p.Category)
                                         .Include(p => p.ProjectManager)
                                         .Include(p => p.ProjectsSubConstructors)
                                         .OrderBy(e => !e.Active)
                                         .ThenByDescending(e => e.DeadLine)
                                         .ToListAsync();
                return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
            }

            projects =  await _context.Set<Project>()
                                      .Skip((pageIndex - 1) * pageSize)
                                      .Take(pageSize)
                                      .Include(r => r.Customer)
                                      .Include(r => r.Invoices)
                                      .Include(p => p.Stage)
                                      .Include(p => p.Address)
                                      .Include(p => p.Category)
                                      .Include(p => p.ProjectManager)
                                      .Include(p => p.ProjectsSubConstructors)
                                      .OrderBy(e => !e.Active)
                                      .ThenByDescending(e => e.DeadLine)
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
                                         .Include(r => r.Invoices)
                                         .Include(p => p.Stage)
                                         .Include(p => p.Address)
                                         .Include(p => p.Category)
                                         .Include(p => p.ProjectManager)
                                         .Include(p => p.ProjectsSubConstructors)
                                         .OrderBy(e => !e.Active)
                                         .ThenByDescending(e => e.DeadLine)
                                         .ToListAsync();
                return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
            }

            projects = await _context.Set<Project>()
                                     .Where(expresion)
                                     .Skip((pageIndex - 1) * pageSize)
                                     .Take(pageSize)
                                     .Include(r => r.Customer)
                                     .Include(r => r.Invoices)
                                     .Include(p => p.Stage)
                                     .Include(p => p.Address)
                                     .Include(p => p.Category)
                                     .Include(p => p.ProjectManager)
                                     .Include(p => p.ProjectsSubConstructors)
                                     .OrderBy(e => !e.Active)
                                     .ThenByDescending(e => e.DeadLine)
                                     .ToListAsync();

            return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
        }
    }

    public async Task<ICollection<ProjectDto>> GetAll(int userId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            // Get User Roles
            var roleIds = await _context.Set<UserRole>()
                                        .Where(r => r.UserId == userId)
                                        .Select(r => r.RoleId)
                                        .ToListAsync();

            // Get Roles Permissions
            var permissions = await _context.Set<RolePermission>()
                                            .Where(pr => roleIds.Contains(pr.RoleId))
                                            .Include(pr => pr.Permission)
                                            .Select(pr => pr.Permission)
                                            .ToListAsync();

            if (permissions.Any(p => p.Ord == 11))
            {
                var allProjects = await _context.Set<Project>()
                                                .Include(r => r.Customer)
                                                .Include(r => r.Invoices)
                                                .Include(p => p.Stage)
                                                .Include(p => p.Address)
                                                .Include(p => p.Category)
                                                .Include(p => p.ProjectManager)
                                                .Include(p => p.ProjectsSubConstructors)
                                                .OrderBy(e => !e.Active)
                                                .ThenByDescending(e => e.DeadLine)
                                                .ToListAsync();

                return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(allProjects.Distinct().ToList());
            }

            // Filter Projects
            var myDrawingIds = await _context.Set<DrawingEmployee>()
                                             .Where(de => de.EmployeeId == userId)
                                             .Select(e => e.DrawingId)
                                             .ToListAsync();

            var drawingsDisciplinesIds = await _context.Set<Drawing>()
                                                 .Where(dd => myDrawingIds.Contains(dd.Id))
                                                 .Select(e => e.DisciplineId)
                                                 .ToListAsync();

            var engineerDisciplineIds = await _context.Set<DisciplineEngineer>()
                                                      .Where(d => d.EngineerId == userId)
                                                      .Select(e => e.DisciplineId)
                                                      .ToListAsync();

            var myDisciplinesIds = drawingsDisciplinesIds.Union(engineerDisciplineIds);

            var projectsFromDisciplineIds = await _context.Set<Discipline>()
                                                        .Where(d => myDisciplinesIds.Contains(d.Id))
                                                        .Select(dp => dp.ProjectId)
                                                        .ToArrayAsync();

            var projects = await _context.Set<Project>()
                                         .Include(r => r.Customer)
                                         .Include(r => r.Invoices)
                                         .Include(p => p.Stage)
                                         .Include(p => p.Address)
                                         .Include(p => p.Category)
                                         .Include(p => p.ProjectManager)
                                         .Include(p => p.ProjectsSubConstructors)
                                         .Where(p => projectsFromDisciplineIds.Contains(p.Id))
                                         .OrderBy(e => !e.Active)
                                         .ThenByDescending(e => e.DeadLine)
                                         .ToListAsync();

            return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
        }
    }

    public async Task<ICollection<ProjectDto>> GetAll(Expression<Func<Project, bool>> expresion, int userId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            // Get User Roles
            var roleIds = await _context.Set<UserRole>()
                                        .Where(r => r.UserId == userId)
                                        .Select(r => r.RoleId)
                                        .ToListAsync();

            // Get Roles Permissions
            var permissions = await _context.Set<RolePermission>()
                                            .Where(pr => roleIds.Contains(pr.RoleId))
                                            .Include(pr => pr.Permission)
                                            .Select(pr => pr.Permission)
                                            .ToListAsync();


            if (permissions.Any(p => p.Ord == 11))
            {
                var allProjects = await _context.Set<Project>()
                                                .Where(expresion)
                                                .Include(r => r.Customer)
                                                .Include(r => r.Invoices)
                                                .Include(p => p.Stage)
                                                .Include(p => p.Address)
                                                .Include(p => p.Category)
                                                .Include(p => p.ProjectManager)
                                                .Include(p => p.ProjectsSubConstructors)
                                                .OrderBy(e => !e.Active)
                                                .ThenByDescending(e => e.DeadLine)
                                                .ToListAsync();

                return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(allProjects.Distinct().ToList());
            }

            // Filter Projects
            var myDrawingIds = await _context.Set<DrawingEmployee>()
                                             .Where(de => de.EmployeeId == userId)
                                             .Select(e => e.DrawingId)
                                             .ToListAsync();

            var drawingsDisciplinesIds = await _context.Set<Drawing>()
                                                 .Where(dd => myDrawingIds.Contains(dd.Id))
                                                 .Select(e => e.DisciplineId)
                                                 .ToListAsync();

            var engineerDisciplineIds = await _context.Set<DisciplineEngineer>()
                                                      .Where(d => d.EngineerId == userId)
                                                      .Select(e => e.DisciplineId)
                                                      .ToListAsync();

            var myDisciplinesIds = drawingsDisciplinesIds.Union(engineerDisciplineIds);

            var projectsFromDisciplineIds = await _context.Set<Discipline>()
                                                        .Where(d => myDisciplinesIds.Contains(d.Id))
                                                        .Select(dp => dp.ProjectId)
                                                        .ToArrayAsync();

            var projects = await _context.Set<Project>()
                                         .Where(p => projectsFromDisciplineIds.Contains(p.Id))
                                         .Where(expresion)
                                         .Include(r => r.Customer)
                                         .Include(r => r.Invoices)
                                         .Include(p => p.Stage)
                                         .Include(p => p.Address)
                                         .Include(p => p.Category)
                                         .Include(p => p.ProjectManager)
                                         .Include(p => p.ProjectsSubConstructors)
                                         .OrderBy(e => !e.Active)
                                         .ThenByDescending(e => e.DeadLine)
                                         .ToListAsync();

            return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
        }
    }

    public async Task<ICollection<ProjectDto>> GetAll(int userId, int pageSize = 0, int pageIndex = 0)
    {
        List<Project> projects;
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            // Get User Roles
            var roleIds = await _context.Set<UserRole>()
                                        .Where(r => r.UserId == userId)
                                        .Select(r => r.RoleId)
                                        .ToListAsync();

            // Get Roles Permissions
            var permissions = await _context.Set<RolePermission>()
                                            .Where(pr => roleIds.Contains(pr.RoleId))
                                            .Include(pr => pr.Permission)
                                            .Select(pr => pr.Permission)
                                            .ToListAsync();

            if (permissions.Any(p => p.Ord == 11))
            {
                var allProjects = await _context.Set<Project>().ToListAsync();

                if (pageSize == 0 || pageIndex == 0)
                {
                    projects = await _context.Set<Project>()
                                             .OrderBy(e => !e.Active)
                                             .ThenByDescending(e => e.DeadLine)
                                             .ToListAsync();

                    return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
                }

                projects = await _context.Set<Project>()
                                         .Skip((pageIndex - 1) * pageSize)
                                         .Take(pageSize)
                                         .Include(r => r.Invoices)
                                         .Include(p => p.Stage)
                                         .Include(p => p.Address)
                                         .Include(p => p.Category)
                                         .Include(p => p.ProjectManager)
                                         .Include(p => p.ProjectsSubConstructors)
                                         .Include(p => p.Customer)
                                         .OrderBy(e => !e.Active)
                                         .ThenByDescending(e => e.DeadLine)
                                         .ToListAsync();

                return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
            }

            // Filter Projects
            var myDrawingIds = await _context.Set<DrawingEmployee>()
                                             .Where(de => de.EmployeeId == userId)
                                             .Select(e => e.DrawingId)
                                             .ToListAsync();

            var drawingsDisciplinesIds = await _context.Set<Drawing>()
                                                 .Where(d => myDrawingIds.Contains(d.Id))
                                                 .Select(e => e.DisciplineId)
                                                 .ToListAsync();

            var engineerDisciplineIds = await _context.Set<DisciplineEngineer>()
                                                      .Where(d => d.EngineerId == userId)
                                                      .Select(e => e.DisciplineId)
                                                      .ToListAsync();

            var myDisciplinesIds = drawingsDisciplinesIds.Union(engineerDisciplineIds);

            var projectsFromDisciplineIds = await _context.Set<Discipline>()
                                                        .Where(d => myDisciplinesIds.Contains(d.Id))
                                                        .Select(dp => dp.ProjectId)
                                                        .ToArrayAsync();

            if (pageSize == 0 || pageIndex == 0)
            {
                projects = await _context.Set<Project>()
                                         .Where(p => projectsFromDisciplineIds.Contains(p.Id))
                                         .Include(r => r.Invoices)
                                         .Include(p => p.Stage)
                                         .Include(p => p.Address)
                                         .Include(p => p.Category)
                                         .Include(p => p.ProjectManager)
                                         .Include(p => p.ProjectsSubConstructors)
                                         .Include(p => p.Customer)
                                         .OrderBy(e => !e.Active)
                                         .ThenByDescending(e => e.DeadLine)
                                         .ToListAsync();

                return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
            }

            projects = await _context.Set<Project>()
                                     .Where(p => projectsFromDisciplineIds.Contains(p.Id))
                                     .Skip((pageIndex - 1) * pageSize)
                                     .Take(pageSize)
                                     .Include(r => r.Invoices)
                                     .Include(p => p.Stage)
                                     .Include(p => p.Address)
                                     .Include(p => p.Category)
                                     .Include(p => p.ProjectManager)
                                     .Include(p => p.ProjectsSubConstructors)
                                     .Include(p => p.Customer)
                                     .OrderBy(e => !e.Active)
                                     .ThenByDescending(e => e.DeadLine)
                                     .ToListAsync();

            return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
        }
    }

    public async Task<ICollection<ProjectDto>> GetAll(
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

            // Get Roles Permissions
            var permissions = await _context.Set<RolePermission>()
                                            .Where(pr => roleIds.Contains(pr.RoleId))
                                            .Include(pr => pr.Permission)
                                            .Select(pr => pr.Permission)
                                            .ToListAsync();

            // Permission 11 See All Projects
            if (permissions.Any(p => p.Ord == 11))
            {
                if (pageSize == 0 || pageIndex == 0)
                {
                    projects = await _context.Set<Project>()
                                             .Where(expresion)
                                             .Include(r => r.Invoices)
                                             .Include(p => p.Stage)
                                             .Include(p => p.Address)
                                             .Include(p => p.Category)
                                             .Include(p => p.ProjectManager)
                                             .Include(p => p.ProjectsSubConstructors)
                                             .Include(p => p.Customer)
                                             .OrderBy(e => !e.Active)
                                             .ThenByDescending(e => e.DeadLine)
                                             .ToListAsync();

                    return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
                }

                projects = await _context.Set<Project>()
                                         .Where(expresion)
                                         .Skip((pageIndex - 1) * pageSize)
                                         .Take(pageSize)
                                         .Include(r => r.Invoices)
                                         .Include(p => p.Stage)
                                         .Include(p => p.Address)
                                         .Include(p => p.Category)
                                         .Include(p => p.ProjectManager)
                                         .Include(p => p.ProjectsSubConstructors)
                                         .Include(p => p.Customer)
                                         .OrderBy(e => !e.Active)
                                         .ThenByDescending(e => e.DeadLine)
                                         .ToListAsync();

                return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
            }


            // Filter Projects
            var myDrawingIds = await _context.Set<DrawingEmployee>()
                                             .Where(de => de.EmployeeId == userId)
                                             .Select(e => e.DrawingId)
                                             .ToListAsync();

            var drawingsDisciplinesIds = await _context.Set<Drawing>()
                                                 .Where(d => myDrawingIds.Contains(d.Id))
                                                 .Select(e => e.DisciplineId)
                                                 .ToListAsync();

            var engineerDisciplineIds = await _context.Set<DisciplineEngineer>()
                                                      .Where(d => d.EngineerId == userId)
                                                      .Select(e => e.DisciplineId)
                                                      .ToListAsync();

            var myDisciplinesIds = drawingsDisciplinesIds.Union(engineerDisciplineIds);

            var projectsFromDisciplineIds = await _context.Set<Discipline>()
                                                        .Where(d => myDisciplinesIds.Contains(d.Id))
                                                        .Select(dp => dp.ProjectId)
                                                        .ToArrayAsync();

            if (pageSize == 0 || pageIndex == 0)
            {
                projects = await _context.Set<Project>()
                                         .Where(p => projectsFromDisciplineIds.Contains(p.Id))
                                         .Where(expresion)
                                         .Include(r => r.Invoices)
                                         .Include(p => p.Stage)
                                         .Include(p => p.Address)
                                         .Include(p => p.Category)
                                         .Include(p => p.ProjectManager)
                                         .Include(p => p.ProjectsSubConstructors)
                                         .Include(p => p.Customer)
                                         .OrderBy(e => !e.Active)
                                         .ThenByDescending(e => e.DeadLine)
                                         .ToListAsync();

                return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
            }

            projects = await _context.Set<Project>()
                                     .Where(p => projectsFromDisciplineIds.Contains(p.Id))
                                     .Where(expresion)
                                     .Skip((pageIndex - 1) * pageSize)
                                     .Take(pageSize)
                                     .Include(r => r.Invoices)
                                     .Include(p => p.Stage)
                                     .Include(p => p.Address)
                                     .Include(p => p.Category)
                                     .Include(p => p.ProjectManager)
                                     .Include(p => p.ProjectsSubConstructors)
                                     .Include(p => p.Customer)
                                     .OrderBy(e => !e.Active)
                                     .ThenByDescending(e => e.DeadLine)
                                     .ToListAsync();

            return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
        }
    }

    public async Task<long> GetMenHoursAsync(int projectId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context.Set<DailyTime>()
                                 .Where(mh => mh.ProjectId == projectId)
                                 .Include(mh => mh.TimeSpan)
                                 .Select(mh => mh.TimeSpan.Hours)
                                 .SumAsync();
        }
    }

    public long GetMenHours(int projectId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return _context.Set<DailyTime>()
                           .Where(mh => mh.ProjectId == projectId)
                           .Include(mh => mh.TimeSpan)
                           .Select(mh => mh.TimeSpan.Hours)
                           .Sum();
        }
    }

    public async Task<ICollection<DisciplineDto>> GetDisciplines(int projectId, int userId, bool all)
    {
        if (projectId == 0)
            throw new ArgumentNullException(nameof(projectId));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Discipline> disciplines = new List<Discipline>();

            if (all)
            {
                disciplines = await _context.Set<Discipline>()
                                             .Where(de => de.ProjectId == projectId)
                                             .Include(d => d.Type)
                                             .ToListAsync();
            }
            else
            {
                var myDrawingsIds = await _context.Set<DrawingEmployee>()
                                            .Where(de => de.EmployeeId == userId)
                                            .Select(de => de.DrawingId)
                                            .ToListAsync();

                var myDisciplinesIds = await _context.Set<Drawing>()
                                                .Where(d => myDrawingsIds.Contains(d.Id))
                                                .Select(dd => dd.DisciplineId)
                                                .ToListAsync();

                disciplines = await _context.Set<Discipline>()
                                             .Where(d => d.ProjectId == projectId && 
                                                                myDisciplinesIds.Contains(d.Id))
                                             .Include(d => d.Type)
                                             .ToListAsync();
            }

            return Mapping.Mapper.Map<List<Discipline>, List<DisciplineDto>>(disciplines);
        }
    }

    public async Task<int> CountDiscipline(int id)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
            return await _context.Set<Discipline>()
                                 .Where(de => de.ProjectId == id)
                                 .CountAsync();
    }

    public async Task UpdateDisciplines(int projectId, List<DisciplineDto> disciplines)
    {
        if (projectId == 0)
            throw new ArgumentNullException(nameof(projectId));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            // Get Project
            var project = await _context.Set<Project>().FirstOrDefaultAsync(p => p.Id == projectId);
            if (project == null)
                throw new ArgumentNullException(nameof(project));

            var otherTypes = await _context.Set<OtherType>().ToListAsync();

            // Calculate Disciplines Estimated Hours, Disciplines Estimated ManDays, Disciplines EstimatedCompleted
            foreach (var d in disciplines)
            {
                d.EstimatedHours = d.EstimatedMandays * 8;

                // Calculate Discipline EstimatedCompleted
                var disciplineMenHours = await _context.Set<DailyTime>()
                                                       .Where(d => d.DisciplineId == d.Id)
                                                       .Select(d => d.TimeSpan.Hours)
                                                       .SumAsync();
                decimal divitionDiscResult = Convert.ToDecimal(disciplineMenHours)
                                                        / Convert.ToDecimal(d.EstimatedHours);
                d.EstimatedCompleted = (float)divitionDiscResult * 100;

                // Update Discipline Project
                d.ProjectId = projectId;

                // Update Discipline
                var exists = await _context.Set<Discipline>().AnyAsync(disc => disc.Id == d.Id);
                if (exists)
                {
                    var dbDisc = await _context.Set<Discipline>().FirstOrDefaultAsync(disc => disc.Id == d.Id);
                    if (dbDisc == null)
                        throw new NullReferenceException(nameof(dbDisc));
                    _context.Entry<Discipline>(dbDisc).CurrentValues.SetValues(Mapping.Mapper.Map<Discipline>(d));
                }
                else
                {
                    var savedDiscipline = await _context.Set<Discipline>().AddAsync(Mapping.Mapper.Map<Discipline>(d));
                    await _context.SaveChangesAsync();

                    var savedDisciplineId = savedDiscipline.Entity.Id;

                    // Create Supportive Works For Every Discipline
                    foreach (var t in otherTypes)
                    {
                        Other other = new Other()
                        {
                            TypeId = t.Id,
                            DisciplineId = savedDisciplineId
                        };
                        await _context.Set<Other>().AddAsync(other);
                    }
                }
            }

            // Get Sum EstimatedManDays && EstimatedHours and update Project
            var estimatedManDaysSum = disciplines.Select(d => d.EstimatedMandays).Sum();
            var estimatedHoursSum = disciplines.Select(d => d.EstimatedHours).Sum();
            project.EstimatedMandays = estimatedManDaysSum;
            project.EstimatedHours = estimatedHoursSum;

            // Calculate Project EstimatedComplete
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

    public async Task<UserDto> GetProjectManager(int projectId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var p = await _context.Set<Project>()
                                  .FirstOrDefaultAsync(p => p.Id == projectId);

            if (p == null)
                throw new NullReferenceException(nameof(p));

            var pmId = p.ProjectManagerId;

            var pm = await _context.Set<User>().FirstOrDefaultAsync(u => u.Id == pmId);

            return Mapping.Mapper.Map<UserDto>(pm);
        }
    }

    public async Task<ICollection<IssueDto>> GetComplains(int projectId)
    {
        if (projectId == 0)
            throw new ArgumentNullException(nameof(projectId));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var complains = await _context.Set<Issue>()
                                          .Where(p => p.ProjectId == projectId)
                                          .ToListAsync();

            return Mapping.Mapper.Map<List<Issue>, List<IssueDto>>(complains);
        }
    }

    public async Task<ICollection<InvoiceDto>> GetInvoices(int projectId)
    {
        if (projectId == 0)
            throw new ArgumentNullException(nameof(projectId));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var invoices = await _context.Set<Invoice>()
                                         .Where(i => i.ProjectId == projectId)
                                         .ToListAsync();

            var dtos = Mapping.Mapper.Map<List<InvoiceDto>>(invoices);
            return dtos;
        }
    }
}
