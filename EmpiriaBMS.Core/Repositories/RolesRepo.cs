using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace EmpiriaBMS.Core.Repositories;
public class RolesRepo : Repository<RoleDto, Role>
{
    public RolesRepo(
        IDbContextFactory<AppDbContext> DbFactory,
        Logging.LoggerManager logger
    ) : base(DbFactory, logger) { }

    public new async Task<RoleDto?> Add(RoleDto entity, bool update = false)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.CreatedDate = update ? DateTime.Now.ToUniversalTime() : entity.CreatedDate;
            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var exists = await _context.Set<Role>().AnyAsync(r => r.Name.Equals(entity.Name));
                if (exists)
                    return null;

                var result = await _context.Set<Role>().AddAsync(Mapping.Mapper.Map<Role>(entity));
                await _context.SaveChangesAsync();

                var id = result.Entity?.Id;
                if (id == null)
                    throw new NullReferenceException(nameof(id));

                var endry = await Get((int)id);

                return Mapping.Mapper.Map<RoleDto>(endry);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception On RolesRepo.Add({Mapping.Mapper.Map<Role>(entity).GetType()}): {ex.Message}, \nInner: {ex.InnerException.Message}");
            return null;
        }
    }

    public new async Task<RoleDto?> Update(RoleDto entity)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var exists = await _context.Set<Role>().Where(r => !r.IsDeleted).AnyAsync(r => r.Name.Equals(entity.Name) && !(r.Id == entity.Id));
                if (exists)
                    return null;

                var entry = await _context.Set<Role>().Where(r => !r.IsDeleted).FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (entry != null)
                {
                    _context.Entry(entry).CurrentValues.SetValues(Mapping.Mapper.Map<Role>(entity));
                    await _context.SaveChangesAsync();
                }

                return Mapping.Mapper.Map<RoleDto>(entry);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception On RolesRepo.Update({Mapping.Mapper.Map<Role>(entity).GetType()}): {ex.Message}, \nInner: {ex.InnerException.Message}");
            return null;
        }
    }

    public async Task<RoleDto?> Get(string name)
    {
        if (name == null)
            throw new ArgumentNullException(nameof(name));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var role = await _context.Roles.Where(r => !r.IsDeleted).FirstOrDefaultAsync(r => r.Name.Equals(name));

            return Mapping.Mapper.Map<RoleDto>(role);
        }
    }

    public async Task<ICollection<RoleDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Role> roles;

            if (pageSize == 0 || pageIndex == 0)
            {


                roles = await _context.Set<Role>()
                                      .Where(r => !r.IsDeleted)
                                      .Include(r => r.RolesPermissions)
                                      .Include(r => r.UserRoles)
                                      .ToListAsync();

                return Mapping.Mapper.Map<List<Role>, List<RoleDto>>(roles);
            }

            roles = await _context.Set<Role>()
                                  .Where(r => !r.IsDeleted)
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
    )
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Role> roles;

            if (pageSize == 0 || pageIndex == 0)
            {


                roles = await _context.Set<Role>()
                                      .Where(r => !r.IsDeleted)
                                      .Where(expresion)
                                      .Include(r => r.RolesPermissions)
                                      .Include(r => r.UserRoles)
                                      .ToListAsync();

                return Mapping.Mapper.Map<List<Role>, List<RoleDto>>(roles);
            }

            roles = await _context.Set<Role>()
                                  .Where(r => !r.IsDeleted)
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
                                        .Where(r => !r.IsDeleted)
                                        .Where(r => r.RoleId == roleId)
                                        .Select(r => r.UserId)
                                        .ToListAsync();

            var users = await _context.Users.Where(r => !r.IsDeleted)
                                            .Where(u => userIds.Contains(u.Id))
                                            .ToListAsync();

            return Mapping.Mapper.Map<List<User>, List<UserDto>>(users);
        }
    }

    public async Task<ICollection<RoleDto>> GetRoles(int userId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var rolesIds = await _context.Set<UserRole>()
                                 .Where(r => !r.IsDeleted)
                                 .Where(ur => ur.UserId == userId)
                                 .Include(ur => ur.Role)
                                 .Select(ur => ur.RoleId)
                                 .ToListAsync();

            var roles = await _context.Set<Role>()
                                .Where(r => !r.IsDeleted)
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
                                 .Where(r => !r.IsDeleted)
                                 .Where(ur => ur.UserId == userId)
                                 .Include(ur => ur.Role)
                                 .Select(ur => ur.RoleId)
                                 .ToListAsync();

            var parentRolesids = await _context.Set<Role>()
                                            .Where(r => !r.IsDeleted)
                                            .Where(r => rolesIds.Contains(r.Id))
                                            .Select(r => r.ParentRoleId)
                                            .ToListAsync();

            // Use Distinct to get unique parent role ids
            var distinctParentRoleIds = parentRolesids.Distinct();



            var parentRoles = await _context.Set<Role>()
                                            .Where(r => !r.IsDeleted)
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
                                             .Where(r => !r.IsDeleted)
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
                var role = await _context.Set<Role>().Where(r => !r.IsDeleted).FirstOrDefaultAsync(r => r.Id == roleId);
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
                                 .Where(r => !r.IsDeleted)
                                 .Where(ur => ur.UserId == userId)
                                 .Include(ur => ur.Role)
                                 .Select(ur => ur.Role)
                                 .ToListAsync();

            var roleIds = roles.Select(r => r.Id);

            var permissionsIdsAll = await _context.Set<RolePermission>()
                                            .Where(r => !r.IsDeleted)
                                            .Where(rp => roleIds.Contains(rp.RoleId))
                                            .Select(rp => rp.PermissionId)
                                            .ToListAsync();

            var permissionsIdsUnique = new HashSet<int>(permissionsIdsAll);

            var permissions = await _context.Set<Permission>()
                                            .Where(r => !r.IsDeleted)
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
                                 .Where(r => !r.IsDeleted)
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
                                 .Where(r => !r.IsDeleted)
                                 .Where(r => !r.IsEmployee)
                                 .ToListAsync();

            return Mapping.Mapper.Map<List<Role>, List<RoleDto>>(roles);
        }
    }

    public async Task<ICollection<RoleDto>> GetEmplyeeRoles(int userId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var roles = await _context.Set<Role>()
                                 .Where(r => !r.IsDeleted)
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
            var roles = await _context.Set<Role>()
                                 .Where(r => !r.IsDeleted)
                                 .Where(r => !r.IsEmployee)
                                 .Where(r => r.UserRoles.Select(ur => ur.UserId).Contains(userId))
                                 .ToListAsync();

            return Mapping.Mapper.Map<List<Role>, List<RoleDto>>(roles);
        }
    }

    public async Task<ICollection<PermissionDto>> GetMyPermissions(int roleId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var permissions = await _context.Set<RolePermission>()
                                            .Where(r => !r.IsDeleted)
                                            .Where(rp => rp.RoleId == roleId)
                                            .Include(rp => rp.Permission)
                                            .Select(rp => rp.Permission)
                                            .Distinct()
                                            .ToListAsync();

            var hasSet = new HashSet<Permission>(permissions);

            return Mapping.Mapper.Map<List<PermissionDto>>(hasSet.ToList());
        }
    }

    public async Task<ICollection<PermissionDto>> GetOtherPermissions(int roleId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var permissions = await _context.Set<RolePermission>()
                                            .Where(r => !r.IsDeleted)
                                            .Where(rp => rp.RoleId != roleId)
                                            .Include(rp => rp.Permission)
                                            .Select(rp => rp.Permission)
                                            .Distinct()
                                            .ToListAsync();

            var hasSet = new HashSet<Permission>(permissions);

            return Mapping.Mapper.Map<List<PermissionDto>>(hasSet.ToList());
        }
    }

    public async Task UpdatePermissions(int roleId, IEnumerable<int> permissionsIds)
    {
        if (roleId == 0)
            throw new ArgumentNullException(nameof(roleId));

        if (permissionsIds == null)
            throw new ArgumentNullException(nameof(permissionsIds));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var permissions = await _context.Set<RolePermission>()
                                            .Where(r => !r.IsDeleted)
                                            .Where(rp => rp.RoleId == roleId)
                                            .ToArrayAsync();

            if (permissions != null)
            {
                foreach (var permission in permissions)
                {
                    await DeleteRolePermission(permission);
                }
                //_context.Set<RolePermission>().RemoveRange(permissions);
            }

            List<RolePermission> rps = new List<RolePermission>();
            foreach (var id in permissionsIds)
            {
                rps.Add(new RolePermission()
                {
                    RoleId = roleId,
                    PermissionId = id
                });
            }

            await _context.Set<RolePermission>().AddRangeAsync(rps);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<RolePermission> DeleteRolePermission(RolePermission entity)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var entry = await _context.Set<RolePermission>().FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (entry != null)
                {
                    entry.IsDeleted = true;
                    await _context.SaveChangesAsync();
                }

                return entry;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception On RolesRepo.DeleteRolePermission({Mapping.Mapper.Map<RolePermission>(entity).GetType()}): {ex.Message}, \nInner: {ex.InnerException.Message}");
            return null;
        }
    }
}
