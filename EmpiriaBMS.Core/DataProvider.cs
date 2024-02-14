using EmpiriaBMS.Core.Repositories;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
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

    public RolesRepo Roles { get; set; }
    public ProjectsRepo Projects { get; set; }
    public InvoiceRepo Invoices { get; set; }
    public EmployeeRepo Employees { get; set; }
    public CastomerRepo Customers { get; set; }
    public UsersRepo Users { get; set; }

    public DataProvider(AppDbContext context)
    {
        Roles = new RolesRepo(context);
        Projects = new ProjectsRepo(context);
        Invoices = new InvoiceRepo(context);
        Employees = new EmployeeRepo(context);
        Customers = new CastomerRepo(context);
        Users = new UsersRepo(context);
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
                Users.Dispose();
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
