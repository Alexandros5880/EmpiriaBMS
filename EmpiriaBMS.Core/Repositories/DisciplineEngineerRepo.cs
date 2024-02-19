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

public class DisciplineEngineerRepo : Repository<DisciplineEmployeeDto, DisciplineEmployee>, IDisposable
{
    public DisciplineEngineerRepo(IDbContextFactory<AppDbContext> dbFactory) : base(dbFactory) { }

    public new async Task<DisciplineEmployeeDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var de =  await _context
                             .Set<DisciplineEmployee>()
                             .Include(r => r.Discipline)
                             .Include(r => r.Employee)
                             .FirstOrDefaultAsync(r => r.Id == id);

            return Mapping.Mapper.Map<DisciplineEmployee, DisciplineEmployeeDto>(de);
        }
    }

    public new async Task<ICollection<DisciplineEmployeeDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<DisciplineEmployee> des;

            if (pageSize == 0 || pageIndex == 0)
            {
                des = await _context.Set<DisciplineEmployee>().ToListAsync();
                return Mapping.Mapper.Map<List<DisciplineEmployee>, List<DisciplineEmployeeDto>>(des);
            }

            des =  await _context.Set<DisciplineEmployee>()
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .Include(r => r.Discipline)
                                 .Include(r => r.Employee)
                                 .ToListAsync();

            return Mapping.Mapper.Map<List<DisciplineEmployee>, List<DisciplineEmployeeDto>>(des);
        }  
    }

    public new async Task<ICollection<DisciplineEmployeeDto>> GetAll(
        Expression<Func<DisciplineEmployee, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<DisciplineEmployee> des;

            if (pageSize == 0 || pageIndex == 0)
            {
                des = await _context.Set<DisciplineEmployee>().Where(expresion).ToListAsync();
                return Mapping.Mapper.Map<List<DisciplineEmployee>, List<DisciplineEmployeeDto>>(des);
            }

            des = await _context.Set<DisciplineEmployee>()
                                .Where(expresion)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .Include(r => r.Discipline)
                                .Include(r => r.Employee)
                                .ToListAsync();

            return Mapping.Mapper.Map<List<DisciplineEmployee>, List<DisciplineEmployeeDto>>(des);
        } 
    }
}
