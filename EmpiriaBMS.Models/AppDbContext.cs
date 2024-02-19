using EmpiriaBMS.Models;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace EmpiriaMS.Models;
public class AppDbContext : DbContext
{
    const string SmarterASPNetDB = "Data Source=SQL5110.site4now.net;Initial Catalog=db_a8c181_empiriam;User Id=db_a8c181_empiriam_admin;Password=admin1234567";
    const string localhostDB = "Data Source=127.0.0.1,1433;Initial Catalog=empiriabms;User Id=sa;Password=-Plata123456";

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Discipline> Disciplines { get; set; }
    public DbSet<Draw> Draws { get; set; }
    public DbSet<Doc> Docs { get; set; }
    public DbSet<DisciplineEmployee> DisciplinesEngineer { get; set; }

    public DbSet<Invoice>? Invoices { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(localhostDB);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        Random random = new Random();

        // Relations
        ModelRelations.CreateRelations(builder);

        // Roles
        var role_1_id = random.Next(123456789, 999999999);
        var role_2_id = random.Next(123456789, 999999999);
        var role_3_id = random.Next(123456789, 999999999);
        var role_4_id = random.Next(123456789, 999999999);
        var role_5_id = random.Next(123456789, 999999999);
        var role_6_id = random.Next(123456789, 999999999);
        var role_7_id = random.Next(123456789, 999999999);
        var role_8_id = random.Next(123456789, 999999999);

        var employes_roles_ids = (new List<int>(){role_1_id, role_2_id, role_3_id, role_4_id, role_5_id, role_6_id}).ToArray();
        
        Role role_1 = new()
        {
            Id = role_1_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Draftsmen",
            IsEmployee = true,
        };

        Role role_2 = new()
        {
            Id = role_2_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Engineer",
            IsEmployee = true,
        };

        Role role_3 = new()
        {
            Id = role_3_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Project Manager",
            IsEmployee = true,
        };

        Role role_4 = new()
        {
            Id = role_4_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "COO",
            IsEmployee = true,
        };

        Role role_5 = new()
        {
            Id = role_5_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "CTO",
            IsEmployee = true,
        };

        Role role_6 = new()
        {
            Id = role_6_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "CEO",
            IsEmployee = true,
        };

        Role role_7 = new()
        {
            Id = role_7_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Guest",
            IsEmployee = false,
        };

        Role role_8 = new()
        {
            Id = role_8_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Customer",
            IsEmployee = false,
        };

        builder.Entity<Role>().HasData(role_1);
        builder.Entity<Role>().HasData(role_2);
        builder.Entity<Role>().HasData(role_3);
        builder.Entity<Role>().HasData(role_4);
        builder.Entity<Role>().HasData(role_5);
        builder.Entity<Role>().HasData(role_6);
        builder.Entity<Role>().HasData(role_7);
        builder.Entity<Role>().HasData(role_8);

        for (var i = 1; i < 10; i++)
        {
            int drawManHours = i * 3; // 3
            int docManHours = i * 2; // 2
            int estimatedHours = 10 * Convert.ToInt32(Math.Pow(i, 2)); // 10
            int dicliplineHours = drawManHours + docManHours; // 5
            int projectHours = dicliplineHours; // 5
            var projectCompleted = (Convert.ToDecimal(projectHours) / Convert.ToDecimal(estimatedHours)) * 100; // 50%

            // Projects
            var projectId = random.Next(123456789, 999999999) + i * 2;
            var f1 = i + 50 - (i * 3) + (i * 5);
            var f2 = i + 50 - (i * 3) + (i * 4);
            var f3 = i + 50 - (i * 3) + (i * 5) + 1;
            var f4 = i + 3 - (i * 3) + (i * 5) + (i * 2);
            var createdDate = DateTime.Now;
            Project pjk = new Project()
            {
                Id = projectId,
                CreatedDate = createdDate,
                LastUpdatedDate = createdDate,
                Code = "D-22-16" + Convert.ToString(i),
                Name = "Project_" + Convert.ToString(i),
                Description = "Test Description Project_" + Convert.ToString(i * random.Next(1, 7)),
                Drawing = "KL-" + Convert.ToString(i),
                EstimatedMandays = estimatedHours / 8,
                EstimatedHours = estimatedHours,
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
                Completed = Convert.ToInt32(projectCompleted),
                ManHours = projectHours
            };
            builder.Entity<Project>().HasData(pjk);

            // Customers
            var customerId = random.Next(123456789, 999999999) + i * 10;
            User customer = new User()
            {
                Id = customerId,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Email = $"alexpl_{i}@gmail.com",
                LastName = "Alexandros_" + Convert.ToString(i),
                FirstName = "Platanios_Customer_" + Convert.ToString(i),
                Phone1 = "694927778" + Convert.ToString(i),
                Description = "Test Description Customer " + Convert.ToString(i),
                ProjectId = projectId,
            };
            builder.Entity<User>().HasData(customer);
            UserRole userRole_c = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + i * 2,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = customerId,
                RoleId = role_8_id
            };
            builder.Entity<UserRole>().HasData(userRole_c);

            // Invoices
            var invoiceId = random.Next(123456789, 999999999) + i * 3;
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
                Mark = "Signature 14234" + Convert.ToString(i * random.Next(1, 7)),
                ProjectId = projectId,
            };
            builder.Entity<Invoice>().HasData(invoice);

            // Project Manager
            var pmId = random.Next(123456789, 999999999) + i * 4;
            User pm = new User()
            {
                Id = pmId,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Email = $"alexpl_{i + 2_1}@gmail.com",
                LastName = "Alexandros_" + Convert.ToString(i + 2),
                FirstName = "Platanios_PM_" + Convert.ToString(i + 2),
                Phone1 = "694927778" + Convert.ToString(i + 2),
                Description = "Test Description PM " + Convert.ToString(i + 2),
                Hours = i * 8
            };
            builder.Entity<User>().HasData(pm);
            UserRole pmRole_em = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + i * 5,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = pmId,
                RoleId = role_3_id
            };
            builder.Entity<UserRole>().HasData(pmRole_em);

            // Engineers
            var engineerId = random.Next(123456789, 999999999) + i * 6;
            User engineer = new User()
            {
                Id = engineerId,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Email = $"alexpl_{i + 2}@gmail.com",
                LastName = "Alexandros_" + Convert.ToString(i + 2),
                FirstName = "Platanios_Engineer_" + Convert.ToString(i + 2),
                Phone1 = "694927778" + Convert.ToString(i + 2),
                Description = "Test Description Engineer " + Convert.ToString(i + 2),
                Hours = i * 8
            };
            builder.Entity<User>().HasData(engineer);
            UserRole engineerRole_em = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + i * 7,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = engineerId,
                RoleId = role_2_id
            };
            builder.Entity<UserRole>().HasData(engineerRole_em);

            // Draftsmen
            var draftsmenId = random.Next(123456789, 999999999) + i * 13;
            User draftsmen = new User()
            {
                Id = draftsmenId,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Email = $"alexpl_{i + 2}@gmail.com",
                LastName = "Alexandros_" + Convert.ToString(i + 2),
                FirstName = "Platanios_Draftsman_" + Convert.ToString(i + 2),
                Phone1 = "694927778" + Convert.ToString(i + 2),
                Description = "Test Description Draftsman " + Convert.ToString(i + 2),
                Hours = i * 8
            };
            builder.Entity<User>().HasData(draftsmen);
            UserRole DraftsmanRole_em = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + i * 7,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = draftsmenId,
                RoleId = role_1_id
            };
            builder.Entity<UserRole>().HasData(DraftsmanRole_em);

            // Discipline
            var disciplineId = random.Next(123456789, 999999999) + i * 8;
            Discipline discipline = new Discipline()
            {
                Id = disciplineId,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = i % 2 == 0 ? "HVAC" : "ELEC",
                ProjectId = projectId,
                ProjectManagerId = pmId,
                Completed = Convert.ToInt32(projectCompleted)
            };
            builder.Entity<Discipline>().HasData(discipline);

            // Discipline Engineer
            DisciplineEmployee disciplineEngineer_em = new DisciplineEmployee()
            {
                Id = random.Next(123456789, 999999999) + i * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                DisciplineId = disciplineId,
                EmployeeId = engineerId
            };
            builder.Entity<DisciplineEmployee>().HasData(disciplineEngineer_em);

            // Discipline Draftsmen
            DisciplineEmployee disciplineDraftsmen_em = new DisciplineEmployee()
            {
                Id = random.Next(123456789, 999999999) + i * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                DisciplineId = disciplineId,
                EmployeeId = draftsmenId
            };
            builder.Entity<DisciplineEmployee>().HasData(disciplineDraftsmen_em);

            // Draw
            var dawId = random.Next(123456789, 999999999) + i * 11;
            Draw draw = new Draw()
            {
                Id = dawId,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = $"Draw_{i}",
                ManHours = drawManHours,
                DisciplineId = disciplineId,
                Completed = Convert.ToInt32(projectCompleted / 2)
            };
            builder.Entity<Draw>().HasData(draw);

            // Doc
            var docId = random.Next(123456789, 999999999) + i * 12;
            Doc doc = new Doc()
            {
                Id = docId,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = $"Doc_{i}",
                ManHours = docManHours,
                DisciplineId = disciplineId,
                Completed = Convert.ToInt32(projectCompleted / 2)
            };
            builder.Entity<Doc>().HasData(doc);
        }

    }

}