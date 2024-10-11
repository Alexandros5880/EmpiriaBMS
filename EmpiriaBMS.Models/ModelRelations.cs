using EmpiriaBMS.Front.Components.KPIS.Helper;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace EmpiriaBMS.Models;
public static class ModelRelations
{
    public static void CreateRelations(ModelBuilder builder)
    {
        // KPIGridItem KPIGridItemPosition
        builder.Entity<KPIGridItem>()
               .HasOne(u => u.Position)
               .WithOne(p => p.KPIGridItem)
               .HasForeignKey<KPIGridItemPosition>(p => p.KPIGridItemId)
               .OnDelete(DeleteBehavior.NoAction);

        // Roles Permissions
        builder.Entity<RolePermission>()
               .HasKey(sc => new { sc.RoleId, sc.PermissionId });
        builder.Entity<RolePermission>()
               .HasOne(sc => sc.Role)
               .WithMany(s => s.RolesPermissions)
               .HasForeignKey(sc => sc.RoleId);
        builder.Entity<RolePermission>()
               .HasOne(sc => sc.Permission)
               .WithMany(c => c.RolesPermissions)
               .HasForeignKey(sc => sc.PermissionId);

        // Users Roles
        builder.Entity<UserRole>()
               .HasKey(sc => new { sc.UserId, sc.RoleId });
        builder.Entity<UserRole>()
               .HasOne(sc => sc.User)
               .WithMany(s => s.UserRoles)
               .HasForeignKey(sc => sc.UserId);
        builder.Entity<UserRole>()
               .HasOne(sc => sc.Role)
               .WithMany(c => c.UserRoles)
               .HasForeignKey(sc => sc.RoleId);

        // Deliverable Employees
        builder.Entity<DeliverableEmployee>()
               .HasKey(de => new { de.DeliverableId, de.EmployeeId });
        builder.Entity<DeliverableEmployee>()
               .HasOne(de => de.Deliverable)
               .WithMany(de => de.DeliverablesEmployees)
               .HasForeignKey(de => de.DeliverableId);
        builder.Entity<DeliverableEmployee>()
               .HasOne(de => de.Employee)
               .WithMany(de => de.DeliverablesEmployees)
               .HasForeignKey(de => de.EmployeeId);

        // SupportiveWorks Employees
        builder.Entity<SupportiveWorkEmployee>()
               .HasKey(de => new { de.SupportiveWorkId, de.EmployeeId });
        builder.Entity<SupportiveWorkEmployee>()
               .HasOne(de => de.SupportiveWork)
               .WithMany(de => de.SupportiveWorksEmployees)
               .HasForeignKey(de => de.SupportiveWorkId);
        builder.Entity<SupportiveWorkEmployee>()
               .HasOne(de => de.Employee)
               .WithMany(de => de.SupportiveWorksEmployees)
               .HasForeignKey(de => de.EmployeeId);

        // Engineers Disciplines
        builder.Entity<DisciplineEngineer>()
               .HasKey(de => new { de.DisciplineId, de.EngineerId });
        builder.Entity<DisciplineEngineer>()
               .HasOne(de => de.Engineer)
               .WithMany(de => de.DisciplinesEngineers)
               .HasForeignKey(de => de.EngineerId);
        builder.Entity<DisciplineEngineer>()
               .HasOne(de => de.Discipline)
               .WithMany(de => de.DisciplinesEngineers)
               .HasForeignKey(de => de.DisciplineId);

        // Projects SubConstructors
        builder.Entity<ProjectSubConstractor>()
               .HasKey(ps => new { ps.ProjectId, ps.SubConstructorId });
        builder.Entity<ProjectSubConstractor>()
               .HasOne(ps => ps.Project)
               .WithMany(p => p.ProjectsSubConstructors)
               .HasForeignKey(ps => ps.ProjectId);
        builder.Entity<ProjectSubConstractor>()
               .HasOne(ps => ps.SubConstructor)
               .WithMany(s => s.ProjectsSubConstructors)
               .HasForeignKey(ps => ps.SubConstructorId);

        // Offer Project (OneToOne)
        builder.Entity<Offer>()
               .HasOne(a => a.Project)
               .WithOne(b => b.Offer)
               .HasForeignKey<Project>(b => b.OfferId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Project>()
               .HasOne(b => b.Offer)
               .WithOne(a => a.Project)
               .HasForeignKey<Offer>(a => a.ProjectId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.NoAction);

        // Offers Client
        builder.Entity<Offer>()
               .HasOne(i => i.Client)
               .WithMany(p => p.Offers)
               .HasForeignKey(i => i.ClientId)
               .OnDelete(DeleteBehavior.NoAction);

        // Users Client
        builder.Entity<User>()
               .HasOne(u => u.Client)
               .WithMany(c => c.Users)
               .HasForeignKey(u => u.ClientId)
               .OnDelete(DeleteBehavior.NoAction);

        // Users SubConstructor
        builder.Entity<User>()
               .HasOne(i => i.SubConstructor)
               .WithMany(p => p.Users)
               .HasForeignKey(i => i.SubConstructorId)
               .OnDelete(DeleteBehavior.NoAction);

        // Invoices Project
        builder.Entity<Invoice>()
               .HasOne(i => i.Project)
               .WithMany(p => p.Invoices)
               .HasForeignKey(i => i.ProjectId)
               .OnDelete(DeleteBehavior.NoAction);

        // InvoiceType Invoices
        builder.Entity<InvoiceType>()
               .HasMany(p => p.Invoices)
               .WithOne(c => c.Type)
               .HasForeignKey(c => c.TypeId)
               .OnDelete(DeleteBehavior.NoAction);

        // ExpensesType Invoices
        builder.Entity<ExpensesType>()
               .HasMany(p => p.Invoices)
               .WithOne(c => c.ExpensesType)
               .HasForeignKey(c => c.ExpensesTypeId)
               .OnDelete(DeleteBehavior.SetNull);

        // Payments Invoice
        builder.Entity<Payment>()
               .HasOne(p => p.Invoice)
               .WithMany(i => i.Payments)
               .HasForeignKey(p => p.InvoiceId)
               .OnDelete(DeleteBehavior.NoAction);

        // PaymentType Payments
        builder.Entity<PaymentType>()
               .HasMany(p => p.Payments)
               .WithOne(c => c.Type)
               .HasForeignKey(c => c.TypeId)
               .OnDelete(DeleteBehavior.NoAction);

        // OfferType Offers
        builder.Entity<OfferType>()
               .HasMany(p => p.Offers)
               .WithOne(c => c.Type)
               .HasForeignKey(c => c.TypeId)
               .OnDelete(DeleteBehavior.NoAction);

        // OfferState Offers
        builder.Entity<OfferState>()
               .HasMany(p => p.Offers)
               .WithOne(c => c.State)
               .HasForeignKey(c => c.StateId)
               .OnDelete(DeleteBehavior.NoAction);

        // Roles Parent And Children
        builder.Entity<Role>()
               .HasOne(r => r.ParentRole)
               .WithMany(r => r.ChildRoles)
               .HasForeignKey(r => r.ParentRoleId)
               .OnDelete(DeleteBehavior.ClientSetNull);

        // Role Issues
        builder.Entity<Role>()
               .HasMany(p => p.Issues)
               .WithOne(c => c.DisplayedRole)
               .HasForeignKey(c => c.DisplayedRoleId)
               .OnDelete(DeleteBehavior.NoAction);

        // User Issues
        builder.Entity<User>()
               .HasMany(p => p.MyIssues)
               .WithOne(c => c.Creator)
               .HasForeignKey(c => c.CreatorId)
               .OnDelete(DeleteBehavior.NoAction);

        // User Emails
        builder.Entity<Email>()
               .HasOne(e => e.User)
               .WithMany(u => u.Emails)
               .HasForeignKey(e => e.UserId)
               .OnDelete(DeleteBehavior.NoAction);

        // SubConstructor Emails
        builder.Entity<Email>()
               .HasOne(e => e.SubConstructor)
               .WithMany(u => u.Emails)
               .HasForeignKey(e => e.SubConstructorId)
               .OnDelete(DeleteBehavior.NoAction);

        // Client Emails
        builder.Entity<Email>()
               .HasOne(e => e.Client)
               .WithMany(u => u.Emails)
               .HasForeignKey(e => e.ClientId)
               .OnDelete(DeleteBehavior.NoAction);

        // Project Disciplines
        builder.Entity<Project>()
               .HasMany(p => p.Disciplines)
               .WithOne(c => c.Project)
               .HasForeignKey(c => c.ProjectId)
               .OnDelete(DeleteBehavior.NoAction);

        // DisciplineType Desciplines
        builder.Entity<DisciplineType>()
               .HasMany(p => p.Disciplines)
               .WithOne(c => c.Type)
               .HasForeignKey(c => c.TypeId)
               .OnDelete(DeleteBehavior.NoAction);

        // ProjectManager Project
        builder.Entity<User>()
               .HasMany(p => p.PMProjects)
               .WithOne(c => c.ProjectManager)
               .HasForeignKey(c => c.ProjectManagerId)
               .OnDelete(DeleteBehavior.ClientSetNull);

        // Client Address
        builder.Entity<Email>()
               .HasOne(e => e.Client)
               .WithMany(c => c.Emails)
               .HasForeignKey(e => e.ClientId)
               .OnDelete(DeleteBehavior.NoAction);

        // Project Address
        builder.Entity<Address>()
               .HasMany(p => p.Projects)
               .WithOne(c => c.Address)
               .HasForeignKey(c => c.AddressId)
               .OnDelete(DeleteBehavior.SetNull);

        // Discipline Draws
        builder.Entity<Discipline>()
               .HasMany(p => p.Deliverables)
               .WithOne(c => c.Discipline)
               .HasForeignKey(c => c.DisciplineId)
               .OnDelete(DeleteBehavior.NoAction);

        // DeliverableType Deliverables
        builder.Entity<DeliverableType>()
               .HasMany(p => p.Deliverables)
               .WithOne(c => c.Type)
               .HasForeignKey(c => c.TypeId)
               .OnDelete(DeleteBehavior.NoAction);

        // Discipline SupportiveWorks
        builder.Entity<Discipline>()
               .HasMany(p => p.SupportiveWorks)
               .WithOne(c => c.Discipline)
               .HasForeignKey(c => c.DisciplineId)
               .OnDelete(DeleteBehavior.NoAction);

        // SupportiveWorkType SupportiveWorks
        builder.Entity<SupportiveWorkType>()
               .HasMany(p => p.SupportiveWorks)
               .WithOne(c => c.Type)
               .HasForeignKey(c => c.TypeId)
               .OnDelete(DeleteBehavior.NoAction);

        // User DailyTime
        builder.Entity<User>()
               .HasMany(u => u.DailyTime)
               .WithOne(d => d.DailyUser)
               .HasForeignKey(d => d.DailyUserId)
               .OnDelete(DeleteBehavior.ClientNoAction);

        // User PersonalTime
        builder.Entity<User>()
               .HasMany(u => u.PersonalTime)
               .WithOne(d => d.PersonalUser)
               .HasForeignKey(d => d.PersonalUserId)
               .OnDelete(DeleteBehavior.ClientNoAction);

        // User TrainingTime
        builder.Entity<User>()
               .HasMany(u => u.TrainingTime)
               .WithOne(d => d.TrainingUser)
               .HasForeignKey(d => d.TrainingUserId)
               .OnDelete(DeleteBehavior.ClientNoAction);

        // User CorporateEvents
        builder.Entity<User>()
               .HasMany(u => u.CorporateEventTime)
               .WithOne(d => d.CorporateUser)
               .HasForeignKey(d => d.CorporateUserId)
               .OnDelete(DeleteBehavior.NoAction);

        // Client DailyTime
        builder.Entity<Client>()
               .HasMany(p => p.ClientDailyTime)
               .WithOne(c => c.Client)
               .HasForeignKey(c => c.ClientId)
               .OnDelete(DeleteBehavior.ClientNoAction);

        // Offer DailyTime
        builder.Entity<Offer>()
               .HasMany(p => p.DailyTime)
               .WithOne(c => c.Offer)
               .HasForeignKey(c => c.OfferId)
               .OnDelete(DeleteBehavior.ClientNoAction);

        // Project DailyTime
        builder.Entity<Project>()
               .HasMany(p => p.DailyTime)
               .WithOne(c => c.Project)
               .HasForeignKey(c => c.ProjectId)
               .OnDelete(DeleteBehavior.ClientNoAction);

        // Discipline DailyTime
        builder.Entity<Discipline>()
               .HasMany(p => p.DailyTime)
               .WithOne(c => c.Discipline)
               .HasForeignKey(c => c.DisciplineId)
               .OnDelete(DeleteBehavior.ClientNoAction);

        // SupportiveWork DailyTime
        builder.Entity<SupportiveWork>()
               .HasMany(p => p.DailyTime)
               .WithOne(c => c.SupportiveWork)
               .HasForeignKey(c => c.SupportiveWorkId)
               .OnDelete(DeleteBehavior.ClientNoAction);

        // Deliverable DailyTime
        builder.Entity<Deliverable>()
               .HasMany(p => p.DailyTime)
               .WithOne(c => c.Deliverable)
               .HasForeignKey(c => c.DeliverableId)
               .OnDelete(DeleteBehavior.ClientNoAction);

        // SubCategorys Category
        builder.Entity<ProjectSubCategory>()
               .HasOne(psc => psc.Category)
               .WithMany()
               .HasForeignKey(psc => psc.CategoryId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.NoAction);

        // Offers SubCategory
        builder.Entity<Offer>()
               .HasOne(psc => psc.SubCategory)
               .WithMany()
               .HasForeignKey(psc => psc.SubCategoryId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.NoAction);

        // Offers Category
        builder.Entity<Offer>()
               .HasOne(psc => psc.Category)
               .WithMany()
               .HasForeignKey(psc => psc.CategoryId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.NoAction);

        // Projects ProjectStage
        builder.Entity<ProjectStage>()
               .HasMany(p => p.Projects)
               .WithOne(c => c.Stage)
               .HasForeignKey(c => c.StageId)
               .OnDelete(DeleteBehavior.NoAction);

        // Complain Project
        builder.Entity<Project>()
               .HasMany(p => p.Complains)
               .WithOne(c => c.Project)
               .HasForeignKey(c => c.ProjectId)
               .OnDelete(DeleteBehavior.NoAction);

        // Issue Documents
        builder.Entity<Document>()
               .HasOne(d => d.Issue)
               .WithMany(i => i.Documents)
               .HasForeignKey(d => d.IssueId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}