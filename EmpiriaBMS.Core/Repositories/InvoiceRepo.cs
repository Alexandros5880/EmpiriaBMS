using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaMS.Models;
using EmpiriaMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Repositories;
public class InvoiceRepo : Repository<Invoice>, IDisposable
{
    public InvoiceRepo(AppDbContext context) : base(context) { }

    public new async Task<Invoice?> Get(string id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));

        return await _context
                         .Set<Invoice>()
                         .Include(r => r.Project)
                         .FirstOrDefaultAsync(r => r.Id.Equals(id));
    }

    public new async Task<ICollection<Invoice>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<Invoice>().ToListAsync();

        return await _context.Set<Invoice>()
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .ToListAsync();
    }

    public new async Task<ICollection<Invoice>> GetAll(
        Expression<Func<Invoice, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<Invoice>().Where(expresion).ToListAsync();

        return await _context.Set<Invoice>()
                             .Where(expresion)
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .ToListAsync();
    }

    public async Task<Invoice> Update(Invoice entity)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();


            var entry = await _context.Set<Invoice>().FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (entry != null)
            {
                _context.Entry(entry.Project).CurrentValues.SetValues(entity.Project);
                _context.Entry(entry).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }

            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(
                $"Exception On InvoiceRepo.Update({entity.GetType()}): " +
                $"{ex.Message}\n ex.InnerException.Message: {ex.InnerException?.Message}"
            );
            return null;
        }
    }
}
