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

    public async Task<ProjectDto> Add(ProjectDto entity, bool update = false, List<long>? subConstructorsIds = null)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.CreatedDate = update ? DateTime.Now.ToUniversalTime() : entity.CreatedDate;
            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            Project project;

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                entity.ProjectManager = null;
                entity.Offer = null;

                var result = await _context.Set<Project>().AddAsync(Mapping.Mapper.Map<Project>(entity));
                await _context.SaveChangesAsync();

                project = result.Entity as Project;
            }

            if (subConstructorsIds != null)
                await UpsertSubConstructors(project.Id, subConstructorsIds);

            var dto = await Get(project.Id);

            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            return dto;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ProjectsRepo.Add(Project): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return default(ProjectDto)!;
        }
    }

    public async Task<ProjectDto> Update(ProjectDto entity, List<long>? subConstructorsIds = null)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            Project project;

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                project = await _context.Set<Project>().FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (project != null)
                {
                    entity.ProjectManager = null;
                    entity.Offer = null;

                    _context.Entry(project).CurrentValues.SetValues(Mapping.Mapper.Map<Project>(entity));
                    await _context.SaveChangesAsync();
                }
            }

            if (project == null)
                throw new ArgumentNullException(nameof(project));

            if (subConstructorsIds != null)
                await UpsertSubConstructors(project.Id, subConstructorsIds);

            var dto = await Get(project.Id);

            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            return dto;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ProjectsRepo.Update(Project): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return default(ProjectDto)!;
        }
    }

    public new async Task<ProjectDto?> Get(long id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            try
            {
                var offers = await _context.Set<Offer>()
                    .Include(o => o.Category)
                    .Include(o => o.SubCategory)
                    .Include(o => o.Client)
                    .ThenInclude(l => l.Address)
                    .Where(r => !r.IsDeleted)
                    .ToListAsync();

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
                                 .ThenInclude(o => o.Client)
                                 .ThenInclude(l => l.Address)
                                 .Include(p => p.Offer)
                                 .ThenInclude(o => o.Client)
                                 .Include(p => p.ProjectManager)
                                 .Include(p => p.ProjectsSubConstructors)
                                 .Include(p => p.Address)
                                 .FirstOrDefaultAsync(r => r.Id == id);

                project.Offer = offers.FirstOrDefault(o => o.Id == project.OfferId);

                var dto = Mapping.Mapper.Map<ProjectDto>(project);

                return dto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception On ProjectsRepo.Get(int id): {ex.Message}, \nInner: {ex.InnerException?.Message}");
                return default(ProjectDto)!;
            }
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
                    .Include(o => o.Client)
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
                .ThenInclude(o => o.Client)
                .ThenInclude(l => l.Address)
                .Include(p => p.Offer)
                .ThenInclude(o => o.Client)
                .Include(p => p.ProjectManager)
                .Include(p => p.ProjectsSubConstructors)
                .Include(p => p.Address)
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

    public async Task<ICollection<ProjectDto>> GetAll(long userId, long offerId = 0, bool? active = null, TimeSpan? period = null)
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
                    .Include(o => o.Client)
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
                        .ThenInclude(o => o.Client)
                        .ThenInclude(l => l.Address)
                        .Include(p => p.Offer)
                        .ThenInclude(o => o.Client)
                        .Include(p => p.ProjectManager)
                        .Include(p => p.ProjectsSubConstructors)
                        .Include(p => p.Address)
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
                        .ThenInclude(o => o.Client)
                        .ThenInclude(l => l.Address)
                        .Include(p => p.Offer)
                        .ThenInclude(o => o.Client)
                        .Include(p => p.ProjectManager)
                        .Include(p => p.ProjectsSubConstructors)
                        .Include(p => p.Address)
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

    public async Task<List<ProjectDto>> GetProjectsWithFallback(long userId, long offerId, bool? active)
    {
        try
        {
            List<ProjectDto> projectsDto = new List<ProjectDto>();
            int monthsToCheck = 1;
            int maxMonthsToCheck = 12; // Define a reasonable limit to avoid overflow

            while (!projectsDto.Any() && monthsToCheck <= maxMonthsToCheck)
            {
                // Calculate the total days to check
                int totalDaysToCheck = 30 * monthsToCheck;

                // Safeguard against overflow
                if (totalDaysToCheck < 0)
                {
                    throw new InvalidOperationException("Calculated days exceed maximum limit.");
                }

                TimeSpan period = TimeSpan.FromDays(totalDaysToCheck);
                projectsDto = (await GetAll(userId, offerId, active, period)).ToList();

                monthsToCheck++;
            }

            return projectsDto;
        }
        catch(Exception ex)
        {
            _logger.LogError($"Exception On ProjectsRepo.GetProjectsWithFallback({typeof(Invoice)}): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return default(List<ProjectDto>)!;
        }
    }

    public async Task<ICollection<ProjectDto>> GetOffersProjects(long? offerId)
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
                    .ThenInclude(o => o.Client)
                    .ThenInclude(l => l.Address)
                    .Include(p => p.Offer)
                    .ThenInclude(o => o.Client)
                    .Include(p => p.ProjectManager)
                    .Include(p => p.ProjectsSubConstructors)
                    .OrderBy(e => !e.Active)
                    .ThenByDescending(e => e.DeadLine)
                    .ToListAsync();

            return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects.Distinct().ToList());
        }
    }

    public async Task<long> GetMenHoursAsync(long projectId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context.Set<DailyTime>()
                                 .Where(r => !r.IsDeleted)
                                 .Where(mh => mh.ProjectId == projectId)
                                 .Select(mh => mh.Hours)
                                 .SumAsync();
        }
    }

    public long GetMenHours(long projectId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return _context.Set<DailyTime>()
                           .Where(r => !r.IsDeleted)
                           .Where(mh => mh.ProjectId == projectId)
                           .Select(mh => mh.Hours)
                           .Sum();
        }
    }

    public async Task<ICollection<DisciplineDto>> GetDisciplines(long projectId, long userId, bool all)
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

    public async Task<int> CountDiscipline(long id)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
            return await _context.Set<Discipline>()
                                 .Where(r => !r.IsDeleted)
                                 .Where(de => de.ProjectId == id)
                                 .CountAsync();
    }

    public async Task<UserDto> GetProjectManager(long projectId)
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

    #region Sub Constructors
    public async Task UpsertSubConstructors(long projectId, List<long> subConstructorsIds)
    {
        try
        {
            if (projectId == 0)
                throw new ArgumentException($"{nameof(projectId)} == 0");

            if (subConstructorsIds == null || !subConstructorsIds.Any())
                return;

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var existingSubConstructors = _context.Set<ProjectSubConstractor>()
                                                            .Where(r => r.ProjectId == projectId);

                var existingIds = existingSubConstructors.Select(sc => sc.SubConstructorId);

                var idsToRemove = existingSubConstructors
                                    .Where(sc => !subConstructorsIds.Contains(sc.SubConstructorId));

                var idsToAdd = subConstructorsIds
                                    .Where(id => !existingIds.Contains(id))
                                    .ToList();

                // Remove old relationships
                if (idsToRemove.Any())
                    _context.Set<ProjectSubConstractor>().RemoveRange(idsToRemove);

                // Add new relationships
                foreach (var id in idsToAdd)
                {
                    ProjectSubConstractor newPs = new ProjectSubConstractor()
                    {
                        CreatedDate = DateTime.Now.ToUniversalTime(),
                        LastUpdatedDate = DateTime.Now.ToUniversalTime(),
                        ProjectId = projectId,
                        SubConstructorId = id,
                        IsDeleted = false
                    };
                    await _context.Set<ProjectSubConstractor>().AddAsync(newPs);
                }

                // Save changes if there were any additions or removals
                if (idsToRemove.Any() || idsToAdd.Any())
                    await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ProjectsRepo.UpsertSubConstructors(ProjectId: {projectId}): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    public async Task<ICollection<SubConstructorDto>> GetSubConstructors(long projectId)
    {
        try
        {
            if (projectId == 0)
                throw new ArgumentException(nameof(projectId));

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var subConstructorsIds = _context.Set<ProjectSubConstractor>()
                                .Where(r => !r.IsDeleted)
                                .Where(r => r.ProjectId == projectId)
                                .Select(r => r.SubConstructorId);

                if (subConstructorsIds == null)
                    throw new NullReferenceException(nameof(subConstructorsIds));

                if (!subConstructorsIds.Any())
                    return default(List<SubConstructorDto>)!;

                var subConstructors = await _context.Set<SubConstructor>()
                    .Where(s => !s.IsDeleted)
                    .Where(s => subConstructorsIds.Contains(s.Id))
                    .ToListAsync();

                return Mapping.Mapper.Map<List<SubConstructorDto>>(subConstructors);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ProjectsRepo.GetSubConstructors(int projectId): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return default(ICollection<SubConstructorDto>)!;
        }
    }

    public async Task<ICollection<long>> GetSubConstructorsIds(long projectId)
    {
        try
        {
            if (projectId == 0)
                throw new ArgumentException(nameof(projectId));

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var subConstructorsIds = _context.Set<ProjectSubConstractor>()
                                .Where(r => !r.IsDeleted)
                                .Where(r => r.ProjectId == projectId)
                                .Select(r => r.SubConstructorId);

                if (subConstructorsIds == null)
                    throw new NullReferenceException(nameof(subConstructorsIds));

                if (!subConstructorsIds.Any())
                    return default(List<long>)!;

                var subConstructors = await _context.Set<SubConstructor>()
                    .Where(s => !s.IsDeleted)
                    .Where(s => subConstructorsIds.Contains(s.Id))
                    .Select(s => s.Id)
                    .ToListAsync();

                return subConstructors;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ProjectsRepo.GetSubConstructorsIds(long projectId): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return default(ICollection<long>)!;
        }
    }
    #endregion

    public async Task<ICollection<IssueDto>> GetComplains(long projectId)
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

    public async Task<ICollection<InvoiceDto>> GetInvoices(long projectId)
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
                                         .Include(i => i.Project)
                                         .ToListAsync();

            var dtos = Mapping.Mapper.Map<List<InvoiceDto>>(invoices);
            return dtos;
        }
    }

    public async Task<double> GetSumOfPayedFee(long projectId)
    {
        try
        {
            if (projectId == 0)
                throw new ArgumentNullException(nameof(projectId));

            List<long> invoiceIds;

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

    public async Task<double> GetSumOfPotencialFee(long projectId)
    {
        try
        {
            if (projectId == 0)
                throw new ArgumentNullException(nameof(projectId));

            List<long> invoiceIds;

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

    public async Task<float> GetEstimatedCompleted(long id)
    {
        try
        {
            if (id == 0)
                throw new ArgumentNullException(nameof(id));

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var disciplinesIds = await _context.Set<Discipline>()
                                       .Where(r => r.ProjectId == id)
                                               .Select(r => r.Id)
                                               .ToListAsync();

                var deliverablesIds = await _context.Set<Deliverable>()
                                                   .Where(r => !r.IsDeleted)
                                                   .Where(r => disciplinesIds.Contains(r.DisciplineId))
                                                   .Select(r => r.Id)
                                                   .ToListAsync();

                var supportiveWorksIds = await _context.Set<SupportiveWork>()
                                               .Where(r => !r.IsDeleted)
                                               .Where(r => disciplinesIds.Contains(r.DisciplineId))
                                               .Select(r => r.Id)
                                               .ToListAsync();

                var projectMenHours = await _context.Set<DailyTime>()
                                               .Where(r => !r.IsDeleted)
                                               .Where(r => r.ProjectId == id
                                                        || disciplinesIds.Contains(r.DisciplineId ?? 0)
                                                        || deliverablesIds.Contains(r.DeliverableId ?? 0)
                                                        || supportiveWorksIds.Contains(r.SupportiveWorkId ?? 0))
                                               .Select(h => h.Hours)
                                               .SumAsync();

                var project = await _context.Set<Project>()
                                            .Where(r => !r.IsDeleted)
                                            .FirstOrDefaultAsync(p => p.Id == id);

                if (project == null)
                    throw new NullReferenceException(nameof(project));

                decimal divitionProResult = Convert.ToDecimal(projectMenHours) / Convert.ToDecimal(project.EstimatedHours);
                var estimatedCompleted = (float)divitionProResult * 100;

                return estimatedCompleted;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ProjectsRepo.GetEstimatedCompleted(id): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return 0;
        }
    }

    public async Task<float> GetDeclaredCompleted(long id)
    {
        try
        {
            if (id == 0)
                throw new ArgumentNullException(nameof(id));

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var disciplinesIds = await _context.Set<Discipline>()
                                       .Where(r => r.ProjectId == id)
                                               .Select(r => r.Id)
                                               .ToListAsync();

                var deliverablesComplEstSum = await _context.Set<Deliverable>()
                                               .Where(r => !r.IsDeleted)
                                               .Where(r => disciplinesIds.Contains(r.DisciplineId))
                                               .Select(r => r.CompletionEstimation)
                                               .SumAsync();

                var deliverablesComplEstCount = await _context.Set<Deliverable>()
                                               .Where(r => !r.IsDeleted)
                                               .Where(r => disciplinesIds.Contains(r.DisciplineId))
                                               .CountAsync();

                if (deliverablesComplEstSum == 0 || deliverablesComplEstCount == 0)
                    return 0;

                var avgCompletedEstimation = deliverablesComplEstSum / deliverablesComplEstCount;

                return avgCompletedEstimation;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ProjectsRepo.GetEstimatedCompleted(id): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return 0;
        }
    }

    public async Task<bool> IsClosed(long projectId)
    {
        try
        {
            if (projectId == 0)
                throw new ArgumentNullException(nameof(projectId));

            List<long> invoiceIds;

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
