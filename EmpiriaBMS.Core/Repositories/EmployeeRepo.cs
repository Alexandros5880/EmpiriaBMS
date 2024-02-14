using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models;
using EmpiriaMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Repositories;
public class EmployeeRepo : Repository<User>
{
    public EmployeeRepo(AppDbContext context) : base(context) { }

    public async Task<ICollection<Role>> GetUsers(string userId)
    {
        if (userId == null)
            throw new NullReferenceException($"No User Id Specified!");

        return await _context.Set<UserRole>()
                             .Where(r => r.UserId.Equals(userId))
                             .Select(r => r.Role)
                             .ToListAsync();
    }

    public async Task<ICollection<Project>> GetProjects(string userId)
    {
        if (userId == null)
            throw new NullReferenceException($"No User Id Specified!");

        return await _context.Set<ProjectEmployee>()
                             .Where(r => r.EmployeeId.Equals(userId))
                             .Select(r => r.Project)
                             .ToListAsync();
    }

    public async Task<ICollection<Role>> GetRoles(string userId)
    {
        if (userId == null)
            throw new NullReferenceException($"No User Id Specified!");

        return await _context.Set<UserRole>()
                             .Where(r => r.UserId.Equals(userId))
                             .Select(r => r.Role)
                             .ToListAsync();
    }

}
