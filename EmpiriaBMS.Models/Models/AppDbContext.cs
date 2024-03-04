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

        var employes_roles_ids = new List<int>()
        {
            role_1_id,
            role_2_id,
            role_3_id,
            role_4_id,
            role_5_id,
            role_6_id
        }.ToArray();
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
        RolePermission rp_16 = new RolePermission()
        {
            Id = random.Next(123456789, 999999999) * 9,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            RoleId = role_5_id,
            PermissionId = per_3_id
        };
        builder.Entity<RolePermission>().HasData(rp_16);

        // CTO || Dashboard Assign Engineer
        RolePermission rp_17 = new RolePermission()
        {
            Id = random.Next(123456789, 999999999) * 9,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            RoleId = role_5_id,
            PermissionId = per_4_id
        };
        builder.Entity<RolePermission>().HasData(rp_17);

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
        #endregion

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
