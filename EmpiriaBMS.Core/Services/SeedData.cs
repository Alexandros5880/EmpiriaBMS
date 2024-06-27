using EmpiriaBMS.Core.Services.DBManipulation;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpiriaBMS.Core.Services;

public class SeedData
{
    private List<int> permissionsIds = new List<int>();
    private List<int> rolesIds = new List<int>();


    protected readonly IDbContextFactory<AppDbContext> _dbContextFactory;

    public SeedData(IDbContextFactory<AppDbContext> dbFactory)
    {
        _dbContextFactory = dbFactory;
    }

    public async void CreateData()
    {
        await CeatePermissions();
        await CeateRoles();
        await CeateRolesPermissions();
        await CeateDefaultAdmins();
    }

    protected async Task CeatePermissions()
    {
        try
        {
            Random random = new Random();

            using (var context = _dbContextFactory.CreateDbContext())
            {
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

                await DatabaseBackupService.SetDbIdentityInsert(context, "Permissions", true);

                await SeedIfNotExists<Permission>(context, per_1);
                await SeedIfNotExists<Permission>(context, per_2);
                await SeedIfNotExists<Permission>(context, per_3);
                await SeedIfNotExists<Permission>(context, per_4);
                await SeedIfNotExists<Permission>(context, per_5);
                await SeedIfNotExists<Permission>(context, per_6);
                await SeedIfNotExists<Permission>(context, per_7);
                await SeedIfNotExists<Permission>(context, per_8);
                await SeedIfNotExists<Permission>(context, per_9);
                await SeedIfNotExists<Permission>(context, per_10);
                await SeedIfNotExists<Permission>(context, per_11);
                await SeedIfNotExists<Permission>(context, per_12);
                await SeedIfNotExists<Permission>(context, per_13);
                await SeedIfNotExists<Permission>(context, per_14);
                await SeedIfNotExists<Permission>(context, per_15);
                await SeedIfNotExists<Permission>(context, per_16);
                await SeedIfNotExists<Permission>(context, per_17);
                await SeedIfNotExists<Permission>(context, per_18);
                await SeedIfNotExists<Permission>(context, per_19);
                await SeedIfNotExists<Permission>(context, per_20);
                await SeedIfNotExists<Permission>(context, per_21);
                await SeedIfNotExists<Permission>(context, per_22);
                await SeedIfNotExists<Permission>(context, per_23);
                await SeedIfNotExists<Permission>(context, per_24);
                await SeedIfNotExists<Permission>(context, per_25);
                await SeedIfNotExists<Permission>(context, per_26);
                await SeedIfNotExists<Permission>(context, per_27);
                await SeedIfNotExists<Permission>(context, per_28);
                await SeedIfNotExists<Permission>(context, per_29);
                await SeedIfNotExists<Permission>(context, per_30);
                await SeedIfNotExists<Permission>(context, per_31);
                await SeedIfNotExists<Permission>(context, per_32);
                await SeedIfNotExists<Permission>(context, per_33);
                await SeedIfNotExists<Permission>(context, per_34);
                await SeedIfNotExists<Permission>(context, per_35);
                await SeedIfNotExists<Permission>(context, per_36);

                await DatabaseBackupService.SetDbIdentityInsert(context, "Permissions", false);

                permissionsIds.Clear();
                permissionsIds.Add(per_1.Id);
                permissionsIds.Add(per_2.Id);
                permissionsIds.Add(per_3.Id);
                permissionsIds.Add(per_4.Id);
                permissionsIds.Add(per_5.Id);
                permissionsIds.Add(per_6.Id);
                permissionsIds.Add(per_7.Id);
                permissionsIds.Add(per_8.Id);
                permissionsIds.Add(per_9.Id);
                permissionsIds.Add(per_10.Id);
                permissionsIds.Add(per_11.Id);
                permissionsIds.Add(per_12.Id);
                permissionsIds.Add(per_13.Id);
                permissionsIds.Add(per_14.Id);
                permissionsIds.Add(per_15.Id);
                permissionsIds.Add(per_16.Id);
                permissionsIds.Add(per_17.Id);
                permissionsIds.Add(per_18.Id);
                permissionsIds.Add(per_19.Id);
                permissionsIds.Add(per_20.Id);
                permissionsIds.Add(per_21.Id);
                permissionsIds.Add(per_22.Id);
                permissionsIds.Add(per_23.Id);
                permissionsIds.Add(per_24.Id);
                permissionsIds.Add(per_25.Id);
                permissionsIds.Add(per_26.Id);
                permissionsIds.Add(per_27.Id);
                permissionsIds.Add(per_28.Id);
                permissionsIds.Add(per_29.Id);
                permissionsIds.Add(per_30.Id);
                permissionsIds.Add(per_31.Id);
                permissionsIds.Add(per_32.Id);
                permissionsIds.Add(per_33.Id);
                permissionsIds.Add(per_34.Id);
                permissionsIds.Add(per_35.Id);
                permissionsIds.Add(per_36.Id);
            }
        }
        catch (Exception ex)
        {
            // TODO: Log Exception
            Console.WriteLine($"Exception On SeedData.CeatePermissions(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    protected async Task CeateRoles()
    {

        Random random = new Random();

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

        rolesIds.Add(role_1_id);
        rolesIds.Add(role_2_id);
        rolesIds.Add(role_3_id);
        rolesIds.Add(role_4_id);
        rolesIds.Add(role_5_id);
        rolesIds.Add(role_6_id);
        rolesIds.Add(role_7_id);
        rolesIds.Add(role_8_id);
        rolesIds.Add(role_9_id);
        rolesIds.Add(role_10_id);
        rolesIds.Add(role_11_id);

        List<Role> roles = new List<Role>();
        roles.Add(role_1);
        roles.Add(role_2);
        roles.Add(role_3);
        roles.Add(role_4);
        roles.Add(role_5);
        roles.Add(role_6);
        roles.Add(role_7);
        roles.Add(role_8);
        roles.Add(role_9);
        roles.Add(role_10);
        roles.Add(role_11);

        using (var context = _dbContextFactory.CreateDbContext())
        {
            await DatabaseBackupService.SetDbIdentityInsert(context, "Roles", true);
            foreach (var role in roles)
            {
                try
                {
                    await SeedIfNotExists<Role>(context, role);
                }
                catch (Exception ex)
                {
                    // TODO: Log Exception
                    Console.WriteLine($"Exception On SeedData.CeateRoles(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
                }
            }

            await DatabaseBackupService.SetDbIdentityInsert(context, "Roles", false);
        }

    }

    protected async Task CeateRolesPermissions()
    {
        try
        {
            Random random = new Random();

            using (var context = _dbContextFactory.CreateDbContext())
            {
                // Designer
                // Designer || See Dashboard Layout
                RolePermission rp_1 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 0),
                    PermissionId = GetRecordAtIndex(permissionsIds, 0)
                };

                // Designer || Dashboard Edit My Hours
                RolePermission rp_2 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 0),
                    PermissionId = GetRecordAtIndex(permissionsIds, 1)
                };

                // Designer || Dashboard See My Hours
                RolePermission rp_30 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 0),
                    PermissionId = GetRecordAtIndex(permissionsIds, 7)
                };


                // Engineer
                // Engineer || See Dashboard Layout
                RolePermission rp_3 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 1),
                    PermissionId = GetRecordAtIndex(permissionsIds, 0)
                };

                // Engineer || Dashboard Edit My Hours
                RolePermission rp_4 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 1),
                    PermissionId = GetRecordAtIndex(permissionsIds, 1)
                };

                // Engineer || Dashboard Assign Designer
                RolePermission rp_5 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 1),
                    PermissionId = GetRecordAtIndex(permissionsIds, 2)
                };

                // Engineer || Dashboard See My Hours
                RolePermission rp_31 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 1),
                    PermissionId = GetRecordAtIndex(permissionsIds, 7)
                };

                // Engineer || See All Disciplines
                RolePermission rp_35 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 1),
                    PermissionId = GetRecordAtIndex(permissionsIds, 8)
                };

                // Engineer || See All Deliverables
                RolePermission rp_41 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 1),
                    PermissionId = GetRecordAtIndex(permissionsIds, 9)
                };


                // Project Manager
                // Project Manager || See Dashboard Layout
                RolePermission rp_6 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 2),
                    PermissionId = GetRecordAtIndex(permissionsIds, 0)
                };

                // Project Manager || Dashboard Edit My Hours
                RolePermission rp_7 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 2),
                    PermissionId = GetRecordAtIndex(permissionsIds, 1)
                };

                // Project Manager || Dashboard Assign Engineer
                RolePermission rp_8 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 2),
                    PermissionId = GetRecordAtIndex(permissionsIds, 3)
                };

                // Project Manager || Dashboard See My Hours
                RolePermission rp_32 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 2),
                    PermissionId = GetRecordAtIndex(permissionsIds, 7)
                };

                // Project Manager || See All Disciplines
                RolePermission rp_36 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 2),
                    PermissionId = GetRecordAtIndex(permissionsIds, 8)
                };

                // Project Manager || See All Deliverables
                RolePermission rp_43 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 2),
                    PermissionId = GetRecordAtIndex(permissionsIds, 9)
                };

                // Project Manager || Dashboard See KPIS
                RolePermission rp_68 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 2),
                    PermissionId = GetRecordAtIndex(permissionsIds, 16)
                };

                // Project Manager || See My Projects Missed DeadLine KPI
                RolePermission rp_69 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 2),
                    PermissionId = GetRecordAtIndex(permissionsIds, 21)
                };

                // Project Manager || See Active Delayed Project Types Counter KPI
                RolePermission rp_77 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 2),
                    PermissionId = GetRecordAtIndex(permissionsIds, 22)
                };


                // COO
                // COO || See Dashboard Layout
                RolePermission rp_9 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 3),
                    PermissionId = GetRecordAtIndex(permissionsIds, 0)
                };

                // COO || Dashboard Edit My Hours
                RolePermission rp_10 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 3),
                    PermissionId = GetRecordAtIndex(permissionsIds, 1)
                };

                // COO || Dashboard Assign Designer
                RolePermission rp_11 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 3),
                    PermissionId = GetRecordAtIndex(permissionsIds, 2)
                };

                // COO || Dashboard Assign Engineer
                RolePermission rp_12 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 3),
                    PermissionId = GetRecordAtIndex(permissionsIds, 3)
                };

                // COO || Dashboard Assign Project Manager
                RolePermission rp_13 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 3),
                    PermissionId = GetRecordAtIndex(permissionsIds, 4)
                };

                // COO || Dashboard See My Hours
                RolePermission rp_33 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 3),
                    PermissionId = GetRecordAtIndex(permissionsIds, 7)
                };

                // COO || See All Disciplines
                RolePermission rp_37 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 3),
                    PermissionId = GetRecordAtIndex(permissionsIds, 8)
                };

                // COO || See All Deliverables
                RolePermission rp_42 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 3),
                    PermissionId = GetRecordAtIndex(permissionsIds, 9)
                };

                // COO || See All Projects
                RolePermission rp_49 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 3),
                    PermissionId = GetRecordAtIndex(permissionsIds, 10)
                };

                // COO || Work on Project
                RolePermission rp_102 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 3),
                    PermissionId = GetRecordAtIndex(permissionsIds, 30)
                };

                // COO || Work on Offers
                RolePermission rp_103 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 3),
                    PermissionId = GetRecordAtIndex(permissionsIds, 31)
                };

                // COO || Work on Leds
                RolePermission rp_106 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 3),
                    PermissionId = GetRecordAtIndex(permissionsIds, 32)
                };

                // COO || See Next Year Income
                RolePermission rp_110 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 3),
                    PermissionId = GetRecordAtIndex(permissionsIds, 33)
                };


                // CTO
                // CTO || See Dashboard Layout
                RolePermission rp_14 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 0)
                };

                // CTO || Dashboard Edit My Hours
                RolePermission rp_15 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 1)
                };

                // CTO || Dashboard Assign Project Manager
                RolePermission rp_18 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 4)
                };

                // CTO || Dashboard Add Project
                RolePermission rp_19 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 5)
                };

                // CTO || Dashboard See My Hours
                RolePermission rp_34 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 7)
                };

                // CTO || See All Disciplines
                RolePermission rp_38 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 8)
                };

                // CTO || See All Deliverables
                RolePermission rp_45 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 9)
                };

                // CTO || See All Projects
                RolePermission rp_48 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 10)
                };

                // CTO || Dashboard Edit Project
                RolePermission rp_60 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 11)
                };

                // CTO || Dashboard Edit Discipline
                RolePermission rp_63 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 13)
                };

                // CTO || Dashboard Edit Deliverable
                RolePermission rp_64 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 14)
                };

                // CTO || Dashboard Edit Other
                RolePermission rp_65 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 15)
                };

                // CTO || Dashboard See KPIS
                RolePermission rp_66 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 16)
                };

                // CTO || See Hours Per Role KPI
                RolePermission rp_70 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 17)
                };

                // CTO || See Active Delayed Projects KPI
                RolePermission rp_71 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 18)
                };

                // CTO || See All Projects Missed DeadLine KPI
                RolePermission rp_72 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 19)
                };

                // CTO || See Active Delayed Project Types Counter KPI
                RolePermission rp_78 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 22)
                };

                // CTO || Display Projects Code
                RolePermission rp_80 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 12)
                };

                // CTO || See Offers
                RolePermission rp_81 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 23)
                };

                // CTO || See Tender Table KPI
                RolePermission rp_83 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 24)
                };

                // CTO || See Delayed Payments KPI
                RolePermission rp_85 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 25)
                };

                // CTO || See Pendings Payments KPI
                RolePermission rp_87 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 26)
                };

                // CTO || See Invoices
                RolePermission rp_91 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 28)
                };

                // CTO || See Excpences
                RolePermission rp_92 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 29)
                };

                // CTO || Work on Project
                RolePermission rp_101 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 30)
                };

                // CTO || Work on Offers
                RolePermission rp_104 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 31)
                };

                // CTO || Work on Leds
                RolePermission rp_107 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 32)
                };

                // CTO || See Next Year Income
                RolePermission rp_111 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 33)
                };

                // CTO || Backup Database
                RolePermission rp_113 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 34)
                };

                // CTO || Restore Database
                RolePermission rp_114 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 4),
                    PermissionId = GetRecordAtIndex(permissionsIds, 35)
                };


                // CEO
                // CEO || See Dashboard Layout
                RolePermission rp_20 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 0)
                };

                // CEO || Dashboard Edit My Hours
                RolePermission rp_21 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 1)
                };

                // CEO || Dashboard Assign Designer
                RolePermission rp_22 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 2)
                };

                // CEO || Dashboard Assign Engineer
                RolePermission rp_23 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 3)
                };

                // CEO || Dashboard Assign Project Manager
                RolePermission rp_24 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 4)
                };

                // CEO || Dashboard Add Project
                RolePermission rp_25 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 5)
                };

                // CEO || See All Disciplines
                RolePermission rp_39 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 8)
                };

                // CEO || See All Deliverable
                RolePermission rp_44 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 9)
                };

                // CEO || See All Projects
                RolePermission rp_47 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 10)
                };

                // CEO || Display Projects Code
                RolePermission rp_61 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 12)
                };

                // CEO || Dashboard Add Project
                RolePermission rp_62 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 11)
                };

                // CEO || Dashboard See KPIS
                RolePermission rp_67 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 16)
                };

                // CEO || See Hours Per Role KPI
                RolePermission rp_73 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 17)
                };

                // CEO || See Active Delayed Projects KPI
                RolePermission rp_74 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 18)
                };

                // CEO || See All Projects Missed DeadLine KPI
                RolePermission rp_75 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 19)
                };

                // CEO || See Employee Turnover KPI
                RolePermission rp_76 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 20)
                };

                // CEO || See Active Delayed Project Types Counter KPI
                RolePermission rp_79 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 22)
                };

                // CEO || See Offers
                RolePermission rp_82 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 23)
                };

                // CEO || See Tender Table KPI
                RolePermission rp_84 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 24)
                };

                // CEO || See Delayed Payments KPI
                RolePermission rp_86 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 25)
                };

                // CEO || See Pendings Payments KPI
                RolePermission rp_88 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 26)
                };

                // CEO || See Teams Requested Users
                RolePermission rp_90 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 27)
                };

                // CEO || See Invoices
                RolePermission rp_93 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 28)
                };

                // CEO || See Excpences
                RolePermission rp_94 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 29)
                };

                // CEO || Work on Project
                RolePermission rp_105 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 30)
                };

                // CEO || Work on Offers
                RolePermission rp_108 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 31)
                };

                // CEO || Work on Leds
                RolePermission rp_109 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 32)
                };

                // CEO || See Next Year Income
                RolePermission rp_112 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 33)
                };

                // CEO || Backup Database
                RolePermission rp_115 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 34)
                };

                // CEO || Restore Database
                RolePermission rp_116 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 5),
                    PermissionId = GetRecordAtIndex(permissionsIds, 35)
                };


                // Guest
                // Guest || See Dashboard Layout
                RolePermission rp_27 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 6),
                    PermissionId = GetRecordAtIndex(permissionsIds, 0)
                };


                // Customer
                // Customer || See Dashboard Layout
                RolePermission rp_28 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 7),
                    PermissionId = GetRecordAtIndex(permissionsIds, 0)
                };


                // Admin
                // Admin || See Dashboard Layout
                RolePermission rp_29 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 8),
                    PermissionId = GetRecordAtIndex(permissionsIds, 6)
                };

                // Admin || See All Disciplines
                RolePermission rp_40 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 8),
                    PermissionId = GetRecordAtIndex(permissionsIds, 8)
                };

                // Admin || See All Deliverables
                RolePermission rp_46 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 8),
                    PermissionId = GetRecordAtIndex(permissionsIds, 9)
                };

                // Admin || See All Projects
                RolePermission rp_50 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 8),
                    PermissionId = GetRecordAtIndex(permissionsIds, 10)
                };

                // Admin || See Teams Requested Users
                RolePermission rp_100 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 8),
                    PermissionId = GetRecordAtIndex(permissionsIds, 27)
                };

                // Admin || Backup Database
                RolePermission rp_117 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 8),
                    PermissionId = GetRecordAtIndex(permissionsIds, 34)
                };

                // Admin || Restore Database
                RolePermission rp_118 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 8),
                    PermissionId = GetRecordAtIndex(permissionsIds, 35)
                };


                // Secretariat 
                // Secretariat || See Dashboard Layout
                RolePermission rp_51 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 9),
                    PermissionId = GetRecordAtIndex(permissionsIds, 0)
                };

                // Secretariat || Dashboard Edit My Hours
                RolePermission rp_52 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 9),
                    PermissionId = GetRecordAtIndex(permissionsIds, 1)
                };

                // Secretariat || Dashboard See My Hours
                RolePermission rp_56 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 9),
                    PermissionId = GetRecordAtIndex(permissionsIds, 7)
                };

                // Secretariat || See All Disciplines
                RolePermission rp_57 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 9),
                    PermissionId = GetRecordAtIndex(permissionsIds, 8)
                };

                // Secretariat || See All Deliverables
                RolePermission rp_58 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 9),
                    PermissionId = GetRecordAtIndex(permissionsIds, 9)
                };

                // Secretariat || See All Projects
                RolePermission rp_59 = new RolePermission()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    RoleId = GetRecordAtIndex(rolesIds, 9),
                    PermissionId = GetRecordAtIndex(permissionsIds, 10)
                };

                await DatabaseBackupService.SetDbIdentityInsert(context, "RolesPermissions", true);

                await SeedIfNotExists<RolePermission>(context, rp_1);
                await SeedIfNotExists<RolePermission>(context, rp_2);
                await SeedIfNotExists<RolePermission>(context, rp_3);
                await SeedIfNotExists<RolePermission>(context, rp_4);
                await SeedIfNotExists<RolePermission>(context, rp_5);
                await SeedIfNotExists<RolePermission>(context, rp_6);
                await SeedIfNotExists<RolePermission>(context, rp_7);
                await SeedIfNotExists<RolePermission>(context, rp_8);
                await SeedIfNotExists<RolePermission>(context, rp_9);
                await SeedIfNotExists<RolePermission>(context, rp_10);
                await SeedIfNotExists<RolePermission>(context, rp_11);
                await SeedIfNotExists<RolePermission>(context, rp_12);
                await SeedIfNotExists<RolePermission>(context, rp_13);
                await SeedIfNotExists<RolePermission>(context, rp_14);
                await SeedIfNotExists<RolePermission>(context, rp_15);
                //await SeedIfNotExists<RolePermission>(context, rp_16);
                //await SeedIfNotExists<RolePermission>(context, rp_17);
                await SeedIfNotExists<RolePermission>(context, rp_18);
                await SeedIfNotExists<RolePermission>(context, rp_19);
                await SeedIfNotExists<RolePermission>(context, rp_20);
                await SeedIfNotExists<RolePermission>(context, rp_21);
                await SeedIfNotExists<RolePermission>(context, rp_22);
                await SeedIfNotExists<RolePermission>(context, rp_23);
                await SeedIfNotExists<RolePermission>(context, rp_24);
                await SeedIfNotExists<RolePermission>(context, rp_25);
                //await SeedIfNotExists<RolePermission>(context, rp_26);
                await SeedIfNotExists<RolePermission>(context, rp_27);
                await SeedIfNotExists<RolePermission>(context, rp_28);
                await SeedIfNotExists<RolePermission>(context, rp_29);
                await SeedIfNotExists<RolePermission>(context, rp_30);
                await SeedIfNotExists<RolePermission>(context, rp_31);
                await SeedIfNotExists<RolePermission>(context, rp_32);
                await SeedIfNotExists<RolePermission>(context, rp_33);
                await SeedIfNotExists<RolePermission>(context, rp_34);
                await SeedIfNotExists<RolePermission>(context, rp_35);
                await SeedIfNotExists<RolePermission>(context, rp_36);
                await SeedIfNotExists<RolePermission>(context, rp_37);
                await SeedIfNotExists<RolePermission>(context, rp_38);
                await SeedIfNotExists<RolePermission>(context, rp_39);
                await SeedIfNotExists<RolePermission>(context, rp_40);
                await SeedIfNotExists<RolePermission>(context, rp_41);
                await SeedIfNotExists<RolePermission>(context, rp_42);
                await SeedIfNotExists<RolePermission>(context, rp_43);
                await SeedIfNotExists<RolePermission>(context, rp_44);
                await SeedIfNotExists<RolePermission>(context, rp_45);
                await SeedIfNotExists<RolePermission>(context, rp_46);
                await SeedIfNotExists<RolePermission>(context, rp_47);
                await SeedIfNotExists<RolePermission>(context, rp_48);
                await SeedIfNotExists<RolePermission>(context, rp_49);
                await SeedIfNotExists<RolePermission>(context, rp_50);
                await SeedIfNotExists<RolePermission>(context, rp_51);
                await SeedIfNotExists<RolePermission>(context, rp_52);
                //await SeedIfNotExists<RolePermission>(context, rp_53);
                //await SeedIfNotExists<RolePermission>(context, rp_54);
                //await SeedIfNotExists<RolePermission>(context, rp_55);
                await SeedIfNotExists<RolePermission>(context, rp_56);
                await SeedIfNotExists<RolePermission>(context, rp_57);
                await SeedIfNotExists<RolePermission>(context, rp_58);
                await SeedIfNotExists<RolePermission>(context, rp_59);
                await SeedIfNotExists<RolePermission>(context, rp_60);
                await SeedIfNotExists<RolePermission>(context, rp_61);
                await SeedIfNotExists<RolePermission>(context, rp_62);
                await SeedIfNotExists<RolePermission>(context, rp_63);
                await SeedIfNotExists<RolePermission>(context, rp_64);
                await SeedIfNotExists<RolePermission>(context, rp_65);
                await SeedIfNotExists<RolePermission>(context, rp_66);
                await SeedIfNotExists<RolePermission>(context, rp_67);
                await SeedIfNotExists<RolePermission>(context, rp_68);
                await SeedIfNotExists<RolePermission>(context, rp_69);
                await SeedIfNotExists<RolePermission>(context, rp_70);
                await SeedIfNotExists<RolePermission>(context, rp_71);
                await SeedIfNotExists<RolePermission>(context, rp_72);
                await SeedIfNotExists<RolePermission>(context, rp_73);
                await SeedIfNotExists<RolePermission>(context, rp_74);
                await SeedIfNotExists<RolePermission>(context, rp_75);
                await SeedIfNotExists<RolePermission>(context, rp_76);
                await SeedIfNotExists<RolePermission>(context, rp_77);
                await SeedIfNotExists<RolePermission>(context, rp_78);
                await SeedIfNotExists<RolePermission>(context, rp_79);
                await SeedIfNotExists<RolePermission>(context, rp_80);
                await SeedIfNotExists<RolePermission>(context, rp_81);
                await SeedIfNotExists<RolePermission>(context, rp_82);
                await SeedIfNotExists<RolePermission>(context, rp_83);
                await SeedIfNotExists<RolePermission>(context, rp_84);
                await SeedIfNotExists<RolePermission>(context, rp_85);
                await SeedIfNotExists<RolePermission>(context, rp_86);
                await SeedIfNotExists<RolePermission>(context, rp_87);
                await SeedIfNotExists<RolePermission>(context, rp_88);
                //await SeedIfNotExists<RolePermission>(context, rp_89);
                await SeedIfNotExists<RolePermission>(context, rp_90);
                await SeedIfNotExists<RolePermission>(context, rp_91);
                await SeedIfNotExists<RolePermission>(context, rp_92);
                await SeedIfNotExists<RolePermission>(context, rp_93);
                await SeedIfNotExists<RolePermission>(context, rp_94);
                //await SeedIfNotExists<RolePermission>(context, rp_95);
                //await SeedIfNotExists<RolePermission>(context, rp_96);
                //await SeedIfNotExists<RolePermission>(context, rp_97);
                //await SeedIfNotExists<RolePermission>(context, rp_98);
                //await SeedIfNotExists<RolePermission>(context, rp_99);
                await SeedIfNotExists<RolePermission>(context, rp_100);
                await SeedIfNotExists<RolePermission>(context, rp_101);
                await SeedIfNotExists<RolePermission>(context, rp_102);
                await SeedIfNotExists<RolePermission>(context, rp_103);
                await SeedIfNotExists<RolePermission>(context, rp_104);
                await SeedIfNotExists<RolePermission>(context, rp_105);
                await SeedIfNotExists<RolePermission>(context, rp_106);
                await SeedIfNotExists<RolePermission>(context, rp_107);
                await SeedIfNotExists<RolePermission>(context, rp_108);
                await SeedIfNotExists<RolePermission>(context, rp_109);
                await SeedIfNotExists<RolePermission>(context, rp_110);
                await SeedIfNotExists<RolePermission>(context, rp_111);
                await SeedIfNotExists<RolePermission>(context, rp_112);
                await SeedIfNotExists<RolePermission>(context, rp_113);
                await SeedIfNotExists<RolePermission>(context, rp_114);
                await SeedIfNotExists<RolePermission>(context, rp_115);
                await SeedIfNotExists<RolePermission>(context, rp_116);
                await SeedIfNotExists<RolePermission>(context, rp_117);
                await SeedIfNotExists<RolePermission>(context, rp_118);
                //await SeedIfNotExists<RolePermission>(context, rp_119);
                //await SeedIfNotExists<RolePermission>(context, rp_120);

                await DatabaseBackupService.SetDbIdentityInsert(context, "RolesPermissions", false);
            }
        }
        catch (Exception ex)
        {
            // TODO: Log Exception
            Console.WriteLine($"Exception On SeedData.CeateRolesPermissions(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    protected async Task CeateDefaultAdmins()
    {
        try
        {
            Random random = new Random();

            using (var context = _dbContextFactory.CreateDbContext())
            {
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

                // Email
                Email email_admin_1 = new Email()
                {
                    Id = random.Next(123456789, 999999999) + random.Next(0, 33),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    Address = "empiriasoft@empiriasoftplat.onmicrosoft.com",
                    UserId = admin_1_Id
                };

                // Admin
                UserRole admin_role_1 = new UserRole()
                {
                    Id = random.Next(123456789, 999999999) / 3,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    UserId = admin_1_Id,
                    RoleId = GetRecordAtIndex(rolesIds, 8)
                };

                await DatabaseBackupService.SetDbIdentityInsert(context, "Users", true);
                await SeedIfNotExists<User>(context, admin_1);
                await DatabaseBackupService.SetDbIdentityInsert(context, "Users", false);

                await DatabaseBackupService.SetDbIdentityInsert(context, "Emails", true);
                await SeedIfNotExists<Email>(context, email_admin_1);
                await DatabaseBackupService.SetDbIdentityInsert(context, "Emails", false);

                await DatabaseBackupService.SetDbIdentityInsert(context, "UsersRoles", true);
                await SeedIfNotExists<UserRole>(context, admin_role_1);
                await DatabaseBackupService.SetDbIdentityInsert(context, "UsersRoles", false);
            }
        }
        catch (Exception ex)
        {
            // TODO: Log Exception
            Console.WriteLine($"Exception On SeedData.CeateDefaultAdmins(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    protected async Task CeateProjectCategories()
    {
        try
        {
            Random random = new Random();

            using (var context = _dbContextFactory.CreateDbContext())
            {

            }
        }
        catch (Exception ex)
        {
            // TODO: Log Exception
            Console.WriteLine($"Exception On SeedData.CeateProjectCategories(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    protected async Task CreateProjectSubCategories()
    {
        try
        {
            Random random = new Random();

            using (var context = _dbContextFactory.CreateDbContext())
            {

            }
        }
        catch (Exception ex)
        {
            // TODO: Log Exception
            Console.WriteLine($"Exception On SeedData.CreateProjectSubCategories(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    protected async Task CreateProjectStages()
    {
        try
        {
            Random random = new Random();

            using (var context = _dbContextFactory.CreateDbContext())
            {

            }
        }
        catch (Exception ex)
        {
            // TODO: Log Exception
            Console.WriteLine($"Exception On SeedData.CreateProjectStages(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    protected async Task CreateInvoiceTypes()
    {
        try
        {
            Random random = new Random();

            using (var context = _dbContextFactory.CreateDbContext())
            {

            }
        }
        catch (Exception ex)
        {
            // TODO: Log Exception
            Console.WriteLine($"Exception On SeedData.CreateInvoiceTypes(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    protected async Task CreatePaymentTypes()
    {
        try
        {
            Random random = new Random();

            using (var context = _dbContextFactory.CreateDbContext())
            {

            }
        }
        catch (Exception ex)
        {
            // TODO: Log Exception
            Console.WriteLine($"Exception On SeedData.CreatePaymentTypes(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    protected async Task CreateOfferTypes()
    {
        try
        {
            Random random = new Random();

            using (var context = _dbContextFactory.CreateDbContext())
            {

            }
        }
        catch (Exception ex)
        {
            // TODO: Log Exception
            Console.WriteLine($"Exception On SeedData.CreateOfferTypes(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    protected async Task CreateOfferState()
    {
        try
        {
            Random random = new Random();

            using (var context = _dbContextFactory.CreateDbContext())
            {

            }
        }
        catch (Exception ex)
        {
            // TODO: Log Exception
            Console.WriteLine($"Exception On SeedData.CreateOfferState(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    protected async Task CreateSecretaries()
    {
        try
        {
            Random random = new Random();

            using (var context = _dbContextFactory.CreateDbContext())
            {

            }
        }
        catch (Exception ex)
        {
            // TODO: Log Exception
            Console.WriteLine($"Exception On SeedData.CreateSecretaries(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    protected async Task CreateDraftmen()
    {
        try
        {
            Random random = new Random();

            using (var context = _dbContextFactory.CreateDbContext())
            {

            }
        }
        catch (Exception ex)
        {
            // TODO: Log Exception
            Console.WriteLine($"Exception On SeedData.CreateDraftmen(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    protected async Task CreateEngineers()
    {
        try
        {
            Random random = new Random();

            using (var context = _dbContextFactory.CreateDbContext())
            {

            }
        }
        catch (Exception ex)
        {
            // TODO: Log Exception
            Console.WriteLine($"Exception On SeedData.CreateEngineers(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    protected async Task CreateProjectManagers()
    {
        try
        {
            Random random = new Random();

            using (var context = _dbContextFactory.CreateDbContext())
            {

            }
        }
        catch (Exception ex)
        {
            // TODO: Log Exception
            Console.WriteLine($"Exception On SeedData.CreateProjectManagers(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    #region Private Helper Methods
    private static async Task SeedIfNotExists<T>(DbContext context, T entity) where T : class
    {
        var primaryKey = context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.First().Name;
        var primaryKeyValue = entity.GetType().GetProperty(primaryKey).GetValue(entity);
        bool exists = context.Set<T>().Any(e => EF.Property<object>(e, primaryKey).Equals(primaryKeyValue));
        if (!exists)
        {
            var result = await context.Set<T>().AddAsync(entity);
            context.SaveChanges();
        }
    }

    private static T GetRecordAtIndex<T>(List<T> list, int index)
    {
        if (index < 0 || index >= list.Count)
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");

        return list[index];
    }
    #endregion
}
