using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models;
public static class ModelRelations
{
    public static void CreateRelations(ModelBuilder builder)
    {
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

        // SubContractors Projects
        builder.Entity<ProjectSubConstructor>()
               .HasKey(ps => new { ps.SubContractorId, ps.ProjectId });
        builder.Entity<ProjectSubConstructor>()
               .HasOne(ps => ps.SubContractor)
               .WithMany(s => s.ProjectsSubConstructors)
               .HasForeignKey(ps => ps.SubContractorId);
        builder.Entity<ProjectSubConstructor>()
               .HasOne(ps => ps.Project)
               .WithMany(p => p.ProjectsSubConstructors)
               .HasForeignKey(ps => ps.ProjectId);

        // Invoices Project
        builder.Entity<Invoice>()
               .HasOne(i => i.Project)
               .WithMany(p => p.Invoices)
               .HasForeignKey(i => i.ProjectId)
               .OnDelete(DeleteBehavior.ClientCascade);

        // Offers Project
        builder.Entity<Offer>()
               .HasOne(i => i.Project)
               .WithMany(p => p.Offers)
               .HasForeignKey(i => i.ProjectId)
               .OnDelete(DeleteBehavior.ClientCascade);

        // InvoiceType Invoices
        builder.Entity<InvoiceType>()
               .HasMany(p => p.Invoices)
               .WithOne(c => c.Type)
               .HasForeignKey(c => c.TypeId)
               .OnDelete(DeleteBehavior.Cascade);

        // Payments Invoice
        builder.Entity<Payment>()
               .HasOne(p => p.Invoice)
               .WithMany(i => i.Payments)
               .HasForeignKey(p => p.InvoiceId)
               .OnDelete(DeleteBehavior.ClientCascade);

        // PaymentType Payments
        builder.Entity<PaymentType>()
               .HasMany(p => p.Payments)
               .WithOne(c => c.Type)
               .HasForeignKey(c => c.TypeId)
               .OnDelete(DeleteBehavior.Cascade);

        // OfferType Offers
        builder.Entity<OfferType>()
               .HasMany(p => p.Offers)
               .WithOne(c => c.Type)
               .HasForeignKey(c => c.TypeId)
               .OnDelete(DeleteBehavior.Cascade);

        // OfferState Offers
        builder.Entity<OfferState>()
               .HasMany(p => p.Offers)
               .WithOne(c => c.State)
               .HasForeignKey(c => c.StateId)
               .OnDelete(DeleteBehavior.Cascade);

        // Roles Parent And Children
        builder.Entity<Role>()
               .HasOne(r => r.ParentRole)
               .WithMany(r => r.ChildRoles)
               .HasForeignKey(r => r.ParentRoleId)
               .OnDelete(DeleteBehavior.ClientCascade);

        // Role Issues
        builder.Entity<Role>()
               .HasMany(p => p.Issues)
               .WithOne(c => c.DisplayedRole)
               .HasForeignKey(c => c.DisplayedRoleId)
               .OnDelete(DeleteBehavior.ClientCascade);

        // User Issues
        builder.Entity<User>()
               .HasMany(p => p.MyIssues)
               .WithOne(c => c.Creator)
               .HasForeignKey(c => c.CreatorId)
               .OnDelete(DeleteBehavior.ClientCascade);

        // User Emails
        builder.Entity<Email>()
               .HasOne(e => e.User)
               .WithMany(u => u.Emails)
               .HasForeignKey(e => e.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        // Project Disciplines
        builder.Entity<Project>()
               .HasMany(p => p.Disciplines)
               .WithOne(c => c.Project)
               .HasForeignKey(c => c.ProjectId)
               .OnDelete(DeleteBehavior.Cascade);

        // DisciplineType Desciplines
        builder.Entity<DisciplineType>()
               .HasMany(p => p.Disciplines)
               .WithOne(c => c.Type)
               .HasForeignKey(c => c.TypeId)
               .OnDelete(DeleteBehavior.Cascade);

        // ProjectManager Project
        builder.Entity<User>()
               .HasMany(p => p.PMProjects)
               .WithOne(c => c.ProjectManager)
               .HasForeignKey(c => c.ProjectManagerId)
               .OnDelete(DeleteBehavior.ClientCascade);

        // Client Project
        builder.Entity<Client>()
               .HasMany(p => p.Projects)
               .WithOne(c => c.Client)
               .HasForeignKey(c => c.ClientId)
               .OnDelete(DeleteBehavior.SetNull);

        // Client Address
        builder.Entity<Address>()
               .HasMany(p => p.Clients)
               .WithOne(c => c.Address)
               .HasForeignKey(c => c.AddressId)
               .OnDelete(DeleteBehavior.SetNull);

        // Discipline Draws
        builder.Entity<Discipline>()
               .HasMany(p => p.Drawings)
               .WithOne(c => c.Discipline)
               .HasForeignKey(c => c.DisciplineId)
               .OnDelete(DeleteBehavior.ClientCascade);

        // DrawingType Drawings
        builder.Entity<DrawingType>()
               .HasMany(p => p.Drawings)
               .WithOne(c => c.Type)
               .HasForeignKey(c => c.TypeId)
               .OnDelete(DeleteBehavior.Cascade);

        // Discipline Others
        builder.Entity<Discipline>()
               .HasMany(p => p.Others)
               .WithOne(c => c.Discipline)
               .HasForeignKey(c => c.DisciplineId)
               .OnDelete(DeleteBehavior.ClientCascade);

        // OtherType Others
        builder.Entity<OtherType>()
               .HasMany(p => p.Others)
               .WithOne(c => c.Type)
               .HasForeignKey(c => c.TypeId)
               .OnDelete(DeleteBehavior.Cascade);

        // Drawings Employees
        builder.Entity<DrawingEmployee>()
               .HasKey(de => new { de.DrawingId, de.EmployeeId });
        builder.Entity<DrawingEmployee>()
               .HasOne(de => de.Drawing)
               .WithMany(de => de.DrawingsEmployees)
               .HasForeignKey(de => de.DrawingId);
        builder.Entity<DrawingEmployee>()
               .HasOne(de => de.Employee)
               .WithMany(de => de.DrawingsEmployees)
               .HasForeignKey(de => de.EmployeeId);

        // Others Employees
        builder.Entity<OtherEmployee>()
               .HasKey(de => new { de.OtherId, de.EmployeeId });
        builder.Entity<OtherEmployee>()
               .HasOne(de => de.Other)
               .WithMany(de => de.OthersEmployees)
               .HasForeignKey(de => de.OtherId);
        builder.Entity<OtherEmployee>()
               .HasOne(de => de.Employee)
               .WithMany(de => de.OthersEmployees)
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

        // User DailyTime
        builder.Entity<User>()
               .HasMany(u => u.DailyTime)
               .WithOne(d => d.DailyUser)
               .HasForeignKey(d => d.DailyUserId)
               .OnDelete(DeleteBehavior.ClientCascade);

        // User PersonalTime
        builder.Entity<User>()
               .HasMany(u => u.PersonalTime)
               .WithOne(d => d.PersonalUser)
               .HasForeignKey(d => d.PersonalUserId)
               .OnDelete(DeleteBehavior.ClientCascade);

        // User TrainingTime
        builder.Entity<User>()
               .HasMany(u => u.TrainingTime)
               .WithOne(d => d.TrainingUser)
               .HasForeignKey(d => d.TrainingUserId)
               .OnDelete(DeleteBehavior.ClientCascade);

        // User CorporateEvents
        builder.Entity<User>()
               .HasMany(u => u.CorporateEventTime)
               .WithOne(d => d.CorporateUser)
               .HasForeignKey(d => d.CorporateUserId)
               .OnDelete(DeleteBehavior.ClientCascade);

        // Project DailyTime
        builder.Entity<Project>()
               .HasMany(p => p.DailyTime)
               .WithOne(c => c.Project)
               .HasForeignKey(c => c.ProjectId)
               .OnDelete(DeleteBehavior.ClientCascade);

        // Discipline DailyTime
        builder.Entity<Discipline>()
               .HasMany(p => p.DailyTime)
               .WithOne(c => c.Discipline)
               .HasForeignKey(c => c.DisciplineId)
               .OnDelete(DeleteBehavior.Cascade);

        // Other DailyTime
        builder.Entity<Other>()
               .HasMany(p => p.DailyTime)
               .WithOne(c => c.Other)
               .HasForeignKey(c => c.OtherId)
               .OnDelete(DeleteBehavior.Cascade);

        // Drawing DailyTime
        builder.Entity<Drawing>()
               .HasMany(p => p.DailyTime)
               .WithOne(c => c.Drawing)
               .HasForeignKey(c => c.DrawingId)
               .OnDelete(DeleteBehavior.Cascade);

        // SubCategorys Category
        builder.Entity<ProjectCategory>()
               .HasMany(p => p.SubCategories)
               .WithOne(c => c.Category)
               .HasForeignKey(c => c.CategoryId)
               .OnDelete(DeleteBehavior.Cascade);

        // Projects SubCategory
        builder.Entity<ProjectSubCategory>()
               .HasMany(p => p.Projects)
               .WithOne(c => c.Category)
               .HasForeignKey(c => c.CategoryId)
               .OnDelete(DeleteBehavior.Cascade);

        // Projects Address
        builder.Entity<Address>()
               .HasMany(p => p.Projects)
               .WithOne(c => c.Address)
               .HasForeignKey(c => c.AddressId)
               .OnDelete(DeleteBehavior.SetNull);

        // Projects ProjectStage
        builder.Entity<ProjectStage>()
               .HasMany(p => p.Projects)
               .WithOne(c => c.Stage)
               .HasForeignKey(c => c.StageId)
               .OnDelete(DeleteBehavior.Cascade);

        // Complain Project
        builder.Entity<Project>()
               .HasMany(p => p.Complains)
               .WithOne(c => c.Project)
               .HasForeignKey(c => c.ProjectId)
               .OnDelete(DeleteBehavior.Cascade);

        // Issue Documents
        builder.Entity<Document>()
               .HasOne(d => d.Issue)
               .WithMany(i => i.Documents)
               .HasForeignKey(d => d.IssueId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
