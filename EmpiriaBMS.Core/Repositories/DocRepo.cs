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
using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Core.Repositories;

public class DocRepo : Repository<DocDto, Doc>, IDisposable
{
    public DocRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public new async Task<DocDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var doc = await _context
                             .Set<Doc>()
                             .Include(r => r.Discipline)
                             .FirstOrDefaultAsync(r => r.Id == id);
            
            return Mapping.Mapper.Map<DocDto>(doc);
        }
    }

    public new async Task<ICollection<DocDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Doc> ds;

            if (pageSize == 0 || pageIndex == 0)
            {
                ds =  await _context.Set<Doc>()
                                     .Include(r => r.Discipline)
                                     .ToListAsync();

                return Mapping.Mapper.Map<List<Doc>, List<DocDto>>(ds);
            }

            ds = await _context.Set<Doc>()
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .Include(r => r.Discipline)
                                 .ToListAsync();

            return Mapping.Mapper.Map<List<Doc>, List<DocDto>>(ds);
        } 
    }

    public new async Task<ICollection<DocDto>> GetAll(
        Expression<Func<Doc, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Doc> ds;

            if (pageSize == 0 || pageIndex == 0)
            {
                ds = await _context.Set<Doc>()
                                   .Where(expresion)
                                   .Include(r => r.Discipline)
                                   .ToListAsync();

                return Mapping.Mapper.Map<List<Doc>, List<DocDto>>(ds);
            }

            ds = await _context.Set<Doc>()
                               .Where(expresion)
                               .Skip((pageIndex - 1) * pageSize)
                               .Take(pageSize)
                               .Include(r => r.Discipline)
                               .ToListAsync();

            return Mapping.Mapper.Map<List<Doc>, List<DocDto>>(ds);
        }
    }
}
