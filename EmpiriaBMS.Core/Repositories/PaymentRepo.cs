using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmpiriaBMS.Core.Repositories;

public class PaymentRepo : Repository<PaymentDto, Payment>, IDisposable
{
    public PaymentRepo(
        IDbContextFactory<AppDbContext> DbFactory,
        Logging.LoggerManager logger
    ) : base(DbFactory, logger) { }

    public async new Task<PaymentDto> Add(PaymentDto entity, bool update = false)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.CreatedDate = update ? DateTime.Now.ToUniversalTime() : entity.CreatedDate;
            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var entry = Mapping.Mapper.Map<Payment>(entity);
                var result = await _context.Set<Payment>().AddAsync(entry);
                await _context.SaveChangesAsync();

                var id = result.Entity?.Id;
                if (id == null)
                    throw new NullReferenceException(nameof(id));

                var endry = await Get((int)id);

                return Mapping.Mapper.Map<PaymentDto>(endry);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On PaymentRepo.Add(Payment): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return default(PaymentDto)!;
        }
    }

    public new async Task<PaymentDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var i = await _context
                             .Set<Payment>()
                             .Where(r => !r.IsDeleted)
                             .Include(r => r.Invoice)
                             .ThenInclude(i => i.Type)
                             .Include(r => r.Invoice)
                             .ThenInclude(i => i.Project)
                             .Include(r => r.Type)
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
                                  .Where(r => !r.IsDeleted)
                                  .Include(r => r.Invoice)
                                  .ThenInclude(i => i.Type)
                                  .Include(r => r.Invoice)
                                  .ThenInclude(i => i.Project)
                                  .Include(r => r.Type)
                                  .ToListAsync();

                return Mapping.Mapper.Map<List<Payment>, List<PaymentDto>>(i);
            }

            i = await _context.Set<Payment>()
                              .Where(r => !r.IsDeleted)
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
    )
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Payment> i;

            if (pageSize == 0 || pageIndex == 0)
            {
                i = await _context.Set<Payment>()
                                  .Where(r => !r.IsDeleted)
                                  .Where(expresion)
                                  .Include(r => r.Invoice)
                                  .ThenInclude(i => i.Type)
                                  .Include(r => r.Invoice)
                                  .ThenInclude(i => i.Project)
                                  .Include(r => r.Type)
                                  .ToListAsync();

                return Mapping.Mapper.Map<List<Payment>, List<PaymentDto>>(i);
            }

            i = await _context.Set<Payment>()
                              .Where(r => !r.IsDeleted)
                              .Where(expresion)
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

    public async Task<ICollection<PaymentDto>> GetAllByInvoice(int invoiceId)
    {
        if (invoiceId == 0)
            throw new ArgumentNullException(nameof(invoiceId));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Payment> i = await _context.Set<Payment>()
                              .Where(r => !r.IsDeleted)
                              .Where(r => r.InvoiceId == invoiceId)
                              .Include(r => r.Invoice)
                              .ThenInclude(i => i.Type)
                              .Include(r => r.Invoice)
                              .ThenInclude(i => i.Project)
                              .Include(r => r.Type)
                              .ToListAsync();

            return Mapping.Mapper.Map<List<Payment>, List<PaymentDto>>(i);
        }
    }

    public async Task<ICollection<PaymentDto>> GetAllByInvoices(int[] invoiceIds)
    {
        if (invoiceIds.Length == 0)
            throw new ArgumentException(nameof(invoiceIds));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Payment> i = await _context.Set<Payment>()
                              .Where(r => !r.IsDeleted)
                              .Where(r => invoiceIds.Contains(r.InvoiceId))
                              .Include(r => r.Invoice)
                              .ThenInclude(i => i.Type)
                              .Include(r => r.Invoice)
                              .ThenInclude(i => i.Project)
                              .Include(r => r.Type)
                              .ToListAsync();

            return Mapping.Mapper.Map<List<Payment>, List<PaymentDto>>(i);
        }
    }
}
