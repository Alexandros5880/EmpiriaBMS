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

public class DrawRepo : Repository<DrawDto, Draw>, IDisposable
{
    public DrawRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    //public new async Task<DrawDto?> Get(int id)
    //{
    //    if (id == 0)
    //        throw new ArgumentNullException(nameof(id));

    //    using (var _context = _dbContextFactory.CreateDbContext())
    //    {
    //        var dr = await _context
    //                         .Set<Draw>()
    //                         .Include(r => r.Discipline)
    //                         .FirstOrDefaultAsync(r => r.Id == id);

    //        return Mapping.Mapper.Map<DrawDto>(dr);
    //    }
    //}

    //public new async Task<ICollection<DrawDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    //{
    //    using (var _context = _dbContextFactory.CreateDbContext())
    //    {
    //        List<Draw> drs;

    //        if (pageSize == 0 || pageIndex == 0)
    //        {
    //            drs = await _context.Set<Draw>()
    //                                 .Include(r => r.Discipline)
    //                                 .ToListAsync();

    //            return Mapping.Mapper.Map<List<Draw>, List<DrawDto>>(drs);
    //        }


    //        drs = await _context.Set<Draw>()
    //                             .Skip((pageIndex - 1) * pageSize)
    //                             .Take(pageSize)
    //                             .Include(r => r.Discipline)
    //                             .ToListAsync();

    //        return Mapping.Mapper.Map<List<Draw>, List<DrawDto>>(drs);
    //    }
    //}

    //public new async Task<ICollection<DrawDto>> GetAll(
    //    Expression<Func<Draw, bool>> expresion,
    //    int pageSize = 0,
    //    int pageIndex = 0
    //) {
    //    using (var _context = _dbContextFactory.CreateDbContext())
    //    {
    //        List<Draw> drs;

    //        if (pageSize == 0 || pageIndex == 0)
    //        {
    //            drs = await _context.Set<Draw>()
    //                                .Where(expresion)
    //                                .Include(r => r.Discipline)
    //                                .ToListAsync();

    //            return Mapping.Mapper.Map<List<Draw>, List<DrawDto>>(drs);
    //        }


    //        drs = await _context.Set<Draw>()
    //                            .Where(expresion)
    //                            .Skip((pageIndex - 1) * pageSize)
    //                            .Take(pageSize)
    //                            .Include(r => r.Discipline)
    //                            .ToListAsync();

    //        return Mapping.Mapper.Map<List<Draw>, List<DrawDto>>(drs);
    //    }
    //}
}