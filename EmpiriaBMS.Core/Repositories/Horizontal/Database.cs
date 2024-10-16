using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Repositories.Horizontal;

public class Database : IDisposable
{
    protected bool disposedValue;
    protected readonly IDbContextFactory<AppDbContext> _dbContextFactory;
    protected readonly Logging.LoggerManager _logger;

    public Database(
        IDbContextFactory<AppDbContext> dbFactory,
        Logging.LoggerManager logger
    ) {
        _dbContextFactory = dbFactory;
        _logger = logger;
        _logger.ProjectName = "EmbiriaBMS.Core";
    }

    #region BackUp
    string _ftpSqlAddress = "ftp://127.0.0.1:21";
    string _ftpSqlUsername = "anonymous";
    string _ftpSqlPassword = "";

    public string DownloadLink => @"/api/database/download-backup";
    public string LocalBackupFilePath => Path.Combine(AppContext.BaseDirectory, "Backups", "DatabaseBackUp.bak");
    string _remoteBackupFilePath = @"/var/opt/mssql/backups/databaseBackUp.bak";

    private void DownloadBackupFromServer()
    {
        try
        {
            string backupDirectory = Path.GetDirectoryName(LocalBackupFilePath)!;
            if (!Directory.Exists(backupDirectory))
                Directory.CreateDirectory(backupDirectory);

            using (WebClient client = new WebClient())
            {
                client.Credentials = new NetworkCredential(_ftpSqlUsername, _ftpSqlPassword);
                client.DownloadFile(_ftpSqlAddress + _remoteBackupFilePath, LocalBackupFilePath);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On Database.DownloadBackupFromServer(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    public void BackupAndDownloadAsync()
    {
        // Step 1: Create the backup on the remote SQL Server
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                _context.BackupDatabase(_remoteBackupFilePath);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On Database.BackupAndDownloadAsync() - Step 1: {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }

        // Step 2: Download the backup from the remote server to the local Blazor server
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                DownloadBackupFromServer();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On Database.BackupAndDownloadAsync() - Step 2: {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }
    #endregion

    public void RestoreDataBase()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            string backupFilePath = @"C:\Backups\yourdb.bak";
            _context.RestoreDatabase(backupFilePath);
        }
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
