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
        public DrawingRepo Drawings { get; set; }
        public OtherRepo Others { get; set; }
        public InvoiceRepo Invoices { get; set; }
        public ProjectTypeRepo ProjectsTypes { get; set; }
        public OtherTypeRepo OthersTypes { get; set; }
        public DrawingTypeRepo DrawingsTypes { get; set; }
        public DisciplineTypeRepo DisciplinesTypes { get; set; }
        public PermissionRepo Permissions { get; set; }
        public IssueRepo Issues { get; set; }
        public PaymentRepo Payments { get; set; }
        public InvoiceTypeRepo InvoiceTypes { get; set; }
        public PaymentTypeRepo PaymentTypes { get; set; }
        public ProjectStageRepo ProjectStages { get; set; }
        public ProjectGroupRepo ProjectsGroups { get; set; }
        public AddressRepo Address { get; set; }
        public KpisRepo KPIS { get; set; }
    }
}