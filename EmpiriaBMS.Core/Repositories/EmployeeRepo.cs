using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models;
using EmpiriaMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Repositories;
public class EmployeeRepo : Repository<User>
{
    public EmployeeRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public async Task<ICollection<Role>> GetUsers(int userId)
    {
        if (userId == 0)
            throw new NullReferenceException($"No User Id Specified!");

        var _context = _dbContextFactory.CreateDbContext();
        return await _context.Set<UserRole>()
                             .Where(r => r.UserId == userId)
                             .Select(r => r.Role)
                             .ToListAsync();
    }

    public async Task<ICollection<Project>> GetProjects(int userId)
    {
        if (userId == 0)
            throw new NullReferenceException($"No User Id Specified!");

        var _context = _dbContextFactory.CreateDbContext();
        return await _context.Set<ProjectEmployee>()
                             .Where(r => r.EmployeeId == userId)
                             .Select(r => r.Project)
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

}
