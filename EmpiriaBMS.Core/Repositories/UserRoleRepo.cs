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

public class UserRoleRepo : Repository<UserRole>, IDisposable
{
    public UserRoleRepo(IDbContextFactory<AppDbContext> dbFactory) : base(dbFactory) { }

    public new async Task<UserRole?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        var _context = _dbContextFactory.CreateDbContext();
        return await _context
                         .Set<UserRole>()
                         .Include(r => r.Role)
                         .Include(r => r.User)
                         .FirstOrDefaultAsync(r => r.Id == id);
    }

    public new async Task<ICollection<UserRole>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        var _context = _dbContextFactory.CreateDbContext();
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<UserRole>()
                                 .ToListAsync();

        return await _context.Set<UserRole>()
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .Include(r => r.Role)
                             .Include(r => r.User)
                             .ToListAsync();
    }

    public new async Task<ICollection<UserRole>> GetAll(
        Expression<Func<UserRole, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    )
    {
        var _context = _dbContextFactory.CreateDbContext();
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<UserRole>().Where(expresion).ToListAsync();

        return await _context.Set<UserRole>()
                             .Where(expresion)
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .Include(r => r.Role)
                             .Include(r => r.User)
                             .ToListAsync();
    }
}
