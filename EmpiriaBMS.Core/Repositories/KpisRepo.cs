using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Dtos.KPIS;
using EmpiriaBMS.Core.ReturnModels;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;



namespace EmpiriaBMS.Core.Repositories;

public class KpisRepo : IDisposable
{
    private bool disposedValue;
    protected readonly IDbContextFactory<AppDbContext> _dbContextFactory;

    public KpisRepo(IDbContextFactory<AppDbContext> dbFactory) =>
        _dbContextFactory = dbFactory;

    public async Task<decimal> GetMissedDeadLineProjects()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var all = await _context.Set<Project>()
                                    .CountAsync();

            var missedDeadline = await _context.Set<Project>()
                                               .Where(p => p.DeadLine < DateTime.Now)
                                               .CountAsync();

            decimal division = Convert.ToDecimal(missedDeadline) / Convert.ToDecimal(all);
            decimal result = Convert.ToDecimal(division * 100);
            return result;
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
                                                .Include(r => r.Client)
                                                .Include(r => r.Invoices)
                                                .Include(p => p.Category)
                                                .Include(p => p.ProjectManager)
                                                .Include(p => p.ProjectsSubConstructors)
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
                                         .Include(r => r.Client)
                                         .Include(r => r.Invoices)
                                         .Include(p => p.Category)
                                         .Include(p => p.ProjectManager)
                                         .Include(p => p.ProjectsSubConstructors)
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
                                                .Include(p => p.Category)
                                                .Where(p => p.DeadLine < DateTime.Now)
                                                .ToListAsync();

                projectTypesWithDeadLines = allProjects
                                                .GroupBy(p => p.Category.Name)
                                                .ToDictionary(
                                                    g => g.Key ?? "Uknown Category",
                                                    g => allProjects.Where(p => p.Category.Name.Equals(g.Key)).Count()
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
                                         .Include(p => p.Category)
                                         .Where(p => projectsFromDisciplineIds.Contains(p.Id)
                                                            || p.ProjectManagerId == userId)
                                         .Where(p => p.DeadLine < DateTime.Now)
                                         .ToListAsync();

            projectTypesWithDeadLines = projects.GroupBy(p => p.Category.Name)
                                                .ToDictionary(
                                                    g => g.Key ?? "Uknown Category",
                                                    g => projects.Where(p => p.Category.Name.Equals(g.Key)).Count()
                                                );


            return projectTypesWithDeadLines;
        }
    }

    public async Task<IQueryable<TenderDataDto>> GetTenderTable()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Project> projects = await _context.Set<Project>()
                                                   .Include(r => r.Client)
                                                   .Include(r => r.Invoices)
                                                   .Include(p => p.Category)
                                                   .Include(p => p.ProjectManager)
                                                   .Include(p => p.ProjectsSubConstructors)
                                                   .Where(p => p.DeadLine < DateTime.Now)
                                                   .OrderBy(e => !e.Active)
                                                   .ThenBy(e => e.DeadLine)
                                                   .ToListAsync();

            List<TenderDataDto> tenderData = new List<TenderDataDto>();

            foreach (var project in projects)
            {
                ProjectCategory parentCategory = null;
                var parentCatId = project.Category?.CategoryId;

                if (parentCatId != null)
                    parentCategory = await _context.Set<ProjectCategory>().FirstOrDefaultAsync(c => c.Id == parentCatId);

                // Get All Offers
                var offers = await _context.Set<Offer>().Where(o => o.ProjectId == project.Id).ToListAsync();

                var data = new TenderDataDto()
                {
                    ProjectName = project.Name ?? "",
                    ProjectStage = project.Stage?.Name ?? "",
                    ProjectCategory = parentCategory?.Name ?? "",
                    ProjectSubCategory = project.Category?.Name ?? "",
                    ProjectPrice = offers.Sum(o => o.OfferPrice) ?? 0,
                    ProjectPudgedPrice = offers.Sum(o => o.PudgetPrice) ?? 0,
                    ClientCompanyName = project.Client?.CompanyName ?? "",
                    ClientFullName = project.Client != null ? project.Client?.LastName + " " + project.Client?.FirstName : "",
                    ClientPhone = project.Client?.Phone1 ?? project.Client?.Phone2 ?? project.Client?.Phone3 ?? "",
                    ClientEmail = project.Client?.Emails?.FirstOrDefault()?.Address ?? ""
                };

                tenderData.Add(data);
            }


            return tenderData.AsQueryable();
        }
    }

    public async Task<Dictionary<string, DelayedPayments>> GetDelayedPayments()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var payments = await _context.Set<Payment>()
                                       .Include(p => p.Invoice)
                                       .Include(p => p.Invoice.Project)
                                       .Where(p => p.Invoice.Date < p.PaymentDate)
                                       .ToListAsync();

            var result = payments.GroupBy(p => p.Invoice.Project)
                                 .ToDictionary(
                                    g => g.Key.Name ?? "Uknown Project",
                                    g => new DelayedPayments()
                                    {
                                        DelayedPaymentsCount = g.Count(),
                                        Project = Mapping.Mapper.Map<ProjectDto>(g.Key),
                                        Payments = Mapping.Mapper.Map<List<PaymentDto>>(g.ToList())
                                    }
                                 );
            return result;
        }
    }

    public async Task<Dictionary<string, PendingPayments>> GetPendingPaymentsPerProject()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var payments = await _context.Set<Payment>()
                                         .Include(p => p.Invoice)
                                         .Include(p => p.Invoice.Project)
                                         .Where(p => p.PaidFee < p.Fee)
                                         .ToListAsync();

            var result = payments.GroupBy(p => p.Invoice.Project)
                                 .ToDictionary(
                                    g => g.Key.Name ?? "Uknown Project",
                                    g => new PendingPayments()
                                    {
                                        DelayedPaymentsCount = g.Count(),
                                        Project = Mapping.Mapper.Map<ProjectDto>(g.Key),
                                        Payments = Mapping.Mapper.Map<List<PaymentDto>>(g.ToList()),
                                        PendingFee = g.Sum(p => p.Fee) - g.Sum(p => p.PaidFee)
                                    }
                                 );
            return result;
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
