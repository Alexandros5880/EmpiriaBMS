using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpiriaBMS.Core.Repositories;

public class ContractRepo : Repository<ContractDto, Contract>
{
    public ContractRepo(
        IDbContextFactory<AppDbContext> DbFactory,
        Logging.LoggerManager logger
    ) : base(DbFactory, logger) { }

    public async Task<ContractDto> Add(ContractDto entity, bool update = false)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.CreatedDate = update ? DateTime.Now.ToUniversalTime() : entity.CreatedDate;
            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var result = await _context.Set<Contract>().AddAsync(Mapping.Mapper.Map<Contract>(entity));
                await _context.SaveChangesAsync();

                if (result.Entity?.Id == null || result.Entity.Id == 0)
                    throw new NullReferenceException(nameof(result.Entity));

                var Contract = await Get(result.Entity.Id);

                if (Contract == null)
                    throw new NullReferenceException(nameof(Contract));

                return Mapping.Mapper.Map<ContractDto>(Contract);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception On Repository.Add({typeof(Contract)}): {ex.Message}, \nInner: {ex.InnerException.Message}");
            return null;
        }
    }

    public async Task<ContractDto> Update(ContractDto entity)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var entry = await _context.Set<Contract>().FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (entry != null)
                {
                    _context.Entry(entry).CurrentValues.SetValues(Mapping.Mapper.Map<Contract>(entity));
                    await _context.SaveChangesAsync();
                }

                var Contract = await Get(entity.Id);

                if (Contract == null)
                    throw new NullReferenceException(nameof(Contract));

                return Mapping.Mapper.Map<ContractDto>(Contract);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception On Repository.Update({typeof(Contract)}): {ex.Message}, \nInner: {ex.InnerException.Message}");
            return null;
        }
    }

    public async Task<ContractDto?> Get(int id)
    {
        try
        {
            if (id == 0)
                throw new ArgumentNullException(nameof(id));

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var invoices = await _context.Set<Invoice>().Include(i => i.Project).ToListAsync();

                var i = await _context
                                 .Set<Contract>()
                                 .Where(r => !r.IsDeleted)
                                 .Include(c => c.Invoice)
                                 .ThenInclude(i => i.Project)
                                 //.Select((c) => _fillInvoice(c, invoices))
                                 .FirstOrDefaultAsync(r => r.Id == id);

                return Mapping.Mapper.Map<ContractDto>(i);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception On Repository.Get({typeof(Contract)}): {ex.Message}, \nInner: {ex.InnerException.Message}");
            return null;
        }
    }

    public async Task<ICollection<ContractDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var invoices = await _context.Set<Invoice>().Include(i => i.Project).ToListAsync();

            List<Contract> items;
            if (pageSize == 0 || pageIndex == 0)
            {
                items = await _context.Set<Contract>()
                                      .Where(r => !r.IsDeleted)
                                      .Include(c => c.Invoice)
                                      .ThenInclude(i => i.Project)
                                      .Select((c) => _fillInvoice(c, invoices))
                                      .ToListAsync();

                return Mapping.Mapper.Map<List<Contract>, List<ContractDto>>(items);
            }

            items = await _context.Set<Contract>()
                                  .Where(r => !r.IsDeleted)
                                  .Include(c => c.Invoice)
                                  .ThenInclude(i => i.Project)
                                  .Select((c) => _fillInvoice(c, invoices))
                                  .Skip((pageIndex - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToListAsync();

            return Mapping.Mapper.Map<List<Contract>, List<ContractDto>>(items);
        }
    }

    private static Contract _fillInvoice(Contract c, List<Invoice> invoices)
    {
        if (c.Invoice == null)
            c.Invoice = invoices.FirstOrDefault(i => i.Id == c.InvoiceId);
        return c;
    }
}
