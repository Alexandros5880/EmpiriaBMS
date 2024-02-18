using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models;
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
public class RolesRepo : Repository<RoleDto>
{
    public RolesRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public async Task<ICollection<UserDto>> GetUsers(int roleId)
    {
        if (roleId == 0)
            throw new NullReferenceException($"No Role Id Specified!");

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context.Set<UserRole>()
                                 .Where(r => r.RoleId == roleId)
                                 .Select(r => r.User)
                                 .Select(r => Mapping.Mapper.Map<UserDto>(r))
                                 .ToListAsync();
        }
    }

    public async Task<ICollection<RoleDto>> GetEmployeeRoles()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context.Set<Role>()
                                 .Where(r => r.IsEmployee)
                                 .Select(r => Mapping.Mapper.Map<RoleDto>(r))
                                 .ToListAsync();
        }
    }

    public async Task<ICollection<RoleDto>> GetCustomerRoles()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context.Set<Role>()
                                 .Where(r => !r.IsEmployee)
                                 .Select(r => Mapping.Mapper.Map<RoleDto>(r))
                                 .ToListAsync();
        }
    }

    public async Task<ICollection<RoleDto>> GetEmplyeeRoles(int userId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context.Set<Role>()
                                 .Where(r => r.IsEmployee)
                                 .Where(r => r.UserRoles.Select(ur => ur.UserId).Contains(userId))
                                 .Select(r => Mapping.Mapper.Map<RoleDto>(r))
                                 .ToListAsync();
        }
    }

    public async Task<ICollection<RoleDto>> GetCustomerRoles(int userId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context.Set<Role>()
                                 .Where(r => !r.IsEmployee)
                                 .Where(r => r.UserRoles.Select(ur => ur.UserId).Contains(userId))
                                 .Select(r => Mapping.Mapper.Map<RoleDto>(r))
                                 .ToListAsync();
        }
    }
}
