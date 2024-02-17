using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models;
using EmpiriaMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Repositories;
public class RolesRepo : Repository<Role>
{
    public RolesRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public async Task<ICollection<User>> GetUsers(int roleId)
    {
        if (roleId == 0)
            throw new NullReferenceException($"No Role Id Specified!");
        var _context = _dbContextFactory.CreateDbContext();
        return await _context.Set<UserRole>()
                             .Where(r => r.RoleId == roleId)
                             .Select(r => r.User)
                             .ToListAsync();
    }

}
