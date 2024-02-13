using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Repositories;
public class CastomerRepo : Repository<Customer>, IDisposable
{
    private bool disposedValue;

    public new async Task<Customer?> Get(string id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));

        return await _context
                         .Set<Customer>()
                         .Include(r => r.Projects)
                         .FirstOrDefaultAsync(r => r.Id == id);
    }

    public new async Task<ICollection<Customer>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<Customer>().ToListAsync();

        return await _context.Set<Customer>()
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .Include(r => r.Projects)
                             .ToListAsync();
    }


    public new async Task<ICollection<Customer>> GetAll(
        Expression<Func<Customer, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<Customer>().Where(expresion).ToListAsync();

        return await _context.Set<Customer>()
                             .Where(expresion)
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .Include(r => r.Projects)
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
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
