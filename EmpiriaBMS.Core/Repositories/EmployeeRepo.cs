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
public class EmployeeRepo : Repository<Employee>
{

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

    public new async Task<ICollection<Employee>> GetAll(Expression<Func<Employee, bool>> expresion)
    {
        if (expresion == null)
            throw new ArgumentNullException(nameof(expresion));

        return await _context.Set<Employee>()
                        .Where(expresion)
                        .Include(r => r.Projects)
                        .Include(r => r.Roles)
                        .ToListAsync();
    }

}
