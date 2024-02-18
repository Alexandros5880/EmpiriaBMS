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

public class DisciplineRepo : Repository<DisciplineDto, Discipline>, IDisposable
{
    public DisciplineRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public new async Task<DisciplineDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var disclipline = await _context
                             .Set<Discipline>()
                             .Include(r => r.Project)
                             .Include(r => r.ProjectManager)
                             .Include(r => r.Draws)
                             .Include(r => r.Docs)
                             .Include(r => r.Engineers)
                             .Include(r => r.DisciplineEngineers)
                             .FirstOrDefaultAsync(r => r.Id == id);

            return Mapping.Mapper.Map<DisciplineDto>(disclipline);
        }
    }

    public new async Task<ICollection<DisciplineDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Discipline> ds;
            if (pageSize == 0 || pageIndex == 0)
            {
                ds = await _context.Set<Discipline>()
                                     .Include(r => r.Project)
                                     .Include(r => r.ProjectManager)
                                     .Include(r => r.Draws)
                                     .Include(r => r.Docs)
                                     .Include(r => r.Engineers)
                                     .Include(r => r.DisciplineEngineers)
                                     .ToListAsync();

                return Mapping.Mapper.Map<List<Discipline>, List<DisciplineDto>>(ds);
            }

            ds = await _context.Set<Discipline>()
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .Include(r => r.Project)
                                 .Include(r => r.ProjectManager)
                                 .Include(r => r.Draws)
                                 .Include(r => r.Docs)
                                 .Include(r => r.Engineers)
                                 .Include(r => r.DisciplineEngineers)
                                 .ToListAsync();

            return Mapping.Mapper.Map<List<Discipline>, List<DisciplineDto>>(ds);
        }
    }

    public new async Task<ICollection<DisciplineDto>> GetAll(
        Expression<Func<Discipline, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Discipline> ds;
            if (pageSize == 0 || pageIndex == 0)
            {
                ds = await _context.Set<Discipline>()
                                     .Where(expresion)
                                     .Include(r => r.Project)
                                     .Include(r => r.ProjectManager)
                                     .Include(r => r.Draws)
                                     .Include(r => r.Docs)
                                     .Include(r => r.Engineers)
                                     .Include(r => r.DisciplineEngineers)
                                     .ToListAsync();

                return Mapping.Mapper.Map<List<Discipline>, List<DisciplineDto>>(ds);
            }

            ds = await _context.Set<Discipline>()
                               .Where(expresion)
                               .Skip((pageIndex - 1) * pageSize)
                               .Take(pageSize)
                               .Include(r => r.Project)
                               .Include(r => r.ProjectManager)
                               .Include(r => r.Draws)
                               .Include(r => r.Docs)
                               .Include(r => r.Engineers)
                               .Include(r => r.DisciplineEngineers)
                               .ToListAsync();

            return Mapping.Mapper.Map<List<Discipline>, List<DisciplineDto>>(ds);
        }
    }
}

