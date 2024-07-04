using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Enum;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpiriaBMS.Core.Repositories;

public class OfferRepo : Repository<OfferDto, Offer>
{
    private ProjectsRepo _projectRepo;

    public OfferRepo(
        IDbContextFactory<AppDbContext> DbFactory,
        Logging.LoggerManager logger
    ) : base(DbFactory, logger)
    {
        _projectRepo = new ProjectsRepo(DbFactory, logger);
    }

    public new async Task<OfferDto?> Add(OfferDto entity, bool update = false)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.CreatedDate = update ? DateTime.Now.ToUniversalTime() : entity.CreatedDate;
            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var result = await _context.Set<Offer>().AddAsync(Mapping.Mapper.Map<Offer>(entity));
                await _context.SaveChangesAsync();

                if (result.Entity == null)
                    throw new ArgumentNullException($"{nameof(entity)} is null");

                var offer = await Get(result.Entity.Id);

                return Mapping.Mapper.Map<OfferDto>(offer);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On Repository.Add({Mapping.Mapper.Map<Offer>(entity).GetType()}): {ex.Message}, \nInner: {ex.InnerException.Message}");
            return null;
        }
    }

    public new async Task<OfferDto?> Update(OfferDto entity)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var entry = await _context.Set<Offer>().FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (entry != null)
                {
                    _context.Entry(entry).CurrentValues.SetValues(Mapping.Mapper.Map<Offer>(entity));
                    await _context.SaveChangesAsync();
                }

                if (entry == null)
                    throw new ArgumentNullException($"{nameof(entry)} is null");

                var offer = await Get(entry.Id);

                return Mapping.Mapper.Map<OfferDto>(offer);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On Repository.Update({Mapping.Mapper.Map<Offer>(entity).GetType()}): {ex.Message}, \nInner: {ex.InnerException.Message}");
            return null;
        }
    }

    public new async Task<OfferDto> Get(int id)
    {
        if (id == 0)
            throw new ArgumentException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var offer = await _context.Set<Offer>()
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
                                       .FirstOrDefaultAsync(o => o.Id == id);

            return Mapping.Mapper.Map<Offer, OfferDto>(offer);
        }
    }

    public async Task<ICollection<OfferDto>> GetAll(int projectId = 0, int stateId = 0, int typeId = 0, OfferResult? result = null)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var offers = await _context.Set<Project>()
                                       .Where(p => !p.IsDeleted)
                                       .Where(p => (projectId == 0 || p.Id == projectId))
                                       .Include(p => p.Offer)
                                       .ThenInclude(o => o.Lead)
                                       .ThenInclude(l => l.Client)
                                       .Include(p => p.Offer)
                                       .ThenInclude(o => o.Lead)
                                       .ThenInclude(l => l.Address)
                                       .Include(p => p.Offer)
                                       .ThenInclude(o => o.State)
                                       .Include(p => p.Offer)
                                       .ThenInclude(o => o.Type)
                                       .Include(p => p.Offer)
                                       .ThenInclude(o => o.SubCategory)
                                       .Include(p => p.Offer)
                                       .ThenInclude(o => o.Category)
                                       .Select(p => p.Offer)
                                       .Where(o => !o.IsDeleted
                                                    && (stateId == 0 || o.StateId == stateId)
                                                    && (typeId == 0 || o.TypeId == typeId)
                                                    && (result == null || o.Result == result)
                                         )
                                         .ToListAsync();

            return Mapping.Mapper.Map<List<Offer>, List<OfferDto>>(offers);
        }
    }

    public async Task<ICollection<OfferDto>> GetAllByLead(int ledId = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var offers = await _context.Set<Offer>()
                                       .Where(o => !o.IsDeleted && (ledId == 0 || o.LeadId == ledId))
                                       .Include(o => o.Lead)
                                       .Include(o => o.State)
                                       .Include(o => o.Type)
                                       .Include(o => o.Lead)
                                       .ThenInclude(p => p.Client)
                                       .Include(o => o.Lead)
                                       .ThenInclude(l => l.Address)
                                       .Include(o => o.SubCategory)
                                       .Include(o => o.Category)
                                       .ToListAsync();

            return Mapping.Mapper.Map<List<Offer>, List<OfferDto>>(offers);
        }
    }

    public async Task AddTime(int userId, int offerId, TimeSpan timespan, bool isEditByAdmin = false)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            DailyTime time = new DailyTime()
            {
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Date = DateTime.Now,
                DailyUserId = userId,
                OfferId = offerId,
                TimeSpan = new Timespan(timespan.Days, timespan.Hours, timespan.Minutes, timespan.Seconds),
                IsEditByAdmin = isEditByAdmin
            };
            await _context.Set<DailyTime>().AddAsync(time);

            // Save Changes
            await _context.SaveChangesAsync();
        }
    }

    public async Task<double> GetSumOfPayedFee(int offerId)
    {
        try
        {
            if (offerId == 0)
                throw new ArgumentNullException(nameof(offerId));

            List<int> projectIds;

            using (var _context = _dbContextFactory.CreateDbContext())
            {
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
                sum += await _projectRepo.GetSumOfPayedFee(projectId);
            }

            return sum;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On OfferRepo.GetSumOfPayedFee({typeof(Invoice)}): {ex.Message}, \nInner: {ex.InnerException.Message}");
            return 0;
        }
    }

    public async Task<double> GetSumOfPotencialFee(int offerId)
    {
        try
        {
            if (offerId == 0)
                throw new ArgumentNullException(nameof(offerId));

            List<int> projectIds;

            using (var _context = _dbContextFactory.CreateDbContext())
            {
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
                sum += await _projectRepo.GetSumOfPotencialFee(projectId);
            }

            return sum;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On OfferRepo.GetSumOfPotencialFee({typeof(Invoice)}): {ex.Message}, \nInner: {ex.InnerException.Message}");
            return 0;
        }
    }

    public async Task<bool> IsClosed(int offerId)
    {
        try
        {
            if (offerId == 0)
                throw new ArgumentNullException(nameof(offerId));

            List<int> projectIds;

            using (var _context = _dbContextFactory.CreateDbContext())
            {
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
                var closed = await _projectRepo.IsClosed(projectId);
                isClosed.Add(closed);
            }

            return isClosed.Count == 0 || isClosed.Any(c => c == false);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On OfferRepo.IsClosed({typeof(Invoice)}): {ex.Message}, \nInner: {ex.InnerException.Message}");
            return false;
        }
    }
}
