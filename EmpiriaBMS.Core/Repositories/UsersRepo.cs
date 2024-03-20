using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.ExtensionMethods;
using EmpiriaBMS.Core.ReturnModels;
using EmpiriaBMS.Core.Hellpers;

namespace EmpiriaBMS.Core.Repositories;
public class UsersRepo : Repository<UserDto, User>
{
    public UsersRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public async Task<bool> Exists(string email)
    {
        if (email == null)
            return false;

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            // Search in emails
            //return await _context.Set<Email>().AnyAsync(u => u.Address.Equals(email));
            // Search in Reverse Proxy
            return await _context.Set<User>().AnyAsync(u => u.ProxyAddress.Equals(email));
        }
    }

    public new async Task<UserDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var u = await _context
                             .Set<User>()
                             .Include(r => r.Disciplines)
                             .Include(r => r.UserRoles)
                             .FirstOrDefaultAsync(r => r.Id == id);

            return Mapping.Mapper.Map<UserDto>(u);
        }
    }

    public new async Task<UserDto?> Get(string email)
    {
        if (email == null)
            throw new ArgumentNullException(nameof(email));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var u = await _context
                             .Set<User>()
                             .Include(r => r.Disciplines)
                             .Include(r => r.UserRoles)
                             .FirstOrDefaultAsync(r => r.ProxyAddress.Equals(email));

            return Mapping.Mapper.Map<UserDto>(u);
        }
    }

    public async Task<ICollection<UserDto>> GetAllWithRoles()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var usersroles = await _context.Set<UserRole>()
                                           .Include(ur => ur.Role)
                                           .ToListAsync();

            var users = await _context.Set<User>()
                                     .ToListAsync();

            var userDto = Mapping.Mapper.Map<List<UserDto>>(users);

            foreach(var u in userDto)
            {
                u.Roles = u.Roles ?? new List<RoleDto>();
                foreach(var ur in usersroles)
                {
                    if (u.Id.Equals(ur.UserId))
                        u.Roles.Add(Mapping.Mapper.Map<RoleDto>(ur.Role));
                }
            }

            return userDto;
        }
    }

    public new async Task<ICollection<UserDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<User> us;

            if (pageSize == 0 || pageIndex == 0)
            {
                us = await _context.Set<User>().ToListAsync();

                return Mapping.Mapper.Map<List<User>, List<UserDto>>(us);
            }


            us = await _context.Set<User>()
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .Include(r => r.Disciplines)
                                 .Include(r => r.UserRoles)
                                 .ToListAsync();

            return Mapping.Mapper.Map<List<User>, List<UserDto>>(us);
        }
    }

    public new async Task<ICollection<UserDto>> GetAll(
        Expression<Func<User, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<User> us;

            if (pageSize == 0 || pageIndex == 0)
            {
                us = await _context.Set<User>().Where(expresion).ToListAsync();

                return Mapping.Mapper.Map<List<User>, List<UserDto>>(us);
            }


            us = await _context.Set<User>()
                               .Where(expresion)
                               .Skip((pageIndex - 1) * pageSize)
                               .Take(pageSize)
                               .Include(r => r.Disciplines)
                               .Include(r => r.UserRoles)
                               .ToListAsync();

            return Mapping.Mapper.Map<List<User>, List<UserDto>>(us);
        }
    }

    public async Task<ICollection<RoleDto>> GetRoles(int userId)
    {
        if (userId == 0)
            throw new NullReferenceException($"No User Id Specified!");

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var roleIds = await _context.Set<UserRole>()
                                        .Where(r => r.UserId == userId)
                                        .Select(r => r.RoleId)
                                        .ToListAsync();

            var roles = await _context.Roles.Where(r => roleIds.Contains(r.Id))
                                       .ToListAsync();

            return Mapping.Mapper.Map<List<Role>, List<RoleDto>>(roles);
        }
    }

    public async Task<ICollection<UserDto>> GetEmployees()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var emplyeeRolesIds = await _context.Set<Role>()
                                                .Where(r => r.IsEmployee)
                                                .Select(r => r.Id)
                                                .ToListAsync();

            var employeeIds = await _context.UsersRoles.Where(ur => emplyeeRolesIds.Contains(ur.Id))
                                                      .Select(ur => ur.UserId)
                                                      .ToListAsync();

            var users = await _context.Users.Where(u => employeeIds.Contains(u.Id))
                                       .Include(r => r.Disciplines)
                                       .Include(r => r.UserRoles)
                                       .ToListAsync();

            return Mapping.Mapper.Map<List<User>, List<UserDto>>(users);
        }
    }

    public async Task<ICollection<UserDto>> GetEmployees(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var emplyeeRolesIds = await _context.Set<Role>()
                                                .Where(r => r.IsEmployee)
                                                .Select(r => r.Id)
                                                .ToListAsync();

            var employeeIds = await _context.UsersRoles.Where(ur => emplyeeRolesIds.Contains(ur.Id))
                                                      .Select(ur => ur.UserId)
                                                      .ToListAsync();

            List<User> users;

            if (pageSize == 0 || pageIndex == 0)
            {
                users = await _context.Users.Where(u => employeeIds.Contains(u.Id))
                                           .ToListAsync();

                return Mapping.Mapper.Map<List<User>, List<UserDto>>(users);
            }



            users = await _context.Users.Where(u => employeeIds.Contains(u.Id))
                                       .Include(r => r.Disciplines)
                                       .Include(r => r.UserRoles)
                                       .Skip((pageIndex - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();

            return Mapping.Mapper.Map<List<User>, List<UserDto>>(users);
        }
    }

    public async Task<ICollection<UserDto>> GetEmployees(
        Expression<Func<User, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var emplyeeRolesIds = await _context.Set<Role>()
                                                .Where(r => r.IsEmployee)
                                                .Select(r => r.Id)
                                                .ToListAsync();

            var employeeIds = await _context.UsersRoles.Where(ur => emplyeeRolesIds.Contains(ur.Id))
                                                      .Select(ur => ur.UserId)
                                                      .ToListAsync();

            List<User> users;

            if (pageSize == 0 || pageIndex == 0)
            {
                users = await _context.Users.Where(u => employeeIds.Contains(u.Id))
                                           .Where(expresion)
                                           .ToListAsync();

                return Mapping.Mapper.Map<List<User>, List<UserDto>>(users);
            }



            users = await _context.Users.Where(u => employeeIds.Contains(u.Id))
                                       .Include(r => r.Disciplines)
                                       .Include(r => r.UserRoles)
                                       .Where(expresion)
                                       .Skip((pageIndex - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();

            return Mapping.Mapper.Map<List<User>, List<UserDto>>(users);
        }
    }

    public async Task<ICollection<UserDto>> GetCustomers()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var customersRolesIds = await _context.Set<Role>()
                                                .Where(r => !r.IsEmployee)
                                                .Select(r => r.Id)
                                                .ToListAsync();

            var customerIds = await _context.UsersRoles.Where(ur => customersRolesIds.Contains(ur.Id))
                                                      .Select(ur => ur.UserId)
                                                      .ToListAsync();

            var users = await _context.Users.Where(u => customerIds.Contains(u.Id))
                                       .Include(r => r.Disciplines)
                                       .Include(r => r.UserRoles)
                                       .ToListAsync();

            return Mapping.Mapper.Map<List<User>, List<UserDto>>(users);
        }
    }

    public async Task<ICollection<UserDto>> GetCustomers(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var customersRolesIds = await _context.Set<Role>()
                                                .Where(r => !r.IsEmployee)
                                                .Select(r => r.Id)
                                                .ToListAsync();

            var customerIds = await _context.UsersRoles.Where(ur => customersRolesIds.Contains(ur.Id))
                                                      .Select(ur => ur.UserId)
                                                      .ToListAsync();

            List<User> users;

            if (pageSize == 0 || pageIndex == 0)
            {
                users = await _context.Users.Where(u => customerIds.Contains(u.Id))
                                           .ToListAsync();

                return Mapping.Mapper.Map<List<User>, List<UserDto>>(users);
            }

            users = await _context.Users.Where(u => customerIds.Contains(u.Id))
                                       .Include(r => r.Disciplines)
                                       .Include(r => r.UserRoles)
                                       .Skip((pageIndex - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();

            return Mapping.Mapper.Map<List<User>, List<UserDto>>(users);
        }
    }

    public async Task<ICollection<UserDto>> GetCustomers(
        Expression<Func<User, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var customersRolesIds = await _context.Set<Role>()
                                                .Where(r => !r.IsEmployee)
                                                .Select(r => r.Id)
                                                .ToListAsync();

            var customerIds = await _context.UsersRoles.Where(ur => customersRolesIds.Contains(ur.Id))
                                                      .Select(ur => ur.UserId)
                                                      .ToListAsync();

            List<User> users;

            if (pageSize == 0 || pageIndex == 0)
            {
                users = await _context.Users.Where(u => customerIds.Contains(u.Id))
                                           .Where(expresion)
                                           .ToListAsync();

                return Mapping.Mapper.Map<List<User>, List<UserDto>>(users);
            }

            users = await _context.Users.Where(u => customerIds.Contains(u.Id))
                                       .Include(r => r.Disciplines)
                                       .Include(r => r.UserRoles)
                                       .Where(expresion)
                                       .Skip((pageIndex - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();

            return Mapping.Mapper.Map<List<User>, List<UserDto>>(users);
        }
    }

    public async Task<double> GetUserHours(int userId, DateTime date)
    {
        if (userId == 0)
            throw new ArgumentException(nameof(userId));

        if (date > DateTime.Now)
            throw new ArgumentException(nameof(date));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var dailyHours = await _context.Set<DailyTime>()
                                     .Where(u => u.DailyUserId == userId)
                                     .ToListAsync();
            
            var dailyHour = dailyHours.FirstOrDefault(d => d.Date.CompareTo(date) == 0);
            
            return dailyHour.TimeSpan.Hours;
        }
    }

    public async Task<double> GetUserHoursFromLastMonday(int userId, DateTime date)
    {
        if (userId == 0)
            throw new ArgumentException(nameof(userId));

        if (date > DateTime.Now)
            throw new ArgumentException(nameof(date));

        if (date.DayOfWeek == DayOfWeek.Monday)
            return 0.0;

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var lastMondaysDate = DateTime.Now.StartOfWeek(DayOfWeek.Monday);

            return await _context.Set<DailyTime>()
                                           .Where(u => u.DailyUserId == userId)
                                           .Where(u => u.Date.CompareTo(lastMondaysDate) > 0)
                                           .Select(u => u.TimeSpan.Hours)
                                           .SumAsync();
        }
    }

    public async Task<double> GetUserSumHours(int userId)
    {
        if (userId == 0)
            throw new ArgumentException(nameof(userId));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context.Set<DailyTime>()
                           .Where(u => u.DailyUserId == userId)
                           .Select(d => d.TimeSpan.Hours)
                           .SumAsync();
        }
    }

    public async Task<double> GetUserLastWeekHours(int userId, DateTime date)
    {
        if (userId == 0)
            throw new ArgumentException(nameof(userId));

        if (date > DateTime.Now)
            throw new ArgumentException(nameof(date));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var dateBeforeWeek = date.AddDays(-7);
            return await _context.Set<DailyTime>()
                                           .Where(u => u.DailyUserId == userId)
                                           .Where(u => u.Date.CompareTo(dateBeforeWeek) > 0)
                                           .Select(u => u.TimeSpan.Hours)
                                           .SumAsync();
        }
    }

    public async Task<DailyTime> AddDailyTime(int userId, DateTime date, TimeSpan ts)
    {
        if (userId == 0)
            throw new ArgumentException(nameof(userId));

        if (date > DateTime.Now)
            throw new ArgumentException(nameof(date));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            // Check if time is betoween 12 - 5 at morning
            TimeSpan start = new TimeSpan(12, 0, 0);
            TimeSpan end = new TimeSpan(5, 0, 0);
            TimeSpan now = date.TimeOfDay;

            if ((now > start) && (now < end))
            {
                // Get Yesterday DailyHour
                var yesterdayDate = date.AddDays(-1);
                var yesterdayDailyHour = await _context.Set<DailyTime>()
                                                   .Where(u => u.DailyUserId == userId)
                                                   .FirstOrDefaultAsync(u => u.Date.CompareTo(yesterdayDate) == 0);

                if (yesterdayDailyHour == null)
                    throw new NullReferenceException(nameof(yesterdayDailyHour));

                var timespan = yesterdayDailyHour.TimeSpan;
                var newHours = timespan.Hours + ts.Hours;
                yesterdayDailyHour.TimeSpan = new Timespan(
                    timespan.Days, newHours, timespan.Minutes, timespan.Seconds);

                await _context.SaveChangesAsync();

                return yesterdayDailyHour;
            }
            else
            {
                var result = await _context.Set<DailyTime>()
                                       .AddAsync(
                    new DailyTime {
                        DailyUserId = userId,
                        Date = date,
                        TimeSpan = new Timespan(
                            ts.Days,
                            ts.Hours,
                            ts.Minutes,
                            ts.Seconds
                        )
                    }
                );

                return result.Entity;
            }
        }
    }

    public async Task<DailyTime> AddPersonalTime(int userId, DateTime date, TimeSpan ts)
    {
        if (userId == 0)
            throw new ArgumentException(nameof(userId));

        if (date > DateTime.Now)
            throw new ArgumentException(nameof(date));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            // Check if time is betoween 12 - 5 at morning
            TimeSpan start = new TimeSpan(12, 0, 0);
            TimeSpan end = new TimeSpan(5, 0, 0);
            TimeSpan now = date.TimeOfDay;

            if ((now > start) && (now < end))
            {
                // Get Yesterday DailyHour
                var yesterdayDate = date.AddDays(-1);
                var yesterdayDailyHour = await _context.Set<DailyTime>()
                                                   .Where(u => u.PersonalUserId == userId)
                                                   .FirstOrDefaultAsync(u => u.Date.CompareTo(yesterdayDate) == 0);

                if (yesterdayDailyHour == null)
                    throw new NullReferenceException(nameof(yesterdayDailyHour));

                var timespan = yesterdayDailyHour.TimeSpan;
                var newHours = timespan.Hours + ts.Hours;
                yesterdayDailyHour.TimeSpan = new Timespan(
                    timespan.Days, newHours, timespan.Minutes, timespan.Seconds);

                await _context.SaveChangesAsync();

                return yesterdayDailyHour;
            }
            else
            {
                var result = await _context.Set<DailyTime>()
                                       .AddAsync(
                    new DailyTime
                    {
                        PersonalUserId = userId,
                        Date = date,
                        TimeSpan = new Timespan(
                            ts.Days,
                            ts.Hours,
                            ts.Minutes,
                            ts.Seconds
                        )
                    }
                );

                return result.Entity;
            }
        }
    }

    public async Task<DailyTime> AddTraningTime(int userId, DateTime date, TimeSpan ts)
    {
        if (userId == 0)
            throw new ArgumentException(nameof(userId));

        if (date > DateTime.Now)
            throw new ArgumentException(nameof(date));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            // Check if time is betoween 12 - 5 at morning
            TimeSpan start = new TimeSpan(12, 0, 0);
            TimeSpan end = new TimeSpan(5, 0, 0);
            TimeSpan now = date.TimeOfDay;

            if ((now > start) && (now < end))
            {
                // Get Yesterday DailyHour
                var yesterdayDate = date.AddDays(-1);
                var yesterdayDailyHour = await _context.Set<DailyTime>()
                                                   .Where(u => u.TrainingUserId == userId)
                                                   .FirstOrDefaultAsync(u => u.Date.CompareTo(yesterdayDate) == 0);

                if (yesterdayDailyHour == null)
                    throw new NullReferenceException(nameof(yesterdayDailyHour));

                var timespan = yesterdayDailyHour.TimeSpan;
                var newHours = timespan.Hours + ts.Hours;
                yesterdayDailyHour.TimeSpan = new Timespan(
                    timespan.Days, newHours, timespan.Minutes, timespan.Seconds);

                await _context.SaveChangesAsync();

                return yesterdayDailyHour;
            }
            else
            {
                var result = await _context.Set<DailyTime>()
                                       .AddAsync(
                    new DailyTime
                    {
                        TrainingUserId = userId,
                        Date = date,
                        TimeSpan = new Timespan(
                            ts.Days,
                            ts.Hours,
                            ts.Minutes,
                            ts.Seconds
                        )
                    }
                );

                return result.Entity;
            }
        }
    }

    public async Task<DailyTime> AddCorporateEventTime(int userId, DateTime date, TimeSpan ts)
    {
        if (userId == 0)
            throw new ArgumentException(nameof(userId));

        if (date > DateTime.Now)
            throw new ArgumentException(nameof(date));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            // Check if time is betoween 12 - 5 at morning
            TimeSpan start = new TimeSpan(12, 0, 0);
            TimeSpan end = new TimeSpan(5, 0, 0);
            TimeSpan now = date.TimeOfDay;

            if ((now > start) && (now < end))
            {
                // Get Yesterday DailyHour
                var yesterdayDate = date.AddDays(-1);
                var yesterdayDailyHour = await _context.Set<DailyTime>()
                                                   .Where(u => u.CorporateUserId == userId)
                                                   .FirstOrDefaultAsync(u => u.Date.CompareTo(yesterdayDate) == 0);

                if (yesterdayDailyHour == null)
                    throw new NullReferenceException(nameof(yesterdayDailyHour));

                var timespan = yesterdayDailyHour.TimeSpan;
                var newHours = timespan.Hours + ts.Hours;
                yesterdayDailyHour.TimeSpan = new Timespan(
                    timespan.Days, newHours, timespan.Minutes, timespan.Seconds);

                await _context.SaveChangesAsync();

                return yesterdayDailyHour;
            }
            else
            {
                var result = await _context.Set<DailyTime>()
                                       .AddAsync(
                    new DailyTime
                    {
                        CorporateUserId = userId,
                        Date = date,
                        TimeSpan = new Timespan(
                            ts.Days,
                            ts.Hours,
                            ts.Minutes,
                            ts.Seconds
                        )
                    }
                );

                return result.Entity;
            }
        }
    }

    public async Task<UserTimes> GetTime(int userId, DateTime date)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            // DailyTime
            var dailyTimeSpans = await _context.Set<DailyTime>()
                                          .Where(dt => 
                                                dt.DailyUserId == userId
                                                && dt.Date.Year.Equals(date.Year)
                                                && dt.Date.Month.Equals(date.Month)
                                                && dt.Date.Day.Equals(date.Day))
                                          .Include(dt => dt.TimeSpan)
                                          .ToListAsync();
            TimeSpan dailyTimeTotal = TimeHelper.CalculateTotalTime(dailyTimeSpans);

            // PersonalTime
            var personalTimeSpans = await _context.Set<DailyTime>()
                                            .Where(dt =>
                                                dt.PersonalUserId == userId
                                                && dt.Date.Year.Equals(date.Year)
                                                && dt.Date.Month.Equals(date.Month)
                                                && dt.Date.Day.Equals(date.Day))
                                          .Include(dt => dt.TimeSpan)
                                          .ToListAsync();
            TimeSpan personalTimeTotal = TimeHelper.CalculateTotalTime(personalTimeSpans);

            // TrainingTime
            var trainingTimeSpans = await _context.Set<DailyTime>()
                                          .Where(dt =>
                                                dt.TrainingUserId == userId
                                                && dt.Date.Year.Equals(date.Year)
                                                && dt.Date.Month.Equals(date.Month)
                                                && dt.Date.Day.Equals(date.Day))
                                          .Include(dt => dt.TimeSpan)
                                          .ToListAsync();
            TimeSpan trainingTimeTotal = TimeHelper.CalculateTotalTime(trainingTimeSpans);

            // CorporateEventTime
            var corporateEventTimeSpans = await _context.Set<DailyTime>()
                                          .Where(dt =>
                                                dt.CorporateUserId == userId
                                                && dt.Date.Year.Equals(date.Year)
                                                && dt.Date.Month.Equals(date.Month)
                                                && dt.Date.Day.Equals(date.Day))
                                          .Include(dt => dt.TimeSpan)
                                          .ToListAsync();
            TimeSpan corporateEventTimeTotal = TimeHelper.CalculateTotalTime(corporateEventTimeSpans);

            return new UserTimes()
            {
                DailyTime = dailyTimeTotal,
                PersonalTime = personalTimeTotal,
                TrainingTime = trainingTimeTotal,
                CorporateEventTime = corporateEventTimeTotal
            };
        }
    }
}