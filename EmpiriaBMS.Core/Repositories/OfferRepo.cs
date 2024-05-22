using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpiriaBMS.Core.Repositories;

public class OfferRepo : Repository<OfferDto, Offer>
{
    public OfferRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

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
            Console.WriteLine($"Exception On Repository.Add({Mapping.Mapper.Map<Offer>(entity).GetType()}): {ex.Message}, \nInner: {ex.InnerException.Message}");
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
            Console.WriteLine($"Exception On Repository.Update({Mapping.Mapper.Map<Offer>(entity).GetType()}): {ex.Message}, \nInner: {ex.InnerException.Message}");
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
                                       .Include(o => o.State)
                                       .Include(o => o.Type)
                                       .Include(o => o.Result)
                                       .Include(o => o.Project)
                                       .ThenInclude(p => p.Client)
                                       .FirstOrDefaultAsync(o => o.Id == id);

            return Mapping.Mapper.Map<Offer, OfferDto>(offer);
        }
    }

    public async Task<ICollection<OfferDto>> GetAll(int projectId = 0, int stateId = 0, int typeId = 0, int resultId = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var offers = await _context.Set<Offer>()
                                       .Where(r => !r.IsDeleted)
                                       .Where(o => (projectId == 0 || o.ProjectId == projectId)
                                                && (stateId == 0 || o.StateId == stateId)
                                                && (typeId == 0 || o.TypeId == typeId)
                                                && (resultId == 0 || o.ResultId == resultId)
                                             )
                                       .Include(o => o.State)
                                       .Include(o => o.Type)
                                       .Include(o => o.Result)
                                       .Include(o => o.Project)
                                       .ThenInclude(p => p.Client)
                                       .ToListAsync();

            return Mapping.Mapper.Map<List<Offer>, List<OfferDto>>(offers);
        }
    }
}
