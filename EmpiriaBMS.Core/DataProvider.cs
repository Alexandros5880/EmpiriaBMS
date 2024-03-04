using EmpiriaBMS.Core.Repositories;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
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
    public ProjectsRepo Projects { get; set; }
    public DisciplineRepo Disciplines { get; set; }
    public DrawingRepo Drawings { get; set; }
    public OtherRepo Others { get; set; }
    public InvoiceRepo Invoices { get; set; }
    public ProjectTypeRepo ProjectsTypes { get; set; }
    public OtherTypeRepo OthersTypes { get; set; }
    public DrawingTypeRepo DrawingsTypes { get; set; }
    public DisciplineTypeRepo DisciplinesTypes { get; set; }

    public DataProvider(IDbContextFactory<AppDbContext> dbFactory) {
        Roles = new RolesRepo(dbFactory);
        Users = new UsersRepo(dbFactory);
        Projects = new ProjectsRepo(dbFactory);
        Disciplines = new DisciplineRepo(dbFactory);
        Drawings = new DrawingRepo(dbFactory);
        Others = new OtherRepo(dbFactory);
        Invoices = new InvoiceRepo(dbFactory);
        ProjectsTypes = new ProjectTypeRepo(dbFactory);
        OthersTypes = new OtherTypeRepo(dbFactory);
        DrawingsTypes = new DrawingTypeRepo(dbFactory);
        DisciplinesTypes = new DisciplineTypeRepo(dbFactory);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                Roles.Dispose();
                Users.Dispose();
                Projects.Dispose();
                Disciplines.Dispose();
                Drawings.Dispose();
                Others.Dispose();
                Invoices.Dispose();
                ProjectsTypes.Dispose();
                OthersTypes.Dispose();
                DrawingsTypes.Dispose();
                DisciplinesTypes.Dispose();
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
