using EmpiriaBMS.Core.Repositories;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models;
using EmpiriaMS.Models.Models;
using Microsoft.EntityFrameworkCore;
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
    public UsersRepo Users { get; set; }
    public UserRoleRepo UsersRoles { get; set; }
    public ProjectsRepo Projects { get; set; }
    public DisciplineRepo Disciplines { get; set; }
    public DrawRepo Draws { get; set; }
    public DocRepo Docs { get; set; }
    public DisciplineEngineerRepo DisciplinesEngineers { get; set; }
    public InvoiceRepo Invoices { get; set; }

    public DataProvider(IDbContextFactory<AppDbContext> dbFactory) {
        Roles = new RolesRepo(dbFactory);
        Users = new UsersRepo(dbFactory);
        UsersRoles = new UserRoleRepo(dbFactory);
        Projects = new ProjectsRepo(dbFactory);
        Disciplines = new DisciplineRepo(dbFactory);
        Draws = new DrawRepo(dbFactory);
        Docs = new DocRepo(dbFactory);
        DisciplinesEngineers = new DisciplineEngineerRepo(dbFactory);
        Invoices = new InvoiceRepo(dbFactory);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                Roles.Dispose();
                Users.Dispose();
                UsersRoles.Dispose();
                Projects.Dispose();
                Disciplines.Dispose();
                Draws.Dispose();
                Docs.Dispose();
                DisciplinesEngineers.Dispose();
                Invoices.Dispose();
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
