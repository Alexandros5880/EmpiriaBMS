using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaMS.Models;
using EmpiriaMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Repositories;
public class InvoiceRepo : Repository<Invoice>, IDisposable
{
    private bool disposedValue;

    public InvoiceRepo(AppDbContext context) : base(context) { }

    public new async Task<Invoice?> Get(string id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));

        return await _context
                         .Set<Invoice>()
                         .Include(r => r.Project)
                         .FirstOrDefaultAsync(r => r.Id == id);
    }

    public new async Task<ICollection<Invoice>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<Invoice>().ToListAsync();

        return await _context.Set<Invoice>()
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .ToListAsync();
    }

    public new async Task<ICollection<Invoice>> GetAll(
        Expression<Func<Invoice, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<Invoice>().Where(expresion).ToListAsync();

        return await _context.Set<Invoice>()
                             .Where(expresion)
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .ToListAsync();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
