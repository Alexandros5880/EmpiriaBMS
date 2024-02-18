using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaMS.Models.Models;
using EmpiriaMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EmpiriaBMS.Models.Models;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Config;

namespace EmpiriaBMS.Core.Repositories;

public class DocRepo : Repository<DocDto>, IDisposable
{
    public DocRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public new async Task<DocDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context
                             .Set<Doc>()
                             .Include(r => r.Discipline)
                             .Select(r => Mapping.Mapper.Map<DocDto>(r))
                             .FirstOrDefaultAsync(r => r.Id == id);
        }
    }

    public new async Task<ICollection<DocDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (pageSize == 0 || pageIndex == 0)
                return await _context.Set<Doc>()
                                     .Include(r => r.Discipline)
                                     .Select(r => Mapping.Mapper.Map<DocDto>(r))
                                     .ToListAsync();

            return await _context.Set<Doc>()
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .Include(r => r.Discipline)
                                 .Select(r => Mapping.Mapper.Map<DocDto>(r))
                                 .ToListAsync();
        } 
    }

    public new async Task<ICollection<DocDto>> GetAll(
        Expression<Func<DocDto, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (pageSize == 0 || pageIndex == 0)
                return await _context.Set<Doc>()
                                     .Select(r => Mapping.Mapper.Map<DocDto>(r))
                                     .Where(expresion)
                                     .ToListAsync();

            return await _context.Set<Doc>()
                                 .Include(r => r.Discipline)
                                 .Select(r => Mapping.Mapper.Map<DocDto>(r))
                                 .Where(expresion)
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }
    }
}
