using AutoMapper;
using EmpiriaBMS.Core;
using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Repositories;
using EmpiriaBMS.Front;
using EmpiriaBMS.Front.Horizontal;
using EmpiriaBMS.Front.Interop.TeamsSDK;
using EmpiriaBMS.Front.Services;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Fast.Components.FluentUI;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// TODO: Dependency Injection Decliration Here
var config = builder.Configuration.Get<ConfigOptions>();
builder.Services.AddTeamsFx(config.TeamsFx.Authentication);
builder.Services.AddScoped<MicrosoftTeams>();
builder.Services.AddSingleton<TimerService>();
builder.Services.AddSingleton<RendererService>();
builder.Services.AddBlazorBootstrap();
builder.Services.AddDbContextFactory<AppDbContext>(); // DbContext Dependency Injection
builder.Services.AddScoped<IDataProvider, DataProvider>(); // Data Providing Dependency Injection
builder.Services.AddScoped<AuthorizeServices>();
builder.Services.AddScoped<PageCachedService>();

// TODO: AutoMapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddFluentUIComponents();

builder.Services.AddControllers();
builder.Services.AddHttpClient("WebClient", client => client.Timeout = TimeSpan.FromSeconds(600));
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

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
    endpoints.MapBlazorHub();//.RequireAuthorization();
    endpoints.MapFallbackToPage("/_Host");
    endpoints.MapControllers();
});

app.Run();

