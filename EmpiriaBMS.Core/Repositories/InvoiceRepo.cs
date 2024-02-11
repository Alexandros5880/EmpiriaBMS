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
public class InvoiceRepo : Repository<Invoice>
{

    public new async Task<Invoice?> Get(string id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));

        return await _context
                         .Set<Invoice>()
                         .Include(r => r.Project)
                         .FirstOrDefaultAsync(r => r.Id == id);
    }

    public new async Task<ICollection<Invoice>> GetAll(Expression<Func<Invoice, bool>> expresion)
    {
        if (expresion == null)
            throw new ArgumentNullException(nameof(expresion));

        return await _context.Set<Invoice>()
                        .Where(expresion)
                        .Include(r => r.Project)
                        .ToListAsync();
    }

}
