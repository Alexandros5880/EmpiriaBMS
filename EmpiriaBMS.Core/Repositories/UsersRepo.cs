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

    public new async Task<User?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));
        var _context = _dbContextFactory.CreateDbContext();
        return await _context
                         .Set<User>()
                         .Include(r => r.Disciplines)
                         .Include(r => r.UserRoles)
                         .Include(r => r.DisciplineEngineers)
                         .FirstOrDefaultAsync(r => r.Id == id);
    }

    public new async Task<ICollection<User>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        var _context = _dbContextFactory.CreateDbContext();
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<User>().ToListAsync();

        return await _context.Set<User>()
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .Include(r => r.Disciplines)
                             .Include(r => r.UserRoles)
                             .Include(r => r.DisciplineEngineers)
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
                             .Include(r => r.Disciplines)
                             .Include(r => r.UserRoles)
                             .Include(r => r.DisciplineEngineers)
                             .ToListAsync();
    }

    public async Task<ICollection<Role>> GetRoles(int userId)
    {
        if (userId == 0)
            throw new NullReferenceException($"No User Id Specified!");
        var _context = _dbContextFactory.CreateDbContext();
        return await _context.Set<UserRole>()
                             .Where(r => r.UserId == userId)
                             .Select(r => r.Role)
                             .ToListAsync();
    }

    public async Task<ICollection<User>> GetEmployees()
    {
        var _context = _dbContextFactory.CreateDbContext();

        var emplyeeRolesIds = await _context.Set<Role>()
                                            .Where(r => r.IsEmployee)
                                            .Select(r => r.Id)
                                            .ToListAsync();

        return await _context.Set<UserRole>()
                             .Where(ur => emplyeeRolesIds.Contains(ur.RoleId))
                             .Select(ur => ur.User)
                             .Include(r => r.Disciplines)
                             .Include(r => r.UserRoles)
                             .Include(r => r.DisciplineEngineers)
                             .ToListAsync();
    }

    public async Task<ICollection<User>> GetEmployees(int pageSize = 0, int pageIndex = 0)
    {
        var _context = _dbContextFactory.CreateDbContext();
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<User>().ToListAsync();

        var emplyeeRolesIds = await _context.Set<Role>()
                                            .Where(r => r.IsEmployee)
                                            .Select(r => r.Id)
                                            .ToListAsync();
        
        return await _context.Set<UserRole>()
                             .Where(ur => emplyeeRolesIds.Contains(ur.RoleId))
                             .Select(ur => ur.User)
                             .Include(r => r.Disciplines)
                             .Include(r => r.UserRoles)
                             .Include(r => r.DisciplineEngineers)
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .ToListAsync();
    }

    public async Task<ICollection<User>> GetEmployees(
        Expression<Func<User, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        var _context = _dbContextFactory.CreateDbContext();
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<User>().Where(expresion).ToListAsync();

        var emplyeeRolesIds = await _context.Set<Role>()
                                            .Where(r => r.IsEmployee)
                                            .Select(r => r.Id)
                                            .ToListAsync();

        return await _context.Set<UserRole>()
                             .Where(ur => emplyeeRolesIds.Contains(ur.RoleId))
                             .Select(ur => ur.User)
                             .Include(r => r.Disciplines)
                             .Include(r => r.UserRoles)
                             .Include(r => r.DisciplineEngineers)
                             .Where(expresion)
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .ToListAsync();
    }

    public async Task<ICollection<User>> GetCustomers()
    {
        var _context = _dbContextFactory.CreateDbContext();

        var emplyeeRolesIds = await _context.Set<Role>()
                                            .Where(r => !r.IsEmployee)
                                            .Select(r => r.Id)
                                            .ToListAsync();

        return await _context.Set<UserRole>()
                             .Where(ur => emplyeeRolesIds.Contains(ur.RoleId))
                             .Select(ur => ur.User)
                             .Include(r => r.Disciplines)
                             .Include(r => r.UserRoles)
                             .Include(r => r.DisciplineEngineers)
                             .ToListAsync();
    }

    public async Task<ICollection<User>> GetCustomers(int pageSize = 0, int pageIndex = 0)
    {
        var _context = _dbContextFactory.CreateDbContext();
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<User>().ToListAsync();

        var emplyeeRolesIds = await _context.Set<Role>()
                                            .Where(r => !r.IsEmployee)
                                            .Select(r => r.Id)
                                            .ToListAsync();

        return await _context.Set<UserRole>()
                             .Where(ur => emplyeeRolesIds.Contains(ur.RoleId))
                             .Select(ur => ur.User)
                             .Include(r => r.Disciplines)
                             .Include(r => r.UserRoles)
                             .Include(r => r.DisciplineEngineers)
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .ToListAsync();
    }

    public async Task<ICollection<User>> GetCustomers(
        Expression<Func<User, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        var _context = _dbContextFactory.CreateDbContext();
        if (pageSize == 0 || pageIndex == 0)
            return await _context.Set<User>().Where(expresion).ToListAsync();

        var emplyeeRolesIds = await _context.Set<Role>()
                                            .Where(r => !r.IsEmployee)
                                            .Select(r => r.Id)
                                            .ToListAsync();

        return await _context.Set<UserRole>()
                             .Where(ur => emplyeeRolesIds.Contains(ur.RoleId))
                             .Select(ur => ur.User)
                             .Include(r => r.Disciplines)
                             .Include(r => r.UserRoles)
                             .Include(r => r.DisciplineEngineers)
                             .Where(expresion)
                             .Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .ToListAsync();
    }

}