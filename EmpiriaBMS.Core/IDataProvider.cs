using EmpiriaBMS.Core.Repositories;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;

namespace EmpiriaBMS.Core
{
    public interface IDataProvider
    {
        UsersRepo Users { get; set; }
        CastomerRepo Customers { get; set; }
        EmployeeRepo Employees { get; set; }
        InvoiceRepo Invoices { get; set; }
        ProjectsRepo Projects { get; set; }
        RolesRepo Roles { get; set; }
    }
}