using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;

namespace EmpiriaBMS.Core
{
    public interface IDataProvider
    {
        IRepository<User> Customers { get; set; }
        IRepository<User> Employees { get; set; }
        IRepository<Invoice> Invoices { get; set; }
        IRepository<Project> Projects { get; set; }
        IRepository<Role> Roles { get; set; }
    }
}