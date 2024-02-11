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
public class CastomerRepo : Repository<Customer>
{

    public new async Task<Customer?> Get(string id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));

        return await _context
                         .Set<Customer>()
                         .Include(r => r.Projects)
                         .FirstOrDefaultAsync(r => r.Id == id);
    }

    public new async Task<ICollection<Customer>> GetAll(Expression<Func<Customer, bool>> expresion)
    {
        if (expresion == null)
            throw new ArgumentNullException(nameof(expresion));

        return await _context.Set<Customer>()
                        .Where(expresion)
                        .Include(r => r.Projects)
                        .ToListAsync();
    }

}
