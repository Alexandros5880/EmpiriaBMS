using EmpiriaBMS.Models;
using EmpiriaMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace EmpiriaBMS.Models.Models;
public class AppDbContext : DbContext
{
    const string SmarterASPNetDB = "Data Source=SQL5106.site4now.net;Initial Catalog=db_a8c181_empiriabms;User Id=db_a8c181_empiriabms_admin;Password=admin1234567";
    const string localhostDB = "Data Source=127.0.0.1,1433;Initial Catalog=empiriabms;User Id=sa;Password=-Plata123456";

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Discipline> Disciplines { get; set; }
    public DbSet<DisciplineType> DisciplineTypes { get; set; }
    public DbSet<Drawing> Drawings { get; set; }
    public DbSet<DrawingType> DrawingTypes { get; set; }
    public DbSet<Other> Others { get; set; }
    public DbSet<OtherType> OtherTypes { get; set; }
    public DbSet<Invoice>? Invoices { get; set; }
    public DbSet<Timespan> TimeSpans { get; set; }
    public DbSet<ProjectType> ProjectType { get; set; }
    public DbSet<DailyHour> DailyHours { get; set; }
    public DbSet<DailyHour> ParsonalTime { get; set; }
    public DbSet<DailyHour> TrainingTime { get; set; }
    public DbSet<DailyHour> CorporateEventTime { get; set; }
    public DbSet<UserRole> UsersRoles { get; set; }
    public DbSet<DrawingEmployee> DrawingsEmployees { get; set; }
    public DbSet<OtherEmployee> OthersEmployees { get; set; }
    public DbSet<ProjectPmanager> ProjectsPmanagers { get; set; }

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
        var role_9_id = random.Next(123456789, 999999999);

        var employes_roles_ids = new List<int>() { role_1_id, role_2_id, role_3_id, role_4_id, role_5_id, role_6_id }.ToArray();

        Role role_1 = new()
        {
            Id = role_1_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Designer",
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

        Role role_9 = new()
        {
            Id = role_9_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Admin",
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
        builder.Entity<Role>().HasData(role_9);

        #region Create Users With Roles:  Admin, CEO, CTO, COO, Guest,
        // Admin
        var adminId = random.Next(123456789, 999999999) + random.Next(0, 33);
        User admin = new User()
        {
            Id = adminId,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Email = $"admin@gmail.com",
            LastName = "Alexandros",
            FirstName = "Platanios",
            Phone1 = "694927778",
            Description = "Admin"
        };
        builder.Entity<User>().HasData(admin);

        UserRole adminRole = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = adminId,
            RoleId = role_9_id
        };
        builder.Entity<UserRole>().HasData(adminRole);

        // CEO
        var ceoId = random.Next(123456789, 999999999) + random.Next(0, 33);
        User ceo = new User()
        {
            Id = ceoId,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Email = $"ceo@gmail.com",
            LastName = "Alexandros",
            FirstName = "Platanios",
            Phone1 = "694927778",
            Description = "CEO"
        };
        builder.Entity<User>().HasData(ceo);

        UserRole ceoRole = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = ceoId,
            RoleId = role_6_id
        };
        builder.Entity<UserRole>().HasData(ceoRole);

        // CTO
        var ctoId = random.Next(123456789, 999999999) + random.Next(0, 33);
        User cto = new User()
        {
            Id = ctoId,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Email = $"cto@gmail.com",
            LastName = "Alexandros",
            FirstName = "Platanios",
            Phone1 = "694927778",
            Description = "CTO"
        };
        builder.Entity<User>().HasData(cto);

        UserRole ctoRole = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = ctoId,
            RoleId = role_5_id
        };
        builder.Entity<UserRole>().HasData(ctoRole);

        // COO
        var cooId = random.Next(123456789, 999999999) + random.Next(0, 33);
        User coo = new User()
        {
            Id = cooId,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Email = $"coo@gmail.com",
            LastName = "Alexandros",
            FirstName = "Platanios",
            Phone1 = "694927778",
            Description = "COO"
        };
        builder.Entity<User>().HasData(coo);

        UserRole cooRole = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = cooId,
            RoleId = role_4_id
        };
        builder.Entity<UserRole>().HasData(cooRole);

        // Guest
        var guestId = random.Next(123456789, 999999999) + random.Next(0, 33);
        User guest = new User()
        {
            Id = guestId,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Email = $"guest@gmail.com",
            LastName = "Alexandros",
            FirstName = "Platanios",
            Phone1 = "694927778",
            Description = "Guest"
        };
        builder.Entity<User>().HasData(guest);

        UserRole guestRole = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = guestId,
            RoleId = role_7_id
        };
        builder.Entity<UserRole>().HasData(guestRole);
        #endregion

        #region Create 5 Draftmen
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
        #endregion

        #region Create 5 Engineer
        List<User> engineers = new List<User>();
        for (var i = 0; i <= 5; i++)
        {
            var engineerId = random.Next(123456789, 999999999) + i * 6 + i;
            User engineer = new User()
            {
                Id = engineerId,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Email = $"engineer_{i}@gmail.com",
                LastName = "Alexandros_" + Convert.ToString(i),
                FirstName = "Platanios_Engineer_" + Convert.ToString(i),
                Phone1 = "694927778" + Convert.ToString(i),
                Description = "Test Description Engineer " + Convert.ToString(i)
            };
            builder.Entity<User>().HasData(engineer);
            engineers.Add(engineer);

            UserRole engineerRole_em = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + i * 7,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = engineerId,
                RoleId = role_2_id
            };
            builder.Entity<UserRole>().HasData(engineerRole_em);
        }
        #endregion

        #region Create 4 Project Types
        // Project Type Buildings
        var project_type_1_Id = random.Next(123456789, 999999999) + 33;
        ProjectType project_type_1 = new ProjectType()
        {
            Id = project_type_1_Id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Buildings",
            Description = "Buildings Description"
        };
        builder.Entity<ProjectType>().HasData(project_type_1);

        // Project Type Infrastructure
        var project_type_2_Id = random.Next(123456789, 999999999) + 33;
        ProjectType project_type_2 = new ProjectType()
        {
            Id = project_type_2_Id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Infrastructure",
            Description = "Infrastructure Description"
        };
        builder.Entity<ProjectType>().HasData(project_type_2);

        // Project Type Energy
        var project_type_3_Id = random.Next(123456789, 999999999) + 33;
        ProjectType project_type_3 = new ProjectType()
        {
            Id = project_type_3_Id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Energy",
            Description = "Energy Description"
        };
        builder.Entity<ProjectType>().HasData(project_type_3);

        // Project Type Consulting
        var project_type_4_Id = random.Next(123456789, 999999999) + 33;
        ProjectType project_type_4 = new ProjectType()
        {
            Id = project_type_4_Id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Consulting",
            Description = "Consulting Description"
        };
        builder.Entity<ProjectType>().HasData(project_type_4);

        int[] projectTypes = {
            project_type_1_Id,
            project_type_2_Id,
            project_type_3_Id,
            project_type_4_Id
        };
        #endregion

        #region Create 4 Project Managers
        List<User> projectManagers = new List<User>();
        for (var i = 1; i <= projectTypes.Count(); i++)
        {
            var pmId = random.Next(123456789, 999999999) + i * 4;
            User pm = new User()
            {
                Id = pmId,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Email = $"pm{i}@gmail.com",
                LastName = "Alexandros_" + Convert.ToString(i),
                FirstName = "Platanios_PM_" + Convert.ToString(i),
                Phone1 = "694927778" + Convert.ToString(i),
                Description = "Test Description PM " + Convert.ToString(i)
            };
            builder.Entity<User>().HasData(pm);
            projectManagers.Add(pm);
            UserRole pmRole_em = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + i * 5,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = pmId,
                RoleId = role_3_id
            };
            builder.Entity<UserRole>().HasData(pmRole_em);
        }
        #endregion

        #region Create 4 Projects
        List<Project> projects = new List<Project>();
        for (var i = 1; i <= projectTypes.Count(); i++)
        {
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
                EstimatedMandays = 100/8,
                EstimatedHours = 100,
                Completed = 0,
                WorkPackegedCompleted = 0,
                EstimatedCompleted = 0,
                TypeId = projectTypes[i-1]
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
        #endregion

        #region Create Discipline Types
        List<DisciplineType> disciplineTypes = new List<DisciplineType>();
        string[] dicTypeNames = { 
            "HVAC", 
            "Sewage", 
            "Potable Water", 
            "Drainage", 
            "Fire Detection", 
            "Fire Suppression",
            "Elevators",
            "Natural Gas",
            "Power Distribution",
            "Structured Cabling",
            "Burglar Alarm",
            "CCTV",
            "BMS",
            "Photovoltaics",
            "Energy Efficiency",
            "Outsource",
            "TenderDocument",
            "Construction Supervision",
        };
        for (var i = 0; i < dicTypeNames.Length; i++)
        {
            var discipline_type_Id = random.Next(123456789, 999999999);
            DisciplineType dt = new DisciplineType()
            {
                Id = discipline_type_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = dicTypeNames[i],
            };
            builder.Entity<DisciplineType>().HasData(dt);
            disciplineTypes.Add(dt);
        }
        #endregion

        #region Create 3 Random Disciplines
        List<Discipline> disciplines = new List<Discipline>();
        for (var i = 0; i < projects.Count; i++)
        {
            // Create 3 Disciplines With Random Type
            List<int> randomTypeIndexes = new List<int>();
            for (int j = 0; j < 3; j++)
            {
                int typeIndex = GetUniqueRandomNumber(random, randomTypeIndexes, 0, disciplineTypes.Count-1);
                var discipline_Id = random.Next(123456789, 999999999) * 8;
                Discipline discipline = new Discipline()
                {
                    Id = discipline_Id,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    TypeId = disciplineTypes[typeIndex].Id,
                    EstimatedHours = 1500,
                    ProjectId = projects[i].Id,
                    Completed = 0
                };
                builder.Entity<Discipline>().HasData(discipline);
                disciplines.Add(discipline);
            }
        }
        #endregion

        #region Create Drawing Types
        List<DrawingType> drawingTypes = new List<DrawingType>();
        string[] drawTypeNames = {
            "Documents",
            "Calculations",
            "Drawings"
        };
        for (var i = 0; i < drawTypeNames.Length; i++)
        {
            var drawing_type_Id = random.Next(123456789, 999999999);
            DrawingType drt = new DrawingType()
            {
                Id = drawing_type_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = drawTypeNames[i],
            };
            builder.Entity<DrawingType>().HasData(drt);
            drawingTypes.Add(drt);
        }
        #endregion

        #region Create Drawings
        List<Drawing> drawings = new List<Drawing>();
        for (var i = 0; i < disciplines.Count; i++)
        {
            for (int j = 0; j < drawingTypes.Count; j++)
            {
                var drawing_Id = random.Next(123456789, 999999999);
                Drawing drawing = new Drawing()
                {
                    Id = drawing_Id,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    TypeId = drawingTypes[j].Id,
                    DisciplineId = disciplines[i].Id,
                    CompletionEstimation = 0,
                    CompletionDate = DateTime.Now.AddDays(11)
                };
                builder.Entity<Drawing>().HasData(drawing);
                drawings.Add(drawing);
            }
        }
        #endregion

        #region Create Other Types
        List<OtherType> otherTypes = new List<OtherType>();
        string[] otherTypeNames = {
            "Communications",
            "Printing",
            "On-Site",
            "Meetings",
            "Administration"
        };
        for (var i = 0; i < otherTypeNames.Length; i++)
        {
            var other_type_Id = random.Next(123456789, 999999999);
            OtherType ort = new OtherType()
            {
                Id = other_type_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = otherTypeNames[i],
            };
            builder.Entity<OtherType>().HasData(ort);
            otherTypes.Add(ort);
        }
        #endregion

        #region Create Others
        List<Other> others = new List<Other>();
        for (var i = 0; i < disciplines.Count; i++)
        {
            for (int j = 0; j < otherTypes.Count; j++)
            {
                var other_Id = random.Next(123456789, 999999999);
                Other other = new Other()
                {
                    Id = other_Id,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    TypeId = otherTypes[j].Id,
                    DisciplineId = disciplines[i].Id,
                    CompletionEstimation = 0
                };
                builder.Entity<Other>().HasData(other);
                others.Add(other);
            }
        }
        #endregion

        #region Connect Project Manager With Every Project
        for (var i = 0; i < projects.Count; i++)
        {
            ProjectPmanager dq_other = new ProjectPmanager()
            {
                Id = random.Next(123456789, 999999999) + i,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                ProjectId = projects[i].Id,
                ProjectManagerId = projectManagers[i].Id
            };
            builder.Entity<ProjectPmanager>().HasData(dq_other);
        }
        #endregion

        #region Connect All Engineers With Every Disclipline
        for (var d = 0; d < disciplines.Count; d++)
        {
            for (var e = 0; e < engineers.Count; e++)
            {
                DisciplineEngineer de = new DisciplineEngineer()
                {
                    Id = random.Next(123456789, 999999999) + d + e,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    DisciplineId = disciplines[d].Id,
                    EngineerId = engineers[e].Id
                };
                builder.Entity<DisciplineEngineer>().HasData(de);
            }
        }
        #endregion

        #region Connect Every Draftman With Every Other
        for (var o = 0; o < others.Count; o++)
        {
            for (var d = 0; d < draftsmen.Count; d++)
            {
                OtherEmployee de_1 = new OtherEmployee()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    EmployeeId = draftsmen[d].Id,
                    OtherId = others[o].Id
                };
                builder.Entity<OtherEmployee>().HasData(de_1);
            }
        }
        #endregion

        #region Connect Every Draftman With Every Drawing
        //for (var o = 0; o < drawings.Count; o++)
        //{
        //    for (var d = 0; d < draftsmen.Count; d++)
        //    {
        //        DrawingEmployee de_1 = new DrawingEmployee()
        //        {
        //            Id = random.Next(123456789, 999999999) * 9,
        //            CreatedDate = DateTime.Now,
        //            LastUpdatedDate = DateTime.Now,
        //            EmployeeId = draftsmen[d].Id,
        //            DrawingId = drawings[o].Id
        //        };
        //        builder.Entity<DrawingEmployee>().HasData(de_1);
        //    }
        //}
        #endregion
    }

    static int GetUniqueRandomNumber(Random random, List<int> selectedNumbers, int min, int max)
    {
        int number;
        do
        {
            number = random.Next(min, max);
        } while (selectedNumbers.Contains(number));

        // Add the selected number to the list
        selectedNumbers.Add(number);
        return number;
    }

}