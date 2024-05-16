using EmpiriaBMS.Core.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Core.Repositories;
public class InvoiceRepo : Repository<InvoiceDto, Invoice>
{
    public InvoiceRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public new async Task<InvoiceDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var i = await _context
                             .Set<Invoice>()
                             .Where(r => !r.IsDeleted)
                             .Include(i => i.Payments)
                             .Include(i => i.Type)
                             .Include(i => i.Contract)
                             .Include(i => i.Project)
                             .FirstOrDefaultAsync(r => r.Id == id);

            return Mapping.Mapper.Map<InvoiceDto>(i);
        }
    }

    public new async Task<ICollection<InvoiceDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Invoice> i;

            if (pageSize == 0 || pageIndex == 0)
            {
                i = await _context.Set<Invoice>()
                                  .Where(r => !r.IsDeleted)
                                  .Include(i => i.Payments)
                                         .Include(i => i.Type)
                                         .Include(i => i.Contract)
                                         .Include(i => i.Project)
                                  .ToListAsync();

                return Mapping.Mapper.Map<List<Invoice>, List<InvoiceDto>>(i);
            }

            i = await _context.Set<Invoice>()
                              .Where(r => !r.IsDeleted)
                              .Skip((pageIndex - 1) * pageSize)
                              .Take(pageSize)
                              .Include(i => i.Payments)
                                         .Include(i => i.Type)
                                         .Include(i => i.Contract)
                                         .Include(i => i.Project)
                              .ToListAsync();

            return Mapping.Mapper.Map<List<Invoice>, List<InvoiceDto>>(i);
        } 
    }

    public new async Task<ICollection<InvoiceDto>> GetAll(
        Expression<Func<Invoice, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Invoice> i;

            if (pageSize == 0 || pageIndex == 0)
            {
                i = await _context.Set<Invoice>()
                                  .Where(r => !r.IsDeleted)
                                  .Where(expresion)
                                  .Include(i => i.Payments)
                                  .Include(i => i.Type)
                                  .Include(i => i.Contract)
                                  .Include(i => i.Project)
                                  .ToListAsync();

                return Mapping.Mapper.Map<List<Invoice>, List<InvoiceDto>>(i);
            }

            i = await _context.Set<Invoice>()
                              .Where(r => !r.IsDeleted)
                              .Where(expresion)
                              .Skip((pageIndex - 1) * pageSize)
                              .Take(pageSize)
                              .Include(i => i.Payments)
                              .Include(i => i.Type)
                              .Include(i => i.Contract)
                              .Include(i => i.Project)
                              .ToListAsync();

            return Mapping.Mapper.Map<List<Invoice>, List<InvoiceDto>>(i);
        }
    }

    public async Task<ICollection<PaymentDto>> GetProjectsPayments(int projectId)
    {
        if (projectId == 0)
            throw new ArgumentNullException(nameof(projectId));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var projectsInvoice = await _context.Set<Invoice>()
                                                .Where(r => !r.IsDeleted)
                                                .Where(i => i.ProjectId == projectId)
                                                .Select(i => i.Id)
                                                .ToListAsync();

            var payments = await _context.Set<Payment>()
                                         .Where(r => !r.IsDeleted)
                                         .Where(p => projectsInvoice.Contains(p.InvoiceId))
                                         .ToListAsync();

            var dtos = Mapping.Mapper.Map<List<PaymentDto>>(payments);
            return dtos;
        }
    }
}
