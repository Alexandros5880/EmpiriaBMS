using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.EF.CLI;
public class ApplicationDbContext : AppDbContext
{
    public ApplicationDbContext()
        : base(null)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=127.0.0.1,1433;Initial Catalog=empiriabms;User Id=sa;Password=-Plata123456");
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.EnableDetailedErrors();
        optionsBuilder.EnableServiceProviderCaching();
        optionsBuilder.EnableThreadSafetyChecks();
        base.OnConfiguring(optionsBuilder);
    }
}