using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Dtos.KPIS;
using EmpiriaBMS.Core.ReturnModels;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;



namespace EmpiriaBMS.Core.Repositories;

public class KpisRepo : IDisposable
{
    private bool disposedValue;
    protected readonly IDbContextFactory<AppDbContext> _dbContextFactory;
    protected readonly LeadRepo _ledRepo;
    protected readonly InvoiceRepo _invoiceRepo;
    protected readonly PaymentRepo _paymentRepo;
    protected readonly Logging.LoggerManager _logger;

    public KpisRepo(
        IDbContextFactory<AppDbContext> dbFactory,
        Logging.LoggerManager logger
    )
    {
        _dbContextFactory = dbFactory;
        _ledRepo = new LeadRepo(dbFactory, logger);
        _invoiceRepo = new InvoiceRepo(dbFactory, logger);
        _paymentRepo = new PaymentRepo(dbFactory, logger);
        _logger = logger;
    }

    #region Simple
    public async Task<double> GetNextYearNetIncome()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var icome = await _ledRepo.GetSumOfAllOppenLeadsPotencialFee();

            return icome;
        }
    }

    public async Task<double> GetEstimatedInvoicing()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var sumInvoicesFee = await _context.Set<Invoice>()
                .Where(i => i.IsDeleted == false)
                .Where(i => i.Category == Models.Enum.InvoiceCategory.INCOMES)
                .SumAsync(i => i.Fee);

            var sumPaymentsFee = await _context.Set<Payment>()
                .Where(i => i.IsDeleted == false)
                .SumAsync(i => i.Fee);

            double result = Convert.ToDouble(sumInvoicesFee) - Convert.ToDouble(sumPaymentsFee);

            return result;
        }
    }

    public async Task<(int Paid, int Unpaid)> GetPaidUnpaidInvoiceCount()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var payments = await _context.Set<Payment>()
                .Where(p => p.IsDeleted == false)
                .Include(p => p.Invoice)
                .ToListAsync();

            var invoices = await _context.Set<Invoice>()
                .Where(p => p.IsDeleted == false)
                .ToListAsync();

            var dict = invoices
                .GroupBy(i => (i.Id, i.Fee))
                .ToDictionary(
                    g => (g.Key.Id, g.Key.Fee),
                    g => payments.Where(p => p.InvoiceId == g.Key.Id).Sum(p => p.Fee)
                );

            int paid = dict.Count(d => d.Key.Fee <= d.Value);
            int unpaid = dict.Count(d => d.Key.Fee > d.Value);

            return (paid, unpaid);
        }
    }
    #endregion

    public async Task<decimal> GetMissedDeadLineProjects()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var all = await _context.Set<Project>()
                                    .Where(r => !r.IsDeleted)
                                    .CountAsync();

            var missedDeadline = await _context.Set<Project>()
                                               .Where(r => !r.IsDeleted)
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
                                            .Where(r => !r.IsDeleted)
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

    public async Task<Dictionary<string, long>> GetHoursPerUser()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var userRolesWithDailyTimes = await _context.Set<UserRole>()
                                            .Where(r => !r.IsDeleted)
                                            .Include(ur => ur.Role)
                                            .Include(ur => ur.User)
                                            .Select(ur => new
                                            {
                                                UserName = $"{ur.User.FirstName} {ur.User.MidName} {ur.User.LastName}",
                                                DailyTimeHours = ur.User.DailyTime.Sum(dt => dt.TimeSpan.Hours)
                                            })
                                            .ToListAsync();

            var userTimes = userRolesWithDailyTimes
                                .GroupBy(ur => ur.UserName)
                                .ToDictionary(
                                    g => g.Key ?? "Uknown User",
                                    g => g.Sum(ur => ur.DailyTimeHours)
                                );

            return userTimes;
        }
    }

    public async Task<List<ProjectDto>> GetActiveDelayedProjects(int userId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            // Get User Roles
            var roleIds = await _context.Set<UserRole>()
                                        .Where(r => !r.IsDeleted)
                                        .Where(r => r.UserId == userId)
                                        .Select(r => r.RoleId)
                                        .ToListAsync();

            // Get Roles Permissions
            var permissions = await _context.Set<RolePermission>()
                                            .Where(r => !r.IsDeleted)
                                            .Where(pr => roleIds.Contains(pr.RoleId))
                                            .Include(pr => pr.Permission)
                                            .Select(pr => pr.Permission)
                                            .ToListAsync();

            if (permissions.Any(p => p.Ord == 20))
            {
                var allProjects = await _context.Set<Project>()
                                                .Where(r => !r.IsDeleted)
                                                .Include(r => r.Invoices)
                                                .Include(p => p.Stage)
                                                .Include(p => p.Offer)
                                                .ThenInclude(o => o.Category)
                                                .Include(p => p.Offer)
                                                .ThenInclude(o => o.SubCategory)
                                                .Include(p => p.Offer)
                                                .ThenInclude(o => o.Lead)
                                                .ThenInclude(l => l.Address)
                                                .Include(p => p.Offer)
                                                .ThenInclude(o => o.Lead)
                                                .ThenInclude(l => l.Client)
                                                .Include(p => p.ProjectManager)
                                                .Include(p => p.ProjectsSubConstructors)
                                                .Where(p => p.DeadLine < DateTime.Now)
                                                .OrderBy(e => !e.Active)
                                                .ThenBy(e => e.DeadLine)
                                                .ToListAsync();

                return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(allProjects.Distinct().ToList());
            }

            // Filter Projects
            var myDrawingIds = await _context.Set<DeliverableEmployee>()
                                             .Where(r => !r.IsDeleted)
                                             .Where(de => de.EmployeeId == userId)
                                             .Select(e => e.DeliverableId)
                                             .ToListAsync();

            var drawingsDisciplinesIds = await _context.Set<Deliverable>()
                                                 .Where(r => !r.IsDeleted)
                                                 .Where(dd => myDrawingIds.Contains(dd.Id))
                                                 .Select(e => e.DisciplineId)
                                                 .ToListAsync();

            var engineerDisciplineIds = await _context.Set<DisciplineEngineer>()
                                                      .Where(r => !r.IsDeleted)
                                                      .Where(d => d.EngineerId == userId)
                                                      .Select(e => e.DisciplineId)
                                                      .ToListAsync();

            var myDisciplinesIds = drawingsDisciplinesIds.Union(engineerDisciplineIds);

            var projectsFromDisciplineIds = await _context.Set<Discipline>()
                                                        .Where(r => !r.IsDeleted)
                                                        .Where(d => myDisciplinesIds.Contains(d.Id))
                                                        .Select(dp => dp.ProjectId)
                                                        .ToArrayAsync();

            var projects = await _context.Set<Project>()
                                         .Where(r => !r.IsDeleted)
                                         .Include(r => r.Invoices)
                                         .Include(p => p.Stage)
                                         .Include(p => p.Offer)
                                         .ThenInclude(o => o.Category)
                                         .Include(p => p.Offer)
                                         .ThenInclude(o => o.SubCategory)
                                         .Include(p => p.Offer)
                                         .ThenInclude(o => o.Lead)
                                         .ThenInclude(l => l.Address)
                                         .Include(p => p.Offer)
                                         .ThenInclude(o => o.Lead)
                                         .ThenInclude(l => l.Client)
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
                                        .Where(r => !r.IsDeleted)
                                        .Where(r => r.UserId == userId)
                                        .Select(r => r.RoleId)
                                        .ToListAsync();

            // Get Roles Permissions
            var permissions = await _context.Set<RolePermission>()
                                            .Where(r => !r.IsDeleted)
                                            .Where(pr => roleIds.Contains(pr.RoleId))
                                            .Include(pr => pr.Permission)
                                            .Select(pr => pr.Permission)
                                            .ToListAsync();

            var offers = await _context.Set<Offer>()
                .Include(o => o.Category)
                .Include(o => o.SubCategory)
                .Where(r => !r.IsDeleted)
                .ToListAsync();

            var offersIds = offers.Select(o => o.Id).ToList();

            Dictionary<string, int> projectTypesWithDeadLines;
            List<Project> allProjects;

            if (permissions.Any(p => p.Ord == 20))
            {
                allProjects = await _context.Set<Project>()
                        .Where(r => !r.IsDeleted)
                        .Include(r => r.Invoices)
                        .Include(p => p.Stage)
                        .Include(p => p.ProjectManager)
                        .Include(p => p.ProjectsSubConstructors)
                        .ToListAsync();
            }
            else
            {
                // Filter Projects
                var myDrawingIds = await _context.Set<DeliverableEmployee>()
                                                 .Where(r => !r.IsDeleted)
                                                 .Where(de => de.EmployeeId == userId)
                                                 .Select(e => e.DeliverableId)
                                                 .ToListAsync();

                var drawingsDisciplinesIds = await _context.Set<Deliverable>()
                                                     .Where(r => !r.IsDeleted)
                                                     .Where(dd => myDrawingIds.Contains(dd.Id))
                                                     .Select(e => e.DisciplineId)
                                                     .ToListAsync();

                var engineerDisciplineIds = await _context.Set<DisciplineEngineer>()
                                                          .Where(r => !r.IsDeleted)
                                                          .Where(d => d.EngineerId == userId)
                                                          .Select(e => e.DisciplineId)
                                                          .ToListAsync();

                var myDisciplinesIds = drawingsDisciplinesIds.Union(engineerDisciplineIds);

                var projectsFromDisciplineIds = await _context.Set<Discipline>()
                                                            .Where(r => !r.IsDeleted)
                                                            .Where(d => myDisciplinesIds.Contains(d.Id))
                                                            .Select(dp => dp.ProjectId)
                                                            .ToArrayAsync();

                allProjects = await _context.Set<Project>()
                            .Where(r => !r.IsDeleted)
                            .Where(p => projectsFromDisciplineIds.Contains(p.Id))
                            .Include(r => r.Invoices)
                            .Include(p => p.Stage)
                            .Include(p => p.ProjectManager)
                            .Include(p => p.ProjectsSubConstructors)
                            .ToListAsync();
            }

            // Perform the projection after the data is loaded
            allProjects = allProjects.Select(p =>
            {
                p.Offer = offers.FirstOrDefault(o => o.Id == p.OfferId);
                return p;
            }).ToList();

            allProjects = allProjects.Where(p => p.DeadLine < DateTime.Now).ToList();

            projectTypesWithDeadLines = allProjects.GroupBy(p => p.Offer.SubCategory.Name)
                                                .ToDictionary(
                                                    g => g.Key ?? "Uknown Category",
                                                    g => allProjects.Where(p => p.Offer.SubCategory.Name.Equals(g.Key)).Count()
                                                );


            return projectTypesWithDeadLines;
        }
    }

    public async Task<IQueryable<TenderDataDto>> GetTenderTable()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Project> projects = await _context.Set<Project>()
                                                   .Where(r => !r.IsDeleted)
                                                   .Include(r => r.Invoices)
                                                    .Include(p => p.Stage)
                                                    .Include(p => p.Offer)
                                                    .ThenInclude(o => o.Category)
                                                    .Include(p => p.Offer)
                                                    .ThenInclude(o => o.SubCategory)
                                                    .Include(p => p.Offer)
                                                    .ThenInclude(o => o.Lead)
                                                    .ThenInclude(l => l.Address)
                                                    .Include(p => p.Offer)
                                                    .ThenInclude(o => o.Lead)
                                                    .ThenInclude(l => l.Client)
                                                    .Include(p => p.Offer)
                                                    .Include(p => p.ProjectManager)
                                                    .Include(p => p.ProjectsSubConstructors)
                                                   .Where(p => p.DeadLine < DateTime.Now)
                                                   .OrderBy(e => !e.Active)
                                                   .ThenBy(e => e.DeadLine)
                                                   .ToListAsync();

            List<TenderDataDto> tenderData = new List<TenderDataDto>();

            foreach (var project in projects)
            {
                var projectOffer = await _context.Set<Offer>()
                                                 .Where(o => !o.IsDeleted)
                                                 .Include(o => o.Lead)
                                                 .ThenInclude(l => l.Client)
                                                 .FirstOrDefaultAsync(o => o.Id == project.OfferId);

                // Get All Offers
                var offers = await _context.Set<Offer>()
                                       .Where(o => !o.IsDeleted)
                                       .Include(o => o.Lead)
                                       .Include(o => o.State)
                                       .Include(o => o.Type)
                                       .Include(o => o.Lead)
                                       .ThenInclude(p => p.Client)
                                       .Include(o => o.Lead)
                                       .ThenInclude(l => l.Address)
                                       .Include(o => o.SubCategory)
                                       .Include(o => o.Category)
                                       .Include(o => o.Project)
                                       .ThenInclude(p => p.Stage)
                                       .ToListAsync();

                var client = projectOffer?.Lead?.Client;

                var data = new TenderDataDto()
                {
                    ProjectName = project.Name ?? "",
                    ProjectStage = project.Stage?.Name ?? "",
                    ProjectCategory = projectOffer?.Category?.Name ?? "",
                    ProjectSubCategory = projectOffer?.SubCategory?.Name ?? "",
                    ProjectPrice = offers.Sum(o => o.OfferPrice) ?? 0,
                    ProjectPudgedPrice = offers.Sum(o => o.PudgetPrice) ?? 0,
                    ClientCompanyName = projectOffer?.Lead?.Client?.CompanyName ?? "",
                    ClientFullName = client?.FullName ?? "",
                    ClientPhone = client?.Phone1 ?? client?.Phone2 ?? client?.Phone3 ?? "",
                    ClientEmail = client?.Emails?.FirstOrDefault()?.Address ?? ""
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
                                       .Where(r => !r.IsDeleted)
                                       .Include(p => p.Invoice)
                                       .Include(p => p.Invoice.Project)
                                       .Where(p => p.Invoice.PaymentDate < p.PaymentDate)
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

    public async Task<Dictionary<string, PendingPayments>> GetPendingPayments()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var payments = await _context.Set<Payment>()
                                       .Where(r => !r.IsDeleted)
                                       .Include(p => p.Invoice)
                                       .ThenInclude(i => i.Project)
                                       .ToListAsync();

            var result = payments.GroupBy(p => p.Invoice.Project)
                                 .ToDictionary(
                                    g => g.Key.Name ?? "Uknown Project",
                                    g => new PendingPayments()
                                    {
                                        Project = Mapping.Mapper.Map<ProjectDto>(g.Key as Project),
                                        Payments = Mapping.Mapper.Map<List<PaymentDto>>(g.ToList()),
                                        PendingPaymentsCount = g.ToList().Count(),
                                        PendingSum = g.ToList().Sum(p => p.Fee)
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
                _ledRepo.Dispose();
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
