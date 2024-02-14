using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models;
public static class ModelRelations
{
    public static void CreateRelations(ModelBuilder builder)
    {
        // UserRoles
        builder.Entity<User>()
            .HasMany(u => u.Roles)
            .WithMany(r => r.Users);
        builder.Entity<Role>()
            .HasMany(u => u.Users)
            .WithMany(r => r.Roles);

        // ProjectEmployee
        builder.Entity<Project>()
            .HasMany(u => u.Employees)
            .WithMany(r => r.Projects);
        builder.Entity<User>()
            .HasMany(u => u.Projects)
            .WithMany(r => r.Employees);

        // Projects Customer
        builder.Entity<Project>()
            .HasOne(u => u.Customer)
            .WithOne(r => r.Project);
        builder.Entity<User>()
            .HasOne(u => u.Project)
            .WithOne(r => r.Customer);

        // Project Invoice
        builder.Entity<Project>()
            .HasOne(u => u.Invoice)
            .WithOne(r => r.Project);
        builder.Entity<Invoice>()
            .HasOne(u => u.Project)
            .WithOne(r => r.Invoice);
    }
}