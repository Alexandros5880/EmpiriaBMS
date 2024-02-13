using EmpiriaMS.Models.Enums;
using EmpiriaMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpiriaMS.Models;
public class AppDbContext : DbContext
{
    const string SmarterASPNetDB = "Data Source=SQL5110.site4now.net;Initial Catalog=db_a8c181_empiriamteemsapp;User Id=db_a8c181_empiriamteemsapp_admin;Password=admin1234567";

    public DbSet<Role>? Roles { get; set; }
    public DbSet<Project>? Projects { get; set; }
    public DbSet<Invoice>? Invoices { get; set; }
    public DbSet<Employee>? Employees { get; set; }
    public DbSet<Customer>? Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer(SmarterASPNetDB);

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        Random random = new Random();

        // Roles
        Role role_1 = new()
        {
            Id = "1",
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Draftsmen",
            Employees = new List<Employee>() { }
        };

        Role role_2 = new()
        {
            Id = "2",
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Engineers",
            Employees = new List<Employee>() { }
        };

        Role role_3 = new()
        {
            Id = "3",
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "Project Managers",
            Employees = new List<Employee>() { }
        };

        Role role_4 = new()
        {
            Id = "4",
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "COO",
            Employees = new List<Employee>() { }
        };

        Role role_5 = new()
        {
            Id = "5",
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "CTO",
            Employees = new List<Employee>() { }
        };

        Role role_6 = new()
        {
            Id = "6",
            CreatedDate = DateTime.Now,
            LastUpdatedDate = DateTime.Now,
            Name = "CEO",
            Employees = new List<Employee>() { }
        };

        builder.Entity<Role>().HasData(role_1);
        builder.Entity<Role>().HasData(role_2);
        builder.Entity<Role>().HasData(role_3);
        builder.Entity<Role>().HasData(role_4);
        builder.Entity<Role>().HasData(role_5);
        builder.Entity<Role>().HasData(role_6);

        List<Customer> customers = new List<Customer>();
        List<Employee> employees = new List<Employee>();
        List<Invoice> invoices = new List<Invoice>();
        for (var i = 0; i < 9; i++)
        {
            Customer customer = new Customer()
            {
                Id = "14234" + Convert.ToString(i),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Email = $"alexpl_{i}@gmail.com",
                LastName = "Alexandros_" + Convert.ToString(i),
                FirstName = "Platanios_Customer_" + Convert.ToString(i),
                Phone1 = "694927778" + Convert.ToString(i),
                Description = "Test Description Client " + Convert.ToString(i),
            };
            builder.Entity<Customer>().HasData(customer);
            customers.Add(customer);

            Employee employee = new Employee()
            {
                Id = "14234" + Convert.ToString(i + 2),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Email = $"alexpl_{i + 2}@gmail.com",
                LastName = "Alexandros_" + Convert.ToString(i + 2),
                FirstName = "Platanios_Employee_" + Convert.ToString(i + 2),
                Phone1 = "694927778" + Convert.ToString(i + 2),
                Description = "Test Description Employee " + Convert.ToString(i + 2),
                Hours = i * (Math.Pow(10, i) + 1)
            };
            builder.Entity<Employee>().HasData(employee);
            employees.Add(employee);

            Invoice invoice = new Invoice()
            {
                Id = "14234" + Convert.ToString(i + 2),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                Total = i * Math.Pow(1, 3),
                Vat = i % 2 == 0 ? 24 : 17,
                Fee = 3000 + Math.Pow(10, i),
                Number = random.Next(10000, 90000),
                Mark = "Signature 14234" + Convert.ToString(i + 2),
                ProjectId = "2546" + Convert.ToString(random.Next(1, 10))
            };
            builder.Entity<Invoice>().HasData(invoice);
            invoices.Add(invoice);
        }

        // Projects
        for (var i = 0; i < 10; i++)
        {
            var f1 = i + 50 - (i * 3) + (i * 5);
            var f2 = i + 50 - (i * 3) + (i * 4);
            var f3 = i + 50 - (i * 3) + (i * 5) + 1;
            var f4 = i + 3 - (i * 3) + (i * 5) + (i * 2);
            var createdDate = DateTime.Now;
            var days = Convert.ToInt16(Math.Pow(i, 2));
            var customerIndex = random.Next(1, customers.Count - 1);
            var employeeIndex = random.Next(1, employees.Count - 1);
            var empl = employees.ElementAt(employeeIndex);
            var invoiceIndex = random.Next(1, invoices.Count - 1);
            Project pjk = new Project()
            {
                Id = "2546" + Convert.ToString(i),
                CreatedDate = createdDate,
                LastUpdatedDate = createdDate,
                Code = "D-22-16" + Convert.ToString(i),
                Name = "Project_" + Convert.ToString(i),
                Description = "Test Description Project_" + Convert.ToString(i),
                Drawing = "KL-" + Convert.ToString(i),
                PlanType = i % 2 == 0 ? PlanType.ELEC : PlanType.HVAC,
                WorkingDays = i + 200 - (i * 3) + (i * 5),
                DurationDate = createdDate.AddDays(f1),
                EstPaymentDate = createdDate.AddDays(f2),
                PaymentDate = createdDate.AddDays(f3),
                DelayInPayment = f4,
                PaymentDetailes = "Payment Detailes For Project_" + Convert.ToString(i),
                DayCost = 7 + i - (1 * 2),
                Bank = i % 2 == 0 ? "ALPHA" : "NBG_IBANK",
                PaidFee = 7 - (1 * 2),
                DaysUntilPayment = (createdDate - createdDate.AddDays(f3)).Days,
                PendingPayments = i,
                CalculationDaly = i < 5 ? i : i - (i - 1),
                Completed = i * 10 < 100 ? i * 10 : 100 - (i * 10),
                ManHours = 8 * (DateTime.Now.AddDays(days) - createdDate).Days,
                CustomerId = customers.ElementAt(customerIndex).Id,
                //Customer = customers.ElementAt(customerIndex),
                InvoiceId = invoices.ElementAt(invoiceIndex).Id,
                //Invoice = invoices.ElementAt(invoiceIndex),
                //Employees = new List<Employee>()
                //{
                //    empl
                //}
            };

            builder.Entity<Project>().HasData(pjk);
        }

    }

}