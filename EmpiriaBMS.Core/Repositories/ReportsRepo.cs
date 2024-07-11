using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpiriaBMS.Core.Repositories;

public class ReportsRepo : IDisposable
{
    private bool disposedValue;
    protected readonly IDbContextFactory<AppDbContext> _dbContextFactory;
    protected readonly Logging.LoggerManager _logger;

    public ReportsRepo(
        IDbContextFactory<AppDbContext> dbFactory,
        Logging.LoggerManager logger
    )
    {
        _dbContextFactory = dbFactory;
        _logger = logger;
    }



    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {

            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
