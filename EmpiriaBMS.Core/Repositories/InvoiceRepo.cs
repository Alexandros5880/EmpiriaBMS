using EmpiriaBMS.Core.Repositories.Base;
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
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Core.Repositories;
public class InvoiceRepo : Repository<InvoiceDto, Invoice>, IDisposable
{
    public InvoiceRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public new async Task<InvoiceDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var i = await _context
                             .Set<Invoice>()
                             .Include(r => r.Project)
                             .FirstOrDefaultAsync(r => r.Id == id);

            return Mapping.Mapper.Map<InvoiceDto>(i);
        }
    }

    public new async Task<ICollection<InvoiceDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Invoice> i;

            if (pageSize == 0 || pageIndex == 0)
            {
                i = await _context.Set<Invoice>()
                                  .Include(r => r.Project)
                                  .ToListAsync();

                return Mapping.Mapper.Map<List<Invoice>, List<InvoiceDto>>(i);
            }

            i = await _context.Set<Invoice>()
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .Include(r => r.Project)
                                 .ToListAsync();

            return Mapping.Mapper.Map<List<Invoice>, List<InvoiceDto>>(i);
        } 
    }

    public new async Task<ICollection<InvoiceDto>> GetAll(
        Expression<Func<Invoice, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Invoice> i;

            if (pageSize == 0 || pageIndex == 0)
            {
                i = await _context.Set<Invoice>()
                                  .Where(expresion)
                                  .Include(r => r.Project)
                                  .ToListAsync();

                return Mapping.Mapper.Map<List<Invoice>, List<InvoiceDto>>(i);
            }

            i = await _context.Set<Invoice>()
                              .Where(expresion)
                              .Skip((pageIndex - 1) * pageSize)
                              .Take(pageSize)
                              .Include(r => r.Project)
                              .ToListAsync();

            return Mapping.Mapper.Map<List<Invoice>, List<InvoiceDto>>(i);
        }
    }
}
