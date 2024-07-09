using EmpiriaBMS.Models.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EmpiriaBMS.Models.Models;
public class AppDbContext : DbContext
{

    //const string SmarterASPNetDB = "Data Source=SQL5106.site4now.net;Initial Catalog=db_a8c181_empiriabms;User Id=db_a8c181_empiriabms_admin;Password=admin1234567";
    const string localhostDB = "Data Source=127.0.0.1,1433;Initial Catalog=empiriabms;User Id=sa;Password=-Plata123456";
    const string azure_staging_DB = "Data Source=empiriabms-staging.database.windows.net;Initial Catalog=EmpiriaBMS-Staging;User Id=admin-user;Password=!@#$123456asdfgh";
    const string migrationsDB = localhostDB;

    public string SelectedConnectionString = string.Empty;
    public string Enviroment = string.Empty;


    public DbSet<User>? Users { get; set; }
    public DbSet<Role>? Roles { get; set; }
    public DbSet<Email>? Emails { get; set; }
    public DbSet<Project>? Projects { get; set; }
    public DbSet<ProjectCategory>? ProjectsCategories { get; set; }
    public DbSet<ProjectSubCategory>? ProjectsSubCategories { get; set; }
    public DbSet<ProjectStage>? ProjectsStages { get; set; }
    public DbSet<Discipline>? Disciplines { get; set; }
    public DbSet<DisciplineType>? DisciplineTypes { get; set; }
    public DbSet<Deliverable>? Deliverables { get; set; }
    public DbSet<DeliverableType>? DeliverableTypes { get; set; }
    public DbSet<SupportiveWork>? SupportiveWorks { get; set; }
    public DbSet<SupportiveWorkType>? SupportiveWorkTypes { get; set; }
    public DbSet<SupportiveWorkEmployee>? SupportiveWorkEmployees { get; set; }
    public DbSet<Invoice>? Invoices { get; set; }
    public DbSet<InvoiceType>? InvoicesTypes { get; set; }
    public DbSet<Contract>? Contracts { get; set; }
    public DbSet<Timespan>? TimeSpans { get; set; }
    public DbSet<DailyTimeRequest>? DailyTimeRequests { get; set; }
    public DbSet<DailyTime>? DailyTime { get; set; }
    public DbSet<DailyTime>? ParsonalTime { get; set; }
    public DbSet<DailyTime>? TrainingTime { get; set; }
    public DbSet<DailyTime>? CorporateEventTime { get; set; }
    public DbSet<Issue>? Issues { get; set; }
    public DbSet<Document>? Documents { get; set; }
    public DbSet<Address>? Address { get; set; }
    public DbSet<Client>? Clients { get; set; }
    public DbSet<Lead>? Leads { get; set; }
    public DbSet<Offer>? Offers { get; set; }
    public DbSet<OfferState>? OffesStates { get; set; }
    public DbSet<OfferType>? OffersTypes { get; set; }
    public DbSet<Payment>? Payments { get; set; }
    public DbSet<PaymentType>? PaymentsTypes { get; set; }
    public DbSet<Permission>? Permissions { get; set; }
    public DbSet<UserRole>? UsersRoles { get; set; }
    public DbSet<RolePermission>? RolesPermissions { get; set; }
    public DbSet<DeliverableEmployee>? DeliverablesEmployees { get; set; }
    public DbSet<ProjectSubConstructor>? ProjectsSubConstructors { get; set; }
    public DbSet<TeamsRequestedUser>? TeamsRequestedUser { get; set; }
    public DbSet<DisciplineEngineer>? DisciplinesEngineers { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Enviroment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        SelectedConnectionString = Environment.GetEnvironmentVariable("ConnectionString") ?? migrationsDB;
        optionsBuilder.UseSqlServer(SelectedConnectionString);
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Error);
        optionsBuilder.EnableSensitiveDataLogging();
        //optionsBuilder.EnableDetailedErrors();
        //optionsBuilder.EnableServiceProviderCaching();
        //optionsBuilder.EnableThreadSafetyChecks();
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Relations
        ModelRelations.CreateRelations(builder);

        Random random = new Random();
        var createdDate = DateTime.Now;

        if (false)
        {
            #region Permissions
            // See Dashboard Layout
            var per_1_id = random.Next(123456789, 999999999);
            Permission per_1 = new Permission()
            {
                Id = per_1_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "See Dashboard Layout",
                Ord = 1
            };
            builder.Entity<Permission>().HasData(per_1);

            // Dashboard Edit My Hours
            var per_2_id = random.Next(123456789, 999999999);
            Permission per_2 = new Permission()
            {
                Id = per_2_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Dashboard Edit My Hours",
                Ord = 2
            };
            builder.Entity<Permission>().HasData(per_2);

            // Dashboard Assign Designer
            var per_3_id = random.Next(123456789, 999999999);
            Permission per_3 = new Permission()
            {
                Id = per_3_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Dashboard Assign Designer",
                Ord = 3
            };
            builder.Entity<Permission>().HasData(per_3);

            // Dashboard Assign Engineer
            var per_4_id = random.Next(123456789, 999999999);
            Permission per_4 = new Permission()
            {
                Id = per_4_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Dashboard Assign Engineer",
                Ord = 4
            };
            builder.Entity<Permission>().HasData(per_4);

            // Dashboard Assign Project Manager
            var per_5_id = random.Next(123456789, 999999999);
            Permission per_5 = new Permission()
            {
                Id = per_5_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Dashboard Assign Project Manager",
                Ord = 5
            };
            builder.Entity<Permission>().HasData(per_5);

            // Dashboard Add Project
            var per_6_id = random.Next(123456789, 999999999);
            Permission per_6 = new Permission()
            {
                Id = per_6_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Dashboard Add Project",
                Ord = 6
            };
            builder.Entity<Permission>().HasData(per_6);

            // See Admin Layout
            var per_7_id = random.Next(123456789, 999999999);
            Permission per_7 = new Permission()
            {
                Id = per_7_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "See Admin Layout",
                Ord = 7
            };
            builder.Entity<Permission>().HasData(per_7);

            // Dashboard See My Hours
            var per_8_id = random.Next(123456789, 999999999);
            Permission per_8 = new Permission()
            {
                Id = per_8_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Dashboard See My Hours",
                Ord = 8
            };
            builder.Entity<Permission>().HasData(per_8);

            // Dashboard See All Disciplines
            var per_9_id = random.Next(123456789, 999999999);
            Permission per_9 = new Permission()
            {
                Id = per_9_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "See All Disciplines",
                Ord = 9
            };
            builder.Entity<Permission>().HasData(per_9);

            // Dashboard See All Deliverables
            var per_10_id = random.Next(123456789, 999999999);
            Permission per_10 = new Permission()
            {
                Id = per_10_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "See All Deliverables",
                Ord = 10
            };
            builder.Entity<Permission>().HasData(per_10);

            // Dashboard See All Projects
            var per_11_id = random.Next(123456789, 999999999);
            Permission per_11 = new Permission()
            {
                Id = per_11_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "See All Projects",
                Ord = 11
            };
            builder.Entity<Permission>().HasData(per_11);

            // Dashboard Edit Project
            var per_12_id = random.Next(123456789, 999999999);
            Permission per_12 = new Permission()
            {
                Id = per_12_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Edit Project On Dashboard",
                Ord = 12
            };
            builder.Entity<Permission>().HasData(per_12);

            // Display Projects Code
            var per_13_id = random.Next(123456789, 999999999);
            Permission per_13 = new Permission()
            {
                Id = per_13_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Display Projects Code",
                Ord = 13
            };
            builder.Entity<Permission>().HasData(per_13);

            // Dashboard Edit Discipline
            var per_14_id = random.Next(123456789, 999999999);
            Permission per_14 = new Permission()
            {
                Id = per_14_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Dashboard Edit Discipline",
                Ord = 14
            };
            builder.Entity<Permission>().HasData(per_14);

            // Dashboard Edit Deliverable
            var per_15_id = random.Next(123456789, 999999999);
            Permission per_15 = new Permission()
            {
                Id = per_15_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Dashboard Edit Deliverable",
                Ord = 15
            };
            builder.Entity<Permission>().HasData(per_15);

            // Dashboard Edit Other
            var per_16_id = random.Next(123456789, 999999999);
            Permission per_16 = new Permission()
            {
                Id = per_16_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Dashboard Edit Other",
                Ord = 16
            };
            builder.Entity<Permission>().HasData(per_16);

            // Dashboard See KPIS
            var per_17_id = random.Next(123456789, 999999999);
            Permission per_17 = new Permission()
            {
                Id = per_17_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Dashboard See KPIS",
                Ord = 17
            };
            builder.Entity<Permission>().HasData(per_17);

            // See Hours Per Role KPI
            var per_18_id = random.Next(123456789, 999999999);
            Permission per_18 = new Permission()
            {
                Id = per_18_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "See Hours Per Role KPI",
                Ord = 18
            };
            builder.Entity<Permission>().HasData(per_18);

            // See Active Delayed Projects KPI
            var per_19_id = random.Next(123456789, 999999999);
            Permission per_19 = new Permission()
            {
                Id = per_19_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "See Active Delayed Projects KPI",
                Ord = 19
            };
            builder.Entity<Permission>().HasData(per_19);

            // See All Projects Missed DeadLine KPI
            var per_20_id = random.Next(123456789, 999999999);
            Permission per_20 = new Permission()
            {
                Id = per_20_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "See All Projects Missed DeadLine KPI",
                Ord = 20
            };
            builder.Entity<Permission>().HasData(per_20);

            // See Employee Turnover KPI
            var per_21_id = random.Next(123456789, 999999999);
            Permission per_21 = new Permission()
            {
                Id = per_21_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "See Employee Turnover KPI",
                Ord = 21
            };
            builder.Entity<Permission>().HasData(per_21);

            // See My Projects Missed DeadLine KPI
            var per_22_id = random.Next(123456789, 999999999);
            Permission per_22 = new Permission()
            {
                Id = per_22_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "See My Projects Missed DeadLine KPI",
                Ord = 22
            };
            builder.Entity<Permission>().HasData(per_22);

            // See Active Delayed Project Types Counter KPI
            var per_23_id = random.Next(123456789, 999999999);
            Permission per_23 = new Permission()
            {
                Id = per_23_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "See Active Delayed Project Types Counter KPI",
                Ord = 23
            };
            builder.Entity<Permission>().HasData(per_23);

            // Dashboard See Offers
            var per_24_id = random.Next(123456789, 999999999);
            Permission per_24 = new Permission()
            {
                Id = per_24_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "See Offers",
                Ord = 24
            };
            builder.Entity<Permission>().HasData(per_24);

            // See Tender Table KPI
            var per_25_id = random.Next(123456789, 999999999);
            Permission per_25 = new Permission()
            {
                Id = per_25_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "See Tender Table KPI",
                Ord = 25
            };
            builder.Entity<Permission>().HasData(per_25);

            // See Delayed Payments KPI
            var per_26_id = random.Next(123456789, 999999999);
            Permission per_26 = new Permission()
            {
                Id = per_26_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "See Delayed Payments KPI",
                Ord = 26
            };
            builder.Entity<Permission>().HasData(per_26);

            // See Pendings Payments KPI
            var per_27_id = random.Next(123456789, 999999999);
            Permission per_27 = new Permission()
            {
                Id = per_27_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "See Pendings Payments KPI",
                Ord = 27
            };
            builder.Entity<Permission>().HasData(per_27);

            // See Teams Requested Users
            var per_28_id = random.Next(123456789, 999999999);
            Permission per_28 = new Permission()
            {
                Id = per_28_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "See Teams Requested Users",
                Ord = 28
            };
            builder.Entity<Permission>().HasData(per_28);

            // See Invoices
            var per_29_id = random.Next(123456789, 999999999);
            Permission per_29 = new Permission()
            {
                Id = per_29_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "See Invoices",
                Ord = 29
            };
            builder.Entity<Permission>().HasData(per_29);

            // See Excpences
            var per_30_id = random.Next(123456789, 999999999);
            Permission per_30 = new Permission()
            {
                Id = per_30_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "See Excpences",
                Ord = 30
            };
            builder.Entity<Permission>().HasData(per_30);

            // Work on Project
            var per_31_id = random.Next(123456789, 999999999);
            Permission per_31 = new Permission()
            {
                Id = per_31_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Work on Project",
                Ord = 31
            };
            builder.Entity<Permission>().HasData(per_31);

            // Work on Offers
            var per_32_id = random.Next(123456789, 999999999);
            Permission per_32 = new Permission()
            {
                Id = per_32_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Work on Offers",
                Ord = 32
            };
            builder.Entity<Permission>().HasData(per_32);

            // Work on Leds
            var per_33_id = random.Next(123456789, 999999999);
            Permission per_33 = new Permission()
            {
                Id = per_33_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Work on Leds",
                Ord = 33
            };
            builder.Entity<Permission>().HasData(per_33);

            // See Next Year Income
            var per_34_id = random.Next(123456789, 999999999);
            Permission per_34 = new Permission()
            {
                Id = per_34_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "See Next Year Income",
                Ord = 34
            };
            builder.Entity<Permission>().HasData(per_34);

            // Backup Database
            var per_35_id = random.Next(123456789, 999999999);
            Permission per_35 = new Permission()
            {
                Id = per_35_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Backup Database",
                Ord = 35
            };
            builder.Entity<Permission>().HasData(per_35);

            // Restore Database
            var per_36_id = random.Next(123456789, 999999999);
            Permission per_36 = new Permission()
            {
                Id = per_36_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Restore Database",
                Ord = 36
            };
            builder.Entity<Permission>().HasData(per_36);

            // Can Change Everybody Hours
            var per_37_id = random.Next(123456789, 999999999);
            Permission per_37 = new Permission()
            {
                Id = per_37_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Can Change Everybody Hours",
                Ord = 37
            };
            builder.Entity<Permission>().HasData(per_37);

            // See Leads On Dashboard
            var per_38_id = random.Next(123456789, 999999999);
            Permission per_38 = new Permission()
            {
                Id = per_38_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "See Leads On Dashboard",
                Ord = 38
            };
            builder.Entity<Permission>().HasData(per_38);
            #endregion

            #region Roles
            // CEO
            var role_6_id = random.Next(123456789, 999999999);
            Role role_6 = new()
            {
                Id = role_6_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "CEO",
                IsEmployee = true,
                IsEditable = false
            };
            builder.Entity<Role>().HasData(role_6);

            // COO
            var role_4_id = random.Next(123456789, 999999999);
            Role role_4 = new()
            {
                Id = role_4_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "COO",
                IsEmployee = true,
                IsEditable = false,
                ParentRoleId = role_6_id
            };
            builder.Entity<Role>().HasData(role_4);

            // CTO
            var role_5_id = random.Next(123456789, 999999999);
            Role role_5 = new()
            {
                Id = role_5_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "CTO",
                IsEmployee = true,
                IsEditable = false,
                ParentRoleId = role_4_id
            };
            builder.Entity<Role>().HasData(role_5);

            // Secretariat
            var role_10_id = random.Next(123456789, 999999999);
            Role role_10 = new()
            {
                Id = role_10_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Secretariat",
                IsEmployee = false,
                IsEditable = false,
                ParentRoleId = role_5_id
            };
            builder.Entity<Role>().HasData(role_10);

            // Project Manager
            var role_3_id = random.Next(123456789, 999999999);
            Role role_3 = new()
            {
                Id = role_3_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Project Manager",
                IsEmployee = true,
                IsEditable = false,
                ParentRoleId = role_5_id
            };
            builder.Entity<Role>().HasData(role_3);

            // Engineer
            var role_2_id = random.Next(123456789, 999999999);
            Role role_2 = new()
            {
                Id = role_2_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Engineer",
                IsEmployee = true,
                IsEditable = false,
                ParentRoleId = role_3_id
            };
            builder.Entity<Role>().HasData(role_2);

            // Designer
            var role_1_id = random.Next(123456789, 999999999);
            Role role_1 = new()
            {
                Id = role_1_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Designer",
                IsEmployee = true,
                IsEditable = false,
                ParentRoleId = role_2_id
            };
            builder.Entity<Role>().HasData(role_1);

            // Guest
            var role_7_id = random.Next(123456789, 999999999);
            Role role_7 = new()
            {
                Id = role_7_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Guest",
                IsEmployee = false,
                IsEditable = false
            };
            builder.Entity<Role>().HasData(role_7);

            // Customer
            var role_8_id = random.Next(123456789, 999999999);
            Role role_8 = new()
            {
                Id = role_8_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Customer",
                IsEmployee = false,
                IsEditable = false
            };
            builder.Entity<Role>().HasData(role_8);

            // Admin
            var role_9_id = random.Next(123456789, 999999999);
            Role role_9 = new()
            {
                Id = role_9_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Admin",
                IsEmployee = false,
                IsEditable = false
            };
            builder.Entity<Role>().HasData(role_9);

            // Engineer SUB
            var role_11_id = random.Next(123456789, 999999999);
            Role role_11 = new()
            {
                Id = role_11_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Engineer SUB",
                IsEmployee = false,
                IsEditable = false
            };
            builder.Entity<Role>().HasData(role_11);
            #endregion

            #region Create Prmissions Roles Connection
            // Designer
            // Designer || See Dashboard Layout
            RolePermission rp_1 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_1_id,
                PermissionId = per_1_id
            };
            builder.Entity<RolePermission>().HasData(rp_1);

            // Designer || Dashboard Edit My Hours
            RolePermission rp_2 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_1_id,
                PermissionId = per_2_id
            };
            builder.Entity<RolePermission>().HasData(rp_2);

            // Designer || Dashboard See My Hours
            RolePermission rp_30 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_1_id,
                PermissionId = per_8_id
            };
            builder.Entity<RolePermission>().HasData(rp_30);


            // Engineer
            // Engineer || See Dashboard Layout
            RolePermission rp_3 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_2_id,
                PermissionId = per_1_id
            };
            builder.Entity<RolePermission>().HasData(rp_3);

            // Engineer || Dashboard Edit My Hours
            RolePermission rp_4 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_2_id,
                PermissionId = per_2_id
            };
            builder.Entity<RolePermission>().HasData(rp_4);

            // Engineer || Dashboard Assign Designer
            RolePermission rp_5 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_2_id,
                PermissionId = per_3_id
            };
            builder.Entity<RolePermission>().HasData(rp_5);

            // Engineer || Dashboard See My Hours
            RolePermission rp_31 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_2_id,
                PermissionId = per_8_id
            };
            builder.Entity<RolePermission>().HasData(rp_31);

            // Engineer || See All Disciplines
            RolePermission rp_35 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_2_id,
                PermissionId = per_9_id
            };
            builder.Entity<RolePermission>().HasData(rp_35);

            // Engineer || See All Deliverables
            RolePermission rp_41 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_2_id,
                PermissionId = per_10_id
            };
            builder.Entity<RolePermission>().HasData(rp_41);


            // Project Manager
            // Project Manager || See Dashboard Layout
            RolePermission rp_6 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_3_id,
                PermissionId = per_1_id
            };
            builder.Entity<RolePermission>().HasData(rp_6);

            // Project Manager || Dashboard Edit My Hours
            RolePermission rp_7 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_3_id,
                PermissionId = per_2_id
            };
            builder.Entity<RolePermission>().HasData(rp_7);

            // Project Manager || Dashboard Assign Engineer
            RolePermission rp_8 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_3_id,
                PermissionId = per_4_id
            };
            builder.Entity<RolePermission>().HasData(rp_8);

            // Project Manager || Dashboard See My Hours
            RolePermission rp_32 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_3_id,
                PermissionId = per_8_id
            };
            builder.Entity<RolePermission>().HasData(rp_32);

            // Project Manager || See All Disciplines
            RolePermission rp_36 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_3_id,
                PermissionId = per_9_id
            };
            builder.Entity<RolePermission>().HasData(rp_36);

            // Project Manager || See All Deliverables
            RolePermission rp_43 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_3_id,
                PermissionId = per_10_id
            };
            builder.Entity<RolePermission>().HasData(rp_43);

            // Project Manager || Dashboard See KPIS
            RolePermission rp_68 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_3_id,
                PermissionId = per_17_id
            };
            builder.Entity<RolePermission>().HasData(rp_68);

            // Project Manager || See My Projects Missed DeadLine KPI
            RolePermission rp_69 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_3_id,
                PermissionId = per_22_id
            };
            builder.Entity<RolePermission>().HasData(rp_69);

            // Project Manager || See Active Delayed Project Types Counter KPI
            RolePermission rp_77 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_3_id,
                PermissionId = per_23_id
            };
            builder.Entity<RolePermission>().HasData(rp_77);


            // COO
            // COO || See Dashboard Layout
            RolePermission rp_9 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_4_id,
                PermissionId = per_1_id
            };
            builder.Entity<RolePermission>().HasData(rp_9);

            // COO || Dashboard Edit My Hours
            RolePermission rp_10 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_4_id,
                PermissionId = per_2_id
            };
            builder.Entity<RolePermission>().HasData(rp_10);

            // COO || Dashboard Assign Designer
            RolePermission rp_11 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_4_id,
                PermissionId = per_3_id
            };
            builder.Entity<RolePermission>().HasData(rp_11);

            // COO || Dashboard Assign Engineer
            RolePermission rp_12 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_4_id,
                PermissionId = per_4_id
            };
            builder.Entity<RolePermission>().HasData(rp_12);

            // COO || Dashboard Assign Project Manager
            RolePermission rp_13 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_4_id,
                PermissionId = per_5_id
            };
            builder.Entity<RolePermission>().HasData(rp_13);

            // COO || Dashboard See My Hours
            RolePermission rp_33 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_4_id,
                PermissionId = per_8_id
            };
            builder.Entity<RolePermission>().HasData(rp_33);

            // COO || See All Disciplines
            RolePermission rp_37 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_4_id,
                PermissionId = per_9_id
            };
            builder.Entity<RolePermission>().HasData(rp_37);

            // COO || See All Deliverables
            RolePermission rp_42 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_4_id,
                PermissionId = per_10_id
            };
            builder.Entity<RolePermission>().HasData(rp_42);

            // COO || See All Projects
            RolePermission rp_49 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_4_id,
                PermissionId = per_11_id
            };
            builder.Entity<RolePermission>().HasData(rp_49);

            // COO || Work on Project
            RolePermission rp_102 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_4_id,
                PermissionId = per_31_id
            };
            builder.Entity<RolePermission>().HasData(rp_102);

            // COO || Work on Offers
            RolePermission rp_103 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_4_id,
                PermissionId = per_32_id
            };
            builder.Entity<RolePermission>().HasData(rp_103);

            // COO || Work on Leds
            RolePermission rp_106 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_4_id,
                PermissionId = per_33_id
            };
            builder.Entity<RolePermission>().HasData(rp_106);

            // COO || See Next Year Income
            RolePermission rp_110 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_4_id,
                PermissionId = per_34_id
            };
            builder.Entity<RolePermission>().HasData(rp_110);


            // CTO
            // CTO || See Dashboard Layout
            RolePermission rp_14 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_1_id
            };
            builder.Entity<RolePermission>().HasData(rp_14);

            // CTO || Dashboard Edit My Hours
            RolePermission rp_15 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_2_id
            };
            builder.Entity<RolePermission>().HasData(rp_15);

            // CTO || Dashboard Assign Designer
            //RolePermission rp_16 = new RolePermission()
            //{
            //    Id = random.Next(123456789, 999999999) * 9,
            //    CreatedDate = DateTime.Now,
            //    LastUpdatedDate = DateTime.Now,
            //    RoleId = role_5_id,
            //    PermissionId = per_3_id
            //};
            //builder.Entity<RolePermission>().HasData(rp_16);

            // CTO || Dashboard Assign Engineer
            //RolePermission rp_17 = new RolePermission()
            //{
            //    Id = random.Next(123456789, 999999999) * 9,
            //    CreatedDate = DateTime.Now,
            //    LastUpdatedDate = DateTime.Now,
            //    RoleId = role_5_id,
            //    PermissionId = per_4_id
            //};
            //builder.Entity<RolePermission>().HasData(rp_17);

            // CTO || Dashboard Assign Project Manager
            RolePermission rp_18 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_5_id
            };
            builder.Entity<RolePermission>().HasData(rp_18);

            // CTO || Dashboard Add Project
            RolePermission rp_19 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_6_id
            };
            builder.Entity<RolePermission>().HasData(rp_19);

            // CTO || Dashboard See My Hours
            RolePermission rp_34 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_8_id
            };
            builder.Entity<RolePermission>().HasData(rp_34);

            // CTO || See All Disciplines
            RolePermission rp_38 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_9_id
            };
            builder.Entity<RolePermission>().HasData(rp_38);

            // CTO || See All Deliverables
            RolePermission rp_45 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_10_id
            };
            builder.Entity<RolePermission>().HasData(rp_45);

            // CTO || See All Projects
            RolePermission rp_48 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_11_id
            };
            builder.Entity<RolePermission>().HasData(rp_48);

            // CTO || Dashboard Edit Project
            RolePermission rp_60 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_12_id
            };
            builder.Entity<RolePermission>().HasData(rp_60);

            // CTO || Dashboard Edit Discipline
            RolePermission rp_63 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_14_id
            };
            builder.Entity<RolePermission>().HasData(rp_63);

            // CTO || Dashboard Edit Deliverable
            RolePermission rp_64 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_15_id
            };
            builder.Entity<RolePermission>().HasData(rp_64);

            // CTO || Dashboard Edit Other
            RolePermission rp_65 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_16_id
            };
            builder.Entity<RolePermission>().HasData(rp_65);

            // CTO || Dashboard See KPIS
            RolePermission rp_66 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_17_id
            };
            builder.Entity<RolePermission>().HasData(rp_66);

            // CTO || See Hours Per Role KPI
            RolePermission rp_70 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_18_id
            };
            builder.Entity<RolePermission>().HasData(rp_70);

            // CTO || See Active Delayed Projects KPI
            RolePermission rp_71 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_19_id
            };
            builder.Entity<RolePermission>().HasData(rp_71);

            // CTO || See All Projects Missed DeadLine KPI
            RolePermission rp_72 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_20_id
            };
            builder.Entity<RolePermission>().HasData(rp_72);

            // CTO || See Active Delayed Project Types Counter KPI
            RolePermission rp_78 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_23_id
            };
            builder.Entity<RolePermission>().HasData(rp_78);

            // CTO || Display Projects Code
            RolePermission rp_80 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_13_id
            };
            builder.Entity<RolePermission>().HasData(rp_80);

            // CTO || See Offers
            RolePermission rp_81 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_24_id
            };
            builder.Entity<RolePermission>().HasData(rp_81);

            // CTO || See Tender Table KPI
            RolePermission rp_83 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_25_id
            };
            builder.Entity<RolePermission>().HasData(rp_83);

            // CTO || See Delayed Payments KPI
            RolePermission rp_85 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_26_id
            };
            builder.Entity<RolePermission>().HasData(rp_85);

            // CTO || See Pendings Payments KPI
            RolePermission rp_87 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_27_id
            };
            builder.Entity<RolePermission>().HasData(rp_87);

            // CTO || See Invoices
            RolePermission rp_91 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_29_id
            };
            builder.Entity<RolePermission>().HasData(rp_91);

            // CTO || See Excpences
            RolePermission rp_92 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_30_id
            };
            builder.Entity<RolePermission>().HasData(rp_92);

            // CTO || Work on Project
            RolePermission rp_101 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_31_id
            };
            builder.Entity<RolePermission>().HasData(rp_101);

            // CTO || Work on Offers
            RolePermission rp_104 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_32_id
            };
            builder.Entity<RolePermission>().HasData(rp_104);

            // CTO || Work on Leds
            RolePermission rp_107 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_33_id
            };
            builder.Entity<RolePermission>().HasData(rp_107);

            // CTO || See Next Year Income
            RolePermission rp_111 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_34_id
            };
            builder.Entity<RolePermission>().HasData(rp_111);

            // CTO || Backup Database
            RolePermission rp_113 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_35_id
            };
            builder.Entity<RolePermission>().HasData(rp_113);

            // CTO || Restore Database
            RolePermission rp_114 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_36_id
            };
            builder.Entity<RolePermission>().HasData(rp_114);

            // CTO || See Leads On Dashboard
            RolePermission rp_122 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_5_id,
                PermissionId = per_38_id
            };
            builder.Entity<RolePermission>().HasData(rp_122);


            // CEO
            // CEO || See Dashboard Layout
            RolePermission rp_20 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_1_id
            };
            builder.Entity<RolePermission>().HasData(rp_20);

            // CEO || Dashboard Edit My Hours
            RolePermission rp_21 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_2_id
            };
            builder.Entity<RolePermission>().HasData(rp_21);

            // CEO || Dashboard Assign Designer
            RolePermission rp_22 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_3_id
            };
            builder.Entity<RolePermission>().HasData(rp_22);

            // CEO || Dashboard Assign Engineer
            RolePermission rp_23 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_4_id
            };
            builder.Entity<RolePermission>().HasData(rp_23);

            // CEO || Dashboard Assign Project Manager
            RolePermission rp_24 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_5_id
            };
            builder.Entity<RolePermission>().HasData(rp_24);

            // CEO || Dashboard Add Project
            RolePermission rp_25 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_6_id
            };
            builder.Entity<RolePermission>().HasData(rp_25);

            // CEO || See Admin Layout
            //RolePermission rp_26 = new RolePermission()
            //{
            //    Id = random.Next(123456789, 999999999) * 9,
            //    CreatedDate = DateTime.Now,
            //    LastUpdatedDate = DateTime.Now,
            //    RoleId = role_6_id,
            //    PermissionId = per_7_id
            //};
            //builder.Entity<RolePermission>().HasData(rp_26);

            // CEO || See All Disciplines
            RolePermission rp_39 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_9_id
            };
            builder.Entity<RolePermission>().HasData(rp_39);

            // CEO || See All Deliverable
            RolePermission rp_44 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_10_id
            };
            builder.Entity<RolePermission>().HasData(rp_44);

            // CEO || See All Projects
            RolePermission rp_47 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_11_id
            };
            builder.Entity<RolePermission>().HasData(rp_47);

            // CEO || Display Projects Code
            RolePermission rp_61 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_13_id
            };
            builder.Entity<RolePermission>().HasData(rp_61);

            // CEO || Dashboard Add Project
            RolePermission rp_62 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_12_id
            };
            builder.Entity<RolePermission>().HasData(rp_62);

            // CEO || Dashboard See KPIS
            RolePermission rp_67 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_17_id
            };
            builder.Entity<RolePermission>().HasData(rp_67);

            // CEO || See Hours Per Role KPI
            RolePermission rp_73 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_18_id
            };
            builder.Entity<RolePermission>().HasData(rp_73);

            // CEO || See Active Delayed Projects KPI
            RolePermission rp_74 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_19_id
            };
            builder.Entity<RolePermission>().HasData(rp_74);

            // CEO || See All Projects Missed DeadLine KPI
            RolePermission rp_75 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_20_id
            };
            builder.Entity<RolePermission>().HasData(rp_75);

            // CEO || See Employee Turnover KPI
            RolePermission rp_76 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_21_id
            };
            builder.Entity<RolePermission>().HasData(rp_76);

            // CEO || See Active Delayed Project Types Counter KPI
            RolePermission rp_79 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_23_id
            };
            builder.Entity<RolePermission>().HasData(rp_79);

            // CEO || See Offers
            RolePermission rp_82 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_24_id
            };
            builder.Entity<RolePermission>().HasData(rp_82);

            // CEO || See Tender Table KPI
            RolePermission rp_84 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_25_id
            };
            builder.Entity<RolePermission>().HasData(rp_84);

            // CEO || See Delayed Payments KPI
            RolePermission rp_86 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_26_id
            };
            builder.Entity<RolePermission>().HasData(rp_86);

            // CEO || See Pendings Payments KPI
            RolePermission rp_88 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_27_id
            };
            builder.Entity<RolePermission>().HasData(rp_88);

            // CEO || See Teams Requested Users
            RolePermission rp_90 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_28_id
            };
            builder.Entity<RolePermission>().HasData(rp_90);

            // CEO || See Invoices
            RolePermission rp_93 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_29_id
            };
            builder.Entity<RolePermission>().HasData(rp_93);

            // CEO || See Excpences
            RolePermission rp_94 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_30_id
            };
            builder.Entity<RolePermission>().HasData(rp_94);

            // CEO || Work on Project
            RolePermission rp_105 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_31_id
            };
            builder.Entity<RolePermission>().HasData(rp_105);

            // CEO || Work on Offers
            RolePermission rp_108 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_32_id
            };
            builder.Entity<RolePermission>().HasData(rp_108);

            // CEO || Work on Leds
            RolePermission rp_109 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_33_id
            };
            builder.Entity<RolePermission>().HasData(rp_109);

            // CEO || See Next Year Income
            RolePermission rp_112 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_34_id
            };
            builder.Entity<RolePermission>().HasData(rp_112);

            // CEO || Backup Database
            RolePermission rp_115 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_35_id
            };
            builder.Entity<RolePermission>().HasData(rp_115);

            // CEO || Restore Database
            RolePermission rp_116 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_36_id
            };
            builder.Entity<RolePermission>().HasData(rp_116);

            // CTO || See Leads On Dashboard
            RolePermission rp_123 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_6_id,
                PermissionId = per_38_id
            };
            builder.Entity<RolePermission>().HasData(rp_123);


            // Guest
            // Guest || See Dashboard Layout
            RolePermission rp_27 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_7_id,
                PermissionId = per_1_id
            };
            builder.Entity<RolePermission>().HasData(rp_27);


            // Customer
            // Customer || See Dashboard Layout
            RolePermission rp_28 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_8_id,
                PermissionId = per_1_id
            };
            builder.Entity<RolePermission>().HasData(rp_28);


            // Admin
            // Admin || See Dashboard Layout
            RolePermission rp_29 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_9_id,
                PermissionId = per_7_id
            };
            builder.Entity<RolePermission>().HasData(rp_29);

            // Admin || See All Disciplines
            RolePermission rp_40 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_9_id,
                PermissionId = per_9_id
            };
            builder.Entity<RolePermission>().HasData(rp_40);

            // Admin || See All Deliverables
            RolePermission rp_46 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_9_id,
                PermissionId = per_10_id
            };
            builder.Entity<RolePermission>().HasData(rp_46);

            // Admin || See All Projects
            RolePermission rp_50 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_9_id,
                PermissionId = per_11_id
            };
            builder.Entity<RolePermission>().HasData(rp_50);

            // Admin || See Teams Requested Users
            RolePermission rp_100 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_9_id,
                PermissionId = per_28_id
            };
            builder.Entity<RolePermission>().HasData(rp_100);

            // Admin || Backup Database
            RolePermission rp_117 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_9_id,
                PermissionId = per_35_id
            };
            builder.Entity<RolePermission>().HasData(rp_117);

            // Admin || Restore Database
            RolePermission rp_118 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_9_id,
                PermissionId = per_36_id
            };
            builder.Entity<RolePermission>().HasData(rp_118);

            // Admin || Can Change Everybody Hours
            RolePermission rp_121 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_9_id,
                PermissionId = per_37_id
            };
            builder.Entity<RolePermission>().HasData(rp_121);


            // Secretariat 
            // Secretariat || See Dashboard Layout
            RolePermission rp_51 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_10_id,
                PermissionId = per_1_id
            };
            builder.Entity<RolePermission>().HasData(rp_51);

            // Secretariat || Dashboard Edit My Hours
            RolePermission rp_52 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_10_id,
                PermissionId = per_2_id
            };
            builder.Entity<RolePermission>().HasData(rp_52);

            // Secretariat || Dashboard See My Hours
            RolePermission rp_56 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_10_id,
                PermissionId = per_8_id
            };
            builder.Entity<RolePermission>().HasData(rp_56);

            // Secretariat || See All Disciplines
            RolePermission rp_57 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_10_id,
                PermissionId = per_9_id
            };
            builder.Entity<RolePermission>().HasData(rp_57);

            // Secretariat || See All Deliverables
            RolePermission rp_58 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_10_id,
                PermissionId = per_10_id
            };
            builder.Entity<RolePermission>().HasData(rp_58);

            // Secretariat || See All Projects
            RolePermission rp_59 = new RolePermission()
            {
                Id = random.Next(123456789, 999999999) * 9,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                RoleId = role_10_id,
                PermissionId = per_11_id
            };
            builder.Entity<RolePermission>().HasData(rp_59);
            #endregion

            #region Create Admins
            // Alexandros Platanios
            var admin_1_Id = random.Next(123456789, 999999999) + random.Next(0, 333) + 10;
            User admin_1 = new User()
            {
                Id = admin_1_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                LastName = "Platanios",
                FirstName = "Alexandros",
                Phone1 = "694927778",
                Description = "Admin",
                ProxyAddress = "empiriasoft@empiriasoftplat.onmicrosoft.com"
            };
            builder.Entity<User>().HasData(admin_1);
            Email email_admin_1 = new Email()
            {
                Id = random.Next(123456789, 999999999) + random.Next(0, 33),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Address = "empiriasoft@empiriasoftplat.onmicrosoft.com",
                UserId = admin_1_Id
            };
            builder.Entity<Email>().HasData(email_admin_1);
            // Admin
            UserRole admin_role_1 = new UserRole()
            {
                Id = random.Next(123456789, 999999999) / 3,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = admin_1_Id,
                RoleId = role_9_id
            };
            builder.Entity<UserRole>().HasData(admin_role_1);
            #endregion

            #region Create 4 Project Categories
            List<ProjectCategory> projectCategories = new List<ProjectCategory>();

            var project_category_1_Id = random.Next(123456789, 999999999) + 33;
            ProjectCategory project_category_1 = new ProjectCategory()
            {
                Id = project_category_1_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "BUILDINGS",
                Description = "Buildings Description",
                CanAssignePM = true
            };
            builder.Entity<ProjectCategory>().HasData(project_category_1);
            projectCategories.Add(project_category_1);

            var project_category_2_Id = random.Next(123456789, 999999999) + 33;
            ProjectCategory project_category_2 = new ProjectCategory()
            {
                Id = project_category_2_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "INFRASTRUCTURE",
                Description = "Infrastructure Description",
                CanAssignePM = true
            };
            builder.Entity<ProjectCategory>().HasData(project_category_2);
            projectCategories.Add(project_category_2);

            var project_category_3_Id = random.Next(123456789, 999999999) + 33;
            ProjectCategory project_category_3 = new ProjectCategory()
            {
                Id = project_category_3_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "ENERGY",
                Description = "Energy Description",
                CanAssignePM = true
            };
            builder.Entity<ProjectCategory>().HasData(project_category_3);
            projectCategories.Add(project_category_3);

            var project_category_4_Id = random.Next(123456789, 999999999) + 33;
            ProjectCategory project_category_4 = new ProjectCategory()
            {
                Id = project_category_4_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "CONSULTING",
                Description = "Consulting Description",
                CanAssignePM = true
            };
            builder.Entity<ProjectCategory>().HasData(project_category_4);
            projectCategories.Add(project_category_4);

            var project_category_5_Id = random.Next(123456789, 999999999) + 34;
            ProjectCategory project_category_5 = new ProjectCategory()
            {
                Id = project_category_5_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "PRODUCTION MANAGMENT",
                Description = "Production Management Description",
                CanAssignePM = false
            };
            builder.Entity<ProjectCategory>().HasData(project_category_5);
            projectCategories.Add(project_category_5);

            var project_category_6_Id = random.Next(123456789, 999999999) + 34;
            ProjectCategory project_category_6 = new ProjectCategory()
            {
                Id = project_category_6_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "TRANSPORT",
                Description = "Transport Description",
                CanAssignePM = false
            };
            builder.Entity<ProjectCategory>().HasData(project_category_6);
            projectCategories.Add(project_category_6);

            var project_category_7_Id = random.Next(123456789, 999999999) + 34;
            ProjectCategory project_category_7 = new ProjectCategory()
            {
                Id = project_category_7_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "ENVIRONMENT",
                Description = "Environment Description",
                CanAssignePM = false
            };
            builder.Entity<ProjectCategory>().HasData(project_category_7);
            projectCategories.Add(project_category_7);

            var project_category_8_Id = random.Next(123456789, 999999999) + 34;
            ProjectCategory project_category_8 = new ProjectCategory()
            {
                Id = project_category_8_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "ENVIRONMENT CONSULTING",
                Description = "Environment Consulting Description",
                CanAssignePM = false
            };
            builder.Entity<ProjectCategory>().HasData(project_category_8);
            projectCategories.Add(project_category_8);
            #endregion

            #region Create Project Sub Categories
            /*
                * projectCategories[0] = BUILDINGS
                * projectCategories[1] = INFRASTRUCTURE
                * projectCategories[2] = ENERGY
                * projectCategories[3] = CONSULTING
                * projectCategories[4] = PRODUCTION MANAGMENT
                * projectCategories[5] = TRANSPORT
                * projectCategories[6] = ENVIRONMENT
                * projectCategories[7] = ENVIRONMENT CONSULTING
                */
            Dictionary<string, ProjectCategory> ProjectSubCatsNameCat = new Dictionary<string, ProjectCategory>();
            ProjectSubCatsNameCat.Add("RENEWABLES - INTERCONNECTION HV", projectCategories[0]);
            ProjectSubCatsNameCat.Add("RENEWABLES - INTERCONNECTION", projectCategories[1]);
            ProjectSubCatsNameCat.Add("RENEWABLES - PV", projectCategories[2]);
            ProjectSubCatsNameCat.Add("RENEWABLES - PV - TDD", projectCategories[3]);
            ProjectSubCatsNameCat.Add("RENEWABLES - PV - CONSTRUCTION SUPERVISION", projectCategories[4]);
            ProjectSubCatsNameCat.Add("RENEWABLES - WIND", projectCategories[5]);
            ProjectSubCatsNameCat.Add("RENEWABLES - HYDRO", projectCategories[6]);
            ProjectSubCatsNameCat.Add("POWER PLANTS - PIPELINES", projectCategories[7]);
            ProjectSubCatsNameCat.Add("DISTRIBUTION NETWORKS", projectCategories[0]);
            ProjectSubCatsNameCat.Add("NATURAL GAS", projectCategories[1]);
            ProjectSubCatsNameCat.Add("ENERGY AUDITS & CONSULTING", projectCategories[2]);
            ProjectSubCatsNameCat.Add("FIRE SAFETY", projectCategories[3]);
            ProjectSubCatsNameCat.Add("OFFICE BUILDINGS", projectCategories[4]);
            ProjectSubCatsNameCat.Add("BANKS", projectCategories[5]);
            ProjectSubCatsNameCat.Add("MALLS, SHOPPING CENTRES, BARS etc", projectCategories[6]);
            ProjectSubCatsNameCat.Add("INDUSTRIAL", projectCategories[7]);
            ProjectSubCatsNameCat.Add("RESIDENTIAL", projectCategories[0]);
            ProjectSubCatsNameCat.Add("HOTELS", projectCategories[1]);
            ProjectSubCatsNameCat.Add("ENERGY CERTIFICATES", projectCategories[2]);
            ProjectSubCatsNameCat.Add("CAR STATIONS", projectCategories[3]);
            ProjectSubCatsNameCat.Add("SCHOOLS & UNIVERSITIES", projectCategories[4]);
            ProjectSubCatsNameCat.Add("SPORT CENTRES", projectCategories[5]);
            ProjectSubCatsNameCat.Add("HOSPITALS & WELFARE", projectCategories[6]);
            ProjectSubCatsNameCat.Add("PUBLIC BUILDINGS", projectCategories[7]);
            ProjectSubCatsNameCat.Add("RESTORATIONS - SQUARES", projectCategories[0]);
            ProjectSubCatsNameCat.Add("MUSEUMS & CULTURAL BUILDINGS", projectCategories[1]);
            ProjectSubCatsNameCat.Add("DATA CENTERS", projectCategories[2]);
            ProjectSubCatsNameCat.Add("BUILDINGS GENERAL", projectCategories[3]);
            ProjectSubCatsNameCat.Add("ROAD NETWORKS", projectCategories[4]);
            ProjectSubCatsNameCat.Add("TOLL STATIONS & BUILDINGS", projectCategories[5]);
            ProjectSubCatsNameCat.Add("TRAIN STATIONS", projectCategories[6]);
            ProjectSubCatsNameCat.Add("TUNNELS", projectCategories[7]);
            ProjectSubCatsNameCat.Add("BUS STATIONS", projectCategories[0]);
            ProjectSubCatsNameCat.Add("PORTS, MARINAS & PORT TERMINALS", projectCategories[1]);
            ProjectSubCatsNameCat.Add("AIRPORTS & TERMINALS", projectCategories[2]);
            ProjectSubCatsNameCat.Add("SUBWAYS & STATIONS", projectCategories[3]);
            ProjectSubCatsNameCat.Add("TRASPORT GENERAL", projectCategories[4]);
            ProjectSubCatsNameCat.Add("WASTE WATER TREATMENT", projectCategories[5]);
            ProjectSubCatsNameCat.Add("RECYCLING & LANDFILL PLANTS", projectCategories[6]);
            ProjectSubCatsNameCat.Add("DAMS", projectCategories[7]);
            ProjectSubCatsNameCat.Add("SEWAGE AND DRAINAGE NETWORKS", projectCategories[0]);
            ProjectSubCatsNameCat.Add("ENVIRONMENTAL STUDIES", projectCategories[1]);
            ProjectSubCatsNameCat.Add("LEGALIZATION PROCEDURES", projectCategories[2]);
            ProjectSubCatsNameCat.Add("PROPERTY EVALUATIONS", projectCategories[3]);
            ProjectSubCatsNameCat.Add("EU PROJECTS", projectCategories[4]);
            ProjectSubCatsNameCat.Add("ENGINEERING CONSULTING - GENERAL", projectCategories[5]);

            List<ProjectSubCategory> projectSubCategories = new List<ProjectSubCategory>();

            foreach (var item in ProjectSubCatsNameCat)
            {
                string subCatName = item.Key;
                int catId = item.Value.Id;
                var canAssignePM = item.Value.CanAssignePM;

                var project_sub_category_id = random.Next(123456789, 999999999) + 33;
                ProjectSubCategory project_sub_category = new ProjectSubCategory()
                {
                    Id = project_sub_category_id,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    Name = subCatName,
                    CategoryId = catId,
                    CanAssignePM = canAssignePM
                };
                builder.Entity<ProjectSubCategory>().HasData(project_sub_category);
                projectSubCategories.Add(project_sub_category);
            }
            #endregion

            #region Create ProjectStages
            var project_stage_1_Id = random.Next(123456789, 999999999) + 33;
            ProjectStage project_stage_1 = new ProjectStage()
            {
                Id = project_stage_1_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Buildings",
            };
            builder.Entity<ProjectStage>().HasData(project_stage_1);

            var project_stage_2_Id = random.Next(123456789, 999999999) + 33;
            ProjectStage project_stage_2 = new ProjectStage()
            {
                Id = project_stage_2_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Final Design",
            };
            builder.Entity<ProjectStage>().HasData(project_stage_2);

            var project_stage_3_Id = random.Next(123456789, 999999999) + 33;
            ProjectStage project_stage_3 = new ProjectStage()
            {
                Id = project_stage_3_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Detailed Design",
            };
            builder.Entity<ProjectStage>().HasData(project_stage_3);

            var project_stage_4_Id = random.Next(123456789, 999999999) + 33;
            ProjectStage project_stage_4 = new ProjectStage()
            {
                Id = project_stage_4_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Construction Supervision",
            };
            builder.Entity<ProjectStage>().HasData(project_stage_4);

            var project_stage_5_Id = random.Next(123456789, 999999999) + 33;
            ProjectStage project_stage_5 = new ProjectStage()
            {
                Id = project_stage_5_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Us Build Joins",
            };
            builder.Entity<ProjectStage>().HasData(project_stage_5);



            int[] ProjectStages = {
                project_stage_1_Id,
                project_stage_2_Id,
                project_stage_3_Id,
                project_stage_4_Id,
                project_stage_5_Id
            };
            #endregion

            #region Create InvoiceTypes
            var it_1_id = random.Next(123456789, 999999999) + random.Next(0, 333) + 10;
            InvoiceType it_1 = new InvoiceType()
            {
                Id = it_1_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "PUBLIC"
            };
            builder.Entity<InvoiceType>().HasData(it_1);

            var it_2_id = random.Next(123456789, 999999999) + random.Next(0, 333) + 10;
            InvoiceType it_2 = new InvoiceType()
            {
                Id = it_2_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "PRIVATE"
            };
            builder.Entity<InvoiceType>().HasData(it_2);

            var it_3_id = random.Next(123456789, 999999999) + random.Next(0, 333) + 10;
            InvoiceType it_3 = new InvoiceType()
            {
                Id = it_3_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "INTERNATIONAL"
            };
            builder.Entity<InvoiceType>().HasData(it_3);
            #endregion

            #region Create 5 PaymentTypes
            // BANK
            var pmt_1_id = random.Next(123456789, 999999999) + random.Next(0, 333) + 55;
            PaymentType pmt_1 = new PaymentType()
            {
                Id = pmt_1_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = $"BANK"
            };
            builder.Entity<PaymentType>().HasData(pmt_1);

            // TRANSFER
            var pmt_2_id = random.Next(123456789, 999999999) + random.Next(0, 333) + 55;
            PaymentType pmt_2 = new PaymentType()
            {
                Id = pmt_2_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = $"TRANSFER"
            };
            builder.Entity<PaymentType>().HasData(pmt_2);

            // CASH
            var pmt_3_id = random.Next(123456789, 999999999) + random.Next(0, 333) + 55;
            PaymentType pmt_3 = new PaymentType()
            {
                Id = pmt_3_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = $"CASH"
            };
            builder.Entity<PaymentType>().HasData(pmt_3);

            // CHECK
            var pmt_4_id = random.Next(123456789, 999999999) + random.Next(0, 333) + 55;
            PaymentType pmt_4 = new PaymentType()
            {
                Id = pmt_4_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = $"CHECK"
            };
            builder.Entity<PaymentType>().HasData(pmt_4);
            #endregion

            #region Create OfferTypes
            var offer_type_1_id = random.Next(123456789, 999999999) + random.Next(0, 333) + 10;
            OfferType offer_type_1 = new OfferType()
            {
                Id = offer_type_1_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "PUBLIC"
            };
            builder.Entity<OfferType>().HasData(offer_type_1);

            var offer_type_2_id = random.Next(123456789, 999999999) + random.Next(0, 333) + 10;
            OfferType offer_type_2 = new OfferType()
            {
                Id = offer_type_2_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "PRIVATE"
            };
            builder.Entity<OfferType>().HasData(offer_type_2);

            var offer_type_3_id = random.Next(123456789, 999999999) + random.Next(0, 333) + 10;
            OfferType offer_type_3 = new OfferType()
            {
                Id = offer_type_3_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "INTERNATIONAL"
            };
            builder.Entity<OfferType>().HasData(offer_type_3);

            var offer_type_4_id = random.Next(123456789, 999999999) + random.Next(0, 333) + 10;
            OfferType offer_type_4 = new OfferType()
            {
                Id = offer_type_4_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "HEDNO"
            };
            builder.Entity<OfferType>().HasData(offer_type_4);

            int[] offerTypesIds =
            {
                offer_type_1_id,
                offer_type_2_id,
                offer_type_3_id
            };
            #endregion

            #region Create OfferState
            var offer_state_1_id = random.Next(123456789, 999999999) + random.Next(0, 333) + 10;
            OfferState offer_state_1 = new OfferState()
            {
                Id = offer_state_1_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "SUBMITTED"
            };
            builder.Entity<OfferState>().HasData(offer_state_1);

            var offer_state_2_id = random.Next(123456789, 999999999) + random.Next(0, 333) + 10;
            OfferState offer_state_2 = new OfferState()
            {
                Id = offer_state_2_id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "PREPARATION"
            };
            builder.Entity<OfferState>().HasData(offer_state_2);

            int[] offerStatesIds =
            {
                offer_state_1_id,
                offer_state_2_id
            };
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
                "DWG Admin/Clearing"
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

            // Add Discipline Type Project Manager Hours.
            var discipline_pm_hours_type_Id = random.Next(123456789, 999999999);
            DisciplineType dt_pm_hours = new DisciplineType()
            {
                Id = discipline_pm_hours_type_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = "Project Manager Hours",
            };
            builder.Entity<DisciplineType>().HasData(dt_pm_hours);
            #endregion

            #region Create Deliverable Types
            List<DeliverableType> deliverableTypes = new List<DeliverableType>();
            string[] drawTypeNames = {
                "Documents",
                "Calculations",
                "Deliverables"
            };
            for (var i = 0; i < drawTypeNames.Length; i++)
            {
                var drawing_type_Id = random.Next(123456789, 999999999);
                DeliverableType drt = new DeliverableType()
                {
                    Id = drawing_type_Id,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    Name = drawTypeNames[i],
                };
                builder.Entity<DeliverableType>().HasData(drt);
                deliverableTypes.Add(drt);
            }
            #endregion

            #region Create SupportiveWork Types
            List<SupportiveWorkType> otherTypes = new List<SupportiveWorkType>();
            string[] otherTypeNames = {
                "Communications",
                "Printing",
                "On-Site",
                "Meetings",
                "Administration",
                "Soft Copy",
                "Hours To Be Erased"
            };
            for (var i = 0; i < otherTypeNames.Length; i++)
            {
                var other_type_Id = random.Next(123456789, 999999999);
                SupportiveWorkType ort = new SupportiveWorkType()
                {
                    Id = other_type_Id,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    Name = otherTypeNames[i],
                };
                builder.Entity<SupportiveWorkType>().HasData(ort);
                otherTypes.Add(ort);
            }
            #endregion




            #region Create Secretaries
            List<User> secretaries = new List<User>();

            // ΑΘΗΝΑ ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ
            var secretarie_1_Id = random.Next(123456789, 999999999) + random.Next(0, 333) + 26;
            User secretarie_1 = new User()
            {
                Id = secretarie_1_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                LastName = "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ",
                FirstName = "ΑΘΗΝΑ",
                Phone1 = "694927778",
                Description = "ΓΡΑΜΜΑΤΕΙΑ",
                ProxyAddress = "embiria@embiria.onmicrosoft.com"
            };
            builder.Entity<User>().HasData(secretarie_1);
            secretaries.Add(secretarie_1);
            Email email_6 = new Email()
            {
                Id = random.Next(123456789, 999999999) + random.Next(0, 33),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Address = "embiria@embiria.gr",
                UserId = secretarie_1_Id
            };
            builder.Entity<Email>().HasData(email_6);
            Email email_7 = new Email()
            {
                Id = random.Next(123456789, 999999999) + random.Next(0, 33),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Address = "akonstantinidou@embiria.gr",
                UserId = secretarie_1_Id
            };
            builder.Entity<Email>().HasData(email_7);
            UserRole secretarieRole_1_em = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + 11,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = secretarie_1_Id,
                RoleId = role_10_id
            };
            builder.Entity<UserRole>().HasData(secretarieRole_1_em);
            #endregion

            #region Create Draftmen
            List<User> draftsmen = new List<User>();

            // Draftsmen ΔΟΥΓΑΛΕΡΗΣ ΓΡΗΓΟΡΗΣ
            var draftsman_1_Id = random.Next(123456789, 999999999) + random.Next(0, 333) + 7;
            User draftman_1 = new User()
            {
                Id = draftsman_1_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                LastName = "ΔΟΥΓΑΛΕΡΗΣ",
                FirstName = "ΓΡΗΓΟΡΗΣ",
                Phone1 = "694927778",
                Description = "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ",
                ProxyAddress = "dtsa@embiria.onmicrosoft.com"
            };
            builder.Entity<User>().HasData(draftman_1);
            draftsmen.Add(draftman_1);
            Email email_8 = new Email()
            {
                Id = random.Next(123456789, 999999999) + random.Next(0, 33),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Address = "gdoug@embiria.gr",
                UserId = draftsman_1_Id
            };
            builder.Entity<Email>().HasData(email_8);
            UserRole DraftsmanRole_1_em = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + 11,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = draftsman_1_Id,
                RoleId = role_1_id
            };
            builder.Entity<UserRole>().HasData(DraftsmanRole_1_em);


            // Draftsmen ΤΣΑΛΑΜΑΓΚΑΚΗΣ ΔΗΜΗΤΡΗΣ
            var draftsman_2_Id = random.Next(123456789, 999999999) + random.Next(0, 333) + 8;
            User draftman_2 = new User()
            {
                Id = draftsman_2_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                LastName = "ΤΣΑΛΑΜΑΓΚΑΚΗΣ",
                FirstName = "ΔΗΜΗΤΡΗΣ",
                Phone1 = "694927778",
                Description = "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ",
                ProxyAddress = "dtsa@embiria.onmicrosoft.com"
            };
            builder.Entity<User>().HasData(draftman_2);
            draftsmen.Add(draftman_2);
            Email email_9 = new Email()
            {
                Id = random.Next(123456789, 999999999) + random.Next(0, 33),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Address = "dtsa@embiria.gr",
                UserId = draftsman_2_Id
            };
            builder.Entity<Email>().HasData(email_9);
            UserRole DraftsmanRole_2_em = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + 11,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = draftsman_2_Id,
                RoleId = role_1_id
            };
            builder.Entity<UserRole>().HasData(DraftsmanRole_2_em);


            // Draftsmen ΧΑΤΖΑΚΗΣ ΜΑΝΩΛΗΣ
            var draftsman_3_Id = random.Next(123456789, 999999999) + random.Next(0, 333) + 9;
            User draftman_3 = new User()
            {
                Id = draftsman_3_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                LastName = "ΧΑΤΖΑΚΗΣ",
                FirstName = "ΜΑΝΩΛΗΣ",
                Phone1 = "694927778",
                Description = "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ",
                ProxyAddress = "mhatzakis@embiria.onmicrosoft.com"
            };
            builder.Entity<User>().HasData(draftman_3);
            draftsmen.Add(draftman_3);
            Email email_10 = new Email()
            {
                Id = random.Next(123456789, 999999999) + random.Next(0, 33),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Address = "dtsa@embiria.gr",
                UserId = draftsman_3_Id
            };
            builder.Entity<Email>().HasData(email_10);
            UserRole DraftsmanRole_3_em = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + 11,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = draftsman_3_Id,
                RoleId = role_1_id
            };
            builder.Entity<UserRole>().HasData(DraftsmanRole_3_em);
            #endregion

            #region Create Engineers
            List<User> engineers = new List<User>();

            // ΠΑΞΙΝΟΣ ΕΥΑΓΓΕΛΟΣ
            var engineer_1_Id = random.Next(123456789, 999999999) + random.Next(0, 333) + 10;
            User engineer_1 = new User()
            {
                Id = engineer_1_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                LastName = "ΠΑΞΙΝΟΣ",
                FirstName = "ΕΥΑΓΓΕΛΟΣ",
                Phone1 = "694927778",
                Description = "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.",
                ProxyAddress = "vpax@embiria.onmicrosoft.com"
            };
            builder.Entity<User>().HasData(engineer_1);
            engineers.Add(engineer_1);
            Email email_11 = new Email()
            {
                Id = random.Next(123456789, 999999999) + random.Next(0, 33),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Address = "vpax@embiria.gr",
                UserId = engineer_1_Id
            };
            builder.Entity<Email>().HasData(email_11);
            // Engineer
            UserRole engineerRole_1_em = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + 12,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = engineer_1_Id,
                RoleId = role_2_id
            };
            builder.Entity<UserRole>().HasData(engineerRole_1_em);

            // ΜΑΝΑΡΩΛΗΣ ΞΕΝΟΦΩΝ
            var engineer_2_Id = random.Next(123456789, 999999999) + random.Next(0, 333) + 11;
            User engineer_2 = new User()
            {
                Id = engineer_2_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                LastName = "ΜΑΝΑΡΩΛΗΣ",
                FirstName = "ΞΕΝΟΦΩΝ",
                Phone1 = "694927778",
                Description = "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.",
                ProxyAddress = "xmanarolis@embiria.onmicrosoft.com"
            };
            builder.Entity<User>().HasData(engineer_2);
            engineers.Add(engineer_2);
            Email email_12 = new Email()
            {
                Id = random.Next(123456789, 999999999) + random.Next(0, 33),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Address = "xmanarolis@embiria.gr",
                UserId = engineer_2_Id
            };
            builder.Entity<Email>().HasData(email_12);
            // Engineer
            UserRole engineerRole_2_em = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + 12,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = engineer_2_Id,
                RoleId = role_2_id
            };
            builder.Entity<UserRole>().HasData(engineerRole_2_em);

            // ΠΑΡΙΣΗΣ ΣΤΕΦΑΝΟΣ
            var engineer_3_Id = random.Next(123456789, 999999999) + random.Next(0, 333) + 12;
            User engineer_3 = new User()
            {
                Id = engineer_3_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                LastName = "ΠΑΡΙΣΗΣ",
                FirstName = "ΣΤΕΦΑΝΟΣ",
                Phone1 = "694927778",
                Description = "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ",
                ProxyAddress = "sparisis@embiria.onmicrosoft.com"
            };
            builder.Entity<User>().HasData(engineer_3);
            engineers.Add(engineer_3);
            Email email_13 = new Email()
            {
                Id = random.Next(123456789, 999999999) + random.Next(0, 33),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Address = "sparisis@embiria.gr",
                UserId = engineer_3_Id
            };
            builder.Entity<Email>().HasData(email_13);
            // Engineer
            UserRole engineerRole_3_em = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + 12,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = engineer_3_Id,
                RoleId = role_2_id
            };
            builder.Entity<UserRole>().HasData(engineerRole_3_em);

            // ΚΟΒΡΑΣ ΜΠΑΜΠΗΣ
            var engineer_4_Id = random.Next(123456789, 999999999) + random.Next(0, 333) + 13;
            User engineer_4 = new User()
            {
                Id = engineer_4_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                LastName = "ΚΟΒΡΑΣ",
                FirstName = "ΜΠΑΜΠΗΣ",
                Phone1 = "694927778",
                Description = "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.",
                ProxyAddress = "chkovras@embiria.onmicrosoft.com"
            };
            builder.Entity<User>().HasData(engineer_4);
            engineers.Add(engineer_4);
            Email email_14 = new Email()
            {
                Id = random.Next(123456789, 999999999) + random.Next(0, 33),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Address = "chkovras@embiria.gr",
                UserId = engineer_4_Id
            };
            builder.Entity<Email>().HasData(email_14);
            // Engineer
            UserRole engineerRole_4_em = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + 12,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = engineer_4_Id,
                RoleId = role_2_id
            };
            builder.Entity<UserRole>().HasData(engineerRole_4_em);

            // ΓΑΛΑΝΗΣ ΝΙΚΗΦΟΡΟΣ
            var engineer_5_Id = random.Next(123456789, 999999999) + random.Next(0, 333) + 14;
            User engineer_5 = new User()
            {
                Id = engineer_5_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                LastName = "ΓΑΛΑΝΗΣ",
                FirstName = "ΝΙΚΗΦΟΡΟΣ",
                Phone1 = "694927778",
                Description = "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.",
                ProxyAddress = "ngal@embiria.onmicrosoft.com"
            };
            builder.Entity<User>().HasData(engineer_5);
            engineers.Add(engineer_5);
            Email email_15 = new Email()
            {
                Id = random.Next(123456789, 999999999) + random.Next(0, 33),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Address = "ngal@embiria.gr",
                UserId = engineer_5_Id
            };
            builder.Entity<Email>().HasData(email_15);
            // Engineer
            UserRole engineerRole_5_em = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + 12,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = engineer_5_Id,
                RoleId = role_2_id
            };
            builder.Entity<UserRole>().HasData(engineerRole_5_em);
            // CEO
            UserRole engineerRole_5_em_3 = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + 12,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = engineer_5_Id,
                RoleId = role_6_id
            };
            builder.Entity<UserRole>().HasData(engineerRole_5_em_3);

            // ΚΟΤΣΩΝΗ ΚΑΤΕΡΙΝΑ
            var engineer_6_Id = random.Next(123456789, 999999999) + random.Next(0, 333) + 15;
            User engineer_6 = new User()
            {
                Id = engineer_6_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                LastName = "ΚΟΤΣΩΝΗ",
                FirstName = "ΚΑΤΕΡΙΝΑ",
                Phone1 = "694927778",
                Description = "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.",
                ProxyAddress = "kkotsoni@embiria.onmicrosoft.com"
            };
            builder.Entity<User>().HasData(engineer_6);
            engineers.Add(engineer_6);
            Email email_16 = new Email()
            {
                Id = random.Next(123456789, 999999999) + random.Next(0, 33),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Address = "kkotsoni@embiria.gr",
                UserId = engineer_6_Id
            };
            builder.Entity<Email>().HasData(email_16);
            // Engineer
            UserRole engineerRole_6_em = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + 12,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = engineer_6_Id,
                RoleId = role_2_id
            };
            builder.Entity<UserRole>().HasData(engineerRole_6_em);
            // COO
            UserRole engineerRole_6_em_coo = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + 12,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = engineer_6_Id,
                RoleId = role_4_id
            };
            builder.Entity<UserRole>().HasData(engineerRole_6_em_coo);
            // CTO
            UserRole engineerRole_17_em_coo = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + 12,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = engineer_6_Id,
                RoleId = role_5_id
            };
            builder.Entity<UserRole>().HasData(engineerRole_17_em_coo);

            // ΤΖΑΝΗΣ ΒΑΣΙΛΕΙΟΣ
            var engineer_7_Id = random.Next(123456789, 999999999) + random.Next(0, 333) + 16;
            User engineer_7 = new User()
            {
                Id = engineer_7_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                LastName = "ΤΖΑΝΗΣ",
                FirstName = "ΒΑΣΙΛΕΙΟΣ",
                Phone1 = "694927778",
                Description = "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.",
                ProxyAddress = "vtza@embiria.onmicrosoft.com"
            };
            builder.Entity<User>().HasData(engineer_7);
            engineers.Add(engineer_7);
            Email email_17 = new Email()
            {
                Id = random.Next(123456789, 999999999) + random.Next(0, 33),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Address = "vtza@embiria.gr",
                UserId = engineer_7_Id
            };
            builder.Entity<Email>().HasData(email_17);
            // Engineer
            UserRole engineerRole_7_em = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + 12,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = engineer_7_Id,
                RoleId = role_2_id
            };
            builder.Entity<UserRole>().HasData(engineerRole_7_em);

            // ΓΡΕΤΟΣ ΑΝΔΡΕΑΣ
            var engineer_8_Id = random.Next(123456789, 999999999) + random.Next(0, 333) + 17;
            User engineer_8 = new User()
            {
                Id = engineer_8_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                LastName = "ΓΡΕΤΟΣ",
                FirstName = "ΑΝΔΡΕΑΣ",
                Phone1 = "694927778",
                Description = "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.",
                ProxyAddress = "agretos@embiria.onmicrosoft.com"
            };
            builder.Entity<User>().HasData(engineer_8);
            engineers.Add(engineer_8);
            Email email_18 = new Email()
            {
                Id = random.Next(123456789, 999999999) + random.Next(0, 33),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Address = "agretos@embiria.gr",
                UserId = engineer_8_Id
            };
            builder.Entity<Email>().HasData(email_18);
            // Engineer
            UserRole engineerRole_8_em = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + 12,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = engineer_8_Id,
                RoleId = role_2_id
            };
            builder.Entity<UserRole>().HasData(engineerRole_8_em);

            // ΜΑΡΓΕΤΗ ΚΑΤΕΡΙΝΑ
            var engineer_9_Id = random.Next(123456789, 999999999) + random.Next(0, 333) + 18;
            User engineer_9 = new User()
            {
                Id = engineer_9_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                LastName = "ΜΑΡΓΕΤΗ",
                FirstName = "ΚΑΤΕΡΙΝΑ",
                Phone1 = "694927778",
                Description = "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ",
                ProxyAddress = "kmargeti@embiria.onmicrosoft.com"
            };
            builder.Entity<User>().HasData(engineer_9);
            engineers.Add(engineer_9);
            Email email_19 = new Email()
            {
                Id = random.Next(123456789, 999999999) + random.Next(0, 33),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Address = "kmargeti@embiria.gr",
                UserId = engineer_9_Id
            };
            builder.Entity<Email>().HasData(email_19);
            // Engineer
            UserRole engineerRole_9_em = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + 12,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = engineer_9_Id,
                RoleId = role_2_id
            };
            builder.Entity<UserRole>().HasData(engineerRole_9_em);

            // ΠΛΑΤΑΝΙΟΣ ΧΑΡΗΣ
            var engineer_10_Id = random.Next(123456789, 999999999) + random.Next(0, 333) + 19;
            User engineer_10 = new User()
            {
                Id = engineer_10_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                LastName = "ΠΛΑΤΑΝΙΟΣ",
                FirstName = "ΧΑΡΗΣ",
                Phone1 = "694927778",
                Description = "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.",
                ProxyAddress = "haris@embiria.onmicrosoft.com"
            };
            builder.Entity<User>().HasData(engineer_10);
            engineers.Add(engineer_10);
            Email email_20 = new Email()
            {
                Id = random.Next(123456789, 999999999) + random.Next(0, 33),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Address = "haris@embiria.gr",
                UserId = engineer_10_Id
            };
            builder.Entity<Email>().HasData(email_20);
            // Engineer
            UserRole engineerRole_10_em = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + 12,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = engineer_10_Id,
                RoleId = role_2_id
            };
            builder.Entity<UserRole>().HasData(engineerRole_10_em);

            // ΦΩΚΙΑΝΟΥ ΠΕΓΚΥ
            var engineer_11_Id = random.Next(123456789, 999999999) + random.Next(0, 333) + 20;
            User engineer_11 = new User()
            {
                Id = engineer_11_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                LastName = "ΦΩΚΙΑΝΟΥ",
                FirstName = "ΠΕΓΚΥ",
                Phone1 = "694927778",
                Description = "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.",
                ProxyAddress = "pfokianou@embiria.onmicrosoft.com"
            };
            builder.Entity<User>().HasData(engineer_11);
            engineers.Add(engineer_11);
            Email email_21 = new Email()
            {
                Id = random.Next(123456789, 999999999) + random.Next(0, 33),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Address = "pfokianou@embiria.gr",
                UserId = engineer_11_Id
            };
            builder.Entity<Email>().HasData(email_21);
            // Engineer
            UserRole engineerRole_11_em = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + 12,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = engineer_11_Id,
                RoleId = role_2_id
            };
            builder.Entity<UserRole>().HasData(engineerRole_11_em);

            // ΓΙΑΝΝΟΓΛΟΥ ΟΛΓΑ
            var engineer_12_Id = random.Next(123456789, 999999999) + random.Next(0, 333) + 21;
            User engineer_12 = new User()
            {
                Id = engineer_12_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                LastName = "ΓΙΑΝΝΟΓΛΟΥ",
                FirstName = "ΟΛΓΑ",
                Phone1 = "694927778",
                Description = "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ",
                ProxyAddress = "ogiannoglou@embiria.onmicrosoft.com"
            };
            builder.Entity<User>().HasData(engineer_12);
            engineers.Add(engineer_12);
            Email email_22 = new Email()
            {
                Id = random.Next(123456789, 999999999) + random.Next(0, 33),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Address = "ogiannoglou@embiria.gr",
                UserId = engineer_12_Id
            };
            builder.Entity<Email>().HasData(email_22);
            // Engineer
            UserRole engineerRole_12_em = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + 12,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = engineer_12_Id,
                RoleId = role_2_id
            };
            builder.Entity<UserRole>().HasData(engineerRole_12_em);

            // ΛΕΚΟΥ ΒΑΡΒΑΡΑ
            var engineer_13_Id = random.Next(123456789, 999999999) + random.Next(0, 333) + 22;
            User engineer_13 = new User()
            {
                Id = engineer_13_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                LastName = "ΛΕΚΟΥ",
                FirstName = "ΒΑΡΒΑΡΑ",
                Phone1 = "694927778",
                Description = "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.",
                ProxyAddress = "blekou@embiria.onmicrosoft.com"
            };
            builder.Entity<User>().HasData(engineer_13);
            engineers.Add(engineer_13);
            Email email_23 = new Email()
            {
                Id = random.Next(123456789, 999999999) + random.Next(0, 33),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Address = "blekou@embiria.gr",
                UserId = engineer_13_Id
            };
            builder.Entity<Email>().HasData(email_23);
            // Engineer
            UserRole engineerRole_13_em = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + 12,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = engineer_13_Id,
                RoleId = role_2_id
            };
            builder.Entity<UserRole>().HasData(engineerRole_13_em);

            // ΧΟΝΤΟΣ ΒΑΣΙΛΕΙΟΣ
            var engineer_14_Id = random.Next(123456789, 999999999) + random.Next(0, 333) + 23;
            User engineer_14 = new User()
            {
                Id = engineer_14_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                LastName = "ΧΟΝΤΟΣ",
                FirstName = "ΒΑΣΙΛΕΙΟΣ",
                Phone1 = "694927778",
                Description = "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ",
                ProxyAddress = "vchontos@embiria.onmicrosoft.com"
            };
            builder.Entity<User>().HasData(engineer_14);
            engineers.Add(engineer_14);
            Email email_24 = new Email()
            {
                Id = random.Next(123456789, 999999999) + random.Next(0, 33),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Address = "vchontos@embiria.gr",
                UserId = engineer_14_Id
            };
            builder.Entity<Email>().HasData(email_24);
            // Engineer
            UserRole engineerRole_14_em = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + 12,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = engineer_14_Id,
                RoleId = role_2_id
            };
            builder.Entity<UserRole>().HasData(engineerRole_14_em);

            // ΠΕΡΙΒΟΛΛΑΡΗ ΠΑΝΑΓΙΩΤΑ
            var engineer_15_Id = random.Next(123456789, 999999999) + random.Next(0, 333) + 24;
            User engineer_15 = new User()
            {
                Id = engineer_15_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                LastName = "ΠΕΡΙΒΟΛΛΑΡΗ",
                FirstName = "ΠΑΝΑΓΙΩΤΑ",
                Phone1 = "694927778",
                Description = "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ",
                ProxyAddress = "panperivollari@embiria.onmicrosoft.com"
            };
            builder.Entity<User>().HasData(engineer_15);
            engineers.Add(engineer_15);
            Email email_25 = new Email()
            {
                Id = random.Next(123456789, 999999999) + random.Next(0, 33),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Address = "panperivollari@embiria.gr",
                UserId = engineer_15_Id
            };
            builder.Entity<Email>().HasData(email_25);
            // Engineer
            UserRole engineerRole_15_em = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + 12,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = engineer_15_Id,
                RoleId = role_2_id
            };
            builder.Entity<UserRole>().HasData(engineerRole_15_em);

            // ΤΡΙΑΝΤΑΦΥΛΛΟΥ ΝΙΚΟΛΑΟΣ
            var engineer_16_Id = random.Next(123456789, 999999999) + random.Next(0, 333) + 25;
            User engineer_16 = new User()
            {
                Id = engineer_16_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                LastName = "ΤΡΙΑΝΤΑΦΥΛΛΟΥ",
                FirstName = "ΝΙΚΟΛΑΟΣ",
                Phone1 = "694927778",
                Description = "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.",
                ProxyAddress = "ntriantafyllou@embiria.onmicrosoft.com"
            };
            builder.Entity<User>().HasData(engineer_16);
            engineers.Add(engineer_16);
            Email email_26 = new Email()
            {
                Id = random.Next(123456789, 999999999) + random.Next(0, 33),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Address = "ntriantafyllou@embiria.gr",
                UserId = engineer_16_Id
            };
            builder.Entity<Email>().HasData(email_26);
            // Engineer
            UserRole engineerRole_16_em = new UserRole()
            {
                Id = random.Next(123456789, 999999999) + 12,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = engineer_16_Id,
                RoleId = role_2_id
            };
            builder.Entity<UserRole>().HasData(engineerRole_16_em);
            #endregion

            #region Create 3 Project Managers
            List<User> projectManagers = new List<User>();

            // ΠΑΞΙΝΟΣ ΕΥΑΓΓΕΛΟΣ
            UserRole pmRole_1 = new UserRole()
            {
                Id = random.Next(123456789, 999999999) / 3,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = engineer_1.Id,
                RoleId = role_3_id
            };
            builder.Entity<UserRole>().HasData(pmRole_1);
            projectManagers.Add(engineer_1);

            // ΚΟΤΣΩΝΗ ΚΑΤΕΡΙΝΑ
            UserRole pmRole_2 = new UserRole()
            {
                Id = random.Next(123456789, 999999999) / 3,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = engineer_6.Id,
                RoleId = role_3_id
            };
            builder.Entity<UserRole>().HasData(pmRole_2);
            projectManagers.Add(engineer_6);

            // ΠΛΑΤΑΝΙΟΣ ΧΑΡΗΣ
            UserRole pmRole_3 = new UserRole()
            {
                Id = random.Next(123456789, 999999999) / 3,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                UserId = engineer_10.Id,
                RoleId = role_3_id
            };
            builder.Entity<UserRole>().HasData(pmRole_3);
            projectManagers.Add(engineer_10);
            #endregion

            var projectManagersLength = projectManagers.Count();
            var projectManagersIndex = 0;
            var stagesLength = ProjectStages.Count();
            var stagesIndex = 0;

            var categoriesLength = projectCategories.Count();
            var categoriesIndex = 0;

            #region Create 5 Projects
            List<Project> projects = new List<Project>();
            for (var i = 1; i <= projectSubCategories.Count(); i++)
            {
                // Client
                var clientId = random.Next(123456789, 999999999) + i * 3;
                Client client = new Client()
                {
                    Id = clientId,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    FirstName = $"Client-Led-{i}",
                    LastName = "LastName",
                    ProxyAddress = "alexandrosplatanios15@gmail.com",
                    Phone1 = "6949277783",
                    CompanyName = "Embiria BMS",
                };
                builder.Entity<Client>().HasData(client);

                // Led
                var ledId = random.Next(123456789, 999999999) + i * 3;
                Lead led = new Lead()
                {
                    Id = ledId,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    Name = $"Led-{i}",
                    ClientId = clientId,
                    PotencialFee = random.Next(i, i * 3),
                    Result = LeadResult.SUCCESSFUL
                };
                builder.Entity<Lead>().HasData(led);

                // Offers
                var offerId = random.Next(123456789, 999999999) + i * 3;
                Offer offer = new Offer()
                {
                    Id = offerId,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    Date = DateTime.Now,
                    Code = $"Code CO-{i}",
                    TypeId = offerTypesIds[random.Next(0, 2)],
                    StateId = offerStatesIds[random.Next(0, 1)],
                    Result = OfferResult.SUCCESSFUL,
                    PudgetPrice = 1000 * i * 3,
                    OfferPrice = 1000 * i * 2,
                    CategoryId = projectCategories[categoriesIndex].Id,
                    SubCategoryId = projectSubCategories[i - 1].Id,
                    LeadId = ledId,
                };
                builder.Entity<Offer>().HasData(offer);

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
                    StartDate = createdDate,
                    DeadLine = createdDate.AddMonths(Convert.ToInt32(Math.Pow(i, 2))),
                    EstimatedMandays = 100 / 8,
                    EstimatedHours = 1500,
                    DeclaredCompleted = 0,
                    EstimatedCompleted = 0,
                    StageId = ProjectStages[stagesIndex],
                    Active = i % 2 == 0 ? true : false,
                    ProjectManagerId = projectManagers[projectManagersIndex].Id,
                    OfferId = offerId
                };
                builder.Entity<Project>().HasData(project);
                projects.Add(project);

                projectManagersIndex++;
                if (projectManagersIndex >= projectManagersLength - 1)
                    projectManagersIndex = 0;

                categoriesIndex++;
                if (categoriesIndex >= categoriesLength)
                    categoriesIndex = 0;

                stagesIndex++;
                if (stagesIndex >= stagesLength - 1)
                    stagesIndex = 0;

                // Invoices
                var invoiceId = random.Next(123456789, 999999999) + i * 3;
                Invoice invoice = new Invoice()
                {
                    Id = invoiceId,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    PaymentDate = DateTime.Now,
                    EstimatedDate = DateTime.Now,
                    Total = i * Math.Pow(1, 3),
                    Vat = i % 2 == 0 ? Vat.TwentyFour : Vat.Seventeen,
                    Fee = 1000 * i,
                    Number = random.Next(10000, 90000),
                    Mark = "Signature 14234" + Convert.ToString(i * random.Next(1, 7)),
                    ProjectId = projectId,
                    TypeId = it_1_id
                };
                builder.Entity<Invoice>().HasData(invoice);
            }
            #endregion

            #region Create 7 Projects Missed DeadLine
            projectManagersIndex = 0;
            stagesIndex = 0;
            categoriesIndex = 0;

            var subCategoriesLength = projectSubCategories.Count();
            var subCategoriesIndex = 0;

            for (var i = 1; i <= 7; i++)
            {
                // Client
                var clientId = random.Next(123456789, 999999999) + i * 3 + 2345;
                Client client = new Client()
                {
                    Id = clientId,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    FirstName = $"Client-Led-M-{i}",
                    LastName = "LastName",
                    ProxyAddress = "alexandrosplatanios15@gmail.com",
                    Phone1 = "6949277783",
                    CompanyName = "Embiria BMS"
                };
                builder.Entity<Client>().HasData(client);

                // Led
                var ledId = random.Next(123456789, 999999999) + i * 3 + 13245;
                Lead led = new Lead()
                {
                    Id = ledId,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    Name = $"Led-M-{i}",
                    ClientId = clientId,
                    PotencialFee = random.Next(i, i * 3),
                    Result = LeadResult.SUCCESSFUL
                };
                builder.Entity<Lead>().HasData(led);

                // Offers
                var offerId = random.Next(123456789, 999999999) + i * 3;
                Offer offer = new Offer()
                {
                    Id = offerId,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    Date = DateTime.Now,
                    Code = $"Code CO-{i}",
                    TypeId = offerTypesIds[random.Next(0, 2)],
                    StateId = offerStatesIds[random.Next(0, 1)],
                    Result = OfferResult.SUCCESSFUL,
                    PudgetPrice = 1000 * i * 4,
                    OfferPrice = 1000 * i * 3,
                    CategoryId = projectCategories[categoriesIndex].Id,
                    SubCategoryId = projectSubCategories[subCategoriesIndex].Id,
                    LeadId = ledId,
                };
                builder.Entity<Offer>().HasData(offer);

                // Projects 
                var projectId = random.Next(123456789, 999999999) + i * 22;
                Project project = new Project()
                {
                    Id = projectId,
                    CreatedDate = createdDate,
                    LastUpdatedDate = createdDate,
                    Code = "D-22-16" + Convert.ToString(i + 2),
                    Name = "Project_Missed_DeadLine_" + Convert.ToString(i + 2),
                    Description = "Test Description Project_" + Convert.ToString(i * random.Next(1, 7)),
                    StartDate = createdDate.AddMonths(-(i * 2)),
                    DeadLine = createdDate.AddMonths(-i),
                    EstimatedMandays = 100 / 8,
                    EstimatedHours = 1500,
                    DeclaredCompleted = 0,
                    EstimatedCompleted = 0,
                    StageId = ProjectStages[stagesIndex],
                    Active = i % 2 == 0 ? true : false,
                    ProjectManagerId = projectManagers[projectManagersIndex].Id,
                    OfferId = offerId
                };
                builder.Entity<Project>().HasData(project);
                projects.Add(project);

                // Invoices
                var invoiceId = random.Next(123456789, 999999999) + i * 3;
                Invoice invoice = new Invoice()
                {
                    Id = invoiceId,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    PaymentDate = DateTime.Now,
                    EstimatedDate = DateTime.Now,
                    Total = i * Math.Pow(1, 3),
                    Vat = i % 2 == 0 ? Vat.TwentyFour : Vat.Seventeen,
                    Fee = 1100 * i,
                    Number = random.Next(10000, 90000),
                    Mark = "Signature 14234" + Convert.ToString(i * random.Next(1, 7)),
                    ProjectId = projectId,
                    TypeId = it_1_id
                };
                builder.Entity<Invoice>().HasData(invoice);

                projectManagersIndex++;
                if (projectManagersIndex >= projectManagersLength)
                    projectManagersIndex = 0;

                subCategoriesIndex++;
                if (subCategoriesIndex >= subCategoriesLength)
                    subCategoriesIndex = 0;

                categoriesIndex++;
                if (categoriesIndex >= categoriesLength)
                    categoriesIndex = 0;

                stagesIndex++;
                if (stagesIndex >= stagesLength)
                    stagesIndex = 0;
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
                    int typeIndex = GetUniqueRandomNumber(random, randomTypeIndexes, 0, disciplineTypes.Count - 1);
                    var discipline_Id = random.Next(123456789, 999999999) * 8;
                    Discipline discipline = new Discipline()
                    {
                        Id = discipline_Id,
                        CreatedDate = DateTime.Now,
                        LastUpdatedDate = DateTime.Now,
                        TypeId = disciplineTypes[typeIndex].Id,
                        EstimatedMandays = 50 + j,
                        EstimatedHours = (50 + j) * 8,
                        ProjectId = projects[i].Id,
                        DeclaredCompleted = 0
                    };
                    builder.Entity<Discipline>().HasData(discipline);
                    disciplines.Add(discipline);
                }
            }
            #endregion

            #region Create Deliverables
            List<Deliverable> deliverables = new List<Deliverable>();
            for (var i = 0; i < disciplines.Count; i++)
            {
                for (int j = 0; j < deliverableTypes.Count; j++)
                {
                    var drawing_Id = random.Next(123456789, 999999999);
                    Deliverable drawing = new Deliverable()
                    {
                        Id = drawing_Id,
                        CreatedDate = DateTime.Now,
                        LastUpdatedDate = DateTime.Now,
                        TypeId = deliverableTypes[j].Id,
                        DisciplineId = disciplines[i].Id,
                        CompletionEstimation = 0,
                        CompletionDate = DateTime.Now.AddDays(11)
                    };
                    builder.Entity<Deliverable>().HasData(drawing);
                    deliverables.Add(drawing);
                }
            }
            #endregion

            #region Create SupportiveWorks
            List<SupportiveWork> others = new List<SupportiveWork>();
            for (var i = 0; i < disciplines.Count; i++)
            {
                for (int j = 0; j < otherTypes.Count; j++)
                {
                    var other_Id = random.Next(123456789, 999999999);
                    SupportiveWork other = new SupportiveWork()
                    {
                        Id = other_Id,
                        CreatedDate = DateTime.Now,
                        LastUpdatedDate = DateTime.Now,
                        TypeId = otherTypes[j].Id,
                        DisciplineId = disciplines[i].Id,
                        CompletionEstimation = 0
                    };
                    builder.Entity<SupportiveWork>().HasData(other);
                }
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
                    SupportiveWorkEmployee de_1 = new SupportiveWorkEmployee()
                    {
                        Id = random.Next(123456789, 999999999) * 9,
                        CreatedDate = DateTime.Now,
                        LastUpdatedDate = DateTime.Now,
                        EmployeeId = draftsmen[d].Id,
                        SupportiveWorkId = others[o].Id
                    };
                    builder.Entity<SupportiveWorkEmployee>().HasData(de_1);
                }
            }
            #endregion

            #region Connect Every Draftman With Every Drawing
            //for (var o = 0; o < deliverables.Count; o++)
            //{
            //    for (var d = 0; d < draftsmen.Count; d++)
            //    {
            //        DrawingEmployee de_1 = new DrawingEmployee()
            //        {
            //            Id = random.Next(123456789, 999999999) * 9,
            //            CreatedDate = DateTime.Now,
            //            LastUpdatedDate = DateTime.Now,
            //            EmployeeId = draftsmen[d].Id,
            //            DrawingId = deliverables[o].Id
            //        };
            //        builder.Entity<DrawingEmployee>().HasData(de_1);
            //    }
            //}
            #endregion
        }
    }

    public async Task<Dictionary<string, List<object>>> GetAllDbSets()
    {
        Dictionary<string, List<object>> allEntities = new Dictionary<string, List<object>>();

        #region Get Employees
        var emplyeeRolesIds = await Roles.Where(r => !r.IsDeleted)
                                            .Where(r => r.IsEmployee || r.Name.Contains("Admin") || r.Name.Contains("admin"))
                                            .Select(r => r.Id)
                                            .ToListAsync();

        var employeeIds = await UsersRoles.Where(r => !r.IsDeleted)
                                            .Where(ur => emplyeeRolesIds.Contains(ur.RoleId))
                                            .Select(ur => ur.UserId)
                                            .ToListAsync();

        var employees = await Users.Where(r => !r.IsDeleted)
                                        .Where(u => employeeIds.Contains(u.Id))
                                        .ToListAsync();
        #endregion

        allEntities.Add("Users", employees.Cast<object>().ToList());
        allEntities.Add("Roles", await Roles.Cast<object>().ToListAsync());
        allEntities.Add("Emails", await Emails.Cast<object>().ToListAsync());
        allEntities.Add("Projects", await Projects.Cast<object>().ToListAsync());
        allEntities.Add("ProjectsCategories", await ProjectsCategories.Cast<object>().ToListAsync());
        allEntities.Add("ProjectsSubCategories", await ProjectsSubCategories.Cast<object>().ToListAsync());
        allEntities.Add("ProjectsStages", await ProjectsStages.Cast<object>().ToListAsync());
        allEntities.Add("Disciplines", await Disciplines.Cast<object>().ToListAsync());
        allEntities.Add("DisciplineTypes", await DisciplineTypes.Cast<object>().ToListAsync());
        allEntities.Add("Deliverables", await Deliverables.Cast<object>().ToListAsync());
        allEntities.Add("DeliverableTypes", await DeliverableTypes.Cast<object>().ToListAsync());
        allEntities.Add("SupportiveWorks", await SupportiveWorks.Cast<object>().ToListAsync());
        allEntities.Add("SupportiveWorkTypes", await SupportiveWorkTypes.Cast<object>().ToListAsync());
        allEntities.Add("SupportiveWorkEmployees", await SupportiveWorkEmployees.Cast<object>().ToListAsync());
        allEntities.Add("Invoices", await Invoices.Cast<object>().ToListAsync());
        allEntities.Add("InvoicesTypes", await InvoicesTypes.Cast<object>().ToListAsync());
        allEntities.Add("Contracts", await Contracts.Cast<object>().ToListAsync());
        allEntities.Add("TimeSpans", await TimeSpans.Cast<object>().ToListAsync());
        allEntities.Add("DailyTime", await DailyTime.Cast<object>().ToListAsync());
        allEntities.Add("ParsonalTime", await ParsonalTime.Cast<object>().ToListAsync());
        allEntities.Add("TrainingTime", await TrainingTime.Cast<object>().ToListAsync());
        allEntities.Add("CorporateEventTime", await CorporateEventTime.Cast<object>().ToListAsync());
        allEntities.Add("Issues", await Issues.Cast<object>().ToListAsync());
        allEntities.Add("Documents", await Documents.Cast<object>().ToListAsync());
        allEntities.Add("Address", await Address.Cast<object>().ToListAsync());
        allEntities.Add("Clients", await Clients.Cast<object>().ToListAsync());
        allEntities.Add("Leds", await Leads.Cast<object>().ToListAsync());
        allEntities.Add("Offers", await Offers.Cast<object>().ToListAsync());
        allEntities.Add("OffesStates", await OffesStates.Cast<object>().ToListAsync());
        allEntities.Add("OffersTypes", await OffersTypes.Cast<object>().ToListAsync());
        allEntities.Add("Payments", await Payments.Cast<object>().ToListAsync());
        allEntities.Add("PaymentsTypes", await PaymentsTypes.Cast<object>().ToListAsync());
        allEntities.Add("Permissions", await Permissions.Cast<object>().ToListAsync());
        allEntities.Add("UsersRoles", await UsersRoles.Cast<object>().ToListAsync());
        allEntities.Add("RolesPermissions", await RolesPermissions.Cast<object>().ToListAsync());
        allEntities.Add("DeliverablesEmployees", await DeliverablesEmployees.Cast<object>().ToListAsync());
        allEntities.Add("ProjectsSubConstructors", await ProjectsSubConstructors.Cast<object>().ToListAsync());
        allEntities.Add("TeamsRequestedUser", await TeamsRequestedUser.Cast<object>().ToListAsync());
        allEntities.Add("DisciplinesEngineers", await DisciplinesEngineers.Cast<object>().ToListAsync());

        return allEntities;
    }

    public List<Type> GetAllDbSetsTypes()
    {
        List<Type> allEntities = new List<Type>();

        // Get all properties of this DbContext
        var dbSetsProperties = GetType().GetProperties()
                                .Where(p => p.PropertyType.IsGenericType &&
                                            p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));

        foreach (var property in dbSetsProperties)
        {
            var entityType = property.PropertyType.GetGenericArguments()[0];
            allEntities.Add(entityType);
        }

        return allEntities;
    }

    public static void TestDatabaseConnection(AppDbContext context)
    {
        try
        {
            context.Database.OpenConnection();
            Console.WriteLine("Database connection is open.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error opening database connection: {ex.Message}");
        }
        finally
        {
            context.Database.CloseConnection();
        }
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