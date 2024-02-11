using EmpiriaMS.Models;
using EmpiriaMS.Models.Models.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;


namespace EmpiriaBMS.Core.Repositories.Base;
public class Repository<T> : IRepository<T>, IDisposable
    where T : class, IEntity
{
    protected readonly AppDbContext _context;
    private bool disposedValue;

    public Repository() =>
        _context = new AppDbContext();

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

        //_context.Set<T>().Attach(entity);
        _context.Set<T>().Update(entity);

        //_context.Entry<T>(entity).State = EntityState.Detached;
        //_context.Entry<T>(entity).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<T?> Get(string id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));

        return await _context
                         .Set<T>()
                         .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<ICollection<T>> GetAll(Expression<Func<T, bool>> expresion)
    {
        if (expresion == null)
            throw new ArgumentNullException(nameof(expresion));

        return await _context.Set<T>().Where(expresion).ToListAsync();
    }

    public async Task<bool> Any(Expression<System.Func<T, bool>> expresion)
    {
        if (expresion == null)
            throw new ArgumentNullException(nameof(expresion));

        return await _context.Set<T>().AnyAsync(expresion);
    }

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