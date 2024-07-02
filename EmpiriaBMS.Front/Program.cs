using AutoMapper;
using EmpiriaBMS.Core;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Core.Services;
using EmpiriaBMS.Core.Services.DBManipulation;
using EmpiriaBMS.Core.Services.EmailService;
using EmpiriaBMS.Core.Services.GooglePlaces;
using EmpiriaBMS.Front;
using EmpiriaBMS.Front.Horizontal;
using EmpiriaBMS.Front.Interop.TeamsSDK;
using EmpiriaBMS.Front.Services;
using EmpiriaBMS.Models.Models;
using Logging;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Fast.Components.FluentUI;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// TODO: Dependency Injection Decliration Here
var config = builder.Configuration.Get<ConfigOptions>();
builder.Services.AddTeamsFx(config.TeamsFx.Authentication);
builder.Services.AddScoped<MicrosoftTeams>();
builder.Services.AddSingleton<TimerService>();
builder.Services.AddScoped<SharedAuthDataService>();
builder.Services.AddScoped<AuthorizeServices>();
builder.Services.AddBlazorBootstrap();

// Add configuration
builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);

builder.Services.AddDbContextFactory<AppDbContext>();
builder.Services.AddScoped<IDataProvider, DataProvider>(); // Data Providing Dependency Injection
builder.Services.AddScoped<DatabaseBackupService>();
builder.Services.AddScoped<SeedData>();

builder.Services.AddSingleton<IEmailService, EmailService>();
builder.Services.AddScoped<DailyEmailSender>();

// AutoMapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Google PLaces Api Service
builder.Services.AddScoped<GooglePlacesService>();


builder.Services.AddFluentUIComponents();

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();
builder.Services.AddHttpClient("WebClient", client => client.Timeout = TimeSpan.FromSeconds(600));
builder.Services.AddHttpContextAccessor();

// Add configuration
builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);

// Increase the file upload limit
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 15 * 1024 * 1024; // 15 MB
});

// Log Service
builder.Services.AddLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
    logging.AddDebug();
    // Add other logging providers as needed, e.g., Application Insights, Serilog
});
// Register LoggerManager
builder.Services.AddSingleton<Logging.LoggerManager>(sp =>
{
    var logger = sp.GetRequiredService<ILogger<LoggerManager>>();
    return new LoggerManager(logger, "EmbiriaBMS.Front");
});

var app = builder.Build();

// Scoped Services Initiations
using (var scope = app.Services.CreateScope())
{
    // Create Seed Data
    //var seedData = scope.ServiceProvider.GetRequiredService<SeedData>();
    //await seedData.CreateData();

    // Get logger from the service provider
    var logger = app.Services.GetRequiredService<ILogger<LoggerManager>>();
    // Initialize the LoggerManager with the logger instance and project name
    Data.InitializeLogger(logger, "EmbiriaBMS.Core");
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    //endpoints.MapControllers();
    //endpoints.MapControllerRoute(
    //    name: "default",
    //    pattern: "mvc/{controller=Home}/{action=Index}/{id?}"
    //);
    //endpoints.MapRazorPages();
    //endpoints.MapControllerRoute(
    //    name: "admin",
    //    pattern: "mvc/{area:exists}/{controller=Home}/{action=Index}/{id?}"
    //);
    endpoints.MapBlazorHub();//.RequireAuthorization();
    endpoints.MapFallbackToPage("/_Host");
});

app.Run();

