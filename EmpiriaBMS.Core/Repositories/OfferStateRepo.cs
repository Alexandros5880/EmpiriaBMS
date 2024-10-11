using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpiriaBMS.Core.Repositories;

public class OfferStateRepo : Repository<OfferStateDto, OfferState>
{
    public OfferStateRepo(
        IDbContextFactory<AppDbContext> DbFactory,
        Logging.LoggerManager logger
    ) : base(DbFactory, logger) { }

}