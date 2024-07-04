using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpiriaBMS.Core.Repositories;

public class LeadRepo : Repository<LeadDto, Lead>, IDisposable
{
    private readonly OfferRepo _offerRepo;
    private readonly ProjectsRepo _projectRep;
    private readonly InvoiceRepo _invoiceRepo;
    private readonly ContractRepo _contractRepo;

    public LeadRepo(
        IDbContextFactory<AppDbContext> DbFactory,
        Logging.LoggerManager logger
    ) : base(DbFactory, logger)
    {
        _projectRep = new ProjectsRepo(DbFactory, logger);
        _offerRepo = new OfferRepo(DbFactory, logger);
        _invoiceRepo = new InvoiceRepo(DbFactory, logger);
        _contractRepo = new ContractRepo(DbFactory, logger);
    }

    public new async Task<LeadDto> Add(LeadDto entity, bool update = false)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.CreatedDate = update ? DateTime.Now.ToUniversalTime() : entity.CreatedDate;
            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var result = await _context.Set<Lead>().AddAsync(Mapping.Mapper.Map<Lead>(entity));
                await _context.SaveChangesAsync();

                var id = result.Entity?.Id;
                if (id == null)
                    throw new NullReferenceException(nameof(id));

                var endry = await Get((int)id);

                return Mapping.Mapper.Map<LeadDto>(endry);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On LeadRepo.Add(Lead): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return null;
        }
    }

    public new async Task<LeadDto> Update(LeadDto entity)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var entry = await _context.Set<Lead>().FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (entry != null)
                {
                    _context.Entry(entry).CurrentValues.SetValues(Mapping.Mapper.Map<Lead>(entity));
                    await _context.SaveChangesAsync();
                }

                return Mapping.Mapper.Map<LeadDto>(entry);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On LeadRepo.Update(Lead): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return null;
        }
    }

    public async Task<LeadDto> Delete(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        var ledDto = await Get(id);

        if (ledDto == null)
            throw new ArgumentNullException(nameof(ledDto));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            // Delete Offer
            var offer = await _context.Set<Offer>().FirstOrDefaultAsync(o => !o.IsDeleted && o.LeadId == ledDto.Id);
            if (offer != null)
            {
                await _offerRepo.Delete(offer.Id);

                // Delete Projects
                var projects = await _context.Set<Project>().Where(p => !p.IsDeleted && p.OfferId == offer.Id).ToListAsync();
                if (projects.Count > 0)
                {
                    foreach (var project in projects)
                    {
                        await _projectRep.Delete(project.Id);

                        // Delete Invoices
                        var invoices = await _context.Set<Invoice>().Where(p => !p.IsDeleted && p.ProjectId == project.Id).Include(i => i.Contract).ToListAsync();
                        if (invoices.Count > 0)
                        {
                            foreach (var invoice in invoices)
                            {
                                await _invoiceRepo.Delete(invoice.Id);

                                // Delete Contract
                                if (invoice != null && invoice.ContractId != null && invoice.ContractId != 0)
                                {
                                    await _contractRepo.Delete((int)invoice.ContractId);
                                }
                            }
                        }

                    }
                }
            }

            // Delete Invoice
            ledDto.IsDeleted = true;
            await Update(ledDto);

            //_context.Set<U>().Remove(Mapping.Mapper.Map<U>(entity));
            //await _context.SaveChangesAsync();
        }

        return ledDto;
    }

    public new async Task<OfferDto?> GetOffer(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var i = await _context
                                .Set<Offer>()
                                .Where(r => !r.IsDeleted)
                                .Include(o => o.Lead)
                                .Include(o => o.State)
                                .Include(o => o.Type)
                                .Include(o => o.Lead)
                                .ThenInclude(p => p.Client)
                                .Include(o => o.Lead)
                                .ThenInclude(l => l.Address)
                                .Include(o => o.SubCategory)
                                .Include(o => o.Category)
                             .FirstOrDefaultAsync(r => r.LeadId == id);

            return Mapping.Mapper.Map<OfferDto>(i);
        }
    }

    public new async Task<LeadDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var i = await _context
                             .Set<Lead>()
                             .Where(r => !r.IsDeleted)
                             .Include(l => l.Address)
                             .Include(l => l.Client)
                             .FirstOrDefaultAsync(r => r.Id == id);

            return Mapping.Mapper.Map<LeadDto>(i);
        }
    }

    public new async Task<ICollection<LeadDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Lead> items;
            if (pageSize == 0 || pageIndex == 0)
            {
                items = await _context.Set<Lead>()
                                       .Where(r => !r.IsDeleted)
                                       .Include(l => l.Address)
                                       .Include(l => l.Client)
                                       .ToListAsync();
                return Mapping.Mapper.Map<List<LeadDto>>(items);
            }

            items = await _context.Set<Lead>()
                                  .Where(r => !r.IsDeleted)
                                  .Skip((pageIndex - 1) * pageSize)
                                  .Take(pageSize)
                                  .Include(l => l.Address)
                                  .Include(l => l.Client)
                                  .ToListAsync();

            return Mapping.Mapper.Map<List<LeadDto>>(items);
        }
    }

    public async Task AddTime(int userId, int ledId, TimeSpan timespan, bool isEditByAdmin = false)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            DailyTime time = new DailyTime()
            {
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Date = DateTime.Now,
                DailyUserId = userId,
                LeadId = ledId,
                TimeSpan = new Timespan(timespan.Days, timespan.Hours, timespan.Minutes, timespan.Seconds),
                IsEditByAdmin = isEditByAdmin
            };
            await _context.Set<DailyTime>().AddAsync(time);

            // Save Changes
            await _context.SaveChangesAsync();
        }
    }

    #region Next Income Functions
    public async Task<List<LeadDto>> GetAllOppenLeads()
    {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var allLeadsIds = await _context.Set<Lead>()
                    .Where(l => !l.IsDeleted)
                    .Select(l => l.Id)
                    .ToListAsync();

                if (allLeadsIds == null || allLeadsIds.Count == 0)
                    return new List<LeadDto>();

                var leds = new List<LeadDto>();

                foreach (var id in allLeadsIds)
                {
                    var isClosed = await IsClosed(id);
                    if (!isClosed)
                    {
                        var led = await Get(id);
                        if (led == null)
                            continue;

                        leds.Add(led);
                    }
                }

                return leds;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On LeadRepo.GetAllOppenLeads(): {ex.Message}, \nInner: {ex.InnerException.Message}");
            return new List<LeadDto>();
        }
    }

    public async Task<double> GetSumOfAllOppenLeadsPotencialFee()
    {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var allLeadsIds = await _context.Set<Lead>()
                    .Where(l => !l.IsDeleted)
                    .Select(l => l.Id)
                    .ToListAsync();

                if (allLeadsIds == null || allLeadsIds.Count == 0)
                    return 0;

                double sumPontecialFee = 0;

                foreach (var id in allLeadsIds)
                {
                    var isClosed = await IsClosed(id);
                    if (!isClosed)
                    {
                        var sum = await GetSumOfPotencialFee(id);
                        sumPontecialFee += sum;
                    }
                }

                return sumPontecialFee;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On LeadRepo.GetSumOfAllOppenLeadsPotencialFee(): {ex.Message}, \nInner: {ex.InnerException.Message}");
            return 0;
        }
    }

    public async Task<double> GetSumOfPayedFee(int ledId)
    {
        try
        {
            if (ledId == 0)
                throw new ArgumentNullException(nameof(ledId));

            List<int> projectIds;

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var offerId = await _context.Set<Offer>()
                    .Where(o => !o.IsDeleted && o.LeadId == ledId)
                    .Select(l => l.Id)
                    .FirstOrDefaultAsync();

                if (offerId == 0)
                    throw new ArgumentNullException(nameof(offerId));

                projectIds = await _context
                                .Set<Project>()
                                .Where(i => !i.IsDeleted && i.OfferId == offerId)
                                .Select(i => i.Id)
                                .ToListAsync();
            }

            if (projectIds == null || projectIds.Count == 0)
                return 0;

            double sum = 0;

            foreach (var projectId in projectIds)
            {
                sum += await _projectRep.GetSumOfPayedFee(projectId);
            }

            return sum;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On LeadRepo.GetSumOfPayedFee({ledId}): {ex.Message}, \nInner: {ex.InnerException.Message}");
            return 0;
        }
    }

    public async Task<double> GetSumOfPotencialFee(int ledId)
    {
        try
        {
            if (ledId == 0)
                throw new ArgumentNullException(nameof(ledId));

            List<int> projectIds;

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var offerId = await _context.Set<Offer>()
                    .Where(o => !o.IsDeleted && o.LeadId == ledId)
                    .Select(l => l.Id)
                    .FirstOrDefaultAsync();

                if (offerId == 0)
                    throw new ArgumentNullException(nameof(offerId));

                projectIds = await _context
                                .Set<Project>()
                                .Where(i => !i.IsDeleted && i.OfferId == offerId)
                                .Select(i => i.Id)
                                .ToListAsync();
            }

            if (projectIds == null || projectIds.Count == 0)
                return 0;

            double sum = 0;

            foreach (var projectId in projectIds)
            {
                sum += await _projectRep.GetSumOfPotencialFee(projectId);
            }

            return sum;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On LeadRepo.GetSumOfPotencialFee({ledId}): {ex.Message}, \nInner: {ex.InnerException.Message}");
            return 0;
        }
    }

    public async Task<bool> IsClosed(int ledId)
    {
        try
        {
            if (ledId == 0)
                throw new ArgumentNullException(nameof(ledId));

            List<int> projectIds;

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var offerId = await _context.Set<Offer>()
                    .Where(o => !o.IsDeleted && o.LeadId == ledId)
                    .Select(l => l.Id)
                    .FirstOrDefaultAsync();

                if (offerId == 0)
                    throw new ArgumentNullException(nameof(offerId));

                projectIds = await _context
                                .Set<Project>()
                                .Where(i => !i.IsDeleted && i.OfferId == offerId)
                                .Select(i => i.Id)
                                .ToListAsync();
            }

            if (projectIds == null || projectIds.Count == 0)
                return false;

            List<bool> isClosed = new List<bool>();

            foreach (var projectId in projectIds)
            {
                var closed = await _projectRep.IsClosed(projectId);
                isClosed.Add(closed);
            }

            return isClosed.Count == 0 || isClosed.Any(c => c == false);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On LeadRepo.IsClosed({ledId}): {ex.Message}, \nInner: {ex.InnerException.Message}");
            return false;
        }
    }

    #endregion
}
