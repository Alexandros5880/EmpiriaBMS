using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;
using System.Linq.Expressions;

namespace EmpiriaBMS.Core.Repositories.Base;
public interface IRepository<T, U>
    where T : class, IEntityDto
    where U : class, IEntity
{
    Task<T?> Get(int id);
    Task<ICollection<T>> GetAll(int pageSize = 0, int pageIndex = 0);
    Task<ICollection<T>> GetAll(
        Expression<Func<U, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    );
    Task<int> Count();
    Task<int> Count(Expression<Func<U, bool>> expresion);
    Task<bool> Any(Expression<System.Func<U, bool>> expresion);
    Task<T> Add(T model, bool update);
    Task<T> Update(T model);
    Task<T> Delete(int id);
    Task SaveChangesAsync();
    void Dispose();
}