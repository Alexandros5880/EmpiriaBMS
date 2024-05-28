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

public class LedRepo : Repository<LedDto, Led>, IDisposable
{
    public LedRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

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
