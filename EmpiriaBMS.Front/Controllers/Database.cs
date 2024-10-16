using EmpiriaBMS.Core;
using Microsoft.AspNetCore.Mvc;
using DB = EmpiriaBMS.Core.Repositories.Horizontal.Database;

namespace EmpiriaBMS.Front.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Database : Controller, IDisposable
{
    protected bool disposedValue;
    private IDataProvider _dataProvider;
    private DB _databaseRepo;

    public Database(IDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
        _databaseRepo = _dataProvider.Database;
    }

    [HttpGet("download-backup")]
    public IActionResult GetBackupFile()
    {
        _databaseRepo.BackupAndDownloadAsync();

        if (System.IO.File.Exists(_databaseRepo.LocalBackupFilePath))
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(_databaseRepo.LocalBackupFilePath);
            return File(fileBytes, "application/octet-stream", "EmbiriaBMS.bak");
        }
        else
        {
            return NotFound("Backup file not found.");
        }
    }
    
    protected override void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _dataProvider?.Dispose();
            }
            disposedValue = true;
        }
    }

    public new void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
