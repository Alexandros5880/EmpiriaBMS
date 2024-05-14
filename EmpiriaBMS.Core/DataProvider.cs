using EmpiriaBMS.Core.Repositories;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

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
    public ProjectCategoryRepo ProjectsCategories { get; set; }
    public OtherTypeRepo OthersTypes { get; set; }
    public DrawingTypeRepo DrawingsTypes { get; set; }
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
    public OfferResultRepo OfferResult { get; set; }
    public OfferRepo Offers { get; set; }
    public EmailRepo Emails { get; set; }
    public TeamsRequestedUserRepo TeamsRequestedUsers { get; set; }
    public ContractRepo Contracts { get; set; }
    public KpisRepo KPIS { get; set; }

    public DataProvider(IDbContextFactory<AppDbContext> dbFactory) {
        Roles = new RolesRepo(dbFactory);
        Users = new UsersRepo(dbFactory);
        Projects = new ProjectsRepo(dbFactory);
        Disciplines = new DisciplineRepo(dbFactory);
        Drawings = new DrawingRepo(dbFactory);
        Others = new OtherRepo(dbFactory);
        Invoices = new InvoiceRepo(dbFactory);
        ProjectsCategories = new ProjectCategoryRepo(dbFactory);
        OthersTypes = new OtherTypeRepo(dbFactory);
        DrawingsTypes = new DrawingTypeRepo(dbFactory);
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
        OfferResult = new OfferResultRepo(dbFactory);
        Offers = new OfferRepo(dbFactory);
        Emails = new EmailRepo(dbFactory);
        TeamsRequestedUsers = new TeamsRequestedUserRepo(dbFactory);
        Contracts = new ContractRepo(dbFactory);
        KPIS = new KpisRepo(dbFactory);
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
                ProjectsCategories.Dispose();
                OthersTypes.Dispose();
                DrawingsTypes.Dispose();
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
                OfferResult.Dispose();
                Offers.Dispose();
                Emails.Dispose();
                TeamsRequestedUsers.Dispose();
                Contracts.Dispose();
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
