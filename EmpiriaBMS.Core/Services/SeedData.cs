using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpiriaBMS.Core.Services;

public class SeedData
{
    protected readonly IDbContextFactory<AppDbContext> _dbContextFactory;

    public SeedData(IDbContextFactory<AppDbContext> dbFactory) =>
        _dbContextFactory = dbFactory;

    public void CreateData()
    {
        CeatePermissions();
        CeateRoles();
    }

    protected void CeatePermissions()
    {
        try
        {
            Random random = new Random();

            using (var context = _dbContextFactory.CreateDbContext())
            {
                var per_1_id = random.Next(123456789, 999999999);
                Permission per_1 = new Permission()
                {
                    Id = per_1_id,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    Name = "See Dashboard Layout",
                    Ord = 1
                };
                SeedIfNotExists<Permission>(context, per_1);

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
                SeedIfNotExists<Permission>(context, per_2);

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
                SeedIfNotExists<Permission>(context, per_3);

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
                SeedIfNotExists<Permission>(context, per_4);

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
                SeedIfNotExists<Permission>(context, per_5);

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
                SeedIfNotExists<Permission>(context, per_6);

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
                SeedIfNotExists<Permission>(context, per_7);

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
                SeedIfNotExists<Permission>(context, per_8);

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
                SeedIfNotExists<Permission>(context, per_9);

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
                SeedIfNotExists<Permission>(context, per_10);

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
                SeedIfNotExists<Permission>(context, per_11);

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
                SeedIfNotExists<Permission>(context, per_12);

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
                SeedIfNotExists<Permission>(context, per_13);

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
                SeedIfNotExists<Permission>(context, per_14);

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
                SeedIfNotExists<Permission>(context, per_15);

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
                SeedIfNotExists<Permission>(context, per_16);

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
                SeedIfNotExists<Permission>(context, per_17);

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
                SeedIfNotExists<Permission>(context, per_18);

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
                SeedIfNotExists<Permission>(context, per_19);

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
                SeedIfNotExists<Permission>(context, per_20);

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
                SeedIfNotExists<Permission>(context, per_21);

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
                SeedIfNotExists<Permission>(context, per_22);

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
                SeedIfNotExists<Permission>(context, per_23);

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
                SeedIfNotExists<Permission>(context, per_24);

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
                SeedIfNotExists<Permission>(context, per_25);

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
                SeedIfNotExists<Permission>(context, per_26);

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
                SeedIfNotExists<Permission>(context, per_27);

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
                SeedIfNotExists<Permission>(context, per_28);

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
                SeedIfNotExists<Permission>(context, per_29);

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
                SeedIfNotExists<Permission>(context, per_30);

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
                SeedIfNotExists<Permission>(context, per_31);

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
                SeedIfNotExists<Permission>(context, per_32);

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
                SeedIfNotExists<Permission>(context, per_33);

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
                SeedIfNotExists<Permission>(context, per_34);
            }
        }
        catch (Exception ex)
        {
            // TODO: Log Exception
            Console.WriteLine($"Exception On SeedData.CeatePermissions(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    protected void CeateRoles()
    {
        try
        {
            Random random = new Random();

            using (var context = _dbContextFactory.CreateDbContext())
            {
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
                SeedIfNotExists<Role>(context, role_6);

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
                SeedIfNotExists<Role>(context, role_4);

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
                SeedIfNotExists<Role>(context, role_5);

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
                SeedIfNotExists<Role>(context, role_10);

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
                SeedIfNotExists<Role>(context, role_3);

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
                SeedIfNotExists<Role>(context, role_2);

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
                SeedIfNotExists<Role>(context, role_1);

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
                SeedIfNotExists<Role>(context, role_7);

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
                SeedIfNotExists<Role>(context, role_8);

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
                SeedIfNotExists<Role>(context, role_9);

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
                SeedIfNotExists<Role>(context, role_11);
            }
        }
        catch (Exception ex)
        {
            // TODO: Log Exception
            Console.WriteLine($"Exception On SeedData.CeateRoles(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    protected void CeateRolesPermissions()
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
            Console.WriteLine($"Exception On SeedData.CeateRolesPermissions(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    protected void CeateProjectCategories()
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

    protected void CreateProjectSubCategories()
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

    protected void CreateProjectStages()
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

    protected void CreateInvoiceTypes()
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

    protected void CreatePaymentTypes()
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

    protected void CreateOfferTypes()
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

    protected void CreateOfferState()
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

    protected void CreateSecretaries()
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

    protected void CreateDraftmen()
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

    protected void CreateEngineers()
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

    protected void CreateProjectManagers()
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

    private static void SeedIfNotExists<T>(DbContext context, T entity) where T : class
    {
        var primaryKey = context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.First().Name;
        var primaryKeyValue = entity.GetType().GetProperty(primaryKey).GetValue(entity);
        bool exists = context.Set<T>().Any(e => EF.Property<object>(e, primaryKey).Equals(primaryKeyValue));
        if (!exists)
        {
            var result = context.Set<T>().Add(entity);
            context.SaveChanges();
        }
    }
}
