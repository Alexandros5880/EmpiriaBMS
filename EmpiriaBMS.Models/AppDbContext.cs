using EmpiriaBMS.Models;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Enums;
using EmpiriaMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace EmpiriaMS.Models;
public class AppDbContext : DbContext
{
    const string SmarterASPNetDB = "Data Source=SQL5110.site4now.net;Initial Catalog=db_a8c181_empiriam;User Id=db_a8c181_empiriam_admin;Password=admin1234567";
    const string localhostDB = "Data Source=127.0.0.1,1433;Initial Catalog=empiriabms;User Id=sa;Password=-Plata123456";
    


    public DbSet<Role>? Roles { get; set; }
    public DbSet<Project>? Projects { get; set; }
    public DbSet<Invoice>? Invoices { get; set; }
    public DbSet<User>? Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.UseSqlServer(localhostDB);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        Random random = new Random();

        // Relations
        ModelRelations.CreateRelations(builder);

        // Roles
        var role_1_id = Guid.NewGuid().ToString("N") + Convert.ToString(1);
        var role_2_id = Guid.NewGuid().ToString("N") + Convert.ToString(2);
        var role_3_id = Guid.NewGuid().ToString("N") + Convert.ToString(3);
        var role_4_id = Guid.NewGuid().ToString("N") + Convert.ToString(4);
        var role_5_id = Guid.NewGuid().ToString("N") + Convert.ToString(5);
        var role_6_id = Guid.NewGuid().ToString("N") + Convert.ToString(6);
        var role_7_id = Guid.NewGuid().ToString("N") + Convert.ToString(7);
        var role_8_id = Guid.NewGuid().ToString("N") + Convert.ToString(8);

        var employes_roles_ids = (new List<string>(){role_1_id, role_2_id, role_3_id, role_4_id, role_5_id, role_6_id}).ToArray();
        
        Role role_1 = new()
        {
            Id = role_1_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Draftsmen"
        };

        Role role_2 = new()
        {
            Id = role_2_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Engineers",
        };

        Role role_3 = new()
        {
            Id = role_3_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Project Managers"
        };

        Role role_4 = new()
        {
            Id = role_4_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "COO"
        };

        Role role_5 = new()
        {
            Id = role_5_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "CTO"
        };

        Role role_6 = new()
        {
            Id = role_6_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "CEO"
        };

        Role role_7 = new()
        {
            Id = role_7_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Guest"
        };

        Role role_8 = new()
        {
            Id = role_8_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Customer"
        };

        builder.Entity<Role>().HasData(role_1);
        builder.Entity<Role>().HasData(role_2);
        builder.Entity<Role>().HasData(role_3);
        builder.Entity<Role>().HasData(role_4);
        builder.Entity<Role>().HasData(role_5);
        builder.Entity<Role>().HasData(role_6);
        builder.Entity<Role>().HasData(role_7);
        builder.Entity<Role>().HasData(role_8);

        for (var i = 0; i < 9; i++)
        {
            // Customers
            var customerId = Guid.NewGuid().ToString("N") + Convert.ToString(i * random.Next(1, 7));
            User customer = new User()
            {
                Id = Convert.ToString(customerId),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Email = $"alexpl_{i}@gmail.com",
                LastName = "Alexandros_" + Convert.ToString(i),
                FirstName = "Platanios_Customer_" + Convert.ToString(i),
                Phone1 = "694927778" + Convert.ToString(i),
                Description = "Test Description Client " + Convert.ToString(i),
            };
            builder.Entity<User>().HasData(customer);
            UserRole userRole_c = new UserRole()
            {
                Id = Guid.NewGuid().ToString("N"),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = customerId,
                RoleId = role_8_id
            };
            builder.Entity<UserRole>().HasData(userRole_c);

            // Employees
            var employeeId = Guid.NewGuid().ToString("N") + Convert.ToString(i * random.Next(1, 7));
            User employee = new User()
            {
                Id = Convert.ToString(employeeId),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Email = $"alexpl_{i + 2}@gmail.com",
                LastName = "Alexandros_" + Convert.ToString(i + 2),
                FirstName = "Platanios_Employee_" + Convert.ToString(i + 2),
                Phone1 = "694927778" + Convert.ToString(i + 2),
                Description = "Test Description Employee " + Convert.ToString(i + 2),
                Hours = i * 8
            };
            builder.Entity<User>().HasData(employee);
            UserRole userRole_em = new UserRole()
            {
                Id = Guid.NewGuid().ToString("N"),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = employeeId,
                RoleId = employes_roles_ids[random.Next(1, 6)]
            };
            builder.Entity<UserRole>().HasData(userRole_em);

            // Invoices
            var invoiceId = Guid.NewGuid().ToString("N") + Convert.ToString(i * random.Next(1,7));
            Invoice invoice = new Invoice()
            {
                Id = invoiceId,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Date = DateTime.Now,
                Total = i * Math.Pow(1, 3),
                Vat = i % 2 == 0 ? 24 : 17,
                Fee = 3000 + Math.Pow(10, i),
                Number = random.Next(10000, 90000),
                Mark = "Signature 14234" + Convert.ToString(i * random.Next(1, 7))
            };
            builder.Entity<Invoice>().HasData(invoice);

            // Projects
            var projectId = Guid.NewGuid().ToString("N") + Convert.ToString(i * random.Next(1, 7));
            var f1 = i + 50 - (i * 3) + (i * 5);
            var f2 = i + 50 - (i * 3) + (i * 4);
            var f3 = i + 50 - (i * 3) + (i * 5) + 1;
            var f4 = i + 3 - (i * 3) + (i * 5) + (i * 2);
            var createdDate = DateTime.Now;
            Project pjk = new Project()
            {
                Id = Convert.ToString(projectId),
                CreatedDate = createdDate,
                LastUpdatedDate = createdDate,
                Code = "D-22-16" + Convert.ToString(i),
                Name = "Project_" + Convert.ToString(i),
                Description = "Test Description Project_" + Convert.ToString(i * random.Next(1, 7)),
                Drawing = "KL-" + Convert.ToString(i),
                PlanType = i % 2 == 0 ? PlanType.ELEC : PlanType.HVAC,
                WorkingDays = i + 200 - (i * 3) + (i * 5),
                DurationDate = createdDate.AddDays(f1),
                EstPaymentDate = createdDate.AddDays(f2),
                PaymentDate = createdDate.AddDays(f3),
                DelayInPayment = f4,
                PaymentDetailes = "Payment Detailes For Project_" + Convert.ToString(i * random.Next(1, 7)),
                DayCost = 7 + i - (1 * 2),
                Bank = i % 2 == 0 ? "ALPHA" : "NBG_IBANK",
                PaidFee = 7 - (1 * 2),
                DaysUntilPayment = (createdDate - createdDate.AddDays(f3)).Days,
                PendingPayments = i,
                CalculationDaly = i < 5 ? i : i - (i - 1),
                Completed = i * 10 < 100 ? i * 10 : 100 - (i * 10),
                ManHours = 4 * i,
                CustomerId = i % 2 == 0 ? customerId : null,
                InvoiceId = invoiceId,
            };
            builder.Entity<Project>().HasData(pjk);

            // Add Employees To Project
            if (i % 2 != 0)
            {
                ProjectEmployee projectEmployee = new ProjectEmployee()
                {
                    Id = Guid.NewGuid().ToString("N") + Convert.ToString(i * random.Next(1, 7)),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    ProjectId = projectId,
                    EmployeeId = employeeId
                };
                builder.Entity<ProjectEmployee>().HasData(projectEmployee);
            }
        }

    }

}