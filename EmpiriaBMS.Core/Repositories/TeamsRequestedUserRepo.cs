using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Repositories;

public class TeamsRequestedUserRepo : Repository<TeamsRequestedUserDto, TeamsRequestedUser>
{
    public TeamsRequestedUserRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public async Task<TeamsRequestedUserDto> GetByObjectId(string objectId)
    {
        if (objectId == null)
            throw new ArgumentNullException(nameof(objectId));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var record =  await _context.Set<TeamsRequestedUser>()
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
