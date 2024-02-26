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

        // Project Desciplines
        builder.Entity<DisciplinePoject>()
               .HasKey(de => new { de.DisciplineId, de.ProjectId });
        builder.Entity<DisciplinePoject>()
               .HasOne(de => de.Discipline)
               .WithMany(de => de.DisciplinesProjects)
               .HasForeignKey(de => de.DisciplineId);
        builder.Entity<DisciplinePoject>()
               .HasOne(de => de.Project)
               .WithMany(de => de.DisciplinesProjects)
               .HasForeignKey(de => de.ProjectId);

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

        // Drawing Employee
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

        // Other Employee
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

        // User DailyHours
        builder.Entity<User>()
                    .HasMany(u => u.DailyHours)
                    .WithOne(d => d.User)
                    .HasForeignKey(d => d.UserId);

        // User ManHours
        builder.Entity<User>()
                    .HasMany(p => p.Hours)
                    .WithOne(c => c.User)
                    .HasForeignKey(c => c.UserId);

        // Project ManHours
        builder.Entity<Project>()
                    .HasMany(p => p.MenHours)
                    .WithOne(c => c.Project)
                    .HasForeignKey(c => c.ProjectId);

        // Discipline ManHours
        builder.Entity<Discipline>()
                    .HasMany(p => p.MenHours)
                    .WithOne(c => c.Discipline)
                    .HasForeignKey(c => c.DisciplineId);

        // Other ManHours
        builder.Entity<Other>()
                    .HasMany(p => p.MenHours)
                    .WithOne(c => c.Other)
                    .HasForeignKey(c => c.OtherId);

        // Drawing ManHours
        builder.Entity<Drawing>()
                    .HasMany(p => p.MenHours)
                    .WithOne(c => c.Drawing)
                    .HasForeignKey(c => c.DrawingId);
    }
}