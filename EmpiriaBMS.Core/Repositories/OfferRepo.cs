using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpiriaBMS.Core.Repositories;

public class OfferRepo : Repository<OfferDto, Offer>
{
    public OfferRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public async Task<ICollection<OfferDto>> GetAll(int projectId = 0, int stateId = 0, int typeId = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var offers = await _context.Set<Offer>()
                                       .Where(r => !r.IsDeleted)
                                       .Where(o => (projectId == 0 || o.ProjectId == projectId)
                                                && (stateId == 0 || o.StateId == stateId)
                                                && (typeId == 0 || o.TypeId == typeId)
                                             )
                                       .Include(o => o.State)
                                       .Include(o => o.Type)
                                       .Include(o => o.Project)
                                       .ThenInclude(p => p.Client)
                                       .ToListAsync();

            return Mapping.Mapper.Map<List<Offer>, List<OfferDto>>(offers);
        }
    }
}
