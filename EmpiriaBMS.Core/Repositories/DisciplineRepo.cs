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

public class DisciplineRepo : Repository<DisciplineDto>, IDisposable
{
    public DisciplineRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public new async Task<DisciplineDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context
                             .Set<Discipline>()
                             .Include(r => r.Project)
                             .Include(r => r.ProjectManager)
                             .Include(r => r.Draws)
                             .Include(r => r.Docs)
                             .Include(r => r.Engineers)
                             .Include(r => r.DisciplineEngineers)
                             .Select(r => Mapping.Mapper.Map<DisciplineDto>(r))
                             .FirstOrDefaultAsync(r => r.Id == id);
        }
    }

    public new async Task<ICollection<DisciplineDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (pageSize == 0 || pageIndex == 0)
                return await _context.Set<Discipline>()
                                     .Include(r => r.Project)
                                     .Include(r => r.ProjectManager)
                                     .Include(r => r.Draws)
                                     .Include(r => r.Docs)
                                     .Include(r => r.Engineers)
                                     .Include(r => r.DisciplineEngineers)
                                     .Select(r => Mapping.Mapper.Map<DisciplineDto>(r))
                                     .ToListAsync();

            return await _context.Set<Discipline>()
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .Include(r => r.Project)
                                 .Include(r => r.ProjectManager)
                                 .Include(r => r.Draws)
                                 .Include(r => r.Docs)
                                 .Include(r => r.Engineers)
                                 .Include(r => r.DisciplineEngineers)
                                 .Select(r => Mapping.Mapper.Map<DisciplineDto>(r))
                                 .ToListAsync();
        }
    }

    public new async Task<ICollection<DisciplineDto>> GetAll(
        Expression<Func<DisciplineDto, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (pageSize == 0 || pageIndex == 0)
                return await _context.Set<Discipline>()
                                     .Select(r => Mapping.Mapper.Map<DisciplineDto>(r))
                                     .Where(expresion)
                                     .ToListAsync();

            return await _context.Set<Discipline>()
                                 .Include(r => r.Project)
                                 .Include(r => r.ProjectManager)
                                 .Include(r => r.Draws)
                                 .Include(r => r.Docs)
                                 .Include(r => r.Engineers)
                                 .Include(r => r.DisciplineEngineers)
                                 .Select(r => Mapping.Mapper.Map<DisciplineDto>(r))
                                 .Where(expresion)
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }
    }
}

