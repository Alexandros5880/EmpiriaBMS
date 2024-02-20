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
using EmpiriaBMS.Core.Hellpers;


namespace EmpiriaBMS.Core.Repositories;

public class DrawRepo : Repository<DrawDto, Draw>, IDisposable
{
    public DrawRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public new async Task<DrawDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var dr = await _context
                             .Set<Draw>()
                             .FirstOrDefaultAsync(r => r.Id == id);

            return Mapping.Mapper.Map<DrawDto>(dr);
        }
    }

    public new async Task<ICollection<DrawDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Draw> drs;

            if (pageSize == 0 || pageIndex == 0)
            {
                drs = await _context.Set<Draw>()
                                     .ToListAsync();

                return Mapping.Mapper.Map<List<Draw>, List<DrawDto>>(drs);
            }


            drs = await _context.Set<Draw>()
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();

            return Mapping.Mapper.Map<List<Draw>, List<DrawDto>>(drs);
        }
    }

    public new async Task<ICollection<DrawDto>> GetAll(
        Expression<Func<Draw, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Draw> drs;

            if (pageSize == 0 || pageIndex == 0)
            {
                drs = await _context.Set<Draw>()
                                    .Where(expresion)
                                    .ToListAsync();

                return Mapping.Mapper.Map<List<Draw>, List<DrawDto>>(drs);
            }


            drs = await _context.Set<Draw>()
                                .Where(expresion)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

            return Mapping.Mapper.Map<List<Draw>, List<DrawDto>>(drs);
        }
    }

    public async Task<int> GetUsersWorkPackegedCompleted(int userId)
    {
        if (userId == 0)
            throw new ArgumentException(nameof(userId));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var disciplines = await _context.Set<DisciplineEmployee>()
                                              .Where(de => de.EmployeeId == userId)
                                              .Select(de => de.Discipline)
                                              .ToListAsync();

            var Draws2D = disciplines.Select(d => d.DisciplinesDraws.Select(dd => dd.Draw));
            List<int?> drawsCompleteds = new List<int?>();

            foreach(var d1 in Draws2D)
                foreach (var d2 in d1)
                    drawsCompleteds.Add(d2.CompletionEstimation);

            return drawsCompleteds.Sum() ?? 0;
        }
    }
}