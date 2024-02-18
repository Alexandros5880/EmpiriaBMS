using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaMS.Models;
using EmpiriaMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Config;

namespace EmpiriaBMS.Core.Repositories;
public class InvoiceRepo : Repository<InvoiceDto>, IDisposable
{
    public InvoiceRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public new async Task<InvoiceDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context
                             .Set<Invoice>()
                             .Include(r => r.Project)
                             .Select(r => Mapping.Mapper.Map<InvoiceDto>(r))
                             .FirstOrDefaultAsync(r => r.Id == id);
        }
    }

    public new async Task<ICollection<InvoiceDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (pageSize == 0 || pageIndex == 0)
                return await _context.Set<Invoice>()
                                     .Include(r => r.Project)
                                     .Select(r => Mapping.Mapper.Map<InvoiceDto>(r))
                                     .ToListAsync();

            return await _context.Set<Invoice>()
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .Include(r => r.Project)
                                 .Select(r => Mapping.Mapper.Map<InvoiceDto>(r))
                                 .ToListAsync();
        } 
    }

    public new async Task<ICollection<InvoiceDto>> GetAll(
        Expression<Func<InvoiceDto, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (pageSize == 0 || pageIndex == 0)
                return await _context.Set<Invoice>()
                                     .Select(r => Mapping.Mapper.Map<InvoiceDto>(r))
                                     .Where(expresion).ToListAsync();

            return await _context.Set<Invoice>()
                                 .Include(r => r.Project)
                                 .Select(r => Mapping.Mapper.Map<InvoiceDto>(r))
                                 .Where(expresion)
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }
    }
}
