using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models;
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
public class Repository<T> : IRepository<T>, IDisposable
    where T : class, IEntityDto
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
            await _context.Set<T>().AddAsync(entity);
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
            _context.Set<T>().Remove(entity);
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
                var entry = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (entry != null)
                {
                    _context.Entry(entry).CurrentValues.SetValues(entity);
                    await _context.SaveChangesAsync();
                }
            }

            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Exception On Repository.Update({entity.GetType()}): {ex.Message}");
            return null;
        }
    }

    public async Task<T?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context
                             .Set<T>()
                             .FirstOrDefaultAsync(r => r.Id == id);
        }
    }

    public async Task<ICollection<T>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (pageSize == 0 || pageIndex == 0)
                return await _context.Set<T>().ToListAsync();

            return await _context.Set<T>()
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }
    }

    public async Task<ICollection<T>> GetAll(
        Expression<Func<T, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (pageSize == 0 || pageIndex == 0)
                return await _context.Set<T>().Where(expresion).ToListAsync();

            return await _context.Set<T>()
                                 .Where(expresion)
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }
    }

    public async Task<int> Count()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context.Set<T>().CountAsync();
        }
    }

    public async Task<int> Count(Expression<Func<T, bool>> expresion)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context.Set<T>().Where(expresion).CountAsync();
        }
    }

    public async Task<bool> Any(Expression<System.Func<T, bool>> expresion)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (expresion == null)
                throw new ArgumentNullException(nameof(expresion));

            return await _context.Set<T>().AnyAsync(expresion);
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