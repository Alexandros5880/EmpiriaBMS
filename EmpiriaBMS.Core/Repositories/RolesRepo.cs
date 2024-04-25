using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;
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

    public async Task<ICollection<RoleDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Role> roles;

            var rolesIds = await _context.Set<UserRole>()
                                 .Include(ur => ur.Role)
                                 .Select(ur => ur.RoleId)
                                 .ToListAsync();

            if (pageSize == 0 || pageIndex == 0)
            {


                roles = await _context.Set<Role>()
                                      .Where(r => rolesIds.Contains(r.Id))
                                      .Include(r => r.RolesPermissions)
                                      .Include(r => r.UserRoles)
                                      .ToListAsync();

                return Mapping.Mapper.Map<List<Role>, List<RoleDto>>(roles);
            }

            roles = await _context.Set<Role>()
                                  .Where(r => rolesIds.Contains(r.Id))
                                  .Include(r => r.RolesPermissions)
                                  .Include(r => r.UserRoles)
                                  .Skip((pageIndex - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToListAsync();

            return Mapping.Mapper.Map<List<Role>, List<RoleDto>>(roles);
        }
    }

    public async Task<ICollection<RoleDto>> GetAll(
        Expression<Func<Role, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Role> roles;

            var rolesIds = await _context.Set<UserRole>()
                                 .Include(ur => ur.Role)
                                 .Select(ur => ur.RoleId)
                                 .ToListAsync();

            if (pageSize == 0 || pageIndex == 0)
            {
                

                roles = await _context.Set<Role>()
                                      .Where(r => rolesIds.Contains(r.Id))
                                      .Where(expresion)
                                      .Include(r => r.RolesPermissions)
                                      .Include(r => r.UserRoles)
                                      .ToListAsync();

                return Mapping.Mapper.Map<List<Role>, List<RoleDto>>(roles);
            }

            roles = await _context.Set<Role>()
                                  .Where(r => rolesIds.Contains(r.Id))
                                  .Where(expresion)
                                  .Include(r => r.RolesPermissions)
                                  .Include(r => r.UserRoles)
                                  .Skip((pageIndex - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToListAsync();

            return Mapping.Mapper.Map<List<Role>, List<RoleDto>>(roles);
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

    public async Task<ICollection<RoleDto>> GetRoles(int userId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var rolesIds = await _context.Set<UserRole>()
                                 .Where(ur => ur.UserId == userId)
                                 .Include(ur => ur.Role)
                                 .Select(ur => ur.RoleId)
                                 .ToListAsync();

            var roles = await _context.Set<Role>()
                                .Where(r => rolesIds.Contains(r.Id))
                                .Include(r => r.RolesPermissions)
                                .Include(r => r.UserRoles)
                                .ToListAsync();

            return Mapping.Mapper.Map<List<Role>, List<RoleDto>>(roles);
        }
    }

    public async Task<RoleDto> GetParentRole(int userId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var rolesIds = await _context.Set<UserRole>()
                                 .Where(ur => ur.UserId == userId)
                                 .Include(ur => ur.Role)
                                 .Select(ur => ur.RoleId)
                                 .ToListAsync();

            var parentRolesids = await _context.Set<Role>()
                                            .Where(r => rolesIds.Contains(r.Id))
                                            .Select(r => r.ParentRoleId)
                                            .ToListAsync();

            // Use Distinct to get unique parent role ids
            var distinctParentRoleIds = parentRolesids.Distinct();



            var parentRoles = await _context.Set<Role>()
                                            .Where(r => distinctParentRoleIds.Contains(r.Id))
                                            .Include(r => r.ParentRole)
                                            .Select(r => r.ParentRole)
                                            .Where(r => r != null)
                                            .ToListAsync();


            if (parentRoles.Any(r => r.ParentRoleId == null))
                return Mapping.Mapper.Map<RoleDto>(parentRoles.FirstOrDefault(r => r.ParentRoleId == null));

            // TODO: RolesRepo.GetParentRole -> Get The Most Paowerfull Role!
                                    ///

            // Returns the parrent roles with the most permissions
            var rolesPermissions = await _context.Set<RolePermission>()
                                             .Where(rp => distinctParentRoleIds.Contains(rp.RoleId))
                                             .ToListAsync();

            // Group RolePermissions by RoleId
            var rolePermissionsGrouped = rolesPermissions.GroupBy(rp => rp.RoleId);

            Role parentRole = null;
            int permisionsCount = 0;

            // Iterate over groups and map permissions to roles
            foreach (var group in rolePermissionsGrouped)
            {
                var roleId = group.Key;
                var role = await _context.Set<Role>().FirstOrDefaultAsync(r => r.Id == roleId);
                var permissions = group.Select(rp => rp.Permission).ToList();

                if (permisionsCount < permissions.Count)
                {
                    permisionsCount = permissions.Count;
                    parentRole = role;
                }
                
            }

            return Mapping.Mapper.Map<RoleDto>(parentRole);
        }
    }

    public async Task<ICollection<PermissionDto>> GetPermissions(int userId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var roles = await _context.Set<UserRole>()
                                 .Where(ur => ur.UserId == userId)
                                 .Include(ur => ur.Role)
                                 .Select(ur => ur.Role)
                                 .ToListAsync();

            var roleIds = roles.Select(r => r.Id);

            var permissionsIdsAll = await _context.Set<RolePermission>()
                                            .Where(rp => roleIds.Contains(rp.RoleId))
                                            .Select(rp => rp.PermissionId)
                                            .ToListAsync();

            var permissionsIdsUnique = new HashSet<int>(permissionsIdsAll);

            var permissions = await _context.Set<Permission>()
                                            .Where(p => permissionsIdsUnique.Contains(p.Id))
                                            .ToListAsync();

            return Mapping.Mapper.Map<List<Permission>, List<PermissionDto>>(permissions);
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
