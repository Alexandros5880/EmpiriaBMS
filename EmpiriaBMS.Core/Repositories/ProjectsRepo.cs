using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models;
using EmpiriaMS.Models.Models;
using EmpiriaMS.Models.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Config;

namespace EmpiriaBMS.Core.Repositories;
public class ProjectsRepo : Repository<ProjectDto>
{
    public ProjectsRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public new async Task<ProjectDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context
                             .Set<Project>()
                             .Include(r => r.Customer)
                             .Include(r => r.Invoice)
                             .Select(r => Mapping.Mapper.Map<ProjectDto>(r))
                             .FirstOrDefaultAsync(r => r.Id == id);
        }
    }

    public new async Task<ICollection<ProjectDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (pageSize == 0 || pageIndex == 0)
                return await _context.Set<Project>()
                                     .Select(r => Mapping.Mapper.Map<ProjectDto>(r))
                                     .ToListAsync();

            return await _context.Set<Project>()
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .Include(r => r.Customer)
                                 .Include(r => r.Invoice)
                                 .Select(r => Mapping.Mapper.Map<ProjectDto>(r))
                                 .ToListAsync();
        }
    }

    public new async Task<ICollection<ProjectDto>> GetAll(
        Expression<Func<ProjectDto, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (pageSize == 0 || pageIndex == 0)
                return await _context.Set<Project>()
                                     .Select(r => Mapping.Mapper.Map<ProjectDto>(r))
                                     .Where(expresion)
                                     .ToListAsync();

            return await _context.Set<Project>()
                                 .Include(r => r.Customer)
                                 .Include(r => r.Invoice)
                                 .Select(r => Mapping.Mapper.Map<ProjectDto>(r))
                                 .Where(expresion)
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }
    }

}
