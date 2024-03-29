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

public class IssueRepo : Repository<IssueDto, Issue>
{
    public IssueRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public async new Task<IssueDto> Add(IssueDto entity, bool update = false)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        entity.CreatedDate = update ? DateTime.Now.ToUniversalTime() : entity.CreatedDate;
        entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            Issue issue = Mapping.Mapper.Map<Issue>(entity);
            issue.Role = null;
            issue.Project = null;
            issue.Creator = null;
            var result = await _context.Set<Issue>().AddAsync(issue);
            await _context.SaveChangesAsync();

            return Mapping.Mapper.Map<IssueDto>(result.Entity);
        }
    }

    public async Task UpdateAll(List<IssueDto> entities)
    {
        if (entities == null)
            throw new ArgumentNullException(nameof(entities));

        if (entities.Count == 0)
            throw new Exception($"Exception: Length List<IssueDto> entities == 0.");

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            foreach(var i in entities)
            {
                var entry = await _context.Set<Issue>().FirstOrDefaultAsync(x => x.Id == i.Id);
                if (entry != null)
                {
                    _context.Entry(entry).CurrentValues.SetValues(Mapping.Mapper.Map<Issue>(i));
                    await _context.SaveChangesAsync();
                }
            }
        }
    }

}
