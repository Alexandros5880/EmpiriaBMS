using EmpiriaMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


const string SmarterASPNetDB = "Data Source=SQL5106.site4now.net;Initial Catalog=db_a8c181_engineertoolspludb;User Id=db_a8c181_engineertoolspludb_admin;Password=Takara719791";
//const string localhostDB = "Server=127.0.0.1,1433;Database=myDB;User Id=SA;Password=Takara719791";

var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
optionsBuilder.UseSqlServer(SmarterASPNetDB);
var _context = new AppDbContext(optionsBuilder.Options);
