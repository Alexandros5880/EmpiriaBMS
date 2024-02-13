using EmpiriaBMS.Core.Repositories;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaMS.Models;
using EmpiriaMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core;
public class DataProvider : IDataProvider, IDisposable
{
    private bool disposedValue;

    public IRepository<Role> Roles { get; set; }
    public IRepository<Project> Projects { get; set; }
    public IRepository<Invoice> Invoices { get; set; }
    public IRepository<Employee> Employees { get; set; }
    public IRepository<Customer> Customers { get; set; }

    public DataProvider(AppDbContext context)
    {
        Roles = new RolesRepo(context);
        Projects = new ProjectsRepo(context);
        Invoices = new InvoiceRepo(context);
        Employees = new EmployeeRepo(context);
        Customers = new CastomerRepo(context);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                Roles.Dispose();
                Projects.Dispose();
                Invoices.Dispose();
                Employees.Dispose();
                Customers.Dispose();
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
