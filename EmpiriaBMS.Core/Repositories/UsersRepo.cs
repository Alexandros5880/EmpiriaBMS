using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Core.ReturnModels;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmpiriaBMS.Core.Repositories;
public class UsersRepo : Repository<UserDto, User>
{

    private readonly EmailRepo _emailRepo;
    public UsersRepo(
        IDbContextFactory<AppDbContext> DbFactory,
        Logging.LoggerManager logger
    ) : base(DbFactory, logger)
    {
        _emailRepo = new EmailRepo(DbFactory, logger);
    }

    public async Task<bool> Exists(string email)
    {
        if (email == null)
            return false;

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            // Search in emails
            // return await _context.Set<Email>().AnyAsync(u => u.Address.Equals(email));
            // Search in Reverse Proxy
            return await _context.Set<User>()
                                 .Where(r => !r.IsDeleted)
                                 .AnyAsync(u => u.ProxyAddress.Equals(email));
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
                             .Where(r => !r.IsDeleted)
                             .Include(r => r.Disciplines)
                             .Include(r => r.UserRoles)
                             .FirstOrDefaultAsync(r => r.Id == id);

            return Mapping.Mapper.Map<UserDto>(u);
        }
    }

    public async Task<UserDto?> Get(string email)
    {
        if (email == null)
            throw new ArgumentNullException(nameof(email));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var u = await _context
                             .Set<User>()
                             .Where(r => !r.IsDeleted)
                             .Include(r => r.Disciplines)
                             .Include(r => r.UserRoles)
                             .FirstOrDefaultAsync(r => r.ProxyAddress.Equals(email));

            return Mapping.Mapper.Map<UserDto>(u);
        }
    }

    public async Task<UserDto?> Get(string email, string password)
    {
        try
        {
            if (email == null)
                throw new ArgumentNullException(nameof(email));

            if (password == null)
                throw new ArgumentNullException(nameof(password));

            // Create Hasher
            var hash = PasswordHasher.HashPassword(password);

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var userWithSameProxy = await _context
                                 .Set<User>()
                                 .Where(r => !r.IsDeleted)
                                 .Include(r => r.Disciplines)
                                 .Include(r => r.UserRoles)
                                 .FirstOrDefaultAsync(r => r.ProxyAddress.Equals(email));

                var userHash = userWithSameProxy?.PasswordHash;

                if (!string.IsNullOrEmpty(userHash) && hash.Equals(userHash))
                    return Mapping.Mapper.Map<UserDto>(userWithSameProxy);

                return null;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On UsersRepo.Get(string email, string password): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return null;
        }
    }

    public async Task<ICollection<UserDto>> GetAllWithRoles()
    {
        var users = await GetEmployees();

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var usersroles = await _context.Set<UserRole>()
                                           .Where(r => !r.IsDeleted)
                                           .Include(ur => ur.Role)
                                           .ToListAsync();

            //var users = await _context.Set<User>()
            //                          .Where(r => !r.IsDeleted)
            //                          .ToListAsync();

            var userDto = Mapping.Mapper.Map<List<UserDto>>(users);

            foreach (var u in userDto)
            {
                u.Roles = u.Roles ?? new List<RoleDto>();
                foreach (var ur in usersroles)
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
                us = await _context.Set<User>()
                                   .Where(r => !r.IsDeleted)
                                   .ToListAsync();

                return Mapping.Mapper.Map<List<User>, List<UserDto>>(us);
            }


            us = await _context.Set<User>()
                                 .Where(r => !r.IsDeleted)
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
    )
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<User> us;

            if (pageSize == 0 || pageIndex == 0)
            {
                us = await _context.Set<User>()
                                   .Where(r => !r.IsDeleted)
                                   .Where(expresion)
                                   .ToListAsync();

                return Mapping.Mapper.Map<List<User>, List<UserDto>>(us);
            }


            us = await _context.Set<User>()
                               .Where(r => !r.IsDeleted)
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
            return new List<RoleDto>();

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var roleIds = await _context.Set<UserRole>()
                                        .Where(r => !r.IsDeleted)
                                        .Where(r => r.UserId == userId)
                                        .Select(r => r.RoleId)
                                        .ToListAsync();

            var roles = await _context.Roles
                                      .Where(r => !r.IsDeleted)
                                      .Where(r => roleIds.Contains(r.Id))
                                      .ToListAsync();

            return Mapping.Mapper.Map<List<Role>, List<RoleDto>>(roles);
        }
    }

    public async Task UpdateRoles(int userId, ICollection<int> rolesids)
    {
        if (userId == 0)
            throw new NullReferenceException($"No User Id Specified!");

        if (rolesids == null)
            throw new NullReferenceException($"No Roles Ids Specified!");

        List<UserRole> userRolesToDelete;

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            userRolesToDelete = await _context.Set<UserRole>()
                                              .Where(r => !r.IsDeleted)
                                              .Where(r => r.UserId == userId)
                                              .ToListAsync();
        }

        foreach (var ur in userRolesToDelete)
        {
            ur.IsDeleted = true;
            await DeleteUserRole(ur);
        }

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            try
            {
                Random random = new Random();

                List<UserRole> userRolesToAdd = rolesids.Select(roleId => new UserRole()
                {
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    UserId = userId,
                    RoleId = roleId
                }).ToList();

                foreach (var userRole in userRolesToAdd)
                {
                    if (!_context.UsersRoles
                        .Where(r => !r.IsDeleted)
                        .Any(ur => ur.RoleId == userRole.RoleId && ur.UserId == userRole.UserId))
                    {
                        await _context.Set<UserRole>().AddAsync(userRole);
                    }
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception On UsersRepo.UpdateRoles(UserRole): {ex.Message}, \nInner: {ex.InnerException?.Message}");
                await _context.Set<UserRole>().AddRangeAsync(userRolesToDelete);
            }
        }
    }

    public async Task<ICollection<UserDto>> GetProjectManagers()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var rolesIds = await _context.Set<Role>()
                                         .Where(r => !r.IsDeleted)
                                         .Where(r => r.Name.Equals("Project Manager"))
                                         .Select(r => r.Id)
                                         .ToListAsync();

            var usersIds = await _context.UsersRoles
                                                    .Where(r => !r.IsDeleted)
                                                    .Where(ur => rolesIds.Contains(ur.RoleId))
                                                    .Select(ur => ur.UserId)
                                                    .ToListAsync();

            var users = await _context.Users.Where(r => !r.IsDeleted)
                                            .Where(u => usersIds.Contains(u.Id))
                                            .ToListAsync();

            return Mapping.Mapper.Map<List<User>, List<UserDto>>(users);
        }
    }

    public async Task<ICollection<UserDto>> GetEmployees()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var emplyeeRolesIds = await _context.Set<Role>()
                                                .Where(r => !r.IsDeleted)
                                                .Where(r => r.IsEmployee || r.Name.Contains("Admin") || r.Name.Contains("admin"))
                                                .Select(r => r.Id)
                                                .ToListAsync();

            var employeeIds = await _context.UsersRoles.Where(r => !r.IsDeleted)
                                                       .Where(ur => emplyeeRolesIds.Contains(ur.RoleId))
                                                      .Select(ur => ur.UserId)
                                                      .ToListAsync();

            var users = await _context.Users.Where(r => !r.IsDeleted)
                                            .Where(u => employeeIds.Contains(u.Id))
                                            .Include(r => r.Disciplines)
                                            .Include(r => r.UserRoles)
                                            .ToListAsync();

            return Mapping.Mapper.Map<List<User>, List<UserDto>>(users);
        }
    }

    public async Task<ICollection<UserDto>> GetCustomers()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var customersRolesIds = await _context.Set<Role>()
                                                  .Where(r => !r.IsDeleted)
                                                  .Where(r => !r.IsEmployee)
                                                  .Select(r => r.Id)
                                                  .ToListAsync();

            var customerIds = await _context.UsersRoles.Where(r => !r.IsDeleted)
                                                       .Where(ur => customersRolesIds.Contains(ur.RoleId))
                                                       .Select(ur => ur.UserId)
                                                       .ToListAsync();

            var users = await _context.Users.Where(r => !r.IsDeleted)
                                            .Where(u => customerIds.Contains(u.Id))
                                            .Include(r => r.Disciplines)
                                            .Include(r => r.UserRoles)
                                            .ToListAsync();

            return Mapping.Mapper.Map<List<User>, List<UserDto>>(users);
        }
    }

    public async Task<double> GetUserTotalHoursThisMonth(int userId)
    {
        if (userId == 0)
            throw new ArgumentException(nameof(userId));

        // Get current date
        DateTime currentDate = DateTime.Now;

        // Get date for a month later
        DateTime dateOneMonthLater = currentDate.AddMonths(-1);

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var timeSpans = await _context.Set<DailyTime>()
                                 .Where(r => !r.IsDeleted)
                                 .Where(u => u.DailyUserId == userId
                                        || u.PersonalUserId == userId
                                        || u.TrainingUserId == userId
                                        || u.CorporateUserId == userId)
                                 .Where(u => u.Date.CompareTo(dateOneMonthLater) > 0)
                                 .Select(u => u.ToTimeSpan())
                                 .ToListAsync();

            var totalTimeSpan = timeSpans.Aggregate(TimeSpan.Zero, (sum, next) => sum.Add(next));

            return totalTimeSpan.TotalHours;
        }
    }

    public async Task<double> GetUserSumHours(int userId)
    {
        if (userId == 0)
            throw new ArgumentException(nameof(userId));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context.Set<DailyTime>()
                           .Where(r => !r.IsDeleted)
                           .Where(u => u.DailyUserId == userId)
                           .Select(d => d.Hours)
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
                                           .Where(r => !r.IsDeleted)
                                           .Where(u => u.DailyUserId == userId)
                                           .Where(u => u.Date.CompareTo(dateBeforeWeek) > 0)
                                           .Select(u => u.Hours)
                                           .SumAsync();
        }
    }

    public async Task<UserTimes> GetTime(int userId, DateTime date)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            // DailyTime
            var dailyTimeSpans = await _context.Set<DailyTime>()
                                          .Where(r => !r.IsDeleted)
                                          .Where(dt =>
                                                dt.DailyUserId == userId
                                                && dt.Date.Year.Equals(date.Year)
                                                && dt.Date.Month.Equals(date.Month)
                                                && dt.Date.Day.Equals(date.Day))
                                          .ToListAsync();
            TimeSpan dailyTimeTotal = TimeHelper.CalculateTotalTime(dailyTimeSpans);

            // PersonalTime
            var personalTimeSpans = await _context.Set<DailyTime>()
                                            .Where(r => !r.IsDeleted)
                                            .Where(dt =>
                                                dt.PersonalUserId == userId
                                                && dt.Date.Year.Equals(date.Year)
                                                && dt.Date.Month.Equals(date.Month)
                                                && dt.Date.Day.Equals(date.Day))
                                          .ToListAsync();
            TimeSpan personalTimeTotal = TimeHelper.CalculateTotalTime(personalTimeSpans);

            // TrainingTime
            var trainingTimeSpans = await _context.Set<DailyTime>()
                                          .Where(r => !r.IsDeleted)
                                          .Where(dt =>
                                                dt.TrainingUserId == userId
                                                && dt.Date.Year.Equals(date.Year)
                                                && dt.Date.Month.Equals(date.Month)
                                                && dt.Date.Day.Equals(date.Day))
                                          .ToListAsync();
            TimeSpan trainingTimeTotal = TimeHelper.CalculateTotalTime(trainingTimeSpans);

            // CorporateEventTime
            var corporateEventTimeSpans = await _context.Set<DailyTime>()
                                          .Where(r => !r.IsDeleted)
                                          .Where(dt =>
                                                dt.CorporateUserId == userId
                                                && dt.Date.Year.Equals(date.Year)
                                                && dt.Date.Month.Equals(date.Month)
                                                && dt.Date.Day.Equals(date.Day))
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

    public async Task<ICollection<IssueDto>> GetOpenIssues(int userId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var rolesIds = await _context.Set<UserRole>()
                                 .Where(r => !r.IsDeleted)
                                 .Where(ur => ur.UserId == userId)
                                 .Include(ur => ur.Role)
                                 .Select(ur => ur.RoleId)
                                 .ToListAsync();

            var issues = await _context.Set<Issue>()
                                .Where(r => !r.IsDeleted)
                                .Where(i => rolesIds.Contains(i.DisplayedRoleId))
                                .Where(i => i.IsClose == false)
                                .Include(i => i.Project)
                                .Include(i => i.DisplayedRole)
                                .Include(i => i.Documents)
                                .Include(i => i.Creator)
                                .ToListAsync();

            return Mapping.Mapper.Map<List<Issue>, List<IssueDto>>(issues);
        }
    }

    public async Task<UserRole> DeleteUserRole(UserRole entity)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var entry = await _context.Set<UserRole>().FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (entry != null)
                {
                    entry.IsDeleted = true;

                    _context.UsersRoles.Remove(entry);

                    await _context.SaveChangesAsync();
                }

                return entry;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On UsersRepo.DeleteUserRole({Mapping.Mapper.Map<UserRole>(entity).GetType()}): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return null;
        }
    }

    #region Email
    public async Task<ICollection<Email>> GetEmails(int userId = 0)
    {
        if (userId == 0)
            return new List<Email>();

        using (var _context = _dbContextFactory.CreateDbContext())
            return await _context.Set<Email>()
                                 .Where(r => !r.IsDeleted)
                                 .Where(r => userId == 0 ? true : r.UserId == userId)
                                 .ToListAsync();
    }

    public async Task UpsertEmails(int userId, List<EmailDto> emails)
    {
        try
        {
            if (userId == 0)
                return;

            List<Email> prevEmails;

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                prevEmails = await _context.Set<Email>()
                        .Where(e => e.UserId == userId)
                        .ToListAsync();
            }

            var updatedIds = emails.Select(e => e.Id).ToList();

            // Updated the existed
            foreach (var prevEmail in prevEmails)
            {
                if (!updatedIds.Contains(prevEmail.Id))
                {
                    await DeleteEmail(prevEmail.Id);
                }
                else
                {
                    var updated = emails.FirstOrDefault(e => e.Id == prevEmail.Id);

                    if (updated == null)
                        continue;

                    await _emailRepo.Update(updated);

                    emails.Remove(updated);
                }
            }

            await AddEmailsRange(emails);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On UsersRepo.UpdateEmails(int userId, List<EmailDto> emails): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    public async Task RemoveEmailsAll(int userId, bool definitely = false)
    {
        try
        {
            if (userId == 0)
                return;

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var prevEmails = await _context.Set<Email>()
                    .Where(r => !r.IsDeleted)
                    .Where(e => e.UserId == userId)
                    .ToListAsync();
                if (definitely)
                {
                    _context.Set<Email>().RemoveRange(prevEmails);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    foreach (var e in prevEmails)
                    {
                        if (e == null)
                            continue;
                        await DeleteEmail(e.Id);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ClientRepo.RemoveEmailsAll(emailId): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    public async Task AddEmailsRange(IList<EmailDto> emails)
    {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var data = Mapping.Mapper.Map<List<Email>>(emails);
                await _context.Set<Email>().AddRangeAsync(data);
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ClientRepo.AddEmailsRange(emailId): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    public async Task<Email> DeleteEmail(int emailId)
    {
        try
        {
            if (emailId == null)
                throw new ArgumentNullException(nameof(emailId));

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var entry = await _context.Set<Email>().FirstOrDefaultAsync(x => x.Id == emailId);
                if (entry != null)
                {
                    entry.IsDeleted = true;
                    await _context.SaveChangesAsync();
                }

                return entry;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ClientRepo.DeleteEmail(emailId): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return default(Email)!;
        }
    }
    #endregion
}