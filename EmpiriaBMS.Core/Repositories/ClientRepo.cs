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

public class ClientRepo : Repository<ClientDto, Client>
{
    public ClientRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public async Task<ICollection<ClientDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Client> items;
            if (pageSize == 0 || pageIndex == 0)
            {
                items = await _context.Set<Client>()
                                      .ToListAsync();
                return Mapping.Mapper.Map<List<ClientDto>>(items);
            }

            items = await _context.Set<Client>()
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
                                 .Where(r => r.UserId == userId)
                                 .ToListAsync();
    }
}
