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

public class DrawRepo : Repository<Draw>, IDisposable
{
    public DrawRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public new async Task<Draw?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        var _context = _dbContextFactory.CreateDbContext();
        return await _context
                         .Set<Draw>()
                         .Include(r => r.Discipline)
                         .FirstOrDefaultAsync(r => r.Id == id);
    }

    public new async Task<ICollection<Draw>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        var _context = _dbContextFactory.CreateDbContext();
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<Draw>()
                                 .Include(r => r.Discipline)
                                 .ToListAsync();

        return await _context.Set<Draw>()
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .Include(r => r.Discipline)
                             .ToListAsync();
    }

    public new async Task<ICollection<Draw>> GetAll(
        Expression<Func<Draw, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    )
    {
        var _context = _dbContextFactory.CreateDbContext();
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<Draw>().Where(expresion).ToListAsync();

        return await _context.Set<Draw>()
                             .Where(expresion)
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .Include(r => r.Discipline)
                             .ToListAsync();
    }
}