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
    public SubConstructorRepo(
        IDbContextFactory<AppDbContext> DbFactory,
        Logging.LoggerManager logger
    ) : base(DbFactory, logger) { }

    #region Email
    public async Task<ICollection<Email>> GetEmails(int subconstructorId)
    {
        if (subconstructorId == 0)
            return new List<Email>();

        using (var _context = _dbContextFactory.CreateDbContext())
            return await _context.Set<Email>()
                                 .Where(r => !r.IsDeleted)
                                 .Where(r => r.SubConstructorId == subconstructorId)
                                 .ToListAsync();
    }

    public async Task UpsertEmails(int subconstructorId, List<EmailDto> emails)
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

                    using (var _context = _dbContextFactory.CreateDbContext())
                    {
                        _context.Entry(prevEmail).CurrentValues.SetValues(Mapping.Mapper.Map<Email>(updated));
                        await SaveChangesAsync();
                    }

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

    public async Task RemoveEmailsAll(int subconstructorId, bool definitely = false)
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

    public async Task<Email> DeleteEmail(int emailId)
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
