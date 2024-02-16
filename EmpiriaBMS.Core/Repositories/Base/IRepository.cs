using EmpiriaMS.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Repositories.Base;
public interface IRepository<T>
    where T : class, IEntity
{
    Task<T?> Get(string id);
    Task<ICollection<T>> GetAll(int pageSize = 0, int pageIndex = 0);
    Task<ICollection<T>> GetAll(
        Expression<Func<T, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    );
    Task<int> Count();
    Task<int> Count(Expression<Func<T, bool>> expresion);
    Task<bool> Any(Expression<System.Func<T, bool>> expresion);
    Task<T> Add(T model, bool update);
    Task<T> Update(T model);
    Task<T> Delete(string id);
    Task SaveChangesAsync();
    void Dispose();
}