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

public class OtherRepo : Repository<OtherDto, Other>, IDisposable
{
    public OtherRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    //public new async Task<OtherDto?> Get(int id)
    //{
    //    if (id == 0)
    //        throw new ArgumentNullException(nameof(id));

    //    using (var _context = _dbContextFactory.CreateDbContext())
    //    {
    //        var Other = await _context
    //                         .Set<Other>()
    //                         .Include(r => r.Discipline)
    //                         .FirstOrDefaultAsync(r => r.Id == id);
            
    //        return Mapping.Mapper.Map<OtherDto>(Other);
    //    }
    //}

    //public new async Task<ICollection<OtherDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    //{
    //    using (var _context = _dbContextFactory.CreateDbContext())
    //    {
    //        List<Other> ds;

    //        if (pageSize == 0 || pageIndex == 0)
    //        {
    //            ds =  await _context.Set<Other>()
    //                                 .Include(r => r.Discipline)
    //                                 .ToListAsync();

    //            return Mapping.Mapper.Map<List<Other>, List<OtherDto>>(ds);
    //        }

    //        ds = await _context.Set<Other>()
    //                             .Skip((pageIndex - 1) * pageSize)
    //                             .Take(pageSize)
    //                             .Include(r => r.Discipline)
    //                             .ToListAsync();

    //        return Mapping.Mapper.Map<List<Other>, List<OtherDto>>(ds);
    //    } 
    //}

    //public new async Task<ICollection<OtherDto>> GetAll(
    //    Expression<Func<Other, bool>> expresion,
    //    int pageSize = 0,
    //    int pageIndex = 0
    //) {
    //    using (var _context = _dbContextFactory.CreateDbContext())
    //    {
    //        List<Other> ds;

    //        if (pageSize == 0 || pageIndex == 0)
    //        {
    //            ds = await _context.Set<Other>()
    //                               .Where(expresion)
    //                               .Include(r => r.Discipline)
    //                               .ToListAsync();

    //            return Mapping.Mapper.Map<List<Other>, List<OtherDto>>(ds);
    //        }

    //        ds = await _context.Set<Other>()
    //                           .Where(expresion)
    //                           .Skip((pageIndex - 1) * pageSize)
    //                           .Take(pageSize)
    //                           .Include(r => r.Discipline)
    //                           .ToListAsync();

    //        return Mapping.Mapper.Map<List<Other>, List<OtherDto>>(ds);
    //    }
    //}
}
