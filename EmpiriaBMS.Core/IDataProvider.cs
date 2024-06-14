using EmpiriaBMS.Core.Repositories;

namespace EmpiriaBMS.Core
{
    public interface IDataProvider
    {
        public RolesRepo Roles { get; set; }
        public UsersRepo Users { get; set; }
        public ProjectsRepo Projects { get; set; }
        public DisciplineRepo Disciplines { get; set; }
        public DeliverableRepo Deliverables { get; set; }
        public OtherRepo Others { get; set; }
        public InvoiceRepo Invoices { get; set; }
        public ProjectCategoryRepo ProjectsCategories { get; set; }
        public OtherTypeRepo OthersTypes { get; set; }
        public DeliverableTypeRepo DeliverablesTypes { get; set; }
        public DisciplineTypeRepo DisciplinesTypes { get; set; }
        public PermissionRepo Permissions { get; set; }
        public IssueRepo Issues { get; set; }
        public PaymentRepo Payments { get; set; }
        public InvoiceTypeRepo InvoiceTypes { get; set; }
        public PaymentTypeRepo PaymentTypes { get; set; }
        public ProjectStageRepo ProjectStages { get; set; }
        public ProjectSubCategoryRepo ProjectsSubCategories { get; set; }
        public AddressRepo Address { get; set; }
        public ClientRepo Clients { get; set; }
        public OfferTypeRepo OfferTypes { get; set; }
        public OfferStateRepo OfferStates { get; set; }
        public OfferRepo Offers { get; set; }
        public EmailRepo Emails { get; set; }
        public TeamsRequestedUserRepo TeamsRequestedUsers { get; set; }
        public ContractRepo Contracts { get; set; }
        public LedRepo Leds { get; set; }
        public KpisRepo KPIS { get; set; }
    }
}