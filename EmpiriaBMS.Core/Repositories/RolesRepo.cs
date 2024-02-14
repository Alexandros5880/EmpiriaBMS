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
public class RolesRepo : Repository<Role>
{
    public RolesRepo(AppDbContext context) : base(context) { }

    public new async Task<Role?> Get(string id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));

        return await _context
                         .Set<Role>()
                         .Include(r => r.Employees)
                         .FirstOrDefaultAsync(r => r.Id.Equals(id));
    }

    public new async Task<ICollection<Role>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<Role>().ToListAsync();

        return await _context.Set<Role>()
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .Include(r => r.Employees)
                             .ToListAsync();
    }

    public new async Task<ICollection<Role>> GetAll(
        Expression<Func<Role, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<Role>().Where(expresion).ToListAsync();

        return await _context.Set<Role>()
                             .Where(expresion)
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .Include(r => r.Employees)
                             .ToListAsync();
    }
}
