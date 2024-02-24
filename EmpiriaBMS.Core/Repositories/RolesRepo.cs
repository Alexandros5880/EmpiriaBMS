using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Config;

namespace EmpiriaBMS.Core.Repositories;
public class RolesRepo : Repository<RoleDto, Role>
{
    public RolesRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public async Task<RoleDto?> Get(string name)
    {
        if (name == null)
            throw new ArgumentNullException(nameof(name));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name.Equals(name));

            return Mapping.Mapper.Map<RoleDto>(role);
        }
    }
    
    public async Task<ICollection<UserDto>> GetUsers(int roleId)
    {
        if (roleId == 0)
            throw new NullReferenceException($"No Role Id Specified!");

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var userIds = await _context.Set<UserRole>()
                                        .Where(r => r.RoleId == roleId)
                                        .Select(r => r.UserId)
                                        .ToListAsync();
            
            var users = await _context.Users.Where(u => userIds.Contains(u.Id))
                                            .ToListAsync();

            return Mapping.Mapper.Map<List<User>, List<UserDto>>(users);
        }
    }

    public async Task<ICollection<RoleDto>> GetEmployeeRoles()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var roles = await _context.Set<Role>()
                                 .Where(r => r.IsEmployee)
                                 .ToListAsync();

            return Mapping.Mapper.Map<List<Role>, List<RoleDto>>(roles);
        }
    }

    public async Task<ICollection<RoleDto>> GetCustomerRoles()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var roles = await _context.Set<Role>()
                                 .Where(r => !r.IsEmployee)
                                 .ToListAsync();

            return Mapping.Mapper.Map<List<Role>, List<RoleDto>>(roles);
        }
    }

    public async Task<ICollection<RoleDto>> GetEmplyeeRoles(int userId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var roles =  await _context.Set<Role>()
                                 .Where(r => r.IsEmployee)
                                 .Where(r => r.UserRoles.Select(ur => ur.UserId).Contains(userId))
                                 .ToListAsync();

            return Mapping.Mapper.Map<List<Role>, List<RoleDto>>(roles);
        }
    }

    public async Task<ICollection<RoleDto>> GetCustomerRoles(int userId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var roles =  await _context.Set<Role>()
                                 .Where(r => !r.IsEmployee)
                                 .Where(r => r.UserRoles.Select(ur => ur.UserId).Contains(userId))
                                 .ToListAsync();

            return Mapping.Mapper.Map<List<Role>, List<RoleDto>>(roles);
        }
    }
}
