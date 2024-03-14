using EmpiriaBMS.Models;
using EmpiriaMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace EmpiriaBMS.Models.Models;
public class AppDbContext : DbContext
{

    //const string SmarterASPNetDB = "Data Source=SQL5106.site4now.net;Initial Catalog=db_a8c181_empiriabms;User Id=db_a8c181_empiriabms_admin;Password=admin1234567";
    const string localhostDB = "Data Source=127.0.0.1,1433;Initial Catalog=empiriabms;User Id=sa;Password=-Plata123456";
    //const string azureDB = "Server=tcp:empiriabms.database.windows.net,1433;Initial Catalog=EmpiriaBMS_DB;Persist Security Info=False;User ID=alexandros5880;Password=-Plat123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    const string migrationsDB = localhostDB;


    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Email> Emails { get; set; }
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
    public DbSet<DailyTime> DailyTime { get; set; }
    public DbSet<DailyTime> ParsonalTime { get; set; }
    public DbSet<DailyTime> TrainingTime { get; set; }
    public DbSet<DailyTime> CorporateEventTime { get; set; }
    public DbSet<UserRole> UsersRoles { get; set; }
    public DbSet<DrawingEmployee> DrawingsEmployees { get; set; }
    public DbSet<OtherEmployee> OthersEmployees { get; set; }
    public DbSet<ProjectPmanager> ProjectsPmanagers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //string enviroment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        string connectionString = Environment.GetEnvironmentVariable("ConnectionString") ?? migrationsDB;
        optionsBuilder.UseSqlServer(connectionString);
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.EnableDetailedErrors();
        optionsBuilder.EnableServiceProviderCaching();
        optionsBuilder.EnableThreadSafetyChecks();
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        Random random = new Random();
        var createdDate = DateTime.Now;

        // Relations
        ModelRelations.CreateRelations(builder);

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

        // Dashboard See All Drawings
        var per_10_id = random.Next(123456789, 999999999);
        Permission per_10 = new Permission()
        {
            Id = per_10_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "See All Drawings",
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
        #endregion

        #region Roles
        // Designer
        var role_1_id = random.Next(123456789, 999999999);
        Role role_1 = new()
        {
            Id = role_1_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Designer",
            IsEmployee = true,
            IsEditable = false
        };
        builder.Entity<Role>().HasData(role_1);

        // Engineer
        var role_2_id = random.Next(123456789, 999999999);
        Role role_2 = new()
        {
            Id = role_2_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Engineer",
            IsEmployee = true,
            IsEditable = false
        };
        builder.Entity<Role>().HasData(role_2);

        // Project Manager
        var role_3_id = random.Next(123456789, 999999999);
        Role role_3 = new()
        {
            Id = role_3_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Project Manager",
            IsEmployee = true,
            IsEditable = false
        };
        builder.Entity<Role>().HasData(role_3);

        // COO
        var role_4_id = random.Next(123456789, 999999999);
        Role role_4 = new()
        {
            Id = role_4_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "COO",
            IsEmployee = true,
            IsEditable = false
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
            IsEditable = false
        };
        builder.Entity<Role>().HasData(role_5);

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

        // Secretariat
        var role_10_id = random.Next(123456789, 999999999);
        Role role_10 = new()
        {
            Id = role_10_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Secretariat",
            IsEmployee = false,
            IsEditable = false
        };
        builder.Entity<Role>().HasData(role_10);
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

        // Engineer || See All Drawings
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

        // Project Manager || See All Drawings
        RolePermission rp_43 = new RolePermission()
        {
            Id = random.Next(123456789, 999999999) * 9,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            RoleId = role_3_id,
            PermissionId = per_10_id
        };
        builder.Entity<RolePermission>().HasData(rp_43);


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

        // COO || See All Drawings
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

        // CTO || See All Drawings
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
        RolePermission rp_26 = new RolePermission()
        {
            Id = random.Next(123456789, 999999999) * 9,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            RoleId = role_6_id,
            PermissionId = per_7_id
        };
        builder.Entity<RolePermission>().HasData(rp_26);

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

        // CEO || See All Drawings
        RolePermission rp_44 = new RolePermission()
        {
            Id = random.Next(123456789, 999999999) * 9,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            RoleId = role_6_id,
            PermissionId = per_10_id
        };
        builder.Entity<RolePermission>().HasData(rp_44);

        // COO || See All Projects
        RolePermission rp_47 = new RolePermission()
        {
            Id = random.Next(123456789, 999999999) * 9,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            RoleId = role_6_id,
            PermissionId = per_11_id
        };
        builder.Entity<RolePermission>().HasData(rp_47);


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

        // Admin || See All Drawings
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

        // Secretariat || See All Drawings
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

        #region Create Random Users With Roles:  Admin, CEO, CTO, COO, Guest,
        // Admin
        var adminId = random.Next(123456789, 999999999) + random.Next(0, 333) + 1;
        User admin = new User()
        {
            Id = adminId,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            LastName = "Alexandros",
            FirstName = "Platanios",
            Phone1 = "694927778",
            Description = "Admin",
            ProxyAddress = "empiriasoft@empiriasoftplat.onmicrosoft.com",
        };
        builder.Entity<User>().HasData(admin);
        Email email_1 = new Email()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Address = "alexandrosplatanios15@gmail.com",
            UserId = adminId
        };
        builder.Entity<Email>().HasData(email_1);
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
        var ceoId = random.Next(123456789, 999999999) + random.Next(0, 333) + 2;
        User ceo = new User()
        {
            Id = ceoId,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            LastName = "Alexandros",
            FirstName = "Platanios",
            Phone1 = "694927778",
            Description = "CEO",
            ProxyAddress = "ceo@gmail.com",
        };
        builder.Entity<User>().HasData(ceo);
        Email email_2 = new Email()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Address = "ceo@gmail.com",
            UserId = ceoId
        };
        builder.Entity<Email>().HasData(email_2);
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
        var ctoId = random.Next(123456789, 999999999) + random.Next(0, 333) + 3;
        User cto = new User()
        {
            Id = ctoId,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            LastName = "Alexandros",
            FirstName = "Platanios",
            Phone1 = "694927778",
            Description = "CTO",
            ProxyAddress = "cto@gmail.com",
        };
        builder.Entity<User>().HasData(cto);
        Email email_3 = new Email()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Address = "cto@gmail.com",
            UserId = ctoId
        };
        builder.Entity<Email>().HasData(email_3);
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
        var cooId = random.Next(123456789, 999999999) + random.Next(0, 333) + 4;
        User coo = new User()
        {
            Id = cooId,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            LastName = "Alexandros",
            FirstName = "Platanios",
            Phone1 = "694927778",
            Description = "COO",
            ProxyAddress = "coo@gmail.com",
        };
        builder.Entity<User>().HasData(coo);
        Email email_4 = new Email()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Address = "coo@gmail.com",
            UserId = cooId
        };
        builder.Entity<Email>().HasData(email_4);
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
        var guestId = random.Next(123456789, 999999999) + random.Next(0, 333) + 5;
        User guest = new User()
        {
            Id = guestId,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            LastName = "Alexandros",
            FirstName = "Platanios",
            Phone1 = "694927778",
            Description = "Guest",
            ProxyAddress = "guest@gmail.com",
        };
        builder.Entity<User>().HasData(guest);
        Email email_5 = new Email()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Address = "guest@gmail.com",
            UserId = guestId
        };
        builder.Entity<Email>().HasData(email_5);
        UserRole guestRole = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = guestId,
            RoleId = role_7_id
        };
        builder.Entity<UserRole>().HasData(guestRole);

        // Project Manager
        var pmId = random.Next(123456789, 999999999) + random.Next(0, 333) + 5;
        User pm = new User()
        {
            Id = pmId,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            LastName = "Alexandros",
            FirstName = "Platanios",
            Phone1 = "694927778",
            Description = "Project Manager",
            ProxyAddress = "pm@gmail.com",
        };
        builder.Entity<User>().HasData(pm);
        Email email_27 = new Email()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Address = "pm@gmail.com",
            UserId = pmId
        };
        builder.Entity<Email>().HasData(email_27);
        UserRole pmRole = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = pmId,
            RoleId = role_3_id
        };
        builder.Entity<UserRole>().HasData(pmRole);
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
        // Admin
        UserRole engineerRole_5_em_2 = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + 12,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = engineer_5_Id,
            RoleId = role_9_id
        };
        builder.Entity<UserRole>().HasData(engineerRole_5_em_2);
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

        #region Create 4 Project Types
        // Project Type Buildings
        var project_type_1_Id = random.Next(123456789, 999999999) + 33;
        ProjectType project_type_1 = new ProjectType()
        {
            Id = project_type_1_Id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Buildings",
            Description = "Buildings Description",
            CanAssignePM = true
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
            Description = "Infrastructure Description",
            CanAssignePM = true
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
            Description = "Energy Description",
            CanAssignePM = true
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
            Description = "Consulting Description",
            CanAssignePM = true
        };
        builder.Entity<ProjectType>().HasData(project_type_4);

        // Project Production Management
        var project_type_5_Id = random.Next(123456789, 999999999) + 34;
        ProjectType project_type_5 = new ProjectType()
        {
            Id = project_type_5_Id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Production Management",
            Description = "Production Management Description",
            CanAssignePM = false
        };
        builder.Entity<ProjectType>().HasData(project_type_5);

        int[] projectTypes = {
            project_type_1_Id,
            project_type_2_Id,
            project_type_3_Id,
            project_type_4_Id
        };
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

        #region Create 5 Projects
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
                EstimatedMandays = 100 / 8,
                EstimatedHours = 1500,
                Completed = 0,
                WorkPackegedCompleted = 0,
                EstimatedCompleted = 0,
                TypeId = projectTypes[i - 1],
                Active = i % 2 == 0 ? true : false
            };
            builder.Entity<Project>().HasData(project);
            projects.Add(project);

            // Customers
            var customerId = random.Next(123456789, 999999999) + i * 10 + 28;
            User customer = new User()
            {
                Id = customerId,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                LastName = "Alexandros_" + Convert.ToString(i),
                FirstName = "Platanios_Customer_" + Convert.ToString(i),
                ProxyAddress = "alexpl_{i}@gmail.com",
                Phone1 = "694927778" + Convert.ToString(i),
                Description = "Test Description Customer " + Convert.ToString(i),
                ProjectId = projectId,
            };
            builder.Entity<User>().HasData(customer);
            Email email_28 = new Email()
            {
                Id = random.Next(123456789, 999999999) + random.Next(0, 33),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Address = "alexpl_{i}@gmail.com",
                UserId = customerId
            };
            builder.Entity<Email>().HasData(email_28);
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

        // // Project Production Management 
        var projectPmId = random.Next(123456789, 999999999) + 11 * 2;
        Project projectPM = new Project()
        {
            Id = projectPmId,
            CreatedDate = createdDate,
            LastUpdatedDate = createdDate,
            Code = "D-22-16-PM",
            Name = "Project_PM",
            Description = "Test Description Project_PM",
            DurationDate = createdDate.AddMonths(1),
            EstPaymentDate = createdDate.AddMonths(2),
            PaymentDate = createdDate.AddMonths(1),
            DeadLine = createdDate.AddMonths(3),
            WorkPackege = createdDate.AddMonths(2),
            DelayInPayment = Convert.ToInt32(Math.Pow(1, 2)),
            PaymentDetailes = "Payment Detailes For Project_PM",
            DayCost = 111,
            Bank = "ALPHA",
            PaidFee = 45,
            DaysUntilPayment = (createdDate.AddDays(90) - createdDate).Days,
            PendingPayments = 2,
            CalculationDaly = 345,
            EstimatedMandays = 100 / 8,
            EstimatedHours = 1500,
            Completed = 0,
            WorkPackegedCompleted = 0,
            EstimatedCompleted = 0,
            TypeId = project_type_5_Id,
            Active = true
        };
        builder.Entity<Project>().HasData(projectPM);
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
                    EstimatedHours = 500,
                    ProjectId = projects[i].Id,
                    Completed = 0
                };
                builder.Entity<Discipline>().HasData(discipline);
                disciplines.Add(discipline);
            }
        }

        // Add Discipline Project Manager Hours To Project PM Hours
        var discipline_pm_hours_Id = random.Next(123456789, 999999999) * 8;
        Discipline discipline_pm_hours = new Discipline()
        {
            Id = discipline_pm_hours_Id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            TypeId = discipline_pm_hours_type_Id,
            EstimatedHours = 500,
            ProjectId = projectPmId,
            Completed = 0
        };
        builder.Entity<Discipline>().HasData(discipline_pm_hours);
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

        // Create Drawings For Discipline Project Manager Hours
        for (int j = 0; j < drawingTypes.Count; j++)
        {
            var drawing_Id = random.Next(123456789, 999999999);
            Drawing drawing = new Drawing()
            {
                Id = drawing_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                TypeId = drawingTypes[j].Id,
                DisciplineId = discipline_pm_hours_Id,
                CompletionEstimation = 0,
                CompletionDate = DateTime.Now.AddDays(11)
            };
            builder.Entity<Drawing>().HasData(drawing);
            drawings.Add(drawing);
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
            }
        }

        // Create Others For Discipline Project Manager Hours
        for (int j = 0; j < otherTypes.Count; j++)
        {
            var other_Id = random.Next(123456789, 999999999);
            Other other = new Other()
            {
                Id = other_Id,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                TypeId = otherTypes[j].Id,
                DisciplineId = discipline_pm_hours_Id,
                CompletionEstimation = 0
            };
            builder.Entity<Other>().HasData(other);
        }
        #endregion

        #region Connect Project Manager With Every Project
        var pm_index = 0;
        for (var i = 0; i < projects.Count; i++)
        {
            ProjectPmanager dq_other = new ProjectPmanager()
            {
                Id = random.Next(123456789, 999999999) + i,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                ProjectId = projects[i].Id,
                ProjectManagerId = projectManagers[pm_index].Id
            };
            builder.Entity<ProjectPmanager>().HasData(dq_other);

            if (pm_index < projectManagers.Count - 1)
                pm_index++;
            else
                pm_index = 0;
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