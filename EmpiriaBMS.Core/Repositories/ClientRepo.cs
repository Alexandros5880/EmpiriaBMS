using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpiriaBMS.Core.Repositories;

public class ClientRepo : Repository<ClientDto, Client>
{
    public ClientRepo(
        IDbContextFactory<AppDbContext> DbFactory,
        Logging.LoggerManager logger
    ) : base(DbFactory, logger) { }

    public async Task<ClientDto> Add(ClientDto entity, bool update = false)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.CreatedDate = update ? DateTime.Now.ToUniversalTime() : entity.CreatedDate;
            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var entry = Mapping.Mapper.Map<Client>(entity);
                var result = await _context.Set<Client>().AddAsync(entry);
                await _context.SaveChangesAsync();

                var id = result.Entity?.Id;
                if (id == null)
                    throw new NullReferenceException(nameof(id));

                var endry = await Get((int)id);

                return Mapping.Mapper.Map<ClientDto>(endry);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ClientRepo.Add(Client): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return null;
        }
    }

    public async Task<ClientDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var i = await _context
                             .Set<Client>()
                             .Where(r => !r.IsDeleted)
                             .Include(c => c.Address)
                             .FirstOrDefaultAsync(r => r.Id == id);

            return Mapping.Mapper.Map<ClientDto>(i);
        }
    }

    public async Task<ICollection<ClientDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Client> items;
            if (pageSize == 0 || pageIndex == 0)
            {
                items = await _context.Set<Client>()
                                      .Where(r => !r.IsDeleted)
                                      .Include(c => c.Address)
                                      .ToListAsync();
                return Mapping.Mapper.Map<List<ClientDto>>(items);
            }

            items = await _context.Set<Client>()
                                  .Where(r => !r.IsDeleted)
                                  .Include(c => c.Address)
                                  .Skip((pageIndex - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToListAsync();

            return Mapping.Mapper.Map<List<ClientDto>>(items);
        }
    }

    public async Task<ICollection<Email>> GetEmails(int userId)
    {
        if (userId == 0)
            return new List<Email>();

        using (var _context = _dbContextFactory.CreateDbContext())
            return await _context.Set<Email>()
                                 .Where(r => !r.IsDeleted)
                                 .Where(r => r.UserId == userId)
                                 .ToListAsync();
    }
}
