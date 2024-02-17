using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;
using EmpiriaMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace EmpiriaBMS.Core.Repositories;
public class UsersRepo : Repository<User>
{
    public UsersRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public new async Task<User?> Get(string id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));
        var _context = _dbContextFactory.CreateDbContext();
        return await _context
                         .Set<User>()
                         .Include(r => r.Project)
                         .FirstOrDefaultAsync(r => r.Id.Equals(id));
    }

    public new async Task<ICollection<User>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        var _context = _dbContextFactory.CreateDbContext();
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<User>().ToListAsync();

        return await _context.Set<User>()
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .Include(r => r.Project)
                             .ToListAsync();
    }

    public new async Task<ICollection<User>> GetAll(
        Expression<Func<User, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    )
    {
        var _context = _dbContextFactory.CreateDbContext();
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<User>().Where(expresion).ToListAsync();

        return await _context.Set<User>()
                             .Where(expresion)
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .Include(r => r.Project)
                             .ToListAsync();
    }

    public async Task<ICollection<Role>> GetUsers(string userId)
    {
        if (userId == null)
            throw new NullReferenceException($"No User Id Specified!");
        var _context = _dbContextFactory.CreateDbContext();
        return await _context.Set<UserRole>()
                             .Where(r => r.UserId.Equals(userId))
                             .Select(r => r.Role)
                             .ToListAsync();
    }

    public async Task<ICollection<Project>> GetProjects(string userId)
    {
        if (userId == null)
            throw new NullReferenceException($"No User Id Specified!");
        var _context = _dbContextFactory.CreateDbContext();
        return await _context.Set<ProjectEmployee>()
                             .Where(r => r.EmployeeId.Equals(userId))
                             .Select(r => r.Project)
                             .ToListAsync();
    }

    public async Task<ICollection<Role>> GetRoles(string userId)
    {
        if (userId == null)
            throw new NullReferenceException($"No User Id Specified!");
        var _context = _dbContextFactory.CreateDbContext();
        return await _context.Set<UserRole>()
                             .Where(r => r.UserId.Equals(userId))
                             .Select(r => r.Role)
                             .ToListAsync();
    }

}