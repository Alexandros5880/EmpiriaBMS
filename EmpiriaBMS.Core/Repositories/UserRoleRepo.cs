using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Config;

namespace EmpiriaBMS.Core.Repositories;

public class UserRoleRepo : Repository<UserRoleDto>, IDisposable
{
    public UserRoleRepo(IDbContextFactory<AppDbContext> dbFactory) : base(dbFactory) { }

    public new async Task<UserRoleDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context
                             .Set<UserRole>()
                             .Include(r => r.Role)
                             .Include(r => r.User)
                             .Select(r => Mapping.Mapper.Map<UserRoleDto>(r))
                             .FirstOrDefaultAsync(r => r.Id == id);
        }  
    }

    public new async Task<ICollection<UserRoleDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (pageSize == 0 || pageIndex == 0)
                return await _context.Set<UserRole>()
                                     .Select(r => Mapping.Mapper.Map<UserRoleDto>(r))
                                     .ToListAsync();

            return await _context.Set<UserRole>()
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .Include(r => r.Role)
                                 .Include(r => r.User)
                                 .Select(r => Mapping.Mapper.Map<UserRoleDto>(r))
                                 .ToListAsync();
        }  
    }

    public new async Task<ICollection<UserRoleDto>> GetAll(
        Expression<Func<UserRoleDto, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (pageSize == 0 || pageIndex == 0)
                return await _context.Set<UserRole>()
                                     .Select(r => Mapping.Mapper.Map<UserRoleDto>(r))
                                     .Where(expresion)
                                     .ToListAsync();

            return await _context.Set<UserRole>()
                                 .Include(r => r.Role)
                                 .Include(r => r.User)
                                 .Select(r => Mapping.Mapper.Map<UserRoleDto>(r))
                                 .Where(expresion)
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }
    }
}
