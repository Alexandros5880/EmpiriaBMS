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
        builder.Entity<DisciplineEmployee>()
               .HasKey(de => new { de.DisciplineId, de.EmployeeId });
        builder.Entity<DisciplineEmployee>()
               .HasOne(de => de.Discipline)
               .WithMany(de => de.DisciplineEmployees)
               .HasForeignKey(de => de.DisciplineId);
        builder.Entity<DisciplineEmployee>()
               .HasOne(de => de.Employee)
               .WithMany(de => de.DisciplineEmployees)
               .HasForeignKey(de => de.EmployeeId);

        // Disciplines Draws
        builder.Entity<DisciplineDraw>()
               .HasKey(de => new { de.DisciplineId, de.DrawId });
        builder.Entity<DisciplineDraw>()
               .HasOne(de => de.Discipline)
               .WithMany(de => de.DisciplinesDraws)
               .HasForeignKey(de => de.DisciplineId);
        builder.Entity<DisciplineDraw>()
               .HasOne(de => de.Draw)
               .WithMany(de => de.DisciplinesDraws)
               .HasForeignKey(de => de.DrawId);

        // Disciplines Others
        builder.Entity<DisciplineOther>()
               .HasKey(de => new { de.DisciplineId, de.OtherId });
        builder.Entity<DisciplineOther>()
               .HasOne(de => de.Discipline)
               .WithMany(de => de.DisciplinesOthers)
               .HasForeignKey(de => de.DisciplineId);
        builder.Entity<DisciplineOther>()
               .HasOne(de => de.Other)
               .WithMany(de => de.DisciplinesOthers)
               .HasForeignKey(de => de.OtherId);

        // Engineer Project
        builder.Entity<User>()
                    .HasMany(p => p.Projects)
                    .WithOne(c => c.ProjectManager)
                    .HasForeignKey(c => c.ProjectManagerId);

        // Engineer Discipline
        builder.Entity<User>()
                    .HasMany(p => p.Disciplines)
                    .WithOne(c => c.Engineer)
                    .HasForeignKey(c => c.EngineerId);

        // Project Invoice
        builder.Entity<Project>()
               .HasOne(p => p.Invoice)
               .WithOne(c => c.Project)
               .HasForeignKey<Invoice>(c => c.ProjectId);
    }
}