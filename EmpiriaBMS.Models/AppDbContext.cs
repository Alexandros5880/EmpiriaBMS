using EmpiriaMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpiriaMS.Models;
public class AppDbContext : DbContext
{
    const string SmarterASPNetDB = "Data Source=SQL5110.site4now.net;Initial Catalog=db_a8c181_empiriamteemsapp;User Id=db_a8c181_empiriamteemsapp_admin;Password=empiriamteemsapp123456";

    public DbSet<Role>? Roles { get; set; }
    public DbSet<Project>? Projects { get; set; }
    public DbSet<Invoice>? Invoices { get; set; }
    public DbSet<Employee>? Employees { get; set; }
    public DbSet<Customer>? Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer(SmarterASPNetDB);

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        Role role_1 = new()
        {
            Id = "1",
            Name = "Draftsmen",
            Employees = new List<Employee>() { }
        };

        Role role_2 = new()
        {
            Id = "2",
            Name = "Engineers",
            Employees = new List<Employee>() { }
        };

        Role role_3 = new()
        {
            Id = "3",
            Name = "Project Managers",
            Employees = new List<Employee>() { }
        };

        Role role_4 = new()
        {
            Id = "4",
            Name = "COO",
            Employees = new List<Employee>() { }
        };

        Role role_5 = new()
        {
            Id = "5",
            Name = "CTO",
            Employees = new List<Employee>() { }
        };

        Role role_6 = new()
        {
            Id = "6",
            Name = "CEO",
            Employees = new List<Employee>() { }
        };

        builder.Entity<Role>().HasData(role_1);
        builder.Entity<Role>().HasData(role_2);
        builder.Entity<Role>().HasData(role_3);
        builder.Entity<Role>().HasData(role_4);
        builder.Entity<Role>().HasData(role_5);
        builder.Entity<Role>().HasData(role_6);

    }

}