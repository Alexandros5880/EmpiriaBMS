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
public class ProjectsRepo : Repository<Project>, IDisposable
{
    private bool disposedValue;

    public new async Task<Project?> Get(string id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));

        return await _context
                         .Set<Project>()
                         .Include(r => r.Employees)
                         .FirstOrDefaultAsync(r => r.Id == id);
    }

    public new async Task<ICollection<Project>> GetAll() =>
        await _context.Set<Project>()
                        .Include(r => r.Employees)
                        .ToListAsync();

    public new async Task<ICollection<Project>> GetAll(Expression<Func<Project, bool>> expresion) =>
        await _context.Set<Project>()
                        .Where(expresion)
                        .Include(r => r.Employees)
                        .ToListAsync();

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
