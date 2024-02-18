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

namespace EmpiriaBMS.Core.Repositories;
public class ProjectsRepo : Repository<Project>
{
    public ProjectsRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public new async Task<Project?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        var _context = _dbContextFactory.CreateDbContext();
        return await _context
                         .Set<Project>()
                         .Include(r => r.Customer)
                         .Include(r => r.Invoice)
                         .FirstOrDefaultAsync(r => r.Id == id);
    }

    public new async Task<ICollection<Project>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        var _context = _dbContextFactory.CreateDbContext();
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<Project>().ToListAsync();

        return await _context.Set<Project>()
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .Include(r => r.Customer)
                             .Include(r => r.Invoice)
                             .ToListAsync();
    }

    public new async Task<ICollection<Project>> GetAll(
        Expression<Func<Project, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        var _context = _dbContextFactory.CreateDbContext();
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<Project>().Where(expresion).ToListAsync();

        return await _context.Set<Project>()
                             .Where(expresion)
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .Include(r => r.Customer)
                             .Include(r => r.Invoice)
                             .ToListAsync();
    }

    public async Task<ICollection<User>> GetUsers(int projectId)
    {
        if (projectId == 0)
            throw new NullReferenceException($"No Project Id Specified!");

        var _context = _dbContextFactory.CreateDbContext();
        return await _context.Set<ProjectEmployee>()
                             .Where(r => r.ProjectId == projectId)
                             .Select(r => r.Employee)
                             .ToListAsync();
    }

}
