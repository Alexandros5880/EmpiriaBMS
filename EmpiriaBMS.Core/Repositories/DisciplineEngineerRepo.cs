using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Repositories;

public class DisciplineEngineerRepo : Repository<DisciplineEngineerDto>, IDisposable
{
    public DisciplineEngineerRepo(IDbContextFactory<AppDbContext> dbFactory) : base(dbFactory) { }

    public new async Task<DisciplineEngineerDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context
                             .Set<DisciplineEngineer>()
                             .Include(r => r.Discipline)
                             .Include(r => r.Engineer)
                             .Select(r => Mapping.Mapper.Map<DisciplineEngineerDto>(r))
                             .FirstOrDefaultAsync(r => r.Id == id);
        }
    }

    public new async Task<ICollection<DisciplineEngineerDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (pageSize == 0 || pageIndex == 0)
                return await _context.Set<DisciplineEngineer>()
                                     .Select(r => Mapping.Mapper.Map<DisciplineEngineerDto>(r))
                                     .ToListAsync();

            return await _context.Set<DisciplineEngineer>()
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .Include(r => r.Discipline)
                                 .Include(r => r.Engineer)
                                 .Select(r => Mapping.Mapper.Map<DisciplineEngineerDto>(r))
                                 .ToListAsync();
        }  
    }

    public new async Task<ICollection<DisciplineEngineerDto>> GetAll(
        Expression<Func<DisciplineEngineerDto, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (pageSize == 0 || pageIndex == 0)
                return await _context.Set<DisciplineEngineer>()
                                     .Select(r => Mapping.Mapper.Map<DisciplineEngineerDto>(r))
                                     .Where(expresion)
                                     .ToListAsync();

            return await _context.Set<DisciplineEngineer>()
                                 .Include(r => r.Discipline)
                                 .Include(r => r.Engineer)
                                 .Select(r => Mapping.Mapper.Map<DisciplineEngineerDto>(r))
                                 .Where(expresion)
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        } 
    }
}
