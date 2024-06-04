using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpiriaBMS.Core.Repositories;

public class LedRepo : Repository<LedDto, Led>, IDisposable
{
    public LedRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public async Task<LedDto> Add(LedDto entity, bool update = false)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.CreatedDate = update ? DateTime.Now.ToUniversalTime() : entity.CreatedDate;
            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            entity.Offer = null;
            entity.Client = null;
            entity.Address = null;

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var led = Mapping.Mapper.Map<Led>(entity);
                var result = await _context.Set<Led>().AddAsync(led);
                await _context.SaveChangesAsync();

                return Mapping.Mapper.Map<LedDto>(result.Entity);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception On LedRepo.Add(LedDto): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return null;
        }
    }

    public async Task<LedDto> Update(LedDto entity)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            entity.Offer = null;
            entity.Client = null;
            entity.Address = null;

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var entry = await _context.Set<Led>().FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (entry != null)
                {
                    var led = Mapping.Mapper.Map<Led>(entity);
                    _context.Entry(entry).CurrentValues.SetValues(led);
                    await _context.SaveChangesAsync();
                }

                return Mapping.Mapper.Map<LedDto>(entry);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception On LedRepo.Update(LedDto): {ex.Message}, \nInner: {ex.InnerException.Message}");
            return null;
        }
    }

    public async Task<LedDto?> Get(int id)
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
                             .Include(l => l.Offer)
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
                                       .Include(l => l.Offer)
                                       .ToListAsync();
                return Mapping.Mapper.Map<List<LedDto>>(items);
            }

            items = await _context.Set<Led>()
                                  .Where(r => !r.IsDeleted)
                                  .Skip((pageIndex - 1) * pageSize)
                                  .Take(pageSize)
                                  .Include(l => l.Address)
                                  .Include(l => l.Client)
                                  .Include(l => l.Offer)
                                  .ToListAsync();

            return Mapping.Mapper.Map<List<LedDto>>(items);
        }
    }

}
