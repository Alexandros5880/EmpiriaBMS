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

public class EmailRepo : Repository<EmailDto, Email>
{
    public EmailRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }
    
    public async Task RemoveAll(int userId)
    {
        if (userId == 0)
            return;

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var prevEmails = await _context.Set<Email>().Where(e => e.UserId == userId).ToListAsync();
            _context.Set<Email>().RemoveRange(prevEmails);
            await _context.SaveChangesAsync();
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
}
