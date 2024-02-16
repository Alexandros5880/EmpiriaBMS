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
    where T : class, IEntity
{
    protected readonly AppDbContext _context;
    private bool disposedValue;

    public Repository(AppDbContext context) =>
        _context = context;

    public async Task<T> Add(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        entity.Id = Guid.NewGuid().ToString().Replace("\\", string.Empty).Replace("/", string.Empty);
        entity.CreatedDate = DateTime.Now.ToUniversalTime();
        entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

        await _context.Set<T>().AddAsync(entity);

        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<T> Delete(string id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));
        
        var entity = await Get(id);
        
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        _context.Set<T>().Remove(entity);

        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<T> Update(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

        var oldEntity = _context.Set<T>().FirstOrDefaultAsync(i => i.Id.Equals(entity.Id));
        _context.Entry(oldEntity).CurrentValues.SetValues(oldEntity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<T?> Get(string id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));

        return await _context
                         .Set<T>()
                         .FirstOrDefaultAsync(r => r.Id.Equals(id));
    }

    public async Task<ICollection<T>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<T>().ToListAsync();

        return await _context.Set<T>()
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .ToListAsync();
    }

    public async Task<ICollection<T>> GetAll(
        Expression<Func<T, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<T>().Where(expresion).ToListAsync();

        return await _context.Set<T>()
                             .Where(expresion)
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .ToListAsync();
    }

    public async Task<int> Count()
    {
        return await _context.Set<T>().CountAsync();
    }

    public async Task<int> Count(Expression<Func<T, bool>> expresion)
    {
        return await _context.Set<T>().Where(expresion).CountAsync();
    }

    public async Task<bool> Any(Expression<System.Func<T, bool>> expresion)
    {
        if (expresion == null)
            throw new ArgumentNullException(nameof(expresion));

        return await _context.Set<T>().AnyAsync(expresion);
    }

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _context.Dispose();
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