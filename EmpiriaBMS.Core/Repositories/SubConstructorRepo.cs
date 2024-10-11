using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Repositories;

public class SubConstructorRepo : Repository<SubConstructorDto, SubConstructor>
{
    private readonly UsersRepo _userRepo;
    private readonly EmailRepo _emailRepo;

    public SubConstructorRepo(
        IDbContextFactory<AppDbContext> DbFactory,
        Logging.LoggerManager logger
    ) : base(DbFactory, logger)
    {
        _userRepo = new UsersRepo(DbFactory, logger);
        _emailRepo = new EmailRepo(DbFactory, logger);
    }

    #region Users
    public async Task<ICollection<UserDto>> GetUsers(long subConstructorId)
    {
        try
        {
            if (subConstructorId == 0)
                return new List<UserDto>();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var users = await _context.Set<User>()
                                     .Where(r => !r.IsDeleted)
                                     .Where(r => r.SubConstructorId == subConstructorId)
                                     .ToListAsync();

                return Mapping.Mapper.Map<List<UserDto>>(users);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On SubConstructorRepo.GetUsers(int subConstructorId): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return default(ICollection<UserDto>)!;
        }
    }

    public async Task RemoveUser(long userId)
    {
        try
        {
            if (userId == 0)
                return;

            await _userRepo.Delete(userId);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On SubConstructorRepo.RemoveUser(int userId): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    public async Task AddUser(UserDto user)
    {
        try
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            await _userRepo.Add(user);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On SubConstructorRepo.AddUser(int userId): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }
    #endregion

    #region Email
    public async Task<ICollection<Email>> GetEmails(long subconstructorId)
    {
        if (subconstructorId == 0)
            return new List<Email>();

        using (var _context = _dbContextFactory.CreateDbContext())
            return await _context.Set<Email>()
                                 .Where(r => !r.IsDeleted)
                                 .Where(r => r.SubConstructorId == subconstructorId)
                                 .ToListAsync();
    }

    public async Task UpsertEmails(long subconstructorId, List<EmailDto> emails)
    {
        try
        {
            if (subconstructorId == 0)
                return;

            List<Email> prevEmails;

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                prevEmails = await _context.Set<Email>()
                        .Where(e => e.SubConstructorId == subconstructorId)
                        .ToListAsync();
            }

            var updatedIds = emails.Select(e => e.Id).ToList();

            // Updated the existed
            foreach (var prevEmail in prevEmails)
            {
                if (!updatedIds.Contains(prevEmail.Id))
                {
                    await DeleteEmail(prevEmail.Id);
                } else
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
            _logger.LogError($"Exception On SubConstructorRepo.UpdateEmails(int subconstructorId, List<EmailDto> emails): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    public async Task RemoveEmailsAll(long subconstructorId, bool definitely = false)
    {
        try
        {
            if (subconstructorId == 0)
                return;

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var prevEmails = await _context.Set<Email>()
                    .Where(r => !r.IsDeleted)
                    .Where(e => e.SubConstructorId == subconstructorId)
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
            _logger.LogError($"Exception On SubConstructorRepo.RemoveEmailsAll(emailId): {ex.Message}, \nInner: {ex.InnerException?.Message}");
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
            _logger.LogError($"Exception On SubConstructorRepo.AddEmailsRange(emailId): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    public async Task<Email> DeleteEmail(long emailId)
    {
        try
        {
            if (emailId == 0)
                throw new ArgumentException($"{nameof(emailId)} == 0");

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
            _logger.LogError($"Exception On SubConstructorRepo.DeleteEmail(emailId): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return default(Email)!;
        }
    }
    #endregion
}
