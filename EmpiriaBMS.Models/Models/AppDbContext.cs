using EmpiriaBMS.Models;
using EmpiriaMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace EmpiriaBMS.Models.Models;
public class AppDbContext : DbContext
{
    const string SmarterASPNetDB = "Data Source=SQL5110.site4now.net;Initial Catalog=db_a8c181_empiriam;User Id=db_a8c181_empiriam_admin;Password=admin1234567";
    const string localhostDB = "Data Source=127.0.0.1,1433;Initial Catalog=empiriabms;User Id=sa;Password=-Plata123456";

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Discipline> Disciplines { get; set; }
    public DbSet<Draw> Draws { get; set; }
    public DbSet<Other> Others { get; set; }
    public DbSet<Invoice>? Invoices { get; set; }

    //public DbSet<DailyHour> DailyHour { get; set; }
    //public DbSet<Timespan> TimeSpan { get; set; }

    public DbSet<UserRole> UsersRoles { get; set; }
    public DbSet<DisciplinePoject> DisciplinesPojects { get; set; }
    public DbSet<DisciplineEmployee> DisciplinesEmployees { get; set; }
    public DbSet<DisciplineDraw> DisciplinesDraws { get; set; }
    public DbSet<DisciplineOther> DisciplinesOthers { get; set; }


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

        var employes_roles_ids = new List<int>() { role_1_id, role_2_id, role_3_id, role_4_id, role_5_id, role_6_id }.ToArray();

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
                Description = "Draftsman " + Convert.ToString(i)
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

        // Create 5 Others
        // Other Communications
        var other_1_Id = random.Next(123456789, 999999999) * 33;
        Other other1 = new Other()
        {
            Id = other_1_Id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = $"Communications",
            CompletionEstimation = 0,
            MenHours = 0
        };
        builder.Entity<Other>().HasData(other1);

        // Other Printing
        var other_2_Id = random.Next(123456789, 999999999) * 33;
        Other other2 = new Other()
        {
            Id = other_2_Id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = $"Printing",
            CompletionEstimation = 0,
            MenHours = 0
        };
        builder.Entity<Other>().HasData(other2);

        // Other On-Site
        var other_3_Id = random.Next(123456789, 999999999) * 33;
        Other other3 = new Other()
        {
            Id = other_3_Id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = $"On-Site",
            CompletionEstimation = 0,
            MenHours = 0
        };
        builder.Entity<Other>().HasData(other3);

        // Other Meetings
        var other_4_Id = random.Next(123456789, 999999999) * 33;
        Other other4 = new Other()
        {
            Id = other_4_Id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = $"Meetings",
            CompletionEstimation = 0,
            MenHours = 0
        };
        builder.Entity<Other>().HasData(other4);

        // other5
        var other_5_Id = random.Next(123456789, 999999999) * 33;
        Other other5 = new Other()
        {
            Id = other_5_Id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = $"Administration",
            CompletionEstimation = 0,
            MenHours = 0
        };
        builder.Entity<Other>().HasData(other5);

        // Create 10 Projects
        List<Project> projects = new List<Project>();
        List<Draw> drawings = new List<Draw>();
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
                Description = "Test Description PM " + Convert.ToString(i + 2)
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
                DayCost = 7 + i - 1 * 2,
                Bank = i % 2 == 0 ? "ALPHA" : "NBG_IBANK",
                PaidFee = 7 - 1 * 2,
                DaysUntilPayment = (createdDate.AddDays(Convert.ToInt32(Math.Pow(i, 2))) - createdDate).Days,
                PendingPayments = i,
                CalculationDaly = i < 5 ? i : i - (i - 1),
                Completed = 0,
                WorkPackegedCompleted = 0,
                MenHours = 0,
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

            // Create 5 Drwaings
            for (var e = 0; e <= 5; e++)
            {
                // Draw
                var dawId = random.Next(123456789, 999999999) + i * 11 + i;
                Draw draw = new Draw()
                {
                    Id = dawId,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    Name = $"Draw_{i}_{e}",
                    MenHours = 0,
                    CompletionEstimation = 0,
                    CompletionDate = projects[i - 1].DeadLine
                };
                builder.Entity<Draw>().HasData(draw);
                drawings.Add(draw);
            }
        }

        // Create 2 Disciplines For Everu Project
        List<Discipline> disciplines = new List<Discipline>();
        for (var i = 1; i < 3; i++)
        {
            // Discipline Engineer
            var engineerId = random.Next(123456789, 999999999) + i * 6 + i;
            User engineer = new User()
            {
                Id = engineerId,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Email = $"alexpl_{i + 2}@gmail.com",
                LastName = "Alexandros_" + Convert.ToString(i + 2),
                FirstName = "Platanios_Engineer_" + Convert.ToString(i + 2),
                Phone1 = "694927778" + Convert.ToString(i + 2),
                Description = "Test Description Engineer " + Convert.ToString(i + 2)
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

            // Discipline
            var disciplineId = random.Next(123456789, 999999999) * 8;
            Discipline discipline = new Discipline()
            {
                Id = disciplineId,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = i % 2 == 0 ? "HVAC" : "ELEC",
                EngineerId = engineerId,
                EstimatedHours = 2345,
                MenHours = 3425,
                Completed = 0
            };
            builder.Entity<Discipline>().HasData(discipline);
            disciplines.Add(discipline);

            // Connect All Others With Every Disclipline
            DisciplineOther dq_other_1 = new DisciplineOther()
            {
                Id = random.Next(123456789, 999999999) + i * 2 + 1,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                DisciplineId = disciplineId,
                OtherId = other_1_Id
            };
            builder.Entity<DisciplineOther>().HasData(dq_other_1);

            DisciplineOther dq_other_2 = new DisciplineOther()
            {
                Id = random.Next(123456789, 999999999) + i * 2 + 1,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                DisciplineId = disciplineId,
                OtherId = other_2_Id
            };
            builder.Entity<DisciplineOther>().HasData(dq_other_2);

            DisciplineOther dq_other_3 = new DisciplineOther()
            {
                Id = random.Next(123456789, 999999999) + i * 2 + 1,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                DisciplineId = disciplineId,
                OtherId = other_3_Id
            };
            builder.Entity<DisciplineOther>().HasData(dq_other_3);

            DisciplineOther dq_other_4 = new DisciplineOther()
            {
                Id = random.Next(123456789, 999999999) + i * 2 + 1,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                DisciplineId = disciplineId,
                OtherId = other_4_Id
            };
            builder.Entity<DisciplineOther>().HasData(dq_other_4);

            DisciplineOther dq_other_5 = new DisciplineOther()
            {
                Id = random.Next(123456789, 999999999) + i * 2 + 1,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                DisciplineId = disciplineId,
                OtherId = other_5_Id
            };
            builder.Entity<DisciplineOther>().HasData(dq_other_5);

            // Connect Every Draftman With Every Discipline
            foreach (var draftman in draftsmen)
            {
                DisciplineEmployee de = new DisciplineEmployee()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    EmployeeId = draftman.Id,
                    DisciplineId = disciplineId
                };
                builder.Entity<DisciplineEmployee>().HasData(de);
            }

            // Connect Every Drwaing With Every Discipline
            for (var e = 0; e < drawings.Count; e++)
            {
                DisciplineDraw dd = new DisciplineDraw()
                {
                    Id = random.Next(123456789, 999999999) + (e + 1) * 2 + 1,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    DisciplineId = disciplineId,
                    DrawId = drawings[e].Id
                };
                builder.Entity<DisciplineDraw>().HasData(dd);
            }
        }

        // Disciplines With Projects 2 Disciplines on Every Project
        foreach (var project in projects)
        {
            foreach (var discipline in disciplines)
            {
                DisciplinePoject disciplinePoject = new DisciplinePoject()
                {
                    Id = random.Next(123456789, 999999999) * random.Next(1, 100),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    DisciplineId = discipline.Id,
                    ProjectId = project.Id
                };
                builder.Entity<DisciplinePoject>().HasData(disciplinePoject);
            }
        }

    }

}