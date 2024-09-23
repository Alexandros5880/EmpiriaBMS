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
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var icome = await _ledRepo.GetSumOfAllOppenLeadsPotencialFee();

                return icome;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On KpisRepo.GetNextYearNetIncome(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return 0;
        }
    }

    public async Task<double> GetEstimatedInvoicing() {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var incomeInvoices = await _context.Set<Invoice>()
                    .Where(i => !i.IsDeleted)
                    .Where(i => i.Category == Models.Enum.InvoiceCategory.INCOMES)
                    .ToListAsync();
                var incomeInvoicesIds = incomeInvoices.Select(i => i.Id).ToList();
                var incomePaymentsFee = await _context.Set<Payment>()
                    .Where(p => !p.IsDeleted)
                    .Where(p => incomeInvoicesIds.Contains(p.InvoiceId))
                    .SumAsync(p => p.Fee);
                var incomeInvoicesFee = incomeInvoices.Sum(i => i.Fee);
                var incomeUnpaidSum = Convert.ToDouble(incomeInvoicesFee) - Convert.ToDouble(incomePaymentsFee);
                return incomeUnpaidSum;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On KpisRepo.GetEstimatedInvoicing(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return 0;
        }
    }

    public async Task<(int Paid, int Unpaid)> GetPaidUnpaidInvoiceCount(
        DateTime? start = null,
        DateTime? end = null
    ) {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var payments = await _context.Set<Payment>()
                    .Where(p => p.IsDeleted == false)
                    .Where(p => (start == null || p.CreatedDate >= start) && (end == null || p.CreatedDate <= end))
                    .Include(p => p.Invoice)
                    .ToListAsync();

                var invoices = await _context.Set<Invoice>()
                    .Where(p => p.IsDeleted == false)
                    .Where(p => (start == null || p.CreatedDate >= start) && (end == null || p.CreatedDate <= end))
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
        catch (Exception ex)
        {
            _logger.LogError($"Exception On KpisRepo.GetPaidUnpaidInvoiceCount(DateTime? start = null,DateTime? end = null): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return (0,0);
        }
    }
    #endregion

    public async Task<decimal> GetMissedDeadLineProjects(
        DateTime? start = null,
        DateTime? end = null
    ) {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var all = await _context.Set<Project>()
                                        .Where(r => !r.IsDeleted)
                                        .Where(p => (start == null || p.CreatedDate >= start) && (end == null || p.CreatedDate <= end))
                                        .CountAsync();

                var missedDeadline = await _context.Set<Project>()
                                                   .Where(r => !r.IsDeleted)
                                                   .Where(p => (start == null || p.CreatedDate >= start) && (end == null || p.CreatedDate <= end))
                                                   .Where(p => p.DeadLine < DateTime.Now)
                                                   .CountAsync();

                if (missedDeadline == 0 || all == 0)
                    return Convert.ToDecimal(0);

                decimal division = Convert.ToDecimal(missedDeadline) / Convert.ToDecimal(all);
                decimal result = Convert.ToDecimal(division * 100);
                return result;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On KpisRepo.GetMissedDeadLineProjects(DateTime? start = null,DateTime? end = null): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return 0;
        }
    }

    public async Task<Dictionary<string, long>> GetHoursPerRole(
        DateTime? start = null,
        DateTime? end = null
    ) {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var userRolesWithDailyTimes = await _context.Set<UserRole>()
                                                .Where(r => !r.IsDeleted)
                                                .Where(p => (start == null || p.CreatedDate >= start) && (end == null || p.CreatedDate <= end))
                                                .Include(ur => ur.Role)
                                                .Include(ur => ur.User)
                                                .Select(ur => new
                                                {
                                                    RoleName = ur.Role != null ? ur.Role.Name : "--",
                                                    DailyTimeHours = ur.User != null && ur.User.DailyTime != null 
                                                        ? ur.User.DailyTime.Sum(dt => dt.TimeSpan != null ? dt.TimeSpan.Hours : 0) : 0
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
        catch (Exception ex)
        {
            _logger.LogError($"Exception On KpisRepo.GetHoursPerRole(DateTime? start = null,DateTime? end = null): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return default(Dictionary<string, long>)!;
        }
    }

    public async Task<Dictionary<string, long>> GetHoursPerUser(
        DateTime? start = null,
        DateTime? end = null
    ) {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var userRolesWithDailyTimes = await _context.Set<UserRole>()
                                                .Where(r => !r.IsDeleted)
                                                .Where(p => (start == null || p.CreatedDate >= start) && (end == null || p.CreatedDate <= end))
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
        catch (Exception ex)
        {
            _logger.LogError($"Exception On KpisRepo.GetHoursPerUser(DateTime? start = null,DateTime? end = null): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return default(Dictionary<string, long>)!;
        }
    }

    public async Task<List<ProjectDto>> GetActiveDelayedProjects(
        int userId,
        DateTime? start = null,
        DateTime? end = null
    ) {
        try
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
                                                    .Where(p => (start == null || p.CreatedDate >= start) && (end == null || p.CreatedDate <= end))
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
                                             .Where(p => (start == null || p.CreatedDate >= start) && (end == null || p.CreatedDate <= end))
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
        catch (Exception ex)
        {
            _logger.LogError($"Exception On KpisRepo.GetActiveDelayedProjects(int userId, DateTime? start = null,DateTime? end = null): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return default(List<ProjectDto>)!;
        }
    }

    public async Task<Dictionary<string, int>> GetActiveDelayedProjectTypesCountByType(
        int userId,
        DateTime? start = null,
        DateTime? end = null
    ) {
        try
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
                            .Where(p => (start == null || p.CreatedDate >= start) && (end == null || p.CreatedDate <= end))
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
                                .Where(p => (start == null || p.CreatedDate >= start) && (end == null || p.CreatedDate <= end))
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
        catch (Exception ex)
        {
            _logger.LogError($"Exception On KpisRepo.GetActiveDelayedProjectTypesCountByType(int userId, DateTime? start = null,DateTime? end = null): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return default(Dictionary<string, int>)!;
        }
    }

    public async Task<Dictionary<string, double>> GetProfitPerProject(
        int userId,
        DateTime? start = null,
        DateTime? end = null
    ) {
        try
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

                // Get Projects
                List<Project> allProjects;
                if (permissions.Any(p => p.Ord == 20))
                {
                    allProjects = await _context.Set<Project>()
                            .Where(r => !r.IsDeleted)
                            .Where(p => (start == null || p.CreatedDate >= start) && (end == null || p.CreatedDate <= end))
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
                                .Where(p => (start == null || p.CreatedDate >= start) && (end == null || p.CreatedDate <= end))
                                .Where(p => projectsFromDisciplineIds.Contains(p.Id))
                                .Include(r => r.Invoices)
                                .Include(p => p.Stage)
                                .Include(p => p.ProjectManager)
                                .Include(p => p.ProjectsSubConstructors)
                                .ToListAsync();
                }

                // Get All Invoices
                var invoices = await _context.Set<Invoice>()
                    .Where(r => !r.IsDeleted)
                    .ToListAsync();

                // Get All Payments
                var payments = await _context.Set<Payment>()
                    .Where(r => !r.IsDeleted)
                    .ToListAsync();

                // Build Dictionary
                Dictionary<string, double> dict = new Dictionary<string, double>();

                dict = allProjects.GroupBy(p => p)
                    .ToDictionary(
                        g => g.Key.Name ?? "Uknown Project",
                        g =>
                        {
                            // Income Sum
                            var incomeInvoices = invoices.Where(i => i.Category == Models.Enum.InvoiceCategory.INCOMES && i.ProjectId == g.Key.Id);
                            var incomePayments = payments.Where(p => incomeInvoices.Select(i => i.Id).Contains(p.Id)).ToList();
                            var invoicesIncomeFeeSum = incomeInvoices.Sum(i => i.Fee);
                            var paymentsIncomeFeeSum = incomePayments.Sum(p => p.Fee);

                            // Expenses Sum
                            var expenseInvoices = invoices.Where(i => i.Category == Models.Enum.InvoiceCategory.EXPENSES && i.ProjectId == g.Key.Id);
                            var expensePayments = payments.Where(p => expenseInvoices.Select(i => i.Id).Contains(p.Id)).ToList();
                            var paymentsExpenseFeeSum = expensePayments.Sum(p => p.Fee);

                            return Convert.ToDouble(invoicesIncomeFeeSum) - paymentsExpenseFeeSum;
                        }
                    );

                return dict;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On KpisRepo.GetProfitPerProject(int userId, DateTime? start = null,DateTime? end = null): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return default(Dictionary<string, double>)!;
        }
    }

    public async Task<IQueryable<TenderDataDto>> GetTenderTable(
        DateTime? start = null,
        DateTime? end = null
    ) {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                List<Project> projects = await _context.Set<Project>()
                                                       .Where(r => !r.IsDeleted)
                                                       .Where(p => (start == null || p.CreatedDate >= start) && (end == null || p.CreatedDate <= end))
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
                                                     .Where(p => (start == null || p.CreatedDate >= start) && (end == null || p.CreatedDate <= end))
                                                     .Include(o => o.Lead)
                                                     .ThenInclude(l => l.Client)
                                                     .FirstOrDefaultAsync(o => o.Id == project.OfferId);

                    // Get All Offers
                    var offers = await _context.Set<Offer>()
                                           .Where(o => !o.IsDeleted)
                                           .Where(p => (start == null || p.CreatedDate >= start) && (end == null || p.CreatedDate <= end))
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
        catch (Exception ex)
        {
            _logger.LogError($"Exception On KpisRepo.GetTenderTable(DateTime? start = null,DateTime? end = null): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return default(IQueryable<TenderDataDto>)!;
        }
    }

    public async Task<Dictionary<string, DelayedPayments>> GetDelayedPayments(
        DateTime? start = null,
        DateTime? end = null
    ) {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var payments = await _context.Set<Payment>()
                                           .Where(r => !r.IsDeleted)
                                           .Where(p => (start == null || p.CreatedDate >= start) && (end == null || p.CreatedDate <= end))
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
        catch (Exception ex)
        {
            _logger.LogError($"Exception On KpisRepo.GetDelayedPayments(DateTime? start = null,DateTime? end = null): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return default(Dictionary<string, DelayedPayments>)!;
        }
    }

    public async Task<Dictionary<string, PendingPayments>> GetPendingPayments(
        DateTime? start = null,
        DateTime? end = null
    ) {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var payments = await _context.Set<Payment>()
                                           .Where(r => !r.IsDeleted)
                                           .Where(p => (start == null || p.CreatedDate >= start) && (end == null || p.CreatedDate <= end))
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
        catch (Exception ex)
        {
            _logger.LogError($"Exception On KpisRepo.GetPendingPayments(DateTime? start = null,DateTime? end = null): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return default(Dictionary<string, PendingPayments>)!;
        }
    }

    public async Task<Dictionary<string, int>> GetIssuesPerProjectCount(
        DateTime? start = null,
        DateTime? end = null
    ) {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var issues = await _context.Set<Issue>()
                    .Where(i => !i.IsDeleted)
                    .Where(p => (start == null || p.CreatedDate >= start) && (end == null || p.CreatedDate <= end))
                    .Include(i => i.Project)
                    .ToListAsync();

                var dict = issues
                    .GroupBy(i => i.Project)
                    .ToDictionary(
                        g => g.Key?.Name ?? "--",
                        g => g.Count()
                    );

                return dict;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On KpisRepo.GetIssuesPerProjectCount(DateTime? start = null,DateTime? end = null): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return new Dictionary<string, int>();
        }
    }

    public async Task<Dictionary<string, int>> GetIssuesPerUserCount(
        DateTime? start = null,
        DateTime? end = null
    ) {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var issues = await _context.Set<Issue>()
                    .Where(i => !i.IsDeleted)
                    .Where(p => (start == null || p.CreatedDate >= start) && (end == null || p.CreatedDate <= end))
                    .Include(i => i.Creator)
                    .ToListAsync();

                var dict = issues
                    .GroupBy(i => i.Creator)
                    .ToDictionary(
                        g => g.Key?.FullName ?? "--",
                        g => g.Count()
                    );

                return dict;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On KpisRepo.GetIssuesPerUserCount(DateTime? start = null,DateTime? end = null): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return new Dictionary<string, int>();
        }
    }

    public async Task<Dictionary<string, double>> GetTurnoverPerProjectCategory(
        DateTime? start = null,
        DateTime? end = null
    ) {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var catPayesIncomes = await _context.Set<Payment>()
                    .Where(payment => !payment.IsDeleted)
                    .Where(p => (start == null || p.CreatedDate >= start) && (end == null || p.CreatedDate <= end))
                    .Join(_context.Set<Invoice>(),
                          payment => payment.InvoiceId,
                          invoice => invoice.Id,
                          (payment, invoice) => new { payment, invoice })
                    .Where(result => !result.invoice.IsDeleted && result.invoice.Category == Models.Enum.InvoiceCategory.INCOMES)
                    .Join(_context.Set<Project>(),
                          paymentInvoice => paymentInvoice.invoice.ProjectId,
                          project => project.Id,
                          (result, project) => new { result.payment, result.invoice, project })
                    .Join(_context.Set<Offer>(),
                          paymentInvoiceProject => paymentInvoiceProject.project.OfferId,
                          offer => offer.Id,
                          (result, offer) => new { result.payment, result.invoice, result.project, offer })
                    .Join(_context.Set<ProjectCategory>(),
                          paymentInvoiceProjectOffer => paymentInvoiceProjectOffer.offer.CategoryId,
                          category => category.Id,
                          (result, category) => new
                          {
                              PaymentFee = result.payment.Fee,
                              CategoryName = category.Name
                          })
                    .ToListAsync();

                var catPayesExpenses = await _context.Set<Payment>()
                    .Where(payment => !payment.IsDeleted)
                    .Where(p => (start == null || p.CreatedDate >= start) && (end == null || p.CreatedDate <= end))
                    .Join(_context.Set<Invoice>(),
                          payment => payment.InvoiceId,
                          invoice => invoice.Id,
                          (payment, invoice) => new { payment, invoice })
                    .Where(result => !result.invoice.IsDeleted && result.invoice.Category == Models.Enum.InvoiceCategory.EXPENSES)
                    .Join(_context.Set<Project>(),
                          paymentInvoice => paymentInvoice.invoice.ProjectId,
                          project => project.Id,
                          (result, project) => new { result.payment, result.invoice, project })
                    .Join(_context.Set<Offer>(),
                          paymentInvoiceProject => paymentInvoiceProject.project.OfferId,
                          offer => offer.Id,
                          (result, offer) => new { result.payment, result.invoice, result.project, offer })
                    .Join(_context.Set<ProjectCategory>(),
                          paymentInvoiceProjectOffer => paymentInvoiceProjectOffer.offer.CategoryId,
                          category => category.Id,
                          (result, category) => new
                          {
                              PaymentFee = result.payment.Fee,
                              CategoryName = category.Name
                          })
                    .ToListAsync();

                var dictIncomes = catPayesIncomes
                    .GroupBy(cp => cp.CategoryName)
                    .ToDictionary(
                        g => g.Key ?? "--",
                        g => g.Sum(cp => cp.PaymentFee)
                    );

                var dictExpenses = catPayesExpenses
                    .GroupBy(cp => cp.CategoryName)
                    .ToDictionary(
                        g => g.Key ?? "--",
                        g => g.Sum(cp => cp.PaymentFee)
                    );

                var resultDict = _concutDicts(dictIncomes, dictExpenses);

                return resultDict;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On KpisRepo.GetTurnoverPerProjectCategory(DateTime? start = null,DateTime? end = null): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return new Dictionary<string, double>();
        }
    }

    public async Task<Dictionary<string, double>> GetTurnoverPerProjectSubCategory(
        DateTime? start = null,
        DateTime? end = null
    ) {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var catPayesIncomes = await _context.Set<Payment>()
                    .Where(payment => !payment.IsDeleted)
                    .Where(p => (start == null || p.CreatedDate >= start) && (end == null || p.CreatedDate <= end))
                    .Join(_context.Set<Invoice>(),
                          payment => payment.InvoiceId,
                          invoice => invoice.Id,
                          (payment, invoice) => new { payment, invoice })
                    .Where(result => !result.invoice.IsDeleted && result.invoice.Category == Models.Enum.InvoiceCategory.INCOMES)
                    .Join(_context.Set<Project>(),
                          paymentInvoice => paymentInvoice.invoice.ProjectId,
                          project => project.Id,
                          (result, project) => new { result.payment, result.invoice, project })
                    .Join(_context.Set<Offer>(),
                          paymentInvoiceProject => paymentInvoiceProject.project.OfferId,
                          offer => offer.Id,
                          (result, offer) => new { result.payment, result.invoice, result.project, offer })
                    .Join(_context.Set<ProjectSubCategory>(),
                          paymentInvoiceProjectOffer => paymentInvoiceProjectOffer.offer.SubCategoryId,
                          category => category.Id,
                          (result, category) => new
                          {
                              PaymentFee = result.payment.Fee,
                              SubCategoryName = category.Name
                          })
                    .ToListAsync();

                var catPayesExpenses = await _context.Set<Payment>()
                    .Where(payment => !payment.IsDeleted)
                    .Where(p => (start == null || p.CreatedDate >= start) && (end == null || p.CreatedDate <= end))
                    .Join(_context.Set<Invoice>(),
                          payment => payment.InvoiceId,
                          invoice => invoice.Id,
                          (payment, invoice) => new { payment, invoice })
                    .Where(result => !result.invoice.IsDeleted && result.invoice.Category == Models.Enum.InvoiceCategory.EXPENSES)
                    .Join(_context.Set<Project>(),
                          paymentInvoice => paymentInvoice.invoice.ProjectId,
                          project => project.Id,
                          (result, project) => new { result.payment, result.invoice, project })
                    .Join(_context.Set<Offer>(),
                          paymentInvoiceProject => paymentInvoiceProject.project.OfferId,
                          offer => offer.Id,
                          (result, offer) => new { result.payment, result.invoice, result.project, offer })
                    .Join(_context.Set<ProjectSubCategory>(),
                          paymentInvoiceProjectOffer => paymentInvoiceProjectOffer.offer.SubCategoryId,
                          category => category.Id,
                          (result, category) => new
                          {
                              PaymentFee = result.payment.Fee,
                              SubCategoryName = category.Name
                          })
                    .ToListAsync();

                var dictIncomes = catPayesIncomes
                    .GroupBy(cp => cp.SubCategoryName)
                    .ToDictionary(
                        g => g.Key ?? "--",
                        g => g.Sum(cp => cp.PaymentFee)
                    );

                var dictExpenses = catPayesExpenses
                    .GroupBy(cp => cp.SubCategoryName)
                    .ToDictionary(
                        g => g.Key ?? "--",
                        g => g.Sum(cp => cp.PaymentFee)
                    );

                var resultDict = _concutDicts(dictIncomes, dictExpenses);

                return resultDict;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On KpisRepo.GetTurnoverPerProjectSubCategory(DateTime? start = null,DateTime? end = null): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return new Dictionary<string, double>();
        }
    }

    public async Task<Dictionary<string, double>> GetTurnoverPerProjectManager(
        DateTime? start = null,
        DateTime? end = null
    ) {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var catPayesIncomes = await _context.Set<Payment>()
                    .Where(payment => !payment.IsDeleted)
                    .Where(p => (start == null || p.CreatedDate >= start) && (end == null || p.CreatedDate <= end))
                    .Join(_context.Set<Invoice>(),
                          payment => payment.InvoiceId,
                          invoice => invoice.Id,
                          (payment, invoice) => new { payment, invoice })
                    .Where(result => !result.invoice.IsDeleted && result.invoice.Category == Models.Enum.InvoiceCategory.INCOMES)
                    .Join(_context.Set<Project>(),
                          paymentInvoice => paymentInvoice.invoice.ProjectId,
                          project => project.Id,
                          (result, project) => new { result.payment, result.invoice, project })
                    .Join(_context.Set<User>(),
                          paymentInvoiceProject => paymentInvoiceProject.project.ProjectManagerId,
                          pm => pm.Id,
                          (result, pm) => new { 
                              ProjectManager = pm.FullName,
                              PaymentFee = result.payment.Fee,
                          })
                    .ToListAsync();

                var catPayesExpenses = await _context.Set<Payment>()
                    .Where(payment => !payment.IsDeleted)
                    .Where(p => (start == null || p.CreatedDate >= start) && (end == null || p.CreatedDate <= end))
                    .Join(_context.Set<Invoice>(),
                          payment => payment.InvoiceId,
                          invoice => invoice.Id,
                          (payment, invoice) => new { payment, invoice })
                    .Where(result => !result.invoice.IsDeleted && result.invoice.Category == Models.Enum.InvoiceCategory.EXPENSES)
                    .Join(_context.Set<Project>(),
                          paymentInvoice => paymentInvoice.invoice.ProjectId,
                          project => project.Id,
                          (result, project) => new { result.payment, result.invoice, project })
                    .Join(_context.Set<User>(),
                          paymentInvoiceProject => paymentInvoiceProject.project.ProjectManagerId,
                          pm => pm.Id,
                          (result, pm) => new {
                              ProjectManager = pm.FullName,
                              PaymentFee = result.payment.Fee,
                          })
                    .ToListAsync();

                var dictIncomes = catPayesIncomes
                    .GroupBy(cp => cp.ProjectManager)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Sum(cp => cp.PaymentFee)
                    );

                var dictExpenses = catPayesExpenses
                    .GroupBy(cp => cp.ProjectManager)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Sum(cp => cp.PaymentFee)
                    );

                var resultDict = _concutDicts(dictIncomes, dictExpenses);

                return resultDict;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On KpisRepo.GetTurnoverPerProjectManager(DateTime? start = null,DateTime? end = null): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return new Dictionary<string, double>();
        }
    }

    public async Task<Dictionary<string, double>> GetTurnoverPerEmployee(
        DateTime? start = null,
        DateTime? end = null
    ) {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                #region DeliverableEmployee Incomes/Expenses
                var empDelIncomes = await _context.Set<DeliverableEmployee>()
                    .Where(de => !de.IsDeleted)
                    .Where(de => (start == null || de.CreatedDate >= start) && (end == null || de.CreatedDate <= end))
                    .Join(_context.Set<User>(),
                          de => de.EmployeeId,
                          u => u.Id,
                          (de, user) => new { de, user })
                    .Where(r => !r.user.IsDeleted)
                    .Join(_context.Set<Deliverable>(),
                          r => r.de.DeliverableId,
                          d => d.Id,
                          (r, deliverable) => new { deliverable, r.user })
                    .Join(_context.Set<Discipline>(),
                          r => r.deliverable.DisciplineId,
                          d => d.Id,
                          (r, discipline) => new { r.user, discipline })
                    .Join(_context.Set<Project>(),
                          r => r.discipline.ProjectId,
                          p => p.Id,
                          (r, project) => new { r.user, project })
                    .Join(_context.Set<Invoice>(),
                          r => r.project.Id,
                          i => i.ProjectId,
                          (r, invoice) => new { r.user, invoice })
                    .Where(r => !r.invoice.IsDeleted && r.invoice.Category == Models.Enum.InvoiceCategory.INCOMES)
                    .Join(_context.Set<Payment>(),
                          r => r.invoice.Id,
                          p => p.InvoiceId,
                          (r, payment) => new { Employee = r.user.FullName, Fee = payment.Fee })
                    .ToListAsync();

                var dictEmpDelIncomes = empDelIncomes
                    .GroupBy(cp => cp.Employee)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Sum(cp => cp.Fee)
                    );

                var empDelExpenses = await _context.Set<DeliverableEmployee>()
                    .Where(de => !de.IsDeleted)
                    .Where(de => (start == null || de.CreatedDate >= start) && (end == null || de.CreatedDate <= end))
                    .Join(_context.Set<User>(),
                          de => de.EmployeeId,
                          u => u.Id,
                          (de, user) => new { de, user })
                    .Where(r => !r.user.IsDeleted)
                    .Join(_context.Set<Deliverable>(),
                          r => r.de.DeliverableId,
                          d => d.Id,
                          (r, deliverable) => new { deliverable, r.user })
                    .Join(_context.Set<Discipline>(),
                          r => r.deliverable.DisciplineId,
                          d => d.Id,
                          (r, discipline) => new { r.user, discipline })
                    .Join(_context.Set<Project>(),
                          r => r.discipline.ProjectId,
                          p => p.Id,
                          (r, project) => new { r.user, project })
                    .Join(_context.Set<Invoice>(),
                          r => r.project.Id,
                          i => i.ProjectId,
                          (r, invoice) => new { r.user, invoice })
                    .Where(r => !r.invoice.IsDeleted && r.invoice.Category == Models.Enum.InvoiceCategory.EXPENSES)
                    .Join(_context.Set<Payment>(),
                          r => r.invoice.Id,
                          p => p.InvoiceId,
                          (r, payment) => new { Employee = r.user.FullName, Fee = payment.Fee })
                    .ToListAsync();

                var dictEmpDelExpenses = empDelIncomes
                    .GroupBy(cp => cp.Employee)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Sum(cp => cp.Fee)
                    );
                #endregion

                #region SupportiveWorkEmployee Incomes/Expenses
                var empSuppIncomes = await _context.Set<SupportiveWorkEmployee>()
                    .Where(de => !de.IsDeleted)
                    .Where(de => (start == null || de.CreatedDate >= start) && (end == null || de.CreatedDate <= end))
                    .Join(_context.Set<User>(),
                          de => de.EmployeeId,
                          u => u.Id,
                          (de, user) => new { de, user })
                    .Where(r => !r.user.IsDeleted)
                    .Join(_context.Set<SupportiveWork>(),
                          r => r.de.SupportiveWorkId,
                          d => d.Id,
                          (r, supp) => new { supp, r.user })
                    .Join(_context.Set<Discipline>(),
                          r => r.supp.DisciplineId,
                          d => d.Id,
                          (r, discipline) => new { r.user, discipline })
                    .Join(_context.Set<Project>(),
                          r => r.discipline.ProjectId,
                          p => p.Id,
                          (r, project) => new { r.user, project })
                    .Join(_context.Set<Invoice>(),
                          r => r.project.Id,
                          i => i.ProjectId,
                          (r, invoice) => new { r.user, invoice })
                    .Where(r => !r.invoice.IsDeleted && r.invoice.Category == Models.Enum.InvoiceCategory.INCOMES)
                    .Join(_context.Set<Payment>(),
                          r => r.invoice.Id,
                          p => p.InvoiceId,
                          (r, payment) => new { Employee = r.user.FullName, Fee = payment.Fee })
                    .ToListAsync();

                var dictEmpSuppIncomes = empDelIncomes
                    .GroupBy(cp => cp.Employee)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Sum(cp => cp.Fee)
                    );

                var empSuppExpenses = await _context.Set<SupportiveWorkEmployee>()
                    .Where(de => !de.IsDeleted)
                    .Where(de => (start == null || de.CreatedDate >= start) && (end == null || de.CreatedDate <= end))
                    .Join(_context.Set<User>(),
                          de => de.EmployeeId,
                          u => u.Id,
                          (de, user) => new { de, user })
                    .Where(r => !r.user.IsDeleted)
                    .Join(_context.Set<SupportiveWork>(),
                          r => r.de.SupportiveWorkId,
                          d => d.Id,
                          (r, supp) => new { supp, r.user })
                    .Join(_context.Set<Discipline>(),
                          r => r.supp.DisciplineId,
                          d => d.Id,
                          (r, discipline) => new { r.user, discipline })
                    .Join(_context.Set<Project>(),
                          r => r.discipline.ProjectId,
                          p => p.Id,
                          (r, project) => new { r.user, project })
                    .Join(_context.Set<Invoice>(),
                          r => r.project.Id,
                          i => i.ProjectId,
                          (r, invoice) => new { r.user, invoice })
                    .Where(r => !r.invoice.IsDeleted && r.invoice.Category == Models.Enum.InvoiceCategory.EXPENSES)
                    .Join(_context.Set<Payment>(),
                          r => r.invoice.Id,
                          p => p.InvoiceId,
                          (r, payment) => new { Employee = r.user.FullName, Fee = payment.Fee })
                    .ToListAsync();

                var dictEmpSuppExpenses = empDelIncomes
                    .GroupBy(cp => cp.Employee)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Sum(cp => cp.Fee)
                    );
                #endregion

                #region Discipline Incomes/Expenses
                var empDiscIncomes = await _context.Set<DisciplineEngineer>()
                    .Where(de => !de.IsDeleted)
                    .Where(de => (start == null || de.CreatedDate >= start) && (end == null || de.CreatedDate <= end))
                    .Join(_context.Set<User>(),
                          de => de.EngineerId,
                          u => u.Id,
                          (de, user) => new { de, user })
                    .Where(r => !r.user.IsDeleted)
                    .Join(_context.Set<Discipline>(),
                          r => r.de.DisciplineId,
                          d => d.Id,
                          (r, discipline) => new { r.user, discipline })
                    .Join(_context.Set<Project>(),
                          r => r.discipline.ProjectId,
                          p => p.Id,
                          (r, project) => new { r.user, project })
                    .Join(_context.Set<Invoice>(),
                          r => r.project.Id,
                          i => i.ProjectId,
                          (r, invoice) => new { r.user, invoice })
                    .Where(r => !r.invoice.IsDeleted && r.invoice.Category == Models.Enum.InvoiceCategory.INCOMES)
                    .Join(_context.Set<Payment>(),
                          r => r.invoice.Id,
                          p => p.InvoiceId,
                          (r, payment) => new { Employee = r.user.FullName, Fee = payment.Fee })
                    .ToListAsync();

                var dictEmpDiscIncomes = empDelIncomes
                    .GroupBy(cp => cp.Employee)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Sum(cp => cp.Fee)
                    );

                var empDiscExpenses = await _context.Set<DisciplineEngineer>()
                    .Where(de => !de.IsDeleted)
                    .Where(de => (start == null || de.CreatedDate >= start) && (end == null || de.CreatedDate <= end))
                    .Join(_context.Set<User>(),
                          de => de.EngineerId,
                          u => u.Id,
                          (de, user) => new { de, user })
                    .Where(r => !r.user.IsDeleted)
                    .Join(_context.Set<Discipline>(),
                          r => r.de.DisciplineId,
                          d => d.Id,
                          (r, discipline) => new { r.user, discipline })
                    .Join(_context.Set<Project>(),
                          r => r.discipline.ProjectId,
                          p => p.Id,
                          (r, project) => new { r.user, project })
                    .Join(_context.Set<Invoice>(),
                          r => r.project.Id,
                          i => i.ProjectId,
                          (r, invoice) => new { r.user, invoice })
                    .Where(r => !r.invoice.IsDeleted && r.invoice.Category == Models.Enum.InvoiceCategory.EXPENSES)
                    .Join(_context.Set<Payment>(),
                          r => r.invoice.Id,
                          p => p.InvoiceId,
                          (r, payment) => new { Employee = r.user.FullName, Fee = payment.Fee })
                    .ToListAsync();

                var dictEmpDiscExpenses = empDelIncomes
                    .GroupBy(cp => cp.Employee)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Sum(cp => cp.Fee)
                    );
                #endregion

                var resultDictEmpDeliverables = _concutDicts(dictEmpDelIncomes, dictEmpDelExpenses);
                var resultDictEmpSupportiveWorks = _concutDicts(dictEmpSuppIncomes, dictEmpSuppExpenses);
                var resultDictEmpDisciplines = _concutDicts(dictEmpDiscIncomes, dictEmpDiscExpenses);

                // Get PM Net Profit
                var pmIncomeDict = await GetTurnoverPerProjectManager(start, end);

                var concut1 = _concutDicts(resultDictEmpDeliverables, resultDictEmpSupportiveWorks);
                var concut2 = _concutDicts(concut1, resultDictEmpDisciplines);
                var concut3 = _concutDicts(concut2, pmIncomeDict);

                return concut3;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On KpisRepo.GetTurnoverPerEmployee(DateTime? start = null,DateTime? end = null): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return new Dictionary<string, double>();
        }
    }

    protected Dictionary<string, double> _concutDicts(
        Dictionary<string, double> dict1,
        Dictionary<string, double> dict2
    ) {
        var concutDicts = dict1
            .Concat(dict2)
            .GroupBy(pair => pair.Key)
            .ToDictionary(
                group => group.Key,
                group => group.Sum(pair => pair.Key == group.Key ? pair.Value : -pair.Value)
            );

        foreach (var category in dict1.Keys)
        {
            if (!concutDicts.ContainsKey(category))
            {
                concutDicts[category] = -dict1[category];
            }
        }

        foreach (var category in dict2.Keys)
        {
            if (!concutDicts.ContainsKey(category))
            {
                concutDicts[category] = dict2[category];
            }
        }

        return concutDicts;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _ledRepo.Dispose();
                _invoiceRepo.Dispose();
                _paymentRepo.Dispose();
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
