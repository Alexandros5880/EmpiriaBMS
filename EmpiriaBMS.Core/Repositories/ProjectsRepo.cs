using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmpiriaBMS.Core.Repositories;
public class ProjectsRepo : Repository<ProjectDto, Project>
{
    private InvoiceRepo _invoiceRepo;

    public ProjectsRepo(
        IDbContextFactory<AppDbContext> DbFactory,
        Logging.LoggerManager logger
    ) : base(DbFactory, logger)
    {
        _invoiceRepo = new InvoiceRepo(DbFactory, logger);
    }

    public async new Task<ProjectDto> Add(ProjectDto entity, bool update = false)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.CreatedDate = update ? DateTime.Now.ToUniversalTime() : entity.CreatedDate;
            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var result = await _context.Set<Project>().AddAsync(Mapping.Mapper.Map<Project>(entity));
                await _context.SaveChangesAsync();

                var project = result.Entity as Project;
                var dto = await Get(project.Id);

                return dto;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ProjectsRepo.Add(Project): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return null;
        }
    }

    public async new Task<ProjectDto> Update(ProjectDto entity)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var project = await _context.Set<Project>().FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (project != null)
                {
                    _context.Entry(project).CurrentValues.SetValues(Mapping.Mapper.Map<Project>(entity));
                    await _context.SaveChangesAsync();
                }

                var dto = await Get(project.Id);

                return dto;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ProjectsRepo.Update(Project): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return null;
        }
    }

    public new async Task<ProjectDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var project = await _context
                             .Set<Project>()
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
                             .FirstOrDefaultAsync(r => r.Id == id);

            var dto = Mapping.Mapper.Map<ProjectDto>(project);

            return dto;
        }
    }

    public async Task<ICollection<ProjectDto>> GetAll()
    {
        List<Project> projects;
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var offers = await _context.Set<Offer>()
                    .Include(o => o.Category)
                    .Include(o => o.SubCategory)
                    .Include(o => o.Lead)
                    .ThenInclude(l => l.Address)
                    .Where(r => !r.IsDeleted)
                    .ToListAsync();

            projects = await _context.Set<Project>()
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
                                     .OrderBy(e => !e.Active)
                                     .ThenByDescending(e => e.DeadLine)
                                     .ToListAsync();

            // Perform the projection after the data is loaded
            projects = projects.Select(p =>
            {
                p.Offer = offers.FirstOrDefault(o => o.Id == p.OfferId);
                return p;
            }).ToList();

            return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
        }
    }

    public async Task<ICollection<ProjectDto>> GetAll(int userId, int offerId = 0, bool? active = null, TimeSpan? period = null)
    {
        try
        {
            if (userId == 0)
                return new List<ProjectDto>();

            // From Date Until Now
            DateTime fromDate;
            if (period.HasValue)
            {
                fromDate = DateTime.Now.Subtract(period.Value);
            } else
            {
                fromDate = DateTime.MinValue;
            }

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
                    .Include(o => o.Lead)
                    .ThenInclude(l => l.Address)
                    .Where(r => !r.IsDeleted)
                    .ToListAsync();

                //var offersIds = offers.Select(o => o.Id).ToList();

                List<Project> allProjects;

                if (permissions.Any(p => p.Ord == 11))
                {
                    allProjects = await _context.Set<Project>()
                                                .Where(r => !r.IsDeleted)
                                                .Where(r => active == null || r.Active == active)
                                                .Where(p => (offerId == 0 || p.OfferId == offerId))
                                                .Where(p => p.StartDate >= fromDate)
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
                                                .OrderBy(e => !e.Active)
                                                .ThenByDescending(e => e.DeadLine)
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
                                                .Where(r => active == null || r.Active == active)
                                                .Where(p => (offerId == 0 || p.OfferId == offerId))
                                                .Where(p => projectsFromDisciplineIds.Contains(p.Id))
                                                .Where(p => p.StartDate >= fromDate)
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
                                                .OrderBy(e => !e.Active)
                                                .ThenByDescending(e => e.DeadLine)
                                                .ToListAsync();
                }

                // Perform the projection after the data is loaded
                allProjects = allProjects.Select(p =>
                {
                    p.Offer = offers.FirstOrDefault(o => o.Id == p.OfferId);
                    return p;
                }).ToList();

                return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(allProjects.Distinct().ToList());
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ProjectsRepo.GetLastMonthProjects({typeof(Invoice)}): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return new List<ProjectDto>();
        }
    }

    public async Task<List<ProjectDto>> GetProjectsWithFallback(int userId, int offerId, bool? active)
    {
        List<ProjectDto> projectsDto = new List<ProjectDto>();
        int monthsToCheck = 1;

        while (!projectsDto.Any())
        {
            TimeSpan period = TimeSpan.FromDays(30 * monthsToCheck);
            monthsToCheck++;
            projectsDto = (await GetAll(userId, offerId, active, period)).ToList();
        }

        return projectsDto;
    }

    public async Task<ICollection<ProjectDto>> GetOffersProjects(int? offerId)
    {
        if (offerId == null || offerId == 0)
            return new List<ProjectDto>();

        List<Project> projects;
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            projects = await _context.Set<Project>()
                                     .Where(r => !r.IsDeleted)
                                     .Where(r => r.OfferId == offerId)
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
                                 .Where(r => !r.IsDeleted)
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
                           .Where(r => !r.IsDeleted)
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
                                            .Where(r => !r.IsDeleted)
                                            .Where(de => de.ProjectId == projectId)
                                            .Include(d => d.Type)
                                            .ToListAsync();
            }
            else
            {
                var myDrawingsIds = await _context.Set<DeliverableEmployee>()
                                                  .Where(r => !r.IsDeleted)
                                                  .Where(de => de.EmployeeId == userId)
                                                  .Select(de => de.DeliverableId)
                                                  .ToListAsync();

                var myDisciplinesIds = await _context.Set<Deliverable>()
                                                     .Where(r => !r.IsDeleted)
                                                     .Where(d => myDrawingsIds.Contains(d.Id))
                                                     .Select(dd => dd.DisciplineId)
                                                     .ToListAsync();

                disciplines = await _context.Set<Discipline>()
                                            .Where(r => !r.IsDeleted)
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
                                 .Where(r => !r.IsDeleted)
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
            var project = await _context.Set<Project>().Where(r => !r.IsDeleted).FirstOrDefaultAsync(p => p.Id == projectId);
            if (project == null)
                throw new ArgumentNullException(nameof(project));

            var otherTypes = await _context.Set<SupportiveWorkType>().Where(r => !r.IsDeleted).ToListAsync();

            // Calculate Disciplines Estimated Hours, Disciplines Estimated ManDays, Disciplines EstimatedCompleted
            foreach (var d in disciplines)
            {
                d.EstimatedHours = d.EstimatedMandays * 8;

                // Calculate Discipline EstimatedCompleted
                var disciplineMenHours = await _context.Set<DailyTime>()
                                                       .Where(r => !r.IsDeleted)
                                                       .Where(d => d.DisciplineId == d.Id)
                                                       .Select(d => d.TimeSpan.Hours)
                                                       .SumAsync();
                decimal divitionDiscResult = Convert.ToDecimal(disciplineMenHours)
                                                        / Convert.ToDecimal(d.EstimatedHours);
                d.EstimatedCompleted = (float)divitionDiscResult * 100;

                // Update Discipline Project
                d.ProjectId = projectId;

                // Update Discipline
                var exists = await _context.Set<Discipline>().Where(r => !r.IsDeleted).AnyAsync(disc => disc.Id == d.Id);
                if (exists)
                {
                    var dbDisc = await _context.Set<Discipline>().Where(r => !r.IsDeleted).FirstOrDefaultAsync(disc => disc.Id == d.Id);
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
                        SupportiveWork other = new SupportiveWork()
                        {
                            TypeId = t.Id,
                            DisciplineId = savedDisciplineId
                        };
                        await _context.Set<SupportiveWork>().AddAsync(other);
                    }
                }
            }

            // Get Sum EstimatedManDays && EstimatedHours and update Project
            var estimatedManDaysSum = disciplines.Where(r => !r.IsDeleted).Select(d => d.EstimatedMandays).Sum();
            var estimatedHoursSum = disciplines.Where(r => !r.IsDeleted).Select(d => d.EstimatedHours).Sum();
            project.EstimatedMandays = estimatedManDaysSum;
            project.EstimatedHours = estimatedHoursSum;

            // Calculate Project EstimatedComplete
            var projectMenHours = await _context.Set<DailyTime>()
                                                .Where(r => !r.IsDeleted)
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
                                  .Where(r => !r.IsDeleted)
                                  .FirstOrDefaultAsync(p => p.Id == projectId);

            if (p == null)
                throw new NullReferenceException(nameof(p));

            var pmId = p.ProjectManagerId;

            var pm = await _context.Set<User>().Where(r => !r.IsDeleted).FirstOrDefaultAsync(u => u.Id == pmId);

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
                                          .Where(r => !r.IsDeleted)
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
                                         .Where(r => !r.IsDeleted)
                                         .Where(i => i.ProjectId == projectId)
                                         .Include(i => i.Payments)
                                         .Include(i => i.Type)
                                         .Include(i => i.Contract)
                                         .Include(i => i.Project)
                                         .ToListAsync();

            var dtos = Mapping.Mapper.Map<List<InvoiceDto>>(invoices);
            return dtos;
        }
    }

    public async Task<double> GetSumOfPayedFee(int projectId)
    {
        try
        {
            if (projectId == 0)
                throw new ArgumentNullException(nameof(projectId));

            List<int> invoiceIds;

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                invoiceIds = await _context
                                .Set<Invoice>()
                                .Where(i => !i.IsDeleted && i.ProjectId == projectId)
                                .Select(i => i.Id)
                                .ToListAsync();
            }

            if (invoiceIds == null || invoiceIds.Count == 0)
                return 0;

            double sum = 0;

            foreach (var invoiceId in invoiceIds)
            {
                sum += await _invoiceRepo.GetSumOfPayedFee(invoiceId);
            }

            return sum;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ProjectsRepo.GetSumOfPayedFee({typeof(Invoice)}): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return 0;
        }
    }

    public async Task<double> GetSumOfPotencialFee(int projectId)
    {
        try
        {
            if (projectId == 0)
                throw new ArgumentNullException(nameof(projectId));

            List<int> invoiceIds;

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                invoiceIds = await _context
                                .Set<Invoice>()
                                .Where(i => !i.IsDeleted && i.ProjectId == projectId)
                                .Select(i => i.Id)
                                .ToListAsync();
            }

            if (invoiceIds == null || invoiceIds.Count == 0)
                return 0;

            double sum = 0;

            foreach (var invoiceId in invoiceIds)
            {
                sum += await _invoiceRepo.GetSumOfPotencialFee(invoiceId);
            }

            return sum;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ProjectsRepo.GetSumOfPotencialFee({typeof(Invoice)}): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return 0;
        }
    }

    public async Task<bool> IsClosed(int projectId)
    {
        try
        {
            if (projectId == 0)
                throw new ArgumentNullException(nameof(projectId));

            List<int> invoiceIds;

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                invoiceIds = await _context
                                .Set<Invoice>()
                                .Where(i => !i.IsDeleted && i.ProjectId == projectId)
                                .Select(i => i.Id)
                                .ToListAsync();
            }

            if (invoiceIds == null || invoiceIds.Count == 0)
                return false;

            List<bool> isClosed = new List<bool>();

            foreach (var invoiceId in invoiceIds)
            {
                if (_invoiceRepo == null)
                    continue;
                var closed = await _invoiceRepo.IsClosed(invoiceId);
                isClosed.Add(closed);
            }

            return isClosed.Count == 0 || isClosed.Any(c => c == false);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ProjectsRepo.IsClosed({typeof(Invoice)}): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return false;
        }
    }
}
