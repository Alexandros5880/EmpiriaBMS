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
                                     .ToListAsync();

                return Mapping.Mapper.Map<List<Discipline>, List<DisciplineDto>>(ds);
            }

            ds = await _context.Set<Discipline>()
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .Include(r => r.Project)
                                 .Include(r => r.ProjectManager)
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
                                     .Include(r => r.DisciplineEmployees)
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
                               .Include(r => r.DisciplineEmployees)
                               .ToListAsync();

            return Mapping.Mapper.Map<List<Discipline>, List<DisciplineDto>>(ds);
        }
    }

    public async Task<List<DrawDto>> GetDraws(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var draws = await _context
                             .Set<Draw>()
                             .Where(d => d.DisciplineId == id)
                             .ToListAsync();

            return Mapping.Mapper.Map<List<Draw>, List<DrawDto>>(draws);
        }
    }

    public async Task<List<DrawDto>> GetDraws(int[] ids)
    {
        if (ids == null)
            throw new ArgumentNullException(nameof(ids));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var draws = await _context
                             .Set<Draw>()
                             .Where(d => ids.Contains(d.DisciplineId))
                             .ToListAsync();

            return Mapping.Mapper.Map<List<Draw>, List<DrawDto>>(draws);
        }
    }

    public async Task<List<DocDto>> GetDocs(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var docs = await _context
                             .Set<Doc>()
                             .Where(d => d.DisciplineId == id)
                             .ToListAsync();

            return Mapping.Mapper.Map<List<Doc>, List<DocDto>>(docs);
        }
    }

    public async Task<List<DocDto>> GetDocs(int[] ids)
    {
        if (ids == null)
            throw new ArgumentNullException(nameof(ids));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var docs = await _context
                             .Set<Doc>()
                             .Where(d => ids.Contains(d.DisciplineId))
                             .ToListAsync();

            return Mapping.Mapper.Map<List<Doc>, List<DocDto>>(docs);
        }
    }

}

