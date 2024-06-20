using EmpiriaBMS.Models.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EmpiriaBMS.Core.Services.DBManipulation;

public class DatabaseBackupService : IDisposable
{
    private bool disposedValue;

    public readonly string ConnectionString;
    public readonly string DatabaseName;

    protected readonly IDbContextFactory<AppDbContext> _dbContextFactory;

    public DatabaseBackupService(IDbContextFactory<AppDbContext> dbFactory)
    {
        _dbContextFactory = dbFactory;
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            ConnectionString = Environment.GetEnvironmentVariable("ConnectionString");
            if (!string.IsNullOrEmpty(ConnectionString))
                DatabaseName = _getDbName();
        }
    }

    public void BackupDatabase(string backupPath, string databaseName = null)
    {
        var dbName = databaseName ?? DatabaseName;

        if (!string.IsNullOrEmpty(backupPath)
            || !string.IsNullOrEmpty(ConnectionString)
            || !string.IsNullOrEmpty(dbName))
            return;

        var backupFileName = Path.Combine(backupPath, $"{dbName}_{DateTime.Now:yyyyMMddHHmmss}.bak");

        using (var connection = new SqlConnection(ConnectionString))
        {
            var query = $"BACKUP DATABASE [{dbName}] TO DISK = @backupFileName";
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@backupFileName", backupFileName);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    public void BackupAllDatabases(string backupPath)
    {
        if (!string.IsNullOrEmpty(backupPath)
            || !string.IsNullOrEmpty(ConnectionString))
            return;

        using (var connection = new SqlConnection(ConnectionString))
        {
            var query = "SELECT name FROM sys.databases WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb')";
            var command = new SqlCommand(query, connection);

            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var databaseName = reader.GetString(0);
                    BackupDatabase(backupPath, databaseName);
                }
            }
            connection.Close();
        }
    }

    public void RestoreDatabase(string backupFilePath, string databaseName = null)
    {
        var dbName = databaseName ?? DatabaseName;

        if (!string.IsNullOrEmpty(backupFilePath)
            || !string.IsNullOrEmpty(ConnectionString)
            || !string.IsNullOrEmpty(dbName))
            return;

        using (var connection = new SqlConnection(ConnectionString))
        {
            var query = $"ALTER DATABASE [{dbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;" +
                        $"RESTORE DATABASE [{dbName}] FROM DISK = '{backupFilePath}' WITH REPLACE;" +
                        $"ALTER DATABASE [{dbName}] SET MULTI_USER;";

            var command = new SqlCommand(query, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    private string _getDbName()
    {
        int startIndex = ConnectionString.IndexOf("Initial Catalog=") + "Initial Catalog=".Length;
        int endIndex = ConnectionString.IndexOf(';', startIndex);
        string dataSource = ConnectionString.Substring(startIndex, endIndex - startIndex);

        return dataSource;
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
