using EmpiriaBMS.Core;
using EmpiriaBMS.Core.Services;
using EmpiriaBMS.Core.Services.DBManipulation;
using EmpiriaBMS.Models.Models;
using Microsoft.Extensions.DependencyInjection;


public class Program
{
    public static async Task Main(string[] args)
    {
        if (args[0] == "seed")
        {
            // Set up the service collection
            var serviceCollection = new ServiceCollection();

            // Register DbContext with dependency injection
            serviceCollection.AddDbContextFactory<AppDbContext>();

            // Register other services
            serviceCollection.AddScoped<IDataProvider, DataProvider>();
            serviceCollection.AddScoped<DatabaseBackupService>();
            serviceCollection.AddScoped<SeedData>();

            // Build the service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Resolve the SeedData service and call the CreateData method
            var seedData = serviceProvider.GetService<SeedData>();
            await seedData.CreateData();
        }
    }
}