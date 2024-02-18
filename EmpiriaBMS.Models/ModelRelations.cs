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
        // User Roles
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


        // Project Disciplines
        builder.Entity<Project>()
                    .HasMany(p => p.Disciplines)
                    .WithOne(c => c.Project)
                    .HasForeignKey(c => c.ProjectId);

        // Discipline Draw
        builder.Entity<Project>()
                    .HasMany(p => p.Disciplines)
                    .WithOne(c => c.Project)
                    .HasForeignKey(c => c.ProjectId);

        // Projects Employees
        builder.Entity<DisciplineEngineer>()
               .HasKey(de => new { de.DisciplineId, de.EngineerId });
        builder.Entity<DisciplineEngineer>()
               .HasOne(de => de.Discipline)
               .WithMany(de => de.DisciplineEngineers)
               .HasForeignKey(de => de.DisciplineId);
        builder.Entity<DisciplineEngineer>()
               .HasOne(de => de.Engineer)
               .WithMany(de => de.DisciplineEngineers)
               .HasForeignKey(de => de.EngineerId);

        // ProjectManager Discipline
        builder.Entity<User>()
                    .HasMany(p => p.Disciplines)
                    .WithOne(c => c.ProjectManager)
                    .HasForeignKey(c => c.ProjectManagerId);

        // Project Invoice
        builder.Entity<Project>()
               .HasOne(p => p.Invoice)
               .WithOne(c => c.Project)
               .HasForeignKey<Invoice>(c => c.ProjectId);
    }
}