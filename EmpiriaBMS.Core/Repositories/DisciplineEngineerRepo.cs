using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models;
using EmpiriaMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Repositories;

public class DisciplineEngineerRepo : Repository<DisciplineEngineerDto, DisciplineEngineer>, IDisposable
{
    public DisciplineEngineerRepo(IDbContextFactory<AppDbContext> dbFactory) : base(dbFactory) { }

    public new async Task<DisciplineEngineerDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var de =  await _context
                             .Set<DisciplineEngineer>()
                             .Include(r => r.Discipline)
                             .Include(r => r.Engineer)
                             .FirstOrDefaultAsync(r => r.Id == id);

            return Mapping.Mapper.Map<DisciplineEngineer, DisciplineEngineerDto>(de);
        }
    }

    public new async Task<ICollection<DisciplineEngineerDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<DisciplineEngineer> des;

            if (pageSize == 0 || pageIndex == 0)
            {
                des = await _context.Set<DisciplineEngineer>().ToListAsync();
                return Mapping.Mapper.Map<List<DisciplineEngineer>, List<DisciplineEngineerDto>>(des);
            }

            des =  await _context.Set<DisciplineEngineer>()
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .Include(r => r.Discipline)
                                 .Include(r => r.Engineer)
                                 .ToListAsync();

            return Mapping.Mapper.Map<List<DisciplineEngineer>, List<DisciplineEngineerDto>>(des);
        }  
    }

    public new async Task<ICollection<DisciplineEngineerDto>> GetAll(
        Expression<Func<DisciplineEngineer, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<DisciplineEngineer> des;

            if (pageSize == 0 || pageIndex == 0)
            {
                des = await _context.Set<DisciplineEngineer>().Where(expresion).ToListAsync();
                return Mapping.Mapper.Map<List<DisciplineEngineer>, List<DisciplineEngineerDto>>(des);
            }

            des = await _context.Set<DisciplineEngineer>()
                                .Where(expresion)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .Include(r => r.Discipline)
                                .Include(r => r.Engineer)
                                .ToListAsync();

            return Mapping.Mapper.Map<List<DisciplineEngineer>, List<DisciplineEngineerDto>>(des);
        } 
    }
}
