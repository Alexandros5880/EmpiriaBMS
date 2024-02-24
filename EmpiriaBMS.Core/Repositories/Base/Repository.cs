using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;
using EmpiriaMS.Models.Models.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;


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
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        entity.CreatedDate = update ? DateTime.Now.ToUniversalTime() : entity.CreatedDate;
        entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            await _context.Set<U>().AddAsync(Mapping.Mapper.Map<U>(entity));
            await _context.SaveChangesAsync();

            return entity;
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
            _context.Set<U>().Remove(Mapping.Mapper.Map<U>(entity));
            await _context.SaveChangesAsync();
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
            }

            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Exception On Repository.Update({Mapping.Mapper.Map<U>(entity).GetType()}): {ex.Message}");
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
                items =  await _context.Set<U>().ToListAsync();
                return Mapping.Mapper.Map<List<T>>(items);
            }

            items = await _context.Set<U>()
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
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<U> items;

            if (pageSize == 0 || pageIndex == 0)
            {
                items = await _context.Set<U>().Where(expresion).ToListAsync();
                return Mapping.Mapper.Map<List<T>>(items);
            }

            items = await _context.Set<U>()
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
            return await _context.Set<U>().CountAsync();
        }
    }

    public async Task<int> Count(Expression<Func<U, bool>> expresion)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
            return await _context.Set<U>().Where(expresion).CountAsync();
    }

    public async Task<bool> Any(Expression<System.Func<U, bool>> expresion)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (expresion == null)
                throw new ArgumentNullException(nameof(expresion));

            return await _context.Set<U>().AnyAsync(expresion);
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