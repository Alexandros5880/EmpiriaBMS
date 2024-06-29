using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpiriaBMS.Core.Repositories;

public class AddressRepo : Repository<AddressDto, Address>
{
    public AddressRepo(
        IDbContextFactory<AppDbContext> DbFactory,
        Logging.LoggerManager logger
    ) : base(DbFactory, logger) { }

    public async Task<AddressDto> GetByPlaceId(string placeId)
    {
        if (string.IsNullOrEmpty(placeId))
            throw new ArgumentNullException(nameof(placeId));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var i = await _context.Set<Address>()
                                  .Where(r => !r.IsDeleted)
                                  .FirstOrDefaultAsync(r => r.PlaceId == placeId);

            return Mapping.Mapper.Map<AddressDto>(i);
        }
    }
}
