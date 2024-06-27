using EmpiriaBMS.Core.Services.DBManipulation;
using EmpiriaBMS.Models.Enum;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpiriaBMS.Core.Services;

public class SeedData
{
    private List<int> permissionsIds = new List<int>();
    private List<int> rolesIds = new List<int>();
    private List<ProjectCategory> projectCategories = new List<ProjectCategory>();
    private List<ProjectSubCategory> projectSubCategories = new List<ProjectSubCategory>();
    private List<ProjectStage> projectStages = new List<ProjectStage>();
    private List<InvoiceType> invoiceTypes = new List<InvoiceType>();
    private List<PaymentType> paymentTypes = new List<PaymentType>();
    private List<OfferType> offerTypes = new List<OfferType>();
    private List<OfferState> offerStates = new List<OfferState>();
    private List<DisciplineType> disciplineTypes = new List<DisciplineType>();
    private List<DeliverableType> deliverableTypes = new List<DeliverableType>();
    private List<SupportiveWorkType> otherTypes = new List<SupportiveWorkType>();
    private List<User> draftsmen = new List<User>();
    private List<User> engineers = new List<User>();
    private List<User> projectManagers = new List<User>();
    private List<Project> projects = new List<Project>();
    private List<Project> msprojects = new List<Project>();
    private List<Discipline> disciplines = new List<Discipline>();
    private List<Deliverable> deliverables = new List<Deliverable>();
    private List<SupportiveWork> supportiveWorks = new List<SupportiveWork>();

    protected readonly IDbContextFactory<AppDbContext> _dbContextFactory;

    public SeedData(IDbContextFactory<AppDbContext> dbFactory)
    {
        _dbContextFactory = dbFactory;
    }

    public async Task CreateData()
    {
        var tasks = new List<Func<Task>>()
        {
            CeatePermissions,
            //CeateRoles,
            //CeateRolesPermissions,
            //CeateDefaultAdmins,
            //CeateProjectCategories,
            //CreateProjectSubCategories,
            //CreateProjectStages,
            //CreateInvoiceTypes,
            //CreatePaymentTypes,
            //CreateOfferTypes,
            //CreateOfferState,
            //CreateDisciplineTypes,
            //CreateDeliverableTypes,
            //CreateSupportiveWorkTypes,
            //CreateSecretaries,
            //CreateDraftmen,
            //CreateEngineers,
            //CreateProjectManagers,
            //CreateProjects,
            //CreateMissedDeadLineProjects,
            //CreateDisciplines,
            //CreateDeliverables,
            //CreateSupportiveWorks,
            //ConnectAllEngineersWithEveryDisclipline,
            //ConnectEveryDraftmanWithEverySupportiveWork
        };

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n\nStarting add Seed Data to DB.");
        for (int i = 0; i < tasks.Count; i++)
        {
            await tasks[i]();
            UpdateProgress(i + 1, tasks.Count);
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Seed Data added.\n\n");
        Console.ForegroundColor = ConsoleColor.White;
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
            //Console.WriteLine($"Exception On SeedData.CeatePermissions(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
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
                    //Console.WriteLine($"Exception On SeedData.CeateRoles(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
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
            //Console.WriteLine($"Exception On SeedData.CeateRolesPermissions(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
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
            //Console.WriteLine($"Exception On SeedData.CeateDefaultAdmins(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    protected async Task CeateProjectCategories()
    {
        Random random = new Random();

        projectCategories.Clear();

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
        projectCategories.Add(project_category_8);

        using (var context = _dbContextFactory.CreateDbContext())
        {
            await DatabaseBackupService.SetDbIdentityInsert(context, "ProjectsCategories", true);
            foreach (var pc in projectCategories)
            {
                try
                {
                    await SeedIfNotExists<ProjectCategory>(context, pc);
                }
                catch (Exception ex)
                {
                    // TODO: Log Exception
                    //Console.WriteLine($"Exception On SeedData.CeateProjectCategories(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
                }
            }
            await DatabaseBackupService.SetDbIdentityInsert(context, "ProjectsCategories", false);
        }
    }

    protected async Task CreateProjectSubCategories()
    {
        Random random = new Random();

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

        projectSubCategories.Clear();

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
            projectSubCategories.Add(project_sub_category);
        }



        using (var context = _dbContextFactory.CreateDbContext())
        {
            await DatabaseBackupService.SetDbIdentityInsert(context, "ProjectsSubCategories", true);
            foreach (var pc in projectSubCategories)
            {
                try
                {
                    await SeedIfNotExists<ProjectSubCategory>(context, pc);
                }
                catch (Exception ex)
                {
                    // TODO: Log Exception
                    //Console.WriteLine($"Exception On SeedData.CeateProjectSubCategories(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
                }
            }
            await DatabaseBackupService.SetDbIdentityInsert(context, "ProjectsSubCategories", false);
        }
    }

    protected async Task CreateProjectStages()
    {
        Random random = new Random();

        projectStages.Clear();

        var project_stage_1_Id = random.Next(123456789, 999999999) + 33;
        ProjectStage project_stage_1 = new ProjectStage()
        {
            Id = project_stage_1_Id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Buildings",
        };
        projectStages.Add(project_stage_1);

        var project_stage_2_Id = random.Next(123456789, 999999999) + 33;
        ProjectStage project_stage_2 = new ProjectStage()
        {
            Id = project_stage_2_Id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Final Design",
        };
        projectStages.Add(project_stage_2);

        var project_stage_3_Id = random.Next(123456789, 999999999) + 33;
        ProjectStage project_stage_3 = new ProjectStage()
        {
            Id = project_stage_3_Id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Detailed Design",
        };
        projectStages.Add(project_stage_3);

        var project_stage_4_Id = random.Next(123456789, 999999999) + 33;
        ProjectStage project_stage_4 = new ProjectStage()
        {
            Id = project_stage_4_Id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Construction Supervision",
        };
        projectStages.Add(project_stage_4);

        var project_stage_5_Id = random.Next(123456789, 999999999) + 33;
        ProjectStage project_stage_5 = new ProjectStage()
        {
            Id = project_stage_5_Id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Us Build Joins",
        };
        projectStages.Add(project_stage_5);

        using (var context = _dbContextFactory.CreateDbContext())
        {
            await DatabaseBackupService.SetDbIdentityInsert(context, "ProjectsStages", true);
            foreach (var pstage in projectStages)
            {
                try
                {
                    await SeedIfNotExists<ProjectStage>(context, pstage);
                }
                catch (Exception ex)
                {
                    // TODO: Log Exception
                    //Console.WriteLine($"Exception On SeedData.CreateProjectStages(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
                }
            }
            await DatabaseBackupService.SetDbIdentityInsert(context, "ProjectsStages", false);
        }
    }

    protected async Task CreateInvoiceTypes()
    {
        Random random = new Random();

        invoiceTypes.Clear();

        var it_1_id = random.Next(123456789, 999999999) + random.Next(0, 333) + 10;
        InvoiceType it_1 = new InvoiceType()
        {
            Id = it_1_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "PUBLIC"
        };
        invoiceTypes.Add(it_1);

        var it_2_id = random.Next(123456789, 999999999) + random.Next(0, 333) + 10;
        InvoiceType it_2 = new InvoiceType()
        {
            Id = it_2_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "PRIVATE"
        };
        invoiceTypes.Add(it_2);

        var it_3_id = random.Next(123456789, 999999999) + random.Next(0, 333) + 10;
        InvoiceType it_3 = new InvoiceType()
        {
            Id = it_3_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "INTERNATIONAL"
        };
        invoiceTypes.Add(it_3);

        using (var context = _dbContextFactory.CreateDbContext())
        {
            await DatabaseBackupService.SetDbIdentityInsert(context, "InvoicesTypes", true);
            foreach (var item in invoiceTypes)
            {
                try
                {
                    await SeedIfNotExists<InvoiceType>(context, item);
                }
                catch (Exception ex)
                {
                    // TODO: Log Exception
                    //Console.WriteLine($"Exception On SeedData.CreateInvoiceTypes(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
                }
            }
            await DatabaseBackupService.SetDbIdentityInsert(context, "InvoicesTypes", false);
        }
    }

    protected async Task CreatePaymentTypes()
    {
        Random random = new Random();

        paymentTypes.Clear();

        // BANK
        var pmt_1_id = random.Next(123456789, 999999999) + random.Next(0, 333) + 55;
        PaymentType pmt_1 = new PaymentType()
        {
            Id = pmt_1_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = $"BANK"
        };
        paymentTypes.Add(pmt_1);

        // TRANSFER
        var pmt_2_id = random.Next(123456789, 999999999) + random.Next(0, 333) + 55;
        PaymentType pmt_2 = new PaymentType()
        {
            Id = pmt_2_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = $"TRANSFER"
        };
        paymentTypes.Add(pmt_2);

        // CASH
        var pmt_3_id = random.Next(123456789, 999999999) + random.Next(0, 333) + 55;
        PaymentType pmt_3 = new PaymentType()
        {
            Id = pmt_3_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = $"CASH"
        };
        paymentTypes.Add(pmt_3);

        // CHECK
        var pmt_4_id = random.Next(123456789, 999999999) + random.Next(0, 333) + 55;
        PaymentType pmt_4 = new PaymentType()
        {
            Id = pmt_4_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = $"CHECK"
        };
        paymentTypes.Add(pmt_4);

        using (var context = _dbContextFactory.CreateDbContext())
        {
            await DatabaseBackupService.SetDbIdentityInsert(context, "PaymentsTypes", true);
            foreach (var item in paymentTypes)
            {
                try
                {
                    await SeedIfNotExists<PaymentType>(context, item);
                }
                catch (Exception ex)
                {
                    // TODO: Log Exception
                    //Console.WriteLine($"Exception On SeedData.CreatePaymentTypes(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
                }
            }
            await DatabaseBackupService.SetDbIdentityInsert(context, "PaymentsTypes", false);
        }
    }

    protected async Task CreateOfferTypes()
    {
        Random random = new Random();

        offerTypes.Clear();

        var offer_type_1_id = random.Next(123456789, 999999999) + random.Next(0, 333) + 10;
        OfferType offer_type_1 = new OfferType()
        {
            Id = offer_type_1_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "PUBLIC"
        };
        offerTypes.Add(offer_type_1);

        var offer_type_2_id = random.Next(123456789, 999999999) + random.Next(0, 333) + 10;
        OfferType offer_type_2 = new OfferType()
        {
            Id = offer_type_2_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "PRIVATE"
        };
        offerTypes.Add(offer_type_2);

        var offer_type_3_id = random.Next(123456789, 999999999) + random.Next(0, 333) + 10;
        OfferType offer_type_3 = new OfferType()
        {
            Id = offer_type_3_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "INTERNATIONAL"
        };
        offerTypes.Add(offer_type_3);

        var offer_type_4_id = random.Next(123456789, 999999999) + random.Next(0, 333) + 10;
        OfferType offer_type_4 = new OfferType()
        {
            Id = offer_type_4_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "HEDNO"
        };
        offerTypes.Add(offer_type_4);

        using (var context = _dbContextFactory.CreateDbContext())
        {
            await DatabaseBackupService.SetDbIdentityInsert(context, "OffersTypes", true);
            foreach (var item in offerTypes)
            {
                try
                {
                    await SeedIfNotExists<OfferType>(context, item);
                }
                catch (Exception ex)
                {
                    // TODO: Log Exception
                    //Console.WriteLine($"Exception On SeedData.CreateOfferTypes(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
                }
            }
            await DatabaseBackupService.SetDbIdentityInsert(context, "OffersTypes", false);
        }
    }

    protected async Task CreateOfferState()
    {
        Random random = new Random();

        offerStates.Clear();

        var offer_state_1_id = random.Next(123456789, 999999999) + random.Next(0, 333) + 10;
        OfferState offer_state_1 = new OfferState()
        {
            Id = offer_state_1_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "SUBMITTED"
        };
        offerStates.Add(offer_state_1);

        var offer_state_2_id = random.Next(123456789, 999999999) + random.Next(0, 333) + 10;
        OfferState offer_state_2 = new OfferState()
        {
            Id = offer_state_2_id,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "PREPARATION"
        };
        offerStates.Add(offer_state_2);

        using (var context = _dbContextFactory.CreateDbContext())
        {
            await DatabaseBackupService.SetDbIdentityInsert(context, "OffesStates", true);
            foreach (var item in offerStates)
            {
                try
                {
                    await SeedIfNotExists<OfferState>(context, item);
                }
                catch (Exception ex)
                {
                    // TODO: Log Exception
                    //Console.WriteLine($"Exception On SeedData.CreateOfferState(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
                }
            }
            await DatabaseBackupService.SetDbIdentityInsert(context, "OffesStates", false);
        }
    }

    protected async Task CreateDisciplineTypes()
    {
        Random random = new Random();

        disciplineTypes.Clear();

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
        disciplineTypes.Add(dt_pm_hours);

        using (var context = _dbContextFactory.CreateDbContext())
        {
            await DatabaseBackupService.SetDbIdentityInsert(context, "DisciplineTypes", true);
            foreach (var item in disciplineTypes)
            {
                try
                {
                    await SeedIfNotExists<DisciplineType>(context, item);
                }
                catch (Exception ex)
                {
                    // TODO: Log Exception
                    //Console.WriteLine($"Exception On SeedData.CreateDisciplineTypes(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
                }
            }
            await DatabaseBackupService.SetDbIdentityInsert(context, "DisciplineTypes", false);
        }
    }

    protected async Task CreateDeliverableTypes()
    {
        Random random = new Random();

        deliverableTypes.Clear();

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
            deliverableTypes.Add(drt);
        }

        using (var context = _dbContextFactory.CreateDbContext())
        {
            await DatabaseBackupService.SetDbIdentityInsert(context, "DeliverableTypes", true);
            foreach (var item in deliverableTypes)
            {
                try
                {
                    await SeedIfNotExists<DeliverableType>(context, item);
                }
                catch (Exception ex)
                {
                    // TODO: Log Exception
                    //Console.WriteLine($"Exception On SeedData.CreateDeliverableTypes(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
                }
            }
            await DatabaseBackupService.SetDbIdentityInsert(context, "DeliverableTypes", false);
        }
    }

    protected async Task CreateSupportiveWorkTypes()
    {
        Random random = new Random();

        otherTypes.Clear();

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
            otherTypes.Add(ort);
        }

        using (var context = _dbContextFactory.CreateDbContext())
        {
            await DatabaseBackupService.SetDbIdentityInsert(context, "SupportiveWorkTypes", true);
            foreach (var item in otherTypes)
            {
                try
                {
                    await SeedIfNotExists<SupportiveWorkType>(context, item);
                }
                catch (Exception ex)
                {
                    // TODO: Log Exception
                    //Console.WriteLine($"Exception On SeedData.CreateSupportiveWorkTypes(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
                }
            }
            await DatabaseBackupService.SetDbIdentityInsert(context, "SupportiveWorkTypes", false);
        }
    }


    protected async Task CreateSecretaries()
    {
        Random random = new Random();

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

        Email email_6 = new Email()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Address = "embiria@embiria.gr",
            UserId = secretarie_1_Id
        };

        Email email_7 = new Email()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Address = "akonstantinidou@embiria.gr",
            UserId = secretarie_1_Id
        };

        UserRole secretarieRole_1_em = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + 11,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = secretarie_1_Id,
            RoleId = GetRecordAtIndex(rolesIds, 9)
        };

        try
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                await DatabaseBackupService.SetDbIdentityInsert(context, "Users", true);
                await SeedIfNotExists<User>(context, secretarie_1);
                await DatabaseBackupService.SetDbIdentityInsert(context, "Users", false);

                await DatabaseBackupService.SetDbIdentityInsert(context, "Emails", true);
                await SeedIfNotExists<Email>(context, email_6);
                await SeedIfNotExists<Email>(context, email_7);
                await DatabaseBackupService.SetDbIdentityInsert(context, "Emails", false);

                await DatabaseBackupService.SetDbIdentityInsert(context, "UsersRoles", true);
                await SeedIfNotExists<UserRole>(context, secretarieRole_1_em);
                await DatabaseBackupService.SetDbIdentityInsert(context, "UsersRoles", false);
            }
        }
        catch (Exception ex)
        {
            // TODO: Log Exception
            //Console.WriteLine($"Exception On SeedData.CreateSecretaries(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    protected async Task CreateDraftmen()
    {
        Random random = new Random();
        draftsmen.Clear();

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
        draftsmen.Add(draftman_1);
        Email email_8 = new Email()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Address = "gdoug@embiria.gr",
            UserId = draftsman_1_Id
        };
        UserRole DraftsmanRole_1_em = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + 11,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = draftsman_1_Id,
            RoleId = GetRecordAtIndex(rolesIds, 0)
        };

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
        draftsmen.Add(draftman_2);
        Email email_9 = new Email()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Address = "dtsa@embiria.gr",
            UserId = draftsman_2_Id
        };
        UserRole DraftsmanRole_2_em = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + 11,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = draftsman_2_Id,
            RoleId = GetRecordAtIndex(rolesIds, 0)
        };


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
        draftsmen.Add(draftman_3);
        Email email_10 = new Email()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Address = "dtsa@embiria.gr",
            UserId = draftsman_3_Id
        };
        UserRole DraftsmanRole_3_em = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + 11,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = draftsman_3_Id,
            RoleId = GetRecordAtIndex(rolesIds, 0)
        };

        try
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                await DatabaseBackupService.SetDbIdentityInsert(context, "Users", true);
                await SeedIfNotExists<User>(context, draftman_1);
                await SeedIfNotExists<User>(context, draftman_2);
                await SeedIfNotExists<User>(context, draftman_3);
                await DatabaseBackupService.SetDbIdentityInsert(context, "Users", false);

                await DatabaseBackupService.SetDbIdentityInsert(context, "Emails", true);
                await SeedIfNotExists<Email>(context, email_8);
                await SeedIfNotExists<Email>(context, email_9);
                await SeedIfNotExists<Email>(context, email_10);
                await DatabaseBackupService.SetDbIdentityInsert(context, "Emails", false);

                await DatabaseBackupService.SetDbIdentityInsert(context, "UsersRoles", true);
                await SeedIfNotExists<UserRole>(context, DraftsmanRole_1_em);
                await SeedIfNotExists<UserRole>(context, DraftsmanRole_2_em);
                await SeedIfNotExists<UserRole>(context, DraftsmanRole_3_em);
                await DatabaseBackupService.SetDbIdentityInsert(context, "UsersRoles", false);
            }
        }
        catch (Exception ex)
        {
            // TODO: Log Exception
            //Console.WriteLine($"Exception On SeedData.CreateDraftmen(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    protected async Task CreateEngineers()
    {
        Random random = new Random();
        engineers.Clear();

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
        engineers.Add(engineer_1);
        Email email_11 = new Email()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Address = "vpax@embiria.gr",
            UserId = engineer_1_Id
        };
        // Engineer
        UserRole engineerRole_1_em = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + 12,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = engineer_1_Id,
            RoleId = GetRecordAtIndex(rolesIds, 1)
        };

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
        engineers.Add(engineer_2);
        Email email_12 = new Email()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Address = "xmanarolis@embiria.gr",
            UserId = engineer_2_Id
        };
        // Engineer
        UserRole engineerRole_2_em = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + 12,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = engineer_2_Id,
            RoleId = GetRecordAtIndex(rolesIds, 1)
        };

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
        engineers.Add(engineer_3);
        Email email_13 = new Email()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Address = "sparisis@embiria.gr",
            UserId = engineer_3_Id
        };
        // Engineer
        UserRole engineerRole_3_em = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + 12,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = engineer_3_Id,
            RoleId = GetRecordAtIndex(rolesIds, 1)
        };

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
        engineers.Add(engineer_4);
        Email email_14 = new Email()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Address = "chkovras@embiria.gr",
            UserId = engineer_4_Id
        };
        // Engineer
        UserRole engineerRole_4_em = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + 12,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = engineer_4_Id,
            RoleId = GetRecordAtIndex(rolesIds, 1)
        };

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
        engineers.Add(engineer_5);
        Email email_15 = new Email()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Address = "ngal@embiria.gr",
            UserId = engineer_5_Id
        };
        // Engineer
        UserRole engineerRole_5_em = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + 12,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = engineer_5_Id,
            RoleId = GetRecordAtIndex(rolesIds, 1)
        };
        // CEO
        UserRole engineerRole_5_em_3 = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + 12,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = engineer_5_Id,
            RoleId = GetRecordAtIndex(rolesIds, 5)
        };

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
        engineers.Add(engineer_6);
        Email email_16 = new Email()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Address = "kkotsoni@embiria.gr",
            UserId = engineer_6_Id
        };
        // Engineer
        UserRole engineerRole_6_em = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + 12,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = engineer_6_Id,
            RoleId = GetRecordAtIndex(rolesIds, 1)
        };
        // COO
        UserRole engineerRole_6_em_coo = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + 12,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = engineer_6_Id,
            RoleId = GetRecordAtIndex(rolesIds, 3)
        };
        // CTO
        UserRole engineerRole_17_em_coo = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + 12,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = engineer_6_Id,
            RoleId = GetRecordAtIndex(rolesIds, 4)
        };
        // Admin
        UserRole admin_2 = new UserRole()
        {
            Id = random.Next(123456789, 999999999) / 3,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = engineer_6_Id,
            RoleId = GetRecordAtIndex(rolesIds, 8)
        };

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
        engineers.Add(engineer_7);
        Email email_17 = new Email()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Address = "vtza@embiria.gr",
            UserId = engineer_7_Id
        };
        // Engineer
        UserRole engineerRole_7_em = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + 12,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = engineer_7_Id,
            RoleId = GetRecordAtIndex(rolesIds, 1)
        };

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
        engineers.Add(engineer_8);
        Email email_18 = new Email()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Address = "agretos@embiria.gr",
            UserId = engineer_8_Id
        };
        // Engineer
        UserRole engineerRole_8_em = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + 12,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = engineer_8_Id,
            RoleId = GetRecordAtIndex(rolesIds, 1)
        };

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
        engineers.Add(engineer_9);
        Email email_19 = new Email()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Address = "kmargeti@embiria.gr",
            UserId = engineer_9_Id
        };
        // Engineer
        UserRole engineerRole_9_em = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + 12,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = engineer_9_Id,
            RoleId = GetRecordAtIndex(rolesIds, 1)
        };

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
        engineers.Add(engineer_10);
        Email email_20 = new Email()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Address = "haris@embiria.gr",
            UserId = engineer_10_Id
        };
        // Engineer
        UserRole engineerRole_10_em = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + 12,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = engineer_10_Id,
            RoleId = GetRecordAtIndex(rolesIds, 1)
        };

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
        engineers.Add(engineer_11);
        Email email_21 = new Email()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Address = "pfokianou@embiria.gr",
            UserId = engineer_11_Id
        };
        // Engineer
        UserRole engineerRole_11_em = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + 12,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = engineer_11_Id,
            RoleId = GetRecordAtIndex(rolesIds, 1)
        };

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
        engineers.Add(engineer_12);
        Email email_22 = new Email()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Address = "ogiannoglou@embiria.gr",
            UserId = engineer_12_Id
        };
        // Engineer
        UserRole engineerRole_12_em = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + 12,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = engineer_12_Id,
            RoleId = GetRecordAtIndex(rolesIds, 1)
        };

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
        engineers.Add(engineer_13);
        Email email_23 = new Email()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Address = "blekou@embiria.gr",
            UserId = engineer_13_Id
        };
        // Engineer
        UserRole engineerRole_13_em = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + 12,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = engineer_13_Id,
            RoleId = GetRecordAtIndex(rolesIds, 1)
        };

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
        engineers.Add(engineer_14);
        Email email_24 = new Email()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Address = "vchontos@embiria.gr",
            UserId = engineer_14_Id
        };
        // Engineer
        UserRole engineerRole_14_em = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + 12,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = engineer_14_Id,
            RoleId = GetRecordAtIndex(rolesIds, 1)
        };

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
        engineers.Add(engineer_15);
        Email email_25 = new Email()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Address = "panperivollari@embiria.gr",
            UserId = engineer_15_Id
        };
        // Engineer
        UserRole engineerRole_15_em = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + 12,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = engineer_15_Id,
            RoleId = GetRecordAtIndex(rolesIds, 1)
        };

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
        engineers.Add(engineer_16);
        Email email_26 = new Email()
        {
            Id = random.Next(123456789, 999999999) + random.Next(0, 33),
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Address = "ntriantafyllou@embiria.gr",
            UserId = engineer_16_Id
        };
        // Engineer
        UserRole engineerRole_16_em = new UserRole()
        {
            Id = random.Next(123456789, 999999999) + 12,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = engineer_16_Id,
            RoleId = GetRecordAtIndex(rolesIds, 1)
        };

        try
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                await DatabaseBackupService.SetDbIdentityInsert(context, "Users", true);
                await SeedIfNotExists<User>(context, engineer_1);
                await SeedIfNotExists<User>(context, engineer_2);
                await SeedIfNotExists<User>(context, engineer_3);
                await SeedIfNotExists<User>(context, engineer_4);
                await SeedIfNotExists<User>(context, engineer_5);
                await SeedIfNotExists<User>(context, engineer_6);
                await SeedIfNotExists<User>(context, engineer_7);
                await SeedIfNotExists<User>(context, engineer_8);
                await SeedIfNotExists<User>(context, engineer_9);
                await SeedIfNotExists<User>(context, engineer_10);
                await SeedIfNotExists<User>(context, engineer_11);
                await SeedIfNotExists<User>(context, engineer_12);
                await SeedIfNotExists<User>(context, engineer_13);
                await SeedIfNotExists<User>(context, engineer_14);
                await SeedIfNotExists<User>(context, engineer_15);
                await SeedIfNotExists<User>(context, engineer_16);
                await DatabaseBackupService.SetDbIdentityInsert(context, "Users", false);

                await DatabaseBackupService.SetDbIdentityInsert(context, "Emails", true);
                await SeedIfNotExists<Email>(context, email_11);
                await SeedIfNotExists<Email>(context, email_12);
                await SeedIfNotExists<Email>(context, email_13);
                await SeedIfNotExists<Email>(context, email_14);
                await SeedIfNotExists<Email>(context, email_15);
                await SeedIfNotExists<Email>(context, email_16);
                await SeedIfNotExists<Email>(context, email_17);
                await SeedIfNotExists<Email>(context, email_18);
                await SeedIfNotExists<Email>(context, email_19);
                await SeedIfNotExists<Email>(context, email_20);
                await SeedIfNotExists<Email>(context, email_21);
                await SeedIfNotExists<Email>(context, email_22);
                await SeedIfNotExists<Email>(context, email_23);
                await SeedIfNotExists<Email>(context, email_24);
                await SeedIfNotExists<Email>(context, email_25);
                await SeedIfNotExists<Email>(context, email_26);
                await DatabaseBackupService.SetDbIdentityInsert(context, "Emails", false);

                await DatabaseBackupService.SetDbIdentityInsert(context, "UsersRoles", true);
                await SeedIfNotExists<UserRole>(context, engineerRole_1_em);
                await SeedIfNotExists<UserRole>(context, engineerRole_2_em);
                await SeedIfNotExists<UserRole>(context, engineerRole_3_em);
                await SeedIfNotExists<UserRole>(context, engineerRole_4_em);
                await SeedIfNotExists<UserRole>(context, engineerRole_5_em);
                await SeedIfNotExists<UserRole>(context, engineerRole_5_em_3);
                await SeedIfNotExists<UserRole>(context, engineerRole_6_em);
                await SeedIfNotExists<UserRole>(context, engineerRole_6_em_coo);
                await SeedIfNotExists<UserRole>(context, engineerRole_17_em_coo);
                await SeedIfNotExists<UserRole>(context, admin_2);
                await SeedIfNotExists<UserRole>(context, engineerRole_7_em);
                await SeedIfNotExists<UserRole>(context, engineerRole_8_em);
                await SeedIfNotExists<UserRole>(context, engineerRole_9_em);
                await SeedIfNotExists<UserRole>(context, engineerRole_10_em);
                await SeedIfNotExists<UserRole>(context, engineerRole_11_em);
                await SeedIfNotExists<UserRole>(context, engineerRole_12_em);
                await SeedIfNotExists<UserRole>(context, engineerRole_13_em);
                await SeedIfNotExists<UserRole>(context, engineerRole_14_em);
                await SeedIfNotExists<UserRole>(context, engineerRole_15_em);
                await SeedIfNotExists<UserRole>(context, engineerRole_16_em);
                await DatabaseBackupService.SetDbIdentityInsert(context, "UsersRoles", false);
            }
        }
        catch (Exception ex)
        {
            // TODO: Log Exception
            //Console.WriteLine($"Exception On SeedData.CreateEngineers(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    protected async Task CreateProjectManagers()
    {
        Random random = new Random();

        // ΠΑΞΙΝΟΣ ΕΥΑΓΓΕΛΟΣ
        var eng_1 = GetRecordAtIndex(engineers, 0);
        UserRole pmRole_1 = new UserRole()
        {
            Id = random.Next(123456789, 999999999) / 3,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = eng_1.Id,
            RoleId = GetRecordAtIndex(rolesIds, 2)
        };
        projectManagers.Add(eng_1);

        // ΚΟΤΣΩΝΗ ΚΑΤΕΡΙΝΑ
        var eng_5 = GetRecordAtIndex(engineers, 5);
        UserRole pmRole_2 = new UserRole()
        {
            Id = random.Next(123456789, 999999999) / 3,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = eng_5.Id,
            RoleId = GetRecordAtIndex(rolesIds, 2)
        };
        projectManagers.Add(eng_5);

        // ΠΛΑΤΑΝΙΟΣ ΧΑΡΗΣ
        var eng_10 = GetRecordAtIndex(engineers, 9);
        UserRole pmRole_3 = new UserRole()
        {
            Id = random.Next(123456789, 999999999) / 3,
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            UserId = eng_10.Id,
            RoleId = GetRecordAtIndex(rolesIds, 2)
        };
        projectManagers.Add(eng_10);

        try
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                await DatabaseBackupService.SetDbIdentityInsert(context, "UsersRoles", true);
                await SeedIfNotExists<UserRole>(context, pmRole_1);
                await SeedIfNotExists<UserRole>(context, pmRole_2);
                await SeedIfNotExists<UserRole>(context, pmRole_3);
                await DatabaseBackupService.SetDbIdentityInsert(context, "UsersRoles", false);
            }
        }
        catch (Exception ex)
        {
            // TODO: Log Exception
            //Console.WriteLine($"Exception On SeedData.CreateProjectManagers(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    protected async Task CreateProjects()
    {
        Random random = new Random();

        projects.Clear();

        List<Client> clients = new List<Client>();
        List<Led> leds = new List<Led>();
        List<Offer> offers = new List<Offer>();
        List<Invoice> invoices = new List<Invoice>();

        var categoriesLength = projectCategories.Count();
        var stagesLength = projectStages.Count();
        var projectManagersLength = projectManagers.Count();

        var categoriesIndex = 0;
        var stagesIndex = 0;
        var projectManagersIndex = 0;

        for (var i = 1; i <= projectSubCategories.Count(); i++)
        {
            // Led
            var clientId = random.Next(123456789, 999999999) + i * 3;
            Client client = new Client()
            {
                Id = clientId,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                FirstName = $"Client-Led-{i}",
                LastName = "LastName",
                ProxyAddress = "alexandrosplatanios15@gmail.com",
                Phone1 = "6949277783"
            };
            clients.Add(client);

            // Led
            var ledId = random.Next(123456789, 999999999) + i * 3;
            Led led = new Led()
            {
                Id = ledId,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = $"Led-{i}",
                ClientId = clientId,
                PotencialFee = random.Next(i, i * 3),
                Result = LedResult.SUCCESSFUL
            };
            leds.Add(led);

            // Offers
            var offerId = random.Next(123456789, 999999999) + i * 3;
            Offer offer = new Offer()
            {
                Id = offerId,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Date = DateTime.Now,
                Code = $"Code CO-{i}",
                TypeId = offerTypes[random.Next(0, 2)].Id,
                StateId = offerStates[random.Next(0, 1)].Id,
                Result = OfferResult.SUCCESSFUL,
                PudgetPrice = 1000 * i * 3,
                OfferPrice = 1000 * i * 2,
                CategoryId = projectCategories[categoriesIndex].Id,
                SubCategoryId = projectSubCategories[i - 1].Id,
                LedId = ledId,
            };
            offers.Add(offer);

            // Projects 
            var projectId = random.Next(123456789, 999999999) + i * 2;
            Project project = new Project()
            {
                Id = projectId,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Code = "D-22-16" + Convert.ToString(i),
                Name = "Project_" + Convert.ToString(i),
                Description = "Test Description Project_" + Convert.ToString(i * random.Next(1, 7)),
                StartDate = DateTime.Now,
                DeadLine = DateTime.Now.AddMonths(Convert.ToInt32(Math.Pow(i, 2))),
                EstimatedMandays = 100 / 8,
                EstimatedHours = 1500,
                DeclaredCompleted = 0,
                EstimatedCompleted = 0,
                StageId = projectStages[stagesIndex].Id,
                Active = i % 2 == 0 ? true : false,
                ProjectManagerId = projectManagers[projectManagersIndex].Id,
                OfferId = offerId
            };
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
                Date = DateTime.Now,
                Total = i * Math.Pow(1, 3),
                Vat = i % 2 == 0 ? Vat.TwentyFour : Vat.Seventeen,
                Fee = 1000 * i,
                Number = random.Next(10000, 90000),
                Mark = "Signature 14234" + Convert.ToString(i * random.Next(1, 7)),
                ProjectId = projectId,
                TypeId = invoiceTypes[0].Id
            };
            invoices.Add(invoice);
        }

        using (var context = _dbContextFactory.CreateDbContext())
        {
            // Clients
            await DatabaseBackupService.SetDbIdentityInsert(context, "Users", true);
            foreach (var item in clients)
            {
                try
                {
                    await SeedIfNotExists<Client>(context, item);
                }
                catch (Exception ex)
                {
                    // TODO: Log Exception
                    //Console.WriteLine($"Exception On SeedData.CreateProjects() Clients: {ex.Message}, \nInner: {ex.InnerException?.Message}");
                }
            }
            await DatabaseBackupService.SetDbIdentityInsert(context, "Users", false);

            // Leds
            await DatabaseBackupService.SetDbIdentityInsert(context, "Leds", true);
            foreach (var item in leds)
            {
                try
                {
                    await SeedIfNotExists<Led>(context, item);
                }
                catch (Exception ex)
                {
                    // TODO: Log Exception
                    //Console.WriteLine($"Exception On SeedData.CreateProjects() Leds: {ex.Message}, \nInner: {ex.InnerException?.Message}");
                }
            }
            await DatabaseBackupService.SetDbIdentityInsert(context, "Leds", false);

            // Offers
            await DatabaseBackupService.SetDbIdentityInsert(context, "Offers", true);
            foreach (var item in offers)
            {
                try
                {
                    await SeedIfNotExists<Offer>(context, item);
                }
                catch (Exception ex)
                {
                    // TODO: Log Exception
                    //Console.WriteLine($"Exception On SeedData.CreateProjects() Offers: {ex.Message}, \nInner: {ex.InnerException?.Message}");
                }
            }
            await DatabaseBackupService.SetDbIdentityInsert(context, "Offers", false);

            // Projects
            await DatabaseBackupService.SetDbIdentityInsert(context, "Projects", true);
            foreach (var item in projects)
            {
                try
                {
                    await SeedIfNotExists<Project>(context, item);
                }
                catch (Exception ex)
                {
                    // TODO: Log Exception
                    //Console.WriteLine($"Exception On SeedData.CreateProjects() Projects: {ex.Message}, \nInner: {ex.InnerException?.Message}");
                }
            }
            await DatabaseBackupService.SetDbIdentityInsert(context, "Projects", false);

            // Invoices
            await DatabaseBackupService.SetDbIdentityInsert(context, "Invoices", true);
            foreach (var item in invoices)
            {
                try
                {
                    await SeedIfNotExists<Invoice>(context, item);
                }
                catch (Exception ex)
                {
                    // TODO: Log Exception
                    //Console.WriteLine($"Exception On SeedData.CreateProjects() Invoices: {ex.Message}, \nInner: {ex.InnerException?.Message}");
                }
            }
            await DatabaseBackupService.SetDbIdentityInsert(context, "Invoices", false);
        }
    }

    protected async Task CreateMissedDeadLineProjects()
    {
        Random random = new Random();

        msprojects.Clear();

        List<Client> clients = new List<Client>();
        List<Led> leds = new List<Led>();
        List<Offer> offers = new List<Offer>();
        List<Invoice> invoices = new List<Invoice>();

        var categoriesLength = projectCategories.Count();
        var stagesLength = projectStages.Count();
        var projectManagersLength = projectManagers.Count();

        var categoriesIndex = 0;
        var stagesIndex = 0;
        var projectManagersIndex = 0;

        for (var i = 1; i <= projectSubCategories.Count(); i++)
        {
            // Led
            var clientId = random.Next(123456789, 999999999) + i * 3 + 2345;
            Client client = new Client()
            {
                Id = clientId,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                FirstName = $"Client-Led-M-{i}",
                LastName = "LastName",
                ProxyAddress = "alexandrosplatanios15@gmail.com",
                Phone1 = "6949277783"
            };
            clients.Add(client);

            // Led
            var ledId = random.Next(123456789, 999999999) + i * 3 + 13245;
            Led led = new Led()
            {
                Id = ledId,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Name = $"Led-M-{i}",
                ClientId = clientId,
                PotencialFee = random.Next(i, i * 3),
                Result = LedResult.SUCCESSFUL
            };
            leds.Add(led);

            // Offers
            var offerId = random.Next(123456789, 999999999) + i * 3 + 3246;
            Offer offer = new Offer()
            {
                Id = offerId,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Date = DateTime.Now,
                Code = $"Code M CO-{i}",
                TypeId = offerTypes[random.Next(0, 2)].Id,
                StateId = offerStates[random.Next(0, 1)].Id,
                Result = OfferResult.SUCCESSFUL,
                PudgetPrice = 1000 * i * 3,
                OfferPrice = 1000 * i * 2,
                CategoryId = projectCategories[categoriesIndex].Id,
                SubCategoryId = projectSubCategories[i - 1].Id,
                LedId = ledId,
            };
            offers.Add(offer);

            // Projects 
            var projectId = random.Next(123456789, 999999999) + i * 3 + 3466;
            Project project = new Project()
            {
                Id = projectId,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Code = "D-M-22-16" + Convert.ToString(i),
                Name = "Project_Missed_DeadLine_" + Convert.ToString(i),
                Description = "Test Description Project_" + Convert.ToString(i * random.Next(1, 7)),
                StartDate = DateTime.Now,
                DeadLine = DateTime.Now.AddMonths(-i),
                EstimatedMandays = 100 / 8,
                EstimatedHours = 1500,
                DeclaredCompleted = 0,
                EstimatedCompleted = 0,
                StageId = projectStages[stagesIndex].Id,
                Active = i % 2 == 0 ? true : false,
                ProjectManagerId = projectManagers[projectManagersIndex].Id,
                OfferId = offerId
            };
            msprojects.Add(project);

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
                Date = DateTime.Now,
                Total = i * Math.Pow(1, 3),
                Vat = i % 2 == 0 ? Vat.TwentyFour : Vat.Seventeen,
                Fee = 1000 * i,
                Number = random.Next(10000, 90000),
                Mark = "Signature M 14234" + Convert.ToString(i * random.Next(1, 7)),
                ProjectId = projectId,
                TypeId = invoiceTypes[0].Id
            };
            invoices.Add(invoice);
        }

        using (var context = _dbContextFactory.CreateDbContext())
        {
            // Clients
            await DatabaseBackupService.SetDbIdentityInsert(context, "Users", true);
            foreach (var item in clients)
            {
                try
                {
                    await SeedIfNotExists<Client>(context, item);
                }
                catch (Exception ex)
                {
                    // TODO: Log Exception
                    //Console.WriteLine($"Exception On SeedData.CreateMissedDeadLineProjects() Clients: {ex.Message}, \nInner: {ex.InnerException?.Message}");
                }
            }
            await DatabaseBackupService.SetDbIdentityInsert(context, "Users", false);

            // Leds
            await DatabaseBackupService.SetDbIdentityInsert(context, "Leds", true);
            foreach (var item in leds)
            {
                try
                {
                    await SeedIfNotExists<Led>(context, item);
                }
                catch (Exception ex)
                {
                    // TODO: Log Exception
                    //Console.WriteLine($"Exception On SeedData.CreateMissedDeadLineProjects() Leds: {ex.Message}, \nInner: {ex.InnerException?.Message}");
                }
            }
            await DatabaseBackupService.SetDbIdentityInsert(context, "Leds", false);

            // Offers
            await DatabaseBackupService.SetDbIdentityInsert(context, "Offers", true);
            foreach (var item in offers)
            {
                try
                {
                    await SeedIfNotExists<Offer>(context, item);
                }
                catch (Exception ex)
                {
                    // TODO: Log Exception
                    //Console.WriteLine($"Exception On SeedData.CreateMissedDeadLineProjects() Offers: {ex.Message}, \nInner: {ex.InnerException?.Message}");
                }
            }
            await DatabaseBackupService.SetDbIdentityInsert(context, "Offers", false);

            // Projects
            await DatabaseBackupService.SetDbIdentityInsert(context, "Projects", true);
            foreach (var item in msprojects)
            {
                try
                {
                    await SeedIfNotExists<Project>(context, item);
                }
                catch (Exception ex)
                {
                    // TODO: Log Exception
                    //Console.WriteLine($"Exception On SeedData.CreateMissedDeadLineProjects() Projects: {ex.Message}, \nInner: {ex.InnerException?.Message}");
                }
            }
            await DatabaseBackupService.SetDbIdentityInsert(context, "Projects", false);

            // Invoices
            await DatabaseBackupService.SetDbIdentityInsert(context, "Invoices", true);
            foreach (var item in invoices)
            {
                try
                {
                    await SeedIfNotExists<Invoice>(context, item);
                }
                catch (Exception ex)
                {
                    // TODO: Log Exception
                    //Console.WriteLine($"Exception On SeedData.CreateMissedDeadLineProjects() Invoices: {ex.Message}, \nInner: {ex.InnerException?.Message}");
                }
            }
            await DatabaseBackupService.SetDbIdentityInsert(context, "Invoices", false);
        }
    }

    protected async Task CreateDisciplines()
    {
        Random random = new Random();

        disciplines.Clear();

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
                disciplines.Add(discipline);
            }
        }

        using (var context = _dbContextFactory.CreateDbContext())
        {
            await DatabaseBackupService.SetDbIdentityInsert(context, "Disciplines", true);
            foreach (var item in disciplines)
            {
                try
                {
                    await SeedIfNotExists<Discipline>(context, item);
                }
                catch (Exception ex)
                {
                    // TODO: Log Exception
                    //Console.WriteLine($"Exception On SeedData.CreateDisciplines(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
                }
            }
            await DatabaseBackupService.SetDbIdentityInsert(context, "Disciplines", false);
        }
    }

    protected async Task CreateDeliverables()
    {
        Random random = new Random();

        deliverables.Clear();

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
                deliverables.Add(drawing);
            }
        }

        using (var context = _dbContextFactory.CreateDbContext())
        {
            await DatabaseBackupService.SetDbIdentityInsert(context, "Deliverables", true);
            foreach (var item in deliverables)
            {
                try
                {
                    await SeedIfNotExists<Deliverable>(context, item);
                }
                catch (Exception ex)
                {
                    // TODO: Log Exception
                    //Console.WriteLine($"Exception On SeedData.CreateDeliverables(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
                }
            }
            await DatabaseBackupService.SetDbIdentityInsert(context, "Deliverables", false);
        }
    }

    protected async Task CreateSupportiveWorks()
    {
        Random random = new Random();

        supportiveWorks.Clear();

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
                supportiveWorks.Add(other);
            }
        }

        using (var context = _dbContextFactory.CreateDbContext())
        {
            await DatabaseBackupService.SetDbIdentityInsert(context, "SupportiveWorks", true);
            foreach (var item in supportiveWorks)
            {
                try
                {
                    await SeedIfNotExists<SupportiveWork>(context, item);
                }
                catch (Exception ex)
                {
                    // TODO: Log Exception
                    //Console.WriteLine($"Exception On SeedData.CreateSupportiveWorks(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
                }
            }
            await DatabaseBackupService.SetDbIdentityInsert(context, "SupportiveWorks", false);
        }
    }

    protected async Task ConnectAllEngineersWithEveryDisclipline()
    {
        Random random = new Random();

        List<DisciplineEngineer> data = new List<DisciplineEngineer>();

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
                data.Add(de);
            }
        }

        using (var context = _dbContextFactory.CreateDbContext())
        {
            await DatabaseBackupService.SetDbIdentityInsert(context, "DisciplinesEngineers", true);
            foreach (var item in data)
            {
                try
                {
                    await SeedIfNotExists<DisciplineEngineer>(context, item);
                }
                catch (Exception ex)
                {
                    // TODO: Log Exception
                    //Console.WriteLine($"Exception On SeedData.ConnectAllEngineersWithEveryDisclipline(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
                }
            }
            await DatabaseBackupService.SetDbIdentityInsert(context, "DisciplinesEngineers", false);
        }
    }

    protected async Task ConnectEveryDraftmanWithEverySupportiveWork()
    {
        Random random = new Random();

        List<SupportiveWorkEmployee> data = new List<SupportiveWorkEmployee>();

        for (var o = 0; o < supportiveWorks.Count; o++)
        {
            for (var d = 0; d < draftsmen.Count; d++)
            {
                SupportiveWorkEmployee de_1 = new SupportiveWorkEmployee()
                {
                    Id = random.Next(123456789, 999999999) * 9,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    EmployeeId = draftsmen[d].Id,
                    SupportiveWorkId = supportiveWorks[o].Id
                };
                data.Add(de_1);
            }
        }

        using (var context = _dbContextFactory.CreateDbContext())
        {
            await DatabaseBackupService.SetDbIdentityInsert(context, "SupportiveWorkEmployees", true);
            foreach (var item in data)
            {
                try
                {
                    await SeedIfNotExists<SupportiveWorkEmployee>(context, item);
                }
                catch (Exception ex)
                {
                    // TODO: Log Exception
                    //Console.WriteLine($"Exception On SeedData.ConnectAllEngineersWithEveryDisclipline(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
                }
            }
            await DatabaseBackupService.SetDbIdentityInsert(context, "SupportiveWorkEmployees", false);
        }
    }

    #region Private Helper Methods
    private static async Task SeedIfNotExists<T>(DbContext context, T entity)
    where T : class, IEntity
    {
        var id = entity.Id;
        var data = await context.Set<T>().ToListAsync();
        bool exists = data.Any(e => e.AreEqualExcludeId(entity));
        if (!exists)
        {
            var result = await context.Set<T>().AddAsync(entity);
            context.SaveChanges();
        }
        else
        {
            //Console.WriteLine($"\n\nEntity of type: {entity.GetType().Name} with Id: {id} Exists\n\n");
        }
        data.Clear();
    }

    private static T GetRecordAtIndex<T>(List<T> list, int index)
    {
        if (index < 0 || index >= list.Count)
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");

        return list[index];
    }

    private static int GetUniqueRandomNumber(Random random, List<int> selectedNumbers, int min, int max)
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

    private void UpdateProgress(int completed, int total)
    {
        int percentage = (completed * 100) / total;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Progress: {percentage}%");
    }
    #endregion
}
