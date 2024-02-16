using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        // Project Employees
        builder.Entity<ProjectEmployee>()
               .HasKey(sc => new { sc.ProjectId, sc.EmployeeId });
        builder.Entity<ProjectEmployee>()
               .HasOne(sc => sc.Project)
               .WithMany(s => s.ProjectEmployees)
               .HasForeignKey(sc => sc.ProjectId);
        builder.Entity<ProjectEmployee>()
               .HasOne(sc => sc.Employee)
               .WithMany(c => c.ProjectEmployees)
               .HasForeignKey(sc => sc.EmployeeId);

        // Project Customer
        builder.Entity<Project>()
               .HasOne(p => p.Customer)
               .WithOne(c => c.Project)
               .HasForeignKey<User>(c => c.ProjectId);

        // Project Invoice
        builder.Entity<Project>()
               .HasOne(p => p.Invoice)
               .WithOne(c => c.Project)
               .HasForeignKey<Invoice>(c => c.ProjectId);
    }
}