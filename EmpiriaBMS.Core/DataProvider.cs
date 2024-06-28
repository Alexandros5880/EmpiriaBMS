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

    public DataProvider(IDbContextFactory<AppDbContext> dbFactory)
    {
        Roles = new RolesRepo(dbFactory);
        Users = new UsersRepo(dbFactory);
        Projects = new ProjectsRepo(dbFactory);
        Disciplines = new DisciplineRepo(dbFactory);
        Deliverables = new DeliverableRepo(dbFactory);
        SupportiveWorks = new SupportiveWorkRepo(dbFactory);
        Invoices = new InvoiceRepo(dbFactory);
        ProjectsCategories = new ProjectCategoryRepo(dbFactory);
        SupportiveWorksTypes = new SupportiveWorkTypeRepo(dbFactory);
        DeliverablesTypes = new DeliverableTypeRepo(dbFactory);
        DisciplinesTypes = new DisciplineTypeRepo(dbFactory);
        Permissions = new PermissionRepo(dbFactory);
        Issues = new IssueRepo(dbFactory);
        Payments = new PaymentRepo(dbFactory);
        InvoiceTypes = new InvoiceTypeRepo(dbFactory);
        PaymentTypes = new PaymentTypeRepo(dbFactory);
        ProjectStages = new ProjectStageRepo(dbFactory);
        ProjectsSubCategories = new ProjectSubCategoryRepo(dbFactory);
        Address = new AddressRepo(dbFactory);
        Clients = new ClientRepo(dbFactory);
        OfferTypes = new OfferTypeRepo(dbFactory);
        OfferStates = new OfferStateRepo(dbFactory);
        Offers = new OfferRepo(dbFactory);
        Emails = new EmailRepo(dbFactory);
        TeamsRequestedUsers = new TeamsRequestedUserRepo(dbFactory);
        Contracts = new ContractRepo(dbFactory);
        Leds = new LedRepo(dbFactory);
        KPIS = new KpisRepo(dbFactory, Leds);
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
