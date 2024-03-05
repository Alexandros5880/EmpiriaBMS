using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Repositories;

public class PermissionRepo : Repository<PermissionDto, Permission>, IDisposable
{
    public PermissionRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }
}

