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

        // Roles Parent And Children
        builder.Entity<Role>()
               .HasOne(r => r.ParentRole)
               .WithMany(r => r.ChildRoles)
               .HasForeignKey(r => r.ParentRoleId);

        // User Emails
        builder.Entity<Email>()
               .HasOne(e => e.User)
               .WithMany(u => u.Emails)
               .HasForeignKey(e => e.UserId);
               //.IsRequired();

        // Project Disciplines
        builder.Entity<Project>()
               .HasMany(p => p.Disciplines)
               .WithOne(c => c.Project)
               .HasForeignKey(c => c.ProjectId);

        // DisciplineType Desciplines
        builder.Entity<DisciplineType>()
               .HasMany(p => p.Disciplines)
               .WithOne(c => c.Type)
               .HasForeignKey(c => c.TypeId);

        // ProjectManager Project
        builder.Entity<User>()
               .HasMany(p => p.PMProjects)
               .WithOne(c => c.ProjectManager)
               .HasForeignKey(c => c.ProjectManagerId)
               .OnDelete(DeleteBehavior.Restrict);

        // SubContractor Project
        builder.Entity<User>()
                    .HasMany(p => p.SubConstructorProjects)
                    .WithOne(c => c.SubContractor)
                    .HasForeignKey(c => c.SubContractorId)
                    .OnDelete(DeleteBehavior.Restrict);

        // Discipline Draws
        builder.Entity<Discipline>()
               .HasMany(p => p.Drawings)
               .WithOne(c => c.Discipline)
               .HasForeignKey(c => c.DisciplineId);

        // DrawingType Drawings
        builder.Entity<DrawingType>()
               .HasMany(p => p.Drawings)
               .WithOne(c => c.Type)
               .HasForeignKey(c => c.TypeId);

        // Discipline Others
        builder.Entity<Discipline>()
               .HasMany(p => p.Others)
               .WithOne(c => c.Discipline)
               .HasForeignKey(c => c.DisciplineId);

        // OtherType Others
        builder.Entity<OtherType>()
               .HasMany(p => p.Others)
               .WithOne(c => c.Type)
               .HasForeignKey(c => c.TypeId);

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

        // Project Invoice
        builder.Entity<Project>()
               .HasOne(p => p.Invoice)
               .WithOne(c => c.Project)
               .HasForeignKey<Invoice>(c => c.ProjectId);

        // Project Payment
        builder.Entity<Project>()
               .HasOne(p => p.Payment)
               .WithOne(c => c.Project)
               .HasForeignKey<Payment>(c => c.ProjectId);

        // User DailyTime
        builder.Entity<User>()
                    .HasMany(u => u.DailyTime)
                    .WithOne(d => d.DailyUser)
                    .HasForeignKey(d => d.DailyUserId)
                    .OnDelete(DeleteBehavior.Restrict);

        // User PersonalTime
        builder.Entity<User>()
                    .HasMany(u => u.PersonalTime)
                    .WithOne(d => d.PersonalUser)
                    .HasForeignKey(d => d.PersonalUserId)
                    .OnDelete(DeleteBehavior.Restrict);

        // User TrainingTime
        builder.Entity<User>()
                    .HasMany(u => u.TrainingTime)
                    .WithOne(d => d.TrainingUser)
                    .HasForeignKey(d => d.TrainingUserId)
                    .OnDelete(DeleteBehavior.Restrict);

        // User CorporateEvents
        builder.Entity<User>()
                    .HasMany(u => u.CorporateEventTime)
                    .WithOne(d => d.CorporateUser)
                    .HasForeignKey(d => d.CorporateUserId)
                    .OnDelete(DeleteBehavior.Restrict);

        // Project DailyTime
        builder.Entity<Project>()
                    .HasMany(p => p.DailyTime)
                    .WithOne(c => c.Project)
                    .HasForeignKey(c => c.ProjectId)
                    .OnDelete(DeleteBehavior.Restrict);

        // Discipline DailyTime
        builder.Entity<Discipline>()
                    .HasMany(p => p.DailyTime)
                    .WithOne(c => c.Discipline)
                    .HasForeignKey(c => c.DisciplineId)
                    .OnDelete(DeleteBehavior.Restrict);

        // Other DailyTime
        builder.Entity<Other>()
                    .HasMany(p => p.DailyTime)
                    .WithOne(c => c.Other)
                    .HasForeignKey(c => c.OtherId)
                    .OnDelete(DeleteBehavior.Restrict);

        // Drawing DailyTime
        builder.Entity<Drawing>()
                    .HasMany(p => p.DailyTime)
                    .WithOne(c => c.Drawing)
                    .HasForeignKey(c => c.DrawingId)
                    .OnDelete(DeleteBehavior.Restrict);

        // Projects ProjectType
        builder.Entity<ProjectType>()
                    .HasMany(p => p.Projects)
                    .WithOne(c => c.Type)
                    .HasForeignKey(c => c.TypeId);

        // Complain Project
        builder.Entity<Project>()
               .HasMany(p => p.Complains)
               .WithOne(c => c.Project)
               .HasForeignKey(c => c.ProjectId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
