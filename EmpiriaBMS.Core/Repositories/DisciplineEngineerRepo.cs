using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Repositories;

public class DisciplineEngineerRepo : Repository<DisciplineEngineer>, IDisposable
{
    public DisciplineEngineerRepo(IDbContextFactory<AppDbContext> dbFactory) : base(dbFactory) { }

    public new async Task<DisciplineEngineer?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        var _context = _dbContextFactory.CreateDbContext();
        return await _context
                         .Set<DisciplineEngineer>()
                         .Include(r => r.Discipline)
                         .Include(r => r.Engineer)
                         .FirstOrDefaultAsync(r => r.Id == id);
    }

    public new async Task<ICollection<DisciplineEngineer>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        var _context = _dbContextFactory.CreateDbContext();
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<DisciplineEngineer>()
                                 .ToListAsync();

        return await _context.Set<DisciplineEngineer>()
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .Include(r => r.Discipline)
                             .Include(r => r.Engineer)
                             .ToListAsync();
    }

    public new async Task<ICollection<DisciplineEngineer>> GetAll(
        Expression<Func<DisciplineEngineer, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    )
    {
        var _context = _dbContextFactory.CreateDbContext();
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<DisciplineEngineer>().Where(expresion).ToListAsync();

        return await _context.Set<DisciplineEngineer>()
                             .Where(expresion)
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .Include(r => r.Discipline)
                             .Include(r => r.Engineer)
                             .ToListAsync();
    }
}
