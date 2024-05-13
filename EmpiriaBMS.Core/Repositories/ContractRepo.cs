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

public class ContractRepo : Repository<ContractDto, Contract>
{
    public ContractRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public async Task<ICollection<ContractDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Contract> items;
            if (pageSize == 0 || pageIndex == 0)
            {
                items = await _context.Set<Contract>()
                                      .Where(r => !r.IsDeleted)
                                      .Include(c => c.Invoice)
                                      .ThenInclude(i => i.Project)
                                      .ToListAsync();
                return Mapping.Mapper.Map<List<ContractDto>>(items);
            }

            items = await _context.Set<Contract>()
                                  .Where(r => !r.IsDeleted)
                                  .Include(c => c.Invoice)
                                  .ThenInclude(i => i.Project)
                                  .Skip((pageIndex - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToListAsync();

            return Mapping.Mapper.Map<List<ContractDto>>(items);
        }
    }
}
