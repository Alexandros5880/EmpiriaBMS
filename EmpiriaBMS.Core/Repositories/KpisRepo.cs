using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.ReturnModels;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Repositories;

public class KpisRepo : IDisposable
{
    private bool disposedValue;
    protected readonly IDbContextFactory<AppDbContext> _dbContextFactory;

    public KpisRepo(IDbContextFactory<AppDbContext> dbFactory) =>
        _dbContextFactory = dbFactory;

    public async Task<int> GetMissedDeadLineProjects()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var all = await _context.Set<Project>()
                                    .CountAsync();

            var missedDeadline = await _context.Set<Project>()
                                               .Where(p => p.DeadLine < DateTime.Now)
                                               .CountAsync();

            return (missedDeadline / all) * 100;
        }  
    }

    public async Task<Dictionary<string, long>> GetHoursPerRole()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var userRolesWithDailyTimes = await _context.Set<UserRole>()
                                            .Include(ur => ur.Role)
                                            .Include(ur => ur.User)
                                            .Select(ur => new
                                            {
                                                RoleName = ur.Role.Name,
                                                DailyTimeHours = ur.User.DailyTime.Sum(dt => dt.TimeSpan.Hours)
                                            })
                                            .ToListAsync();

            var roleTimes = userRolesWithDailyTimes
                                .GroupBy(ur => ur.RoleName)
                                .ToDictionary(
                                    g => g.Key ?? "Uknown Role",
                                    g => g.Sum(ur => ur.DailyTimeHours)
                                );

            return roleTimes;
        }
    }

    public async Task<List<ProjectDto>> GetActiveDelayedProjects(int userId)
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

            if (permissions.Any(p => p.Ord == 20))
            {
                var allProjects = await _context.Set<Project>()
                                                .Include(r => r.Customer)
                                                .Include(r => r.Invoice)
                                                .Include(p => p.Type)
                                                .Include(p => p.ProjectManager)
                                                .Include(p => p.SubContractor)
                                                .Include(p => p.Customer)
                                                .Include(p => p.Payment)
                                                .Where(p => p.DeadLine < DateTime.Now)
                                                .OrderBy(e => !e.Active)
                                                .ThenBy(e => e.DeadLine)
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
                                         .Include(r => r.Invoice)
                                         .Include(p => p.Type)
                                         .Include(p => p.ProjectManager)
                                         .Include(p => p.SubContractor)
                                         .Include(p => p.Customer)
                                         .Include(p => p.Payment)
                                         .Where(p => projectsFromDisciplineIds.Contains(p.Id)
                                                            || p.ProjectManagerId == userId)
                                         .Where(p => p.DeadLine < DateTime.Now)
                                         .OrderBy(e => !e.Active)
                                         .ThenBy(e => e.DeadLine)
                                         .ToListAsync();

            return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
        }
    }

    public async Task<Dictionary<string, int>> GetActiveDelayedProjectTypesCountByType(int userId)
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

            Dictionary<string, int> projectTypesWithDeadLines;

            if (permissions.Any(p => p.Ord == 20))
            {
                var allProjects = await _context.Set<Project>()
                                                .Include(p => p.Type)
                                                .Where(p => p.DeadLine < DateTime.Now)
                                                .ToListAsync();

                projectTypesWithDeadLines = allProjects
                                                .GroupBy(p => p.Type.Name)
                                                .ToDictionary(
                                                    g => g.Key ?? "Uknown Type",
                                                    g => allProjects.Where(p => p.Type.Name.Equals(g.Key)).Count()
                                                );


                return projectTypesWithDeadLines;
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
                                         .Include(p => p.Type)
                                         .Where(p => projectsFromDisciplineIds.Contains(p.Id)
                                                            || p.ProjectManagerId == userId)
                                         .Where(p => p.DeadLine < DateTime.Now)
                                         .ToListAsync();

            projectTypesWithDeadLines = projects.GroupBy(p => p.Type.Name)
                                                .ToDictionary(
                                                    g => g.Key ?? "Uknown Type",
                                                    g => projects.Where(p => p.Type.Name.Equals(g.Key)).Count()
                                                );


            return projectTypesWithDeadLines;
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {

            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

}
