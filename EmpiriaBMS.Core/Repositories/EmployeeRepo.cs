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
public class EmployeeRepo : Repository<Employee>, IDisposable
{
    private bool disposedValue;

    public new async Task<Employee?> Get(string id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));

        return await _context
                         .Set<Employee>()
                         .Include(r => r.Projects)
                         .Include(r => r.Roles)
                         .FirstOrDefaultAsync(r => r.Id == id);
    }

    public new async Task<ICollection<Employee>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<Employee>().ToListAsync();

        return await _context.Set<Employee>()
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .Include(r => r.Projects)
                             .Include(r => r.Roles)
                             .ToListAsync();
    }

    public new async Task<ICollection<Employee>> GetAll(
        Expression<Func<Employee, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<Employee>().Where(expresion).ToListAsync();

        return await _context.Set<Employee>()
                             .Where(expresion)
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .Include(r => r.Projects)
                             .Include(r => r.Roles)
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
