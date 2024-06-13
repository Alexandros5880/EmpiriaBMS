using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace EmpiriaBMS.Core.Repositories.Base;
public class Repository<T, U> : IRepository<T, U>, IDisposable
    where T : class, IEntityDto
    where U : class, IEntity
{
    private bool disposedValue;
    protected readonly IDbContextFactory<AppDbContext> _dbContextFactory;

    public Repository(IDbContextFactory<AppDbContext> dbFactory) =>
        _dbContextFactory = dbFactory;

    public async Task<T> Add(T entity, bool update = false)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.CreatedDate = update ? DateTime.Now.ToUniversalTime() : entity.CreatedDate;
            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var entry = Mapping.Mapper.Map<U>(entity);
                var result = await _context.Set<U>().AddAsync(entry);
                await _context.SaveChangesAsync();

                var id = result.Entity?.Id;
                if (id == null)
                    throw new NullReferenceException(nameof(id));

                var endry = await Get((int)id);

                return Mapping.Mapper.Map<T>(endry);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception On Repository.Add({Mapping.Mapper.Map<U>(entity).GetType()}): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return null;
        }
    }

    public async Task<T> Delete(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        var entity = await Get(id);

        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            entity.IsDeleted = true;
            await Update(entity);

            //_context.Set<U>().Remove(Mapping.Mapper.Map<U>(entity));
            //await _context.SaveChangesAsync();
        }

        return entity;
    }

    public async Task<T> Update(T entity)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var entry = await _context.Set<U>().FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (entry != null)
                {
                    _context.Entry(entry).CurrentValues.SetValues(Mapping.Mapper.Map<U>(entity));
                    await _context.SaveChangesAsync();
                }

                return Mapping.Mapper.Map<T>(entry);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception On Repository.Update({Mapping.Mapper.Map<U>(entity).GetType()}): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return null;
        }
    }

    public async Task<T?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var i = await _context
                             .Set<U>()
                             .Where(r => !r.IsDeleted)
                             .FirstOrDefaultAsync(r => r.Id == id);

            return Mapping.Mapper.Map<T>(i);
        }
    }

    public async Task<ICollection<T>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<U> items;
            if (pageSize == 0 || pageIndex == 0)
            {
                items = await _context.Set<U>()
                                       .Where(r => !r.IsDeleted)
                                       .ToListAsync();
                return Mapping.Mapper.Map<List<T>>(items);
            }

            items = await _context.Set<U>()
                                  .Where(r => !r.IsDeleted)
                                  .Skip((pageIndex - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToListAsync();

            return Mapping.Mapper.Map<List<T>>(items);
        }
    }

    public async Task<ICollection<T>> GetAll(
        Expression<Func<U, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    )
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<U> items;

            if (pageSize == 0 || pageIndex == 0)
            {
                items = await _context.Set<U>()
                                      .Where(r => !r.IsDeleted)
                                      .Where(expresion).ToListAsync();
                return Mapping.Mapper.Map<List<T>>(items);
            }

            items = await _context.Set<U>()
                                  .Where(r => !r.IsDeleted)
                                  .Where(expresion)
                                  .Skip((pageIndex - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToListAsync();

            return Mapping.Mapper.Map<List<T>>(items);
        }
    }

    public async Task<int> Count()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context.Set<U>().Where(r => !r.IsDeleted).CountAsync();
        }
    }

    public async Task<int> Count(Expression<Func<U, bool>> expresion)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
            return await _context.Set<U>().Where(r => !r.IsDeleted).Where(expresion).CountAsync();
    }

    public async Task<bool> Any(Expression<System.Func<U, bool>> expresion)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (expresion == null)
                throw new ArgumentNullException(nameof(expresion));

            return await _context.Set<U>().Where(r => !r.IsDeleted).AnyAsync(expresion);
        }
    }

    public async Task SaveChangesAsync()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
            await _context.SaveChangesAsync();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {

            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}