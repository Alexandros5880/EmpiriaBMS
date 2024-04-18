using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Repositories;

public class OfferRepo : Repository<OfferDto, Offer>
{
    public OfferRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public async Task<ICollection<OfferDto>> GetAll(int projectId = 0, int stateId = 0, int typeId = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var offers = await _context.Set<Offer>()
                                         .Where(o => projectId == 0 || o.ProjectId == stateId)
                                         .Where(o => stateId == 0 || o.StateId == stateId)
                                         .Where(o => typeId == 0 || o.TypeId == stateId)
                                         .Include(o => o.State)
                                         .Include(o => o.Type)
                                         .ToListAsync();

            return Mapping.Mapper.Map<List<Offer>, List<OfferDto>>(offers);
        }
    }
}
