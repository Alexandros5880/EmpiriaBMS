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
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Fast.Components.FluentUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// TODO: Dependency Injection Decliration Here
var config = builder.Configuration.Get<ConfigOptions>();
builder.Services.AddTeamsFx(config.TeamsFx.Authentication);
builder.Services.AddScoped<MicrosoftTeams>();
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

builder.Services.AddScoped<Culture>();

// AutoMapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Google PLaces Api Service
builder.Services.AddScoped<GooglePlacesService>();

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

// AddSingleton
builder.Services.AddScoped<TimerService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowTeams",
        builder =>
        {
            builder.WithOrigins("https://teams.microsoft.com")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});


builder.Services.AddFluentUIComponents();

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();
builder.Services.AddHttpClient("WebClient", client => client.Timeout = TimeSpan.FromSeconds(600));
builder.Services.AddHttpContextAccessor();

// Increase the file upload limit
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 15 * 1024 * 1024; // 15 MB
});

builder.Services.AddServerSideBlazor()
    .AddHubOptions(options =>
    {
        options.MaximumReceiveMessageSize = 102400; // 100KB limit for large messages
        options.ClientTimeoutInterval = TimeSpan.FromMinutes(2);
        options.KeepAliveInterval = TimeSpan.FromSeconds(10);
    });




var app = builder.Build();

// Scoped Services Initiations
using (var scope = app.Services.CreateScope())
{
    // Get logger from the service provider
    var logger = app.Services.GetRequiredService<ILogger<LoggerManager>>();
    // Initialize the LoggerManager with the logger instance and project name
    Data.InitializeLogger(logger, "EmbiriaBMS.Core");

    // Create Seed Data
    //try
    //{
    //    var seedData = scope.ServiceProvider.GetRequiredService<SeedData>();
    //    await seedData.CreateData();
    //}
    //catch (Exception ex)
    //{
    //    logger.LogError($"Exception SeedData: {ex.Message}\nInner: {ex.InnerException?.Message}.");
    //}
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

app.UseCors("AllowTeams");
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "api/{controller=Database}/{action=Index}/{id?}"
    );
    //endpoints.MapRazorPages();
    //endpoints.MapControllerRoute(
    //    name: "admin",
    //    pattern: "mvc/{area:exists}/{controller=Home}/{action=Index}/{id?}"
    //);
    endpoints.MapBlazorHub();//.RequireAuthorization();
    endpoints.MapFallbackToPage("/_Host");
});

app.Run();

