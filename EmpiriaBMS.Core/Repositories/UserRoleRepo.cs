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
using EmpiriaMS.Models.Models;

namespace EmpiriaBMS.Core.Repositories;

public class UserRoleRepo : Repository<UserRoleDto, UserRole>, IDisposable
{
    public UserRoleRepo(IDbContextFactory<AppDbContext> dbFactory) : base(dbFactory) { }

    public new async Task<UserRoleDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var ur = await _context
                             .Set<UserRole>()
                             .Include(r => r.Role)
                             .Include(r => r.User)
                             .FirstOrDefaultAsync(r => r.Id == id);

            return Mapping.Mapper.Map<UserRoleDto>(ur);
        }  
    }

    public new async Task<ICollection<UserRoleDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<UserRole> ur;

            if (pageSize == 0 || pageIndex == 0)
            {
                ur = await _context.Set<UserRole>().ToListAsync();

                return Mapping.Mapper.Map<List<UserRole>, List<UserRoleDto>>(ur);
            }

            ur = await _context.Set<UserRole>()
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .Include(r => r.Role)
                                 .Include(r => r.User)
                                 .ToListAsync();

            return Mapping.Mapper.Map<List<UserRole>, List<UserRoleDto>>(ur);
        }  
    }

    public new async Task<ICollection<UserRoleDto>> GetAll(
        Expression<Func<UserRole, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<UserRole> ur;

            if (pageSize == 0 || pageIndex == 0)
            {
                ur = await _context.Set<UserRole>().Where(expresion).ToListAsync();

                return Mapping.Mapper.Map<List<UserRole>, List<UserRoleDto>>(ur);
            }

            ur = await _context.Set<UserRole>()
                               .Where(expresion)
                               .Skip((pageIndex - 1) * pageSize)
                               .Take(pageSize)
                               .Include(r => r.Role)
                               .Include(r => r.User)
                               .ToListAsync();

            return Mapping.Mapper.Map<List<UserRole>, List<UserRoleDto>>(ur);
        }
    }
}
