using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaMS.Models.Models;
using EmpiriaMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Core.Repositories;

public class DisciplineRepo : Repository<Discipline>, IDisposable
{
    public DisciplineRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public new async Task<Discipline?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        var _context = _dbContextFactory.CreateDbContext();
        return await _context
                         .Set<Discipline>()
                         .Include(r => r.Project)
                         .Include(r => r.ProjectManager)
                         .Include(r => r.Draws)
                         .Include(r => r.Docs)
                         .Include(r => r.Engineers)
                         .Include(r => r.DisciplineEngineers)
                         .FirstOrDefaultAsync(r => r.Id == id);
    }

    public new async Task<ICollection<Discipline>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        var _context = _dbContextFactory.CreateDbContext();
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<Discipline>()
                                 .Include(r => r.Project)
                                 .Include(r => r.ProjectManager)
                                 .Include(r => r.Draws)
                                 .Include(r => r.Docs)
                                 .Include(r => r.Engineers)
                                 .Include(r => r.DisciplineEngineers)
                                 .ToListAsync();

        return await _context.Set<Discipline>()
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .Include(r => r.Project)
                             .Include(r => r.ProjectManager)
                             .Include(r => r.Draws)
                             .Include(r => r.Docs)
                             .Include(r => r.Engineers)
                             .Include(r => r.DisciplineEngineers)
                             .ToListAsync();
    }

    public new async Task<ICollection<Discipline>> GetAll(
        Expression<Func<Discipline, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    )
    {
        var _context = _dbContextFactory.CreateDbContext();
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<Discipline>().Where(expresion).ToListAsync();

        return await _context.Set<Discipline>()
                             .Where(expresion)
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .Include(r => r.Project)
                             .Include(r => r.ProjectManager)
                             .Include(r => r.Draws)
                             .Include(r => r.Docs)
                             .Include(r => r.Engineers)
                             .Include(r => r.DisciplineEngineers)
                             .ToListAsync();
    }
}

