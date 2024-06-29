using EmpiriaBMS.Core.Repositories;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpiriaBMS.Core;
public class DataProvider : IDataProvider, IDisposable
{
    private bool disposedValue;

    public RolesRepo Roles { get; set; }
    public UsersRepo Users { get; set; }
    public ProjectsRepo Projects { get; set; }
    public DisciplineRepo Disciplines { get; set; }
    public DeliverableRepo Deliverables { get; set; }
    public SupportiveWorkRepo SupportiveWorks { get; set; }
    public InvoiceRepo Invoices { get; set; }
    public ProjectCategoryRepo ProjectsCategories { get; set; }
    public SupportiveWorkTypeRepo SupportiveWorksTypes { get; set; }
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

    public DataProvider(
        IDbContextFactory<AppDbContext> dbFactory,
        Logging.LoggerManager logger
    )
    {
        Roles = new RolesRepo(dbFactory, logger);
        Users = new UsersRepo(dbFactory, logger);
        Projects = new ProjectsRepo(dbFactory, logger);
        Disciplines = new DisciplineRepo(dbFactory, logger);
        Deliverables = new DeliverableRepo(dbFactory, logger);
        SupportiveWorks = new SupportiveWorkRepo(dbFactory, logger);
        Invoices = new InvoiceRepo(dbFactory, logger);
        ProjectsCategories = new ProjectCategoryRepo(dbFactory, logger);
        SupportiveWorksTypes = new SupportiveWorkTypeRepo(dbFactory, logger);
        DeliverablesTypes = new DeliverableTypeRepo(dbFactory, logger);
        DisciplinesTypes = new DisciplineTypeRepo(dbFactory, logger);
        Permissions = new PermissionRepo(dbFactory, logger);
        Issues = new IssueRepo(dbFactory, logger);
        Payments = new PaymentRepo(dbFactory, logger);
        InvoiceTypes = new InvoiceTypeRepo(dbFactory, logger);
        PaymentTypes = new PaymentTypeRepo(dbFactory, logger);
        ProjectStages = new ProjectStageRepo(dbFactory, logger);
        ProjectsSubCategories = new ProjectSubCategoryRepo(dbFactory, logger);
        Address = new AddressRepo(dbFactory, logger);
        Clients = new ClientRepo(dbFactory, logger);
        OfferTypes = new OfferTypeRepo(dbFactory, logger);
        OfferStates = new OfferStateRepo(dbFactory, logger);
        Offers = new OfferRepo(dbFactory, logger);
        Emails = new EmailRepo(dbFactory, logger);
        TeamsRequestedUsers = new TeamsRequestedUserRepo(dbFactory, logger);
        Contracts = new ContractRepo(dbFactory, logger);
        Leds = new LedRepo(dbFactory, logger);
        KPIS = new KpisRepo(dbFactory, logger);
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
                Deliverables.Dispose();
                SupportiveWorks.Dispose();
                Invoices.Dispose();
                ProjectsCategories.Dispose();
                SupportiveWorksTypes.Dispose();
                DeliverablesTypes.Dispose();
                DisciplinesTypes.Dispose();
                Permissions.Dispose();
                Issues.Dispose();
                Payments.Dispose();
                InvoiceTypes.Dispose();
                PaymentTypes.Dispose();
                ProjectStages.Dispose();
                ProjectsSubCategories.Dispose();
                Address.Dispose();
                Clients.Dispose();
                OfferTypes.Dispose();
                OfferStates.Dispose();
                Offers.Dispose();
                Emails.Dispose();
                TeamsRequestedUsers.Dispose();
                Contracts.Dispose();
                Leds.Dispose();
                KPIS.Dispose();
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
