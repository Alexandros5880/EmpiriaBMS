using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpiriaBMS.Core.Repositories;

public class TeamsRequestedUserRepo : Repository<TeamsRequestedUserDto, TeamsRequestedUser>
{
    public TeamsRequestedUserRepo(
        IDbContextFactory<AppDbContext> DbFactory,
        Logging.LoggerManager logger
    ) : base(DbFactory, logger) { }

    public async new Task<ICollection<TeamsRequestedUserDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            IQueryable<TeamsRequestedUser> query = _context
                .Set<TeamsRequestedUser>()
                .Where(r => !r.IsDeleted);

            if (pageSize != 0 && pageIndex != 0)
            {
                query = query.Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize);
            }

            var items = await query.ToListAsync();

            return Mapping.Mapper.Map<List<TeamsRequestedUserDto>>(items);
        }
    }

    public async new Task<int> Count()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context
                .Set<TeamsRequestedUser>().CountAsync();
        }
    }

    public async Task<TeamsRequestedUserDto> GetByObjectId(string objectId)
    {
        if (objectId == null)
            throw new ArgumentNullException(nameof(objectId));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var record = await _context.Set<TeamsRequestedUser>()
                                        .Where(r => !r.IsDeleted)
                                        .FirstOrDefaultAsync(t => t.ObjectId.Equals(objectId));
            var dto = Mapping.Mapper.Map<TeamsRequestedUserDto>(record);
            return dto;
        }
    }

    public async Task<TeamsRequestedUserDto> DeleteByObjectId(string objectId)
    {
        if (objectId == null)
            throw new ArgumentNullException(nameof(objectId));

        var entity = await GetByObjectId(objectId);

        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            entity.IsDeleted = true;
            await Update(entity);

            //_context.Set<U>().Remove(Mapping.Mapper.Map<U>(entity));
            //await _context.SaveChangesAsync();
        }

        return entity;
    }
}
