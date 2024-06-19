using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Contract = EmpiriaBMS.Models.Models.Contract;

namespace EmpiriaBMS.Core.Repositories;
public class InvoiceRepo : Repository<InvoiceDto, Invoice>
{
    public InvoiceRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory)
    {

    }

    public async Task<InvoiceDto> Add(InvoiceDto entity, bool update = false)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.CreatedDate = update ? DateTime.Now.ToUniversalTime() : entity.CreatedDate;
            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var result = await _context.Set<Invoice>().AddAsync(Mapping.Mapper.Map<Invoice>(entity));
                await _context.SaveChangesAsync();

                var invoice = await Get(result.Entity.Id);

                if (invoice == null)
                    throw new NullReferenceException(nameof(invoice));

                return Mapping.Mapper.Map<InvoiceDto>(invoice);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception On Repository.Add({typeof(Invoice)}): {ex.Message}, \nInner: {ex.InnerException.Message}");
            return null;
        }
    }

    public async Task<InvoiceDto> Update(InvoiceDto entity)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var entry = await _context.Set<Invoice>().FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (entry != null)
                {
                    _context.Entry(entry).CurrentValues.SetValues(Mapping.Mapper.Map<Invoice>(entity));
                    await _context.SaveChangesAsync();
                }

                var invoice = await Get(entity.Id);

                if (invoice == null)
                    throw new NullReferenceException(nameof(invoice));

                return Mapping.Mapper.Map<InvoiceDto>(invoice);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception On Repository.Update({typeof(Invoice)}): {ex.Message}, \nInner: {ex.InnerException.Message}");
            return null;
        }
    }

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
            var contracts = await _context.Set<Contract>().Where(c => !c.IsDeleted).ToListAsync();

            if (pageSize == 0 || pageIndex == 0)
            {
                i = await _context.Set<Invoice>()
                                  .Where(r => !r.IsDeleted)
                                  .Include(i => i.Payments)
                                  .Include(i => i.Type)
                                  .Include(i => i.Project)
                                  .ThenInclude(p => p.ProjectManager)
                                  .Select(i => _includeContract(i, ref contracts))
                                  .ToListAsync();

                return Mapping.Mapper.Map<List<Invoice>, List<InvoiceDto>>(i);
            }

            i = await _context.Set<Invoice>()
                              .Where(r => !r.IsDeleted)
                              .Skip((pageIndex - 1) * pageSize)
                              .Take(pageSize)
                              .Include(i => i.Payments)
                              .Include(i => i.Type)
                              .Include(i => i.Project)
                              .ThenInclude(p => p.ProjectManager)
                              .Select(i => _includeContract(i, ref contracts))
                              .ToListAsync();

            return Mapping.Mapper.Map<List<Invoice>, List<InvoiceDto>>(i);
        }
    }

    public async Task<ICollection<InvoiceDto>> GetAllByProject(int projectId = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var contracts = await _context.Set<Contract>().Where(c => !c.IsDeleted).ToListAsync();

            List<Invoice> i = await _context.Set<Invoice>()
                                 .Where(r => !r.IsDeleted)
                                 .Where(r => projectId == 0 || r.ProjectId == projectId)
                                 .Include(i => i.Payments)
                                 .Include(i => i.Type)
                                 .Include(i => i.Project)
                                 .ThenInclude(p => p.ProjectManager)
                                 .Select(i => _includeContract(i, ref contracts))
                                 .ToListAsync();


            return Mapping.Mapper.Map<List<Invoice>, List<InvoiceDto>>(i);
        }
    }

    private static Invoice _includeContract(Invoice invoice, ref List<Contract> contracts)
    {
        invoice.Contract = contracts.FirstOrDefault(c => c.InvoiceId == invoice.Id);
        return invoice;
    }

    public new async Task<ICollection<InvoiceDto>> GetAll(
        Expression<Func<Invoice, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    )
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Invoice> i;
            var contracts = await _context.Set<Contract>().Where(c => !c.IsDeleted).ToListAsync();

            if (pageSize == 0 || pageIndex == 0)
            {
                i = await _context.Set<Invoice>()
                                  .Where(r => !r.IsDeleted)
                                  .Where(expresion)
                                  .Include(i => i.Payments)
                                  .Include(i => i.Type)
                                  .Include(i => i.Project)
                                  .ThenInclude(p => p.ProjectManager)
                                  .Select(i => _includeContract(i, ref contracts))
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
                              .Include(i => i.Project)
                              .ThenInclude(p => p.ProjectManager)
                              .Select(i => _includeContract(i, ref contracts))
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

    public new async Task<ContractDto> GetContract(int invoiceId)
    {
        if (invoiceId == 0)
            throw new ArgumentNullException(nameof(invoiceId));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var c = await _context
                             .Set<Contract>()
                             .Where(r => !r.IsDeleted)
                             .FirstOrDefaultAsync(c => c.InvoiceId == invoiceId);

            return Mapping.Mapper.Map<ContractDto>(c);
        }
    }

    public async Task<double> GetSumOfPaymentsFee(int invoiceId)
    {
        try
        {
            if (invoiceId == 0)
                throw new ArgumentNullException(nameof(invoiceId));

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var sum = await _context
                                .Set<Payment>()
                                .Where(r => !r.IsDeleted && r.InvoiceId == invoiceId)
                                .SumAsync(p => p.Fee);

                return sum;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception On InvoiceRepo.GetSumOfPaymentsFee({typeof(Invoice)}): {ex.Message}, \nInner: {ex.InnerException.Message}");
            return 0;
        }
    }

    public async Task<bool> IsClosed(int invoiceId)
    {
        try
        {
            if (invoiceId == 0)
                throw new ArgumentNullException(nameof(invoiceId));

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var invoice = await _context.Set<Invoice>()
                                            .Where(r => !r.IsDeleted)
                                            .FirstOrDefaultAsync(i => i.Id == invoiceId);

                if (invoice == null)
                    throw new NullReferenceException(nameof(invoice));

                var sum = await _context
                                .Set<Payment>()
                                .Where(r => !r.IsDeleted && r.InvoiceId == invoiceId)
                                .SumAsync(p => p.Fee);

                return sum >= invoice.Fee;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception On InvoiceRepo.IsClosed({typeof(Invoice)}): {ex.Message}, \nInner: {ex.InnerException.Message}");
            return false;
        }
    }
}
