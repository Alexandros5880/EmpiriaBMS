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
    public DbSet<UserRole> UsersRoles { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Discipline> Disciplines { get; set; }
    public DbSet<Draw> Draws { get; set; }
    public DbSet<Other> Others { get; set; }
    public DbSet<DisciplineEmployee> DisciplinesEmployees { get; set; }
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
        var createdDate = DateTime.Now;

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

        // Create 10 Projects
        List<Project> projects = new List<Project>();
        for (var i = 1; i < 11; i++)
        {
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
                Hours = i * 8,
                DailyHours = 8
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

            // Projects 
            var projectId = random.Next(123456789, 999999999) + i * 2;
            Project project = new Project()
            {
                Id = projectId,
                CreatedDate = createdDate,
                LastUpdatedDate = createdDate,
                Code = "D-22-16" + Convert.ToString(i),
                Name = "Project_" + Convert.ToString(i),
                Description = "Test Description Project_" + Convert.ToString(i * random.Next(1, 7)),
                Drawing = "KL-" + Convert.ToString(i),
                EstimatedMandays = Convert.ToInt64(Math.Pow(i, 3)),
                EstimatedHours = Convert.ToInt64(Math.Pow(i, 3) / 8),
                DurationDate = createdDate.AddMonths(Convert.ToInt32(Math.Pow(i, 2))),
                EstPaymentDate = createdDate.AddMonths(Convert.ToInt32(Math.Pow(i, 2))),
                PaymentDate = createdDate.AddMonths(Convert.ToInt32(Math.Pow(i, 2))),
                DeadLine = createdDate.AddMonths(Convert.ToInt32(Math.Pow(i, 2))),
                WorkPackege = createdDate.AddMonths(Convert.ToInt32(Math.Pow(i, 2))),
                DelayInPayment = Convert.ToInt32(Math.Pow(i, 2)),
                PaymentDetailes = "Payment Detailes For Project_" + Convert.ToString(i * random.Next(1, 7)),
                DayCost = 7 + i - (1 * 2),
                Bank = i % 2 == 0 ? "ALPHA" : "NBG_IBANK",
                PaidFee = 7 - (1 * 2),
                DaysUntilPayment = (createdDate.AddDays(Convert.ToInt32(Math.Pow(i, 2))) - createdDate).Days,
                PendingPayments = i,
                CalculationDaly = i < 5 ? i : i - (i - 1),
                Completed = 0,
                WorkPackegedCompleted = 0,
                ManHours = 0,
                ProjectManagerId = pm.Id
            };
            builder.Entity<Project>().HasData(project);
            projects.Add(project);

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
        }

        // Other Comm
        var otherCommId = random.Next(123456789, 999999999) * 33;
        Other otherComm = new Other()
        {
            Id = otherCommId,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = $"Comm",
            ManHours = 0
        };
        builder.Entity<Other>().HasData(otherComm);

        // Other Printing
        var otherPrintingId = random.Next(123456789, 999999999) * 33;
        Other otherPrinting = new Other()
        {
            Id = otherPrintingId,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = $"Printing",
            ManHours = 0
        };
        builder.Entity<Other>().HasData(otherPrinting);

        // Other Outside
        var otherOutsideId = random.Next(123456789, 999999999) * 33;
        Other otherOutside = new Other()
        {
            Id = otherOutsideId,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = $"Outside",
            ManHours = 0
        };
        builder.Entity<Other>().HasData(otherOutside);

        // OtherMeeting
        var otherMeetingId = random.Next(123456789, 999999999) * 33;
        Other otherMeeting = new Other()
        {
            Id = otherMeetingId,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = $"Meeting",
            ManHours = 0
        };
        builder.Entity<Other>().HasData(otherMeeting);

        // OtherAdministration
        var otherAdministrationId = random.Next(123456789, 999999999) * 33;
        Other otherAdministration = new Other()
        {
            Id = otherAdministrationId,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = $"Administration",
            ManHours = 0
        };
        builder.Entity<Other>().HasData(otherAdministration);

        // Create 5 DraftsMen And 5 Engineers
        List<User> draftsmen = new List<User>();
        for (var i = 0; i <= 5; i++)
        {
            // Draftsmen
            var draftsmanId = random.Next(123456789, 999999999) + i * 13;
            User draftman = new User()
            {
                Id = draftsmanId,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Email = $"draftman{i}@gmail.com",
                LastName = "Alexandros" + Convert.ToString(i),
                FirstName = "Platanios" + Convert.ToString(i),
                Phone1 = "694927778" + Convert.ToString(i),
                Description = "Draftsman " + Convert.ToString(i),
                Hours = i * 8,
                DailyHours = 8
            };
            builder.Entity<User>().HasData(draftman);
            draftsmen.Add(draftman);

            UserRole DraftsmanRole_em = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + i * 2,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = draftsmanId,
                RoleId = role_1_id
            };
            builder.Entity<UserRole>().HasData(DraftsmanRole_em);
        }

        // Create 2 Disciplines For Everu Project
        for (var i = 1; i <= projects.Count; i++)
        {
            for (var j = 1; j < 3; j++)
            {
                // Discipline Engineer
                var engineerId = random.Next(123456789, 999999999) + i * 6 + j;
                User engineer = new User()
                {
                    Id = engineerId,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    Email = $"alexpl_{i + j + 2}@gmail.com",
                    LastName = "Alexandros_" + Convert.ToString(i + j + 2),
                    FirstName = "Platanios_Engineer_" + Convert.ToString(i + j + 2),
                    Phone1 = "694927778" + Convert.ToString(i + j + 2),
                    Description = "Test Description Engineer " + Convert.ToString(i + j + 2),
                    Hours = i * 8,
                    DailyHours = 8
                };
                builder.Entity<User>().HasData(engineer);
                UserRole engineerRole_em = new UserRole()
                {
                    Id = random.Next(123456789, 999999999) + i * 7 + j,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    UserId = engineerId,
                    RoleId = role_2_id
                };
                builder.Entity<UserRole>().HasData(engineerRole_em);

                // Discipline
                var disciplineId = random.Next(123456789, 999999999) + i * 8;
                Discipline discipline = new Discipline()
                {
                    Id = disciplineId,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    Name = j % 2 == 0 ? "HVAC" : "ELEC",
                    ProjectId = projects[i - 1].Id,
                    EngineerId = engineerId,
                    EstimatedHours = 2345,
                    EstimatedMenHours = 3425,
                    Completed = 0
                };
                builder.Entity<Discipline>().HasData(discipline);

                // Connect All Others With Every Disclipline
                DisciplineOther dq_comm = new DisciplineOther()
                {
                    Id = random.Next(123456789, 999999999) + i * 2 + 1 + j,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    DisciplineId = disciplineId,
                    OtherId = otherCommId
                };
                builder.Entity<DisciplineOther>().HasData(dq_comm);
                
                DisciplineOther dq_priting = new DisciplineOther()
                {
                    Id = random.Next(123456789, 999999999) + i * 2 + 1 + j,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    DisciplineId = disciplineId,
                    OtherId = otherPrintingId
                };
                builder.Entity<DisciplineOther>().HasData(dq_priting);
                
                DisciplineOther dq_outside = new DisciplineOther()
                {
                    Id = random.Next(123456789, 999999999) + i * 2 + 1 + j,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    DisciplineId = disciplineId,
                    OtherId = otherOutsideId
                };
                builder.Entity<DisciplineOther>().HasData(dq_outside);
                
                DisciplineOther dq_meeting = new DisciplineOther()
                {
                    Id = random.Next(123456789, 999999999) + i * 2 + 1 + j,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    DisciplineId = disciplineId,
                    OtherId = otherMeetingId
                };
                builder.Entity<DisciplineOther>().HasData(dq_meeting);
                
                DisciplineOther dq_admin = new DisciplineOther()
                {
                    Id = random.Next(123456789, 999999999) + i * 2 + 1 + j,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    DisciplineId = disciplineId,
                    OtherId = otherAdministrationId
                };
                builder.Entity<DisciplineOther>().HasData(dq_admin);

                // Connect Every Draftman With Every Discipline
                foreach(var draftman in draftsmen)
                {
                    DisciplineEmployee de = new DisciplineEmployee()
                    {
                        Id = random.Next(123456789, 999999999) + i * 9,
                        CreatedDate = DateTime.Now,
                        LastUpdatedDate = DateTime.Now,
                        EmployeeId = draftman.Id,
                        DisciplineId = disciplineId
                    };
                    builder.Entity<DisciplineEmployee>().HasData(de);
                }

                // Create 10 Draws For Every Discipline
                for (var e = 1; e < 11; e++)
                {
                    // Draw
                    var dawId = random.Next(123456789, 999999999) + i * 11 + i + j + j;
                    Draw draw = new Draw()
                    {
                        Id = dawId,
                        CreatedDate = DateTime.Now,
                        LastUpdatedDate = DateTime.Now,
                        Name = $"Draw_{i}_{j}",
                        ManHours = 0,
                        CompletionEstimation = 0,
                        CompletionDate = projects[i - 1].DeadLine
                    };
                    builder.Entity<Draw>().HasData(draw);
                    DisciplineDraw dd = new DisciplineDraw()
                    {
                        Id = random.Next(123456789, 999999999) + i * 2 + 1 + j,
                        CreatedDate = DateTime.Now,
                        LastUpdatedDate = DateTime.Now,
                        DisciplineId = disciplineId,
                        DrawId = dawId
                    };
                    builder.Entity<DisciplineDraw>().HasData(dd);
                }
            }
        }

    }

}