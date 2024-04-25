using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpiriaBMS.Core.Repositories;

public class AddressRepo : Repository<AddressDto, Address>
{
    public AddressRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }
}
