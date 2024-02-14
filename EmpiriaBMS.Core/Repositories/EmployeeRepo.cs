using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
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
public class EmployeeRepo : Repository<User>
{
    public EmployeeRepo(AppDbContext context) : base(context) { }

    public new async Task<User?> Get(string id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));

        return await _context
                         .Set<User>()
                         .Include(r => r.Roles)
                         .Include(r => r.Employees)
                         .FirstOrDefaultAsync(r => r.Id.Equals(id));
    }

    public new async Task<ICollection<User>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<User>().ToListAsync();

        return await _context.Set<User>()
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .Include(r => r.Roles)
                             .Include(r => r.Employees)
                             .ToListAsync();
    }

    public new async Task<ICollection<User>> GetAll(
        Expression<Func<User, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<User>().Where(expresion).ToListAsync();

        return await _context.Set<User>()
                             .Where(expresion)
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .Include(r => r.Roles)
                             .Include(r => r.Employees)
                             .ToListAsync();
    }
}
