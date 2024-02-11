using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaMS.Models.Models;

namespace EmpiriaBMS.Core
{
    public interface IDataProvider
    {
        IRepository<Customer> Customers { get; set; }
        IRepository<Employee> Employees { get; set; }
        IRepository<Invoice> Invoices { get; set; }
        IRepository<Project> Projects { get; set; }
        IRepository<Role> Roles { get; set; }
    }
}