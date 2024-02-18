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
public class UsersRepo : Repository<UserDto, User>
{
    public UsersRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public new async Task<UserDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var u = await _context
                             .Set<User>()
                             .Include(r => r.Disciplines)
                             .Include(r => r.UserRoles)
                             .Include(r => r.DisciplineEngineers)
                             .FirstOrDefaultAsync(r => r.Id == id);

            return Mapping.Mapper.Map<UserDto>(u);
        }
    }

    public new async Task<ICollection<UserDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<User> us;

            if (pageSize == 0 || pageIndex == 0)
            {
                us = await _context.Set<User>().ToListAsync();

                return Mapping.Mapper.Map<List<User>, List<UserDto>>(us);
            }


            us = await _context.Set<User>()
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .Include(r => r.Disciplines)
                                 .Include(r => r.UserRoles)
                                 .Include(r => r.DisciplineEngineers)
                                 .ToListAsync();

            return Mapping.Mapper.Map<List<User>, List<UserDto>>(us);
        }
    }

    public new async Task<ICollection<UserDto>> GetAll(
        Expression<Func<User, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<User> us;

            if (pageSize == 0 || pageIndex == 0)
            {
                us = await _context.Set<User>().Where(expresion).ToListAsync();

                return Mapping.Mapper.Map<List<User>, List<UserDto>>(us);
            }


            us = await _context.Set<User>()
                               .Where(expresion)
                               .Skip((pageIndex - 1) * pageSize)
                               .Take(pageSize)
                               .Include(r => r.Disciplines)
                               .Include(r => r.UserRoles)
                               .Include(r => r.DisciplineEngineers)
                               .ToListAsync();

            return Mapping.Mapper.Map<List<User>, List<UserDto>>(us);
        }
    }

    public async Task<ICollection<RoleDto>> GetRoles(int userId)
    {
        if (userId == 0)
            throw new NullReferenceException($"No User Id Specified!");
 
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var roleIds = await _context.Set<UserRole>()
                                        .Where(r => r.UserId == userId)
                                        .Select(r => r.RoleId)
                                        .ToListAsync();

            var roles = await _context.Roles.Where(r => roleIds.Contains(r.Id))
                                       .ToListAsync();

            return Mapping.Mapper.Map<List<Role>, List<RoleDto>>(roles);
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

            var employeeIds = await _context.UserRoles.Where(ur => emplyeeRolesIds.Contains(ur.Id))
                                                      .Select(ur => ur.UserId)
                                                      .ToListAsync();

            var users = await _context.Users.Where(u => employeeIds.Contains(u.Id))
                                       .Include(r => r.Disciplines)
                                       .Include(r => r.UserRoles)
                                       .Include(r => r.DisciplineEngineers)
                                       .ToListAsync();

            return Mapping.Mapper.Map<List<User>, List<UserDto>>(users);
        }
    }

    public async Task<ICollection<UserDto>> GetEmployees(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var emplyeeRolesIds = await _context.Set<Role>()
                                                .Where(r => r.IsEmployee)
                                                .Select(r => r.Id)
                                                .ToListAsync();

            var employeeIds = await _context.UserRoles.Where(ur => emplyeeRolesIds.Contains(ur.Id))
                                                      .Select(ur => ur.UserId)
                                                      .ToListAsync();

            List<User> users;

            if (pageSize == 0 || pageIndex == 0)
            {
                users = await _context.Users.Where(u => employeeIds.Contains(u.Id))
                                           .ToListAsync();

                return Mapping.Mapper.Map<List<User>, List<UserDto>>(users);
            }

            

            users = await _context.Users.Where(u => employeeIds.Contains(u.Id))
                                       .Include(r => r.Disciplines)
                                       .Include(r => r.UserRoles)
                                       .Include(r => r.DisciplineEngineers)
                                       .Skip((pageIndex - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();

            return Mapping.Mapper.Map<List<User>, List<UserDto>>(users);
        } 
    }

    public async Task<ICollection<UserDto>> GetEmployees(
        Expression<Func<User, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var emplyeeRolesIds = await _context.Set<Role>()
                                                .Where(r => r.IsEmployee)
                                                .Select(r => r.Id)
                                                .ToListAsync();

            var employeeIds = await _context.UserRoles.Where(ur => emplyeeRolesIds.Contains(ur.Id))
                                                      .Select(ur => ur.UserId)
                                                      .ToListAsync();

            List<User> users;

            if (pageSize == 0 || pageIndex == 0)
            {
                users = await _context.Users.Where(u => employeeIds.Contains(u.Id))
                                           .Where(expresion)
                                           .ToListAsync();

                return Mapping.Mapper.Map<List<User>, List<UserDto>>(users);
            }



            users = await _context.Users.Where(u => employeeIds.Contains(u.Id))
                                       .Include(r => r.Disciplines)
                                       .Include(r => r.UserRoles)
                                       .Include(r => r.DisciplineEngineers)
                                       .Where(expresion)
                                       .Skip((pageIndex - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();

            return Mapping.Mapper.Map<List<User>, List<UserDto>>(users);
        }
    }

    public async Task<ICollection<UserDto>> GetCustomers()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var customersRolesIds = await _context.Set<Role>()
                                                .Where(r => !r.IsEmployee)
                                                .Select(r => r.Id)
                                                .ToListAsync();

            var customerIds = await _context.UserRoles.Where(ur => customersRolesIds.Contains(ur.Id))
                                                      .Select(ur => ur.UserId)
                                                      .ToListAsync();

            var users = await _context.Users.Where(u => customerIds.Contains(u.Id))
                                       .Include(r => r.Disciplines)
                                       .Include(r => r.UserRoles)
                                       .Include(r => r.DisciplineEngineers)
                                       .ToListAsync();

            return Mapping.Mapper.Map<List<User>, List<UserDto>>(users);
        }
    }

    public async Task<ICollection<UserDto>> GetCustomers(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var customersRolesIds = await _context.Set<Role>()
                                                .Where(r => !r.IsEmployee)
                                                .Select(r => r.Id)
                                                .ToListAsync();

            var customerIds = await _context.UserRoles.Where(ur => customersRolesIds.Contains(ur.Id))
                                                      .Select(ur => ur.UserId)
                                                      .ToListAsync();

            List<User> users;

            if (pageSize == 0 || pageIndex == 0)
            {
                users = await _context.Users.Where(u => customerIds.Contains(u.Id))
                                           .ToListAsync();

                return Mapping.Mapper.Map<List<User>, List<UserDto>>(users);
            }

            users = await _context.Users.Where(u => customerIds.Contains(u.Id))
                                       .Include(r => r.Disciplines)
                                       .Include(r => r.UserRoles)
                                       .Include(r => r.DisciplineEngineers)
                                       .Skip((pageIndex - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();

            return Mapping.Mapper.Map<List<User>, List<UserDto>>(users);
        }
    }

    public async Task<ICollection<UserDto>> GetCustomers(
        Expression<Func<User, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var customersRolesIds = await _context.Set<Role>()
                                                .Where(r => !r.IsEmployee)
                                                .Select(r => r.Id)
                                                .ToListAsync();

            var customerIds = await _context.UserRoles.Where(ur => customersRolesIds.Contains(ur.Id))
                                                      .Select(ur => ur.UserId)
                                                      .ToListAsync();

            List<User> users;

            if (pageSize == 0 || pageIndex == 0)
            {
                users = await _context.Users.Where(u => customerIds.Contains(u.Id))
                                           .Where(expresion)
                                           .ToListAsync();

                return Mapping.Mapper.Map<List<User>, List<UserDto>>(users);
            }

            users = await _context.Users.Where(u => customerIds.Contains(u.Id))
                                       .Include(r => r.Disciplines)
                                       .Include(r => r.UserRoles)
                                       .Include(r => r.DisciplineEngineers)
                                       .Where(expresion)
                                       .Skip((pageIndex - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();

            return Mapping.Mapper.Map<List<User>, List<UserDto>>(users);
        }
    }

}