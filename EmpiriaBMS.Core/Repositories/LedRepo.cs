using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpiriaBMS.Core.Repositories;

public class LedRepo : Repository<LedDto, Led>, IDisposable
{
    private readonly OfferRepo _offerRepo;
    private readonly ProjectsRepo _projectRep;
    private readonly InvoiceRepo _invoiceRepo;
    private readonly ContractRepo _contractRepo;

    public LedRepo(
        IDbContextFactory<AppDbContext> DbFactory,
        OfferRepo offerRepo,
        ProjectsRepo projectRepo,
        InvoiceRepo invoiceRepo,
        ContractRepo contractRepo
    ) : base(DbFactory)
    {
        _offerRepo = offerRepo;
        _projectRep = projectRepo;
        _invoiceRepo = invoiceRepo;
        _contractRepo = contractRepo;
    }

    public new async Task<LedDto> Add(LedDto entity, bool update = false)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.CreatedDate = update ? DateTime.Now.ToUniversalTime() : entity.CreatedDate;
            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var result = await _context.Set<Led>().AddAsync(Mapping.Mapper.Map<Led>(entity));
                await _context.SaveChangesAsync();

                return Mapping.Mapper.Map<LedDto>(result.Entity);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception On LedRepo.Add(Led): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return null;
        }
    }

    public new async Task<LedDto> Update(LedDto entity)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var entry = await _context.Set<Led>().FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (entry != null)
                {
                    _context.Entry(entry).CurrentValues.SetValues(Mapping.Mapper.Map<Led>(entity));
                    await _context.SaveChangesAsync();
                }

                return Mapping.Mapper.Map<LedDto>(entry);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception On LedRepo.Update(Led): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return null;
        }
    }

    public async Task<LedDto> Delete(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        var ledDto = await Get(id);

        if (ledDto == null)
            throw new ArgumentNullException(nameof(ledDto));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            // Delete Offer
            var offer = await _context.Set<Offer>().FirstOrDefaultAsync(o => !o.IsDeleted && o.LedId == ledDto.Id);
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
                                .Include(o => o.Led)
                                .Include(o => o.State)
                                .Include(o => o.Type)
                                .Include(o => o.Led)
                                .ThenInclude(p => p.Client)
                                .Include(o => o.Led)
                                .ThenInclude(l => l.Address)
                                .Include(o => o.SubCategory)
                                .Include(o => o.Category)
                             .FirstOrDefaultAsync(r => r.LedId == id);

            return Mapping.Mapper.Map<OfferDto>(i);
        }
    }

    public new async Task<LedDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var i = await _context
                             .Set<Led>()
                             .Where(r => !r.IsDeleted)
                             .Include(l => l.Address)
                             .Include(l => l.Client)
                             .FirstOrDefaultAsync(r => r.Id == id);

            return Mapping.Mapper.Map<LedDto>(i);
        }
    }

    public new async Task<ICollection<LedDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Led> items;
            if (pageSize == 0 || pageIndex == 0)
            {
                items = await _context.Set<Led>()
                                       .Where(r => !r.IsDeleted)
                                       .Include(l => l.Address)
                                       .Include(l => l.Client)
                                       .ToListAsync();
                return Mapping.Mapper.Map<List<LedDto>>(items);
            }

            items = await _context.Set<Led>()
                                  .Where(r => !r.IsDeleted)
                                  .Skip((pageIndex - 1) * pageSize)
                                  .Take(pageSize)
                                  .Include(l => l.Address)
                                  .Include(l => l.Client)
                                  .ToListAsync();

            return Mapping.Mapper.Map<List<LedDto>>(items);
        }
    }

    public async Task AddTime(int userId, int ledId, TimeSpan timespan)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            DailyTime time = new DailyTime()
            {
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Date = DateTime.Now,
                DailyUserId = userId,
                LedId = ledId,
                TimeSpan = new Timespan(timespan.Days, timespan.Hours, timespan.Minutes, timespan.Seconds)
            };
            await _context.Set<DailyTime>().AddAsync(time);

            // Save Changes
            await _context.SaveChangesAsync();
        }
    }
}
