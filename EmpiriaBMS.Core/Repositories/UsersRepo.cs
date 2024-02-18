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
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Config;

namespace EmpiriaBMS.Core.Repositories;
public class UsersRepo : Repository<UserDto>
{
    public UsersRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public new async Task<UserDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context
                             .Set<User>()
                             .Include(r => r.Disciplines)
                             .Include(r => r.UserRoles)
                             .Include(r => r.DisciplineEngineers)
                             .Select(r => Mapping.Mapper.Map<UserDto>(r))
                             .FirstOrDefaultAsync(r => r.Id == id);
        }
    }

    public new async Task<ICollection<UserDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (pageSize == 0 || pageIndex == 0)
                return await _context.Set<User>()
                                     .Select(r => Mapping.Mapper.Map<UserDto>(r))
                                     .ToListAsync();

            return await _context.Set<User>()
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .Include(r => r.Disciplines)
                                 .Include(r => r.UserRoles)
                                 .Include(r => r.DisciplineEngineers)
                                 .Select(r => Mapping.Mapper.Map<UserDto>(r))
                                 .ToListAsync();
        }
    }

    public new async Task<ICollection<UserDto>> GetAll(
        Expression<Func<UserDto, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (pageSize == 0 || pageIndex == 0)
                return await _context.Set<User>()
                                     .Select(r => Mapping.Mapper.Map<UserDto>(r))
                                     .Where(expresion)
                                     .ToListAsync();

            return await _context.Set<User>()
                                 .Include(r => r.Disciplines)
                                 .Include(r => r.UserRoles)
                                 .Include(r => r.DisciplineEngineers)
                                 .Select(r => Mapping.Mapper.Map<UserDto>(r))
                                 .Where(expresion)
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }
    }

    public async Task<ICollection<RoleDto>> GetRoles(int userId)
    {
        if (userId == 0)
            throw new NullReferenceException($"No User Id Specified!");
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context.Set<UserRole>()
                                 .Where(r => r.UserId == userId)
                                 .Select(r => r.Role)
                                 .Select(r => Mapping.Mapper.Map<RoleDto>(r))
                                 .ToListAsync();
        }
    }

    public async Task<ICollection<UserDto>> GetEmployees()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
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
                                 .Select(r => Mapping.Mapper.Map<UserDto>(r))
                                 .ToListAsync();
        }
    }

    public async Task<ICollection<UserDto>> GetEmployees(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (pageSize == 0 || pageIndex == 0)
                return await _context.Set<User>()
                                     .Select(r => Mapping.Mapper.Map<UserDto>(r))
                                     .ToListAsync();

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
                                 .Select(r => Mapping.Mapper.Map<UserDto>(r))
                                 .ToListAsync();
        } 
    }

    public async Task<ICollection<UserDto>> GetEmployees(
        Expression<Func<UserDto, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (pageSize == 0 || pageIndex == 0)
                return await _context.Set<User>()
                                     .Select(r => Mapping.Mapper.Map<UserDto>(r))
                                     .Where(expresion)
                                     .ToListAsync();

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
                                 .Select(r => Mapping.Mapper.Map<UserDto>(r))
                                 .Where(expresion)
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }
    }

    public async Task<ICollection<UserDto>> GetCustomers()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
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
                                 .Select(r => Mapping.Mapper.Map<UserDto>(r))
                                 .ToListAsync();
        }
    }

    public async Task<ICollection<UserDto>> GetCustomers(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (pageSize == 0 || pageIndex == 0)
                return await _context.Set<User>()
                                     .Select(r => Mapping.Mapper.Map<UserDto>(r))
                                     .ToListAsync();

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
                                 .Select(r => Mapping.Mapper.Map<UserDto>(r))
                                 .ToListAsync();
        }
    }

    public async Task<ICollection<UserDto>> GetCustomers(
        Expression<Func<UserDto, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (pageSize == 0 || pageIndex == 0)
                return await _context.Set<User>()
                                     .Select(r => Mapping.Mapper.Map<UserDto>(r))
                                     .Where(expresion)
                                     .ToListAsync();

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
                                 .Select(r => Mapping.Mapper.Map<UserDto>(r))
                                 .Where(expresion)
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }
    }

}