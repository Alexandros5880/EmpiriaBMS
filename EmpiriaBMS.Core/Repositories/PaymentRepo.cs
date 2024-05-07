using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmpiriaBMS.Core.Repositories;

public class PaymentRepo : Repository<PaymentDto, Payment>, IDisposable
{
    public PaymentRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public new async Task<PaymentDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var i = await _context
                             .Set<Payment>()
                             .Include(r => r.Invoice)
                             .ThenInclude(i => i.Type)
                             .Include(r => r.Invoice)
                             .ThenInclude(i => i.Project)
                             .FirstOrDefaultAsync(r => r.Id == id);

            return Mapping.Mapper.Map<PaymentDto>(i);
        }
    }

    public new async Task<ICollection<PaymentDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Payment> i;

            if (pageSize == 0 || pageIndex == 0)
            {
                i = await _context.Set<Payment>()
                                  .Include(r => r.Invoice)
                                  .ThenInclude(i => i.Type)
                                  .Include(r => r.Invoice)
                                  .ThenInclude(i => i.Project)
                                  .Include(r => r.Type)
                                  .ToListAsync();

                return Mapping.Mapper.Map<List<Payment>, List<PaymentDto>>(i);
            }

            i = await _context.Set<Payment>()
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .Include(r => r.Invoice)
                                 .ThenInclude(i => i.Type)
                                 .Include(r => r.Invoice)
                                 .ThenInclude(i => i.Project)
                                 .Include(r => r.Type)
                                 .ToListAsync();

            return Mapping.Mapper.Map<List<Payment>, List<PaymentDto>>(i);
        }
    }

    public new async Task<ICollection<PaymentDto>> GetAll(
        Expression<Func<Payment, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Payment> i;

            if (pageSize == 0 || pageIndex == 0)
            {
                i = await _context.Set<Payment>()
                                  .Where(expresion)
                                  .Include(r => r.Invoice)
                                  .ThenInclude(i => i.Type)
                                  .Include(r => r.Invoice)
                                  .ThenInclude(i => i.Project)
                                  .ToListAsync();

                return Mapping.Mapper.Map<List<Payment>, List<PaymentDto>>(i);
            }

            i = await _context.Set<Payment>()
                              .Where(expresion)
                              .Skip((pageIndex - 1) * pageSize)
                              .Take(pageSize)
                              .Include(r => r.Invoice)
                              .ThenInclude(i => i.Type)
                              .Include(r => r.Invoice)
                              .ThenInclude(i => i.Project)
                              .ToListAsync();

            return Mapping.Mapper.Map<List<Payment>, List<PaymentDto>>(i);
        }
    }
}
