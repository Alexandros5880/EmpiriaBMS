using EmpiriaBMS.Core.Repositories;
using EmpiriaBMS.Core.Repositories.Base;
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

    public DataProvider()
    {
        Roles = new RolesRepo();
        Projects = new ProjectsRepo();
        Invoices = new InvoiceRepo();
        Employees = new EmployeeRepo();
        Customers = new CastomerRepo();
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
