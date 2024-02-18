using EmpiriaBMS.Core.Repositories;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;

namespace EmpiriaBMS.Core
{
    public interface IDataProvider
    {
        public RolesRepo Roles { get; set; }
        public UsersRepo Users { get; set; }
        public ProjectsRepo Projects { get; set; }
        public DisciplineRepo Disciplines { get; set; }
        public DrawRepo Draws { get; set; }
        public DocRepo Docs { get; set; }
        public DisciplineEngineerRepo DisciplinesEngineers { get; set; }
        public InvoiceRepo Invoices { get; set; }
    }
}