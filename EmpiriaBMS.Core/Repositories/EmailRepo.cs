using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpiriaBMS.Core.Repositories;

public class EmailRepo : Repository<EmailDto, Email>
{
    public EmailRepo(
        IDbContextFactory<AppDbContext> DbFactory,
        Logging.LoggerManager logger
    ) : base(DbFactory, logger) { }

    public async Task RemoveAll(int userId)
    {
        if (userId == 0)
            return;

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var prevEmails = await _context.Set<Email>().Where(r => !r.IsDeleted).Where(e => e.UserId == userId).ToListAsync();
            foreach (var e in prevEmails)
            {
                await DeleteEmail(e);
            }
            //_context.Set<Email>().RemoveRange(prevEmails);
            //await _context.SaveChangesAsync();
        }
    }

    public async Task AddRange(IList<EmailDto> emails)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            emails.ToList().ForEach(e => e.Id = 0);
            var data = Mapping.Mapper.Map<List<Email>>(emails);
            await _context.Set<Email>().AddRangeAsync(data);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Email> DeleteEmail(Email entity)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var entry = await _context.Set<Email>().FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (entry != null)
                {
                    entry.IsDeleted = true;
                    await _context.SaveChangesAsync();
                }

                return entry!;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On EmailRepo.DeleteEmail({Mapping.Mapper.Map<Email>(entity).GetType()}): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return default(Email)!;
        }
    }
}
